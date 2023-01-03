using Newtonsoft.Json;
using RestSharp;
using System;
using System.Drawing;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using SomiodWebApplication.Models;
using System.Xml;

namespace LightA
{
    public partial class LightA : Form
    {
        MqttClient mClient = null;
        string endpoint = "127.0.0.1";
        string baseURI = @"http://localhost:53204";
        RestClient client = null;
        string activeModule = "";
        string eventMqt = "";

        public LightA()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "LightA";
            client = new RestClient(baseURI);

            textBoxApplicationName.Text = Properties.Settings.Default.application_name;
            textBoxModuleName.Text = Properties.Settings.Default.module_name;
            textBoxSubscriptionName.Text = Properties.Settings.Default.subscription_name;
            textBoxSubscriptionEndPoint.Text = Properties.Settings.Default.subscription_endpoint;
            comboBoxEventType.Text = Properties.Settings.Default.subscription_event;
        }
        
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string body = Encoding.UTF8.GetString(e.Message);
            string[] vars = body.Split(';');
            
            if (vars.Length != 2)
            {
                MessageBox.Show("Something went wrong with Mosquitto. Please try again later");
                return;
            }

            string eventMosquitto = vars[0].ToLower();
            string message = vars[1];

            if (!eventMqt.Contains(eventMosquitto))
            {
                //ignores publish because it's not the type of event that this application subscribed to
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(message);
            string content = doc.SelectSingleNode("//content").InnerText;
            
            if(content.Equals("ON"))
            {
                if (richTextBoxLightBulb.InvokeRequired)
                {
                    richTextBoxLightBulb.Invoke(new Action(() => richTextBoxLightBulb.BackColor = Color.Yellow));
                }
            }
            else if(content.Equals("OFF"))
            {
                if (richTextBoxLightBulb.InvokeRequired)
                {
                    richTextBoxLightBulb.Invoke(new Action(() => richTextBoxLightBulb.BackColor = Color.Black));
                }
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string applicationName = textBoxApplicationName.Text;
            if (applicationName.Equals(""))
            {
                MessageBox.Show("Application name cannot be empty");
                return;
            }

            string moduleName = textBoxModuleName.Text;
            if (moduleName.Equals(""))
            {
                MessageBox.Show("Module name cannot be empty");
                return;
            }

            string subscriptionName = textBoxSubscriptionName.Text;
            if (subscriptionName.Equals(""))
            {
                MessageBox.Show("Subscription name cannot be empty");
                return;
            }

            string subscriptionEventType = comboBoxEventType.GetItemText(comboBoxEventType.SelectedItem);
            if (!subscriptionEventType.Equals("creation") && !subscriptionEventType.Equals("deletion") && !subscriptionEventType.Equals("creation and deletion"))
            {
                MessageBox.Show("Subscription event not properly selected");
                return;
            }
            
            string subscrptionEndPoint = textBoxSubscriptionEndPoint.Text;
            if (subscrptionEndPoint.Equals(""))
            {
                MessageBox.Show("Subscription endpoint cannot be empty");
                return;
            }

            try
            {
                if (activeModule != "" && activeModule != moduleName)
                {
                    mClient.Disconnect();
                }

                SomiodWebApplication.Models.Application appCreated = createApplication(applicationName);
                if (appCreated != null)
                {
                    applicationName = appCreated.Name;
                }
                else {
                    applicationName = applicationName.Replace(" ", "-");
                }

                SomiodWebApplication.Models.Module moduleCreated =  createModule(moduleName, applicationName);
                if (moduleCreated != null)
                {
                    moduleName = moduleCreated.Name;
                }
                else
                {
                    moduleName = moduleName.Replace(" ", "-");
                }

                string responseSubscription = createSubscription(subscriptionEventType, subscrptionEndPoint, subscriptionName, moduleName, applicationName);
                if (!responseSubscription.Contains("exists"))
                {
                    string topic = applicationName + "/" + moduleName ;
                    connectToMosquitto(topic);
                    activeModule = moduleName;
                    eventMqt = subscriptionEventType;
                    MessageBox.Show("Created and Connected to Server Successfully");
                }
                else
                {
                    MessageBox.Show(responseSubscription);
                }
            }
            catch
            {
                throw new Exception("Could not connect to the server");
            }
        }

        private void connectToMosquitto(string topic)
        {
            try
            {
                mClient = new MqttClient(IPAddress.Parse(endpoint));
                mClient.Connect(Guid.NewGuid().ToString());
                if (!mClient.IsConnected)
                {
                    Console.WriteLine("Error connecting to message broker...");
                    return;
                }
                mClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }; //QoS – depends on the topics number
                                                                                                               // mClient.Subscribe(module, qosLevels)
                mClient.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            }
            catch (Exception)
            {
                throw new Exception("Could not connect to the server");
            }
        }

        private SomiodWebApplication.Models.Application createApplication(string applicationName)
        {
            try
            {
                // Creates the Object Application
                SomiodWebApplication.Models.Application application = new SomiodWebApplication.Models.Application
                {
                    Name = applicationName,
                    Res_type = "application"
                };

                // Sends Application to the server
                var request = new RestRequest("/api/somiod", Method.Post);
                request.AddJsonBody(application);
                RestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<SomiodWebApplication.Models.Application>(response.Content);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("exists"))
                {
                    return null;
                }
                throw new Exception("Could not create application");
            }
        }

        private Module createModule(string moduleName, string applicationName)
        {
            try
            {
                // Creates the Object Module
                Module module = new Module
                {
                    Name = moduleName,
                    Res_type = "module"
                };

                // Sends Module to the server
                var request = new RestRequest("/api/somiod/" + applicationName, Method.Post);
                request.AddJsonBody(module);
                RestResponse response = client.Execute(request);

                return JsonConvert.DeserializeObject<Module>(response.Content);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("exists"))
                {
                    return null;
                }
                throw new Exception("Could not create module");
            }
        }

        private string createSubscription(string subscriptionEventType, string subscrptionEndPoint, string subscriptionName, string moduleName, string applicationName)
        {
            try
            {
                // Creates the Object Subscription
                SomiodWebApplication.Models.Subscription subscription = new SomiodWebApplication.Models.Subscription
                {
                    Name = subscriptionName,
                    Res_type = "subscription",
                    Event = subscriptionEventType,
                    Endpoint = subscrptionEndPoint
                };

                // Sends Subscription to the server
                var request = new RestRequest("/api/somiod/" + applicationName + "/" + moduleName, Method.Post);
                request.AddJsonBody(subscription);
                RestResponse response = client.Execute(request);
                return response.Content;
            }
            catch
            {
                throw new Exception("Could not create subscription");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEventType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

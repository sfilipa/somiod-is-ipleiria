using Newtonsoft.Json;
using RestSharp;
using SomiodWebApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace LightB
{
    public partial class LightB : Form
    {
        MqttClient mClient = null;
        string endpoint = "127.0.0.1";
        string baseURI = @"http://localhost:53204";
        RestClient client = null;
        string activeModule = "";
        public LightB()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "LightB";
            client = new RestClient(baseURI);
        }
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            String message = Encoding.UTF8.GetString(e.Message);
            if (message.Equals("ON"))
            {
                if (richTextBoxLightBulb.InvokeRequired)
                {
                    richTextBoxLightBulb.Invoke(new Action(() => richTextBoxLightBulb.BackColor = Color.Salmon));
                }
            }
            else
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
                if(activeModule != "" && activeModule != moduleName)
                {
                    mClient.Disconnect();
                }
                SomiodWebApplication.Models.Application appCreated = createApplication(applicationName);
                if (appCreated != null)
                {
                    applicationName = appCreated.Name;
                }
                else
                {
                    applicationName = applicationName.Replace(" ", "-");
                }

                Module moduleCreated = createModule(moduleName, applicationName);
                if (moduleCreated != null)
                {
                    moduleName = moduleCreated.Name;
                }
                else
                {
                    moduleName = moduleName.Replace(" ", "-");
                }
                
                createSubscription(subscriptionEventType, subscrptionEndPoint, subscriptionName, moduleName, applicationName);
                connectToMosquitto(moduleName);
                activeModule = moduleName;
                MessageBox.Show("Created and Connected to Server Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void connectToMosquitto(string moduleName)
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
                mClient.Subscribe(new string[] { moduleName }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
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
            catch(Exception ex)
            {
                if (ex.Message.Contains("exists")) {
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

        private void createSubscription(string subscriptionEventType, string subscrptionEndPoint, string subscriptionName, string moduleName, string applicationName)
        {
            try
            {
                // Creates the Object Subscription
                Subscription subscription = new Subscription
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
            }
            catch
            {
                throw new Exception("Could not create subscription");
            }
        }
    }
}

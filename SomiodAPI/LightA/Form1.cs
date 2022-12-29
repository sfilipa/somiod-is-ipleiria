using RestSharp;
using System;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace LightA
{
    public partial class LightbulbA : Form
    {
        MqttClient mClient = null;
        String domain = "127.0.0.1";
        String application = "lighting";
        String[] module = { "lightbulb" };
        string res_type = "subscription";
        string event_type = "creation and deletion";
        string endpoint = "127.0.0.1";
        string baseURI = @"http://localhost:53204";
        RestClient client = null;
        
        public LightbulbA()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new RestClient(baseURI);
            
            try
            {
                // Creates the Object Application
                SomiodWebApplication.Models.Subscription subscription = new SomiodWebApplication.Models.Subscription
                {
                    Name = module[0],
                    Res_type = res_type,
                    Event = event_type,
                    Endpoint = endpoint
                };


                var request = new RestRequest("/api/somiod/" + application + "/" + module[0], Method.Post);

                // Adds the message body to the response
                request.AddJsonBody(subscription);


                RestResponse response = client.Execute(request);
                MessageBox.Show(response.StatusCode.ToString());

                mClient = new MqttClient(IPAddress.Parse(endpoint));
                mClient.Connect(Guid.NewGuid().ToString());
                if (!mClient.IsConnected)
                {
                    Console.WriteLine("Error connecting to message broker...");
                    return;
                }
                mClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE}; //QoS – depends on the topics number
                mClient.Subscribe(module, qosLevels);
            }
            catch (Exception)
            {
                throw new Exception("Could not connect to the server");
            }
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            MessageBox.Show("Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " +
            e.Topic);
            this.BackColor = Color.Yellow;
        }
    }
}

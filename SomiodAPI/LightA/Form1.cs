using RestSharp;
using System;
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
        String module = "lightbulb";
        string res_type = "subscription";
        string event_type = "creation and deletion";
        string endpoint = "mqtt://localhost:1883";
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
                    Name = module,
                    Res_type = res_type,
                    Event = event_type,
                    Endpoint = endpoint
                };


                var request = new RestRequest("/api/somiod/" + application + "/" + module, Method.Post);

                // Adds the message body to the response
                request.AddJsonBody(subscription);


                RestResponse response = client.Execute(request);
                MessageBox.Show(response.StatusCode.ToString());
            }
            catch (Exception)
            {
                throw new Exception("Could not connect to the server");
            }
        }
    }
}

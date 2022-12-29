using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using RestSharp;

namespace RemoteLights
{
    public partial class Remote : Form
    {
        MqttClient mcClient = null;
        String domain = "127.0.0.1";
        String application = "lighting";
        String my_module = "lightcommand";
        string module_to_send = "lightbulb";
        string res_type = "subscription";
        string event_type = "creation and deletion";
        string endpoint = "mqtt://localhost:1883";
        string baseURI = @"http://localhost:53204";
        RestClient client = null;
        
        public Remote()
        {
            InitializeComponent();
        }

        private void buttonOFF_Click(object sender, EventArgs e)
        {
            try
            {
                // Creates the Object Application
                SomiodWebApplication.Models.Data data = new SomiodWebApplication.Models.Data
                {
                    Content = "OFF",
                    Res_type = "data"
                };


                var request = new RestRequest("/api/somiod/" + application + "/" + module_to_send, Method.Post);

                // Adds the message body to the response
                request.AddJsonBody(data);


                RestResponse response = client.Execute(request);
                //MessageBox.Show(response.StatusCode.ToString());

                mcClient.Publish(module_to_send, Encoding.UTF8.GetBytes(data.Content));
               /* if (mcClient.IsConnected)
                {
                    mcClient.Unsubscribe(new string[] { "lightbulb" }); //Put this in a button to see notify!
                    mcClient.Disconnect(); //Free process and process's resources
                }*/

            }
            catch (Exception)
            {
                throw new Exception("Error Connection to Server");
            }
        }

        private void buttonON_Click(object sender, EventArgs e)
        {
            try
            {
                // Creates the Object Application
                SomiodWebApplication.Models.Data data = new SomiodWebApplication.Models.Data
                {
                    Content = "ON",
                    Res_type = "data"
                };


                var request = new RestRequest("/api/somiod/" + application + "/" + module_to_send, Method.Post);

                // Adds the message body to the response
                request.AddJsonBody(data);


                RestResponse response = client.Execute(request);
               // MessageBox.Show(response.StatusCode.ToString());



                mcClient.Publish(module_to_send, Encoding.UTF8.GetBytes(data.Content));
               /* if (mcClient.IsConnected)
                {
                    mcClient.Unsubscribe(new string[] { "lightbulb" }); //Put this in a button to see notify!
                    mcClient.Disconnect(); //Free process and process's resources
                }*/
            }
            catch (Exception)
            {
                throw new Exception("Error Connection to Server");
            }
        }
        
        private void Remote_Load(object sender, EventArgs e)
        {
            client = new RestClient(baseURI);

            mcClient = new MqttClient(IPAddress.Parse(domain));

            mcClient.Connect(Guid.NewGuid().ToString());
            if (!mcClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return;
            }
           // MessageBox.Show("Connected!");
        }
    }
}

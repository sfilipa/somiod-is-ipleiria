using SomiodWebApplication.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace LightA
{
    public partial class Form1 : Form
    {
        MqttClient mClient = null;
        String domain = "127.0.0.1";
        String application = "lighting";
        String[] module = { "blinds_v2" };
        public Form1()
        {
            InitializeComponent();
        }

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            MessageBox.Show("Received = " + Encoding.UTF8.GetString(e.Message) +
            " on topic " + e.Topic);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Creates the Object Application
                SomiodWebApplication.Models.Subscription subscription = new SomiodWebApplication.Models.Data
                {
                    Content = dataContent,
                    Res_type = "data"
                };


                var request = new RestRequest("/api/somiod/" + applicationName + "/" + moduleName, Method.Post);

                // Adds the message body to the response
                request.AddJsonBody(data);


                RestResponse response = client.Execute(request);
                MessageBox.Show(response.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

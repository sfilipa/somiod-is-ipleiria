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

            mClient = new MqttClient(IPAddress.Parse(domain));
            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return;
            }
            //Specify events we are interest on
            //New Msg Arrived
            mClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            //Subscribe to topics
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE}; //QoS – depends on the topics number
            mClient.Subscribe(module, qosLevels);
            MessageBox.Show("Connected");
        }
    }
}

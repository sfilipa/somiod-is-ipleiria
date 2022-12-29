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

namespace RemoteLights
{
    public partial class Form1 : Form
    {
        MqttClient mcClient = null;
        String domain = "127.0.0.1";
        String application = "lighting";
        String[] module = { "blinds_v2" };
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOFF_Click(object sender, EventArgs e)
        {
            mcClient.Publish(module[0], Encoding.UTF8.GetBytes("OFF"));
            if (mcClient.IsConnected)
            {
                mcClient.Unsubscribe(module); //Put this in a button to see notify!
                mcClient.Disconnect(); //Free process and process's resources
            }

        }

        private void buttonON_Click(object sender, EventArgs e)
        {
            mcClient.Publish(module[0], Encoding.UTF8.GetBytes("ON"));
            if (mcClient.IsConnected)
            {
                mcClient.Unsubscribe(module); //Put this in a button to see notify!
                mcClient.Disconnect(); //Free process and process's resources
            }
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            mcClient = new MqttClient(IPAddress.Parse(domain));
            
            mcClient.Connect(Guid.NewGuid().ToString());
            if (!mcClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return;
            }
            MessageBox.Show("Connected!");
        }
    }
}

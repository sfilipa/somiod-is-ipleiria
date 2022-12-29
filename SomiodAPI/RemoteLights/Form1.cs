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
          
        }

        private void buttonON_Click(object sender, EventArgs e)
        {

        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}

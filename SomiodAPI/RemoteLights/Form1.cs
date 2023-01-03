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
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RemoteLights
{
    public partial class Remote : Form
    {
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

                if (comboBoxApplications.SelectedItem == null)
                {
                    MessageBox.Show("Please select an application first");
                    return;
                }

                if (comboBoxModules.SelectedItem == null)
                {
                    MessageBox.Show("Please select a module first");
                    return;
                }

                string application = comboBoxApplications.SelectedItem.ToString();
                string module = comboBoxModules.SelectedItem.ToString();

                var request = new RestRequest("/api/somiod/" + application + "/" + module, Method.Post);

                // Adds the message body to the response
                request.AddJsonBody(data);

                RestResponse response = client.Execute(request);
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

                if (comboBoxApplications.SelectedItem == null)
                {
                    MessageBox.Show("Please select an application first");
                    return;
                }

                if (comboBoxModules.SelectedItem == null)
                {
                    MessageBox.Show("Please select a module first");
                    return;
                }

                string application = comboBoxApplications.SelectedItem.ToString();
                string module = comboBoxModules.SelectedItem.ToString();
                var request = new RestRequest("/api/somiod/" + application + "/" + module, Method.Post);

                // Adds the message body to the response
                request.AddJsonBody(data);

                RestResponse response = client.Execute(request);
            }
            catch (Exception)
            {
                throw new Exception("Error Connection to Server");
            }
        }
        
        private async void Remote_Load(object sender, EventArgs e)
        {
            client = new RestClient(baseURI);

            loadApplicationsIntoComboBox();
        }

        private void loadApplicationsIntoComboBox()
        {
            comboBoxApplications.Items.Clear();
            var request = new RestRequest("/api/somiod/", Method.Get);
            RestResponse response = client.Execute(request);
            string xmlResponseString = response.Content;

            XmlDocument xmlDoc = new XmlDocument();
            XmlNamespaceManager ns = new XmlNamespaceManager(xmlDoc.NameTable);
            ns.AddNamespace("arr", "http://schemas.datacontract.org/2004/07/SomiodWebApplication.Models");
            xmlDoc.LoadXml(xmlResponseString);

            XmlNodeList list = xmlDoc.SelectNodes("//arr:Application/arr:Name", ns);
            foreach (XmlNode item in list)
            {
                comboBoxApplications.Items.Add(item.InnerText);
            }
            comboBoxApplications.SelectedIndexChanged += new EventHandler(comboBoxChanged);
        }

        private void comboBoxChanged(object sender, EventArgs e)
        {
            comboBoxModules.Items.Clear();
            var request = new RestRequest("/api/somiod/"+ comboBoxApplications.SelectedItem.ToString() + "/modules", Method.Get);
            RestResponse response = client.Execute(request);
            string xmlResponseString = response.Content;
            XmlDocument xmlDoc = new XmlDocument();
            
            XmlNamespaceManager ns = new XmlNamespaceManager(xmlDoc.NameTable);
            ns.AddNamespace("arrm", "http://schemas.datacontract.org/2004/07/SomiodWebApplication.Models");
            xmlDoc.LoadXml(xmlResponseString);

            XmlNodeList list = xmlDoc.SelectNodes("//arrm:Module/arrm:Name", ns);
            foreach (XmlNode item in list)
            {
                comboBoxModules.Items.Add(item.InnerText);
            }

            comboBoxModules.Enabled = !(list.Count == 0);
        }

        private void button1_Click(object sender, EventArgs e) //Refresh applications and modules
        {
            comboBoxApplications.ResetText();
            comboBoxModules.ResetText();
            loadApplicationsIntoComboBox();
        }
    }
}

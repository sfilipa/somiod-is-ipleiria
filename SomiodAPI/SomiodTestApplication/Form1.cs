using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SomiodTestApplication
{
    public partial class Form1 : Form
    {
        string baseURI = @"http://localhost:53204"; 
        RestClient client = null;
        public Form1()
        {
            InitializeComponent();
            client = new RestClient(baseURI);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string requestURI = "/api/somiod/";
            XmlDocument doc = RequestsHandler.getApplicationsAsAXMLDocument(requestURI, client);

            // Loads the XML document to the RichTextBox
            richTextBoxListApplications.Text = doc.InnerXml;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string applicationName = textBoxGetApplicationByName.Text;
            if (applicationName == "")
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            string requestURI = "/api/somiod/" + applicationName;
            XmlDocument doc = RequestsHandler.getApplicationsAsAXMLDocument(requestURI, client);

            // Loads the XML document to the RichTextBox
            richTextBoxApplication.Text = doc.InnerXml;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void listBoxModules_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBoxApplicationName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonPOSTApplication_Click(object sender, EventArgs e)
        {
            // Verifies if Application Name Input is Empty
            string applicationName = textBoxApplicationName.Text;
            if (applicationName == "")
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            // Makes the Put Request
            string requestURI = "/api/somiod/";
            try
            {
                RequestsHandler.createApplication(requestURI, client, applicationName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void buttonPUTApplication_Click(object sender, EventArgs e)
        {
            // Verifies if Application Name Input is Empty
            string applicationName = textBoxApplicationName.Text;
            if (applicationName == "")
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            // Verifies if New Application Name Input is Empty
            string newApplicationName = textBoxApplicationNewName.Text;
            if (newApplicationName == "")
            {
                MessageBox.Show("Please enter the new application name");
                return;
            }

            // Makes the Put Request
            string requestURI = "/api/somiod/" + applicationName;
            try
            {
                RequestsHandler.updateApplicationName(requestURI, client, newApplicationName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void buttonDELApplication_Click(object sender, EventArgs e)
        {
            // Verifies if Application Name Input is Empty
            string applicationName = textBoxApplicationName.Text;
            if (applicationName == "")
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            // Makes the Put Request
            string requestURI = "/api/somiod/" + applicationName;
            try
            {
                RequestsHandler.deleteApplication(requestURI, client);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

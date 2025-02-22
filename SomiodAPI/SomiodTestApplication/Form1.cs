﻿using RestSharp;
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

        private void button1_Click(object sender, EventArgs e) // get all applications
        {
            richTextBoxListApplications.Clear();
            string requestURI = "/api/somiod/";
            XmlDocument doc = RequestsHandler.getResponseAsXMLDocument(requestURI, client, "Applications");

            if (doc == null)
            {
                return;
            }

            // Loads the XML document to the RichTextBox
            richTextBoxListApplications.Text = doc.InnerXml;
        }

        private void button2_Click(object sender, EventArgs e) //get specific application
        {
            richTextBoxApplication.Clear();
            string applicationName = textBoxGetApplicationByName.Text;
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            string requestURI = "/api/somiod/" + applicationName;
            XmlDocument doc = RequestsHandler.getResponseAsXMLDocument(requestURI, client, "Application");
            if(doc == null)
            {
                return;
            }
            // Loads the XML document to the RichTextBox
            richTextBoxApplication.Text = doc.InnerXml;
        }

        private void label1_Click(object sender, EventArgs e)
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
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            // Makes the Post Request
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
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            // Verifies if New Application Name Input is Empty
            string newApplicationName = textBoxApplicationNewName.Text;
            if (newApplicationName.Trim().Length == 0)
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
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            // Makes the Put Request
            string requestURI = "/api/somiod/" + applicationName;
            try
            {
                RequestsHandler.delete(requestURI, client);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //--------------------- MODULES ---------------------

        private void button1_Click_1(object sender, EventArgs e) //get all modules from application
        {
            richTextBoxListModules.Clear();
            string applicationName = textBoxApplicationNameModule.Text;
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }
            string requestURI = "/api/somiod/" + applicationName + "/modules";
            XmlDocument doc = RequestsHandler.getResponseAsXMLDocument(requestURI, client, "Modules");
            
            if(doc == null)
            {
                return;
            }
            
            richTextBoxListModules.Text = doc.InnerXml;
        }

        private void buttonGetModule_Click(object sender, EventArgs e)
        {
            richTextBoxSpecificModule.Clear();
            string applicationName = textBoxApplicationNameModule.Text;
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }
            string moduleName = textBoxGetModuleName.Text;
            if (moduleName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the module name");
                return;
            }
            string requestURI = "/api/somiod/" + applicationName + "/" + moduleName;
            XmlDocument doc = RequestsHandler.getResponseAsXMLDocument(requestURI, client, "Module");

            if (doc == null)
            {
                return;
            }

            richTextBoxSpecificModule.Text = doc.InnerXml;
        }

        private void buttonPOSTModule_Click(object sender, EventArgs e)
        {
            // Verifies if Application Name Input is Empty
            string applicationName = textBoxApplicationNameModule.Text;
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            string moduleName = textBoxModuleName.Text;
            if (moduleName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the new module name");
                return;
            }

            // Makes the Put Request
            string requestURI = "/api/somiod/" + applicationName;
            try
            {
                RequestsHandler.createModule(requestURI, client, applicationName, moduleName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void buttonPUTModule_Click(object sender, EventArgs e)
        {
            string applicationName = textBoxApplicationNameModule.Text;
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            string moduleName = textBoxModuleName.Text;
            if (moduleName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the module name to change");
                return;
            }

            string newModuleName = textBoxModuleNewName.Text;
            if (newModuleName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the new module name");
                return;
            }

            // Makes the Put Request
            string requestURI = "/api/somiod/" + applicationName +"/"+ moduleName;
            try
            {
                RequestsHandler.updateModule(requestURI, client, newModuleName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void buttonDELModule_Click(object sender, EventArgs e)
        {
            // Verifies if Application Name Input is Empty
            string applicationName = textBoxApplicationNameModule.Text;
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            string moduleName = textBoxModuleName.Text;
            if (moduleName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the new module name");
                return;
            }

            string requestURI = "/api/somiod/" + applicationName + "/" + moduleName;
            try
            {
                RequestsHandler.delete(requestURI, client);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void textBoxGetModuleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        //--------------------- END OF MODULES ---------------------

        //--------------------- DATA ---------------------
        private void buttonPOSTData_Click(object sender, EventArgs e)
        {
            // Verifies if Application Name Input is Empty
            string applicationName = textBoxApplicationNameData.Text;
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            string moduleName = textBoxModuleNameData.Text;
            if (moduleName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the module name");
                return;
            }

            string dataContent = richTextBoxDataContent.Text;
            if (dataContent.Trim().Length == 0)
            {
                MessageBox.Show("Please enter some data content");
                return;
            }

            // Makes the Put Request
            string requestURI = "/api/somiod/" + applicationName + "/" + moduleName;
            try
            {
                RequestsHandler.createData(requestURI, client, applicationName, moduleName,dataContent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void buttonDELData_Click(object sender, EventArgs e)
        {
            // Verifies if Application Name Input is Empty
            string applicationName = textBoxApplicationNameData.Text;
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            string moduleName = textBoxModuleNameData.Text;
            if (moduleName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the new module name");
                return;
            }

            string dataId = textBoxDataID.Text;
            if (dataId.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the data ID");
                return;
            }

            string requestURI = "/api/somiod/" + applicationName + "/" + moduleName + "/data" + "/" + dataId;
            try
            {
                RequestsHandler.delete(requestURI, client);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        //--------------------- END OF DATA ---------------------


        //--------------------- SUBSCRIPTION ---------------------
        private void buttonLigarDesligar_Click(object sender, EventArgs e)
        {

        }

        private void buttonPOSTSubscription_Click(object sender, EventArgs e)
        {
            string applicationName = textBoxApplicationNameSubscription.Text;
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            string moduleName = textBoxModuleNameSubscription.Text;
            if (moduleName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the new module name");
                return;
            }

            string subscriptionName = textBoxSubscriptionNamePOST.Text;
            if (subscriptionName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the new subscription name");
                return;
            }

            string eventName = comboBoxSubscriptionEvents.SelectedItem.ToString();
            if (!eventName.Equals("creation") && !eventName.Equals("deletion") && !eventName.Equals("creation and deletion"))
            {
                MessageBox.Show("Event should be 'creation', 'deletion' or 'creation and deletion'");
                return;
            }

            string endpoint = textBoxEndPoint.Text;

            // Makes the Put Request
            string requestURI = "/api/somiod/" + applicationName + "/" + moduleName;
            try
            {
                RequestsHandler.createSubscription(requestURI, client, applicationName, moduleName, subscriptionName, eventName, endpoint);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void buttonDELSubscription_Click_1(object sender, EventArgs e)
        {
            // Verifies if Application Name Input is Empty
            string applicationName = textBoxApplicationNameSubscription.Text;
            if (applicationName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the application name");
                return;
            }

            string moduleName = textBoxModuleNameSubscription.Text;
            if (moduleName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the new module name");
                return;
            }

            string subscriptionName = textBoxSubscriptionNamePOST.Text;
            if (subscriptionName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the subscription name");
                return;
            }

            string requestURI = "/api/somiod/" + applicationName + "/" + moduleName + "/subscription" + "/" + subscriptionName;
            try
            {
                RequestsHandler.delete(requestURI, client);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //--------------------- END OF SUBSCRIPTION ---------------------
    }
}

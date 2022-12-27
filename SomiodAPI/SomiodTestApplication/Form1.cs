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
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
            string applicationName = textBoxApplicationName.Text;
            SomiodWebApplication.Models.Application application = new SomiodWebApplication.Models.Application
            {
                Name = applicationName,
                Res_type = "application"
            };

            var request = new RestRequest("/api/somiod", Method.Post);
            request.AddObject(application);

            RestResponse response = client.Execute(request);
            MessageBox.Show(response.StatusCode.ToString());
        }
    }
}

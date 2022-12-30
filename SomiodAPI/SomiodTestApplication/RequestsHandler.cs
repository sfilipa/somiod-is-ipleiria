using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace SomiodTestApplication
{
    internal class RequestsHandler
    {

        //--------------------- COMMON METHODS ---------------------

        static public XmlDocument getResponseAsXMLDocument(string requestURI, RestClient client, string res_type)
        {
            try
            {
                // Creates and Executes a GET request
                RestRequest request = new RestRequest(requestURI, Method.Get);
                RestResponse response = client.Execute(request);

                // Creates the XML document
                var doc = new XmlDocument();

                // Loads the Response XML Content to the XML document
                doc.LoadXml(response.Content);

                // Shows Status Code
                MessageBox.Show(response.StatusCode.ToString());

                return doc;
            }
            catch (Exception)
            {
                throw new Exception("Could not get "+res_type);
            }
        }

        
        static public void delete(string requestURI, RestClient client)
        {
            try
            {
                // Creates and Executes a Delete request
                RestRequest request = new RestRequest(requestURI, Method.Delete);
                RestResponse response = client.Execute(request);
                // Shows Status Code

                if (response.StatusCode.ToString().Equals("BadRequest"))
                {
                    MessageBox.Show("Resource does not exist");
                }
                else
                {
                    MessageBox.Show("Deleted");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //--------------------- END OF COMMON METHODS ---------------------

        //--------------------- APPLICATION ---------------------
        static public void createApplication(string requestURI, RestClient client, string applicationName)
        {
            try
            {
                // Creates the Object Application
                SomiodWebApplication.Models.Application application = new SomiodWebApplication.Models.Application
                {
                    Name = applicationName,
                    Res_type = "application"
                };


                var request = new RestRequest("/api/somiod", Method.Post);

                // Adds the message body to the response
                request.AddObject(application);

                RestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("BadRequest"))
                {
                    MessageBox.Show("Application already exists");
                }
                else {
                    MessageBox.Show("Application created");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        static public void updateApplicationName(string requestURI, RestClient client, string newApplicationName)
        {
            try
            {
                // Creates and Executes a PUT request
                RestRequest request = new RestRequest(requestURI, Method.Put);

                // Creates Application Object
                SomiodWebApplication.Models.Application application = new SomiodWebApplication.Models.Application
                {
                    Name = newApplicationName,
                    Res_type = "application"
                };

                // Adds the message body to the response
                request.AddJsonBody(application);

                RestResponse response = client.Execute(request);
                // Shows Status Code
                if (response.StatusCode.ToString().Equals("BadRequest"))
                {
                    MessageBox.Show("Application does not exist");
                }
                else
                {
                    MessageBox.Show("Application updated");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //--------------------- END OF APPLICATION ---------------------
        
        //--------------------- MODULES ---------------------
        static public void createModule(string requestURI, RestClient client, string applicationName, string moduleName)
        {
            try
            {
                // Creates the Object Application
                SomiodWebApplication.Models.Module module = new SomiodWebApplication.Models.Module
                {
                    Name = moduleName,
                    Res_type = "module"
                };


                var request = new RestRequest("/api/somiod/"+applicationName, Method.Post);

                // Adds the message body to the response
                request.AddObject(module);

                RestResponse response = client.Execute(request); 
                if (response.StatusCode.ToString().Equals("BadRequest"))
                {
                    MessageBox.Show("Module already exists");
                }
                else
                {
                    MessageBox.Show("Module created");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        static public void updateModule(string requestURI, RestClient client, string newModuleName)
        {
            try
            {
                // Creates and Executes a PUT request
                RestRequest request = new RestRequest(requestURI, Method.Put);

                SomiodWebApplication.Models.Module module = new SomiodWebApplication.Models.Module
                {
                    Name = newModuleName,
                    Res_type = "module"
                };

                // Adds the message body to the response
                request.AddJsonBody(module);

                RestResponse response = client.Execute(request);
                // Shows Status Code
                if (response.StatusCode.ToString().Equals("BadRequest"))
                {
                    MessageBox.Show("Module does not exist");
                }
                else
                {
                    MessageBox.Show("Module updated");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        //--------------------- END OF MODULES ---------------------

        //--------------------- DATA ---------------------

        static public void createData(string requestURI, RestClient client, string applicationName, string moduleName, string dataContent)
        {
            try
            {
                // Creates the Object Application
                SomiodWebApplication.Models.Data data = new SomiodWebApplication.Models.Data
                {
                    Content = dataContent,
                    Res_type = "data"
                };


                var request = new RestRequest("/api/somiod/" + applicationName + "/" + moduleName, Method.Post);

                // Adds the message body to the response
                request.AddJsonBody(data);
           

                RestResponse response = client.Execute(request);
                MessageBox.Show(response.Content);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //--------------------- END OF DATA ---------------------

        //--------------------- SUBSCRIPTION ---------------------

        static public void createSubscription(string requestURI, RestClient client, string applicationName, string moduleName, string subscriptionName, string eventName, string endpoint)
        {
            try
            {
                // Creates the Object Application
                SomiodWebApplication.Models.Subscription subscription = new SomiodWebApplication.Models.Subscription
                {
                    Name = subscriptionName,
                    Res_type = "subscription",
                    Event = eventName,
                    Endpoint = endpoint
            };


                var request = new RestRequest("/api/somiod/" + applicationName + "/" + moduleName, Method.Post);

                // Adds the message body to the response
                request.AddJsonBody(subscription);


                RestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("BadRequest"))
                {
                    MessageBox.Show("Subscription already exists");
                }
                else
                {
                    MessageBox.Show("Subscription created");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //--------------------- END OF SUBSCRIPTION ---------------------

    }
}

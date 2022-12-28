using SomiodWebApplication.Models;
using System.Collections.Generic;
using System.Web.Http;
using SomiodWebApplication.Handlers;
using System.Net.Http;
using System.Net;
using System.Net.Http.Formatting;
using Application = SomiodWebApplication.Models.Application;
using Newtonsoft.Json.Linq;

namespace SomiodWebApplication.Controllers
{
    public class SomiodController : ApiController
    {
        //---Application
  
        //GET: api/somiod
        [Route("api/somiod")]
        [HttpGet]
        public HttpResponseMessage GetAllApplications()
        {
            List<Application> objs;
            var formatter = new XmlMediaTypeFormatter();

            try
            {
                objs = ApplicationHandler.FindObjectsInDatabase();
            }
            catch (System.Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Application(), formatter);
            }

            return Request.CreateResponse(HttpStatusCode.OK, objs, formatter);
        }

        // GET: api/Somiod/lighting
        [Route("api/somiod/{application_name}")]
        [HttpGet]
        public HttpResponseMessage GetSpecificApplication(string application_name)
        {
            Application obj;
            var formatter = new XmlMediaTypeFormatter();

            try
            {
                obj = ApplicationHandler.FindObjectInDatabase(application_name);
            }
            catch (System.Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Application(), formatter);
            }

            return Request.CreateResponse(HttpStatusCode.OK, obj, formatter);
        }

        // POST: api/Somiod
        [Route("api/somiod")]
        [HttpPost]
        public HttpResponseMessage PostApplication([FromBody] Application newApplication)
        {
            if (newApplication.Res_type != "application")
            {
                return Request.CreateResponse<Application>(HttpStatusCode.BadRequest, null);
            }

            Application obj;

            try
            {
                obj = ApplicationHandler.SaveToDatabase(newApplication);
            }
            catch (System.Exception)
            {
                return Request.CreateResponse<Application>(HttpStatusCode.BadRequest, null);
            }

            return Request.CreateResponse<Application>(HttpStatusCode.Created, obj);
        }

        // DELETE: api/Somiod/lighting
        [Route("api/somiod/{application_name}")]
        [HttpDelete]
        public HttpResponseMessage DeleteApplication(string application_name)
        {
            try
            {
                ApplicationHandler.DeleteFromDatabase(application_name);
            }
            catch (System.Exception)
            {
                return Request.CreateResponse<Application>(HttpStatusCode.BadRequest, null);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // PUT: api/Somiod/lighting
        [Route("api/somiod/{application_name}")]
        [HttpPut]
        public HttpResponseMessage PutApplication(string application_name, [FromBody] Application newApplication)
        {
            if (newApplication.Res_type != "application")
            {
                return Request.CreateResponse<Application>(HttpStatusCode.BadRequest, null);
            }

            Application obj;

            try
            {
                obj = ApplicationHandler.UpdateToDatabase(application_name, newApplication);
            }
            catch (System.Exception)
            {
                return Request.CreateResponse<Application>(HttpStatusCode.BadRequest, null);
            }

            return Request.CreateResponse<Application>(HttpStatusCode.OK, obj);
        }
        //--- End of Application

        //--- Modules

        // GET: api/Somiod/lighting/modules
        [Route("api/somiod/{application_name}/modules")]
        [HttpGet]
        public HttpResponseMessage GetAllModulesFromApplication(string application_name)
        {
            IEnumerable<Module> modules;
            var formatter = new XmlMediaTypeFormatter();
            try
            {
                modules = ModuleHandler.FindAllInDatabase(application_name);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Module(), formatter);
            }

            return Request.CreateResponse(HttpStatusCode.OK, modules, formatter);
        }

        // GET: api/Somiod/lighting/light_bulb
        [Route("api/somiod/{application_name}/{module_name}")]
        [HttpGet]
        public HttpResponseMessage GetSpecificModuleFromApplication(string application_name, string module_name)
        {
            Module module;
            var formatter = new XmlMediaTypeFormatter();
            try
            {
                module = ModuleHandler.FindObjectInDatabase(application_name, module_name);
                if (module == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There is no module named " + module_name + " in the application " + application_name, formatter);
                }
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Module(), formatter);
            }

            return Request.CreateResponse(HttpStatusCode.OK, module, formatter);
        }

        // POST: api/Somiod/lighting
        [Route("api/somiod/{application_name}")]
        [HttpPost]
        public HttpResponseMessage PostModule(string application_name, [FromBody] Module newModule)
        {
            if (newModule.Res_type != "module")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Object is not of 'module' res_type");
            }

            Module obj;

            try
            {
                obj = ModuleHandler.SaveToDatabaseModule(newModule, application_name);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.Created, obj);
        }

        //DELETE: api/somiod/lighting/light_bulb
        [Route("api/somiod/{application_name}/{module_name}")]
        [HttpDelete]
        public HttpResponseMessage DeleteModule(string application_name, string module_name)
        {
            try
            {
                ModuleHandler.DeleteFromDatabase(application_name, module_name);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        //PUT: api/somiod/lighting/light_bulb
        [Route("api/somiod/{application_name}/{module_name}")]
        [HttpPut]
        public HttpResponseMessage PutModule(string application_name, string module_name, [FromBody] Module updatedModule)
        {
            if (updatedModule.Res_type != "module")
            {
                return Request.CreateResponse<Application>(HttpStatusCode.BadRequest, null);
            }
            Module obj;
            try
            {
                obj = ModuleHandler.UpdateToDatabase(application_name, module_name, updatedModule);

            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, obj);

        }
        //--- End of Module


        //--- Data And Subscriptions

        // POST: api/Somiod/lighting/light_bulb
        [Route("api/somiod/{application_name}/{module_name}")]
        [HttpPost]
        public HttpResponseMessage PostDataOrSubscription(string application_name, string module_name, [FromBody] JObject newObj)
        {
            //--Data
            if (newObj["Res_type"].ToString().Equals("data"))
            {
                Data data = newObj.ToObject<Data>();

                int rowsInserted = 0;

                try
                {
                    rowsInserted = DataHandler.SaveToDatabaseData(data, application_name, module_name);
                }
                catch (System.Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.Created, "Inserted " + rowsInserted + " row");
            }
            //--Subscription
            else if (newObj["res_type"].ToString().Equals("subscription"))
            {
                Subscription subscription = newObj.ToObject<Subscription>();

                int rowsInserted;

                try
                {
                    rowsInserted = SubscriptionHandler.SaveToDatabase(application_name, module_name, subscription);
                }
                catch (System.Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.Created, "Inserted "+rowsInserted+" row");
            }
            //--Neither of them
            else {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Object is not of 'data' or 'subscription' res_type, is "+ newObj["res_type"]);
            }
        }

        //DELETE: api/somiod/lighting/light_bulb
        [Route("api/somiod/{application_name}/{module_name}/data/{data_id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteData(string application_name, string module_name, int data_id)
        {
            try
            {
                DataHandler.DeleteFromDatabase(application_name, module_name, data_id);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        //DELETE: api/somiod/lighting/light_bulb
        [Route("api/somiod/{application_name}/{module_name}/subscription/{subscription_name}")]
        [HttpDelete]
        public HttpResponseMessage DeleteSubscription(string application_name, string module_name, string subscription_name)
        {
            try
            {
                SubscriptionHandler.DeleteFromDatabase(application_name, module_name, subscription_name);
            }
            catch (System.Exception)
            {
                return Request.CreateResponse<Subscription>(HttpStatusCode.BadRequest, null);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        //--- End of Data and Subscription

    }
}

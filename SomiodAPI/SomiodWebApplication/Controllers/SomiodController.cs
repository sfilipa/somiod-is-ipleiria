using SomiodWebApplication.Models;
using System.Collections.Generic;
using System.Web.Http;
using SomiodWebApplication.Handlers;
using System.Net.Http;
using System.Net;
using System.Xml.Linq;
using System.Web.UI.WebControls;

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

            try
            {
                objs = ApplicationHandler.FindObjectsInDatabase();
            }
            catch (System.Exception)
            {
                return Request.CreateResponse<IEnumerable<Application>>(HttpStatusCode.BadRequest, null);
            }

            return Request.CreateResponse<IEnumerable<Application>>(HttpStatusCode.OK, objs);
        }

        // GET: api/Somiod/lighting
        [Route("api/somiod/{application_name}")]
        [HttpGet]
        public HttpResponseMessage GetSpecificApplication(string application_name)
        {
            Application obj;
            try
            {
                obj = ApplicationHandler.FindObjectInDatabase(application_name);
            }
            catch (System.Exception)
            {
                return Request.CreateResponse<Application>(HttpStatusCode.BadRequest, null);
            }

            return Request.CreateResponse<Application>(HttpStatusCode.OK, obj);
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
            try
            {
                modules = ModuleHandler.FindAllInDatabase(application_name);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, modules);
        }

        // GET: api/Somiod/lighting/light_bulb
        [Route("api/somiod/{application_name}/{module_name}")]
        [HttpGet]
        public HttpResponseMessage GetSpecificModuleFromApplication(string application_name, string module_name)
        {
            Module module;
            try
            {
                module = ModuleHandler.FindObjectInDatabase(application_name, module_name);
                if (module == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There is no module named " + module_name + " in the application " + application_name);
                }
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, module);
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

            return Request.CreateResponse(HttpStatusCode.OK, obj);
        }

        //DELETE: api/somiod/lighting/light_bulb
        [Route("api/somiod/{application_name}/{module_name}")]
        [HttpDelete]
        public HttpResponseMessage DeleteModule(string application_name, string module_name)
        {
            try
            {
                ModuleHandler.DeleteFromDatabase(application_name, module_name);
                //depois se tiver FK é preciso tratar dessas exceções
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.Accepted, "Deleted "+module_name+ " with success!");
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


        //--- Data

        // POST: api/Somiod/lighting/light_bulb
        [Route("api/somiod/{application_name}/{module_name}")]
        [HttpPost]
        public HttpResponseMessage PostData(string application_name, string module_name, [FromBody] Data newData)
        {
            if (newData.Res_type != "data")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Object is not of 'data' res_type");
            }

            int rows = 0;

            try
            {
                rows = DataHandler.SaveToDatabaseData(newData, application_name, module_name);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Inserted "+rows + " row");
        }

        
        //--- End of Data

        //--- Subscription

        // GET: api/Somiod/lighting/modules/

        //TODO
        //--- End of Subscription

    }
}

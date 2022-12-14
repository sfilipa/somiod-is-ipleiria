using SomiodWebApplication.Models;
using System.Collections.Generic;
using System.Web.Http;
using SomiodWebApplication.Handlers;
using System.Net.Http;
using System.Net;
using System.Xml.Linq;

namespace SomiodWebApplication.Controllers
{
    public class SomiodController : ApiController
    {
        [Route("api/somiod/applications")]
        [HttpGet]
        public HttpResponseMessage Get()
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
        [Route("api/somiod/{name}")]
        [HttpGet]
        public HttpResponseMessage Get(string name)
        {
            Application obj;
            try
            {
                obj = ApplicationHandler.FindObjectInDatabase(name);
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
        public HttpResponseMessage Post([FromBody] Application newApplication)
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

        // POST: api/Somiod/lighing
        [Route("api/somiod/{application_name}")]
        [HttpPost]
        public HttpResponseMessage Post(string application_name, [FromBody] Module newModule)
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

        // GET: api/Somiod/lighting/module/light_bulb
        [Route("api/somiod/{application_name}/modules/{module_name}")] //deixo assim pq penso que deveriamos tirar a constraint UNIQUE do name dos modules
        [HttpGet]
        public HttpResponseMessage GetSpecificModule(string application_name, string module_name)
        {
            Module module;
            try
            {
                module = ModuleHandler.FindObjectInDatabase(application_name, module_name);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, module);
        }

        //PUT: api/somiod/lighting/modules/light_bulb
        [Route("api/somiod/{application_name}/modules/{module_name}")]
        [HttpPut]
        public HttpResponseMessage PutModule(string application_name, string module_name, [FromBody] Module updatedModule)
        {
            if(updatedModule.Res_type != "module")
            {
                return Request.CreateResponse<Application>(HttpStatusCode.BadRequest, null);
            }
            Module obj;
            try
            {
                obj = ModuleHandler.UpdateToDatabase(application_name, module_name, updatedModule);

            }catch(System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, obj);

        }

        //DELETE: api/somiod/lighting/modules/light_bulb
        [Route("api/somiod/{application_name}/modules/{module_name}")]
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

        // DELETE: api/Somiod/lighting
        [Route("api/somiod/{name}")]
        [HttpPut]
        public HttpResponseMessage Put(string name, [FromBody] Application newApplication)
        {
            if (newApplication.Res_type != "application")
            {
                return Request.CreateResponse<Application>(HttpStatusCode.BadRequest, null);
            }

            Application obj;

            try
            {
                obj = ApplicationHandler.UpdateToDatabase(name,newApplication);
            }
            catch (System.Exception)
            {
                return Request.CreateResponse<Application>(HttpStatusCode.BadRequest, null);
            }

            return Request.CreateResponse<Application>(HttpStatusCode.OK, obj);
        }

        // DELETE: api/Somiod/lighting
        [Route("api/somiod/{name}")]
        [HttpDelete]
        public HttpResponseMessage Delete(string name)
        {
            try
            {
                ApplicationHandler.DeleteFromDatabase(name);
            }
            catch (System.Exception)
            {
                return Request.CreateResponse<Application>(HttpStatusCode.BadRequest, null);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}

using SomiodWebApplication.Models;
using System.Collections.Generic;
using System.Web.Http;
using SomiodWebApplication.Handlers;
using System.Net.Http;
using System.Net;

namespace SomiodWebApplication.Controllers
{
    public class SomiodController : ApiController
    {
        [Route("api/somiod/applications")]
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

        // PUT: api/Somiod/lighting
        [Route("api/somiod/{name}")]
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

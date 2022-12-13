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
        public IHttpActionResult Post([FromBody] Application newApplication)
        {
            if (newApplication.Res_type != "application")
            {
                return BadRequest();
            }

            Application obj;

            try
            {
                obj = ApplicationHandler.SaveToDatabaseApplication(newApplication);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

            return Created("api/somiod", obj);
        }

        // PUT: api/Somiod/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Somiod/5
        public void Delete(int id)
        {
        }
    }
}

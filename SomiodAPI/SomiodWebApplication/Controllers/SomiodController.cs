using SomiodWebApplication.Models;
using System.Collections.Generic;
using System.Web.Http;
using SomiodWebApplication.Handlers;

namespace SomiodWebApplication.Controllers
{
    public class SomiodController : ApiController
    {
        // GET: api/Somiod
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Somiod/5
        public string Get(int id)
        {
            return "value";
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

            return Created("api/products", obj);
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

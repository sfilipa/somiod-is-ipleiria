using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SomiodWebApplication.Controllers
{
    public class SomiodController : ApiController
    {
        string connectionString = Properties.Settings.Default.connStr;

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
        public void Post([FromBody]string value)
        {
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

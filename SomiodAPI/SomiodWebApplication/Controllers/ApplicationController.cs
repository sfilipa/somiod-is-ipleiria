using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SomiodWebApplication.Controllers
{
    public class ApplicationController : ApiController
    {
        // Connection to DB
        string connectionString = SomiodWebApplication.Properties.Settings.Default.connStr;

        // GET: api/Application
        [Route("api/somiod")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Application/5
        [Route("api/somiod/{id:int}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Application
        [Route("api/somiod")]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Application/5
        [Route("api/somiod/{id:int}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Application/5
        [Route("api/somiod/{id:int}")]
        public void Delete(int id)
        {
        }
    }
}

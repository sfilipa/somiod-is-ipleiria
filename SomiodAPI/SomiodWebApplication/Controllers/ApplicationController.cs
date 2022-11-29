using SomiodWebApplication.Models;
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
        public void Post([FromBody]Application newApplication)
        {
            string query = "INSERT INTO Application VALUES (@name)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", newApplication.Name);

                int numRows = command.ExecuteNonQuery();

                connection.Close();

                if (numRows != 1)
                {
                    return InternalServerError();
                }
                return Ok;
            }
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

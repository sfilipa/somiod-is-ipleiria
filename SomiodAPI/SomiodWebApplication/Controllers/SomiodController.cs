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
        [Route("api/somiod")]
        public IHttpActionResult Post([FromBody] Application newApplication)
        {
            string query = "INSERT INTO Applications VALUES (@name)";

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
                return Ok();
            }
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

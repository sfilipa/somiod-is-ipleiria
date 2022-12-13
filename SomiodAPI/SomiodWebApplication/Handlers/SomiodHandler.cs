using SomiodWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SomiodWebApplication.Handlers
{
    public static class SomiodHandler
    {
        static string connectionString = Properties.Settings.Default.connStr;

        public static Application FindObjectInDatabase(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Set up the command to search for the object by name
                string searchCommand = "SELECT * FROM Applications WHERE Name = @Name";
                SqlCommand command = new SqlCommand(searchCommand, connection);
                command.Parameters.AddWithValue("@Name", name);

                try
                {
                    // Open the database connection and execute the search command
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if the object was found
                    if (reader.Read())
                    {
                        // Create a new object using the data from the database
                        Application obj = new Application();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.Name = reader["Name"].ToString();
                        obj.Creation_dt = Convert.ToDateTime(reader["Creation_dt"]);
                        return obj;
                    }
                    else
                    {
                        // Return null if the object was not found
                        return null;
                    }
                }
                catch (SqlException ex)
                {
                    // Handle any errors that may have occurred
                    Console.WriteLine("Error finding object in database: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
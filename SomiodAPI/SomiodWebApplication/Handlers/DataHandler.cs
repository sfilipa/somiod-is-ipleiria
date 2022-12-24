using SomiodWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SomiodWebApplication.Handlers
{
    public class DataHandler
    {
        static string connectionString = Properties.Settings.Default.connStr;

        public static int SaveToDatabaseData(Data data, string application_name, string module_name)
        {
            DateTime todaysDateAndTime = DateTime.Now;
            int rowsInserted = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertCmd = "INSERT INTO Data VALUES (@content, @date, @parent)";
                SqlCommand cmd = new SqlCommand(insertCmd, connection);
                cmd.Parameters.AddWithValue("@content", data.Content);
                cmd.Parameters.AddWithValue("@date", todaysDateAndTime);

                Module moduleObj = ModuleHandler.FindObjectInDatabase(application_name, module_name);
                if(moduleObj == null)
                {
                    throw new Exception("Error finding module named " + module_name + " in application " + application_name);
                }

                cmd.Parameters.AddWithValue("@parent", moduleObj.Id);
                
                //Makes the connection to the database
                try
                {
                    // Open the database connection and execute the insert command
                    connection.Open();
                    rowsInserted = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Handle any errors that may have occurred
                    Console.WriteLine("Error inserting object into database: " + ex.Message);
                    throw new Exception(ex.Message);

                }
            }

            return rowsInserted;
        }
    }
}
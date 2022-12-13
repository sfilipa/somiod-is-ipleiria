using SomiodWebApplication.Models;
using System;
using System.Data.SqlClient;

namespace SomiodWebApplication.Handlers
{
    public class ApplicationHandler
    {
        static string connectionString = Properties.Settings.Default.connStr;

        public static Application SaveToDatabaseApplication(Application myApplication)
        {
            // Attributes to send to the DB
            string newApplicationName = myApplication.Name;
            DateTime todaysDateAndTime = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Set up the command to insert the object into the database
                string insertCommand = "INSERT INTO Applications VALUES (@name, @date)";
                SqlCommand command = new SqlCommand(insertCommand, connection);

                // Remove Spaces from Name and Add "_"
                newApplicationName = newApplicationName.Replace(" ", "_");

                // Add the parameters for the object's name and value
                command.Parameters.AddWithValue("@name", newApplicationName);
                command.Parameters.AddWithValue("@date", todaysDateAndTime);

                // Makes the connection to the Database
                try
                {
                    // Open the database connection and execute the insert command
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Handle any errors that may have occurred
                    Console.WriteLine("Error inserting object into database: " + ex.Message);
                }
            }

            Application obj = SomiodHandler.FindObjectInDatabase(newApplicationName);
            obj.Res_type = "application";
            return obj;
        }

 
    }
}
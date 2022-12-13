using SomiodWebApplication.Models;
using System;
using System.Data.SqlClient;

namespace SomiodWebApplication
{
    public class HandlerSomiod
    {
        static string connectionString = Properties.Settings.Default.connStr;

        public static Application SaveToDatabaseApplication(Application myApplcation)
        {
            // Attributes to send to the DB
            string newApplicationName = myApplcation.Name;
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
            return FindObjectInDatabase(newApplicationName);
        }

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
using SomiodWebApplication.Models;
using System;
using System.Data.SqlClient;

namespace SomiodWebApplication.Handlers
{
    public class ModuleHandler
    {
        static string connectionString = Properties.Settings.Default.connStr;
        public static Module FindObjectInDatabase(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Set up the command to search for the object by name
                string searchCommand = "SELECT * FROM Modules WHERE Name = @Name";
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
                        Module obj = new Module();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.Name = reader["Name"].ToString();
                        obj.Creation_dt = Convert.ToDateTime(reader["Creation_dt"]);
                        obj.Parent = Convert.ToInt32(reader["Parent"]);
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

        public static Module SaveToDatabaseModule(Module myModule, string application_name)
        {
            // Attributes to send to the DB
            string newModuleName = myModule.Name;
            DateTime todaysDateAndTime = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Set up the command to insert the object into the database
                string insertCommand = "INSERT INTO Modules VALUES (@name, @date, @parent)";
                SqlCommand command = new SqlCommand(insertCommand, connection);

                // Remove Spaces from Name and Add "_"
                newModuleName = newModuleName.Replace(" ", "_");

                // Add the parameters for the object's name and value
                command.Parameters.AddWithValue("@name", newModuleName);
                command.Parameters.AddWithValue("@date", todaysDateAndTime);

                Application applicationObj = ApplicationHandler.FindObjectInDatabase(application_name);
                if(applicationObj == null) {
                    Console.WriteLine("ERROR: FINDING APPLICATION WITH NAME "+ application_name);
                }
              
                command.Parameters.AddWithValue("@parent", applicationObj.Id);

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

            Module obj = FindObjectInDatabase(newModuleName);
            obj.Res_type = "module";
            return obj;
        }

 
    }
}
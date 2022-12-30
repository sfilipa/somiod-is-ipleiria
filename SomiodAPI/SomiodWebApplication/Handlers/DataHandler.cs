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
            int idInserted = -1;
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
                    int rowsInserted = cmd.ExecuteNonQuery();
                    if(rowsInserted != 1)
                    {
                        throw new Exception("Error inserting object into database");
                    }

                    Data newData = FindLastObjectInsertedInDatabaseByModuleId(moduleObj.Id);
                    if(newData == null)
                    {
                        throw new Exception("Can't find newly created data record in the database");
                    }
                    idInserted = newData.Id;

                }
                catch (SqlException ex)
                {
                    // Handle any errors that may have occurred
                    Console.WriteLine("Error inserting object into database: " + ex.Message);
                    throw new Exception(ex.Message);

                }
            }
            return idInserted;
        }

        public static Data FindLastObjectInsertedInDatabaseByModuleId(int module_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string searchNewlyInsertedData = "SELECT * FROM Data WHERE Parent = @parent ORDER BY Id DESC";
                SqlCommand cmdSelect = new SqlCommand(searchNewlyInsertedData, connection);
                cmdSelect.Parameters.AddWithValue("@parent", module_id);

                try
                {
                    // Open the database connection and execute the search command
                    connection.Open();
                    SqlDataReader reader = cmdSelect.ExecuteReader();

                    // Check if the object was found
                    if (reader.Read())
                    {
                        // Create a new object using the data from the database
                        Data obj = new Data();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.Content = reader["Content"].ToString();
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
                    throw ex;
                }
            }
        }
        public static void DeleteFromDatabase(string application_name, string module_name, int data_id)
        {
            // Find the data
            Data obj = FindObjectInDatabase(application_name, module_name, data_id);
            if (obj == null)
            {
                throw new Exception("Data Not Found");
            }


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Set up the command to delete object from the database
                string insertCommand = "DELETE FROM Data WHERE Id = @Id";
                SqlCommand command = new SqlCommand(insertCommand, connection);

                command.Parameters.AddWithValue("@Id", data_id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static Data FindObjectInDatabase(string application_name, string module_name, int data_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Find Application
                Application application = ApplicationHandler.FindObjectInDatabase(application_name);
                if (application == null)
                {
                    return null;
                }

                // Find Module 
                Module module = ModuleHandler.FindObjectInDatabase(application.Name, module_name);
                if (module == null)
                {
                    return null;
                }

                // Set up the command to search for the object by name
                string searchCommand = "SELECT * FROM Data WHERE Id = @Id and Parent = @Parent";
                SqlCommand command = new SqlCommand(searchCommand, connection);
                command.Parameters.AddWithValue("@Id", data_id);
                command.Parameters.AddWithValue("@Parent", module.Id);

                try
                {
                    // Open the database connection and execute the search command
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if the object was found
                    if (reader.Read())
                    {
                        // Create a new object using the data from the database
                        Data obj = new Data();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.Content = reader["Content"].ToString();
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
                    throw ex;
                }
            }
        }
    }
}
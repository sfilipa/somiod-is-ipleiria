using SomiodWebApplication.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SomiodWebApplication.Handlers
{
    public class ModuleHandler
    {
        static string connectionString = Properties.Settings.Default.connStr;
        public static Module FindObjectInDatabase(string application_name, string module_name)
        {
            Application applicationObj = ApplicationHandler.FindObjectInDatabase(application_name);
            if (applicationObj == null)
            {
                throw new Exception("ERROR: FINDING APPLICATION WITH NAME " + application_name);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                // Set up the command to search for the object by name
                string searchCommand = "SELECT * FROM Modules WHERE Name = @Name AND Parent = @Parent";
                SqlCommand command = new SqlCommand(searchCommand, connection);
                command.Parameters.AddWithValue("@Name", module_name);
                command.Parameters.AddWithValue("@Parent", applicationObj.Id);

                try
                {
                    // Open the database connection and execute the search command
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if the object was found
                    if (reader.Read())
                    {
                        Module obj = new Module();
                        obj.Id = Convert.ToInt32(reader["Id"]);
                        obj.Name = reader["Name"].ToString();
                        obj.Res_type = "module";
                        obj.Creation_dt = Convert.ToDateTime(reader["Creation_dt"]);
                        obj.Parent = Convert.ToInt32(reader["Parent"]);

                        List<Data> dataArray = new List<Data>();
                        reader.Close();

                        // Set up the command to search for the object by name
                        string searchDataCommand = "SELECT * FROM Data WHERE Parent = @ParentData";
                        SqlCommand commandData = new SqlCommand(searchDataCommand, connection);
                        commandData.Parameters.AddWithValue("@ParentData", obj.Id);

                        SqlDataReader readerData = commandData.ExecuteReader();

                        // Check if the object was found
                        while (readerData.Read())
                        {

                            Data objData = new Data();

                            objData.Id = Convert.ToInt32(readerData["Id"]);
                            objData.Content = readerData["Content"].ToString();
                            objData.Res_type = "data";
                            objData.Creation_dt = Convert.ToDateTime(readerData["Creation_dt"]);
                            objData.Parent = Convert.ToInt32(readerData["Parent"]);

                            dataArray.Add(objData);
                        }
                        readerData.Close();
                        obj.Data = dataArray;
                        connection.Close();
                        return obj;
                    }
                    else
                    {
                        connection.Close();
                        return null;
                        //throw new Exception("Error finding object "+  module_name);
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        public static IEnumerable<Module> FindAllInDatabase(string application_name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Module> modules = new List<Module>();
                Application applicationObj = ApplicationHandler.FindObjectInDatabase(application_name);
                if (applicationObj == null)
                {
                    Console.WriteLine("ERROR: FINDING APPLICATION WITH NAME " + application_name);
                    throw new Exception("ERROR: FINDING APPLICATION WITH NAME " + application_name);
                }

                string searchCommand = "SELECT * FROM Modules WHERE Parent = @Parent";
                SqlCommand command = new SqlCommand(searchCommand, connection);
                command.Parameters.AddWithValue("@Parent", applicationObj.Id);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Module obj = new Module
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Res_type = "module",
                            Creation_dt = Convert.ToDateTime(reader["Creation_dt"]),
                            Parent = Convert.ToInt32(reader["Parent"])
                        };
                        modules.Add(obj);
                    }
                    reader.Close();

                    foreach (Module module in modules)
                    {
                        List<Data> dataArray = new List<Data>();
                        // Set up the command to search for the object by name
                        string searchDataCommand = "SELECT * FROM Data WHERE Parent = @ParentData";
                        SqlCommand commandData = new SqlCommand(searchDataCommand, connection);
                        commandData.Parameters.AddWithValue("@ParentData", module.Id);

                        SqlDataReader readerData = commandData.ExecuteReader();

                        // Check if the object was found
                        while (readerData.Read())
                        {

                            Data objData = new Data();

                            objData.Id = Convert.ToInt32(readerData["Id"]);
                            objData.Content = readerData["Content"].ToString();
                            objData.Res_type = "data";
                            objData.Creation_dt = Convert.ToDateTime(readerData["Creation_dt"]);
                            objData.Parent = Convert.ToInt32(readerData["Parent"]);

                            dataArray.Add(objData);
                        }
                        module.Data = dataArray;

                        readerData.Close();
                    }

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }

                return modules;
            }
        }

        public static IEnumerable<Module> FindAllByParentIDInDatabase(int application_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Module> modules = new List<Module>();


                string searchCommand = "SELECT * FROM Modules WHERE Parent = @Parent";
                SqlCommand command = new SqlCommand(searchCommand, connection);
                command.Parameters.AddWithValue("@Parent", application_id);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Module obj = new Module
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Res_type = "module",
                            Creation_dt = Convert.ToDateTime(reader["Creation_dt"]),
                            Parent = Convert.ToInt32(reader["Parent"])
                        };
                        modules.Add(obj);
                    }
                    reader.Close();

                    foreach (Module module in modules)
                    {
                        List<Data> dataArray = new List<Data>();
                        // Set up the command to search for the object by name
                        string searchDataCommand = "SELECT * FROM Data WHERE Parent = @ParentData";
                        SqlCommand commandData = new SqlCommand(searchDataCommand, connection);
                        commandData.Parameters.AddWithValue("@ParentData", module.Id);

                        SqlDataReader readerData = commandData.ExecuteReader();

                        // Check if the object was found
                        while (readerData.Read())
                        {

                            Data objData = new Data();

                            objData.Id = Convert.ToInt32(readerData["Id"]);
                            objData.Content = readerData["Content"].ToString();
                            objData.Res_type = "data";
                            objData.Creation_dt = Convert.ToDateTime(readerData["Creation_dt"]);
                            objData.Parent = Convert.ToInt32(readerData["Parent"]);

                            dataArray.Add(objData);
                        }
                        module.Data = dataArray;

                        readerData.Close();
                    }

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }

                return modules;
            }
        }

        public static Module SaveToDatabaseModule(Module myModule, string application_name)
        {
            // Attributes to send to the DB
            string newModuleName = myModule.Name;
            DateTime todaysDateAndTime = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                if (FindObjectInDatabase(application_name, newModuleName) != null)
                {
                    throw new Exception("There are already exists a module named " + newModuleName + " in the application " + application_name);
                }


                // Set up the command to insert the object into the database
                string insertCommand = "INSERT INTO Modules VALUES (@name, @date, @parent)";
                SqlCommand command = new SqlCommand(insertCommand, connection);

                // Remove Spaces from Name and Add "_"
                newModuleName = newModuleName.Replace(" ", "_");

                command.Parameters.AddWithValue("@name", newModuleName);
                command.Parameters.AddWithValue("@date", todaysDateAndTime);

                Application applicationObj = ApplicationHandler.FindObjectInDatabase(application_name);
                if (applicationObj == null)
                {
                    throw new Exception("Error finding application with name " + application_name);
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
                    throw new Exception(ex.Message);

                }
            }

            Module obj = FindObjectInDatabase(application_name, newModuleName);
            obj.Res_type = "module";
            return obj;
        }

        public static Module UpdateToDatabase(string application_name, string module_name, Module updatedModule)
        {
            Module obj = FindObjectInDatabase(application_name, module_name);
            if (obj == null)
            {
                throw new Exception("Null Object");
            }

            Application applicationObj = ApplicationHandler.FindObjectInDatabase(application_name);
            if (applicationObj == null)
            {
                throw new Exception("ERROR: FINDING APPLICATION WITH NAME " + application_name);
            }

            string newModuleName = updatedModule.Name;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Set up the command to insert the object into the database
                string insertCommand = "UPDATE Modules SET Name = @newName WHERE Name = @currentName AND Parent = @Parent";
                SqlCommand command = new SqlCommand(insertCommand, connection);

                // Replace any spaces to "_"
                newModuleName = newModuleName.Replace(" ", "_");

                // Add the parameters for the object's name and value
                command.Parameters.AddWithValue("@newName", newModuleName);
                command.Parameters.AddWithValue("@currentName", module_name);
                command.Parameters.AddWithValue("@Parent", applicationObj.Id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

            Module updatedObj = FindObjectInDatabase(application_name, newModuleName);
            updatedObj.Res_type = "module";
            return updatedObj;
        }

        public static void DeleteFromDatabase(string application_name, string module_name)
        {
            Module obj = FindObjectInDatabase(application_name, module_name);

            if (obj == null)
            {
                throw new Exception("Module with name " + module_name + " was not found!");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string deleteData = "DELETE FROM Data WHERE Parent = @DataParentId";
                SqlCommand deleteCommandData = new SqlCommand(deleteData, connection);
                deleteCommandData.Parameters.AddWithValue("@DataParentId", obj.Id);

                string deleteSubscriptions = "DELETE FROM Subscriptions WHERE Parent = @SubsParentId";
                SqlCommand deleteCommandSubscriptions = new SqlCommand(deleteSubscriptions, connection);
                deleteCommandSubscriptions.Parameters.AddWithValue("@SubsParentId", obj.Id);

                // Set up the command to delete object from the database
                string insertCommand = "DELETE FROM Modules WHERE Name = @name AND Parent = @Parent";
                SqlCommand command = new SqlCommand(insertCommand, connection);

                command.Parameters.AddWithValue("@name", obj.Name);
                command.Parameters.AddWithValue("@Parent", obj.Parent);

                try
                {
                    connection.Open();
                    deleteCommandData.ExecuteNonQuery();
                    deleteCommandSubscriptions.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
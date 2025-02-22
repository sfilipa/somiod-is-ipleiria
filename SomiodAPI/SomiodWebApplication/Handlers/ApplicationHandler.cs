﻿using SomiodWebApplication.Models;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http.Results;
using Application = SomiodWebApplication.Models.Application;

namespace SomiodWebApplication.Handlers
{
    public class ApplicationHandler
    {
        static string connectionString = Properties.Settings.Default.connStr;

        public static List<Application> FindObjectsInDatabase()
        {
            List<Application> objs = new List<Application>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Set up the command to search for all the objects
                string query = "SELECT * FROM Applications";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Open the database connection and execute the search command
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Reads line from Database
                        while (reader.Read())
                        {
                            // Create a new object using the data from the reader
                            Application obj = new Application();
                            obj.Id = Convert.ToInt32(reader["Id"]);
                            obj.Name = reader["Name"].ToString();
                            obj.Creation_dt = Convert.ToDateTime(reader["Creation_dt"]);
                            obj.Res_type = "application";
                            objs.Add(obj);
                        }
                    }

                    if (objs.Count == 0)
                    {
                        return null;
                    }
                    return objs;
                }
            }
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
                        obj.Res_type = "application";
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

        public static Application SaveToDatabase(Application myApplication)
        {
            // Attributes to send to the DB
            string newApplicationName = myApplication.Name;
            DateTime todaysDateAndTime = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Remove Spaces from Name and Add "_"
                newApplicationName = newApplicationName.Replace(" ", "-");

                if (FindObjectInDatabase(newApplicationName) != null)
                {
                    throw new Exception("There are already exists an application named " + newApplicationName + " in the database.");
                }
                
                // Set up the command to insert the object into the database
                string insertCommand = "INSERT INTO Applications VALUES (@name, @date)";
                SqlCommand command = new SqlCommand(insertCommand, connection);

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
                    throw ex;
                }
            }

            Application obj = FindObjectInDatabase(newApplicationName);
            obj.Res_type = "application";
            return obj;
        }

        public static void DeleteFromDatabase(string name)
        {
            Application obj = FindObjectInDatabase(name);

            // If object doesnt exist
            if (obj == null)
            {
                throw new Exception("Null Object");
            }

            List<Module> modules = (List<Module>)ModuleHandler.FindAllByParentIDInDatabase(obj.Id);
            foreach (Module module in modules)
            {
                ModuleHandler.DeleteFromDatabase(name, module.Name);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Set up the command to delete object from the database
                string insertCommand = "DELETE FROM Applications WHERE Name = @name";
                SqlCommand command = new SqlCommand(insertCommand, connection);

                // Add the parameters for the object's name 
                command.Parameters.AddWithValue("@name", obj.Name);

                // Makes the connection to the Database
                try
                {
                    // Open the database connection and execute the delete command
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        public static Application UpdateToDatabase(string currentName, Application newApplication)
        {
            Application obj = FindObjectInDatabase(currentName);
            if (obj == null)
            {
                throw new Exception("Null Object");
            }

            // Attributes to send to the DB
            string newApplicationName = newApplication.Name;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Set up the command to insert the object into the database
                string insertCommand = "UPDATE Applications SET Name = @newName WHERE Name = @currentName;";
                SqlCommand command = new SqlCommand(insertCommand, connection);

                // Remove Spaces from Name and Add "_"
                newApplicationName = newApplicationName.Replace(" ", "-");

                // Add the parameters for the object's name and value
                command.Parameters.AddWithValue("@newName", newApplicationName);
                command.Parameters.AddWithValue("@currentName", currentName);

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
                    throw ex;
                }
            }

            Application updatedObj = FindObjectInDatabase(newApplicationName);
            updatedObj.Res_type = "application";
            return updatedObj;
        }
    }
}
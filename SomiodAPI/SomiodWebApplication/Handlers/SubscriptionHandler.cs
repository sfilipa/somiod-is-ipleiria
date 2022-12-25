using SomiodWebApplication.Handlers;
using SomiodWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class SubscriptionHandler
{
    static string connectionString = SomiodWebApplication.Properties.Settings.Default.connStr;

    public static Subscription FindObjectInDatabase(string application_name, string module_name, string subscription_name)
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
            string searchCommand = "SELECT * FROM Subscriptions WHERE Name = @Name and Parent = @Parent";
            SqlCommand command = new SqlCommand(searchCommand, connection);
            command.Parameters.AddWithValue("@Name", subscription_name);
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
                    Subscription obj = new Subscription();
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Name = reader["Name"].ToString();
                    obj.Creation_dt = Convert.ToDateTime(reader["Creation_dt"]);
                    obj.Parent = Convert.ToInt32(reader["Parent"]);
                    obj.Event = reader["Event"].ToString();
                    obj.Endpoint = reader["Endpoint"].ToString();
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

    public static void DeleteFromDatabase(string application_name, string module_name, string subscription_name)
    {
        // Find the subscription
        Subscription obj = FindObjectInDatabase(application_name, module_name, subscription_name);
        if (obj == null)
        {
            throw new Exception("Null Object");
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Set up the command to delete object from the database
            string insertCommand = "DELETE FROM Subscriptions WHERE Name = @name AND Parent = @parent";
            SqlCommand command = new SqlCommand(insertCommand, connection);

            // Add the parameters for the object's name 
            command.Parameters.AddWithValue("@name", obj.Name);
            command.Parameters.AddWithValue("@parent", obj.Parent);

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
}

using SomiodWebApplication.Handlers;
using SomiodWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

public class SubscriptionHandler
{
    static string connectionString = SomiodWebApplication.Properties.Settings.Default.connStr;

    public static int SaveToDatabase(string application_name, string module_name, Subscription mySubscription)
    {
        // Attributes to send to the DB
        string newSubscriptionName = mySubscription.Name;
        DateTime todaysDateAndTime = DateTime.Now;
        string newSubscriptionEvent = mySubscription.Event;

        if (newSubscriptionEvent != "creation" && newSubscriptionEvent != "deletion" && newSubscriptionEvent != "creation and deletion") {
            throw new Exception("Event must be 'creation', 'deletion' or 'creation and deletion'");
        }

        int rowsInserted = 0;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            if (FindObjectInDatabase(application_name, module_name, newSubscriptionName) != null)
             {
                 throw new Exception("There are already exists a subscription named " + newSubscriptionName + " in the module "+module_name+" from application " + application_name);
             }

            // Set up the command to insert the object into the database
            string insertCommand = "INSERT INTO Subscriptions VALUES (@name, @date, @parent, @event, @endpoint)";
            SqlCommand command = new SqlCommand(insertCommand, connection);

            Module moduleObj = ModuleHandler.FindObjectInDatabase(application_name, module_name);
            if (moduleObj == null)
            {
                throw new Exception("Module '" + module_name + "' from Application '" + application_name + "' does not exist");
            }

            // Remove Spaces from Name and Add "-"
            newSubscriptionName = newSubscriptionName.Replace(" ", "-");

            // Add the parameters for the object's name and value
            command.Parameters.AddWithValue("@name", newSubscriptionName);
            command.Parameters.AddWithValue("@date", todaysDateAndTime);
            command.Parameters.AddWithValue("@event", newSubscriptionEvent);
            command.Parameters.AddWithValue("@endpoint", mySubscription.Endpoint);
            command.Parameters.AddWithValue("@parent", moduleObj.Id);

            // Makes the connection to the Database
            try
            {
                // Open the database connection and execute the insert command
                connection.Open();
                rowsInserted = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // Handle any errors that may have occurred
                Console.WriteLine("Error inserting object into database: " + ex.Message);
                throw new Exception(ex.Message);
            }

            return rowsInserted;
        }
    }

    public static void DeleteFromDatabase(string application_name, string module_name, string subscription_name)
    {
        // Find the subscription
        Subscription obj = FindObjectInDatabase(application_name, module_name, subscription_name);
        if (obj == null)
        {
            throw new Exception("Subscription Not Found");
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Set up the command to delete object from the database
            string insertCommand = "DELETE FROM Subscriptions WHERE Id = @id AND Parent = @parent";
            SqlCommand command = new SqlCommand(insertCommand, connection);

            // Add the parameters for the object's name 
            command.Parameters.AddWithValue("@id", obj.Id);
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

    public static Subscription FindObjectInDatabase(string application_name, string module_name, string subscription_name)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Finds Module
            Module module = new Module();
            try
            {
                module = ModuleHandler.FindObjectInDatabase(application_name, module_name);
            }
            catch (Exception)
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
}

using SomiodWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SomiodWebApplication.Handlers
{
    public class SubscriptionHandler
    {
        static string connectionString = Properties.Settings.Default.connStr;

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
                // Set up the command to insert the object into the database
                string insertCommand = "INSERT INTO Subscriptions VALUES (@name, @date, @parent, @event, @endpoint)";
                SqlCommand command = new SqlCommand(insertCommand, connection);

                Module moduleObj = ModuleHandler.FindObjectInDatabase(application_name, module_name);
                if (moduleObj == null) {
                    throw new Exception("Module '" + module_name + "' from Application '"+application_name+"' does not exist");
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
            }

            return rowsInserted;
        }

        public static void DeleteFromDatabase(string name)
        {
        }
    }
}
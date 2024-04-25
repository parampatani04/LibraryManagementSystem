using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.LifecycleEvents;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagementSystem.Components.Pages.Data
{
    public class DBConnection
    {
        public static MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
        {
            // define the server
            Server = "localhost",
            Database = "librarymanagementsystem",
            UserID = "root",
            Password = "password",
        };
        public bool CheckCreds(string username, string password)
        {
            using (var connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string query = "Select * from login_creds";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string usernm = reader.GetString(0);
                    string pass = reader.GetString(1);

                    if (pass == password && username == usernm)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}

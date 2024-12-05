using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GuidanceManagementSystem.methods
{
    internal class MyCon
    {
        public static string _loggedName { get; set; }
        public static int _loggedId { get; set; }

        // Get connection method with improved error handling
        public static MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost;database=guidancedb;user=root;password=;"; // Direct connection string
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open(); // Ensure the connection is opened
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to establish a database connection. Error: {ex.Message}",
                                "Connection Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return null; // Return null to indicate failure
            }
        }

        // Login method
        public static (int UserType, int ID, string Name) _Login(string username, string password)
        {
            using (MySqlConnection conn = GetConnection())
            {
                if (conn == null)
                {
                    MessageBox.Show("Unable to connect to the database. Please check your connection.",
                                    "Connection Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return (0, 0, string.Empty);
                }

                try
                {
                    // Query both tables with UNION and select the user type, ID, and name
                    string sql = @"SELECT IFNULL(UserType, 0) AS UserType, IFNULL(ID, 0) AS ID, IFNULL(Name, '') AS Name
                                   FROM (
                                       SELECT 1 AS UserType, Admin_ID AS ID, Admin_Name AS Name
                                       FROM tbl_admin_account
                                       WHERE Admin_Name = @username AND Admin_Password = @password
                                       UNION
                                       SELECT 2 AS UserType, Staff_ID AS ID, Staff_Name AS Name
                                       FROM tbl_staff_account
                                       WHERE Staff_Name = @username AND Staff_Pass = @password
                                   ) AS combined
                                   LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userType = reader.GetInt32("UserType");
                            int id = reader.GetInt32("ID");
                            string name = reader.GetString("Name");

                            if (userType > 0)
                            {
                                return (userType, id, name);
                            }
                        }
                    }

                    // If no records were found
                    MessageBox.Show("Invalid username or password.",
                                    "Login Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return (0, 0, string.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during login: {ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return (0, 0, string.Empty);
                }
            }
        }
    }
}

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
        public static MySqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GuidanceDB"].ConnectionString;
            return new MySqlConnection(connectionString);
        }

        public static (int UserType, int ID, string Name) _Login(string username, string password)
        {
            MySqlConnection conn = MyCon.GetConnection();

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

                conn.Open();
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
                MessageBox.Show("Invalid username or password.");
                return (0, 0, string.Empty);
            }
            catch (Exception)
            {
                //MessageBox.Show("Error: " + ex.Message);
                return (0, 0, string.Empty); // Indicate an error with (0, 0, "")
            }
            finally
            {
                conn.Close();
            }
        }


    }
}

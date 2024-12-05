using GuidanceManagementSystem.methods;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuidanceManagementSystem.View_Frms
{
    public partial class superadmin : Form
    {
        public int AccountID { get; set; }
        public string AccountPassword { get; set; }
        public string AccountType { get; set; }
        public superadmin()
        {
            InitializeComponent();
        }
        private void UpdateAccountPassword(string table, int accountID, string newPassword)
        {

            string query = table == "tbl_admin_account"
                ? "UPDATE tbl_admin_account SET Admin_Password = @NewPassword WHERE Admin_ID = @AccountID"
                : "UPDATE tbl_staff_account SET Staff_Pass = @NewPassword WHERE Staff_ID = @AccountID";


                using (var command = new MySqlCommand(query, MyCon.GetConnection()))
                {
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.Parameters.AddWithValue("@AccountID", accountID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Account not found or password not updated.");
                    }
                }
            
        }
 

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NextButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                MessageBox.Show("Please enter a new password.");
                return;
            }

            // Get the new password from the form
            string newPassword = txtNewPassword.Text;

            // Determine if the account is Admin or Staff based on the AccountType property
            string table = AccountType == "Admin" ? "tbl_admin_account" : "tbl_staff_account";

            // Update the password in the database
            try
            {
                UpdateAccountPassword(table, AccountID, newPassword);
               
                MessageBox.Show("Account updated successfully!");
                this.Close(); // Optionally close the form after update
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating account: {ex.Message}");
            }
        }

        private void superadmin_Load(object sender, EventArgs e)
        {
            txtAccountID.Text = AccountID.ToString();
            txtNewPassword.Text = AccountPassword;
            txtAccountID.Enabled = false;

            // Based on the account type (Admin/Staff), you could add different logic
            lblaccount.Text = AccountType;

            // Optionally, you can load additional data for the selected account, such as password or other details
            LoadAccountDetails(AccountID);
        }
        private void LoadAccountDetails(int accountID)
        {
            // You can load more details, like password, from the database and display them in the form
        
                string query = $"SELECT * FROM tbl_admin_account WHERE Admin_ID = @AccountID"; // Use appropriate query for Admin or Staff

                using (var command = new MySqlCommand(query, MyCon.GetConnection()))
                {
                    command.Parameters.AddWithValue("@AccountID", accountID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Assuming you want to show the password as well, you can modify the form fields accordingly
                            txtNewPassword.Text = reader.GetString("Admin_Password"); // Or Staff_Pass for Staff
                        }
                    }
                }
            }
        }
    }


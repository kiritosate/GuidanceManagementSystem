using CrystalDecisions.ReportAppServer.Prompting;
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
using static GuidanceManagementSystem.View_Frms.LoginFrm;

namespace GuidanceManagementSystem.View_Frms
{
    public partial class Account_view : Form
    {

        public Account_view()
        {
            InitializeComponent();
            
        }
        private void InitializeDataGridViewColumns()
        {
            // Clear any existing columns to avoid duplicates
            dataGridViewAccounts.Columns.Clear();

            // Add Account ID column
            dataGridViewAccounts.Columns.Add("AccountID", "Account ID");

            // Add Account Name column
            dataGridViewAccounts.Columns.Add("AccountName", "Account Name");

            // Add Password column (this will store the password)
            dataGridViewAccounts.Columns.Add("Password", "Password");

            dataGridViewAccounts.Columns.Add("UpdatedAt", "Updated At");

            // Add Delete Button column
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.Name = "DeleteColumn";
            deleteColumn.HeaderText = "Delete";
            deleteColumn.Text = "Delete";
            deleteColumn.UseColumnTextForButtonValue = true;
            dataGridViewAccounts.Columns.Add(deleteColumn);

            // Add Update Button column
            DataGridViewButtonColumn updateColumn = new DataGridViewButtonColumn();
            updateColumn.Name = "UpdateColumn";
            updateColumn.HeaderText = "Update";
            updateColumn.Text = "Update";
            updateColumn.UseColumnTextForButtonValue = true;
            dataGridViewAccounts.Columns.Add(updateColumn);
        }
        private void DeleteAccount(string tableName, int accountID)
        {
         
                string query = $"DELETE FROM {tableName} WHERE Admin_ID = @AccountID OR Staff_ID = @AccountID;";

                using (var command = new MySqlCommand(query, MyCon.GetConnection()))
                {
                    command.Parameters.AddWithValue("@AccountID", accountID);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Account not found or already deleted.");
                    }
                }
            }
        

        


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewAccounts.Rows.Count)
            {

                // Handling delete operation
                if (e.ColumnIndex == dataGridViewAccounts.Columns["DeleteColumn"].Index)
                {
                    // Get Account ID from the clicked row
                    int accountID = Convert.ToInt32(dataGridViewAccounts.Rows[e.RowIndex].Cells["AccountID"].Value);
                    string accountType = comboBoxAccountType.SelectedItem.ToString();
                    string table = accountType == "Admin" ? "tbl_admin_account" : "tbl_staff_account";

                    // Delete the account
                    DeleteAccount(table, accountID);
                    MessageBox.Show("Account Deleted Successfully!");

                    // Reload the DataGridView after deletion
                    LoadAccountData(accountType);  // Reload data for the specific account type (Admin/Staff)
                }

                // Handling update operation
                else if (e.ColumnIndex == dataGridViewAccounts.Columns["UpdateColumn"].Index)
                {
                    // Check if the row is not empty before accessing the cells
                    if (dataGridViewAccounts.Rows[e.RowIndex].Cells["AccountID"].Value != DBNull.Value)
                    {
                        int rowIndex = e.RowIndex;

                        // Update the UpdatedAt field with the current date and time
                        dataGridViewAccounts.Rows[rowIndex].Cells["UpdatedAt"].Value = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

                        // You can add additional code to handle the actual account update, like saving changes to the database
                        UpdateAccountInDatabase(rowIndex);
                        // Get Account ID and Name from the clicked row
                        int accountID = Convert.ToInt32(dataGridViewAccounts.Rows[e.RowIndex].Cells["AccountID"].Value);
                        string accountName = dataGridViewAccounts.Rows[e.RowIndex].Cells["AccountName"].Value.ToString();
                        string accountType = comboBoxAccountType.SelectedItem.ToString();  // Admin or Staff

                        // Open SuperAdmin Form to update
                        OpenSuperAdminForm(accountID, accountName, accountType);
                        
                    }
                    else
                    {
                        MessageBox.Show("Account data is not valid or empty.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid row index.");
            }
        }
        private void UpdateAccountInDatabase(int rowIndex)
        {
            string accountID = dataGridViewAccounts.Rows[rowIndex].Cells["AccountID"].Value.ToString();
            string accountName = dataGridViewAccounts.Rows[rowIndex].Cells["AccountName"].Value.ToString();
            string password = dataGridViewAccounts.Rows[rowIndex].Cells["Password"].Value.ToString();
            string updatedAt = dataGridViewAccounts.Rows[rowIndex].Cells["UpdatedAt"].Value.ToString();

            // Perform your database update logic here
            // Example:
            // UpdateAccount(accountID, accountName, password, updatedAt);
        }

        private void OpenSuperAdminForm(int accountID, string accountName, string accountType)
        {
            superadmin superAdminForm = new superadmin();

            // Pass the account information and account type (Admin or Staff)
            superAdminForm.AccountID = accountID;
            superAdminForm.AccountPassword = accountName;
            superAdminForm.AccountType = accountType;  // Set the account type

            // Show the SuperAdmin form
            BlurEffectHelper.BlurBackground(superAdminForm);       
        }
        private void comboBoxAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboBoxAccountType.SelectedItem.ToString();
            LoadAccountData(selectedType);
        }
        // Load Account Data for Admin or Staff
        private void LoadAccountData(string selectedType)
        {
            // Clear existing rows
            dataGridViewAccounts.Rows.Clear();

            // Determine which table to fetch data from based on ComboBox selection
            string tableName = selectedType == "Admin" ? "tbl_admin_account" : "tbl_staff_account";
            string query = $"SELECT * FROM {tableName}";


          
                MySqlCommand command = new MySqlCommand(query, MyCon.GetConnection());

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0); // Get Account ID (Admin_ID or Staff_ID)
                        string name = reader.GetString(1); // Get Account Name (Admin_Name or Staff_Name)
                        string password = reader.GetString(2); // Get Password (Admin_Password or Staff_Pass)

                        // Add a row for each account in the DataGridView
                        int rowIndex = dataGridViewAccounts.Rows.Add(id, name, password);

                        // Add Delete Button for each row
                        DataGridViewButtonCell deleteButton = new DataGridViewButtonCell();
                        deleteButton.Value = "Delete";
                        dataGridViewAccounts.Rows[rowIndex].Cells["DeleteColumn"] = deleteButton;

                        // Add Update Button for each row
                        DataGridViewButtonCell updateButton = new DataGridViewButtonCell();
                        updateButton.Value = "Update";
                        dataGridViewAccounts.Rows[rowIndex].Cells["UpdateColumn"] = updateButton;
                    }
                }
            }
        


        private void Account_view_Load(object sender, EventArgs e)
        {
            InitializeDataGridViewColumns();
            comboBoxAccountType.SelectedIndex = 0; // Optionally, choose "Admin" as the default
            LoadAccountData(comboBoxAccountType.SelectedItem.ToString());
            dataGridViewAccounts.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

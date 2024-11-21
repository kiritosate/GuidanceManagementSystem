using CuoreUI.Controls;
using GuidanceManagementSystem.methods;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GuidanceManagementSystem.methods.MyMethods;

namespace GuidanceManagementSystem.View_Frms
{
    public partial class registration_view : Form
    {
        public registration_view()
        {
            InitializeComponent();
            fetchService = new MyFetch();
            methods = new MyMethods();
        }

        private BindingSource bindingSource = new BindingSource();
        private methods.MyFetch fetchService;
        private methods.MyMethods methods;
        private String StudentId;

        private void cuiTextBox21_ContentChanged(object sender, EventArgs e)
        {
            string searchText = cuiTextBox21.Content.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                bindingSource.Filter = $"Student_ID LIKE '%{searchText}%' OR " +
                                       $"Course LIKE '%{searchText}%' OR " +
                                       $"Year LIKE '%{searchText}%' OR " +
                                       $"Firstname LIKE '%{searchText}%' OR " +
                                       $"Middlename LIKE '%{searchText}%' OR " +
                                       $"Lastname LIKE '%{searchText}%' OR " +
                                       $"Sex LIKE '%{searchText}%'";
            }
            else
            {
                bindingSource.RemoveFilter();
            }
        }

        private void LoadDataIntoDataGridView(DataGridView dataGridView)
        {
            MySqlDataAdapter adapter = fetchService.GetIndividualDataPending();
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            bindingSource.DataSource = dataTable;   // Fill the DataTable with data
            dataGridView.DataSource = bindingSource; // Bind the DataTable to the DataGridView
            AddActionColumns();

        }

        private void AddActionColumns()
        {
            // Create the View column
            DataGridViewImageColumn viewColumn = new DataGridViewImageColumn();
            viewColumn.HeaderText = "View";
            viewColumn.Name = "imgView";
            viewColumn.Image = Properties.Resources.eye_96px; // Replace with your resource image
            viewColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Optionally set layout
            dataGridView1.Columns.Add(viewColumn);

            // Create the Edit column
            DataGridViewImageColumn editColumn = new DataGridViewImageColumn();
            editColumn.HeaderText = "Edit";
            editColumn.Name = "imgEdit";
            editColumn.Image = Properties.Resources.pen_50px; // Replace with your resource image
            editColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Optionally set layout
            dataGridView1.Columns.Add(editColumn);
            // Create the Delete column
            DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn();
            deleteColumn.HeaderText = "Delete";
            deleteColumn.Name = "imgDelete";
            deleteColumn.Image = Properties.Resources.Delete_Trash_50px; // Replace with your resource image
            deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Optionally set layout
            dataGridView1.Columns.Add(deleteColumn);
        }

        private void registration_view_Load(object sender, EventArgs e)
        {
            timer1.Start();

            LoadDataIntoDataGridView(dataGridView1);
        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            webserver_view ws = new webserver_view();
            ws.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (methods.IsApacheRunning())
            {
                //Console.WriteLine("Apache is running.");
                //webserver_view._serverUp = true;
                cuiButton2.Image = Properties.Resources.cloud_sync_480px;
            }
            else
            {
                //Console.WriteLine("Apache is not running.");
                //webserver_view._serverUp = false;
                cuiButton2.Image = Properties.Resources.cloud_cross_480px;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int columnIndex = e.ColumnIndex;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Find the column index for "StudentId" column by name
                int studentIdColumnIndex = dataGridView1.Columns["Student_Id"].Index;

                // Retrieve the StudentId value based on its column index
                StudentId = row.Cells[studentIdColumnIndex].Value?.ToString() ?? "N/A";

                // Check if the clicked column is one of the action columns
                if (dataGridView1.Columns[columnIndex].Name == "imgView")
                {
                    //MessageBox.Show("You clicked to view the record.");
                    view_irf fm = new view_irf();
                    fm.ShowDialog();
                }
                else if (dataGridView1.Columns[columnIndex].Name == "imgEdit")
                {
                    MessageBox.Show("You clicked to edit the record.");
                }

                //MessageBox.Show($"Student Id: {StudentId}: {row.Cells[1]}");
            }
        }

        private void MoveOrInsertActionColumns(int sexColumnIndex)
        {
            // Check if the action columns exist, and move them to the correct position
            int viewIndex = dataGridView1.Columns["imgView"]?.Index ?? -1;
            int editIndex = dataGridView1.Columns["imgEdit"]?.Index ?? -1;
            int deleteIndex = dataGridView1.Columns["imgDelete"]?.Index ?? -1;

            if (viewIndex != -1 && editIndex != -1 && deleteIndex != -1)
            {
                // If the columns exist, move them after "Sex"
                dataGridView1.Columns["imgView"].DisplayIndex = sexColumnIndex + 1;
                dataGridView1.Columns["imgEdit"].DisplayIndex = sexColumnIndex + 2;
                dataGridView1.Columns["imgDelete"].DisplayIndex = sexColumnIndex + 3;
            }
            else
            {
                // Otherwise, add them to the correct position
                AddActionColumns();
            }
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            enrollment frm = new enrollment();
            frm.ShowDialog();

        }
        public void LoadData()
        {
            string connectionString = "server=localhost;database=guidancedb;user=root;password=;";
             string query = @"SELECT ir.Student_ID, 
                            ir.Course, 
                            ir.Year,
                            pd.FirstName, pd.MiddleName, pd.LastName, pd.Sex
                     FROM tbl_individual_record ir
                     INNER JOIN tbl_personal_data pd 
                     ON ir.Student_ID = pd.Student_ID";

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Clear any existing data source before binding
                        dataGridView1.DataSource = null;

                        // Bind the new data
                        dataGridView1.DataSource = dataTable;

                        // Ensure action columns are added if they do not exist
                        AddActionColumns();
                    }
                }

                // Add the action columns after the "Sex" column, if the column exists
                int sexColumnIndex = dataGridView1.Columns["Sex"]?.Index ?? -1;
                if (sexColumnIndex != -1)
                {
                    // Only move the action columns if they exist, or add them
                    MoveOrInsertActionColumns(sexColumnIndex);
                }
                else
                {
                    // If "Sex" column doesn't exist, just add action columns at the end
                    AddActionColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                // Get the Student_ID from the selected row
                string studentID = dataGridView1.Rows[e.RowIndex].Cells["Student_ID"].Value?.ToString();

                if (string.IsNullOrEmpty(studentID))
                {
                    MessageBox.Show("Invalid Student ID. Unable to delete.");
                    return;
                }
                DialogResult confirmation = MessageBox.Show("Are you sure you want to delete this record?",
                                                             "Confirmation",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Warning);

                if (confirmation == DialogResult.Yes)
                {
                    Delete.DeleteRecord(studentID);
                    MessageBox.Show("Successfully Deleted...");

                    dataGridView1.Columns.Clear();
                    LoadData();
                }
            }
        }
    }
}

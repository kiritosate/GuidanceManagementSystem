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
    public partial class recordfrm : Form
    {
        public recordfrm()
        {
            InitializeComponent();
            fetchService = new MyFetch();
            methods = new MyMethods();

            cmbCourses.SelectedIndexChanged += (sender, args) =>
            {
                string selectedCourse = cmbCourses.SelectedItem?.ToString();
                LoadDataIntoDataGridView(dataGridView1, selectedCourse); // Filter the grid
            };
        }


        private void AddActionColumns()
        {
            // Check if the "View" column already exists
            if (dataGridView1.Columns["imgView"] == null)
            {
                DataGridViewImageColumn viewColumn = new DataGridViewImageColumn
                {
                    HeaderText = "View",
                    Name = "imgView",
                    Image = Properties.Resources.eye_96px, // Replace with your resource image
                    ImageLayout = DataGridViewImageCellLayout.Zoom // Ensures the image is resized proportionally
                };
                dataGridView1.Columns.Add(viewColumn);
            }

            // Check if the "Edit" column already exists
            if (dataGridView1.Columns["imgEdit"] == null)
            {
                DataGridViewImageColumn editColumn = new DataGridViewImageColumn
                {
                    HeaderText = "Edit",
                    Name = "imgEdit",
                    Image = Properties.Resources.pen_50px, // Replace with your resource image
                    ImageLayout = DataGridViewImageCellLayout.Zoom // Ensures the image is resized proportionally
                };
                dataGridView1.Columns.Add(editColumn);
            }

            // Check if the "Delete" column already exists
            if (dataGridView1.Columns["imgDelete"] == null)
            {
                DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn
                {
                    HeaderText = "Delete",
                    Name = "imgDelete",
                    Image = Properties.Resources.Delete_Trash_50px, // Replace with your resource image
                    ImageLayout = DataGridViewImageCellLayout.Zoom // Ensures the image is resized proportionally
                };
                dataGridView1.Columns.Add(deleteColumn);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int viewColumnIndex = dataGridView1.Columns["ImgView"].Index;
            int editColumnIndex = dataGridView1.Columns["ImgEdit"].Index;
            int deleteColumnIndex = dataGridView1.Columns["ImgDelete"].Index;

            if (e.RowIndex >= 0) // Ensure it's a valid row
            {
                string studentID = dataGridView1.Rows[e.RowIndex].Cells["Student_ID"].Value.ToString();

                if (e.ColumnIndex == viewColumnIndex)
                {
                    ViewRecord(studentID);
                }
                else if (e.ColumnIndex == editColumnIndex)
                {
                    EditRecord(studentID);
                }
                else if (e.ColumnIndex == deleteColumnIndex)
                {
                    DeleteRecord(studentID);
                }
            }
        }
        private void ViewRecord(string studentID)
        {
            // Display the details of the selected record
            MessageBox.Show($"View details for Student ID: {studentID}");
        }

        private void EditRecord(string studentID)
        {
            // Open a form to edit the selected record
            MessageBox.Show($"Edit record for Student ID: {studentID}");
        }

        private void DeleteRecord(string studentID)
        {
            string connectionString = "server=localhost;database=guidancedb;user=root;password=;";
            string query = "DELETE FROM tbl_individual_record WHERE Student_ID = @StudentID";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Deleted.");
            LoadDataIntoDataGridView(dataGridView1);
        }

        private void recordfrm_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView(dataGridView1);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void cuiTextBox21_ContentChanged(object sender, EventArgs e)
        {

        }

        private BindingSource bindingSource = new BindingSource();
        private methods.MyFetch fetchService;
        private methods.MyMethods methods;
        private String StudentId;

        private void cuiTextBox21_ContentChanged_1(object sender, EventArgs e)
        {
            string searchText = cuiTextBox21.Content.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                string courseFilter = (cmbCourses.SelectedIndex != -1) ?
                                        $"Course LIKE '%{cmbCourses.SelectedItem}%' " :
                                        $"Course LIKE '%{searchText}%'";

                // Apply the filter with conditional course filter
                bindingSource.Filter = $"Student_ID LIKE '%{searchText}%' OR " +
                                       $"Course LIKE '%{searchText}%' OR " +
                                       $"Year LIKE '%{searchText}%' OR " +
                                       $"FirstName LIKE '%{searchText}%' OR " +
                                       $"MiddleName LIKE '%{searchText}%' OR " +
                                       $"LastName LIKE '%{searchText}%' OR " +
                                       $"Sex LIKE '%{searchText}%'";
            }
            else
            {
                bindingSource.RemoveFilter();
            }

            LoadDataIntoDataGridView(dataGridView1, cmbCourses.SelectedItem?.ToString());
        }

        private void LoadDataIntoDataGridView(DataGridView dataGridView, string course = null)
        {
            MySqlDataAdapter adapter = fetchService.GetIndividualDataActive(course);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            bindingSource.DataSource = dataTable;   // Fill the DataTable with data
            dataGridView.DataSource = bindingSource; // Bind the DataTable to the DataGridView
            AddActionColumns();

        }
    }
}

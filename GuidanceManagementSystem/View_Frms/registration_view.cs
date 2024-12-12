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
using static GuidanceManagementSystem.View_Frms.LoginFrm;

namespace GuidanceManagementSystem.View_Frms
{
    public partial class registration_view : Form
    {
        public string SavedStudentID { get; set; }
        public registration_view(string StudentID)
        {
            InitializeComponent();
            fetchService = new MyFetch();
            methods = new MyMethods();
            SavedStudentID = StudentID;
            GlobalData.SavedStudentID = this.SavedStudentID;


            cmbCourses.SelectedIndexChanged += (sender, args) =>
            {
                string selectedCourse = cmbCourses.SelectedItem?.ToString();
                LoadDataIntoDataGridView(dataGridView1, selectedCourse); // Filter the grid
            };
        }

        public registration_view()
        {
        }

        public static class GlobalData
        {
            public static string SavedStudentID { get; set; }
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
                string courseFilter = (cmbCourses.SelectedIndex != -1) ?
                                        $"Course LIKE '%{cmbCourses.SelectedItem}%' " :
                                        $"Course LIKE '%{searchText}%'";

                // Apply the filter with conditional course filter
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

            LoadDataIntoDataGridView(dataGridView1, cmbCourses.SelectedItem?.ToString());
        }
        private void LoadDataIntoDataGridView(DataGridView dataGridView, string course = null)
        {
            MySqlDataAdapter adapter = fetchService.GetIndividualDataPending(course);
            DataTable dataTable = new DataTable();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);


            adapter.Fill(dataTable);

            bindingSource.DataSource = dataTable;   // Fill the DataTable with data
            dataGridView.DataSource = bindingSource; // Bind the DataTable to the DataGridView
            AddActionColumns();

        }
        private void AddActionColumns()
        {
            if (dataGridView1.Columns["btnApprove"] == null)
            {
                DataGridViewButtonColumn approveColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Approve",
                    Name = "btnApprove",

                    Text = "Approve",

                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(approveColumn);
            }
            if (dataGridView1.Columns["imgView"] == null)
            {
                DataGridViewImageColumn viewColumn = new DataGridViewImageColumn
                {
                    HeaderText = "View",
                    Name = "imgView",
                    Image = Properties.Resources.eye_96px, // Replace with your resource image
                    ImageLayout = DataGridViewImageCellLayout.Zoom // Optionally set layout
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
                    ImageLayout = DataGridViewImageCellLayout.Zoom // Optionally set layout
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
                    ImageLayout = DataGridViewImageCellLayout.Zoom // Optionally set layout
                };
                dataGridView1.Columns.Add(deleteColumn);
            }
        }

        private void registration_view_Load(object sender, EventArgs e)
        {
            timer1.Start();

            LoadDataIntoDataGridView(dataGridView1);
            //LoadCourses();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            webserver_view ws = new webserver_view();
            BlurEffectHelper.BlurBackground(ws);
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

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Validate that a row is clicked
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    int columnIndex = e.ColumnIndex;
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Retrieve the Student_ID value from the row
                    string studentId = row.Cells["Student_ID"]?.Value?.ToString();

                    if (string.IsNullOrEmpty(studentId))
                    {
                        MessageBox.Show("Student ID is missing. Please select a valid record.");
                        return;
                    }

                    // Check which column is clicked
                    if (dataGridView1.Columns[columnIndex].Name == "imgView")
                    {
                        // Handle the "View" operation
                        view_irf fm = new view_irf(studentId);
                        BlurEffectHelper.BlurBackground(fm);
                        fm.ShowDialog();
                    }
                    else if (dataGridView1.Columns[columnIndex].Name == "btnApprove")
                    {
                        // Handle the "Approve" operation
                        ApproveStudent(studentId);
                    }
                    else if (dataGridView1.Columns[columnIndex].Name == "imgDelete")
                    {
                        Delete.DeleteRecord(studentId);
                        LoadData();
                    }
                    else if (dataGridView1.Columns[columnIndex].Name == "imgEdit")
                    {
                        // Handle the "Edit" operation
                        enrollment enrollmentForm = Application.OpenForms["enrollment"] as enrollment;
                        if (enrollmentForm == null)
                        {
                            // If the form is not open, create a new instance
                            enrollmentForm = new enrollment();
                            enrollmentForm.Name = "enrollment"; // Ensure the form has this name for detection
                        }

                        // Make sure the form is visible and bring it to front
                        enrollmentForm.BringToFront();

                        // Pass the student ID and other necessary data to the form
                        enrollmentForm.LoadEducationalDataToForm(studentId);
                        enrollmentForm.SetEditMode(studentId);

                        // Now, load the student image from the database and display it in the PictureBox
                        byte[] imageBytes = enrollmentForm.RetrieveImageFromDatabase(studentId);
                        enrollmentForm.DisplayImageInPictureBox(imageBytes);

                        // Show the form with blur effect
                        BlurEffectHelper.BlurBackground(enrollmentForm);
                        enrollmentForm.Show();
                        LoadData();
                    }
                    else
                    {
                        // Optional: Handle other columns if necessary
                        MessageBox.Show("No action assigned for this column.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid row or column clicked.");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"An unexpected error occurred: DITO YON {ex.Message}");
            }

        }
            private void ApproveStudent(string studentID)
        {            
            string query = @"UPDATE tbl_individual_record 
                     SET Status = 1 
                     WHERE Student_ID = @StudentID";
            MySqlConnection con =  MyCon.GetConnection();
            try
            {
                using (var command = new MySqlCommand(query,con))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    // Execute the update query
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student record approved successfully!");

                        // Reload data to reflect changes
                        LoadData(); // You can pass the course parameter if needed
                    }
                    else
                    {
                        MessageBox.Show("Error: Student record not found or could not be approved.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error approving student: {ex.Message}");
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

            // Show the form with the blur effect on the background
             BlurEffectHelper.BlurBackground(frm);

        }
        public void LoadData(string course = null)
        {
            string query = @"SELECT ir.Student_ID, 
                     ir.Course, 
                     ir.Year,
                     pd.Firstname, pd.Middlename, pd.Lastname, pd.Sex,
                     CASE WHEN ir.Status = 1 THEN 'Approved' ELSE 'Pending' END AS Status
              FROM tbl_individual_record ir
              INNER JOIN tbl_personal_data pd 
              ON ir.Student_ID = pd.Student_ID WHERE status=0";

            if (!string.IsNullOrEmpty(course) && course != "All")
            {
                query += " WHERE ir.Course = @Course";
            }
            MySqlConnection con = MyCon.GetConnection();
            try
            {
                using (var command = new MySqlCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(course) && course != "All")
                    {
                        command.Parameters.AddWithValue("@Course", course);
                    }

                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Clear existing columns and data to prevent duplication
                        dataGridView1.DataSource = null;
                        dataGridView1.Columns.Clear();

                        // Bind new data
                        dataGridView1.DataSource = dataTable;

                        // Add the action columns (View, Edit, Delete)
                        AddActionColumns();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
           
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void LoadCourses()
        {
            string query = "SELECT DISTINCT Course FROM tbl_individual_record WHERE status=0";
            MySqlConnection con = MyCon.GetConnection();
            try
            {


                using (var command = new MySqlCommand(query, con))
                using (var reader = command.ExecuteReader())
                {
                    cmbCourses.Items.Clear();
                    cmbCourses.Items.Add("All"); // Add "All Courses" option first

                    while (reader.Read())
                    {
                        cmbCourses.Items.Add(reader.GetString("Course"));
                    }

                    cmbCourses.SelectedIndex = 0; // Default to "All Courses"
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null && e.Value.ToString() == "Approved")
                {
                    e.CellStyle.ForeColor = Color.Green; // Green for Approved
                }
                else if (e.Value != null && e.Value.ToString() == "Pending")
                {
                    e.CellStyle.ForeColor = Color.Red; // Red for Pending
                }
            }
        }

        private void cuiLabel2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Assuming the first column is the StudentID
            string studentID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            enrollment enrollment = new enrollment();
            // Call method to load student data, including image
            enrollment.LoadStudentData(studentID);
        }

        private void cmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

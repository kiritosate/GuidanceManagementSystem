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
            if (e.RowIndex >= 0)
            {
                int columnIndex = e.ColumnIndex;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Find the column index for "StudentId" column by name
                int studentIdColumnIndex = dataGridView1.Columns["Student_Id"].Index;

                // Retrieve the StudentId value based on its column index
                StudentId = row.Cells[studentIdColumnIndex].Value?.ToString() ?? "N/A";

                // Check if the clicked column is one of the action columns
                if (e.ColumnIndex == dataGridView1.Columns["imgView"].Index)
                {
                    // Get the student ID from the clicked row
                    string studentId = dataGridView1.Rows[e.RowIndex].Cells["Student_ID"].Value.ToString();

                    // Now you can create your view_irf form and pass the studentId
                    view_irf fm = new view_irf(studentId);

                    // Optional: Blur the background if needed
                    BlurEffectHelper.BlurBackground(fm);

                    // Show the form
                    //fm.Show();
                }
                else if (e.ColumnIndex == dataGridView1.Columns["btnApprove"].Index && e.RowIndex >= 0)
                {
                    // Get the Student_ID from the selected row
                    string studentID = dataGridView1.Rows[e.RowIndex].Cells["Student_ID"].Value.ToString();

                    // Call a method to approve the student record
                    ApproveStudent(studentID);
                }

                else if (dataGridView1.Columns[columnIndex].Name == "imgEdit")
                {
                    // Retrieve the selected student ID from the DataGridView
                    string studentId = dataGridView1.Rows[e.RowIndex].Cells["Student_ID"].Value.ToString();
                   
                    // Create a new instance of the Enrollment Form
                    enrollment enrollmentForm = new enrollment();

                    foreach (TabPage tabPage in enrollmentForm.tabControl1.TabPages)
                    {
                        tabPage.Enabled = true; // Enable each tab page
                    }

                    // Optionally, set a specific tab as the selected one
                    //enrollmentForm.tabControl1.SelectedTab = enrollmentForm.tabControl1.TabPages["tabPage1"]; // Replace "tabPage1" with the tab you want to select

                    enrollmentForm.LoadEducationalDataToForm(studentId);
            
                    enrollmentForm.SetEditMode(studentId);
                    BlurEffectHelper.BlurBackground(enrollmentForm);
                }
            }
            //MessageBox.Show($"Student Id: {StudentId}: {row.Cells[1]}");      
       }
    



        private void ApproveStudent(string studentID)
        {            
            string query = @"UPDATE tbl_individual_record 
                     SET Status = 1 
                     WHERE Student_ID = @StudentID";
            try
            {
                    using (var command = new MySqlCommand(query, MyCon.GetConnection()))
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

            try
            {
                    using (var command = new MySqlCommand(query, MyCon.GetConnection()))
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
                    dataGridView1.Columns.Clear();
                    LoadData();
                }
            }
        }
        private void LoadCourses()
        {
            string query = "SELECT DISTINCT Course FROM tbl_individual_record WHERE status=0";
            try
            {
               

                    using (var command = new MySqlCommand(query, MyCon.GetConnection()))
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
    }
}

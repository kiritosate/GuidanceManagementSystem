﻿using GuidanceManagementSystem.methods;
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
using GuidanceManagementSystem.methods;
using static GuidanceManagementSystem.methods.MyMethods;
using static GuidanceManagementSystem.View_Frms.LoginFrm;

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
            //if (dataGridView1.Columns["imgEdit"] == null)
            //{
            //    DataGridViewImageColumn editColumn = new DataGridViewImageColumn
            //    {
            //        HeaderText = "Edit",
            //        Name = "imgEdit",
            //        Image = Properties.Resources.pen_50px, // Replace with your resource image
            //        ImageLayout = DataGridViewImageCellLayout.Zoom // Ensures the image is resized proportionally
            //    };
            //    dataGridView1.Columns.Add(editColumn);
            //}
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
            //int editColumnIndex = dataGridView1.Columns["ImgEdit"].Index;
            int deleteColumnIndex = dataGridView1.Columns["ImgDelete"].Index;

            if (e.RowIndex >= 0) // Ensure it's a valid row
            {
                string studentID = dataGridView1.Rows[e.RowIndex].Cells["Student_ID"].Value.ToString();

                if (e.ColumnIndex == viewColumnIndex)
                {
                    string studentId = dataGridView1.Rows[e.RowIndex].Cells["Student_ID"].Value.ToString();

                    // Now you can create your view_irf form and pass the studentId
                    view_irf fm = new view_irf(studentId);

                    // Optional: Blur the background if needed
                    BlurEffectHelper.BlurBackground(fm);

                }

                else if (e.ColumnIndex == deleteColumnIndex)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Call your static Delete method
                        Delete.DeleteRecord(studentID);
                        LoadDataIntoDataGridView(dataGridView1);
                    }
                }
            }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Make sure it's not the header row
            {
                // Get the data from the clicked row
                var row = dataGridView1.Rows[e.RowIndex];

                // Retrieve values from the clicked row
                string studentID = row.Cells["Student_ID"].Value.ToString();
                string course = row.Cells["Course"].Value.ToString();
                string year = row.Cells["Year"].Value.ToString();
                string firstName = row.Cells["FirstName"].Value.ToString();
                string lastName = row.Cells["LastName"].Value.ToString();
                // Continue fetching the rest of the data as needed...

                // Create a new instance of the form to display the data
                var displayForm = new approve_view(
                    studentID, course, year, firstName, lastName
                // Add any additional fields you want to pass
                );

                // Show the form with the data
                displayForm.Show();
            }
        }
    }
}

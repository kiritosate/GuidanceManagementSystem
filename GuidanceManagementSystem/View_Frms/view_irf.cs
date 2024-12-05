using aaa;
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
using ZstdSharp.Unsafe;

namespace GuidanceManagementSystem.View_Frms
{
    public partial class view_irf : Form
    {
        public view_irf(string studentId)
        {
            InitializeComponent();
            //label1.Text =  studentId;
        }
        private string GetStudentName(string studentId)
        {
            // Your database code to fetch student name using studentId
            // For example:
            string query = "SELECT Name FROM tbl_personal_data WHERE Student_ID = @Student_ID";
            string name = "";

           
                MySqlCommand command = new MySqlCommand(query, MyCon.GetConnection());
                command.Parameters.AddWithValue("@Student_ID", studentId);
                var result = command.ExecuteScalar();
                name = result?.ToString();
            

            return name;
        }
        private void printFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //print
            PrinterHelper ph = new PrinterHelper();

            // Subscribe to the PrintCompleted event to close the form after printing
            ph.PrintCompleted += (s, args) => this.Close();

            // Start the print process
            ph.PrintPanel(tabPage1);
        }

        private void view_irf_Load(object sender, EventArgs e)
        {
            //asyncrounously get data from database and fill the form.
            LoadForms();
            

        }

        private void LoadForms()
        {
            tabPage1.Controls.Clear();

            individual_progress_report irf = new individual_progress_report();

            // Set the form's properties to allow it to be displayed within the panel
            irf.TopLevel = false;       // Makes the form a child control of the panel
            irf.FormBorderStyle = FormBorderStyle.None; // Removes the form's border
            irf.Dock = DockStyle.Fill;  // Fills the panel completely

            // Add the form to the panel's controls and show it
            tabPage1.Controls.Add(irf);
            irf.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

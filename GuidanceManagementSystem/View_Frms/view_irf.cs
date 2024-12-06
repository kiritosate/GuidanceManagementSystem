using aaa;
using GuidanceManagementSystem.methods;
using GuidanceManagementSystem.docsFrm;
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
        public static string student_id { get; set; }
        public static DataSet studentData { get; set; }
        public view_irf(string studentId)
        {
            InitializeComponent();
            student_id = studentId;
            //label1.Text =  studentId;
        }
        private void printFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage activeTab = tabControl1.SelectedTab;

            // Create an instance of PrinterHelper
            PrinterHelper ph = new PrinterHelper();

            // Subscribe to the PrintCompleted event to close the form after printing
            ph.PrintCompleted += (s, args) => this.Close();

            // Print the active tab if it's tabPage1, otherwise print tabPage2
            if (activeTab == tabPage1)
            {
                ph.PrintPanel(tabPage1);
            }
            else
            {
                // If tabPage1 is not active, print tabPage2
                ph.PrintPanel(tabPage2);
            }
        }

        private void view_irf_Load(object sender, EventArgs e)
        {
            //asyncrounously get data from database and fill the form.

            MyFetch fetchData = new MyFetch();
            // Replace with the actual student ID you want to query
            studentData = fetchData.GetStudentData(student_id);

            LoadForms();

            

            // Example: Display data from the first table (tbl_brothers_sisters)
        }

        private void LoadForms()
        {
            tabPage1.Controls.Clear();
            tabPage2.Controls.Clear();

            irfp1 irf = new irfp1(studentData);

            // Set the form's properties to allow it to be displayed within the panel
            irf.TopLevel = false;       // Makes the form a child control of the panel
            irf.FormBorderStyle = FormBorderStyle.None; // Removes the form's border
            irf.Dock = DockStyle.Fill;  // Fills the panel completely

            // Add the form to the panel's controls and show it
            tabPage1.Controls.Add(irf);
            irf.Show();

            irfp2 irf2 = new irfp2(studentData);

            // Set the form's properties to allow it to be displayed within the panel
            irf2.TopLevel = false;       // Makes the form a child control of the panel
            irf2.FormBorderStyle = FormBorderStyle.None; // Removes the form's border
            irf2.Dock = DockStyle.Fill;  // Fills the panel completely

            // Add the form to the panel's controls and show it
            tabPage2.Controls.Add(irf2);
            irf2.Show();
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

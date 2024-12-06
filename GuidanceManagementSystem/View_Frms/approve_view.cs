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
    public partial class approve_view : Form
    {
        public approve_view(string studentID, string course, string year, string firstName, string lastName)
        {
            InitializeComponent();

            // Display the received data in the labels
            lblStudentID.Text = studentID;
            lblCourse.Text = course;
            lblYear.Text = year;
            lblFirstname.Text = firstName;
            lblLastname.Text = lastName;


            enrollment enrollmentForm = new enrollment();

            picapprove.SizeMode = PictureBoxSizeMode.StretchImage;
            // Call the method in enrollmentForm to load the data and picture
            enrollmentForm.LLoadStudentData(studentID,picapprove);
            // Continue setting the other labels or textboxes as needed
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

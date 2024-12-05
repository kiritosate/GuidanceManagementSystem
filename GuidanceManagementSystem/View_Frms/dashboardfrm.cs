using GuidanceManagementSystem.methods;
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
    public partial class dashboardfrm : Form
    {
        public string UserRole { get; set; } // This will be set during login

        public dashboardfrm()
        {
            InitializeComponent();
            //if (UserSession.Role != "Admin")
            //{
            //    MessageBox.Show("Unauthorized access. This form is restricted to Admins only.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close(); // Close the form if the user is not an admin
            //}
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            LoginFrm.closeApp();
        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cuiButton2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ShowFormInPanel(Form form)
        {
            // Clear any existing form in the dockingPnl
            dockingPnl.Controls.Clear();

            // Set the form's properties to allow it to be displayed within the panel
            form.TopLevel = false;       // Makes the form a child control of the panel
            form.FormBorderStyle = FormBorderStyle.None; // Removes the form's border
            form.Dock = DockStyle.Fill;  // Fills the panel completely

            // Add the form to the panel's controls and show it
            dockingPnl.Controls.Add(form);
            form.Show();
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            //dashboard
            ShowFormInPanel(new dashboard_view());


        }


        private void cuiButton4_Click(object sender, EventArgs e)
        {
            //registration
            string studentID = "StudentId"; // Replace with the actual student ID you need
            ShowFormInPanel(new registration_view(studentID));
            
        }
        private void cuiButton5_Click(object sender, EventArgs e)
        {
            //records
            ShowFormInPanel(new recordfrm());
            
        }
        private void cuiButton6_Click(object sender, EventArgs e)
        {
            //reports
            ShowFormInPanel(new reports_view());
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            DateTime currentDateTime = await GetCurrentDateTimeAsync();
            cuiLabel3.Content = currentDateTime.ToString("MMMM dd, yyyy - hh:mm tt");  // Will display: "September 11, 2023 02:30 PM"
        }

        private async Task<DateTime> GetCurrentDateTimeAsync()
        {
            // Simulate async work
            await Task.Delay(1);
            return DateTime.Now; // "September 11, 2023"
        }
        private void dashboardfrm_Load(object sender, EventArgs e)
        {
            ShowFormInPanel(new dashboard_view());
            //cuiLabel1.Content = MyCon._loggedName.ToUpper();
          

        }
        private void cuiButton7_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog
            var result = MessageBox.Show("Are you sure you want to log out?",
                                         "Logout Confirmation",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // Perform the logout logic here
                MessageBox.Show("You have successfully logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Example: Close the current form and show the login form
                this.Hide();
                LoginFrm loginForm = new LoginFrm(); // Replace with your login form's name
                loginForm.Show();
            }
            else
            {
                // If "No" is selected, do nothing
            }
        }
        public static class UserSession
        {
            public static string Role { get; set; } // "Admin" or "Staff"
            public static string Username { get; set; } // Store the logged-in username if needed
        }

        private void cuiButton8_Click(object sender, EventArgs e)
        {
            if (UserSession.Role == "Admin")
            {
                // Open the Super Admin form
                ShowFormInPanel(new Account_view());
                //BlurEffectHelper.BlurBackground(Account_view); // or Show() depending on your preference
            }
            else if (UserSession.Role == "Staff")
            {
                // Show restricted access message
                MessageBox.Show("Access restricted. Only Admins can access the Super Admin panel.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Handle cases where the role is not set (e.g., not logged in)
                MessageBox.Show("Please log in to access this feature.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}

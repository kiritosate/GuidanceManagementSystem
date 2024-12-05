using CuoreUI.Controls;
using GuidanceManagementSystem.methods;
using GuidanceManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static GuidanceManagementSystem.View_Frms.dashboardfrm;

namespace GuidanceManagementSystem.View_Frms
{
    public partial class LoginFrm : Form
    {
       // static LoginFrm _obj;
        public static LoginFrm instance;
        public LoginFrm()
        {
            InitializeComponent();
            instance = this;
        }

        public static void closeApp()
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form mainForm = Application.OpenForms["Loadingfrm"]; // Replace "MainForm" with the actual name of your main form class
                mainForm?.Close();
            }
            
        }
        
        public static void minApp()
        {
            
        }
        public static class BlurEffectHelper
        {
            public static void BlurBackground(Form model)
            {
                Form background = new Form();
                try
                {
                    // Configure background form
                    background.StartPosition = FormStartPosition.CenterScreen;
                    background.FormBorderStyle = FormBorderStyle.None;
                    background.Opacity = 0.6d;
                    background.BackColor = Color.Black;
                    background.Size = model.Size;  // Size of the model form
                    background.WindowState = FormWindowState.Maximized;
                    background.Location = model.Location;  // Position of the model form
                    background.ShowInTaskbar = false;
                    background.Show();

                    // Set the owner of the model to the background form
                    model.Owner = background;

                    // Show the model form as a dialog
                    model.ShowDialog(background);

                    // Dispose the background form after the model form is closed
                    background.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        private void cuiButton1_Click(object sender, EventArgs e)
        {
            closeApp();
        }

        private async void cuiButton2_Click(object sender, EventArgs e)
        {
            cuiSpinner1.Visible = true;
            dashboardfrm frm = new dashboardfrm();

            // Call the login function
            (int UserType, int ID, string Name) loginResult = MyCon._Login(textBox1.Text, textBox2.Text);

            if (loginResult.UserType > 0)
            {
                // Login successful
                MyCon._loggedName = loginResult.Name;
                MyCon._loggedId = loginResult.ID;

                // Set user session information based on the UserType
                UserSession.Role = loginResult.UserType == 1 ? "Admin" : "Staff"; // Assume 1 = Admin, otherwise Staff
                UserSession.Username = loginResult.Name;

                // Pass role information to the dashboard
                frm.UserRole = UserSession.Role; // Pass the role to the dashboard form
                frm.Show();

                this.Hide(); // Hide the login form
            }
            else
            {
                // Login failed
                cuiSpinner1.Visible = false;
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '●')
            {
                textBox2.PasswordChar = '\0'; // Show password by setting PasswordChar to '\0' (no masking character)
                pictureBox1.Image = Properties.Resources.hide_480px;
            }
            else
            {
                textBox2.PasswordChar = '●'; // Hide password by setting PasswordChar back to '●'
                pictureBox1.Image = Properties.Resources.eye_480px;
            }
        }
        
    


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form model = new Form_AboutUs();  // Assuming 'Form_AboutUs' is the model to be blurred
            //BlurEffectHelper.BlurBackground(model);
        }
    }
}

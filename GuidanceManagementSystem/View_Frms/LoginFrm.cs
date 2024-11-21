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

namespace GuidanceManagementSystem.View_Frms
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
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

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            closeApp();
        }

        private async void cuiButton2_Click(object sender, EventArgs e)
        {
            cuiSpinner1.Visible = true;
            dashboardfrm frm = new dashboardfrm();
            await Task.Delay(3000);

            (int UserType, int ID, string Name) loginResult = MyCon._Login(textBox1.Text, textBox2.Text);

            if (loginResult.UserType > 0)
            {
                // If UserType > 0, the login was successful, so show the form
                

                // Optionally, you can use loginResult.ID and loginResult.Name

                MyCon._loggedName = loginResult.Name;
                MyCon._loggedId = loginResult.ID;


                frm.Show();
                this.Hide();

                // Example: Display the user's name in a label (if you have a label for this purpose)
                //frm.userNameLabel.Text = $"Welcome, {loggedInUserName}!";
            }
            else
            {
                // If login fails, display the spinner and show an error message
                cuiSpinner1.Visible = false;
                MessageBox.Show("Invalid username or password.");
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
    }
}

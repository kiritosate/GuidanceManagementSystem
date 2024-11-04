using CuoreUI.Controls;
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
            frm.Show();
            this.Hide();
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            //cuiTextBox22.PasswordChar = '●';
            cuiTextBox22.PasswordChar = true;
        }
    }
}

using GuidanceManagementSystem.View_Frms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuidanceManagementSystem
{
    public partial class Loadingfrm : Form
    {
        public Loadingfrm()
        {
            InitializeComponent();
        }

        private async void Loadingfrm_Load(object sender, EventArgs e)
        {
            LoginFrm frm = new LoginFrm();
            for (int i = 0; i <= 100; i++)
            {
                //cuiCircleProgressBar1.ProgressValue = i;
                progressBar1.Value = i;
                await Task.Delay(25); // Adjust the delay as needed (e.g., 50ms)
            }
            frm.Show();
            this.Hide();


        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cuiCircleProgressBar1_Load(object sender, EventArgs e)
        {

        }
    }
}

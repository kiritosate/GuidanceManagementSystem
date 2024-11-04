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
    public partial class dashboardfrm : Form
    {
        public dashboardfrm()
        {
            InitializeComponent();
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

        private async void ShowFormWithLoadingSpinnerAsync(Form formToLoad)
        {
            // Show the loading spinner GIF
            loadFrm.Visible = true;

            // Load the form asynchronously
            await Task.Run(() =>
            {
                // Simulate form initialization (replace with actual initialization logic if needed)
                
            });

            // Hide the loading spinner after initialization
            loadFrm.Visible = false;

            // Show the form inside the panel
            ShowFormInPanel(formToLoad);
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
            ShowFormWithLoadingSpinnerAsync(new dashboard_view());


        }

        private void cuiButton4_Click(object sender, EventArgs e)
        {
            //registration
        }

        private void cuiButton5_Click(object sender, EventArgs e)
        {
            //records
        }

        private void cuiButton6_Click(object sender, EventArgs e)
        {
            //reports
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}

﻿using GuidanceManagementSystem.methods;
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
            ShowFormInPanel(new registration_view());
        }

        private void cuiButton5_Click(object sender, EventArgs e)
        {
            //records
        }

        private void cuiButton6_Click(object sender, EventArgs e)
        {
            //reports
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
            cuiLabel1.Content = MyCon._loggedName.ToUpper();


        }

        private void cuiButton7_Click(object sender, EventArgs e)
        {
            
            LoginFrm.closeApp();
             
        }
    }
}

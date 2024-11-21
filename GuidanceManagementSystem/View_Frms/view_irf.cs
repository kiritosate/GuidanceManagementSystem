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
using ZstdSharp.Unsafe;

namespace GuidanceManagementSystem.View_Frms
{
    public partial class view_irf : Form
    {
        public view_irf()
        {
            InitializeComponent();
        }

        private void printFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //print
            PrinterHelper ph = new PrinterHelper();

            // Subscribe to the PrintCompleted event to close the form after printing
            ph.PrintCompleted += (s, args) => this.Close();

            // Start the print process
            ph.PrintPanel(panel2);
        }

        private void view_irf_Load(object sender, EventArgs e)
        {
            //asyncrounously get data from database and fill the form.
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

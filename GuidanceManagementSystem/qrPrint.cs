using GuidanceManagementSystem.methods;
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
    public partial class qrPrint : Form
    {
        
        
        public qrPrint()
        {
            InitializeComponent();
        }

        private void qrPrint_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = webserver_view._qrCodeBitmap;
            cuiLabel2.Content = webserver_view._ipAddress;

            PrinterHelper ph = new PrinterHelper();

            // Subscribe to the PrintCompleted event to close the form after printing
            ph.PrintCompleted += (s, args) => this.Close();

            // Start the print process
            ph.PrintPanel(panel1);
        }
    }
}

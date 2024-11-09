using GuidanceManagementSystem.methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuidanceManagementSystem.View_Frms
{
    public partial class webserver_view : Form
    {
        public static bool _serverUp { get; set; }
        public static string _ipAddress { get; set; }
        public static Bitmap _qrCodeBitmap { get; set; }

        private MyMethods apacheServer;

        public webserver_view()
        {
            InitializeComponent();
            apacheServer = new MyMethods();
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void cuiButton2_Click(object sender, EventArgs e)
        {
            cuiButton2.Enabled = false; // Disable button to prevent multiple clicks
            if (_serverUp)
            {
                await StopApacheServer();
            }
            else
            {
                await StartApacheServer();
            }
            cuiButton2.Enabled = true; // Re-enable button after completion
        }

        private async Task StartApacheServer()
        {
            try
            {
                _serverUp = await apacheServer.StartApacheFromBinaryAsync();
                if (_serverUp)
                {
                    _ipAddress = $"http://{await apacheServer.GetLocalIPAddressAsync()}:1111";
                    _qrCodeBitmap = await apacheServer.GenerateQRCodeAsync(_ipAddress);
                    pictureBox1.Image = _qrCodeBitmap;
                    linkLabel1.Text = _ipAddress;

                    MessageBox.Show("Apache server started and QR code generated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to start Apache server.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async Task StopApacheServer()
        {
            bool stoppedSuccessfully = await apacheServer.StopApacheAsync();
            if (stoppedSuccessfully)
            {
                _serverUp = false;
                pictureBox1.Image = null;
                linkLabel1.Text = "Server stopped";
                MessageBox.Show("Apache server stopped successfully.");
            }
            else
            {
                MessageBox.Show("Failed to stop Apache server.");
            }
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            qrPrint p = new qrPrint();
            p.ShowDialog();
        }

        private async void webserver_view_Load(object sender, EventArgs e)
        {
            _serverUp = apacheServer.IsApacheRunning();
            //MessageBox.Show(_serverUp.ToString());
            if (_serverUp)
            {
                _ipAddress = $"http://{await apacheServer.GetLocalIPAddressAsync()}:1111";
                _qrCodeBitmap = await apacheServer.GenerateQRCodeAsync(_ipAddress);
                pictureBox1.Image = _qrCodeBitmap;
                linkLabel1.Text = _ipAddress;
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cuiButton2.Content = _serverUp ? "Stop Server" : "Start Server";
            cuiButton2.NormalBackground = _serverUp ? Color.Crimson : Color.Green;
            cuiButton3.Enabled = _serverUp;
            if (_serverUp)
            {
                pictureBox1.Image = _qrCodeBitmap;
                linkLabel1.Text = _ipAddress;
            }
            else
            {
                pictureBox1.Image = null;
                linkLabel1.Text = "Server not running";
            }
        }
    }

}

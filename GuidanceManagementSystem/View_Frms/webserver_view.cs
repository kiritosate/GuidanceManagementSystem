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
        public webserver_view()
        {
            InitializeComponent();
        }
        
        public static bool _serverUp { get; set; }
        public static string _ipAddress { get; set; }
        public static Bitmap _qrCodeBitmap { get; set; }
        private void cuiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void cuiButton2_Click(object sender, EventArgs e)
        {
            //bool apacheStarted = false; // Declare a variable to store the result
            if (_serverUp)
            {
                MyMethods apacheServer = new MyMethods();
                bool stoppedSuccessfully = await apacheServer.StopApacheAsync();

                if (stoppedSuccessfully)
                {
                    _serverUp = false; // Update the server status
                    MessageBox.Show("Apache server stopped successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to stop Apache server.");
                }

                cuiButton2.Content = "Start Server";
                cuiButton2.NormalBackground = Color.Green;
            }
            else
            {
                try
                {
                    // Call the async method when the button is clicked
                    MyMethods apacheServer = new MyMethods();

                    // Capture the result of the Apache server start
                    _serverUp = await apacheServer.StartApacheFromBinaryAsync();

                    // Get the generated QR code as Bitmap
                    string ipAddress = await apacheServer.GetLocalIPAddressAsync();
                    _ipAddress = $"http://{ipAddress}:1111";
                    Bitmap qrCodeBitmap = await apacheServer.GenerateQRCodeAsync(_ipAddress);
                    _qrCodeBitmap = qrCodeBitmap;
                    MessageBox.Show(_ipAddress);
                    MessageBox.Show(_qrCodeBitmap.ToString());
                    if (qrCodeBitmap != null)
                    {
                        
                        // Set the generated QR code as the Image in the PictureBox
                        pictureBox1.Image = qrCodeBitmap;
                        linkLabel1.Text = $"http://{ipAddress}:1111";
                    }

                    // Show a message based on whether the Apache server started successfully
                    if (_serverUp)
                    {
                        MessageBox.Show("Apache server started and barcode generated successfully.");
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
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            qrPrint p = new qrPrint();
            p.ShowDialog();

        }

        private void webserver_view_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_serverUp)
            {
                pictureBox1.Image = _qrCodeBitmap;
                linkLabel1.Text = "";
                linkLabel1.Text = $"http://{_ipAddress}:1111";

                cuiButton2.Content = "Stop Server";
                cuiButton2.NormalBackground = Color.Crimson;

                cuiButton3.Enabled = true;
            }
            else
            {
                cuiButton2.Content = "Start Server";
                cuiButton2.NormalBackground = Color.Green;

                cuiButton3.Enabled = false;
            }
        }
    }
}

using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace GuidanceManagementSystem.methods
{
    internal class MyMethods
    {
        public async Task<bool> StartApacheFromBinaryAsync()
        {
            try
            {
                // Path to Apache binary (make sure the path is correct)
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string apachePath = "C:/Apache";//Path.Combine(appDirectory, "Apache", "bin", "httpd.exe");

                // Create a ProcessStartInfo to hide the command window
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = apachePath,
                    WindowStyle = ProcessWindowStyle.Hidden, // This will hide the window
                    CreateNoWindow = true // Ensure no window is created
                };

                // Start Apache using the ProcessStartInfo
                await Task.Run(() => Process.Start(startInfo));

                Console.WriteLine("Apache server started without showing CMD.");
                return true; // Return true indicating success
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // Return false if an exception occurs
            }
        }


        public async Task<string> GetLocalIPAddressAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    // Get all network interfaces on the local machine
                    var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                    // Loop through all the network interfaces to find a wireless (Wi-Fi) interface
                    foreach (var networkInterface in networkInterfaces)
                    {
                        // Check if the network interface is wireless (Wi-Fi)
                        if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                            networkInterface.OperationalStatus == OperationalStatus.Up) // Ensure the interface is up
                        {
                            // Get the IP properties of the wireless interface
                            var ipProperties = networkInterface.GetIPProperties();
                            var ipv4Address = ipProperties.UnicastAddresses
                                .FirstOrDefault(ip => ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.Address.ToString();

                            if (ipv4Address != null)
                            {
                                return ipv4Address; // Return the IPv4 address of the Wi-Fi interface
                            }
                        }
                    }


                    return "Wi-Fi IP Address not found";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error getting Wi-Fi IP address: {ex.Message}");
                    return "Error";
                }
            });
        }

        public async Task<bool> StopApacheAsync()
        {
            try
            {
                // Find the Apache process and stop it
                var processes = Process.GetProcessesByName("httpd");

                if (processes.Length > 0)
                {
                    // Kill the Apache process
                    foreach (var process in processes)
                    {
                        process.Kill();
                    }
                    return true; // Return true when successfully stopped
                }
                else
                {
                    return false; // Apache process not found
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error stopping Apache: {ex.Message}");
                return false;
            }
        }


        public async Task<Bitmap> GenerateQRCodeAsync(string data)
        {
            return await Task.Run(() =>
            {
                try
                {
                    // Create a BarcodeWriter instance for QR code
                    BarcodeWriter barcodeWriter = new BarcodeWriter
                    {
                        Format = BarcodeFormat.QR_CODE, // QR_CODE format for generating QR codes
                        Options = new ZXing.Common.EncodingOptions
                        {
                            Height = 200,  // QR code height
                            Width = 200    // QR code width
                        }
                    };

                    // Generate the QR code from the provided data
                    Bitmap qrCodeBitmap = barcodeWriter.Write(data);

                    // Ensure the QR code was generated successfully
                    if (qrCodeBitmap == null)
                    {
                        throw new Exception("Failed to generate QR code.");
                    }

                    // Return the Bitmap for later access (no saving to file)
                    return qrCodeBitmap;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error generating QR code: {ex.Message}");
                    return null; // Return null if an error occurs
                }
            });
        }
        
    }
}

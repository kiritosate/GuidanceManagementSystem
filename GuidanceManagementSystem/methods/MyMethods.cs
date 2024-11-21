﻿using GuidanceManagementSystem.docsFrm;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
                string apachePath = "C:/Apache/bin/httpd.exe";//Path.Combine(appDirectory, "Apache", "bin", "httpd.exe");

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

        public static void txtInput_TextChanged_Letters(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Initialize an empty string to hold the valid text
            string filteredText = string.Empty;

            foreach (char c in textBox.Text)
            {
                if (char.IsLetter(c) || char.IsWhiteSpace(c)) // Allow letters and spaces
                {
                    filteredText += c;
                }
            }

            // Only update the text if it's different from the filtered text
            if (textBox.Text != filteredText)
            {
                int cursorPosition = textBox.SelectionStart; // Save cursor position

                // Set the filtered text and restore the cursor position
                textBox.Text = filteredText;
                textBox.SelectionStart = Math.Min(cursorPosition, filteredText.Length); // Prevent cursor jumping to the end
            }
        }

        // Filters only digits
        public static void txtInput_TextChanged_Numbers(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Initialize an empty string to hold the valid text
            string filteredText = string.Empty;

            foreach (char c in textBox.Text)
            {
                if (char.IsDigit(c)) // Allow only digits
                {
                    filteredText += c;
                }
            }

            // Only update the text if it's different from the filtered text
            if (textBox.Text != filteredText)
            {
                int cursorPosition = textBox.SelectionStart; // Save cursor position

                // Set the filtered text and restore the cursor position
                textBox.Text = filteredText;
                textBox.SelectionStart = Math.Min(cursorPosition, filteredText.Length); // Prevent cursor jumping to the end
            }
        }

        // Method to attach the TextChanged event handler to multiple TextBoxes
        public static void AttachTextChangedEventHandlers(EventHandler handler, params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.TextChanged += handler;
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

        public bool IsApacheRunning()
        {
            try
            {
                // Check if there are any processes with the name "httpd"
                var processes = Process.GetProcessesByName("httpd");

                // If any "httpd" process is found, Apache is running
                return processes.Length > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking Apache status: {ex.Message}");
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
        public static int sql(string qry, Hashtable ht)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;database=guidancedb;port=3306;username=root;password=;");

            int res = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                    //cmd.Parameters.AddWithValue(item.Key.ToString(), item.Key);
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                res = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }

            return res;
        }

        public static class Delete
        {
            public static void DeleteRecord(string studentID)
            {
                string connectionString = "server=localhost;database=guidancedb;user=root;password=;";
                string query = "DELETE FROM tbl_individual_record WHERE Student_ID = @StudentID";

                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@StudentID", studentID);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully.");
                            }
                            else
                            {
                                MessageBox.Show("No record found to delete.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting record: {ex.Message}");
                }
            }
        }


    }
}

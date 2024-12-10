using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuidanceManagementSystem.methods
{
    internal class InputValidator
    {
        // Function to handle only letter inputs
        public static void OnKeyPress_LettersOnly(object sender, KeyPressEventArgs e)
        {
            // Allow only letters (A-Z, a-z) and control keys (backspace, etc.)
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Cancel the input if it's not a letter or control key
            }
        }

        // Function to handle only numeric inputs
        public static void OnKeyPress_NumbersOnly(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers (0-9) and control keys (backspace, etc.)
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Cancel the input if it's not a digit or control key
            }
        }

        // Function to validate email format
        public static bool ValidateEmail(string input)
        {
            // Simple regex for basic email format validation
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(input);
        }

        // Function to handle email input validation in real-time as user types
        public static void OnKeyPress_EmailValidation(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;

            // Allow control keys (e.g., backspace) and valid email characters
            if (!char.IsControl(keyChar) &&
                !char.IsLetterOrDigit(keyChar) &&
                keyChar != '@' &&
                keyChar != '.' &&
                keyChar != '-' &&
                keyChar != '_')
            {
                e.Handled = true; // Reject invalid characters
            }
        }

        public static void OnKeyPress_FormatIdNumber(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Allow control keys (like backspace)
                if (Char.IsControl(e.KeyChar)) return;

                // Allow only digits
                if (!Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }

                // Get the current input text
                string currentText = textBox.Text.Replace("-", ""); // Remove hyphen for formatting
                currentText += e.KeyChar.ToString(); // Add the new character

                // Limit the length of the text to 7 digits (excluding the hyphen)
                if (currentText.Length > 7)
                {
                    e.Handled = true;  // Prevent input if more than 7 digits
                    return;
                }

                // Format the input into 00-00000
                StringBuilder formattedText = new StringBuilder();
                if (currentText.Length > 2)
                {
                    // Add the first two digits
                    formattedText.Append(currentText.Substring(0, 2));
                    formattedText.Append('-'); // Add the hyphen
                                               // Add the remaining five digits
                    formattedText.Append(currentText.Substring(2));
                }
                else
                {
                    // If less than two digits, just display the digits
                    formattedText.Append(currentText);
                }

                // Set the formatted text back into the TextBox
                textBox.Text = formattedText.ToString();
                textBox.SelectionStart = textBox.Text.Length; // Move the cursor to the end
                e.Handled = true; // Block the default input since we've handled it
            }
        }
    }

}

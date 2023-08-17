using Bunifu.UI.WinForms.BunifuTextbox;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MuseeApps
{
    internal static class UtilsFunction
    {
        private static readonly string[] ValidPrefixes = { "77", "78", "76", "75", "72", "70" };

        public static string Encrypt(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }


        public static string Decrypt(string text)
        {
            byte[] bytes = Convert.FromBase64String(text);
            return Encoding.UTF8.GetString(bytes);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length != 9) return false;

            var prefix = phoneNumber.Substring(0, 2);
            return IsValidPhoneNumberDigit(phoneNumber) && ValidPrefixes.Contains(prefix);
        }

        private static bool IsValidPhoneNumberDigit(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^[0-9]{9}$", RegexOptions.IgnoreCase);
        }

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", RegexOptions.IgnoreCase);
        }
        
        public static bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z0-9 ]{2,}$", RegexOptions.IgnoreCase);
        }

        public static void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccessMessageBox(string message)
        {
            MessageBox.Show(message, "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool TestFields(params string[] fields)
        {
            foreach (string field in fields)
            {
                if (string.IsNullOrWhiteSpace(field) || field.Length < 2)
                {
                    return true; // Au moins un champ est vide
                }
            }
            return false; // Tous les champs sont remplis
        }

        public static void ClearFormFields(params BunifuTextBox[] textFields)
        {
            foreach (BunifuTextBox textField in textFields)
            {
                textField.Text = "";
            }
        }

        public static bool ConfirmPassword(string password, string confirmPassword)
        {
            if (password == null || confirmPassword == null)
            {
                return false;
            }
            return !password.Equals(confirmPassword);
        }

        public static bool ValidatePassword(string password)
        {
            if (password == null || password.Length < 8)
            {
                return false;
            }

            bool hasLowercase = false;
            bool hasUppercase = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsLower(c))
                {
                    hasLowercase = true;
                }
                else if (char.IsUpper(c))
                {
                    hasUppercase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }

                if (hasLowercase && hasUppercase && hasDigit)
                {
                    return true;
                }
            }

            return false;
        }




        public static bool IsFieldEmpty(string field) => string.IsNullOrWhiteSpace(field);

    }
}

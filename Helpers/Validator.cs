using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IntegratedUniversityInformationSystem.Helpers
{
    public static class Validator
    {
        public static bool IsValidId(string input, out int id)
        {
            return int.TryParse(input, out id) && id > 0;
        }

        public static bool IsValidName(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.Length >= 2;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidAge(int age)
        {
            return age >= 0 && age <= 120;
        }

        public static bool IsValidDate(DateTime date)
        {
            return date <= DateTime.Now && date >= new DateTime(1900, 1, 1);
        }

        public static bool IsValidContactNumber(string contact)
        {
            return Regex.IsMatch(contact, @"^(\+63|0)\d{10}$");
        }

        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }
    }
}

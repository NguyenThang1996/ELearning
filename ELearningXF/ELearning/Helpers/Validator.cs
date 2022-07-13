using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ELearning.Helpers
{
    public static class Validator
    {
        public const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

        public static bool IsValidPhone(string number)
        {
            if (number != null) return Regex.IsMatch(number, motif);
            else return false;
        }
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsValidSpecialCharacter(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«£§€{}-;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
        public static string IsValidStringNullOrEmty(string name, string address, string tel, string email)
        {
            string str = string.Empty;
            if (String.IsNullOrEmpty(name))
            {
                str += "Tên nhân viên ";
            }
            if (String.IsNullOrEmpty(address))
            {
                str += "Địa chỉ ";
            }
            if (String.IsNullOrEmpty(tel))
            {
                str += "Số điện thoại ";
            }
            if (String.IsNullOrEmpty(email))
            {
                str += "Email ";
            }
            return str += "không được để trống";
        }
    }
}

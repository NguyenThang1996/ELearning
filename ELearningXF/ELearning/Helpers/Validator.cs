using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ELearning.Helpers
{
    /// <summary>
    ///     Validator
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public static class Validator
    {
        #region Define các hàm validate form
        public const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

        /// <summary>Check valid số điện thoại</summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if [is valid phone] [the specified number]; otherwise, <c>false</c>.</returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public static bool IsValidPhone(string number)
        {
            if (number != null) return Regex.IsMatch(number, motif);
            else return false;
        }

        /// <summary>Check valid email</summary>
        /// <param name="email">The email.</param>
        /// <returns>
        ///   <c>true</c> if [is valid email] [the specified email]; otherwise, <c>false</c>.</returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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

        /// <summary>Check valid các ký tự đặc biệt</summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if [is valid special character] [the specified input]; otherwise, <c>false</c>.</returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public static bool IsValidSpecialCharacter(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«£§€{}-;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        /// <summary>Check null tên, địa chỉ, sdt, email</summary>
        /// <param name="name">The name.</param>
        /// <param name="address">The address.</param>
        /// <param name="tel">The tel.</param>
        /// <param name="email">The email.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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
        #endregion
    }
}

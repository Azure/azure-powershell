using System;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Utils
{
    public class PasswordUtility
    {
        private static readonly int PasswordMinLength = 8;
        private static readonly int PasswordMaxLength = 15;

        private const string OneCapital = @"^.*(?=[A-Z]+).*$";
        private const string OneNumber = @"^.*(?=[0-9]+).*$";

        public static string UnAllowedChars { get; } = @"[^a-zA-Z0-9@#\-$%^!+=;:_()]";
        private const string AllowedSymbolsString = "[`@`,`#`,`-`,`$`,`%`,`^`,`!`,`+`,`=`,`;`,`:`,`_`,`(`,`)`]";

        private static readonly Regex OneCapitalRegex = new Regex(
            OneCapital, RegexOptions.Singleline
        );
        private static readonly Regex OneNumberRegex = new Regex(
            OneNumber, RegexOptions.Singleline
        );

        private static readonly Regex UnAllowedCharsRegex = new Regex(UnAllowedChars,
            RegexOptions.Singleline);



        /// <summary>
        /// Validates password strength with set of rules for password provided by user
        /// </summary>
        /// <param name="argumentName"></param>
        /// <param name="password">Password provided by user</param>
        /// <returns>true if valid pattern is provided.</returns>
        public static bool ValidateUserPasswordPattern(string argumentName, string password)
        {
            string error = null;
            if (string.IsNullOrEmpty(password))
            {
                error = "Password cannot be empty";
            }
            else if (password.Length < PasswordMinLength)
            {
                error = "Minimum length of the password can not be less than " + PasswordMinLength + " chars";
            }
            else if (password.Length > PasswordMaxLength)
            {
                error = "Maximum length of the password can not be greater than " + PasswordMaxLength + " chars";
            }
            else if (!(OneNumberRegex.IsMatch(password) && OneCapitalRegex.IsMatch(password)))
            {
                error = "Should Contain at least 1 uppercase and 1 number";
            }
            else if (UnAllowedCharsRegex.IsMatch(password))
            {
                error = "Should not contain characters outside of the set [a-z, A-Z, 0-9] and symbols" + AllowedSymbolsString;
            }

            if (string.IsNullOrEmpty(error))
            {
                return true;
            }
            else
            {
                throw new PSArgumentException(error, argumentName);
            }
        }
    }
}
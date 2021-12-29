using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Compute.Common
{
    public static class ValidateBase64EncodedString
    {
        public const string UserDataEncodeNotification = "The provided UserData parameter value was not Base64 encoded. The cmdlet has automatically changed your value by Base64 encoding it.";
        public static bool ValidateStringIsBase64Encoded(string encodedString)
        {
            if (!string.IsNullOrEmpty(encodedString) &&
                (encodedString.Contains(" ") ||
                encodedString.Length % 4 != 0 ||
                encodedString.Contains("\t") ||
                encodedString.Contains("\r") ||
                encodedString.Contains("\n")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string EncodeStringToBase64(string toBeEncoded)
        {
            var bytesToEncode = System.Text.Encoding.Unicode.GetBytes(toBeEncoded);
            string encodedString = System.Convert.ToBase64String(bytesToEncode);

            return encodedString;
        }
    }
}

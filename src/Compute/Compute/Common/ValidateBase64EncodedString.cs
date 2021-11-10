using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Common
{
    public static class ValidateBase64EncodedString
    {
        public static bool validateStringIsBase64Encoded(string encodedString)
        {
            if (String.IsNullOrEmpty(encodedString) ||
                    encodedString.Contains(" ") ||
                    encodedString.Length % 4 != 0 ||
                    encodedString.Contains("\t") ||
                    encodedString.Contains("\r") ||
                    encodedString.Contains("\n"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string encodeStringToBase64(string toBeEncoded)
        {
            var bytesToEncode = System.Text.ASCIIEncoding.ASCII.GetBytes(toBeEncoded);
            string encodedString = System.Convert.ToBase64String(bytesToEncode);

            return encodedString;
        }
    }
}

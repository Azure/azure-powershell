using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Microsoft.Azure.Commands.KeyVault
{
    internal static class UtilityExtensions
    {
        public static string ToPlainText(this SecureString secureString)
        {
            IntPtr bstr = Marshal.SecureStringToBSTR(secureString);

            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }
        }
    }
}

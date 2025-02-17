using System.Runtime.InteropServices;
using System.Security;
using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models
{
    public static class Utils
    {
		public static System.Security.SecureString ToSecureString(this string input)
		{
		  if (string.IsNullOrEmpty(input))
		    return null;

		  System.Security.SecureString secureString = new System.Security.SecureString();
		  foreach (char c in input)
		  {
		    secureString.AppendChar(c);
		  }
		  secureString.MakeReadOnly();
		  return secureString;
		}

        public static string ConvertToString(this SecureString secureString)
        {
            if (secureString == null)
            {
                return null;
            }

            IntPtr unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                if (unmanagedString != IntPtr.Zero)
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
            }
        }
    }

}
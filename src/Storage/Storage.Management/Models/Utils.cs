namespace Microsoft.Azure.Commands.Management.Storage.Models
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
    }
}
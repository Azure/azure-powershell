using System.Security.Cryptography;
using System.IO;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common
{
    internal static class IOStreamExtensions
    {
        public static void Write(this MemoryStream stream, byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
        }
        
        public static void Write(this CryptoStream stream, byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}

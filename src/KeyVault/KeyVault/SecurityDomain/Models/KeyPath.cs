using System.Security;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    public class KeyPath
    {
        public string PublicKey;
        public string PrivateKey;
        public SecureString Password;
    }
}

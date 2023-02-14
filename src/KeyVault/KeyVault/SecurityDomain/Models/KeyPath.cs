using System.Security;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    public class KeyPath
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public SecureString Password { get; set; }
    }
}

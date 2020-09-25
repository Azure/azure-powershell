using System.Security;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    public class KeyPath
    {
        public string PublicKey { get; }
        public string PrivateKey { get; }
        public SecureString Password { get; }
    }
}

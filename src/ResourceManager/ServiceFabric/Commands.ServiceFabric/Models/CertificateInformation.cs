
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Management.KeyVault.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    internal class CertificateInformation
    {
        internal Vault KeyVault { get; set; }

        internal string SecretUrl { get; set; }

        internal string Thumbprint { get; set; }
    }
}
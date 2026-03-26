using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Models
{
    public class PSCustomCertificateResource : PSResource
    {
        public string KeyVaultBaseUri { get; }
        public string KeyVaultSecretName { get; }
        public string KeyVaultSecretVersion { get; }
        public string ProvisioningState { get; }

        public PSCustomCertificateResource(CustomCertificate cert)
            : base(cert)
        {
            KeyVaultBaseUri = cert.KeyVaultBaseUri;
            KeyVaultSecretName = cert.KeyVaultSecretName;
            KeyVaultSecretVersion = cert.KeyVaultSecretVersion;
            ProvisioningState = cert.ProvisioningState;
        }
    }
}

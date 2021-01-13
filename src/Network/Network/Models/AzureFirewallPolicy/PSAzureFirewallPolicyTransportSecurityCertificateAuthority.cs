using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSAzureFirewallPolicyTransportSecurityCertificateAuthority
    {
        public string Name { get; set; }

        public string KeyVaultSecretId { get; set; }
    }
}

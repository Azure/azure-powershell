using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSSecretValueReference
    {
        public PSKeyVaultReference KeyVault { get; set; }
        public string SecretName { get; set; }
        public string SecretVersion { get; set; }
    }
}

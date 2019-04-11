using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSSecretValueReference
    {
        public PSKeyVaultReference KeyVault { get; private set; }
        public string SecretName { get; private set; }
        public string SecretVersion { get; private set; }

        public PSSecretValueReference(PSKeyVaultReference keyVault, string secretName, string secretVersion = default(string))
        {
            KeyVault = keyVault;
            SecretName = secretName;
            SecretVersion = secretVersion;
        }
    }
}

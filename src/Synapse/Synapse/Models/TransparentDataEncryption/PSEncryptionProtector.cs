using Microsoft.Azure.Management.Synapse.Models;
using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public enum EncryptionProtectorType
    {
        AzureKeyVault,
        ServiceManaged
    };

    public class PSEncryptionProtector
    {
        public PSEncryptionProtector(EncryptionProtector protector, string resourceGroupName, string workspaceName)
        {
            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            this.ServerKeyVaultKeyName = protector.ServerKeyName;
            EncryptionProtectorType type = EncryptionProtectorType.ServiceManaged;
            Enum.TryParse<EncryptionProtectorType>(protector.ServerKeyType, true, out type);
            this.Type = type;
            if (type == EncryptionProtectorType.AzureKeyVault)
            {
                this.KeyId = protector.Uri;
            }
        }

        public string ResourceGroupName { get; set; }

        public string WorkspaceName { get; set; }

        public EncryptionProtectorType Type { get; set; }

        public string ServerKeyVaultKeyName { get; set; }

        public string KeyId { get; set; }
    }
}

using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSWorkspaceKeyDetails
    {
        public PSWorkspaceKeyDetails(WorkspaceKeyDetails key)
        {
            this.Name = key?.Name;
            this.KeyVaultUrl = key?.KeyVaultUrl;
        }

        /// <summary>
        /// Gets or sets workspace Key sub-resource name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets workspace Key sub-resource key vault url
        /// </summary>
        public string KeyVaultUrl { get; set; }
    }
}
using Microsoft.Azure.Management.KeyVault.Models;


namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSMHSMGeoReplicatedRegion
    {
        public PSMHSMGeoReplicatedRegion()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PSMHSMGeoReplicatedRegion class.
        /// </summary>

        /// <param name="name">Name of the geo replicated region.
        /// </param>

        /// <param name="provisioningState">Provisioning state of the geo replicated region.
        /// Possible values include: 'Preprovisioning', 'Provisioning', 'Succeeded',
        /// 'Failed', 'Deleting', 'Cleanup'</param>

        /// <param name="isPrimary">A boolean value that indicates whether the region is the primary region or
        /// a secondary region.
        /// </param>
        public PSMHSMGeoReplicatedRegion(string name = default(string), string provisioningState = default(string), bool? isPrimary = default(bool?))

        {
            this.Name = name;
            this.ProvisioningState = provisioningState;
            this.IsPrimary = isPrimary;
        }

        internal PSMHSMGeoReplicatedRegion(MhsmGeoReplicatedRegion region)
        {
            this.Name = region?.Name;
            this.IsPrimary = region?.IsPrimary;
            this.ProvisioningState = region?.ProvisioningState;
        }

        /// <summary>
        /// Gets or sets name of the geo replicated region.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets provisioning state of the geo replicated region. Possible values include: &#39;Preprovisioning&#39;, &#39;Provisioning&#39;, &#39;Succeeded&#39;, &#39;Failed&#39;, &#39;Deleting&#39;, &#39;Cleanup&#39;
        /// </summary>
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets a boolean value that indicates whether the region is the
        /// primary region or a secondary region.
        /// </summary>
        public bool? IsPrimary { get; set; }

        public override string ToString()
        {
            return string.Format("Name = {0}, IsPrimary = {1}, ProvisioningState = {2}", Name, IsPrimary, ProvisioningState);
        }
    }
}

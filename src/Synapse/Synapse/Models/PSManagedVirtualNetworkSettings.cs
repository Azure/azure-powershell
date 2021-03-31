using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    /// <summary>
    /// Managed Virtual Network Settings
    /// </summary>
    public class PSManagedVirtualNetworkSettings
    {
        public PSManagedVirtualNetworkSettings(ManagedVirtualNetworkSettings settings)
        {
            this.PreventDataExfiltration = settings?.PreventDataExfiltration;
            this.LinkedAccessCheckOnTargetResource = settings.LinkedAccessCheckOnTargetResource;
            this.AllowedAadTenantIdsForLinking = settings?.AllowedAadTenantIdsForLinking;
        }

        /// <summary>
        /// Gets or sets prevent Data Exfiltration
        /// </summary>
        public bool? PreventDataExfiltration { get; set; }

        /// <summary>
        /// Gets or sets linked Access Check On Target Resource
        /// </summary>
        public bool? LinkedAccessCheckOnTargetResource { get; set; }

        /// <summary>
        /// Gets or sets allowed Aad Tenant Ids For Linking
        /// </summary>
        public IList<string> AllowedAadTenantIdsForLinking { get; set; }

        public ManagedVirtualNetworkSettings ToSdkObject()
        {
            return new ManagedVirtualNetworkSettings
            {
                PreventDataExfiltration = this.PreventDataExfiltration,
                AllowedAadTenantIdsForLinking = this.AllowedAadTenantIdsForLinking,
                LinkedAccessCheckOnTargetResource = this.LinkedAccessCheckOnTargetResource
            };
        }
    }
}

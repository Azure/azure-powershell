using Microsoft.Azure.Management.KeyVault.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSManagedServiceIdentity
    {
        public PSManagedServiceIdentity() { }

        public PSManagedServiceIdentity(ManagedServiceIdentity identity) {

            this.PrincipalId = identity?.PrincipalId?.ToString();
            this.TenantId = identity?.TenantId?.ToString();
            this.Type = identity?.Type?.ToString();
            this.UserAssignedIdentities = identity?.UserAssignedIdentities?.Keys?.ToArray();
        }

        /// <summary>
        /// Gets the service principal ID of the system assigned identity. This
        /// property will only be provided for a system assigned identity.
        /// </summary>
        public string PrincipalId { get; private set; }

        /// <summary>
        /// Gets the tenant ID of the system assigned identity. This property will only
        /// be provided for a system assigned identity.
        /// </summary>
        public string TenantId { get; private set; }

        /// <summary>
        /// Gets or sets type of managed service identity (where both SystemAssigned
        /// and UserAssigned types are allowed). Possible values include: &#39;None&#39;, &#39;SystemAssigned&#39;, &#39;UserAssigned&#39;, &#39;SystemAssigned,UserAssigned&#39;
        /// </summary>

        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the set of user assigned identities associated with the
        /// resource. 
        /// </summary>
        public string[] UserAssignedIdentities { get; set; }
    }
}

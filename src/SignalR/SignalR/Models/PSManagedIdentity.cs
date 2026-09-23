using Microsoft.Azure.Management.SignalR.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SignalR.Models
{
    public class PSManagedIdentity
    {
        public string Type { get; }
        public IDictionary<string, PSUserAssignedIdentityProperty> UserAssignedIdentities { get; }
        public string PrincipalId { get; }
        public string TenantId { get; }

        public PSManagedIdentity(ManagedIdentity identity)
        {
            Type = identity.Type;
            PrincipalId = identity.PrincipalId;
            TenantId = identity.TenantId;
            if (identity.UserAssignedIdentities != null)
            {
                UserAssignedIdentities = new Dictionary<string, PSUserAssignedIdentityProperty>();
                foreach (var kvp in identity.UserAssignedIdentities)
                {
                    UserAssignedIdentities[kvp.Key] = new PSUserAssignedIdentityProperty(kvp.Value);
                }
            }
        }
    }
}
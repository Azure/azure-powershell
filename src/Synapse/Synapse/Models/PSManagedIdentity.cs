using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSManagedIdentity
    {
        public string IdentityType { get; set; }

        public string PrincipalId { get; set; }

        public string TenantId { get; set; }

        public PSManagedIdentity(ManagedIdentity identity)
        {
            this.IdentityType = identity?.Type?.ToString();
            this.PrincipalId = identity?.PrincipalId;
            this.TenantId = identity?.TenantId.ToString();
        }
    }
}
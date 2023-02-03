namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    using System.Linq;
    using Newtonsoft.Json.Linq;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using System.Collections.Generic;

    /// <summary>
    /// The policy assignment properties.
    /// </summary>
    public class PsPolicyIdentity
    {
        public PsPolicyIdentity(JToken input)
        {
            var identity = input?.ToObject<ResourceIdentity>(JsonExtensions.JsonMediaTypeSerializer);
            IdentityType = identity.Type;
            PrincipalId = identity.PrincipalId;
            TenantId = identity.TenantId;

            var userAssignedIdentityId = identity.UserAssignedIdentities?.Take(1).Select(d => d.Key).FirstOrDefault();

            UserAssignedIdentities = userAssignedIdentityId != null ? 
                new Dictionary<string, PsUserAssignedIdentity>
                {
                    { userAssignedIdentityId, new PsUserAssignedIdentity(identity.UserAssignedIdentities[userAssignedIdentityId].ToJToken()) }
                } :null;
        }

        public string PrincipalId { get; set; }
        public string TenantId { get; set; }
        public string IdentityType { get; set; }
        public Dictionary<string, PsUserAssignedIdentity> UserAssignedIdentities { get; set; }
    }
}

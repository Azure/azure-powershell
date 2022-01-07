namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    using Newtonsoft.Json.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using System.Collections.Generic;

    /// <summary>
    /// The policy assignment properties.
    /// </summary>
    public class PsUserAssignedIdentity
    {
        public PsUserAssignedIdentity(JToken input)
        {
            var identity = input.ToObject<UserAssignedIdentityResource>(JsonExtensions.JsonMediaTypeSerializer);
            PrincipalId = identity.PrincipalId;
            ClientId = identity.ClientId;
        }

        public string PrincipalId { get; set; }
        public string ClientId { get; set; }
    }
}

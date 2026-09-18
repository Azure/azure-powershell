using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Models
{
    public class PSUserAssignedIdentityProperty
    {
        public string PrincipalId { get; }
        public string ClientId { get; }

        public PSUserAssignedIdentityProperty(UserAssignedIdentityProperty prop)
        {
            PrincipalId = prop.PrincipalId;
            ClientId = prop.ClientId;
        }
    }
}
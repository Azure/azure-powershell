using System;
using Microsoft.Azure.Management.ManagedServiceIdentity.Models;

namespace Microsoft.Azure.Commands.ManagedServiceIdentity.Models
{
    public class PsUserAssignedIdentity
    {
        public string Id { get; set; }
        public string ResourceGroupName { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string TenantId { get; set; }
        public string PrincipalId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecretUrl { get; set; }
        public string Type { get; set; }

        public PsUserAssignedIdentity(Identity identity)
        {
            this.Id = identity.Id;
            this.ResourceGroupName = GetResourceGroupNameFromId(this.Id);
            this.Name = identity.Name;
            this.Location = identity.Location;
            this.TenantId = identity.TenantId.ToString();
            this.PrincipalId = identity.PrincipalId.ToString();
            this.ClientId = identity.ClientId.ToString();
            this.ClientSecretUrl = identity.ClientSecretUrl;
            this.Type = identity.Type;
        }

        private string GetResourceGroupNameFromId(string resourceId)
        {
            if (!string.IsNullOrEmpty(resourceId))
            {
                string[] tokens = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[3];
            }

            return null;
        }
    }
}

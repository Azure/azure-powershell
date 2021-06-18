using Azure.Analytics.Synapse.AccessControl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSynapseRole
    {
        public PSSynapseRole(SynapseRoleDefinition synapseRole)
        {
            this.Id = synapseRole.Id?.ToString();
            this.Name = synapseRole.Name;
            this.IsBuiltIn = synapseRole.IsBuiltIn.Value;
            this.Description = synapseRole.Description;
            this.AvailabilityStatus = synapseRole.AvailabilityStatus;
            this.Permissions = synapseRole.Permissions;
            this.Scopes = synapseRole.Scopes;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsBuiltIn { get; set; }

        public string Description { get; set; }

        public string AvailabilityStatus { get; set; }

        public IReadOnlyList<SynapseRbacPermission> Permissions { get; set; }

        public IReadOnlyList<string> Scopes { get; set; }
    }
}

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
            this.Id = synapseRole.Id.ToString();
            this.Name = synapseRole.Name;
            this.IsBuiltIn = synapseRole.IsBuiltIn;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool? IsBuiltIn { get; set; }
    }
}

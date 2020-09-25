using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseEntityFilterOptions
    {
        public string WorkspaceName { get; set; }

        public string ResourceGroupName { get; set; }

        public string NextLink { get; set; }

        public string Name { get; set; }
    }
}

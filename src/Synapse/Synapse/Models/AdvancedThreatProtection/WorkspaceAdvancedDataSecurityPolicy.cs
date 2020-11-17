using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class WorkspaceAdvancedDataSecurityPolicy
    {
        public string ResourceGroupName { get; set; }

        public string WorkspaceName { get; set; }

        public bool IsEnabled { get; set; }
    }
}

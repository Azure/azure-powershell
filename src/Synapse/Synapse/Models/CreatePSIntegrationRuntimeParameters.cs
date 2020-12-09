using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class CreatePSIntegrationRuntimeParameters
    {
        public string ResourceGroupName { get; set; }

        public string WorkspaceName { get; set; }

        public bool Force { get; set; }

        public Action<bool, string, string, string, Action, Func<bool>> ConfirmAction { get; set; }

        public string Name { get; set; }

        public bool IsUpdate { get; set; }

        public IntegrationRuntimeResource IntegrationRuntimeResource { get; set; }
    }
}

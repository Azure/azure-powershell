using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLinkedIntegrationRuntime : PSSelfHostedIntegrationRuntime
    {
        public PSLinkedIntegrationRuntime(
            IntegrationRuntimeResource integrationRuntime,
            string resourceGroupName,
            string workspaceName)
            : base(integrationRuntime, resourceGroupName, workspaceName)
        {
        }

        public string AuthorizationType { get; set; }
    }
}

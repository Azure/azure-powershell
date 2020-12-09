using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSelfHostedIntegrationRuntime : PSIntegrationRuntime
    {
        public PSSelfHostedIntegrationRuntime(
            IntegrationRuntimeResource integrationRuntime,
            string resourceGroupName,
            string workspaceName)
            : base(integrationRuntime, resourceGroupName, workspaceName)
        {
            if (IntegrationRuntime.Properties == null)
            {
                IntegrationRuntime.Properties = new SelfHostedIntegrationRuntime();
            }

            if (SelfHostedIntegrationRuntime == null)
            {
                throw new PSArgumentException("The resource is not a valid self-hosted integration runtime.");
            }
        }

        protected SelfHostedIntegrationRuntime SelfHostedIntegrationRuntime => IntegrationRuntime.Properties as SelfHostedIntegrationRuntime;
    }
}

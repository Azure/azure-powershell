using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSIntegrationRuntime
    {
        internal readonly IntegrationRuntimeResource IntegrationRuntime;

        public PSIntegrationRuntime(IntegrationRuntimeResource integrationRuntime, string resourceGroupName, string workspaceName)
        {
            if (integrationRuntime == null)
            {
                throw new ArgumentNullException(nameof(integrationRuntime));
            }

            IntegrationRuntime = integrationRuntime;
            ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
        }

        public string Name => IntegrationRuntime.Name;

        public string Type
        {
            get
            {
                if (IntegrationRuntime.Properties is ManagedIntegrationRuntime)
                {
                    return SynapseConstants.IntegrationRuntimeTypeManaged;
                }
                else if (IntegrationRuntime.Properties is SelfHostedIntegrationRuntime)
                {
                    return SynapseConstants.IntegrationRuntimeSelfhosted;
                }

                return string.Empty;
            }
        }

        public string ResourceGroupName { get; private set; }

        public string WorkspaceName { get; private set; }

        public string Description
        {
            get { return IntegrationRuntime.Properties.Description; }
            set { IntegrationRuntime.Properties.Description = value; }
        }

        public string Id => IntegrationRuntime.Id;
    }
}

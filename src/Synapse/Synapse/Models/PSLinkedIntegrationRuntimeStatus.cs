using Microsoft.Azure.Management.Synapse.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLinkedIntegrationRuntimeStatus : PSSelfHostedIntegrationRuntimeStatus
    {
        public PSLinkedIntegrationRuntimeStatus(
            IntegrationRuntimeResource integrationRuntime,
            SelfHostedIntegrationRuntimeStatus status,
            string resourceGroupName,
            string workspaceName,
            JsonSerializerSettings deserializerSettings,
            string authType,
            string origIntegrationRuntimeName,
            string origDataFactoryName)
            : base(integrationRuntime, status, resourceGroupName, workspaceName, deserializerSettings)
        {
            WorkspaceName = workspaceName;
            ResourceGroupName = resourceGroupName;
            OriginalIntegrationRuntimeName = origIntegrationRuntimeName;
            OriginalDataFactoryName = origDataFactoryName;
            AuthorizationType = authType;
        }

        public new string Name => IntegrationRuntime.Name;

        public new string Type => SynapseConstants.IntegrationRuntimeSelfhostedLinked;

        public new string WorkspaceName { get; private set; }

        public new string ResourceGroupName { get; private set; }

        public string OriginalIntegrationRuntimeName { get; private set; }

        public string OriginalDataFactoryName { get; private set; }

        public string AuthorizationType { get; private set; }

        private new IList<LinkedIntegrationRuntime> Links { get; set; }
    }
}

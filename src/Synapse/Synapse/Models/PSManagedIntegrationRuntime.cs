using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSManagedIntegrationRuntime : PSIntegrationRuntime
    {
        public PSManagedIntegrationRuntime(
            IntegrationRuntimeResource integrationRuntime,
            string resourceGroupName,
            string workspaceName)
            : base(integrationRuntime, resourceGroupName, workspaceName)
        {
            if (IntegrationRuntime.Properties == null)
            {
                IntegrationRuntime.Properties = new ManagedIntegrationRuntime();
            }

            if (ManagedIntegrationRuntime == null)
            {
                throw new PSArgumentException("The resource is not a valid managed integration runtime.");
            }
        }

        private ManagedIntegrationRuntime ManagedIntegrationRuntime => IntegrationRuntime.Properties as ManagedIntegrationRuntime;

        public string Location => ManagedIntegrationRuntime.ComputeProperties?.Location;

        public string NodeSize => ManagedIntegrationRuntime.ComputeProperties?.NodeSize;

        public int? NodeCount => ManagedIntegrationRuntime.ComputeProperties?.NumberOfNodes;

        public int? MaxParallelExecutionsPerNode => ManagedIntegrationRuntime.ComputeProperties?.MaxParallelExecutionsPerNode;

        public string CatalogServerEndpoint => ManagedIntegrationRuntime.SsisProperties?.CatalogInfo?.CatalogServerEndpoint;

        public string CatalogAdminUserName => ManagedIntegrationRuntime.SsisProperties?.CatalogInfo?.CatalogAdminUserName;

        public string CatalogAdminPassword => ManagedIntegrationRuntime.SsisProperties?.CatalogInfo?.CatalogAdminPassword?.Value;

        public string CatalogPricingTier => ManagedIntegrationRuntime.SsisProperties?.CatalogInfo?.CatalogPricingTier;

        public string VNetId => ManagedIntegrationRuntime.ComputeProperties?.VNetProperties?.VNetId;

        public string Subnet => ManagedIntegrationRuntime.ComputeProperties?.VNetProperties?.Subnet;

        public string[] PublicIPs => ManagedIntegrationRuntime.ComputeProperties?.VNetProperties?.PublicIPs == null ? null : new List<string>(ManagedIntegrationRuntime.ComputeProperties?.VNetProperties?.PublicIPs).ToArray();

        public int? DataFlowCoreCount => ManagedIntegrationRuntime.ComputeProperties?.DataFlowProperties?.CoreCount;

        public string DataFlowComputeType => ManagedIntegrationRuntime.ComputeProperties?.DataFlowProperties?.ComputeType;

        public int? DataFlowTimeToLive => ManagedIntegrationRuntime.ComputeProperties?.DataFlowProperties?.TimeToLive;

        public string State => ManagedIntegrationRuntime.State;

        public string LicenseType => ManagedIntegrationRuntime.SsisProperties?.LicenseType;

        public string SetupScriptContainerSasUri => ManagedIntegrationRuntime.SsisProperties?.CustomSetupScriptProperties?.BlobContainerUri + ManagedIntegrationRuntime.SsisProperties?.CustomSetupScriptProperties?.SasToken?.Value;

        public string DataProxyIntegrationRuntimeName => ManagedIntegrationRuntime.SsisProperties?.DataProxyProperties?.ConnectVia?.ReferenceName;

        public string DataProxyStagingLinkedServiceName => ManagedIntegrationRuntime.SsisProperties?.DataProxyProperties?.StagingLinkedService?.ReferenceName;

        public string DataProxyStagingPath => ManagedIntegrationRuntime.SsisProperties?.DataProxyProperties?.Path;

        public string Edition => ManagedIntegrationRuntime.SsisProperties?.Edition;

        public System.Collections.Generic.IList<CustomSetupBase> ExpressCustomSetup => ManagedIntegrationRuntime.SsisProperties?.ExpressCustomSetupProperties;
    }
}

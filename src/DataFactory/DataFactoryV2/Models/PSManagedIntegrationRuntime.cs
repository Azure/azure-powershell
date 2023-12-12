// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.DataFactory.Models;


namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSManagedIntegrationRuntime : PSIntegrationRuntime
    {
        public PSManagedIntegrationRuntime(
            IntegrationRuntimeResource integrationRuntime,
            string resourceGroupName,
            string factoryName)
            : base(integrationRuntime, resourceGroupName, factoryName)
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

        public string SubnetId => ManagedIntegrationRuntime.ComputeProperties?.VNetProperties?.SubnetId ?? ManagedIntegrationRuntime.CustomerVirtualNetwork?.SubnetId;

        public string VNetInjectionMethod => ManagedIntegrationRuntime.CustomerVirtualNetwork?.SubnetId == null ? Constants.IntegrationRuntimeVNetInjectionStandard : Constants.IntegrationRuntimeVNectInjectionExpress;

        public string[] PublicIPs => ManagedIntegrationRuntime.ComputeProperties?.VNetProperties?.PublicIPs == null ? null : new List<string>(ManagedIntegrationRuntime.ComputeProperties?.VNetProperties?.PublicIPs).ToArray();

        public int? DataFlowCoreCount => ManagedIntegrationRuntime.ComputeProperties?.DataFlowProperties?.CoreCount;

        public string DataFlowComputeType => ManagedIntegrationRuntime.ComputeProperties?.DataFlowProperties?.ComputeType;

        public int? DataFlowTimeToLive => ManagedIntegrationRuntime.ComputeProperties?.DataFlowProperties?.TimeToLive;

        public bool? DataFlowEnableCleanUp => ManagedIntegrationRuntime.ComputeProperties?.DataFlowProperties.Cleanup;

        public int? CopyComputeScaleDataIntegrationUnit => ManagedIntegrationRuntime.ComputeProperties?.CopyComputeScaleProperties?.DataIntegrationUnit;

        public int? CopyComputeScaleTimeToLive => ManagedIntegrationRuntime.ComputeProperties?.CopyComputeScaleProperties?.TimeToLive;

        public int? PipelineExternalComputeScaleTimeToLive => ManagedIntegrationRuntime.ComputeProperties?.PipelineExternalComputeScaleProperties?.TimeToLive;

        public int? PipelineExternalComputeScaleNumberOfPipelineNodes => ManagedIntegrationRuntime.ComputeProperties?.PipelineExternalComputeScaleProperties?.NumberOfPipelineNodes;

        public int? PipelineExternalComputeScaleNumberOfExternalNodes => ManagedIntegrationRuntime.ComputeProperties?.PipelineExternalComputeScaleProperties?.NumberOfExternalNodes;

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

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

using System;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2IntegrationRuntime", DefaultParameterSetName = ParameterSetNames.ByIntegrationRuntimeName, SupportsShouldProcess = true), OutputType(typeof(PSIntegrationRuntime))]
    public class SetAzureDataFactoryIntegrationRuntimeCommand : IntegrationRuntimeCmdlet
    {
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeResourceId,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceId)]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public new string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeName,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public new string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeName,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [ValidateNotNullOrEmpty]
        public new string DataFactoryName { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = Constants.HelpIntegrationRuntimeObject)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeObject,
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = Constants.HelpIntegrationRuntimeObject)]
        [ValidateNotNull]
        public new PSIntegrationRuntime InputObject { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpIntegrationRuntimeName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeName,
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpIntegrationRuntimeName)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.IntegrationRuntimeName)]
        public new string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimetype)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.IntegrationRuntimeTypeManaged,
            Constants.IntegrationRuntimeSelfhosted,
            IgnoreCase = true)]
        public string Type { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDescription)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLocation)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLocation)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLocation)]
        [LocationCompleter("Microsoft.DataFactory/factories")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeSize)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeSize)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeSize)]
        [ValidateNotNullOrEmpty]
        public string NodeSize { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeCount)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeCount)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeNodeCount)]
        public int? NodeCount { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogServerEndpoint)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogServerEndpoint)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogServerEndpoint)]
        [ValidateNotNullOrEmpty]
        public string CatalogServerEndpoint { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogAdminCredential)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogAdminCredential)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogAdminCredential)]
        [ValidateNotNull]
        public PSCredential CatalogAdminCredential { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogPricingTier)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogPricingTier)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeCatalogPricingTier)]
        [ValidateNotNullOrEmpty]
        public string CatalogPricingTier { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeVNetId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeVNetId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeVNetId)]
        [ValidateNotNull]
        public string VNetId { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSubnet)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSubnet)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSubnet)]
        [Alias(Constants.SubnetName)]
        [ValidateNotNull]
        public string Subnet { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSubnetId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSubnetId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSubnetId)]
        [ValidateNotNull]
        public string SubnetId { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimePublicIP)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimePublicIP)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimePublicIP)]
        [ValidateNotNull]
        public string[] PublicIPs { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataFlowComputeType)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataFlowComputeType)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataFlowComputeType)]
        [PSArgumentCompleter(Management.DataFactory.Models.DataFlowComputeType.General,
            Management.DataFactory.Models.DataFlowComputeType.MemoryOptimized,
            Management.DataFactory.Models.DataFlowComputeType.ComputeOptimized)]
        [ValidateNotNullOrEmpty]
        public string DataFlowComputeType { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataFlowQuickReuseEnabled)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataFlowQuickReuseEnabled)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataFlowQuickReuseEnabled)]
        public SwitchParameter DataFlowEnableQuickReuse { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataFlowCoreCount)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataFlowCoreCount)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataFlowCoreCount)]
        public int? DataFlowCoreCount { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataFlowTimeToLive)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataFlowTimeToLive)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataFlowTimeToLive)]
        public int? DataFlowTimeToLive { get; set; }

        [Parameter(
           ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetCopyComputeScaleDataIntegrationUnit)]
        [Parameter(
           ParameterSetName = ParameterSetNames.ByResourceId,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetCopyComputeScaleDataIntegrationUnit)]
        [Parameter(
           ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetCopyComputeScaleDataIntegrationUnit)]
        public int? ManagedVNetCopyComputeScaleDataIntegrationUnit { get; set; }

        [Parameter(
           ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetCopyComputeScaleTimeToLive)]
        [Parameter(
           ParameterSetName = ParameterSetNames.ByResourceId,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetCopyComputeScaleTimeToLive)]
        [Parameter(
           ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetCopyComputeScaleTimeToLive)]
        public int? ManagedVNetCopyComputeScaleTimeToLive { get; set; }

        [Parameter(
           ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetPipelineExternalComputeScaleTimeToLive)]
        [Parameter(
           ParameterSetName = ParameterSetNames.ByResourceId,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetPipelineExternalComputeScaleTimeToLive)]
        [Parameter(
           ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetPipelineExternalComputeScaleTimeToLive)]
        public int? ManagedVNetPipelineExternalComputeScaleTimeToLive { get; set; }

        [Parameter(
           ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetNumberOfPipelineNodes)]
        [Parameter(
           ParameterSetName = ParameterSetNames.ByResourceId,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetNumberOfPipelineNodes)]
        [Parameter(
           ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetNumberOfPipelineNodes)]
        public int? ManagedVNetNumberOfPipelineNodeCount { get; set; }

        [Parameter(
           ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetNumberOfExternalNodes)]
        [Parameter(
           ParameterSetName = ParameterSetNames.ByResourceId,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetNumberOfExternalNodes)]
        [Parameter(
           ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeManagedVNetNumberOfExternalNodes)]
        public int? ManagedVNetNumberOfExternalNodeCount { get; set; }

        [Parameter(
           ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeSelfContainedInteractiveAuthoringEnabled)]
        [Parameter(
           ParameterSetName = ParameterSetNames.ByResourceId,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeSelfContainedInteractiveAuthoringEnabled)]
        [Parameter(
           ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
           Mandatory = false,
           HelpMessage = Constants.HelpIntegrationRuntimeSelfContainedInteractiveAuthoringEnabled)]
        public SwitchParameter SelfContainedInteractiveAuthoringEnabled { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSetupScriptContainerSasUri)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSetupScriptContainerSasUri)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeSetupScriptContainerSasUri)]
        [ValidateNotNullOrEmpty]
        public string SetupScriptContainerSasUri { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeEdition)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeEdition)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeEdition)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            IntegrationRuntimeEdition.Standard,
            IntegrationRuntimeEdition.Enterprise,
            IgnoreCase = true)]
        public string Edition { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeEdition)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeEdition)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeVNetInjectionMethod)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.IntegrationRuntimeVNetInjectionStandard,
            Constants.IntegrationRuntimeVNectInjectionExpress,
            IgnoreCase = true)]
        public string VNetInjectionMethod { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeExpressCustomSetup)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeExpressCustomSetup)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeExpressCustomSetup)]
        [ValidateNotNullOrEmpty]
        public System.Collections.ArrayList ExpressCustomSetup { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataProxyIntegrationRuntimeName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataProxyIntegrationRuntimeName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataProxyIntegrationRuntimeName)]
        [ValidateNotNullOrEmpty]
        public string DataProxyIntegrationRuntimeName { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataProxyStagingLinkedServiceName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataProxyStagingLinkedServiceName)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataProxyStagingLinkedServiceName)]
        [ValidateNotNullOrEmpty]
        public string DataProxyStagingLinkedServiceName { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataProxyStagingPath)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataProxyStagingPath)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeDataProxyStagingPath)]
        [ValidateNotNullOrEmpty]
        public string DataProxyStagingPath { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeMaxParallelExecutionsPerNode)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeMaxParallelExecutionsPerNode)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeMaxParallelExecutionsPerNode)]
        public int? MaxParallelExecutionsPerNode { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLicenseType)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLicenseType)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeLicenseType)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.IntegrationRuntimeLicenseIncluded,
            Constants.IntegrationRuntimeBasePrice,
            IgnoreCase = true)]
        public string LicenseType { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeAuthKey)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByResourceId,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeAuthKey)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByIntegrationRuntimeObject,
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeAuthKey)]
        [ValidateNotNull]
        public System.Security.SecureString AuthKey { get; set; }

        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeName,
            Mandatory = true,
            HelpMessage = Constants.HelpSharedIntegrationRuntimeResourceId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeResourceId,
            Mandatory = true,
            HelpMessage = Constants.HelpSharedIntegrationRuntimeResourceId)]
        [Parameter(
            ParameterSetName = ParameterSetNames.ByLinkedIntegrationRuntimeObject,
            Mandatory = true,
            HelpMessage = Constants.HelpSharedIntegrationRuntimeResourceId)]
        [ValidateNotNullOrEmpty]
        public string SharedIntegrationRuntimeResourceId { get; set; }

        [Parameter(
            Mandatory = false, HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        protected override void ByResourceId()
        {
            if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                ResourceGroupName = parsedResourceId.ResourceGroupName;

                var parentResource = parsedResourceId.ParentResource.Split(new[] { '/' });
                DataFactoryName = parentResource[parentResource.Length - 1];

                Name = parsedResourceId.ResourceName;
            }
        }

        protected override void ByIntegrationRuntimeObject()
        {
            if (InputObject != null)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                DataFactoryName = InputObject.DataFactoryName;
                Name = InputObject.Name;
            }
        }


        public override void ExecuteCmdlet()
        {
            this.ByResourceId();
            this.ByIntegrationRuntimeObject();

            if (string.Equals(Type, Constants.IntegrationRuntimeTypeManaged, StringComparison.OrdinalIgnoreCase))
            {
                if (AuthKey != null || !string.IsNullOrWhiteSpace(SharedIntegrationRuntimeResourceId))
                {
                    throw new PSArgumentException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.InvalidIntegrationRuntimeSharing),
                        "AuthKey");
                }
            }

            IntegrationRuntimeResource resource = null;
            var isUpdate = false;
            try
            {
                resource = DataFactoryClient.GetIntegrationRuntimeAsync(
                    ResourceGroupName,
                    DataFactoryName,
                    Name).ConfigureAwait(true).GetAwaiter().GetResult().IntegrationRuntime;

                isUpdate = true;
                if (Type != null && (resource.Properties is ManagedIntegrationRuntime ^
                    Type.Equals(Constants.IntegrationRuntimeTypeManaged, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new PSArgumentException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.IntegrationRuntimeWrongType,
                            Name),
                        "Type");
                }

                if (AuthKey != null)
                {
                    throw new PSArgumentException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.UpdateAuthKeyNotAllowed,
                            Name),
                        "AuthKey");
                }
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    if (Type == null)
                    {
                        throw new PSArgumentException(
                            string.Format(
                                CultureInfo.InvariantCulture,
                                Resources.NeedIntegrationRuntimeType),
                            "Type");
                    }

                    resource = new IntegrationRuntimeResource();
                    if (Type.Equals(Constants.IntegrationRuntimeTypeManaged, StringComparison.OrdinalIgnoreCase))
                    {
                        resource.Properties = new ManagedIntegrationRuntime();
                    }
                    else
                    {
                        var selfHosted = new SelfHostedIntegrationRuntime();
                        if (AuthKey != null)
                        {
                            var authKey = ConvertToUnsecureString(AuthKey);
                            selfHosted.LinkedInfo = new LinkedIntegrationRuntimeKeyAuthorization(new SecureString(authKey));
                        }
                        if (SelfContainedInteractiveAuthoringEnabled.IsPresent)
                        {
                            selfHosted.SelfContainedInteractiveAuthoringEnabled = true;
                        }
                        resource.Properties = selfHosted;
                    }
                }
                else
                {
                    throw;
                }
            }

            if (!string.IsNullOrWhiteSpace(SharedIntegrationRuntimeResourceId))
            {
                var selfHostedIr = resource.Properties as SelfHostedIntegrationRuntime;
                if (selfHostedIr != null)
                {
                    selfHostedIr.LinkedInfo = new LinkedIntegrationRuntimeRbacAuthorization(SharedIntegrationRuntimeResourceId);
                    if (SelfContainedInteractiveAuthoringEnabled.IsPresent)
                    {
                        selfHostedIr.SelfContainedInteractiveAuthoringEnabled = true;
                    }
                }
                else
                {
                    throw new PSArgumentException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.InvalidIntegrationRuntimeSharing),
                        "SharedIntegrationRuntimeResourceId");
                }
            }

            if (!string.IsNullOrWhiteSpace(Description))
            {
                resource.Properties.Description = Description;
            }

            var managedIr = resource.Properties as ManagedIntegrationRuntime;
            if (managedIr != null)
            {
                HandleManagedIntegrationRuntime(managedIr);
            }

            var parameters = new CreatePSIntegrationRuntimeParameters()
            {
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                Name = Name,
                IsUpdate = isUpdate,
                IntegrationRuntimeResource = resource,
                Force = Force.IsPresent,
                ConfirmAction = base.ConfirmAction
            };

            WriteObject(DataFactoryClient.CreateOrUpdateIntegrationRuntime(parameters));
        }

        private void HandleManagedIntegrationRuntime(ManagedIntegrationRuntime integrationRuntime)
        {
            if (!string.IsNullOrWhiteSpace(Location))
            {
                if (integrationRuntime.ComputeProperties == null)
                {
                    integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                }

                integrationRuntime.ComputeProperties.Location = Location;
            }

            if (!string.IsNullOrWhiteSpace(NodeSize))
            {
                if (integrationRuntime.ComputeProperties == null)
                {
                    integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                }

                integrationRuntime.ComputeProperties.NodeSize = NodeSize;
            }

            if (NodeCount.HasValue)
            {
                if (integrationRuntime.ComputeProperties == null)
                {
                    integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                }

                integrationRuntime.ComputeProperties.NumberOfNodes = NodeCount;

                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties();
                }
            }

            if (MaxParallelExecutionsPerNode.HasValue)
            {
                if (integrationRuntime.ComputeProperties == null)
                {
                    integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                }

                integrationRuntime.ComputeProperties.MaxParallelExecutionsPerNode = MaxParallelExecutionsPerNode;
            }

            if (!string.IsNullOrWhiteSpace(CatalogServerEndpoint))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties()
                    {
                        CatalogInfo = new IntegrationRuntimeSsisCatalogInfo()
                    };
                }
                else if (integrationRuntime.SsisProperties.CatalogInfo == null)
                {
                    integrationRuntime.SsisProperties.CatalogInfo = new IntegrationRuntimeSsisCatalogInfo();
                }

                integrationRuntime.SsisProperties.CatalogInfo.CatalogServerEndpoint = CatalogServerEndpoint;
            }

            if (CatalogAdminCredential != null)
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties()
                    {
                        CatalogInfo = new IntegrationRuntimeSsisCatalogInfo()
                    };
                }
                else if (integrationRuntime.SsisProperties.CatalogInfo == null)
                {
                    integrationRuntime.SsisProperties.CatalogInfo = new IntegrationRuntimeSsisCatalogInfo();
                }

                integrationRuntime.SsisProperties.CatalogInfo.CatalogAdminUserName = CatalogAdminCredential.UserName;
                var passWord = ConvertToUnsecureString(CatalogAdminCredential.Password);
                if (passWord != null && passWord.Length > 128)
                {
                    throw new PSArgumentException("The password exceeds maximum length of '128'", "CatalogAdminCredential");
                }
                integrationRuntime.SsisProperties.CatalogInfo.CatalogAdminPassword = new SecureString(passWord);
            }

            if (!string.IsNullOrWhiteSpace(CatalogPricingTier))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties()
                    {
                        CatalogInfo = new IntegrationRuntimeSsisCatalogInfo()
                    };
                }
                else if (integrationRuntime.SsisProperties.CatalogInfo == null)
                {
                    integrationRuntime.SsisProperties.CatalogInfo = new IntegrationRuntimeSsisCatalogInfo();
                }

                integrationRuntime.SsisProperties.CatalogInfo.CatalogPricingTier = CatalogPricingTier;
            }

            SetAzureDataFactoryIntegrationRuntimeCommandHelper.SetSubnetId(
                integrationRuntime, VNetInjectionMethod, SubnetId, Subnet, VNetId
                );

            if (!string.IsNullOrWhiteSpace(DataFlowComputeType) || DataFlowCoreCount != null || DataFlowTimeToLive != null || DataFlowEnableQuickReuse != null)
            {
                if (integrationRuntime.ComputeProperties == null)
                {
                    integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                }
                if (integrationRuntime.ComputeProperties.DataFlowProperties == null)
                {
                    integrationRuntime.ComputeProperties.DataFlowProperties = new IntegrationRuntimeDataFlowProperties();
                }

                integrationRuntime.ComputeProperties.DataFlowProperties.ComputeType = DataFlowComputeType ?? integrationRuntime.ComputeProperties.DataFlowProperties.ComputeType;
                integrationRuntime.ComputeProperties.DataFlowProperties.CoreCount = DataFlowCoreCount ?? integrationRuntime.ComputeProperties.DataFlowProperties.CoreCount;
                integrationRuntime.ComputeProperties.DataFlowProperties.TimeToLive = DataFlowTimeToLive ?? integrationRuntime.ComputeProperties.DataFlowProperties.TimeToLive;
                if (DataFlowEnableQuickReuse.IsPresent)
                {
                    integrationRuntime.ComputeProperties.DataFlowProperties.Cleanup = false;
                }
                else
                {
                    // setting it as null as the default value for the cleanup variable is false, and the backend endpoint treats null value as true.
                    integrationRuntime.ComputeProperties.DataFlowProperties.Cleanup = null;
                }

            }

            if (ManagedVNetCopyComputeScaleDataIntegrationUnit != null || ManagedVNetCopyComputeScaleTimeToLive != null)
            {
                if (integrationRuntime.ComputeProperties == null)
                {
                    integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                }
                if (integrationRuntime.ComputeProperties.CopyComputeScaleProperties == null)
                {
                    integrationRuntime.ComputeProperties.CopyComputeScaleProperties = new CopyComputeScaleProperties();
                }

                integrationRuntime.ComputeProperties.CopyComputeScaleProperties.DataIntegrationUnit = ManagedVNetCopyComputeScaleDataIntegrationUnit ?? integrationRuntime.ComputeProperties.CopyComputeScaleProperties.DataIntegrationUnit;
                integrationRuntime.ComputeProperties.CopyComputeScaleProperties.TimeToLive = ManagedVNetCopyComputeScaleTimeToLive ?? integrationRuntime.ComputeProperties.CopyComputeScaleProperties.TimeToLive;
            }

            if (ManagedVNetPipelineExternalComputeScaleTimeToLive != null || ManagedVNetNumberOfPipelineNodeCount != null || ManagedVNetNumberOfExternalNodeCount != null)
            {
                if (integrationRuntime.ComputeProperties == null)
                {
                    integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                }
                if (integrationRuntime.ComputeProperties.PipelineExternalComputeScaleProperties == null)
                {
                    integrationRuntime.ComputeProperties.PipelineExternalComputeScaleProperties = new PipelineExternalComputeScaleProperties();
                }

                integrationRuntime.ComputeProperties.PipelineExternalComputeScaleProperties.TimeToLive = ManagedVNetPipelineExternalComputeScaleTimeToLive ?? integrationRuntime.ComputeProperties.PipelineExternalComputeScaleProperties.TimeToLive;
                integrationRuntime.ComputeProperties.PipelineExternalComputeScaleProperties.NumberOfPipelineNodes = ManagedVNetNumberOfPipelineNodeCount ?? integrationRuntime.ComputeProperties.PipelineExternalComputeScaleProperties.NumberOfPipelineNodes;
                integrationRuntime.ComputeProperties.PipelineExternalComputeScaleProperties.NumberOfExternalNodes = ManagedVNetNumberOfExternalNodeCount ?? integrationRuntime.ComputeProperties.PipelineExternalComputeScaleProperties.NumberOfExternalNodes;
            }

            if (PublicIPs != null)
            {
                if (string.IsNullOrWhiteSpace(VNetId) && string.IsNullOrWhiteSpace(SubnetId))
                {
                    throw new PSArgumentException(string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.IntegrationRuntimeSubnetNotProvided),
                        "SubnetId");
                }

                if (PublicIPs.Length != 2)
                {
                    throw new PSArgumentException(string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.InvalidPublicIPCount),
                        "PublicIPs");
                }

                integrationRuntime.ComputeProperties.VNetProperties.PublicIPs = PublicIPs;
            }

            if (!string.IsNullOrWhiteSpace(LicenseType))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties();
                }

                integrationRuntime.SsisProperties.LicenseType = LicenseType;
            }

            if (!string.IsNullOrEmpty(SetupScriptContainerSasUri))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties();
                }

                int index = SetupScriptContainerSasUri.IndexOf('?');

                integrationRuntime.SsisProperties.CustomSetupScriptProperties = new IntegrationRuntimeCustomSetupScriptProperties()
                {
                    BlobContainerUri = index >= 0 ? SetupScriptContainerSasUri.Substring(0, index) : SetupScriptContainerSasUri,
                    SasToken = index >= 0 ? new SecureString(SetupScriptContainerSasUri.Substring(index)) : null
                };
            }

            if (ExpressCustomSetup != null && ExpressCustomSetup.ToArray().Length > 0)
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties();
                }
                System.Collections.Generic.IList<CustomSetupBase> setups = new System.Collections.Generic.List<CustomSetupBase>();
                foreach (CustomSetupBase setup in ExpressCustomSetup)
                {
                    setups.Add(setup);
                }
                integrationRuntime.SsisProperties.ExpressCustomSetupProperties = setups;
            }

            if (!string.IsNullOrEmpty(DataProxyIntegrationRuntimeName))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties();
                }
                if (integrationRuntime.SsisProperties.DataProxyProperties == null)
                {
                    integrationRuntime.SsisProperties.DataProxyProperties = new IntegrationRuntimeDataProxyProperties();
                }
                integrationRuntime.SsisProperties.DataProxyProperties.ConnectVia = new EntityReference("IntegrationRuntimeReference", DataProxyIntegrationRuntimeName);
            }

            if (!string.IsNullOrEmpty(DataProxyStagingLinkedServiceName))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties();
                }
                if (integrationRuntime.SsisProperties.DataProxyProperties == null)
                {
                    integrationRuntime.SsisProperties.DataProxyProperties = new IntegrationRuntimeDataProxyProperties();
                }
                integrationRuntime.SsisProperties.DataProxyProperties.StagingLinkedService = new EntityReference("LinkedServiceReference", DataProxyStagingLinkedServiceName);
            }

            if (!string.IsNullOrEmpty(DataProxyStagingPath))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties();
                }
                if (integrationRuntime.SsisProperties.DataProxyProperties == null)
                {
                    integrationRuntime.SsisProperties.DataProxyProperties = new IntegrationRuntimeDataProxyProperties();
                }
                integrationRuntime.SsisProperties.DataProxyProperties.Path = DataProxyStagingPath;
            }

            if (!string.IsNullOrEmpty(Edition))
            {
                if (integrationRuntime.SsisProperties == null)
                {
                    integrationRuntime.SsisProperties = new IntegrationRuntimeSsisProperties();
                }

                integrationRuntime.SsisProperties.Edition = Edition;
            }

            integrationRuntime.Validate();
        }
    }
}

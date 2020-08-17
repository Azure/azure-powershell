using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.IntegrationRuntime,
        DefaultParameterSetName = SetByIntegrationRuntimeName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSIntegrationRuntime))]
    public class SetAzureSynapseIntegrationRuntime : SynapseManagementCmdletBase
    {
        private const string SetByResourceId = "SetByResourceId";
        private const string SetByLinkedIntegrationRuntimeResourceId = "SetByLinkedIntegrationRuntimeResourceId";
        private const string SetByIntegrationRuntimeName = "SetByIntegrationRuntimeName";
        private const string SetByLinkedIntegrationRuntimeName = "SetByLinkedIntegrationRuntimeName";
        private const string SetByIntegrationRuntimeObject = "SetByIntegrationRuntimeObject";
        private const string SetByLinkedIntegrationRuntimeObject = "SetByLinkedIntegrationRuntimeObject";
        private const string SetByParentObject = "SetByParentObject";
        private const string SetByLinkedIntegrationRuntimeParentObject = "SetByLinkedIntegrationRuntimeParentObject";


        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByLinkedIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByLinkedIntegrationRuntimeName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByLinkedIntegrationRuntimeName,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByParentObject,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByLinkedIntegrationRuntimeParentObject,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [ResourceNameCompleter(
            ResourceTypes.IntegrationRuntime,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [Alias(SynapseConstants.IntegrationRuntimeName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByParentObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByLinkedIntegrationRuntimeParentObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByResourceId,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeResourceId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByLinkedIntegrationRuntimeResourceId,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByLinkedIntegrationRuntimeObject,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeObject)]
        [ValidateNotNull]
        public PSIntegrationRuntime InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimetype)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(SynapseConstants.IntegrationRuntimeTypeManaged, SynapseConstants.IntegrationRuntimeSelfhosted, IgnoreCase = true)]
        public string Type { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDescription)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeLocation)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeLocation)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeLocation)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeLocation)]
        [LocationCompleter("Microsoft.DataFactory/factories")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeNodeSize)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeNodeSize)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeNodeSize)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeNodeSize)]
        [ValidateNotNullOrEmpty]
        public string NodeSize { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeNodeCount)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeNodeCount)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeNodeCount)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeNodeCount)]
        public int? NodeCount { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeCatalogServerEndpoint)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeCatalogServerEndpoint)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeCatalogServerEndpoint)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeCatalogServerEndpoint)]
        [ValidateNotNullOrEmpty]
        public string CatalogServerEndpoint { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeCatalogAdminCredential)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeCatalogAdminCredential)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeCatalogAdminCredential)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeCatalogAdminCredential)]
        [ValidateNotNull]
        public PSCredential CatalogAdminCredential { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeCatalogPricingTier)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeCatalogPricingTier)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeCatalogPricingTier)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeCatalogPricingTier)]
        [ValidateNotNullOrEmpty]
        public string CatalogPricingTier { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeVNetId)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeVNetId)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeVNetId)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeVNetId)]
        [ValidateNotNull]
        public string VNetId { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeSubnet)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeSubnet)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeSubnet)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeSubnet)]
        [Alias(SynapseConstants.SubnetName)]
        [ValidateNotNull]
        public string Subnet { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimePublicIP)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimePublicIP)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false,HelpMessage = HelpMessages.IntegrationRuntimePublicIP)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimePublicIP)]
        [ValidateNotNull]
        [Alias("PublicIPs")]
        public string[] PublicIP { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataFlowComputeType)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataFlowComputeType)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataFlowComputeType)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataFlowComputeType)]
        [PSArgumentCompleter(Management.Synapse.Models.DataFlowComputeType.General,
            Management.Synapse.Models.DataFlowComputeType.MemoryOptimized,
            Management.Synapse.Models.DataFlowComputeType.ComputeOptimized)]
        [ValidateNotNullOrEmpty]
        public string DataFlowComputeType { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataFlowCoreCount)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataFlowCoreCount)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataFlowCoreCount)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataFlowCoreCount)]
        public int? DataFlowCoreCount { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataFlowTimeToLive)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataFlowTimeToLive)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataFlowTimeToLive)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataFlowTimeToLive)]
        public int? DataFlowTimeToLive { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeSetupScriptContainerSasUri)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false,HelpMessage = HelpMessages.IntegrationRuntimeSetupScriptContainerSasUri)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeSetupScriptContainerSasUri)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeSetupScriptContainerSasUri)]
        [ValidateNotNullOrEmpty]
        public string SetupScriptContainerSasUri { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeEdition)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeEdition)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeEdition)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeEdition)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(IntegrationRuntimeEdition.Standard, IntegrationRuntimeEdition.Enterprise, IgnoreCase = true)]
        public string Edition { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeExpressCustomSetup)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false,HelpMessage = HelpMessages.IntegrationRuntimeExpressCustomSetup)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeExpressCustomSetup)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeExpressCustomSetup)]
        [ValidateNotNullOrEmpty]
        public System.Collections.ArrayList ExpressCustomSetup { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataProxyIntegrationRuntimeName)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataProxyIntegrationRuntimeName)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataProxyIntegrationRuntimeName)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataProxyIntegrationRuntimeName)]
        [ValidateNotNullOrEmpty]
        public string DataProxyIntegrationRuntimeName { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataProxyStagingLinkedServiceName)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataProxyStagingLinkedServiceName)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataProxyStagingLinkedServiceName)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataProxyStagingLinkedServiceName)]
        [ValidateNotNullOrEmpty]
        public string DataProxyStagingLinkedServiceName { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataProxyStagingPath)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataProxyStagingPath)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataProxyStagingPath)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeDataProxyStagingPath)]
        [ValidateNotNullOrEmpty]
        public string DataProxyStagingPath { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeMaxParallelExecutionsPerNode)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeMaxParallelExecutionsPerNode)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeMaxParallelExecutionsPerNode)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeMaxParallelExecutionsPerNode)]
        public int? MaxParallelExecutionsPerNode { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeLicenseType)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeLicenseType)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeLicenseType)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeLicenseType)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            SynapseConstants.IntegrationRuntimeLicenseIncluded,
            SynapseConstants.IntegrationRuntimeBasePrice,
            IgnoreCase = true)]
        public string LicenseType { get; set; }

        [Parameter(ParameterSetName = SetByIntegrationRuntimeName,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeAuthKey)]
        [Parameter(ParameterSetName = SetByResourceId,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeAuthKey)]
        [Parameter(ParameterSetName = SetByIntegrationRuntimeObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeAuthKey)]
        [Parameter(ParameterSetName = SetByParentObject,
            Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeAuthKey)]
        [ValidateNotNull]
        public System.Security.SecureString AuthKey { get; set; }

        [Parameter(ParameterSetName = SetByLinkedIntegrationRuntimeName,
            Mandatory = true, HelpMessage = HelpMessages.SharedIntegrationRuntimeResourceId)]
        [Parameter(ParameterSetName = SetByLinkedIntegrationRuntimeResourceId,
            Mandatory = true, HelpMessage = HelpMessages.SharedIntegrationRuntimeResourceId)]
        [Parameter(ParameterSetName = SetByLinkedIntegrationRuntimeObject,
            Mandatory = true, HelpMessage = HelpMessages.SharedIntegrationRuntimeResourceId)]
        [Parameter(ParameterSetName = SetByLinkedIntegrationRuntimeParentObject,
            Mandatory = true, HelpMessage = HelpMessages.SharedIntegrationRuntimeResourceId)]
        [ValidateNotNullOrEmpty]
        public string SharedIntegrationRuntimeResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.DontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = InputObject.ResourceGroupName;
                this.WorkspaceName = InputObject.WorkspaceName;
                this.Name = InputObject.Name;
            }

            if (string.Equals(Type, SynapseConstants.IntegrationRuntimeTypeManaged, StringComparison.OrdinalIgnoreCase))
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
                resource = SynapseAnalyticsClient.GetIntegrationRuntimeAsync(
                    ResourceGroupName,
                    WorkspaceName,
                    Name).ConfigureAwait(true).GetAwaiter().GetResult().IntegrationRuntime;

                isUpdate = true;
                if (Type != null && (resource.Properties is ManagedIntegrationRuntime ^
                    Type.Equals(SynapseConstants.IntegrationRuntimeTypeManaged, StringComparison.OrdinalIgnoreCase)))
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
                    if (Type.Equals(SynapseConstants.IntegrationRuntimeTypeManaged, StringComparison.OrdinalIgnoreCase))
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
                WorkspaceName = WorkspaceName,
                Name = Name,
                IsUpdate = isUpdate,
                IntegrationRuntimeResource = resource,
                Force = Force.IsPresent,
                ConfirmAction = base.ConfirmAction
            };

            WriteObject(SynapseAnalyticsClient.CreateOrUpdateIntegrationRuntime(parameters));
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

            if (integrationRuntime.ComputeProperties?.VNetProperties == null
                || (string.IsNullOrWhiteSpace(integrationRuntime.ComputeProperties.VNetProperties.VNetId)
                    && string.IsNullOrWhiteSpace(integrationRuntime.ComputeProperties.VNetProperties.Subnet)))
            {
                // When no previous VNet set, both VNetId and Subnet must be present
                if (!string.IsNullOrWhiteSpace(VNetId) && !string.IsNullOrWhiteSpace(Subnet))
                {
                    // Both VNetId and Subnet are set
                    if (integrationRuntime.ComputeProperties == null)
                    {
                        integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                    }

                    integrationRuntime.ComputeProperties.VNetProperties = new IntegrationRuntimeVNetProperties()
                    {
                        VNetId = VNetId,
                        Subnet = Subnet
                    };
                }
                else if (string.IsNullOrWhiteSpace(VNetId) ^ string.IsNullOrWhiteSpace(Subnet))
                {
                    // Only one of the two pramaters is set
                    throw new PSArgumentException(string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.IntegrationRuntimeInvalidVnet),
                        "Type");
                }
            }
            else
            {
                // We have VNet properties set, then we are able to change VNetId or Subnet individually now.
                // Could be empty. If user input empty, then convert it to null. If user want to remove VNet settings, input both with empty string.
                if (VNetId != null)
                {
                    integrationRuntime.ComputeProperties.VNetProperties.VNetId = VNetId.IsEmptyOrWhiteSpace() ? null : VNetId;
                }
                if (Subnet != null)
                {
                    integrationRuntime.ComputeProperties.VNetProperties.Subnet = Subnet.IsEmptyOrWhiteSpace() ? null : Subnet;
                }

                // Make sure both VNetId and Subnet are present, or both null
                if (string.IsNullOrWhiteSpace(integrationRuntime.ComputeProperties.VNetProperties.VNetId)
                    ^ string.IsNullOrWhiteSpace(integrationRuntime.ComputeProperties.VNetProperties.Subnet))
                {
                    throw new PSArgumentException(string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.IntegrationRuntimeInvalidVnet),
                        "Type");
                }
            }

            if (!string.IsNullOrWhiteSpace(DataFlowComputeType) || DataFlowCoreCount != null || DataFlowTimeToLive != null)
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
            }

            if (PublicIP != null)
            {
                if (string.IsNullOrWhiteSpace(VNetId))
                {
                    throw new PSArgumentException(string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.IntegrationRuntimeVNetNotProvided),
                        "VNetId");
                }

                if (PublicIP.Length != 2)
                {
                    throw new PSArgumentException(string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.InvalidPublicIPCount),
                        "PublicIPs");
                }

                integrationRuntime.ComputeProperties.VNetProperties.PublicIPs = PublicIP;
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

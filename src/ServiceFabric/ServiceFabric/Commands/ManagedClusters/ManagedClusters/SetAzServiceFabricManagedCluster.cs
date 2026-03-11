// ----------------------------------------------------------------------------------
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
using System.Collections;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedCluster", DefaultParameterSetName = ByObj, SupportsShouldProcess = true), OutputType(typeof(PSManagedCluster))]
    public class SetAzServiceFabricManagedCluster : ServiceFabricManagedCmdletBase
    {
        protected const string WithParamsByName = "WithParamsByName";
        protected const string WithParamsById = "ByNameById";
        protected const string ByObj = "ByObj";

        #region Params

        #region Common params

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = WithParamsByName,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = WithParamsByName,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = WithParamsById,
            HelpMessage = "Managed Cluster resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = ByObj,
            HelpMessage = "Managed Cluster resource")]
        [ValidateNotNull]
        public PSManagedCluster InputObject { get; set; }

        #endregion

        #region Upgrade params

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Cluster code version upgrade mode. Automatic or Manual.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Cluster code version upgrade mode. Automatic or Manual.")]
        public Models.ClusterUpgradeMode? UpgradeMode { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Cluster code version. Only use if upgrade mode is Manual.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Cluster code version. Only use if upgrade mode is Manual.")]
        public string CodeVersion { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Enables automatic OS upgrade for node types created using OS images with version 'latest'. The default value for this setting is false.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Enables automatic OS upgrade for node types created using OS images with version 'latest'. The default value for this setting is false.")]
        public bool? EnableAutoOsUpgrade { get; set; }

        #endregion

        #region Network and Infrastructure Properties

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Port used for http connections to the cluster. Default: 19080.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Port used for http connections to the cluster. Default: 19080.")]
        public int? HttpGatewayConnectionPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Port used for client connections to the cluster. Default: 19000.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Port used for client connections to the cluster. Default: 19000.")]
        public int? ClientConnectionPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Cluster's dns name.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Cluster's dns name.")]
        public string DnsName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "This property is the entry point to using a public CA cert for your cluster cert. It specifies the level of reuse allowed for the custom FQDN created, matching the subject of the public CA cert.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "This property is the entry point to using a public CA cert for your cluster cert. It specifies the level of reuse allowed for the custom FQDN created, matching the subject of the public CA cert.")]
        public string AutoGeneratedDomainNameLabelScope { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "List of add-on features to enable on the cluster.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "List of add-on features to enable on the cluster.")]
        public string[] AddonFeature { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Specify the resource id of a DDoS network protection plan that will be associated with the virtual network of the cluster.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Specify the resource id of a DDoS network protection plan that will be associated with the virtual network of the cluster.")]
        public string DdosProtectionPlanId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Specify the resource ID of the public IP prefix that the load balancer will allocate a public IP address from.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Specify the resource ID of the public IP prefix that the load balancer will allocate a public IP address from.")]
        public string PublicIPPrefixId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Specify the resource ID of the IPv6 public IP prefix that the load balancer will allocate an IPv6 public IP address from.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Specify the resource ID of the IPv6 public IP prefix that the load balancer will allocate an IPv6 public IP address from.")]
        public string PublicIPv6PrefixId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "The VM image used to create cluster nodes.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "The VM image used to create cluster nodes.")]
        public string VMImage { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "The number of outbound ports allocated for SNAT for each node in the backend pool of the default load balancer.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "The number of outbound ports allocated for SNAT for each node in the backend pool of the default load balancer.")]
        public int? AllocatedOutboundPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Setting this to true enables outbound-only node types.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Setting this to true enables outbound-only node types.")]
        public bool? EnableOutboundOnlyNodeTypes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Setting this to true skips the assignment of managed NSG to the cluster's subnet.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Setting this to true skips the assignment of managed NSG to the cluster's subnet.")]
        public bool? SkipManagedNsgAssignment { get; set; }

        #endregion

        #region Security and Authentication Properties

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Setting this to true enables RDP access to the VM. The default NSG rule opens RDP port to Internet which can be overridden with custom Network Security Rules. The default value for this setting is false.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Setting this to true enables RDP access to the VM. The default NSG rule opens RDP port to Internet which can be overridden with custom Network Security Rules. The default value for this setting is false.")]
        public bool? AllowRdpAccess { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Azure active directory client application id.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Azure active directory client application id.")]
        public string AzureActiveDirectoryClientApplication { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Azure active directory cluster application id.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Azure active directory cluster application id.")]
        public string AzureActiveDirectoryClusterApplication { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Azure active directory tenant id.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Azure active directory tenant id.")]
        public string AzureActiveDirectoryTenantId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "If true, token-based authentication is not allowed on the HttpGatewayEndpoint. This is required to support TLS versions 1.3 and above.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "If true, token-based authentication is not allowed on the HttpGatewayEndpoint. This is required to support TLS versions 1.3 and above.")]
        public bool? EnableHttpGatewayExclusiveAuthMode { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "The port used for token-auth based HTTPS connections to the cluster. Cannot be set to the same port as HttpGatewayConnectionPort.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "The port used for token-auth based HTTPS connections to the cluster. Cannot be set to the same port as HttpGatewayConnectionPort.")]
        public int? HttpGatewayTokenAuthConnectionPort { get; set; }

        #endregion

        #region Health Policy Properties

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "The maximum allowed percentage of unhealthy applications before reporting an error.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "The maximum allowed percentage of unhealthy applications before reporting an error.")]
        public int? MaxPercentUnhealthyApplications { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "The maximum allowed percentage of unhealthy nodes before reporting an error.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "The maximum allowed percentage of unhealthy nodes before reporting an error.")]
        public int? MaxPercentUnhealthyNodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Number of unused versions per application type to keep.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Number of unused versions per application type to keep.")]
        public int? MaxUnusedVersionsToKeep { get; set; }

        #endregion

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Specify the tags as key/value pairs.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Specify the tags as key/value pairs.")]
        public Hashtable Tag { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            this.SetParams();
            if (ShouldProcess(target: this.Name, action: string.Format("Update cluster {0} on resource group: {1}", this.Name, this.ResourceGroupName)))
            {
                try
                {
                    ManagedCluster updatedClusterParams = null;
                    switch (ParameterSetName)
                    {
                        case WithParamsByName:
                        case WithParamsById:
                            updatedClusterParams = this.GetUpdatedClusterParams();
                            break;
                        case ByObj:
                            updatedClusterParams = this.InputObject;
                            break;
                        default:
                            throw new ArgumentException("Invalid parameter set", ParameterSetName);
                    }

                    var beginRequestResponse = this.SfrpMcClient.ManagedClusters.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, updatedClusterParams)
                        .GetAwaiter().GetResult();

                    var cluster = this.PollLongRunningOperation(beginRequestResponse);

                    WriteObject(new PSManagedCluster(cluster), false);
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }

        private ManagedCluster GetUpdatedClusterParams()
        {
            var currentCluster = this.SfrpMcClient.ManagedClusters.Get(this.ResourceGroupName, this.Name);
            this.ValidateParams(currentCluster);

            if (this.UpgradeMode.HasValue)
            {
                currentCluster.ClusterUpgradeMode = this.UpgradeMode.ToString();
            }

            if (!string.IsNullOrEmpty(this.CodeVersion))
            {
                currentCluster.ClusterCodeVersion = this.CodeVersion;
            }

            if (this.ClientConnectionPort.HasValue)
            {
                currentCluster.ClientConnectionPort = ClientConnectionPort;
            }

            if (!string.IsNullOrEmpty(this.DnsName))
            {
                currentCluster.DnsName = DnsName;
            }

            if (this.IsParameterBound(c => c.Tag))
            {
                currentCluster.Tags = this.Tag?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string);
            }

            if (string.IsNullOrEmpty(currentCluster.PublicIPPrefixId))
            {
                currentCluster.PublicIPPrefixId = null;
            }

            if (this.IsParameterBound(c => c.AutoGeneratedDomainNameLabelScope))
            {
                currentCluster.AutoGeneratedDomainNameLabelScope = this.AutoGeneratedDomainNameLabelScope;
            }

            if (this.IsParameterBound(c => c.EnableAutoOsUpgrade))
            {
                currentCluster.EnableAutoOSUpgrade = this.EnableAutoOsUpgrade;
            }

            if (this.IsParameterBound(c => c.AllowRdpAccess))
            {
                currentCluster.AllowRdpAccess = this.AllowRdpAccess;
            }

            // Update Network and Infrastructure properties
            if (this.IsParameterBound(c => c.AddonFeature))
            {
                currentCluster.AddonFeatures = this.AddonFeature?.ToList();
            }

            if (this.IsParameterBound(c => c.DdosProtectionPlanId))
            {
                currentCluster.DdosProtectionPlanId = this.DdosProtectionPlanId;
            }

            if (this.IsParameterBound(c => c.PublicIPPrefixId))
            {
                currentCluster.PublicIPPrefixId = this.PublicIPPrefixId;
            }

            if (this.IsParameterBound(c => c.PublicIPv6PrefixId))
            {
                currentCluster.PublicIPv6PrefixId = this.PublicIPv6PrefixId;
            }

            if (this.IsParameterBound(c => c.VMImage))
            {
                currentCluster.VMImage = this.VMImage;
            }

            if (this.IsParameterBound(c => c.AllocatedOutboundPort))
            {
                currentCluster.AllocatedOutboundPorts = this.AllocatedOutboundPort;
            }

            if (this.IsParameterBound(c => c.EnableOutboundOnlyNodeTypes))
            {
                currentCluster.EnableOutboundOnlyNodeTypes = this.EnableOutboundOnlyNodeTypes;
            }

            if (this.IsParameterBound(c => c.SkipManagedNsgAssignment))
            {
                currentCluster.SkipManagedNsgAssignment = this.SkipManagedNsgAssignment;
            }

            // Update Security and Authentication properties
            if (this.IsParameterBound(c => c.AzureActiveDirectoryClientApplication) ||
                this.IsParameterBound(c => c.AzureActiveDirectoryClusterApplication) ||
                this.IsParameterBound(c => c.AzureActiveDirectoryTenantId))
            {
                // Create or update the Azure Active Directory configuration
                string clientApp = this.IsParameterBound(c => c.AzureActiveDirectoryClientApplication)
                    ? this.AzureActiveDirectoryClientApplication
                    : currentCluster.AzureActiveDirectory?.ClientApplication;
                string clusterApp = this.IsParameterBound(c => c.AzureActiveDirectoryClusterApplication)
                    ? this.AzureActiveDirectoryClusterApplication
                    : currentCluster.AzureActiveDirectory?.ClusterApplication;
                string tenantId = this.IsParameterBound(c => c.AzureActiveDirectoryTenantId)
                    ? this.AzureActiveDirectoryTenantId
                    : currentCluster.AzureActiveDirectory?.TenantId;

                if (!string.IsNullOrEmpty(clientApp) && !string.IsNullOrEmpty(clusterApp) && !string.IsNullOrEmpty(tenantId))
                {
                    currentCluster.AzureActiveDirectory = new AzureActiveDirectory(
                        clientApplication: clientApp,
                        clusterApplication: clusterApp,
                        tenantId: tenantId
                    );
                }
            }

            if (this.IsParameterBound(c => c.EnableHttpGatewayExclusiveAuthMode))
            {
                currentCluster.EnableHttpGatewayExclusiveAuthMode = this.EnableHttpGatewayExclusiveAuthMode;
            }

            if (this.IsParameterBound(c => c.HttpGatewayTokenAuthConnectionPort))
            {
                currentCluster.HttpGatewayTokenAuthConnectionPort = this.HttpGatewayTokenAuthConnectionPort;
            }

            // Update Health Policy properties
            if (this.IsParameterBound(c => c.MaxPercentUnhealthyApplications) ||
                this.IsParameterBound(c => c.MaxPercentUnhealthyNodes))
            {
                if (currentCluster.UpgradeDescription == null)
                {
                    currentCluster.UpgradeDescription = new ClusterUpgradePolicy();
                }

                if (currentCluster.UpgradeDescription.HealthPolicy == null)
                {
                    currentCluster.UpgradeDescription.HealthPolicy = new ClusterHealthPolicy();
                }

                if (this.IsParameterBound(c => c.MaxPercentUnhealthyApplications))
                {
                    currentCluster.UpgradeDescription.HealthPolicy.MaxPercentUnhealthyApplications = this.MaxPercentUnhealthyApplications.Value;
                }

                if (this.IsParameterBound(c => c.MaxPercentUnhealthyNodes))
                {
                    currentCluster.UpgradeDescription.HealthPolicy.MaxPercentUnhealthyNodes = this.MaxPercentUnhealthyNodes.Value;
                }
            }

            if (this.IsParameterBound(c => c.MaxUnusedVersionsToKeep))
            {
                currentCluster.ApplicationTypeVersionsCleanupPolicy = new ApplicationTypeVersionsCleanupPolicy(
                    maxUnusedVersionsToKeep: this.MaxUnusedVersionsToKeep.Value
                );
            }

            return currentCluster;
        }

        private void ValidateParams(ManagedCluster currentCluster)
        {
            if (!string.IsNullOrEmpty(this.CodeVersion))
            {
                // If UpgradeMode is being set in this invocation, check it directly;
                // otherwise fall back to the current cluster's mode.
                string effectiveMode = this.UpgradeMode.HasValue
                    ? this.UpgradeMode.ToString()
                    : currentCluster.ClusterUpgradeMode;

                if (string.Equals(effectiveMode, Models.ClusterUpgradeMode.Automatic.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    throw new PSArgumentException("CodeVersion should only be used when upgrade mode is set to Manual.", "CodeVersion");
                }
            }
        }

        private void SetParams()
        {
            switch (ParameterSetName)
            {
                case ByObj:
                    if (string.IsNullOrEmpty(this.InputObject?.Id))
                    {
                        throw new ArgumentException("ResourceId is null.");
                    }

                    SetParametersByResourceId(this.InputObject.Id);
                    break;

                case WithParamsById:
                    SetParametersByResourceId(this.ResourceId);
                    break;
            }
        }

        private void SetParametersByResourceId(string resourceId)
        {
            this.GetParametersByResourceId(resourceId, Constants.ManagedClusterProvider, out string resourceGroup, out string resourceName);
            this.ResourceGroupName = resourceGroup;
            this.Name = resourceName;
        }
    }
}

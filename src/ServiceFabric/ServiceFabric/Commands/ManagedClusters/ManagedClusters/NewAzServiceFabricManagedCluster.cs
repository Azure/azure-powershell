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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Sku = Microsoft.Azure.Management.ServiceFabricManagedClusters.Models.Sku;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedCluster", DefaultParameterSetName = ClientCertByTp, SupportsShouldProcess = true), OutputType(typeof(PSManagedCluster))]
    public class NewAzServiceFabricManagedCluster : ServiceFabricManagedCmdletBase
    {
        protected const string ClientCertByTp = "ClientCertByTp";
        protected const string ClientCertByCn = "ClientCertByCn";

        #region Params

        #region Common params

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ClientCertByTp, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ClientCertByCn, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ClientCertByTp, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ClientCertByCn, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ClientCertByTp, HelpMessage = "The resource location")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ClientCertByCn, HelpMessage = "The resource location")]
        [LocationCompleter(Constants.ManagedClustersFullType)]
        public string Location { get; set; }

        #endregion

        #region Upgrade params

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Cluster service fabric code version upgrade mode. Automatic or Manual.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Cluster service fabric code version upgrade mode. Automatic or Manual.")]
        [Alias("ClusterUpgradeMode")]
        public Models.ClusterUpgradeMode UpgradeMode { get; set; } = Models.ClusterUpgradeMode.Automatic;

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Cluster service fabric code version. Only use if upgrade mode is Manual.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Cluster service fabric code version. Only use if upgrade mode is Manual.")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterCodeVersion")]
        public string CodeVersion { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Indicates when new cluster runtime version upgrades will be applied after they are released. By default is Wave0.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Indicates when new cluster runtime version upgrades will be applied after they are released. By default is Wave0.")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterUpgradeCadence")]
        public PSClusterUpgradeCadence UpgradeCadence { get; set; } = PSClusterUpgradeCadence.Wave0;

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Enables automatic OS upgrade for node types created using OS images with version 'latest'. The default value for this setting is false.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Enables automatic OS upgrade for node types created using OS images with version 'latest'. The default value for this setting is false.")]
        public SwitchParameter EnableAutoOsUpgrade { get; set; }

        #endregion

        #region Client cert params

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp,
                   HelpMessage = "Use to specify if the client certificate has administrator level.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn,
                   HelpMessage = "Use to specify if the client certificate has administrator level.")]
        public SwitchParameter ClientCertIsAdmin { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ClientCertByTp,
                   HelpMessage = "Client certificate thumbprint.")]
        [ValidateNotNullOrEmpty()]
        public string ClientCertThumbprint { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ClientCertByCn,
                   HelpMessage = "Client certificate common name.")]
        [ValidateNotNullOrEmpty()]
        public string ClientCertCommonName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn,
                   HelpMessage = "List of Issuer thumbprints for the client certificate. Only use in combination with ClientCertCommonName.")]
        public string[] ClientCertIssuerThumbprint { get; set; }

        #endregion

        #region Cluster configuration params

        [Parameter(Mandatory = true, ParameterSetName = ClientCertByTp, HelpMessage = "Admin password used for the virtual machines.")]
        [Parameter(Mandatory = true, ParameterSetName = ClientCertByCn, HelpMessage = "Admin password used for the virtual machines.")]
        [ValidateNotNullOrEmpty()]
        public SecureString AdminPassword { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Admin user used for the virtual machines. Default: vmadmin.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Admin user used for the virtual machines. Default: vmadmin.")]
        public string AdminUserName { get; set; } = "vmadmin";

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Cluster's dns name.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Cluster's dns name.")]
        public string DnsName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp,
            HelpMessage = "Cluster's Sku, the options are Basic: it will have a minimum of 3 seed nodes and only allows 1 node type and Standard: it will have a minimum of 5 seed nodes and allows multiple node types.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn,
            HelpMessage = "Cluster's Sku, the options are Basic: it will have a minimum of 3 seed nodes and only allows 1 node type and Standard: it will have a minimum of 5 seed nodes and allows multiple node types.")]
        public ManagedClusterSku Sku { get; set; } = ManagedClusterSku.Basic;

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "If Specify The cluster will be crated with service test vmss extension.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "If Specify The cluster will be crated with service test vmss extension.")]
        public SwitchParameter UseTestExtension { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Indicates if the cluster has zone resiliency.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Indicates if the cluster has zone resiliency.")]
        public SwitchParameter ZonalResiliency { get; set; }

        #endregion

        #region Network and Infrastructure Properties

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Port used for http connections to the cluster. Default: 19080.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Port used for http connections to the cluster. Default: 19080.")]
        public int HttpGatewayConnectionPort { get; set; } = 19080;

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Port used for client connections to the cluster. Default: 19000.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Port used for client connections to the cluster. Default: 19000.")]
        public int ClientConnectionPort { get; set; } = 19000;

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "This property is the entry point to using a public CA cert for your cluster cert. It specifies the level of reuse allowed for the custom FQDN created, matching the subject of the public CA cert.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "This property is the entry point to using a public CA cert for your cluster cert. It specifies the level of reuse allowed for the custom FQDN created, matching the subject of the public CA cert.")]
        public string AutoGeneratedDomainNameLabelScope { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "List of add-on features to enable on the cluster.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "List of add-on features to enable on the cluster.")]
        public string[] AddonFeature { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Specify the resource id of a DDoS network protection plan that will be associated with the virtual network of the cluster.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Specify the resource id of a DDoS network protection plan that will be associated with the virtual network of the cluster.")]
        public string DdosProtectionPlanId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Setting this to true creates IPv6 address space for the default VNet used by the cluster. This setting cannot be changed once the cluster is created. The default value for this setting is false.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Setting this to true creates IPv6 address space for the default VNet used by the cluster. This setting cannot be changed once the cluster is created. The default value for this setting is false.")]
        public SwitchParameter EnableIpv6 { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Setting this to true will link the IPv4 address as the ServicePublicIP of the IPv6 address. It can only be set to True if IPv6 is enabled on the cluster.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Setting this to true will link the IPv4 address as the ServicePublicIP of the IPv6 address. It can only be set to True if IPv6 is enabled on the cluster.")]
        public SwitchParameter EnableServicePublicIP { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Specify the resource ID of the public IP prefix that the load balancer will allocate a public IP address from.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Specify the resource ID of the public IP prefix that the load balancer will allocate a public IP address from.")]
        public string PublicIPPrefixId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Specify the resource ID of the IPv6 public IP prefix that the load balancer will allocate an IPv6 public IP address from.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Specify the resource ID of the IPv6 public IP prefix that the load balancer will allocate an IPv6 public IP address from.")]
        public string PublicIPv6PrefixId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Specify the resource ID of the subnet for the cluster to use.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Specify the resource ID of the subnet for the cluster to use.")]
        public string SubnetId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Setting this to true enables the use of custom VNet for the cluster.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Setting this to true enables the use of custom VNet for the cluster.")]
        public SwitchParameter UseCustomVnet { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "The VM image used to create cluster nodes. Default: Windows.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "The VM image used to create cluster nodes. Default: Windows.")]
        public string VMImage { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "The number of outbound ports allocated for SNAT for each node in the backend pool of the default load balancer. The default value is 0 which provides dynamic port allocation based on pool size.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "The number of outbound ports allocated for SNAT for each node in the backend pool of the default load balancer. The default value is 0 which provides dynamic port allocation based on pool size.")]
        public int? AllocatedOutboundPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Setting this to true enables outbound-only node types. These node types will not have load balancing rules associated with them.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Setting this to true enables outbound-only node types. These node types will not have load balancing rules associated with them.")]
        public SwitchParameter EnableOutboundOnlyNodeTypes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Setting this to true skips the assignment of managed NSG to the cluster's subnet.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Setting this to true skips the assignment of managed NSG to the cluster's subnet.")]
        public SwitchParameter SkipManagedNsgAssignment { get; set; }

        #endregion

        #region Security and Authentication Properties

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Setting this to true enables RDP access to the VM. The default NSG rule opens RDP port to Internet which can be overridden with custom Network Security Rules. The default value for this setting is false.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Setting this to true enables RDP access to the VM. The default NSG rule opens RDP port to Internet which can be overridden with custom Network Security Rules. The default value for this setting is false.")]
        public SwitchParameter AllowRdpAccess { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Azure active directory client application id.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Azure active directory client application id.")]
        public string AzureActiveDirectoryClientApplication { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Azure active directory cluster application id.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Azure active directory cluster application id.")]
        public string AzureActiveDirectoryClusterApplication { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Azure active directory tenant id.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Azure active directory tenant id.")]
        public string AzureActiveDirectoryTenantId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "If true, token-based authentication is not allowed on the HttpGatewayEndpoint. This is required to support TLS versions 1.3 and above. If token-based authentication is used, HttpGatewayTokenAuthConnectionPort must be defined.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "If true, token-based authentication is not allowed on the HttpGatewayEndpoint. This is required to support TLS versions 1.3 and above. If token-based authentication is used, HttpGatewayTokenAuthConnectionPort must be defined.")]
        public SwitchParameter EnableHttpGatewayExclusiveAuthMode { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "The port used for token-auth based HTTPS connections to the cluster. Cannot be set to the same port as HttpGatewayEndpoint.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "The port used for token-auth based HTTPS connections to the cluster. Cannot be set to the same port as HttpGatewayEndpoint.")]
        public int? HttpGatewayTokenAuthConnectionPort { get; set; }

        #endregion

        #region Health Policy Properties

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "The maximum allowed percentage of unhealthy applications before reporting an error. For example, to allow 10% of applications to be unhealthy, this value would be 10.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "The maximum allowed percentage of unhealthy applications before reporting an error. For example, to allow 10% of applications to be unhealthy, this value would be 10.")]
        public int? MaxPercentUnhealthyApplications { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "The maximum allowed percentage of unhealthy nodes before reporting an error. For example, to allow 10% of nodes to be unhealthy, this value would be 10.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "The maximum allowed percentage of unhealthy nodes before reporting an error. For example, to allow 10% of nodes to be unhealthy, this value would be 10.")]
        public int? MaxPercentUnhealthyNodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Number of unused versions per application type to keep.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Number of unused versions per application type to keep.")]
        public int? MaxUnusedVersionsToKeep { get; set; }

        #endregion

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Specify the tags as key/value pairs.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Specify the tags as key/value pairs.")]
        public Hashtable Tag { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.Name, action: string.Format("Create new managed cluster {0} in resource group {1}", this.Name, this.ResourceGroupName)))
            {
                try
                {
                    ManagedCluster cluster = SafeGetResource(() => this.SfrpMcClient.ManagedClusters.Get(this.ResourceGroupName, this.Name));
                    if (cluster != null)
                    {
                        WriteError(new ErrorRecord(new InvalidOperationException(string.Format("Cluster '{0}' already exists.", this.Name)),
                            "ResourceAlreadyExists", ErrorCategory.InvalidOperation, null));
                    }
                    else
                    {
                        // Create resource group if it doesn't exist
                        var rg = SafeGetResource(() => this.ResourcesClient.ResourceGroups.Get(this.ResourceGroupName));
                        if (rg == null)
                        {
                            WriteVerboseWithTimestamp(string.Format("Creating resource group {0} on {1}", this.ResourceGroupName, this.Location));
                            this.ResourcesClient.ResourceGroups.CreateOrUpdate(this.ResourceGroupName, new ResourceGroup(this.Location));
                        }

                        ManagedCluster newClusterParams = this.GetNewManagedClusterParameters();
                        var beginRequestResponse = this.SfrpMcClient.ManagedClusters.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, newClusterParams)
                            .GetAwaiter().GetResult();

                        cluster = this.PollLongRunningOperation(beginRequestResponse);

                        WriteObject(new PSManagedCluster(cluster), false);
                    }
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }

        private ManagedCluster GetNewManagedClusterParameters()
        {
            if (this.UpgradeMode == Models.ClusterUpgradeMode.Manual && string.IsNullOrEmpty(this.CodeVersion))
            {
                throw new PSArgumentException("UpgradeMode is set to manual but CodeVersion is not set. Please specify CodeVersion.", "CodeVersion");
            }

            if (this.UpgradeMode == Models.ClusterUpgradeMode.Automatic && !string.IsNullOrEmpty(this.CodeVersion))
            {
                throw new PSArgumentException("CodeVersion should only be used when upgrade mode is set to Manual.", "CodeVersion");
            }

            List<ClientCertificate> clientCerts = new List<ClientCertificate>();
            if (this.ParameterSetName == ClientCertByTp)
            {
                clientCerts.Add(new ClientCertificate()
                {
                    Thumbprint = this.ClientCertThumbprint,
                    IsAdmin = this.ClientCertIsAdmin.IsPresent
                });
            }
            else if (this.ParameterSetName == ClientCertByCn)
            {
                clientCerts.Add(new ClientCertificate()
                {
                    CommonName = this.ClientCertCommonName,
                    IssuerThumbprint = this.ClientCertIssuerThumbprint != null ? string.Join(",", this.ClientCertIssuerThumbprint) : null,
                    IsAdmin = this.ClientCertIsAdmin.IsPresent
                });
            }

            if (string.IsNullOrEmpty(this.DnsName))
            {
                this.DnsName = this.Name;
            }

            var newCluster = new ManagedCluster(
                location: this.Location,
                dnsName: this.DnsName,
                clients: clientCerts,
                adminUserName: this.AdminUserName,
                adminPassword: this.AdminPassword.ConvertToString(),
                httpGatewayConnectionPort: this.HttpGatewayConnectionPort,
                clientConnectionPort: this.ClientConnectionPort,
                sku: new Sku(name: this.Sku.ToString()),
                clusterUpgradeMode: this.UpgradeMode.ToString(),
                clusterUpgradeCadence: this.UpgradeCadence.ToString(),
                zonalResiliency: this.ZonalResiliency.IsPresent,
                autoGeneratedDomainNameLabelScope: this.AutoGeneratedDomainNameLabelScope,
                enableAutoOSUpgrade: this.EnableAutoOsUpgrade.IsPresent,
                allowRdpAccess: this.AllowRdpAccess.IsPresent,
                tags: this.Tag?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string)
            );

            // Set additional Network and Infrastructure properties
            if (this.AddonFeature != null)
            {
                newCluster.AddonFeatures = this.AddonFeature.ToList();
            }

            if (!string.IsNullOrEmpty(this.DdosProtectionPlanId))
            {
                newCluster.DdosProtectionPlanId = this.DdosProtectionPlanId;
            }

            if (this.EnableIpv6.IsPresent)
            {
                newCluster.EnableIpv6 = true;
            }

            if (this.EnableServicePublicIP.IsPresent)
            {
                newCluster.EnableServicePublicIP = true;
            }

            if (!string.IsNullOrEmpty(this.PublicIPPrefixId))
            {
                newCluster.PublicIPPrefixId = this.PublicIPPrefixId;
            }

            if (!string.IsNullOrEmpty(this.PublicIPv6PrefixId))
            {
                newCluster.PublicIPv6PrefixId = this.PublicIPv6PrefixId;
            }

            if (!string.IsNullOrEmpty(this.SubnetId))
            {
                newCluster.SubnetId = this.SubnetId;
            }

            if (this.UseCustomVnet.IsPresent)
            {
                newCluster.UseCustomVnet = true;
            }

            if (!string.IsNullOrEmpty(this.VMImage))
            {
                newCluster.VMImage = this.VMImage;
            }

            if (this.AllocatedOutboundPort.HasValue)
            {
                newCluster.AllocatedOutboundPorts = this.AllocatedOutboundPort;
            }

            if (this.EnableOutboundOnlyNodeTypes.IsPresent)
            {
                newCluster.EnableOutboundOnlyNodeTypes = true;
            }

            if (this.SkipManagedNsgAssignment.IsPresent)
            {
                newCluster.SkipManagedNsgAssignment = true;
            }

            // Set Security and Authentication properties
            bool hasAnyAadParam = !string.IsNullOrEmpty(this.AzureActiveDirectoryClientApplication) ||
                                 !string.IsNullOrEmpty(this.AzureActiveDirectoryClusterApplication) ||
                                 !string.IsNullOrEmpty(this.AzureActiveDirectoryTenantId);

            if (hasAnyAadParam)
            {
                newCluster.AzureActiveDirectory = new AzureActiveDirectory(
                    clientApplication: this.AzureActiveDirectoryClientApplication,
                    clusterApplication: this.AzureActiveDirectoryClusterApplication,
                    tenantId: this.AzureActiveDirectoryTenantId
                );
            }

            if (this.EnableHttpGatewayExclusiveAuthMode.IsPresent)
            {
                newCluster.EnableHttpGatewayExclusiveAuthMode = true;
            }

            if (this.HttpGatewayTokenAuthConnectionPort.HasValue)
            {
                newCluster.HttpGatewayTokenAuthConnectionPort = this.HttpGatewayTokenAuthConnectionPort;
            }

            // Set Health Policy properties
            if (this.MaxPercentUnhealthyApplications.HasValue || this.MaxPercentUnhealthyNodes.HasValue)
            {
                if (newCluster.UpgradeDescription == null)
                {
                    newCluster.UpgradeDescription = new ClusterUpgradePolicy();
                }

                if (newCluster.UpgradeDescription.HealthPolicy == null)
                {
                    newCluster.UpgradeDescription.HealthPolicy = new ClusterHealthPolicy();
                }

                if (this.MaxPercentUnhealthyApplications.HasValue)
                {
                    newCluster.UpgradeDescription.HealthPolicy.MaxPercentUnhealthyApplications = this.MaxPercentUnhealthyApplications.Value;
                }

                if (this.MaxPercentUnhealthyNodes.HasValue)
                {
                    newCluster.UpgradeDescription.HealthPolicy.MaxPercentUnhealthyNodes = this.MaxPercentUnhealthyNodes.Value;
                }
            }

            if (this.MaxUnusedVersionsToKeep.HasValue)
            {
                newCluster.ApplicationTypeVersionsCleanupPolicy = new ApplicationTypeVersionsCleanupPolicy(
                    maxUnusedVersionsToKeep: this.MaxUnusedVersionsToKeep.Value
                );
            }

            if (this.UpgradeMode == Models.ClusterUpgradeMode.Manual)
            {
                newCluster.ClusterCodeVersion = this.CodeVersion;
            }

            return newCluster;
        }
    }
}

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

        [Parameter(Mandatory = true, ParameterSetName = ClientCertByTp, HelpMessage = "Admin password used for the virtual machines.")]
        [Parameter(Mandatory = true, ParameterSetName = ClientCertByCn, HelpMessage = "Admin password used for the virtual machines.")]
        [ValidateNotNullOrEmpty()]
        public SecureString AdminPassword { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Admin user used for the virtual machines. Default: vmadmin.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Admin user used for the virtual machines. Default: vmadmin.")]
        public string AdminUserName { get; set; } = "vmadmin";

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Port used for http connections to the cluster. Default: 19080.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Port used for http connections to the cluster. Default: 19080.")]
        public int HttpGatewayConnectionPort { get; set; } = 19080;

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp, HelpMessage = "Port used for client connections to the cluster. Default: 19000.")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn, HelpMessage = "Port used for client connections to the cluster. Default: 19000.")]
        public int ClientConnectionPort { get; set; } = 19000;

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
                tags: this.Tag?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string)
            );

            if (this.UpgradeMode == Models.ClusterUpgradeMode.Manual)
            {
                newCluster.ClusterCodeVersion = this.CodeVersion;
            }

            return newCluster;
        }
    }
}

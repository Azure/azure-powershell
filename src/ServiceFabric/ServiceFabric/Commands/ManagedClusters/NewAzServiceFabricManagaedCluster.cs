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
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Sku = Microsoft.Azure.Management.ServiceFabric.Models.Sku;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedCluster", SupportsShouldProcess = true), OutputType(typeof(PSManagedCluster))]
    public class NewAzServiceFabricManagedCluster : ServiceFabricCommonCmdletBase
    {
        protected const string ClientCertByTp = "ClientCertByTp";
        protected const string ClientCertByCn = "ClientCertByCn";

        #region Params

        #region Common params

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The resource location")]
        [LocationCompleter(Constants.ManagedClustersFullType)]
        public string Location { get; set; }

        #endregion

        [Parameter(Mandatory = false, HelpMessage = "Cluster code version upgrade mode. Automatic or Manual.")]
        public ClusterUpgradeMode ClusterUpgradeMode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Cluster code version. Only use if upgrade mode is Manual.")]
        public string ClusterCodeVersion { get; set; }

        #region Client cert params

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByTp,
                   HelpMessage = "TODO: HELP")]
        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn,
                   HelpMessage = "TODO: HELP")]
        public SwitchParameter ClientCertIsAdmin { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ClientCertByTp,
                   HelpMessage = "TODO: HELP")]
        public string ClientCertThumbprint { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ClientCertByCn,
                   HelpMessage = "TODO: HELP")]
        public string ClientCertCommonName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ClientCertByCn,
                   HelpMessage = "TODO: HELP")]
        public string ClientCertIssuerThumbprint { get; set; }

        #endregion

        [Parameter(Mandatory = true, HelpMessage = "TODO: HELP")]
        public string AdminPassword { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "TODO: HELP default vmadmin")]
        public string AdminUserName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "TODO: HELP default 19080")]
        public int? HttpGatewayConnectionPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "TODO: HELP default 19000")]
        public int? ClientConnectionPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "TODO: HELP format??")]
        public string DnsName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "TODO: HELP")]
        public int? ReverseProxyEndpointPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "TODO: HELP")]
        public ManagedClusterSku Sku { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If Specify The cluster will be crated with service test vmss extension.")]
        public SwitchParameter UseTestExtension { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.ResourceGroupName, action: string.Format("Create new managed cluster. name {0}, resouce group: {1}", this.Name, this.ResourceGroupName)))
            {
                try
                {
                    // Create resouce group if it doesen't exist
                    this.ResourcesClient.ResourceGroups.CreateOrUpdate(
                        this.ResourceGroupName,
                        new ResourceGroup()
                        {
                            Location = this.Location
                        });

                    ManagedCluster newClusterParams = this.GetNewManagedClusterParameters();
                    var beginRequestResponse = this.SFRPClient.ManagedClusters.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, newClusterParams)
                        .GetAwaiter().GetResult();

                    ManagedCluster cluster = this.PollLongRunningOperation(beginRequestResponse);

                    WriteObject(new PSManagedCluster(cluster), false);
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
                    IssuerThumbprint = this.ClientCertIssuerThumbprint,
                    IsAdmin = this.ClientCertIsAdmin.IsPresent
                });
            }

            if (string.IsNullOrEmpty(this.AdminUserName))
            {
                this.AdminUserName = "vmadmin";
            }

            if (string.IsNullOrEmpty(this.DnsName))
            {
                this.DnsName = this.Name;
            }

            if (!this.HttpGatewayConnectionPort.HasValue)
            {
                this.HttpGatewayConnectionPort = 19080;
            }

            if (!this.ClientConnectionPort.HasValue)
            {
                this.ClientConnectionPort = 19000;
            }

            var newCluster = new ManagedCluster(
                location: this.Location,
                dnsName: this.DnsName,
                clusterUpgradeMode: this.ClusterUpgradeMode.ToString(),
                useTestExtension: this.UseTestExtension,
                clients: clientCerts,
                adminUserName: this.AdminUserName,
                adminPassword: this.AdminPassword,
                httpGatewayConnectionPort: this.HttpGatewayConnectionPort,
                clientConnectionPort: this.ClientConnectionPort,
                reverseProxyEndpointPort: this.ReverseProxyEndpointPort,
                sku: new Sku(name: this.Sku.ToString())
            );

            if (this.ClusterUpgradeMode == ClusterUpgradeMode.Manual)
            {
                newCluster.ClusterCodeVersion = this.ClusterCodeVersion;
            }

            return newCluster;
        }
    }
}

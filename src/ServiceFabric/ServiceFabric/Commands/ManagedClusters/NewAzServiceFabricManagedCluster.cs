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

        [Parameter(Mandatory = false, HelpMessage = "Cluster service fabric code version upgrade mode. Automatic or Manual.")]
        public ClusterUpgradeMode UpgradeMode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Cluster service fabric code version. Only use if upgrade mode is Manual.")]
        [ValidateNotNullOrEmpty()]
        public string CodeVersion { get; set; }

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
        public List<string> ClientCertIssuerThumbprint { get; set; }

        #endregion

        [Parameter(Mandatory = true, HelpMessage = "Admin password used for the virtual machines.")]
        [ValidateNotNullOrEmpty()]
        public string AdminPassword { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Admin password used for the virtual machines. Default: vmadmin.")]
        public string AdminUserName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Port used for http connections to the cluster. Default: 19080.")]
        public int? HttpGatewayConnectionPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Port used for client connections to the cluster. Default: 19000.")]
        public int? ClientConnectionPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Cluster's dns name.")]
        public string DnsName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Endpoint used by reverse proxy.")]
        public int? ReverseProxyEndpointPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Cluster's Sku, the options are Basic: it will have a minimum of 3 seed nodes and only allows 1 node type and Standard: it will have a minimum of 5 seed nodes and allows multiple node types.")]
        public ManagedClusterSku Sku { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If Specify The cluster will be crated with service test vmss extension.")]
        public SwitchParameter UseTestExtension { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.Name, action: string.Format("Create new managed cluster {0} in resouce group {1}", this.Name, this.ResourceGroupName)))
            {
                try
                {
                    ManagedCluster cluster = SafeGetResource(() => this.SFRPClient.ManagedClusters.Get(this.ResourceGroupName, this.Name));
                    if (cluster != null)
                    {
                        WriteError(new ErrorRecord(new InvalidOperationException(string.Format("Cluster '{0}' already exists.", this.Name)),
                            "ResouceAlreadyExists", ErrorCategory.InvalidOperation, null));
                    }
                    else
                    {
                        // Create resouce group if it doesn't exist
                        this.ResourcesClient.ResourceGroups.CreateOrUpdate(this.ResourceGroupName, new ResourceGroup(this.Location));

                        ManagedCluster newClusterParams = this.GetNewManagedClusterParameters();
                        var beginRequestResponse = this.SFRPClient.ManagedClusters.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, newClusterParams)
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
            if (this.UpgradeMode == ClusterUpgradeMode.Automatic && !string.IsNullOrEmpty(this.CodeVersion))
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
                clusterUpgradeMode: this.UpgradeMode.ToString(),
                useTestExtension: this.UseTestExtension,
                clients: clientCerts,
                adminUserName: this.AdminUserName,
                adminPassword: this.AdminPassword,
                httpGatewayConnectionPort: this.HttpGatewayConnectionPort,
                clientConnectionPort: this.ClientConnectionPort,
                reverseProxyEndpointPort: this.ReverseProxyEndpointPort,
                sku: new Sku(name: this.Sku.ToString())
            );

            if (this.UpgradeMode == ClusterUpgradeMode.Manual)
            {
                newCluster.ClusterCodeVersion = this.CodeVersion;
            }

            return newCluster;
        }
    }
}

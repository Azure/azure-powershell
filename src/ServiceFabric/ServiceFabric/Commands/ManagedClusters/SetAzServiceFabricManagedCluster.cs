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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedCluster", SupportsShouldProcess = true), OutputType(typeof(PSManagedCluster))]
    public class SetAzServiceFabricManagedCluster : ServiceFabricCommonCmdletBase
    {
        protected const string WithParamsByName = "WithPramsByName";
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

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Cluster code version upgrade mode. Automatic or Manual.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Cluster code version upgrade mode. Automatic or Manual.")]
        public ClusterUpgradeMode? UpgradeMode { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Cluster code version. Only use if upgrade mode is Manual.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Cluster code version. Only use if upgrade mode is Manual.")]
        public string CodeVersion { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Port used for http connections to the cluster. Default: 19080.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Port used for http connections to the cluster. Default: 19080.")]
        public int? HttpGatewayConnectionPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Port used for client connections to the cluster. Default: 19000.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Port used for client connections to the cluster. Default: 19000.")]
        public int? ClientConnectionPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Cluster's dns name.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Cluster's dns name.")]
        public string DnsName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Endpoint used by reverse proxy.")]
        [Parameter(Mandatory = false, ParameterSetName = WithParamsById, HelpMessage = "Endpoint used by reverse proxy.")]
        public int? ReverseProxyEndpointPort { get; set; }

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
                            throw new ArgumentException("Invalid parameter set {0}", ParameterSetName);
                    }

                    var beginRequestResponse = this.SFRPClient.ManagedClusters.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, updatedClusterParams)
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
            var currentCluster = this.SFRPClient.ManagedClusters.Get(this.ResourceGroupName, this.Name);
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

            if (this.ReverseProxyEndpointPort.HasValue)
            {
                currentCluster.ReverseProxyEndpointPort = ReverseProxyEndpointPort;
            }

            return currentCluster;
        }

        private void ValidateParams(ManagedCluster currentCluster)
        {
            if (this.UpgradeMode.HasValue)
            {
                if (this.UpgradeMode == ClusterUpgradeMode.Automatic)
                {
                    if (!string.IsNullOrEmpty(this.CodeVersion))
                    {
                        throw new PSArgumentException("CodeVersion should only be used when upgrade mode is set to Manual.", "CodeVersion");
                    }
                }
            }
            else if (!string.IsNullOrEmpty(this.CodeVersion))
            {
                Enum.TryParse(currentCluster.ClusterUpgradeMode, out ClusterUpgradeMode upgradeMode);
                if (upgradeMode == ClusterUpgradeMode.Automatic)
                {
                    throw new PSArgumentException("Currently the cluster upgrade mode is set to Automatic and CodeVersion should only be used when upgrade mode is set to Manual.", "CodeVersion");
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
                default:
                    throw new ArgumentException("Invalid parameter set {0}", ParameterSetName);
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

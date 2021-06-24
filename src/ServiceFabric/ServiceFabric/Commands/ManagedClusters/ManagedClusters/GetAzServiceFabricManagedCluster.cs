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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabricManagedClusters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedCluster", DefaultParameterSetName = BySubscription), OutputType(typeof(PSManagedCluster))]
    public class GetServiceFabricManagedCluster : ServiceFabricManagedCmdletBase
    {
        protected const string ByName = "ByName";
        protected const string ByResourceGroup = "ByResourceGroup";
        protected const string BySubscription = "BySubscription";

        #region Params

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByResourceGroup, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public string Name { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                switch(ParameterSetName)
                {
                    case ByName:
                        var cluster = this.SfrpMcClient.ManagedClusters.Get(this.ResourceGroupName, this.Name);
                        WriteObject(new PSManagedCluster(cluster), false);
                        break;
                    case ByResourceGroup:
                        var clusterList = this.ReturnListByPageResponse(
                            this.SfrpMcClient.ManagedClusters.ListByResourceGroup(this.ResourceGroupName),
                            this.SfrpMcClient.ManagedClusters.ListByResourceGroupNext);

                        WriteObject(clusterList.Select(c => new PSManagedCluster(c)), true);
                        break;
                    case BySubscription:
                        var cluster2List = this.ReturnListByPageResponse(
                            this.SfrpMcClient.ManagedClusters.ListBySubscription(),
                            this.SfrpMcClient.ManagedClusters.ListBySubscriptionNext);

                        WriteObject(cluster2List.Select(c => new PSManagedCluster(c)), true);
                        break;
                }
            }
            catch (Exception ex)
            {
                PrintSdkExceptionDetail(ex);
                throw;
            }
        }
    }
}

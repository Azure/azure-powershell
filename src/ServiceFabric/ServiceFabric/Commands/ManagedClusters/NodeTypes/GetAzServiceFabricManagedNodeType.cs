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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedNodeType", DefaultParameterSetName = ByName), OutputType(typeof(PSManagedNodeType))]
    public class GetAzServiceFabricManagedNodeType : ServiceFabricManagedCmdletBase
    {
        protected const string ByName = "ByName";
        protected const string ByResourceGroup = "ByResourceGroup";

        #region Params

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByResourceGroup, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByResourceGroup, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the node type.")]
        [ValidateNotNullOrEmpty()]
        [Alias("NodeTypeName")]
        public string Name { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.Name))
                {
                    var nodeType = this.SfrpMcClient.NodeTypes.Get(this.ResourceGroupName, this.ClusterName, this.Name);
                    WriteObject(new PSManagedNodeType(nodeType), false);
                }
                else
                {
                    var nodeTypeList = this.ReturnListByPageResponse(
                        this.SfrpMcClient.NodeTypes.ListByManagedClusters(this.ResourceGroupName, this.ClusterName),
                        this.SfrpMcClient.NodeTypes.ListByManagedClustersNext);
                    WriteObject(nodeTypeList.Select(nt => new PSManagedNodeType(nt)), true);
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

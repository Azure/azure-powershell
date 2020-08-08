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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedNodeType", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzServiceFabricManagedNodeType : ServiceFabricCommonCmdletBase
    {
        protected const string DeleteNode = "DeleteNode";

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
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the node type.")]
        [ValidateNotNullOrEmpty()]
        [Alias("NodeTypeName")]
        public string Name { get; set; }

        #endregion

        [Parameter(Mandatory = true, ParameterSetName = DeleteNode, HelpMessage = "List of node names for the operation.")]
        [ValidateNotNullOrEmpty()]
        public string[] NodeName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = DeleteNode,
            HelpMessage = "Using this flag will force the removal even if service fabric is unable to disable the nodes. Use with caution as this might cause data loss if stateful workloads are running on the nodes, or might bring the cluster down if there are not enough seed nodes after the opearion.")]
        public SwitchParameter ForceRemoveNode { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName == DeleteNode)
                {
                    if (ShouldProcess(target: this.Name, action: string.Format("Delete node(s) {0}, from node type {1} on cluster {2}", string.Join(", ", this.NodeName), this.Name, this.ClusterName)))
                    {

                        var actionParams = new NodeTypeActionParameters(nodes: this.NodeName, force: this.ForceRemoveNode.IsPresent);
                        var beginRequestResponse = this.SFRPClient.NodeTypes.BeginDeleteNodeWithHttpMessagesAsync(
                                this.ResourceGroupName,
                                this.ClusterName,
                                this.Name,
                                actionParams).GetAwaiter().GetResult();

                        this.PollLongRunningOperation(beginRequestResponse);
                    }
                }
                else
                {
                    if (ShouldProcess(target: this.Name, action: string.Format("Remove node type: {0} on cluster {1}, resource group {2}", this.Name, this.ClusterName, this.ResourceGroupName)))
                    {
                        var beginRequestResponse = this.SFRPClient.NodeTypes.BeginDeleteWithHttpMessagesAsync(
                                this.ResourceGroupName,
                                this.ClusterName,
                                this.Name).GetAwaiter().GetResult();

                        this.PollLongRunningOperation(beginRequestResponse);
                    }
                }

                if (this.PassThru)
                {
                    WriteObject(true);
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

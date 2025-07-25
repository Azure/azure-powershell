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
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedNodeType", DefaultParameterSetName = DeleteNodeTypeByObj, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzServiceFabricManagedNodeType : ServiceFabricManagedCmdletBase
    {
        protected const string DeleteNodeTypeByName = "DeleteNodeTypeByName";
        protected const string DeleteNodeTypeByObj = "DeleteNodeTypeByObj";
        protected const string DeleteNodeTypeById = "DeleteNodeTypeById";

        protected const string DeleteNodeByName = "DeleteNodeByName";
        protected const string DeleteNodeByObj = "DeleteNodeByObj";
        protected const string DeleteNodeById = "DeleteNodeById";

        #region Params

        #region Common params

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteNodeTypeByName,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteNodeByName,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteNodeTypeByName,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteNodeByName,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteNodeTypeByName,
            HelpMessage = "Specify the name of the node type.")]
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteNodeByName,
            HelpMessage = "Specify the name of the node type.")]
        [ValidateNotNullOrEmpty()]
        [Alias("NodeTypeName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = DeleteNodeTypeByObj,
            HelpMessage = "Node type resource")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = DeleteNodeByObj,
            HelpMessage = "Node type resource")]
        [ValidateNotNull]
        public PSManagedNodeType InputObject { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = DeleteNodeTypeById,
            HelpMessage = "Node type resource id")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = DeleteNodeById,
            HelpMessage = "Node type resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion

        [Parameter(Mandatory = true, ParameterSetName = DeleteNodeByName, HelpMessage = "List of node names for the operation.")]
        [Parameter(Mandatory = true, ParameterSetName = DeleteNodeByObj, HelpMessage = "List of node names for the operation.")]
        [Parameter(Mandatory = true, ParameterSetName = DeleteNodeById, HelpMessage = "List of node names for the operation.")]
        [ValidateNotNullOrEmpty()]
        public string[] NodeName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = DeleteNodeByName,
            HelpMessage = "Using this flag will force the removal even if service fabric is unable to disable the nodes. Use with caution as this might cause data loss if stateful workloads are running on the nodes, or might bring the cluster down if there are not enough seed nodes after the opearion.")]
        [Parameter(Mandatory = false, ParameterSetName = DeleteNodeByObj,
            HelpMessage = "Using this flag will force the removal even if service fabric is unable to disable the nodes. Use with caution as this might cause data loss if stateful workloads are running on the nodes, or might bring the cluster down if there are not enough seed nodes after the opearion.")]
        [Parameter(Mandatory = false, ParameterSetName = DeleteNodeById,
            HelpMessage = "Using this flag will force the removal even if service fabric is unable to disable the nodes. Use with caution as this might cause data loss if stateful workloads are running on the nodes, or might bring the cluster down if there are not enough seed nodes after the opearion.")]
        public SwitchParameter ForceRemoveNode { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Returns True if the command succeeds and False if it fails. By default, this cmdlet does not return any output.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                this.SetParams();
                switch (ParameterSetName)
                {
                    case DeleteNodeByName:
                    case DeleteNodeByObj:
                    case DeleteNodeById:
                        if (ShouldProcess(target: this.Name, action: string.Format("Delete node(s) {0}, from node type {1} on cluster {2}", string.Join(", ", this.NodeName), this.Name, this.ClusterName)))
                        {

                            var actionParams = new NodeTypeActionParameters(nodes: this.NodeName, force: this.ForceRemoveNode.IsPresent);
                            var beginRequestResponse = this.SfrpMcClient.NodeTypes.BeginDeleteNodeWithHttpMessagesAsync(
                                    this.ResourceGroupName,
                                    this.ClusterName,
                                    this.Name,
                                    actionParams).GetAwaiter().GetResult();

                            this.PollLongRunningOperation(beginRequestResponse);
                        }

                        break;

                    case DeleteNodeTypeByName:
                    case DeleteNodeTypeByObj:
                    case DeleteNodeTypeById:
                        if (ShouldProcess(target: this.Name, action: string.Format("Remove node type: {0} on cluster {1}, resource group {2}", this.Name, this.ClusterName, this.ResourceGroupName)))
                        {
                            var beginRequestResponse = this.SfrpMcClient.NodeTypes.BeginDeleteWithHttpMessagesAsync(
                                    this.ResourceGroupName,
                                    this.ClusterName,
                                    this.Name).GetAwaiter().GetResult();

                            this.PollLongRunningOperation(beginRequestResponse);
                        }

                        break;
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

        private void SetParams()
        {
            switch (ParameterSetName)
            {
                case DeleteNodeByObj:
                case DeleteNodeTypeByObj:
                    if (string.IsNullOrEmpty(this.InputObject?.Id))
                    {
                        throw new ArgumentException("ResourceId is null.");
                    }

                    SetParametersByResourceId(this.InputObject.Id);
                    break;
                case DeleteNodeById:
                case DeleteNodeTypeById:
                    SetParametersByResourceId(this.ResourceId);
                    break;
            }
        }

        private void SetParametersByResourceId(string resourceId)
        {
            this.GetParametersByResourceId(resourceId, Constants.ManagedNodeTypeProvider, out string resourceGroup, out string resourceName, out string parentResourceName);
            this.ResourceGroupName = resourceGroup;
            this.Name = resourceName;
            this.ClusterName = parentResourceName;
        }
    }
}

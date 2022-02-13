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
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedNodeType", DefaultParameterSetName = ByObj, SupportsShouldProcess = true), OutputType(new Type[] { typeof(bool), typeof(PSManagedNodeType) })]
    public class SetAzServiceFabricManagedNodeType : ServiceFabricManagedCmdletBase
    {
        protected const string ReimageByName = "ReimageByName";
        protected const string ReimageById = "ReimageById";
        protected const string ReimageByObj = "ReimageByObj";
        protected const string WithParamsByName = "WithParamsByName";
        protected const string WithParamsById = "WithParamsById";
        protected const string ByObj = "ByObj";

        #region Params

        #region Common params

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = WithParamsByName,
            HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ReimageByName,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = WithParamsByName,
            HelpMessage = "Specify the name of the cluster.")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ReimageByName,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter(Constants.ManagedClustersFullType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = WithParamsByName,
            HelpMessage = "Specify the name of the node type.")]
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ReimageByName,
            HelpMessage = "Specify the name of the node type.")]
        [ValidateNotNullOrEmpty()]
        [Alias("NodeTypeName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = WithParamsById,
            HelpMessage = "Node type resource id")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = ReimageById,
            HelpMessage = "Node type resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = ByObj,
            HelpMessage = "Node type resource")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = ReimageByObj,
            HelpMessage = "Node type resource")]
        [ValidateNotNull]
        public PSManagedNodeType InputObject { get; set; }

        #endregion

        #region reimage params

        [Parameter(Mandatory = true, ParameterSetName = ReimageByName, HelpMessage = "List of node names for the operation.")]
        [Parameter(Mandatory = true, ParameterSetName = ReimageById, HelpMessage = "List of node names for the operation.")]
        [Parameter(Mandatory = true, ParameterSetName = ReimageByObj, HelpMessage = "List of node names for the operation.")]
        [ValidateNotNullOrEmpty()]
        public string[] NodeName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ReimageByName, HelpMessage = "List of node names for the operation.")]
        [Parameter(Mandatory = true, ParameterSetName = ReimageById, HelpMessage = "List of node names for the operation.")]
        [Parameter(Mandatory = true, ParameterSetName = ReimageByObj, HelpMessage = "List of node names for the operation.")]
        public SwitchParameter Reimage { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ReimageByName,
            HelpMessage = "Using this flag will force the reimage even if service fabric is unable to disable the nodes. Use with caution as this might cause data loss if stateful workloads are running on the node.")]
        [Parameter(Mandatory = false, ParameterSetName = ReimageById,
            HelpMessage = "Using this flag will force the reimage even if service fabric is unable to disable the nodes. Use with caution as this might cause data loss if stateful workloads are running on the node.")]
        [Parameter(Mandatory = false, ParameterSetName = ReimageByObj,
            HelpMessage = "Using this flag will force the reimage even if service fabric is unable to disable the nodes. Use with caution as this might cause data loss if stateful workloads are running on the node.")]
        public SwitchParameter ForceReimage { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ReimageByName)]
        [Parameter(Mandatory = false, ParameterSetName = ReimageById)]
        [Parameter(Mandatory = false, ParameterSetName = ReimageByObj)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        #region set params

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "The number of nodes in the node type.")]
        public int? InstanceCount { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Application start port of a range of ports.")]
        public int? ApplicationStartPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Application End port of a range of ports.")]
        public int? ApplicationEndPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Ephemeral start port of a range of ports.")]
        public int? EphemeralStartPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Ephemeral end port of a range of ports.")]
        public int? EphemeralEndPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Capacity tags applied to the nodes in the node type as key/value pairs, the cluster resource manager uses these tags to understand how much resource a node has. Updating this will override the current values.")]
        public Hashtable Capacity { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = WithParamsByName, HelpMessage = "Placement tags applied to nodes in the node type as key/value pairs, which can be used to indicate where certain services (workload) should run. Updating this will override the current values.")]
        public Hashtable PlacementProperty { get; set; }

        #endregion


        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                this.SetParams();
                NodeType updatedNodeTypeParams = null;
                switch (ParameterSetName)
                {
                    case ReimageByName:
                    case ReimageById:
                    case ReimageByObj:
                        if (ShouldProcess(target: this.Name, action: string.Format("Reimage node(s) {0}, from node type {1} on cluster {2}", string.Join(", ", this.NodeName), this.Name, this.ClusterName)))
                        {

                            var actionParams = new NodeTypeActionParameters(nodes: this.NodeName, force: this.ForceReimage.IsPresent);
                            var beginRequestResponse = this.SfrpMcClient.NodeTypes.BeginReimageWithHttpMessagesAsync(
                                    this.ResourceGroupName,
                                    this.ClusterName,
                                    this.Name,
                                    actionParams).GetAwaiter().GetResult();

                            this.PollLongRunningOperation(beginRequestResponse);
                        }

                        if (this.PassThru)
                        {
                            WriteObject(true);
                        }

                        return;
                    case WithParamsByName:
                    case WithParamsById:
                        updatedNodeTypeParams = this.GetUpdatedNodeTypeParams();
                        break;
                    case ByObj:
                        updatedNodeTypeParams = this.InputObject;
                        break;
                    default:
                        throw new ArgumentException("Invalid parameter set", ParameterSetName);
                }

                if (ShouldProcess(target: this.Name, action: string.Format("Update node type name {0}, cluster: {1}", this.Name, this.ClusterName)))
                {
                    var beginRequestResponse = this.SfrpMcClient.NodeTypes.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, this.Name, updatedNodeTypeParams)
                        .GetAwaiter().GetResult();

                    var nodeType = this.PollLongRunningOperation(beginRequestResponse);

                    WriteObject(new PSManagedNodeType(nodeType), false);
                }
            }
            catch (Exception ex)
            {
                PrintSdkExceptionDetail(ex);
                throw;
            }
        }

        private NodeType GetUpdatedNodeTypeParams()
        {
            NodeType currentNodeType = this.SfrpMcClient.NodeTypes.Get(this.ResourceGroupName, this.ClusterName, this.Name);

            if (this.InstanceCount.HasValue)
            {
                currentNodeType.VmInstanceCount = this.InstanceCount.Value;
            }

            if (this.ApplicationStartPort.HasValue && this.ApplicationEndPort.HasValue)
            {
                currentNodeType.ApplicationPorts = new EndpointRangeDescription(this.ApplicationStartPort.Value, this.ApplicationEndPort.Value);
            }

            if (this.EphemeralStartPort.HasValue && this.EphemeralEndPort.HasValue)
            {
                currentNodeType.EphemeralPorts = new EndpointRangeDescription(this.EphemeralStartPort.Value, this.EphemeralEndPort.Value);
            }

            if (this.Capacity != null)
            {
                currentNodeType.Capacities = this.Capacity.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string);
            }

            if (this.PlacementProperty != null)
            {
                currentNodeType.PlacementProperties = this.PlacementProperty.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string);
            }

            return currentNodeType;
        }

        private void SetParams()
        {
            switch (ParameterSetName)
            {
                case ByObj:
                case ReimageByObj:
                    if (string.IsNullOrEmpty(this.InputObject?.Id))
                    {
                        throw new ArgumentException("ResourceId is null.");
                    }

                    SetParametersByResourceId(this.InputObject.Id);
                    break;
                case WithParamsById:
                case ReimageById:
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

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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Common.OData;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedNodeType", DefaultParameterSetName = SetParams, SupportsShouldProcess = true), OutputType(new Type[] { typeof(bool), typeof(PSManagedNodeType) })]
    public class SetAzServiceFabricManagedNodeType : ServiceFabricCommonCmdletBase
    {
        protected const string ReimageParameterSet = "Reimage";
        protected const string SetParams = "SetParams";

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

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the node type.")]
        [ValidateNotNullOrEmpty()]
        [Alias("NodeTypeName")]
        public string Name { get; set; }

        #endregion

        #region reimage params

        [Parameter(Mandatory = true, ParameterSetName = ReimageParameterSet, HelpMessage = "List of node names for the operation.")]
        [ValidateNotNullOrEmpty()]
        public List<string> NodeName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ReimageParameterSet, HelpMessage = "Specify to reimage nodes on the node type.")]
        public SwitchParameter Reimage { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ReimageParameterSet,
            HelpMessage = "Using this flag will force the reimage even if service fabric is unable to disable the nodes. Use with caution as this might cause data loss if stateful workloads are running on the node.")]
        public SwitchParameter ForceReimage { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ReimageParameterSet)]
        public SwitchParameter PassThru { get; set; }

        #endregion

        #region set params

        [Parameter(Mandatory = false, ParameterSetName = SetParams, HelpMessage = "The number of nodes in the node type.")]
        public int? InstanceCount { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SetParams, HelpMessage = "Application start port of a range of ports.")]
        public int? ApplicationStartPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SetParams, HelpMessage = "Application End port of a range of ports.")]
        public int? ApplicationEndPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SetParams, HelpMessage = "Ephemeral start port of a range of ports.")]
        public int? EphemeralStartPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SetParams, HelpMessage = "Ephemeral end port of a range of ports.")]
        public int? EphemeralEndPort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SetParams, HelpMessage = "Capacity tags applied to the nodes in the node type as key/value pairs, the cluster resource manager uses these tags to understand how much resource a node has. Updating this will override the current values.")]
        public Hashtable Capacity { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SetParams, HelpMessage = "Placement tags applied to nodes in the node type as key/value pairs, which can be used to indicate where certain services (workload) should run. Updating this will override the current values.")]
        public Hashtable PlacementPropertie { get; set; }

        #endregion


        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case ReimageParameterSet: 
                        if (ShouldProcess(target: this.Name, action: string.Format("Reimage node(s) {0}, from node type {1} on cluster {2}", string.Join(", ", this.NodeName), this.Name, this.ClusterName)))
                        {

                            var actionParams = new NodeTypeActionParameters(nodes: this.NodeName, force: this.ForceReimage.IsPresent);
                            var beginRequestResponse = this.SFRPClient.NodeTypes.BeginReimageWithHttpMessagesAsync(
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

                        break;
                    case SetParams:
                        if (ShouldProcess(target: this.Name, action: string.Format("Update node type name {0}, cluster: {1}", this.Name, this.ClusterName)))
                        {
                            NodeType updatedNodeTypeParams = this.GetUpdatedNodeTypeParams();
                            var beginRequestResponse = this.SFRPClient.NodeTypes.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, this.Name, updatedNodeTypeParams)
                                .GetAwaiter().GetResult();

                            var nodeType = this.PollLongRunningOperation(beginRequestResponse);

                            WriteObject(new PSManagedNodeType(nodeType), false);
                        }

                        break;
                    default:
                        throw new ArgumentException("Invalid parameter set {0}", ParameterSetName);
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
            NodeType currentNodeType = this.SFRPClient.NodeTypes.Get(this.ResourceGroupName, this.ClusterName, this.Name);

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

            if (this.PlacementPropertie != null)
            {
                currentNodeType.PlacementProperties = this.PlacementPropertie.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string);
            }

            return currentNodeType;
        }
    }
}

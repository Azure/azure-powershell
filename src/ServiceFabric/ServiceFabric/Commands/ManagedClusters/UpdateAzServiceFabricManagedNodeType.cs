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
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedNodeType", SupportsShouldProcess = true), OutputType(typeof(PSManagedNodeType))]
    public class UpdateAzServiceFabricManagedNodeType : ServiceFabricCommonCmdletBase
    {
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

        [Parameter(Mandatory = false, HelpMessage = "The number of nodes in the node type.")]
        public int? InstanceCount { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "Application start port of a range of ports.")]
        public int? ApplicationStartPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Application End port of a range of ports.")]
        public int? ApplicationEndPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Ephemeral start port of a range of ports.")]
        public int? EphemeralStartPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Ephemeral end port of a range of ports.")]
        public int? EphemeralEndPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Capacity tags applied to the nodes in the node type as key/value pairs, the cluster resource manager uses these tags to understand how much resource a node has. Updating this will override the current values.")]
        public Hashtable Capacity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Placement tags applied to nodes in the node type as key/value pairs, which can be used to indicate where certain services (workload) should run. Updating this will override the current values.")]
        public Hashtable PlacementPropertie { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.Name, action: string.Format("Update node type name {0}, cluster: {1}", this.Name, this.ClusterName)))
            {
                try
                {
                    NodeType updatedNodeTypeParams = this.GetUpdatedNodeTypeParams();
                    var beginRequestResponse = this.SFRPClient.NodeTypes.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, this.Name, updatedNodeTypeParams)
                        .GetAwaiter().GetResult();

                    var nodeType = this.PollLongRunningOperation(beginRequestResponse);

                    WriteObject(new PSManagedNodeType(nodeType), false);
                }
                catch (Exception ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
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

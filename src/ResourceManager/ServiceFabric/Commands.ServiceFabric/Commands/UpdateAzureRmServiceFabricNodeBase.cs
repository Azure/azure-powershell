// ----------------------------------------------------------------------------------
//
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
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.ServiceFabric;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class UpdateAzureRmServiceFabricNodeBase : ServiceFabricClusterCmdlet
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public override string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
                HelpMessage = "Node type name")]
        public virtual string NodeType { get; set; }

        protected virtual int Number
        {
            get;
        }  

        public override void ExecuteCmdlet()
        {
            var cluster = GetCurrentCluster();
            var vmss = GetVmss(this.NodeType);
            var nodeType = GetNodeType(cluster, this.NodeType);
            var durabilityLevel = (DurabilityLevel)Enum.Parse(typeof(DurabilityLevel), nodeType.DurabilityLevel);

            if (this.Number < 0)
            {
                if (durabilityLevel == DurabilityLevel.Bronze)
                {
                    throw new PSInvalidOperationException(ServiceFabricProperties.Resources.CannotUpdateBronzeNodeType);
                }
            }

            if (vmss.Sku.Capacity == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.InvalidVmssConfiguration);
            }

            vmss.Sku.Capacity += this.Number;
            if (vmss.Sku.Capacity < 0)
            {
                throw new PSArgumentException(ServiceFabricProperties.Resources.SkuCapacityZero);
            }

            var reliabilityLevel = GetReliabilityLevel(cluster);
            var minInstanceCount = (int)reliabilityLevel;
            if (vmss.Sku.Capacity < minInstanceCount)
            {
                throw new PSArgumentException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotUpdateNodeCountLessThenReliabilityLevel,
                        vmss.Sku.Capacity,
                        minInstanceCount,
                        reliabilityLevel));
            }

            WriteVerboseWithTimestamp("Begin to add nodes to the node type");

            var updateTask = this.ComputeClient.VirtualMachineScaleSets.CreateOrUpdateAsync(this.ResourceGroupName, vmss.Name, vmss);

            WriteClusterAndVmssVerboseWhenUpdate(new List<Task>() { updateTask }, false, this.NodeType);

            cluster = GetCurrentCluster();
            nodeType = GetNodeType(cluster, this.NodeType);
            nodeType.VmInstanceCount = Convert.ToInt32(vmss.Sku.Capacity);
            cluster = SendPatchRequest(new ClusterUpdateParameters()
            {
                NodeTypes = cluster.NodeTypes
            });

            WriteObject((PSCluster)cluster, true);
        }
    }
}
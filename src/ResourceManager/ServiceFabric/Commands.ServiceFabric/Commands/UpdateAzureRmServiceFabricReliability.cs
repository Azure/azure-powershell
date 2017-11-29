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
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsData.Update, CmdletNoun.AzureRmServiceFabricReliability, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class UpdateAzureRmServiceFabricReliability : ServiceFabricClusterCmdlet
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
                   HelpMessage = "Reliability tier")]
        [ValidateNotNullOrEmpty()]
        [Alias("Level")]
        public ReliabilityLevel ReliabilityLevel { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true,
                   HelpMessage = "Add node count automatically when changing reliability")]
        [Alias("Auto")]
        public SwitchParameter AutoAddNode
        {
            get { return autoAddNode; }
            set { autoAddNode = value; }
        }
        private bool autoAddNode;

        public override void ExecuteCmdlet()
        {
            var cluster = GetCurrentCluster();
            var oldReliabilityLevelStr = cluster.ReliabilityLevel;
            var oldReliabilityLevel = ReliabilityLevel.Bronze;
            if (!Enum.TryParse(oldReliabilityLevelStr, out oldReliabilityLevel))
            {
                throw new InvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotParseReliabilityLevel,
                        oldReliabilityLevelStr));
            }

            if (this.ReliabilityLevel == oldReliabilityLevel)
            {
                WriteObject(new PSCluster(cluster), true);
                return;
            }

            var primaryVmss = GetPrimaryVmss();
            var instanceNumber = (int)ReliabilityLevel;

            if (primaryVmss.Sku.Capacity == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.SkuCapacityIsNull);
            }

            if (ShouldProcess(target: this.Name, action: string.Format("Update fabric reliability level to {0}", this.ReliabilityLevel)))
            {
                if ((int)this.ReliabilityLevel >= (int)oldReliabilityLevel)
                {
                    if (instanceNumber > primaryVmss.Sku.Capacity && !this.AutoAddNode.IsPresent)
                    {
                        throw new InvalidOperationException(
                            string.Format(
                                ServiceFabricProperties.Resources.UseAutoToIncreaseNodesCount,
                                primaryVmss.Sku.Capacity,
                                instanceNumber
                            ));
                    }

                    if (primaryVmss.Sku.Capacity < instanceNumber)
                    {
                        primaryVmss.Sku.Capacity = instanceNumber;

                        var updateVmssTask = ComputeClient.VirtualMachineScaleSets.CreateOrUpdateAsync(
                               this.ResourceGroupName,
                               primaryVmss.Name,
                               primaryVmss);

                        WriteClusterAndVmssVerboseWhenUpdate(new List<Task>() { updateVmssTask }, false);
                    }
                }

                var primayNodeType = cluster.NodeTypes.Single(n => n.IsPrimary);
                primayNodeType.VmInstanceCount = Convert.ToInt32(primaryVmss.Sku.Capacity);
                var request = new ClusterUpdateParameters
                {
                    ReliabilityLevel = this.ReliabilityLevel.ToString(),
                    NodeTypes = cluster.NodeTypes
                };

                var psCluster = SendPatchRequest(request);

                WriteObject(psCluster, true);
            }
        }

        protected VirtualMachineScaleSet GetPrimaryVmss()
        {
            var clusterRes = GetCurrentCluster();
            var nodeTypes = clusterRes.NodeTypes;
            var primaryNodeType = nodeTypes.Single(nt => nt.IsPrimary);
            var vmss = GetVmss(primaryNodeType.Name);
            return vmss;
        }
    }
}
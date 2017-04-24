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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

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
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        public override string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
                   HelpMessage = "VM instance number")]
        [ValidateNotNullOrEmpty()]
        [Alias("ReliabilityLevel")]
        public ReliabilityLevel Level { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true,
                   HelpMessage = "Adjust nodes number automatically when changing reliability")]
        [Alias("Auto")]
        public SwitchParameter AutoAddNodes
        {
            get { return autoAddNodes; }
            set { autoAddNodes = value; }
        }
        private bool autoAddNodes;

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

            if (this.Level == oldReliabilityLevel)
            {
                WriteObject(cluster, true);
                return;
            }

            var primaryVmss = GetPrimaryVmss();
            var instanceNumber = (int)Level;

            if (primaryVmss.Sku.Capacity == null)
            {
                throw new PSInvalidOperationException("invalid vmss");
            }

            if (ShouldProcess(target: this.Name, action: string.Format("Update fabric reliability level to {0} of {1}", this.Level, this.Name)))
            {
                if ((int)this.Level >= (int)oldReliabilityLevel)
                {
                    if (instanceNumber > primaryVmss.Sku.Capacity && !this.AutoAddNodes.IsPresent)
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
                        ComputeClient.VirtualMachineScaleSets.CreateOrUpdate(
                            this.ResourceGroupName,
                            primaryVmss.Name,   
                            primaryVmss);
                    }
                }   

                var request = new ClusterUpdateParameters
                {
                    ReliabilityLevel = this.Level.ToString()
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
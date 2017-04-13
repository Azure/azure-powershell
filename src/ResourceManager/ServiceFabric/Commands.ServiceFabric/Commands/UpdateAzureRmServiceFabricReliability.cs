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
    [Cmdlet(VerbsData.Update, CmdletNoun.AzureRmServiceFabricReliability), OutputType(typeof(PsCluster))]
    public class UpdateAzureRmServiceFabricReliability : ServiceFabricClusterCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "VM instance number")]
        [ValidateNotNullOrEmpty()]
        public ReliabilityLevel ReliabilityLevel { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Automaticly adjust nodes number when changing reliability")]
        [Alias("AutoAdjustNodes")]
        public SwitchParameter AutoAddNodes
        {
            get { return autoAdjustNodes; }
            set { autoAdjustNodes = value; }
        }
        private bool autoAdjustNodes;

        public override void ExecuteCmdlet()
        {
            var cluster = GetCurrentCluster();
            var oldReliabilityLevelStr = cluster.ReliabilityLevel;
            var oldReliabilityLevel = ReliabilityLevel.Bronze;
            if (!Enum.TryParse(oldReliabilityLevelStr, out oldReliabilityLevel))
            {
                throw new InvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CanNotParseReliabilityLevel,
                        oldReliabilityLevelStr));
            }

            var primaryVmss = GetPrimaryVmss();
            var instanceNumber = (int)ReliabilityLevel;

            if ((int)ReliabilityLevel > (int)oldReliabilityLevel)
            {
                if (instanceNumber > primaryVmss.Sku.Capacity && !this.AutoAddNodes.IsPresent)
                {
                    throw new InvalidOperationException(
                        ServiceFabricProperties.Resources.UseAutoToIncreaseNodesCount);
                }
                
                primaryVmss.Sku.Capacity = instanceNumber;
                ComputeClient.VirtualMachineScaleSets.CreateOrUpdate(
                    ResourceGroupName,
                    primaryVmss.Name,
                    primaryVmss);
            }
            else if (this.AutoAddNodes.IsPresent)
            {
                DurabilityLevel durabilityLevel;
                var missMatch = false;

                //ignore mismatch
                GetDurabilityLevel(
                    out durabilityLevel,
                    out missMatch,
                    primaryVmss.Name);

                if (durabilityLevel == DurabilityLevel.Bronze)
                {
                    throw new PSInvalidOperationException(
                        ServiceFabricProperties.Resources.CanNotChangeReliabilityLevelWithDurabilityWithBronze);
                }
            }

            var request = new ClusterUpdateParameters
            {
                ReliabilityLevel = ReliabilityLevel.ToString()
            };

            var psCluster = SendPatchRequest(request, true);           

            WriteObject(psCluster,true);
        }

        protected VirtualMachineScaleSet GetPrimaryVmss()
        {
            var clusterRes = GetCurrentCluster();
            var nodeTypes = clusterRes.NodeTypes;
            var primaryNodeType = nodeTypes.First(nt => nt.IsPrimary == true);
            var vmss = GetVmss(primaryNodeType.Name);
            return vmss;
        }
    }
}
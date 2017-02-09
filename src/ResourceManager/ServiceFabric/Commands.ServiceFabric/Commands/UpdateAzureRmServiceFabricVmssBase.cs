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
using Microsoft.Azure.Management.ServiceFabric;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class UpdateAzureRmServiceFabricVmssBase : ServiceFabricClusterCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "VM instance number")]
        [ValidateNotNullOrEmpty()]
        [Alias("NumberOfNodesToAdd")]
        public virtual int Number { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Node type name")]
        public string NodeTypeName { get; set; }

        public override void ExecuteCmdlet()
        {
            var cluster = GetCurrentCluster();
            DurabilityLevel durabilityLevel;
            bool missMatch = false;
            var vmss = GetVmss(this.NodeTypeName);
            GetDurabilityLevel(out durabilityLevel, out missMatch, this.NodeTypeName);

            if (this.Number < 0)
            {
                if (durabilityLevel == DurabilityLevel.Bronze)
                {
                    throw new PSInvalidOperationException(
                        ServiceFabricProperties.Resources.CanNotUpdateBronzeNodeType);
                }
            }

            vmss.Sku.Capacity += this.Number;
            if (vmss.Sku.Capacity < 0)
            {
                throw new PSArgumentException(this.Number.ToString());
            }

            var minInstanceCount = GetReliabilityLevel();
            if (vmss.Sku.Capacity < minInstanceCount)
            {
                throw new PSArgumentException(
                    string.Format(
                        ServiceFabricProperties.Resources.CanNotUpdateBronzeNodeType,
                        this.Number,
                        cluster.ReliabilityLevel));
            }

            ComputeClient.VirtualMachineScaleSets.CreateOrUpdate(
                ResourceGroupName, 
                vmss.Name,
                vmss);

            cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.ClusterName);
            var nodeType = cluster.NodeTypes.Where(n =>
            string.Equals(
                this.NodeTypeName,
                n.Name,
                StringComparison.InvariantCultureIgnoreCase)).First();

            nodeType.VmInstanceCount = Convert.ToInt32(vmss.Sku.Capacity);

            cluster = SendPatchRequest(new ClusterUpdateParameters()
            {
                NodeTypes = cluster.NodeTypes
            });

            WriteObject((PsCluster)cluster,true);
        }

        protected int GetReliabilityLevel()
        {
            var clusterResouce = GetCurrentCluster();
            var level = clusterResouce.ReliabilityLevel;
            ReliabilityLevel reliabilitylevel;
            if (Enum.TryParse(level, out reliabilitylevel))
            {
                return (int)reliabilitylevel;
            }
            else
            {
                throw new PSInvalidOperationException(
                    ServiceFabricProperties.Resources.CanNotGetReliabilityLevel);
            }
        }
    }
}

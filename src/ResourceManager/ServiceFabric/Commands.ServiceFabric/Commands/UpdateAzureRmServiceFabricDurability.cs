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
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Newtonsoft.Json.Linq;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsData.Update, CmdletNoun.AzureRmServiceFabricDurability), OutputType(typeof(PsCluster))]
    public class UpdateAzureRmServiceFabricDurability : ServiceFabricClusterCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify durability Level")]
        [ValidateNotNullOrEmpty()]
        [Alias("DurabilityLevel")]
        public DurabilityLevel Level { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify Service Fabric node type name")]
        [ValidateNotNullOrEmpty()]
        public string NodeTypeName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify Sku name of the node type")]
        [ValidateNotNullOrEmpty()]
        public string SkuName { get; set; }

        public override void ExecuteCmdlet()
        {
            var vmss = GetVmss(NodeTypeName);
            var ext = FindFabricVmExt(
                vmss.VirtualMachineProfile.ExtensionProfile.Extensions);
            var cluster = GetCurrentCluster();
            var nodeType = cluster.NodeTypes.SingleOrDefault(
                n => string.Compare(
                    n.Name,
                    NodeTypeName, 
                    StringComparison.OrdinalIgnoreCase) == 0);

            if (nodeType == null )
            {
                throw new PSArgumentException(
                    string.Format(
                        ServiceFabricProperties.Resources.CanNotFindTheNodeType,
                        this.NodeTypeName));
            }            

            DurabilityLevel oldurabilityLevel;
            var missMatch = false;
            GetDurabilityLevel(
                out oldurabilityLevel,
                out missMatch,
                this.NodeTypeName);

            var cuDurabilityLevel = this.Level;

            if (!CheckState(oldurabilityLevel, cuDurabilityLevel, vmss.Sku.Name))
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CanNotChangeDurabilityFrom,
                        oldurabilityLevel,
                        cuDurabilityLevel));
            }

            if (!string.IsNullOrEmpty(SkuName))
            {
                vmss.Sku = new Sku(SkuName, "Standard", vmss.Sku.Capacity);
            }

            if (cuDurabilityLevel == DurabilityLevel.Bronze && !string.IsNullOrEmpty(this.SkuName))
            {
                throw new PSInvalidOperationException(
                    ServiceFabricProperties.Resources.CanNotUpdateSkuWithDurabilityWithBronze);
            }

            ((JObject)ext.Settings)["durabilityLevel"] = this.Level.ToString();

            var vmssTask = ComputeClient.VirtualMachineScaleSets.
                CreateOrUpdateAsync(
                ResourceGroupName,
                vmss.Name,
                vmss);

            nodeType.DurabilityLevel = this.Level.ToString();

            var patchArg = new ClusterUpdateParameters
            {
                NodeTypes = cluster.NodeTypes
            };

            var patchTask = PatchAsync(patchArg, true);

            Task.WaitAll(vmssTask, patchTask);

            if (!vmssTask.IsCompleted || !patchTask.IsCompleted)
            {
                throw new PSInvalidOperationException();
            }

            var psCluster = patchTask.Result;
            WriteObject(psCluster, true);
        }

        private bool CheckState(
            DurabilityLevel now,
            DurabilityLevel next,
            string currentSkuName)
        {

            if (now == DurabilityLevel.Gold)
            {
                if (next != DurabilityLevel.Gold
                    //&& next != DurabilityLevel.Silver //TODO
                    )
                {
                    return false;
                }
            }

            if (now == DurabilityLevel.Silver)
            {
                if (next != DurabilityLevel.Gold &&
                    next != DurabilityLevel.Silver)
                {
                    return false;
                }
            }

            if (next == DurabilityLevel.Gold)
            {
                var targetSkuName = string.IsNullOrEmpty(this.SkuName)
                    ? currentSkuName
                    : this.SkuName;

                if (targetSkuName.ToLower().Contains(
                    "D15_V2".ToLower()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

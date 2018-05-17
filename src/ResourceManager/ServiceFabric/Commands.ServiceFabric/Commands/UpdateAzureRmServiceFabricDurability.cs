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
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Newtonsoft.Json.Linq;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsData.Update, CmdletNoun.AzureRmServiceFabricDurability, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class UpdateAzureRmServiceFabricDurability : ServiceFabricClusterCmdlet
    {
        private readonly HashSet<string> skusSupportGoldDurability = 
            new HashSet<string>(StringComparer.OrdinalIgnoreCase) {"Standard_D15_v2", "Standard_G5"};

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
           HelpMessage = "Specify Service Fabric node type name")]
        [ValidateNotNullOrEmpty()]
        public string NodeType { get; set; } 

        [Parameter(Mandatory = true, ValueFromPipeline = true,
                   HelpMessage = "Specify durability Level")]
        [ValidateNotNullOrEmpty()]
        [Alias("Level")]
        public DurabilityLevel DurabilityLevel { get; set; } 

        [Parameter(Mandatory = false, ValueFromPipeline = true,
                   HelpMessage = "Specify the SKU of the node type")]
        [ValidateNotNullOrEmpty()]
        public string Sku { get; set; }

        public override void ExecuteCmdlet()
        {
            var vmss = GetVmss(this.NodeType);
            var ext = FindFabricVmExt(vmss.VirtualMachineProfile.ExtensionProfile.Extensions);
            var cluster = GetCurrentCluster();
            var nodeType = GetNodeType(cluster, this.NodeType);
            var oldDurabilityLevel = GetDurabilityLevel(nodeType.DurabilityLevel);
            var newDurabilityLevel = this.DurabilityLevel;
            var isMismatched = oldDurabilityLevel != GetDurabilityLevel(vmss);

            if (newDurabilityLevel == oldDurabilityLevel && !isMismatched)
            {
                WriteObject(new PSCluster(cluster), true);
                return;
            }

            if (isMismatched)
            {
                WriteWarning(ServiceFabricProperties.Resources.DurabilityLevelMismatches);
            }

            if (!ChangeAllowed(oldDurabilityLevel, newDurabilityLevel, vmss.Sku.Name))
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotChangeDurabilityFrom,
                        oldDurabilityLevel,
                        newDurabilityLevel));
            }

            if (newDurabilityLevel == DurabilityLevel.Bronze &&
                !string.IsNullOrEmpty(this.Sku) &&
                !this.Sku.Equals(vmss.Sku.Name))
            {
                throw new PSInvalidOperationException(
                    ServiceFabricProperties.Resources.CannotUpdateSkuWithBronzeDurability);
            }

            if (!string.IsNullOrEmpty(Sku))
            {
                vmss.Sku = new Sku(this.Sku, Constants.DefaultTier, vmss.Sku.Capacity);
            }

            ((JObject)ext.Settings)["durabilityLevel"] = this.DurabilityLevel.ToString();
            ((JObject)ext.Settings)["enableParallelJobs"] = true;

            if (ShouldProcess(target: this.Name, action: string.Format("Update fabric durability level to {0} of {1}", this.DurabilityLevel, this.NodeType)))
            {
                var vmssTask = ComputeClient.VirtualMachineScaleSets.CreateOrUpdateAsync(
                    ResourceGroupName,
                    vmss.Name,
                    vmss);

                nodeType.DurabilityLevel = this.DurabilityLevel.ToString();

                var patchArg = new ClusterUpdateParameters
                {
                    NodeTypes = cluster.NodeTypes
                };

                var patchTask = PatchAsync(patchArg);

                WriteClusterAndVmssVerboseWhenUpdate(new List<Task>() { vmssTask, patchTask }, true, this.NodeType);

                var psCluster = new PSCluster(patchTask.Result);
                WriteObject(psCluster, true);
            }
        }

        private bool ChangeAllowed(DurabilityLevel now, DurabilityLevel next, string currentSkuName)
        {
            if (now == DurabilityLevel.Gold)
            {
                if (next != DurabilityLevel.Gold)
                {
                    return false;
                }
            }

            if (now == DurabilityLevel.Silver)
            {
                if (next != DurabilityLevel.Gold && next != DurabilityLevel.Silver)
                {
                    return false;
                }
            }

            if (next == DurabilityLevel.Gold)
            {
                var targetSkuName = string.IsNullOrEmpty(this.Sku) ? currentSkuName : this.Sku;

                if (!skusSupportGoldDurability.Contains(targetSkuName))
                {
                    WriteWarning("Only Standard_D15_v2 and Standard_G5 supports Gold durability");
                    return false;
                }
            }

            return true;
        }
    }
}
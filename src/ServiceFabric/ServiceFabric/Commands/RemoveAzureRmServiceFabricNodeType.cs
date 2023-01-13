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
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceFabricNodeType", SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class RemoveAzureRmServiceFabricNodeType : ServiceFabricNodeTypeCmdletBase
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

        public override void ExecuteCmdlet()
        {
            WriteWarning("After the NodeType is removed, you may see the nodes of the NodeType are in error state. " +
                "Run 'Remove-ServiceFabricNodeState' on those nodes to fix them. Read this document for details: " +
                "https://docs.microsoft.com/powershell/module/servicefabric/remove-servicefabricnodestate?view=azureservicefabricps");

            var cluster = GetCurrentCluster();
            var vmssExists = VmssExists();
            var existingNodeType = GetNodeType(cluster, this.NodeType, ignoreErrors:true);
            if (existingNodeType != null)
            {
                if (existingNodeType.IsPrimary)
                {
                    throw new PSInvalidOperationException(
                        string.Format(
                            ServiceFabricProperties.Resources.CannotDeletePrimaryNodeType,
                            this.NodeType));
                }


                var durabilityLevel = GetDurabilityLevel(existingNodeType.DurabilityLevel);
                if (durabilityLevel == DurabilityLevel.Bronze && vmssExists)
                {
                    var vmss = GetVmss(existingNodeType.Name, cluster.ClusterId);

                    VirtualMachineScaleSetExtension sfExtension;
                    if (TryGetFabricVmExt(vmss.VirtualMachineProfile.ExtensionProfile?.Extensions, out sfExtension))
                    {
                        string vmssDurabilityLevel = GetDurabilityLevelFromExtension(sfExtension);
                        if (!string.Equals(DurabilityLevel.Bronze.ToString(), vmssDurabilityLevel, StringComparison.InvariantCultureIgnoreCase))
                        {
                            throw new PSInvalidOperationException(string.Format(
                                ServiceFabricProperties.Resources.CannotRemoveMismatchedDurabilityNodeType, this.NodeType));
                        }
                    }
                }
            }

            if (!vmssExists && existingNodeType == null)
            {
                throw new PSArgumentException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotFindTheNodeType,
                        this.NodeType));
            }

            if (ShouldProcess(target: this.NodeType, action: string.Format("Remove a nodetype {0}", this.NodeType)))
            {
                if (vmssExists)
                {
                    this.ComputeClient.VirtualMachineScaleSets.Delete(this.ResourceGroupName, this.NodeType);
                }

                if (cluster.NodeTypes == null)
                {
                    throw new PSInvalidOperationException(ServiceFabricProperties.Resources.NodeTypesNotDefinedInCluster);
                }

                if (existingNodeType != null)
                {
                    cluster.NodeTypes.Remove(existingNodeType);

                    /*
                     * * Pulled this out after discussion with Justin. Opened Issue #6246 to track the Null Ptr Exception.
                    cluster.UpgradeDescription.DeltaHealthPolicy = new ClusterUpgradeDeltaHealthPolicy()
                    {
                        MaxPercentDeltaUnhealthyApplications = 0,
                        MaxPercentDeltaUnhealthyNodes = 0,
                        MaxPercentUpgradeDomainDeltaUnhealthyNodes = 0
                    };*/

                    var patchRequest = new ClusterUpdateParameters
                    {
                        NodeTypes = cluster.NodeTypes
                    };

                    var psCluster = SendPatchRequest(patchRequest);
                    WriteObject(psCluster, true);
                }
                else
                {
                    WriteObject(new PSCluster(cluster), true);
                }
            }
        }
    }
}

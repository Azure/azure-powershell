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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, CmdletNoun.AzureRmServiceFabricNodeType, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
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
            WriteWarning("After the NodeType is removed, you may see the nodes of the NodeType are in error state," +
                 "you need to run 'Remove-ServiceFabricNodeState' on those nodes to fix them, read this document for details on how to " +
                 " https://docs.microsoft.com/powershell/module/servicefabric/remove-servicefabricnodestate?view=azureservicefabricps");

            if (!CheckNodeTypeExistence())
            {
                throw new PSArgumentException(this.NodeType);
            }

            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.Name);

            if (cluster.NodeTypes == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.NoneNodeTypeFound);
            }

            var existingNodeType = cluster.NodeTypes.FirstOrDefault(n =>
                this.NodeType.Equals(
                    n.Name,    
                    StringComparison.OrdinalIgnoreCase));

            if (existingNodeType == null)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotFindTheNodeType,
                        this.NodeType));
            }

            if (existingNodeType.IsPrimary)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotDeletePrimayNodeType,
                        this.NodeType));
            }

            DurabilityLevel durabilityLevel;
            bool missMatch;
            GetDurabilityLevel(this.NodeType, out durabilityLevel, out missMatch);

            if (durabilityLevel == DurabilityLevel.Bronze)
            {
                throw new PSInvalidOperationException(
                    ServiceFabricProperties.Resources.CannotUpdateBronzeNodeType);
            }

            if (ShouldProcess(target: this.NodeType, action: string.Format("Remove a nodetype {0} ", this.NodeType)))
            {
                cluster = RemoveNodeTypeFromSfrp();
                this.ComputeClient.VirtualMachineScaleSets.Delete(this.ResourceGroupName, this.NodeType);

                WriteObject((PSCluster)cluster, true);
            }
        }
    }
}

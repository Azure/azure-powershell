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
// ---------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, CmdletNoun.AzureRmServiceFabricNode, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class RemoveAzureRmServiceFabricNode : UpdateAzureRmServiceFabricNodeBase
    {
        private int toRemoveNode;

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
        [Alias("ClusterName")]
        public override string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
           HelpMessage = "Node type name")]
        public override string NodeType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
                  HelpMessage = "Number of nodes to remove")]
        [ValidateRange(1, 2147483647)]
        [Alias("NumberOfNodesToRemove")]
        public override int Number
        {
            get
            {
                return this.toRemoveNode;
            }
            set
            {
                toRemoveNode = -value;
            }
        }      

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.NodeType, action: string.Format("Remove {0} nodes", -toRemoveNode)))
            {
                base.ExecuteCmdlet();
            }
        }
    }
}
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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, CmdletNoun.AzureRmServiceFabricNode, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class RemoveAzureRmServiceFabricNode : UpdateAzureRmServiceFabricNodeBase
    {
        private int toRemoveNode;

        [Parameter(Mandatory = true, ValueFromPipeline = true,
         HelpMessage = "The number of nodes to add")]
        [ValidateRange(1, 2147483647)]
        [Alias("Number")]
        public int NumberOfNodesToRemove
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

        protected override int Number
        {
             get { return this.NumberOfNodesToRemove; }
        }      

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.Name, action: string.Format("Remove {0} nodes from {1}", -toRemoveNode, this.NodeType)))
            {
                base.ExecuteCmdlet();
            }
        }
    }
}
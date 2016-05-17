// Copyright Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Node
{
    using System;
    using System.Management.Automation;
    using Base;
    using Management.ServerManagement;
    using Model;

    [Cmdlet(VerbsCommon.Remove, "AzureRmServerManagementNode")]
    public class RemoveServerManagementNodeCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName", Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the node to delete.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName", Position = 1)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The node to delete.", ValueFromPipeline = true,
            ParameterSetName = "ByObject", Position = 0)]
        [ValidateNotNull]
        public Node Node { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (Node != null)
            {
                WriteVerbose("Using Gateway object for resource/gateway name");
                ResourceGroupName = Node.ResourceGroupName;
                NodeName = Node.Name;
            }

            WriteVerbose(string.Format("Removing Node {0}/{1}", ResourceGroupName, NodeName));
            Client.Node.Delete(ResourceGroupName, NodeName);
        }
    }
}
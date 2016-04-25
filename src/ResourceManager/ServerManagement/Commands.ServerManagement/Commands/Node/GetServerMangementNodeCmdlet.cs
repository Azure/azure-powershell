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
    using System.Management.Automation;
    using Base;
    using Management.ServerManagement;
    using Model;

    [Cmdlet(VerbsCommon.Get, "AzureRmServerManagementNode"), OutputType(typeof(Node))]
    public class GetServerManagementNodeCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The targeted resource group.",
            ValueFromPipelineByPropertyName = true, Position = 0)]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the node to retrieve.",
            ValueFromPipelineByPropertyName = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            // lookup just one node
            if (NodeName != null)
            {
                WriteVerbose($"Getting Node for {NodeName}");
                WriteObject(new Node(Client.Node.Get(ResourceGroupName, NodeName)));
                return;
            }

            // lookup by resource group
            if (!string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                WriteVerbose($"Getting Nodes in resource group {ResourceGroupName}");
                foreach (var node in Client.Node.ListForResourceGroup(ResourceGroupName))
                {
                    WriteObject(new Node(node));
                }
                return;
            }

            // grab everything for the whole subscription
            foreach (var node in Client.Node.List())
            {
                WriteVerbose($"Getting all Nodes in entire subscription ");
                WriteObject(new Node(node));
            }
        }
    }
}
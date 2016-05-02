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

    [Cmdlet(VerbsCommon.Get, "AzureRmServerManagementNode"), OutputType(typeof(Node))]
    public class GetServerManagementNodeCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The targeted resource group.",
            ParameterSetName = "ByNodeName", ValueFromPipelineByPropertyName = true, Position = 0)]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the node to retrieve.",
            ParameterSetName = "ByNodeName", ValueFromPipelineByPropertyName = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The the node to retrieve.", ValueFromPipeline = true,
            ParameterSetName = "ByNode", Position = 0)]
        [ValidateNotNull]
        public Node Node { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Node != null)
            {
                WriteVerbose("Using object for NodeName/ResourceGroup.");
                NodeName = Node.Name;
                ResourceGroupName = Node.ResourceGroupName;
            }

            // lookup just one node
            if (NodeName != null)
            {
                WriteVerbose(string.Format("Getting Node for {0}", NodeName));
                WriteObject(Node.Create(Client.Node.Get(ResourceGroupName, NodeName)));
                return;
            }

            // lookup by resource group
            if (!string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                WriteVerbose(string.Format("Getting Nodes in resource group {0}", ResourceGroupName));
                foreach (var node in Client.Node.ListForResourceGroup(ResourceGroupName))
                {
                    WriteObject(Node.Create(node));
                }
                return;
            }

            // grab everything for the whole subscription
            foreach (var node in Client.Node.List())
            {
                WriteVerbose("Getting all Nodes in entire subscription ");
                WriteObject(Node.Create(node));
            }
        }
    }
}
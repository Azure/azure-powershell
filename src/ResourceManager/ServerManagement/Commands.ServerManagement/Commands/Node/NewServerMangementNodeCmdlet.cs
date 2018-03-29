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
    using System.Collections;
    using System.Management.Automation;
    using Base;
    using Management.ServerManagement;
    using Model;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet(VerbsCommon.New, "AzureRmServerManagementNode"), OutputType(typeof(Node))]
    [Obsolete("The AzureRM.ServerManagement module will be removed from AzureRM in May 2018")]
    public class NewServerManagementNodeCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName", Position = 0)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the gateway.", ValueFromPipelineByPropertyName = true,
            ParameterSetName = "ByName", Position = 1)]
        [ValidateNotNullOrEmpty]
        public string GatewayName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group location.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName", Position = 2)]
        [LocationCompleter("Microsoft.ServerManagement/nodes")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The gateway to place the node in.", ValueFromPipeline = true,
            ParameterSetName = "ByObject", Position = 0)]
        [ValidateNotNull]
        public Gateway Gateway { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the node to create.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The computer name of the node to connect to (will default to NodeName).",
            ValueFromPipelineByPropertyName = true)]
        public string ComputerName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The credentials to connect to the node.")]
        [ValidateNotNull]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Key/value pairs associated with the object.",
            ValueFromPipelineByPropertyName = true)]
        [Obsolete("New-AzureRmServerManagementNode: -Tags will be removed in favor of -Tag in an upcoming breaking change release.  Please start using the -Tag parameter to avoid breaking scripts.")]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Gateway != null)
            {
                WriteVerbose("Using Gateway object for resource/gateway name/location");
                ResourceGroupName = Gateway.ResourceGroupName;
                GatewayName = Gateway.Name;
                Location = Gateway.Location;
            }
            // the Node.Create call actually uses gatewayId, not gateway name, but that's easy enough to make.
            string gatewayId =
                string.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.ServerManagement/gateways/{2}",
                    Client.SubscriptionId,
                    ResourceGroupName,
                    GatewayName);

            WriteVerbose(string.Format("Creating new Node for {0}/{1}/{2}/{3}",
                ResourceGroupName,
                NodeName,
                Location,
                GatewayName));

#pragma warning disable CS0618
            var node = Node.Create(Client.Node.Create(ResourceGroupName,
                NodeName,
                Location,
                Tag,
                gatewayId,
                ComputerName ?? NodeName,
                Credential.UserName,
                ToPlainText(Credential.Password)));
#pragma warning restore CS0618

            if (node != null)
            {
                node.Credential = Credential;
            }

            WriteObject(node);
        }
    }
}
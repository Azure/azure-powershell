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

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Session
{
    using System;
    using System.Management.Automation;
    using Base;
    using Management.ServerManagement;
    using Model;

    [Cmdlet(VerbsCommon.Get, "AzureRmServerManagementSession"), OutputType(typeof(Session))]
    public class GetServerManagementSessionCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.", ParameterSetName = "ByNodeName",
            ValueFromPipelineByPropertyName = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the node.", ParameterSetName = "ByNodeName",
            ValueFromPipelineByPropertyName = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the session.", ParameterSetName = "ByNodeName",
            Position = 2)]
        [Parameter(Mandatory = false, HelpMessage = "The name of the session.", ParameterSetName = "BySession",
            Position = 1)]
        [ValidateNotNullOrEmpty]
        public string SessionName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The the node to retrieve a session for.", ValueFromPipeline = true,
            ParameterSetName = "ByNode", Position = 0)]
        [ValidateNotNull]
        public Node Node { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The the session to retrieve.", ValueFromPipeline = true,
            ParameterSetName = "BySession", Position = 0)]
        [ValidateNotNull]
        public Session Session { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Node != null)
            {
                WriteVerbose("Using object for NodeName/ResourceGroup.");
                NodeName = Node.Name;
                ResourceGroupName = Node.ResourceGroupName;
            }

            if (Session != null)
            {
                WriteVerbose("Using object for NodeName/ResourceGroup/SessionName");

                NodeName = Session.NodeName;
                ResourceGroupName = Session.ResourceGroupName;
                if (string.IsNullOrWhiteSpace(SessionName))
                {
                    SessionName = Session.Name;
                }
            }

            WriteVerbose(string.Format("Getting Session resource for {0}/{1}/{2}",
                ResourceGroupName,
                NodeName,
                SessionName));
            WriteObject(Session.Create(Client.Session.Get(ResourceGroupName, NodeName, SessionName)));
        }
    }
}
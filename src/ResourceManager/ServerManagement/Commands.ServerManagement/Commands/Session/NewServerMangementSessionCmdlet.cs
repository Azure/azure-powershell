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

    [Cmdlet(VerbsCommon.New, "AzureRmServerManagementSession"), OutputType(typeof(Session))]
    public class NewServerManagementSessionCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName", Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the node.", ParameterSetName = "ByName", Position = 1)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The the node to create the session on.", ValueFromPipeline = true,
            ParameterSetName = "ByNode", Position = 0)]
        [ValidateNotNull]
        public Node Node { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the session to create. (Defaults to random)",
            ValueFromPipelineByPropertyName = true)]
        public string SessionName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The credentials to connect to the node.")]
        public PSCredential Credential { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Node != null)
            {
                ResourceGroupName = Node.ResourceGroupName;
                NodeName = Node.Name;
                if (Node.Credential != null && Credential == null)
                {
                    Credential = Node.Credential;
                }
                WriteVerbose("Using Node object to for resourcegroup/node name");
            }

            if (SessionName == null)
            {
                SessionName = Guid.NewGuid().ToString();
                WriteVerbose(string.Format("Generating Session name {0}", SessionName));
            }

            WriteVerbose(string.Format("Getting Session resource for {0}/{1}/{2}",
                ResourceGroupName,
                NodeName,
                SessionName));
            WriteObject(
                Session.Create(Client.Session.Create(ResourceGroupName,
                    NodeName,
                    SessionName,
                    Credential.UserName,
                    ToPlainText(Credential.Password))));
        }
    }
}
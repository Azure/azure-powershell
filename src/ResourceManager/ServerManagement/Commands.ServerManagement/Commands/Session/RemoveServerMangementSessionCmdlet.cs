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

    [Cmdlet(VerbsCommon.Remove, "AzureRmServerManagementSession")]
    public class RemoveServerManagementSessionCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.",
            ValueFromPipelineByPropertyName = true, ParameterSetName = "ByName", Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the node.", ValueFromPipelineByPropertyName = true,
            ParameterSetName = "ByName", Position = 1)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the session to delete.", ParameterSetName = "ByName",
            Position = 2)]
        [Parameter(Mandatory = false, HelpMessage = "The name of the session to delete.", ParameterSetName = "ByObject",
            Position = 1)]
        [ValidateNotNullOrEmpty]
        public string SessionName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The session to delete.", ParameterSetName = "ByObject", Position = 0,
            ValueFromPipeline = true)]
        [ValidateNotNull]
        public Session Session { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Session != null)
            {
                ResourceGroupName = Session.ResourceGroupName;
                NodeName = Session.NodeName;
                SessionName = Session.Name;
                WriteVerbose("Using Session object for resourcegroup/node name/session name");
            }

            WriteVerbose(string.Format("Deleting session for {0}/{1}/{2}", ResourceGroupName, NodeName, SessionName));
            Client.Session.Delete(ResourceGroupName, NodeName, SessionName);
        }
    }
}
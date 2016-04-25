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
    using System.Management.Automation;
    using Base;
    using Management.ServerManagement;
    using Model;

    [Cmdlet(VerbsCommon.Get, "AzureRmServerManagementSession"), OutputType(typeof(Session))]
    public class GetServerManagementSessionCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.",
            ValueFromPipelineByPropertyName = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the node.", ValueFromPipelineByPropertyName = true,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        public string NodeName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the session.", ValueFromPipelineByPropertyName = true,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        public string SessionName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            WriteVerbose($"Getting Session resource for {ResourceGroupName}/{NodeName}/{SessionName}");
            WriteObject(new Session(Client.Session.Get(ResourceGroupName, NodeName, SessionName)));
        }
    }
}
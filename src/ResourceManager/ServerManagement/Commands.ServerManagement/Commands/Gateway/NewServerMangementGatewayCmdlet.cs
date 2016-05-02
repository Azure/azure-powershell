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

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Gateway
{
    using System;
    using System.Collections;
    using System.Management.Automation;
    using Base;
    using Management.ServerManagement;
    using Model;

    [Cmdlet(VerbsCommon.New, "AzureRmServerManagementGateway"), OutputType(typeof(Gateway))]
    public class NewServerManagementGatewayCmdlet : ServerManagementCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The targeted resource group.",
            ValueFromPipelineByPropertyName = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the gateway to create.",
            ValueFromPipelineByPropertyName = true, Position = 1)]
        [ValidateNotNullOrEmpty]
        public string GatewayName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group location.",
            ValueFromPipelineByPropertyName = true, Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Allow the gateway to auto-upgrade itself.",
            ValueFromPipelineByPropertyName = true)]
        public SwitchParameter AutoUpgrade { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Key/value pairs associated with the gateway.",
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tags { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            // create the gateway object
            WriteVerbose(string.Format("Creating gateway for {0}/{1}/{2}", ResourceGroupName, GatewayName, Location));
            var gateway = Gateway.Create(Client.Gateway.Create(ResourceGroupName,
                GatewayName,
                Location,
                Tags,
                AutoUpgrade.IsPresent
                    ? Management.ServerManagement.Models.AutoUpgrade.On
                    : Management.ServerManagement.Models.AutoUpgrade.Off));

            // create the gawe
            WriteObject(gateway);
        }
    }
}
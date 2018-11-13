﻿// ----------------------------------------------------------------------------------
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
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallNetworkRule", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallNetworkRule))]
    public class NewAzureFirewallNetworkRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Network Rule")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The description of the rule")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The source addresses of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> SourceAddress { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The destination addresses of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> DestinationAddress { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The destination ports of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> DestinationPort { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The protocols of the rule")]
        [ValidateSet(
            MNM.AzureFirewallNetworkRuleProtocol.Any,
            MNM.AzureFirewallNetworkRuleProtocol.TCP,
            MNM.AzureFirewallNetworkRuleProtocol.UDP,
            MNM.AzureFirewallNetworkRuleProtocol.ICMP,
            IgnoreCase = false)]
        public List<string> Protocol { get; set; }
        
        public override void Execute()
        {
            base.Execute();
            
            var networkRule = new PSAzureFirewallNetworkRule
            {
                Name = this.Name,
                Description = this.Description,
                Protocols = this.Protocol,
                SourceAddresses = this.SourceAddress,
                DestinationAddresses = this.DestinationAddress,
                DestinationPorts = this.DestinationPort
            };
            WriteObject(networkRule);
        }
    }
}

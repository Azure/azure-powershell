// ----------------------------------------------------------------------------------
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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using System.Text.RegularExpressions;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallNetworkRule", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallNetworkRule))]
    public class NewAzureFirewallNetworkRuleCommand : AzureFirewallBaseCmdlet
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
            Mandatory = false,
            HelpMessage = "The source addresses of the rule")]
        public string[] SourceAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The source ipgroup of the rule")]
        public string[] SourceIpGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination addresses of the rule")]
        public string[] DestinationAddress { get; set; }


        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination ipgroup of the rule")]
        public string[] DestinationIpGroup { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The destination FQDN of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] DestinationFqdn { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The destination ports of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] DestinationPort { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The protocols of the rule")]
        [ValidateSet(
            MNM.AzureFirewallNetworkRuleProtocol.Any,
            MNM.AzureFirewallNetworkRuleProtocol.TCP,
            MNM.AzureFirewallNetworkRuleProtocol.UDP,
            MNM.AzureFirewallNetworkRuleProtocol.ICMP,
            IgnoreCase = false)]
        public string[] Protocol { get; set; }
        
        public override void Execute()
        {
            base.Execute();

            // One of SourceAddress or SourceIpGroup must be present
            if ((SourceAddress == null) && (SourceIpGroup == null))
            {
                throw new ArgumentException("Either SourceAddress or SourceIpGroup is required.");
            }

            if (DestinationFqdn != null)
            {
                foreach (string fqdn in DestinationFqdn)
                {
                    ValidateIsFqdn(fqdn);
                }
            }

            // Only one of DestinationAddress or DestinationFqdns is allowed
            if ((DestinationAddress != null) && (DestinationFqdn != null))
            {
                throw new ArgumentException("Both DestinationAddress and DestinationFqdns not allowed.");
            }

            // One of DestinationAddress or DestinationFqdns must be present
            if ((DestinationAddress == null) && (DestinationFqdn == null) && (DestinationIpGroup == null))
            {
                throw new ArgumentException("DestinationAddress,DestinationIpGroup or DestinationFqdns is required.");
            }

            var networkRule = new PSAzureFirewallNetworkRule
            {
                Name = this.Name,
                Description = this.Description,
                Protocols = this.Protocol?.ToList(),
                SourceAddresses = this.SourceAddress?.ToList(),
                SourceIpGroups = this.SourceIpGroup?.ToList(),
                DestinationAddresses = this.DestinationAddress?.ToList(),
                DestinationIpGroups = this.DestinationIpGroup?.ToList(),
                DestinationFqdns = this.DestinationFqdn?.ToList(),
                DestinationPorts = this.DestinationPort?.ToList()
            };
            WriteObject(networkRule);
        }

        private void ValidateIsFqdn(string fqdn)
        {
            var fqdnRegEx = new Regex("^\\*$|^[a-zA-Z0-9]+(([a-zA-Z0-9_\\-]*[a-zA-Z0-9]+)*\\.)*(?:[a-zA-Z0-9]{2,})$");

            if (!fqdnRegEx.IsMatch(fqdn))
            {
                throw new ArgumentException($"Invalid value {fqdn}.");
            }
        }
    }
}

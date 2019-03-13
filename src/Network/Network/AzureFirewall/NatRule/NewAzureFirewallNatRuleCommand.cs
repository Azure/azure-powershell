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
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallNatRule", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallNatRule))]
    public class NewAzureFirewallNatRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the NAT Rule")]
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
        public string[] SourceAddress { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The destination addresses of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] DestinationAddress { get; set; }

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
            IgnoreCase = false)]
        public string[] Protocol { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The translated address for this NAT rule")]
        [ValidateNotNullOrEmpty]
        public string TranslatedAddress { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The translated port for this NAT rule")]
        [ValidateNotNullOrEmpty]
        public string TranslatedPort { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Add some validation based on the type of RuleCollection (SNAT will be supported later)
            // if (MNM.AzureFirewallNatRCActionType.Dnat.Equals(ActionType))
            {
                if (DestinationAddress.Length != 1)
                {
                    throw new ArgumentException("Only one destination address is accepted.", nameof(DestinationAddress));
                }

                if (DestinationPort.Length != 1)
                {
                    throw new ArgumentException("Only one destination port is accepted.", nameof(DestinationPort));
                }

                ValidateIsSingleIpNotRange(DestinationAddress.Single());
                ValidateIsSingleIpNotRange(TranslatedAddress);

                ValidateIsSinglePortNotRange(DestinationPort.Single());
                ValidateIsSinglePortNotRange(TranslatedPort);
            }

            var networkRule = new PSAzureFirewallNatRule
            {
                Name = this.Name,
                Description = this.Description,
                Protocols = this.Protocol?.ToList(),
                SourceAddresses = this.SourceAddress?.ToList(),
                DestinationAddresses = this.DestinationAddress?.ToList(),
                DestinationPorts = this.DestinationPort?.ToList(),
                TranslatedAddress = this.TranslatedAddress,
                TranslatedPort = this.TranslatedPort
            };
            WriteObject(networkRule);
        }

        private void ValidateIsSingleIpNotRange(string ipStr)
        {
            var singleIpRegEx = new Regex("^((\\d){1,3}\\.){3}((\\d){1,3})$");

            if (!singleIpRegEx.IsMatch(ipStr))
            {
                throw new ArgumentException($"Invalid value {ipStr}. Only a single IPv4 value is accepted (e.g. 10.1.2.3).");
            }
        }

        private void ValidateIsSinglePortNotRange(string portStr)
        {
            uint parsed;
            if (!uint.TryParse(portStr, out parsed))
            {
                throw new ArgumentException($"Invalid value {portStr}. Only a single port value is accepted (e.g. 8080).");
            }
        }
    }
}

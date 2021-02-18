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
<<<<<<< HEAD
    public class NewAzureFirewallNatRuleCommand : NetworkBaseCmdlet
=======
    public class NewAzureFirewallNatRuleCommand : AzureFirewallBaseCmdlet
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
            Mandatory = true,
            HelpMessage = "The source addresses of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] SourceAddress { get; set; }

        [Parameter(
=======
            Mandatory = false,
            HelpMessage = "The source addresses of the rule")]
        public string[] SourceAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The source ipgroup of the rule")]
        public string[] SourceIpGroup { get; set; }

        [Parameter(
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
            Mandatory = true,
=======
            Mandatory = false,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = "The translated address for this NAT rule")]
        [ValidateNotNullOrEmpty]
        public string TranslatedAddress { get; set; }

        [Parameter(
<<<<<<< HEAD
=======
            Mandatory = false,
            HelpMessage = "The translated FQDN for this NAT rule")]
        [ValidateNotNullOrEmpty]
        public string TranslatedFqdn { get; set; }

        [Parameter(
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
=======
               // One of SourceAddress or SourceIpGroup must be present
               if ((SourceAddress == null) && (SourceIpGroup == null))
               {
                  throw new ArgumentException("Either SourceAddress or SourceIpGroup is required.");
               }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                if (DestinationAddress.Length != 1)
                {
                    throw new ArgumentException("Only one destination address is accepted.", nameof(DestinationAddress));
                }

                if (DestinationPort.Length != 1)
                {
                    throw new ArgumentException("Only one destination port is accepted.", nameof(DestinationPort));
                }

                ValidateIsSingleIpNotRange(DestinationAddress.Single());
<<<<<<< HEAD
                ValidateIsSingleIpNotRange(TranslatedAddress);
=======
                if (TranslatedAddress != null)
                {
                    ValidateIsSingleIpNotRange(TranslatedAddress);
                }
                if (TranslatedFqdn != null)
                {
                    ValidateIsFqdn(TranslatedFqdn);
                }

                // Only one of TranslatedAddress or TranslatedFqdn is allowed
                if ((TranslatedAddress != null) && (TranslatedFqdn != null))
                {
                    throw new ArgumentException("Both TranslatedAddress and TranslatedFqdn not allowed");
                }

                // One of TranslatedAddress or TranslatedFqdn must be present
                if ((TranslatedAddress == null) && (TranslatedFqdn == null))
                {
                    throw new ArgumentException("Either TranslatedAddress or TranslatedFqdn is required");
                }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

                ValidateIsSinglePortNotRange(DestinationPort.Single());
                ValidateIsSinglePortNotRange(TranslatedPort);
            }

<<<<<<< HEAD
            var networkRule = new PSAzureFirewallNatRule
=======
            var natRule = new PSAzureFirewallNatRule
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            {
                Name = this.Name,
                Description = this.Description,
                Protocols = this.Protocol?.ToList(),
                SourceAddresses = this.SourceAddress?.ToList(),
<<<<<<< HEAD
                DestinationAddresses = this.DestinationAddress?.ToList(),
                DestinationPorts = this.DestinationPort?.ToList(),
                TranslatedAddress = this.TranslatedAddress,
                TranslatedPort = this.TranslatedPort
            };
            WriteObject(networkRule);
=======
                SourceIpGroups = this.SourceIpGroup?.ToList(),
                DestinationAddresses = this.DestinationAddress?.ToList(),
                DestinationPorts = this.DestinationPort?.ToList(),
                TranslatedAddress = this.TranslatedAddress,
                TranslatedFqdn = this.TranslatedFqdn,
                TranslatedPort = this.TranslatedPort
            };
            WriteObject(natRule);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
=======

        private void ValidateIsFqdn(string fqdn)
        {
            var fqdnRegEx = new Regex("^[a-zA-Z0-9]+(([a-zA-Z0-9_\\-]*[a-zA-Z0-9]+)*\\.)*(?:[a-zA-Z0-9]{2,})$");

            if (!fqdnRegEx.IsMatch(fqdn))
            {
                throw new ArgumentException($"Invalid value {fqdn}.");
            }
        }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}

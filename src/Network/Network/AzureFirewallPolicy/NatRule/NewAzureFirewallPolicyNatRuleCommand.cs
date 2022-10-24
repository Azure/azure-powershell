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
using Microsoft.Azure.Commands.Network.AzureFirewallPolicy;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyNatRule"), OutputType(typeof(PSAzureFirewallNatRule))]
    public class NewAzFirewallPolicyNatRuleCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Nat Rule")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The description of the rule")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyRuleSourceParameterSets.SourceAddressAndTranslatedAddress,
            HelpMessage = "The source addresses of the rule. Either SourceAddress or SourceIpGroup must be present.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyRuleSourceParameterSets.SourceAddressAndTranslatedFqdn,
            HelpMessage = "The source addresses of the rule. Either SourceAddress or SourceIpGroup must be present.")]
        [ValidateNotNullOrEmpty]
        public string[] SourceAddress { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyRuleSourceParameterSets.SourceIpGroupAndTranslatedAddress,
            HelpMessage = "The source ipgroups of the rule. Either SourceAddress or SourceIpGroup must be present.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyRuleSourceParameterSets.SourceIpGroupAndTranslatedFqdn,
            HelpMessage = "The source ipgroups of the rule. Either SourceAddress or SourceIpGroup must be present.")]
        [ValidateNotNullOrEmpty]
        public string[] SourceIpGroup { get; set; }

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
        public string[] Protocol { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyRuleSourceParameterSets.SourceAddressAndTranslatedAddress,
            HelpMessage = "The translated address for this NAT rule. Either translated address or fqdn must be present.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyRuleSourceParameterSets.SourceIpGroupAndTranslatedAddress,
            HelpMessage = "The translated address for this NAT rule. Either translated address or fqdn must be present.")]
        [ValidateNotNullOrEmpty]
        public string TranslatedAddress { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyRuleSourceParameterSets.SourceAddressAndTranslatedFqdn,
            HelpMessage = "The translated FQDN for this NAT rule. Either translated address or fqdn must be present.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyRuleSourceParameterSets.SourceIpGroupAndTranslatedFqdn,
            HelpMessage = "The translated FQDN for this NAT rule. Either translated address or fqdn must be present.")]
        [ValidateNotNullOrEmpty]
        public string TranslatedFqdn { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The translated port for this NAT rule")]
        [ValidateNotNullOrEmpty]
        public string TranslatedPort { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (TranslatedFqdn != null)
            {
                ValidateIsFqdn(TranslatedFqdn);
            }

            var natRule = new PSAzureFirewallPolicyNatRule
            {
                Name = this.Name,
                Protocols = this.Protocol?.ToList(),
                SourceAddresses = this.SourceAddress?.ToList(),
                SourceIpGroups = this.SourceIpGroup?.ToList(),
                DestinationAddresses = this.DestinationAddress?.ToList(),
                DestinationPorts = this.DestinationPort?.ToList(),
                TranslatedAddress = this.TranslatedAddress,
                TranslatedFqdn = this.TranslatedFqdn,
                TranslatedPort = this.TranslatedPort,
                RuleType = "NatRule",
                Description = this.Description
            };
            WriteObject(natRule);
        }

        private void ValidateIsFqdn(string fqdn)
        {
            var fqdnRegEx = new Regex("^[a-zA-Z0-9]+(([a-zA-Z0-9_\\-]*[a-zA-Z0-9]+)*\\.)*(?:[a-zA-Z0-9]{2,})$");

            if (!fqdnRegEx.IsMatch(fqdn))
            {
                throw new ArgumentException($"Invalid value {fqdn}.");
            }
        }
    }
}

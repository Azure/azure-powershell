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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyApplicationRule", DefaultParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceAddressAndTargetFqdn), OutputType(typeof(PSAzureFirewallPolicyApplicationRule))]
    public class NewAzFirewallPolicyApplicationRuleCommand : AzureFirewallPolicyBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Application Rule")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The description of the rule")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [CmdletParameterBreakingChange(
            "SourceAddress",
            ChangeDescription = "This parameter is becoming optional as SourceIpGroup can be provided without this.",
            IsBecomingMandatory = false)]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceAddressAndTargetFqdn,
            HelpMessage = "The source addresses of the rule. Either SourceAddress or SourceIpGroup must be present.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceAddressAndFqdnTag,
            HelpMessage = "The source addresses of the rule. Either SourceAddress or SourceIpGroup must be present.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceAddressAndWebCategory,
            HelpMessage = "The source addresses of the rule. Either SourceAddress or SourceIpGroup must be present.")]
        [ValidateNotNullOrEmpty]
        public string[] SourceAddress { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceIpGroupAndTargetFqdn,
            HelpMessage = "The source addresses of the rule. Either SourceAddress or SourceIpGroup must be present.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceIpGroupAndFqdnTag,
            HelpMessage = "The source addresses of the rule. Either SourceAddress or SourceIpGroup must be present.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceIpGroupAndWebCategory,
            HelpMessage = "The source addresses of the rule. Either SourceAddress or SourceIpGroup must be present.")]
        [ValidateNotNullOrEmpty]
        public string[] SourceIpGroup { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceAddressAndTargetFqdn,
            HelpMessage = "The target FQDNs of the rule")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceIpGroupAndTargetFqdn,
            HelpMessage = "The target FQDNs of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] TargetFqdn { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceAddressAndFqdnTag,
            HelpMessage = "The FQDN Tags of the rule")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceIpGroupAndFqdnTag,
            HelpMessage = "The FQDN Tags of the rule")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceIpGroupAndWebCategory,
            HelpMessage = "The source addresses of the rule. Either SourceAddress or SourceIpGroup must be present.")]
        [ValidateNotNullOrEmpty]
        public string[] FqdnTag { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceAddressAndWebCategory,
            HelpMessage = "The Web Categories of the rule")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceIpGroupAndWebCategory,
            HelpMessage = "The Web Categories of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] WebCategory { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceAddressAndTargetFqdn,
            HelpMessage = "The protocols of the rule")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceIpGroupAndTargetFqdn,
            HelpMessage = "The protocols of the rule")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceAddressAndWebCategory,
            HelpMessage = "The protocols of the rule")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallPolicyApplicationRuleParameterSets.SourceIpGroupAndWebCategory,
            HelpMessage = "The protocols of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] Protocol { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (FqdnTag != null)
            {
                this.Protocol = new string[] { "http", "https" };
                FqdnTag = AzureFirewallFqdnTagHelper.MapUserInputToAllowedFqdnTags(FqdnTag, this.AzureFirewallPolicyFqdnTagClient).ToArray();
            }

            var protocolsAsWeExpectThem = MapUserProtocolsToFirewallPolicyProtocols(Protocol?.ToList());

            var applicationRule = new PSAzureFirewallPolicyApplicationRule
            {
                Name = this.Name,
                SourceAddresses = this.SourceAddress?.ToList(),
                SourceIpGroups = this.SourceIpGroup?.ToList(),
                Protocols = protocolsAsWeExpectThem,
                TargetFqdns = this.TargetFqdn?.ToList(),
                FqdnTags = this.FqdnTag?.ToList(),
                WebCategories = this.WebCategory?.ToList(),
                RuleType = "ApplicationRule"
            };
            WriteObject(applicationRule);
        }

        private List<PSAzureFirewallPolicyApplicationRuleProtocol> MapUserProtocolsToFirewallPolicyProtocols(List<string> userProtocols)
        {
            return userProtocols.Select(PSAzureFirewallPolicyApplicationRuleProtocol.MapUserInputToApplicationRuleProtocol)?.ToList();
        }
    }
}

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

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallApplicationRule", SupportsShouldProcess = true, DefaultParameterSetName = AzureFirewallApplicationRuleParameterSets.TargetFqdn), OutputType(typeof(PSAzureFirewallApplicationRule))]
    public class NewAzureFirewallApplicationRuleCommand : AzureFirewallBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallApplicationRuleParameterSets.TargetFqdn,
            HelpMessage = "The name of the Application Rule")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallApplicationRuleParameterSets.FqdnTag,
            HelpMessage = "The name of the Application Rule")]
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
            Mandatory = true,
            ParameterSetName = AzureFirewallApplicationRuleParameterSets.TargetFqdn,
            HelpMessage = "The target FQDNs of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] TargetFqdn { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallApplicationRuleParameterSets.FqdnTag,
            HelpMessage = "The FQDN Tags of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] FqdnTag { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = AzureFirewallApplicationRuleParameterSets.TargetFqdn,
            HelpMessage = "The protocols of the rule")]
        [ValidateNotNullOrEmpty]
        public string[] Protocol { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (FqdnTag != null)
            {
                this.Protocol = PSAzureFirewallApplicationRuleProtocol.AllProtocols().ToArray();
                FqdnTag = AzureFirewallFqdnTagHelper.MapUserInputToAllowedFqdnTags(FqdnTag, this.AzureFirewallFqdnTagClient).ToArray();
            }

            var protocolsAsWeExpectThem = MapUserProtocolsToFirewallProtocols(Protocol?.ToList());

            var applicationRule = new PSAzureFirewallApplicationRule
            {
                Name = this.Name,
                Description = this.Description,
                SourceAddresses = this.SourceAddress?.ToList(),
                SourceIpGroups = this.SourceIpGroup?.ToList(),
                Protocols = protocolsAsWeExpectThem,
                TargetFqdns = this.TargetFqdn?.ToList(),
                FqdnTags = this.FqdnTag?.ToList()
            };
            WriteObject(applicationRule);
        }

        private List<PSAzureFirewallApplicationRuleProtocol> MapUserProtocolsToFirewallProtocols(List<string> userProtocols)
        {
            return userProtocols.Select(PSAzureFirewallApplicationRuleProtocol.MapUserInputToApplicationRuleProtocol)?.ToList();
        }
    }
}

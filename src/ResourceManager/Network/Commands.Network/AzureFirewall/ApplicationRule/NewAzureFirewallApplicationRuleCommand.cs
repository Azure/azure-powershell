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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallApplicationRule", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallApplicationRule))]
    public class NewAzureFirewallApplicationRuleCommand : NetworkBaseCmdlet
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "The source addresses of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> SourceAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The target FQDNs of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> TargetFqdn { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The FQDN Tags of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> FqdnTag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The protocols of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> Protocol { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (FqdnTag == null)
            {
                if (TargetFqdn == null)
                {
                    throw new ArgumentException($"Either {nameof(TargetFqdn)} or {nameof(FqdnTag)} must be specified for a rule.");
                }
            }
            else
            {
                if (TargetFqdn != null)
                {
                    throw new ArgumentException($"{nameof(TargetFqdn)} and {nameof(FqdnTag)} cannot be specified in the same rule.");
                }

                // We do not allow user protocols in this case
                if (Protocol != null)
                {
                    throw new ArgumentException($"Protocol parameter is not allowed when using {nameof(FqdnTag)}.");
                }

                this.Protocol = new List<string> { "http", "https" };
                FqdnTag = AzureFirewallFqdnTagHelper.MapUserInputToAllowedFqdnTags(FqdnTag);
            }

            var protocolsAsWeExpectThem = MapUserProtocolsToFirewallProtocols(Protocol);

            var applicationRule = new PSAzureFirewallApplicationRule
            {
                Name = this.Name,
                Description = this.Description,
                SourceAddresses = this.SourceAddress,
                Protocols = protocolsAsWeExpectThem,
                TargetFqdns = this.TargetFqdn,
                FqdnTags = this.FqdnTag
            };
            WriteObject(applicationRule);
        }

        private List<PSAzureFirewallApplicationRuleProtocol> MapUserProtocolsToFirewallProtocols(List<string> userProtocols)
        {
            return userProtocols.Select(PSAzureFirewallApplicationRuleProtocol.MapUserInputToApplicationRuleProtocol).ToList();
        }
    }
}

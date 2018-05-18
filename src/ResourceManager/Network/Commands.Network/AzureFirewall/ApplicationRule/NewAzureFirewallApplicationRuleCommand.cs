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
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmFirewallApplicationRule", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallApplicationRule))]
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
            Mandatory = true,
            HelpMessage = "The protocols of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> Protocol { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The target URLs of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> TargetFqdn { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.Protocol == null || this.Protocol.Count == 0)
            {
                throw new ArgumentException("At least one application rule protocol should be specified!");
            }

            if (this.TargetFqdn == null || this.TargetFqdn.Count == 0)
            {
                throw new ArgumentException("At least one application rule target URL should be specified!");
            }

            // User can pass "http" or "HTTP" protocol instead of "Http"
            var protocolsAsWeExpectThem = this.Protocol.Select(userProtocolText =>
            {
                string expectedProtocolText = null;
                uint port;

                if (MNM.AzureFirewallApplicationRuleProtocolType.Http.Equals(userProtocolText, StringComparison.InvariantCultureIgnoreCase))
                {
                    expectedProtocolText = MNM.AzureFirewallApplicationRuleProtocolType.Http;
                    port = 80;
                }
                else if (MNM.AzureFirewallApplicationRuleProtocolType.Https.Equals(userProtocolText, StringComparison.InvariantCultureIgnoreCase))
                {
                    expectedProtocolText = MNM.AzureFirewallApplicationRuleProtocolType.Https;
                    port = 443;
                }
                else
                {
                    throw new ArgumentException($"Unsupported protocol {userProtocolText}.");
                }

                return new PSAzureFirewallApplicationRuleProtocol
                {
                    ProtocolType = expectedProtocolText,
                    Port = port
                };
            }).ToList();

            var applicationRule = new PSAzureFirewallApplicationRule
            {
                Name = this.Name,
                Description = this.Description,
                Protocols = protocolsAsWeExpectThem,
                TargetUrls = this.TargetFqdn
            };
            WriteObject(applicationRule);
        }
    }
}

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
            Mandatory = false,
            HelpMessage = "The source addresses of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> SourceAddress { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The target FQDNs of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> TargetFqdn { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The protocols of the rule")]
        [ValidateNotNullOrEmpty]
        public List<string> Protocol { get; set; }
        
        public override void Execute()
        {
            base.Execute();

            if (this.Protocol == null || this.Protocol.Count == 0)
            {
                throw new ArgumentException("At least one application rule protocol should be specified!");
            }

            if (this.TargetFqdn == null || this.TargetFqdn.Count == 0)
            {
                throw new ArgumentException("At least one application rule target FQDN should be specified!");
            }

            var protocolsAsWeExpectThem = MapUserProtocolsToFirewallProtocols(Protocol);

            var applicationRule = new PSAzureFirewallApplicationRule
            {
                Name = this.Name,
                Description = this.Description,
                SourceAddresses = this.SourceAddress,
                Protocols = protocolsAsWeExpectThem,
                TargetUrls = this.TargetFqdn
            };
            WriteObject(applicationRule);
        }

        private List<PSAzureFirewallApplicationRuleProtocol> MapUserProtocolsToFirewallProtocols(List<string> userProtocols)
        {
            var protocolRegEx = new Regex("^[hH][tT][tT][pP][sS]?(:[1-9][0-9]*)?$");

            var supportedProtocolsAndTheirDefaultPorts = new List<PSAzureFirewallApplicationRuleProtocol>
            {
                new PSAzureFirewallApplicationRuleProtocol { ProtocolType = MNM.AzureFirewallApplicationRuleProtocolType.Http, Port = 80 },
                new PSAzureFirewallApplicationRuleProtocol { ProtocolType = MNM.AzureFirewallApplicationRuleProtocolType.Https, Port = 443 }
            };

            // User can pass "http", "HTtP" or "hTTp:8080"
            var protocolsAsWeExpectThem = this.Protocol.Select(userText =>
            {
                //The actual validation is performed in NRP. Here we are just trying to map user info to our model
                if (!protocolRegEx.IsMatch(userText))
                {
                    throw new ArgumentException($"Invalid protocol {userText}");
                }

                var userParts = userText.Split(':');
                var userProtocolText = userParts[0];
                var userPortText = userParts.Length == 2 ? userParts[1] : null;

                PSAzureFirewallApplicationRuleProtocol supportedProtocol;
                try
                {
                    supportedProtocol = supportedProtocolsAndTheirDefaultPorts.Single(protocol => protocol.ProtocolType.Equals(userProtocolText, StringComparison.InvariantCultureIgnoreCase));
                }
                catch
                {
                    throw new ArgumentException($"Unsupported protocol {userProtocolText}. Supported protocols are {string.Join(", ", supportedProtocolsAndTheirDefaultPorts.Select(proto => proto.ProtocolType))}", nameof(Protocol));
                }

                uint port;
                if (userPortText == null)
                {
                    // Use default port for this protocol
                    port = supportedProtocol.Port;
                }
                else if (!uint.TryParse(userPortText, out port))
                {
                    throw new ArgumentException($"Invalid port {userText}", nameof(Protocol));
                }

                return new PSAzureFirewallApplicationRuleProtocol
                {
                    ProtocolType = supportedProtocol.ProtocolType,
                    Port = port
                };
            }).ToList();

            return protocolsAsWeExpectThem;
        }
    }
}

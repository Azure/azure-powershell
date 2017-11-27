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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    using System.Linq;

    [Cmdlet(VerbsCommon.Set, "AzureRmSecureGatewayNetworkRuleConfig"), OutputType(typeof(PSSecureGatewayNetworkRuleCollection))]
    public class SetAzureSecureGatewayNetworkRuleConfigCommand : AzureSecureGatewayNetworkRuleConfigBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The SecureGatewayNetworkRuleCollection")]
        public PSSecureGatewayNetworkRuleCollection SecureGatewayNetworkRuleCollection { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.Protocols == null || this.Protocols.Count == 0)
            {
                throw new ArgumentException("At least one network rule protocol should be specified!");
            }
            if (this.SourcePorts == null || this.SourcePorts.Count == 0)
            {
                throw new ArgumentException("At least one network rule source IP should be specified!");
            }
            if (this.DestinationPorts == null || this.DestinationPorts.Count == 0)
            {
                throw new ArgumentException("At least one network rule destination IP should be specified!");
            }
            if (this.SourcePorts == null || this.SourcePorts.Count == 0)
            {
                throw new ArgumentException("At least one network rule source port should be specified!");
            }
            if (this.DestinationPorts == null || this.DestinationPorts.Count == 0)
            {
                throw new ArgumentException("At least one network rule destination port should be specified!");
            }
            if (this.Actions == null || this.Actions.Count == 0)
            {
                throw new ArgumentException("At least one network rule action should be specified!");
            }

            // Verify if the networkRule exists in the SecureGateway
            var networkRule = this.SecureGatewayNetworkRuleCollection.Rules.SingleOrDefault(rule => string.Equals(rule.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (networkRule == null)
            {
                throw new ArgumentException("Network rule with the specified name does not exist");
            }

            networkRule.Name = this.Name;
            networkRule.Priority = this.Priority;
            networkRule.Description = this.Description;
            networkRule.Direction = this.Direction;
            networkRule.Protocols = this.Protocols;
            networkRule.SourceIps = this.SourceIps;
            networkRule.DestinationIps = this.DestinationIps;
            networkRule.SourcePorts = this.SourcePorts;
            networkRule.DestinationPorts = this.DestinationPorts;
            networkRule.Actions = this.Actions;
            WriteObject(this.SecureGatewayNetworkRuleCollection);
        }
    }
}

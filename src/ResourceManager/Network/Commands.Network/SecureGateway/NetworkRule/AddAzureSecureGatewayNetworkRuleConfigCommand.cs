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
    [Cmdlet(VerbsCommon.Add, "AzureRmSecureGatewayNetworkRuleConfig", SupportsShouldProcess = true), OutputType(typeof(PSSecureGatewayNetworkRuleCollection))]
    public class AddAzureSecureGatewayNetworkRuleConfigCommand : AzureSecureGatewayNetworkRuleConfigBase
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

            var networkRule = new PSSecureGatewayNetworkRule
            {
                Name = this.Name,
                Priority = this.Priority,
                Description = this.Description,
                Direction = this.Direction,
                Protocols = this.Protocols,
                SourceIps = this.SourceIps,
                DestinationIps = this.DestinationIps,
                SourcePorts = this.SourcePorts,
                DestinationPorts = this.DestinationPorts,
                Actions = this.Actions
            };

            this.SecureGatewayNetworkRuleCollection.Rules.Add(networkRule);
            WriteObject(this.SecureGatewayNetworkRuleCollection);
        }
    }
}

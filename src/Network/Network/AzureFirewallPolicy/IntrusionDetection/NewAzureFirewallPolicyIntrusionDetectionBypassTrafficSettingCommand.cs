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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New,
            ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyIntrusionDetectionBypassTraffic",
            SupportsShouldProcess = true),
            OutputType(typeof(PSAzureFirewallPolicyIntrusionDetectionBypassTrafficSetting))]
    public class NewAzureFirewallPolicyIntrusionDetectionBypassTrafficCommand : NetworkBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             HelpMessage = "Bypass setting name."
         )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "Bypass setting description."
         )]
        public string Description { get; set; }

        [Parameter(
             Mandatory = true,
             HelpMessage = "Bypass setting protocol."
         )]
        [ValidateSet(
            MNM.FirewallPolicyIntrusionDetectionProtocol.TCP,
            MNM.FirewallPolicyIntrusionDetectionProtocol.UDP,
            MNM.FirewallPolicyIntrusionDetectionProtocol.ICMP,
            MNM.FirewallPolicyIntrusionDetectionProtocol.ANY,
            IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string Protocol { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "List of source IP addresses or ranges."
         )]
        public string[] SourceAddress { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "List of destination IP addresses or ranges."
         )]
        public string[] DestinationAddress { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "List of source IpGroups."
         )]
        public string[] SourceIpGroup { get; set; }

        [Parameter(
             Mandatory = false,
             HelpMessage = "List of destination IpGroups."
         )]
        public string[] DestinationIpGroup { get; set; }

        [Parameter(
             Mandatory = true,
             HelpMessage = "List of destination ports or ranges."
         )]
        [ValidateNotNullOrEmpty]
        public string[] DestinationPort { get; set; }

        public override void Execute()
        {
            base.Execute();

            var bypassTrafficSetting = new PSAzureFirewallPolicyIntrusionDetectionBypassTrafficSetting
            {
                Name = this.Name,
                Description = this.Description,
                Protocol = this.Protocol,
                SourceAddresses = this.SourceAddress?.ToList(),
                DestinationAddresses = this.DestinationAddress?.ToList(),
                SourceIpGroups = this.SourceIpGroup?.ToList(),
                DestinationIpGroups = this.DestinationIpGroup?.ToList(),
                DestinationPorts = this.DestinationPort.ToList()
            };

            WriteObject(bypassTrafficSetting);
        }

    }
}

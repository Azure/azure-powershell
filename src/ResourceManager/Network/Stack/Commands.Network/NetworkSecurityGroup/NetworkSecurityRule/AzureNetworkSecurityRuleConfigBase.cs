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

using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureNetworkSecurityRuleConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the rule")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The description of the rule")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Rule protocol")]
        [ValidateSet(
            MNM.SecurityRuleProtocol.Tcp,
            MNM.SecurityRuleProtocol.Udp,
            MNM.SecurityRuleProtocol.Asterisk,
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Source Port Range rule")]
        [ValidateNotNullOrEmpty]
        public string SourcePortRange { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination Port Range rule")]
        [ValidateNotNullOrEmpty]
        public string DestinationPortRange { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Source Address Prefix  rule")]
        [ValidateNotNullOrEmpty]
        public string SourceAddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination Address Prefix rule")]
        [ValidateNotNullOrEmpty]
        public string DestinationAddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The description of the rule")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.SecurityRuleAccess.Allow,
            MNM.SecurityRuleAccess.Deny,
            IgnoreCase = true)]
        public string Access { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The prioroty of the rule")]
        [ValidateNotNullOrEmpty]
        public int Priority { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The direction of the rule")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.SecurityRuleDirection.Inbound,
            MNM.SecurityRuleDirection.Outbound,
            IgnoreCase = true)]
        public string Direction { get; set; }
    }
}

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
using System.Text;
using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    class PSSynapseIpFirewallRule
    {
        public PSSynapseIpFirewallRule(IpFirewallRuleInfo ipFirewallRuleInfo)
        {
            this.EndIpAddress=ipFirewallRuleInfo?.EndIpAddress;
            this.ProvisioningState = ipFirewallRuleInfo?.ProvisioningState;
            this.StartIpAddress = ipFirewallRuleInfo?.StartIpAddress;
        }

        /// <summary>
        ///  Gets or sets the end IP address of the firewall rule. Must be IPv4 format. Must be greater than or equal to startIpAddress
        /// </summary>
        public string EndIpAddress { get; set; }

        /// <summary>
        ///  Gets resource provisioning state. Possible values include: 'Provisioning', 'Succeeded', 'Deleting', 'Failed', 'DeleteError'
        /// </summary>
        public string ProvisioningState { get; }

        /// <summary>
        /// Gets or sets the start IP address of the firewall rule. Must be IPv4 format
        /// </summary>
        public string StartIpAddress { get; set; }
    }
}

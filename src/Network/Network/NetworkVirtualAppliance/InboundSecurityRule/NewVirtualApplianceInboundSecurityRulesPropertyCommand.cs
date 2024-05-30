
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

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualApplianceInboundSecurityRulesProperty",
        SupportsShouldProcess = true),
        OutputType(typeof(PSInboundSecurityRulesProperty))]
    public class NewVirtualApplianceInboundSecurityRulesPropertyCommand : VirtualApplianceInboundSecurityRuleBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           HelpMessage = "Name of the Inbound Security Rules Property")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Rule protocol")]
        [ValidateSet(
            SecurityRuleProtocol.Tcp,
            SecurityRuleProtocol.Udp,
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Protocol { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "The Source Address Prefix of the rule")]
        public string SourceAddressPrefix { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Destination Port Range of the rule")]
        public int? DestinationPortRange { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Destination Port Ranges of the rule")]
        public string[] DestinationPortRangeList { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "The Applies On value of the rule for the SLP IP/Interface")]
        public string[] AppliesOn { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.DestinationPortRange.HasValue && (this.DestinationPortRangeList == null || this.DestinationPortRangeList.Length == 0))
            {
                throw new PSArgumentException("Both 'DestinationPortRange' and 'DestinationPortRangeList' cannot be null. Please make sure to input value for one of the parameters.");
            }

            if (this.DestinationPortRange.HasValue && this.DestinationPortRangeList != null && this.DestinationPortRangeList.Length >= 0)
            {
                throw new PSArgumentException("Both 'DestinationPortRange' and 'DestinationPortRangeList' cannot have values. Please make sure to input value for only one of the parameters.");
            }

            var rule = new PSInboundSecurityRulesProperty();
            rule.Name = this.Name;
            rule.Protocol = this.Protocol;
            rule.SourceAddressPrefix = this.SourceAddressPrefix;
            rule.DestinationPortRange = this.DestinationPortRange;
            rule.DestinationPortRanges = this.DestinationPortRangeList !=null ? this.DestinationPortRangeList.ToList() : null;
            rule.AppliesOn = this.AppliesOn.ToList();

            WriteObject(rule, true);

        }
    }
}

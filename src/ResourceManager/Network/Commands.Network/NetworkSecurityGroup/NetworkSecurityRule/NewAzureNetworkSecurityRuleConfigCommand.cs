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
using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmNetworkSecurityRuleConfig"), OutputType(typeof(PSSecurityRule))]
    public class NewAzureNetworkSecurityRuleConfigCommand : AzureNetworkSecurityRuleConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the rule")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        public override void Execute()
        {

            base.Execute();

            if (!string.IsNullOrWhiteSpace(this.SourceAddressPrefix) && (this.SourceApplicationSecurityGroup != null))
            {
                throw new ArgumentException($"{nameof(SourceAddressPrefix)} and {nameof(SourceApplicationSecurityGroup)} cannot be used simultaneously.");
            }

            if (!string.IsNullOrWhiteSpace(this.SourceAddressPrefix) && (this.SourceApplicationSecurityGroupId != null))
            {
                throw new ArgumentException($"{nameof(SourceAddressPrefix)} and {nameof(SourceApplicationSecurityGroupId)} cannot be used simultaneously.");
            }

            if (!string.IsNullOrWhiteSpace(this.DestinationAddressPrefix) && (this.DestinationApplicationSecurityGroup != null))
            {
                throw new ArgumentException($"{nameof(DestinationAddressPrefix)} and {nameof(DestinationApplicationSecurityGroup)} cannot be used simultaneously.");
            }

            if (!string.IsNullOrWhiteSpace(this.DestinationAddressPrefix) && (this.DestinationApplicationSecurityGroupId != null))
            {
                throw new ArgumentException($"{nameof(DestinationAddressPrefix)} and {nameof(DestinationApplicationSecurityGroupId)} cannot be used simultaneously.");
            }

            var rule = new PSSecurityRule();

            rule.Name = this.Name;
            rule.Description = this.Description;
            rule.Protocol = this.Protocol;
            rule.SourcePortRange = this.SourcePortRange;
            rule.DestinationPortRange = this.DestinationPortRange;
            rule.SourceAddressPrefix = this.SourceAddressPrefix;
            rule.DestinationAddressPrefix = this.DestinationAddressPrefix;
            rule.Access = this.Access;
            rule.Priority = this.Priority;
            rule.Direction = this.Direction;

            SetSourceApplicationSecurityGroupInRule(rule);
            SetDestinationApplicationSecurityGroupInRule(rule);

            WriteObject(rule);
        }

    }
}

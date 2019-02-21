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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkSecurityRuleConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSNetworkSecurityGroup))]
    public class UpdateAzureNetworkSecurityRuleConfigCommand : AzureNetworkSecurityRuleConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the rule")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The NetworkSecurityGroup")]
        public PSNetworkSecurityGroup NetworkSecurityGroup { get; set; }

        public override void Execute()
        {
            base.Execute();

            if ((this.SourceAddressPrefix != null) && (this.SourceAddressPrefix.Length > 0) && (this.SourceApplicationSecurityGroup != null) && (this.SourceApplicationSecurityGroup.Length > 0))
            {
                throw new ArgumentException($"{nameof(SourceAddressPrefix)} and {nameof(SourceApplicationSecurityGroup)} cannot be used simultaneously.");
            }

            if ((this.SourceAddressPrefix != null) && (this.SourceAddressPrefix.Length > 0) && (this.SourceApplicationSecurityGroupId != null) && (this.SourceApplicationSecurityGroupId.Length > 0))
            {
                throw new ArgumentException($"{nameof(SourceAddressPrefix)} and {nameof(SourceApplicationSecurityGroupId)} cannot be used simultaneously.");
            }

            if ((this.DestinationAddressPrefix != null) && (this.DestinationAddressPrefix.Length > 0) && (this.DestinationApplicationSecurityGroup != null) && (this.DestinationApplicationSecurityGroup.Length > 0))
            {
                throw new ArgumentException($"{nameof(DestinationAddressPrefix)} and {nameof(DestinationApplicationSecurityGroup)} cannot be used simultaneously.");
            }

            if ((this.DestinationAddressPrefix != null) && (this.DestinationAddressPrefix.Length > 0) && (this.DestinationApplicationSecurityGroupId != null) && (this.DestinationApplicationSecurityGroupId.Length > 0))
            {
                throw new ArgumentException($"{nameof(DestinationAddressPrefix)} and {nameof(DestinationApplicationSecurityGroupId)} cannot be used simultaneously.");
            }

            // Verify if the subnet exists in the NetworkSecurityGroup
            var rule = this.NetworkSecurityGroup.SecurityRules.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (rule == null)
            {
                throw new ArgumentException("Rule with the specified name does not exist");
            }

            if (this.Description != null)
            {
                rule.Description = this.Description;
            }

            if (this.Protocol != null)
            {
                rule.Protocol = this.Protocol;
            }

            if (this.SourcePortRange != null)
            {
                rule.SourcePortRange = this.SourcePortRange;
            }

            if (this.DestinationPortRange != null)
            {
                rule.DestinationPortRange = this.DestinationPortRange;
            }

            if (this.SourceAddressPrefix != null)
            {
                rule.SourceAddressPrefix = this.SourceAddressPrefix;
            }

            if (this.DestinationAddressPrefix != null)
            {
                rule.DestinationAddressPrefix = this.DestinationAddressPrefix;
            }

            if (this.Access != null)
            {
                rule.Access = this.Access;
            }

            if (MyInvocation.BoundParameters.ContainsKey("Priority"))
            {
                rule.Priority = this.Priority;
            }

            if (this.Direction != null)
            {
                rule.Direction = this.Direction;
            }

            if ((this.SourceApplicationSecurityGroup != null) || (this.SourceApplicationSecurityGroupId != null))
            {
                SetSourceApplicationSecurityGroupInRule(rule);
            }

            if ((this.DestinationApplicationSecurityGroup != null) || (this.DestinationApplicationSecurityGroupId != null))
            {
                SetDestinationApplicationSecurityGroupInRule(rule);
            }

            WriteObject(this.NetworkSecurityGroup);
        }
    }
}

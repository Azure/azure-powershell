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
    [Cmdlet(VerbsCommon.Add, "AzureRmNetworkSecurityRuleConfig"), OutputType(typeof(PSNetworkSecurityGroup))]
    public class AddAzureNetworkSecurityRuleConfigCommand : AzureNetworkSecurityRuleConfigBase
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
            // Verify if the subnet exists in the NetworkSecurityGroup
            var rule = this.NetworkSecurityGroup.SecurityRules.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (rule != null)
            {
                throw new ArgumentException("Rule with the specified name already exists");
            }

            rule = new PSSecurityRule();

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

            this.NetworkSecurityGroup.SecurityRules.Add(rule);

            WriteObject(this.NetworkSecurityGroup);
        }
    }
}

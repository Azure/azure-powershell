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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
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
        public List<string> SourcePortRange { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination Port Range rule")]
        [ValidateNotNullOrEmpty]
        public List<string> DestinationPortRange { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Source Address Prefix  rule")]
        [ValidateNotNullOrEmpty]
        public List<string> SourceAddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Destination Address Prefix rule")]
        [ValidateNotNullOrEmpty]
        public List<string> DestinationAddressPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResource",
            HelpMessage = "The application security group set as source for the rule. It cannot be used with 'SourceAddressPrefix' parameter.")]
        public List<PSApplicationSecurityGroup> SourceApplicationSecurityGroup { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResource",
            HelpMessage = "The application security group set as destination for the rule. It cannot be used with 'DestinationAddressPrefix' parameter.")]
        public List<PSApplicationSecurityGroup> DestinationApplicationSecurityGroup { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "The application security group set as source for the rule. It cannot be used with 'SourceAddressPrefix' parameter.")]
        public List<string> SourceApplicationSecurityGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "The application security group set as destination for the rule. It cannot be used with 'DestinationAddressPrefix' parameter.")]
        public List<string> DestinationApplicationSecurityGroupId { get; set; }

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

        protected void SetDestinationApplicationSecurityGroupInRule(PSSecurityRule rule)
        {
            if ((this.DestinationApplicationSecurityGroup != null) || (this.DestinationApplicationSecurityGroupId != null))
            {
                rule.DestinationApplicationSecurityGroups = new List<PSApplicationSecurityGroup>();
            }

            if (this.DestinationApplicationSecurityGroup != null)
            {
                foreach (var psApplicationSecurityGroup in this.DestinationApplicationSecurityGroup)
                {
                    rule.DestinationApplicationSecurityGroups.Add(psApplicationSecurityGroup);
                }
            }

            if (this.DestinationApplicationSecurityGroupId != null)
            {
                foreach (var psApplicationSecurityGroupId in this.DestinationApplicationSecurityGroupId)
                {
                    rule.DestinationApplicationSecurityGroups.Add(new PSApplicationSecurityGroup { Id = psApplicationSecurityGroupId });
                }
            }
        }

        protected void SetSourceApplicationSecurityGroupInRule(PSSecurityRule rule)
        {
            if ((this.SourceApplicationSecurityGroup != null) || (this.SourceApplicationSecurityGroupId != null))
            {
                rule.SourceApplicationSecurityGroups = new List<PSApplicationSecurityGroup>();
            }

            if (this.SourceApplicationSecurityGroup != null)
            {
                foreach (var psApplicationSecurityGroup in this.SourceApplicationSecurityGroup)
                {
                    rule.SourceApplicationSecurityGroups.Add(psApplicationSecurityGroup);
                }
            }

            if (this.SourceApplicationSecurityGroupId != null)
            {
                foreach (var psApplicationSecurityGroupId in this.SourceApplicationSecurityGroupId)
                {
                    rule.SourceApplicationSecurityGroups.Add(new PSApplicationSecurityGroup { Id = psApplicationSecurityGroupId });
                }
            }
        }
    }
}

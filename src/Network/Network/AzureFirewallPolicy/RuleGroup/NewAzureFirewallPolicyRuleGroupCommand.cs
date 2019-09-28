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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyRuleGroup", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallPolicyRuleGroup))]
    public class NewAzureFirewallPolicyRuleGroupCommand : AzureFirewallPolicyRuleGroupBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Rule Group")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The priority of the rule group")]
        [ValidateRange(100, 65000)]
        public uint Priority { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of application rules")]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicyBaseRule[] Rules { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "location.")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
                   Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Firewall Policy.")]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicy AzureFirewallPolicy { get; set; }

        public override void Execute()
        {
            base.Execute();

            var applicationRc = new PSAzureFirewallPolicyRuleGroup
            {
                Name = this.Name,
                Priority = this.Priority,
                Rules = this.Rules?.ToList(),
            };


            // Map to the sdk object
            var azureFirewallModel = NetworkResourceManagerProfile.Mapper.Map<MNM.FirewallPolicyRuleGroup>(applicationRc);

            // Execute the Create AzureFirewall call
            FirewallPolicyRuleGroupsOperationsExtensions.CreateOrUpdate(NetworkClient.NetworkManagementClient.FirewallPolicyRuleGroups, this.ResourceGroupName, this.AzureFirewallPolicy.Name, this.Name, azureFirewallModel);

            WriteObject(applicationRc);
        }
    }
}

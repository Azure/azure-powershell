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
using Newtonsoft.Json;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyRuleCollectionGroup", SupportsShouldProcess = true, DefaultParameterSetName = SetByNameParameterSet), OutputType(typeof(PSAzureFirewallPolicyRuleCollectionGroup))]
    public class NewAzureFirewallPolicyRuleCollectionGroupCommand : AzureFirewallPolicyRuleCollectionGroupBaseCmdlet
    {

        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";

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
            Mandatory = false,
            HelpMessage = "The list of rule collections")]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicyBaseRuleCollection[] RuleCollection { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
                   Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Firewall Policy.", ParameterSetName = SetByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicy FirewallPolicyObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the firewall policy", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string FirewallPolicyName { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (this.IsParameterBound(c => c.FirewallPolicyObject))
            {
                FirewallPolicyName = FirewallPolicyObject.Name;
                ResourceGroupName = FirewallPolicyObject.ResourceGroupName;
            }

            var ruleGroup = new PSAzureFirewallPolicyRuleCollectionGroup
            {
                Priority = this.Priority,
                RuleCollection = this.RuleCollection?.ToList(),
            };

            var rcWrapper = new PSAzureFirewallPolicyRuleCollectionGroupWrapper
            {
                Name = this.Name,
                Properties = ruleGroup
            };

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            string serializedObject = JsonConvert.SerializeObject(rcWrapper, settings);
            var json = serializedObject.Replace("'", "\"");
            var deserializedruleGroup = (MNM.FirewallPolicyRuleGroup)JsonConvert.DeserializeObject(
                                        json,
                                        typeof(MNM.FirewallPolicyRuleGroup),
                                        new JsonConverter[] { new Iso8601TimeSpanConverter(), new PolymorphicJsonCustomConverter<MNM.FirewallPolicyRule, MNM.FirewallPolicyRuleCondition>("ruleType", "ruleConditionType"), new TransformationJsonConverter() });
            this.AzureFirewallPolicyRuleGroupClient.CreateOrUpdate(this.ResourceGroupName, this.FirewallPolicyName, deserializedruleGroup.Name, deserializedruleGroup);
            WriteObject(rcWrapper);
        }
    }
}

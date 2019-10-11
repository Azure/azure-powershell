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
using Microsoft.Rest.Serialization;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyRuleCollectionGroup", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallPolicyRuleCollectionGroup))]
    public class SetAzureFirewallPolicyRuleGroupCommand : AzureFirewallPolicyRuleCollectionGroupBaseCmdlet
    {

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of rules")]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicyRuleCollectionGroupWrapper InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
                   Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Firewall Policy.")]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicy AzureFirewallPolicy { get; set; }

        public override void Execute()
        {
            base.Execute();

            var ruleGroup = new PSAzureFirewallPolicyRuleCollectionGroup
            {
                priority = InputObject.properties.priority,
                ruleCollection = InputObject.properties.ruleCollection?.ToList()
            };
            
            var rcWrapper = new PSAzureFirewallPolicyRuleCollectionGroupWrapper
            {
                name = InputObject.name,
                properties = ruleGroup
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
            this.AzureFirewallPolicyRuleGroupClient.CreateOrUpdate(this.ResourceGroupName, this.AzureFirewallPolicy.Name, deserializedruleGroup.Name, deserializedruleGroup);
            WriteObject(InputObject);
        }
    }
}

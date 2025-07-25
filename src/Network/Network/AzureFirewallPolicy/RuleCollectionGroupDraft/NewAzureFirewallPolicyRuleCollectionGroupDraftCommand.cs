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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network;
using Newtonsoft.Json;
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyRuleCollectionGroupDraft", SupportsShouldProcess = true, DefaultParameterSetName = SetByNameParameterSet), OutputType(typeof(PSAzureFirewallPolicyRuleCollectionGroupDraft))]
    public class NewAzureFirewallPolicyRuleCollectionGroupDraftCommand : AzureFirewallPolicyRuleCollectionGroupDraftCmdlet
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByParentInputObjectParameterSet = "SetByInputObjectParameterSet";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Rule Group")]
        [ValidateNotNullOrEmpty]
        public virtual string AzureFirewallPolicyRuleCollectionGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the firewall policy", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string AzureFirewallPolicyName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Firewall Policy.", ParameterSetName = SetByParentInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicy FirewallPolicyObject { get; set; }

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

        public override void Execute()
        {
            base.Execute();
            if (this.IsParameterBound(c => c.FirewallPolicyObject))
            {
                this.AzureFirewallPolicyName = FirewallPolicyObject.Name;
                this.ResourceGroupName = FirewallPolicyObject.ResourceGroupName;
            }

            var ruleGroup = new PSAzureFirewallPolicyRuleCollectionGroupDraft
            {
                Priority = this.Priority,
                RuleCollection = this.RuleCollection?.ToList(),
            };

            var rcWrapper = new PSAzureFirewallPolicyRuleCollectionGroupDraftWrapper
            {
                Name = this.AzureFirewallPolicyRuleCollectionGroupName,
                Properties = ruleGroup
            };

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            string serializedObject = JsonConvert.SerializeObject(rcWrapper, settings);
            var json = serializedObject.Replace("'", "\"");
            var deserializedRuleGroup = (MNM.FirewallPolicyRuleCollectionGroupDraft)JsonConvert.DeserializeObject(
                                        json,
                                        typeof(MNM.FirewallPolicyRuleCollectionGroupDraft),
                                        new JsonConverter[] { new Iso8601TimeSpanConverter(), new PolymorphicJsonCustomConverter<MNM.FirewallPolicyRuleCollection, MNM.FirewallPolicyRule>("ruleCollectionType", "ruleType"), new TransformationJsonConverter() });
            this.AzureFirewallPolicyRuleCollectionGroupDraftClient.CreateOrUpdate(this.ResourceGroupName, this.AzureFirewallPolicyName, AzureFirewallPolicyRuleCollectionGroupName, deserializedRuleGroup);
            WriteObject(rcWrapper);
        }
    }
}

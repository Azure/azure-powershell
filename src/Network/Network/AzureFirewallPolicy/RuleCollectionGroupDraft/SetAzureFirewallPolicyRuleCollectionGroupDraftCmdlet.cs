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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyRuleCollectionGroupDraft", SupportsShouldProcess = true, DefaultParameterSetName = SetByNameParameterSet), OutputType(typeof(PSAzureFirewallPolicyRuleCollectionGroupDraft))]
    public class SetAzureFirewallPolicyRuleCollectionGroupDraftCommand : AzureFirewallPolicyRuleCollectionGroupDraftCmdlet
    {

        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByParentObjectParameterSet = "SetByParentInputObjectParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";


        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the rule collection group.", ParameterSetName = SetByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string AzureFirewallPolicyRuleCollectionGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The list of rules", ParameterSetName = SetByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicyRuleCollectionGroupDraftWrapper InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Firewall Policy", ParameterSetName = SetByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicy FirewallPolicyObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Id of the Rule collection group", ParameterSetName = SetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The name of the firewall policy", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string AzureFirewallPolicyName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The priority of the rule group")]
        [ValidateRange(100, 65000)]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByResourceIdParameterSet)]
        public uint Priority { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The list of rule collections")]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicyBaseRuleCollection[] RuleCollection { get; set; }

        public override void Execute()
        {
            base.Execute();
            var ruleGroupDraft = new PSAzureFirewallPolicyRuleCollectionGroupDraft();
            var rcWrapperDraft = new PSAzureFirewallPolicyRuleCollectionGroupDraftWrapper();

            if (this.IsParameterBound(c => c.InputObject))
            {
                var resourceInfo = new ResourceIdentifier(InputObject.Properties.Id);
                this.AzureFirewallPolicyName = ExtractFirewallPolicyNameFromDraftResourceId(resourceInfo.ParentResource);
                this.AzureFirewallPolicyRuleCollectionGroupName = ExtractFirewallPolicyRCGNameFromDraftResourceId(resourceInfo.ParentResource);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;

                ruleGroupDraft = new PSAzureFirewallPolicyRuleCollectionGroupDraft
                {
                    Priority = this.IsParameterBound(c => c.Priority) ? Priority : InputObject.Properties.Priority,
                    RuleCollection = this.IsParameterBound(c => c.RuleCollection) ? RuleCollection.ToList() : InputObject.Properties.RuleCollection?.ToList()
                };

                rcWrapperDraft = new PSAzureFirewallPolicyRuleCollectionGroupDraftWrapper
                {
                    Name = this.AzureFirewallPolicyRuleCollectionGroupName,
                    Properties = ruleGroupDraft
                };

            }
            else if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.AzureFirewallPolicyName = ExtractFirewallPolicyNameFromDraftResourceId(resourceInfo.ParentResource);
                this.AzureFirewallPolicyRuleCollectionGroupName = ExtractFirewallPolicyRCGNameFromDraftResourceId(resourceInfo.ParentResource);

                ruleGroupDraft = new PSAzureFirewallPolicyRuleCollectionGroupDraft
                {
                    Priority = Priority,
                    RuleCollection = this.RuleCollection?.ToList()
                };
                rcWrapperDraft = new PSAzureFirewallPolicyRuleCollectionGroupDraftWrapper
                {
                    Name = this.AzureFirewallPolicyRuleCollectionGroupName,
                    Properties = ruleGroupDraft
                };
            }
            else if (this.IsParameterBound(c => c.FirewallPolicyObject))
            {
                this.ResourceGroupName = FirewallPolicyObject.ResourceGroupName;
                this.AzureFirewallPolicyName = FirewallPolicyObject.Name;

                ruleGroupDraft = new PSAzureFirewallPolicyRuleCollectionGroupDraft
                {
                    Priority = Priority,
                    RuleCollection = this.RuleCollection?.ToList()
                };
                rcWrapperDraft = new PSAzureFirewallPolicyRuleCollectionGroupDraftWrapper
                {
                    Name = this.AzureFirewallPolicyRuleCollectionGroupName,
                    Properties = ruleGroupDraft
                };
            }
            else if (this.IsParameterBound(c => c.AzureFirewallPolicyName))
            {
                ruleGroupDraft = new PSAzureFirewallPolicyRuleCollectionGroupDraft
                {
                    Priority = Priority,
                    RuleCollection = this.RuleCollection?.ToList()
                };
                rcWrapperDraft = new PSAzureFirewallPolicyRuleCollectionGroupDraftWrapper
                {
                    Name = this.AzureFirewallPolicyRuleCollectionGroupName,
                    Properties = ruleGroupDraft
                };
            }

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            string serializedObject = JsonConvert.SerializeObject(rcWrapperDraft, settings);
            var json = serializedObject.Replace("'", "\"");

            var deserializedRuleGroup = (MNM.FirewallPolicyRuleCollectionGroupDraft)JsonConvert.DeserializeObject(
                                        json,
                                        typeof(MNM.FirewallPolicyRuleCollectionGroupDraft),
                                        new JsonConverter[] { new Iso8601TimeSpanConverter(), new PolymorphicJsonCustomConverter<MNM.FirewallPolicyRuleCollection, MNM.FirewallPolicyRule>("ruleCollectionType", "ruleType"), new TransformationJsonConverter() });
            this.AzureFirewallPolicyRuleCollectionGroupDraftClient.CreateOrUpdate(this.ResourceGroupName, this.AzureFirewallPolicyName, this.AzureFirewallPolicyRuleCollectionGroupName, deserializedRuleGroup);
            WriteObject(InputObject);
        }
    }
}

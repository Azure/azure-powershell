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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyRuleCollectionGroup", SupportsShouldProcess = true, DefaultParameterSetName = SetByNameParameterSet), OutputType(typeof(PSAzureFirewallPolicyRuleCollectionGroup))]
    public class SetAzureFirewallPolicyRuleGroupCommand : AzureFirewallPolicyRuleCollectionGroupBaseCmdlet
    {

        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByParentObjectParameterSet = "SetByParentInputObjectParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";


        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.", ParameterSetName = SetByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The list of rules", ParameterSetName = SetByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicyRuleCollectionGroupWrapper InputObject { get; set; }

        [Parameter(
                   Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Firewall Policy.", ParameterSetName = SetByParentObjectParameterSet)]
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
            HelpMessage = "The resource Id of the Rule collection groupy", ParameterSetName = SetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/FirewallPolicies")]
        public virtual string ResourceId { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The name of the firewall policy", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string FirewallPolicyName { get; set; }

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
            var ruleGroup = new PSAzureFirewallPolicyRuleCollectionGroup();
            var rcWrapper = new PSAzureFirewallPolicyRuleCollectionGroupWrapper();

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.Name = InputObject.Name;
                var resourceId = InputObject.Properties.Id;

                var resourceInfo = new ResourceIdentifier(resourceId);
                this.FirewallPolicyName = resourceInfo.ParentResource.Split('/')[1];
                this.ResourceGroupName = resourceInfo.ResourceGroupName;

                ruleGroup = new PSAzureFirewallPolicyRuleCollectionGroup
                {
                    Priority = this.IsParameterBound(c => c.Priority) ? Priority : InputObject.Properties.Priority,
                    RuleCollection = this.IsParameterBound(c => c.RuleCollection) ? RuleCollection.ToList() : InputObject.Properties.RuleCollection?.ToList()
                };

                rcWrapper = new PSAzureFirewallPolicyRuleCollectionGroupWrapper
                {
                    Name = InputObject.Name,
                    Properties = ruleGroup
                };

            }
            else if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                this.Name = resourceInfo.ResourceName;
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.FirewallPolicyName = resourceInfo.ParentResource.Split('/')[1];
                ruleGroup = new PSAzureFirewallPolicyRuleCollectionGroup
                {
                    Priority = Priority,
                    RuleCollection = this.RuleCollection?.ToList()
                };
                rcWrapper = new PSAzureFirewallPolicyRuleCollectionGroupWrapper
                {
                    Name = this.Name,
                    Properties = ruleGroup
                };
            }
            else if (this.IsParameterBound(c => c.FirewallPolicyObject))
            {
                this.ResourceGroupName = FirewallPolicyObject.ResourceGroupName;
                this.FirewallPolicyName = FirewallPolicyObject.Name;
                ruleGroup = new PSAzureFirewallPolicyRuleCollectionGroup
                {
                    Priority = Priority,
                    RuleCollection = this.RuleCollection?.ToList()
                };
                rcWrapper = new PSAzureFirewallPolicyRuleCollectionGroupWrapper
                {
                    Name = this.Name,
                    Properties = ruleGroup
                };
            }
            else if (this.IsParameterBound(c => c.FirewallPolicyName))
            {
                ruleGroup = new PSAzureFirewallPolicyRuleCollectionGroup
                {
                    Priority = Priority,
                    RuleCollection = this.RuleCollection?.ToList()
                };
                rcWrapper = new PSAzureFirewallPolicyRuleCollectionGroupWrapper
                {
                    Name = this.Name,
                    Properties = ruleGroup
                };
            }

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
            this.AzureFirewallPolicyRuleGroupClient.CreateOrUpdate(this.ResourceGroupName, this.FirewallPolicyName, this.Name, deserializedruleGroup);
            WriteObject(InputObject);
        }
    }
}

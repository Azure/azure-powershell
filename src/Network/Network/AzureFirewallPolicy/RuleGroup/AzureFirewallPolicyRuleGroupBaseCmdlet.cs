
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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Newtonsoft.Json;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class AzureFirewallPolicyRuleCollectionGroupBaseCmdlet : NetworkBaseCmdlet
    {
        public IFirewallPolicyRuleGroupsOperations AzureFirewallPolicyRuleGroupClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.FirewallPolicyRuleGroups;
            }
        }

        public PSAzureFirewallPolicyRuleCollectionGroupWrapper GetAzureFirewallPolicyRuleGroup(string resourceGroupName, string firewallPolicyName, string name)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var getRuleCollectionGroup = this.AzureFirewallPolicyRuleGroupClient.Get(resourceGroupName, firewallPolicyName, name);

            var ruleCollectionGroup = new PSAzureFirewallPolicyRuleCollectionGroup();
            ruleCollectionGroup.ruleCollection = new List<PSAzureFirewallPolicyBaseRuleCollection>();

            for (int ruleCollectionIndex = 0; ruleCollectionIndex < getRuleCollectionGroup.Rules.Count; ruleCollectionIndex++)
            {
                var ruleCollection = new PSAzureFirewallPolicyBaseRuleCollection();
                if (getRuleCollectionGroup.Rules[ruleCollectionIndex] is MNM.FirewallPolicyFilterRule)
                {
                    MNM.FirewallPolicyFilterRule filterRule = (MNM.FirewallPolicyFilterRule)getRuleCollectionGroup.Rules[ruleCollectionIndex];
                    PSAzureFirewallPolicyFilterRuleCollection filterRuleCollection = JsonConvert.DeserializeObject<PSAzureFirewallPolicyFilterRuleCollection>(JsonConvert.SerializeObject(getRuleCollectionGroup.Rules[ruleCollectionIndex]));
                    filterRuleCollection.ruleCollectionType = "FirewallPolicyFilterRule";
                    filterRuleCollection.rules = new List<PSAzureFirewallPolicyRule>();
                    for (int ruleIndex = 0; ruleIndex < filterRule.RuleConditions.Count; ruleIndex++)
                    {
                        if (filterRule.RuleConditions[ruleIndex] is MNM.ApplicationRuleCondition)
                        {
                            PSAzureFirewallPolicyApplicationRule rule = JsonConvert.DeserializeObject<PSAzureFirewallPolicyApplicationRule>(JsonConvert.SerializeObject(filterRule.RuleConditions[ruleIndex]));
                            rule.ruleType = "ApplicationRuleCondition";
                            filterRuleCollection.rules.Add(rule);
                        }
                        else
                        {
                            PSAzureFirewallPolicyNetworkRule rule = JsonConvert.DeserializeObject<PSAzureFirewallPolicyNetworkRule>(JsonConvert.SerializeObject(filterRule.RuleConditions[ruleIndex]));
                            rule.ruleType = "NetworkRuleCondition";
                            filterRuleCollection.rules.Add(rule);
                        }
                    }
                    ruleCollectionGroup.ruleCollection.Add(filterRuleCollection);
                }
                else
                {
                    MNM.FirewallPolicyNatRule natRule = (MNM.FirewallPolicyNatRule)getRuleCollectionGroup.Rules[ruleCollectionIndex];
                    PSAzureFirewallPolicyNatRuleCollection natRuleCollection = JsonConvert.DeserializeObject<PSAzureFirewallPolicyNatRuleCollection>(JsonConvert.SerializeObject(getRuleCollectionGroup.Rules[ruleCollectionIndex]));
                    natRuleCollection.ruleCollectionType = "FirewallPolicyNatRule";
                    natRuleCollection.rule = JsonConvert.DeserializeObject<PSAzureFirewallPolicyNetworkRule>(JsonConvert.SerializeObject(natRule.RuleCondition));
                    natRuleCollection.rule.ruleType = "NetworkRuleCondition";
                    ruleCollectionGroup.ruleCollection.Add(natRuleCollection);
                }
            }

            var ruleCollectionGroupWrapper = new PSAzureFirewallPolicyRuleCollectionGroupWrapper();
            ruleCollectionGroup.priority = (uint)getRuleCollectionGroup.Priority;
            ruleCollectionGroupWrapper.properties = ruleCollectionGroup;
            ruleCollectionGroupWrapper.name = getRuleCollectionGroup.Name;
            ruleCollectionGroupWrapper.properties.Id = getRuleCollectionGroup.Id;

            return ruleCollectionGroupWrapper;
        }
    }
}

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.Common.Strategies;
using System.Text.RegularExpressions;
using System;

namespace Microsoft.Azure.Commands.Network {
    public abstract class AzureFirewallPolicyRuleCollectionGroupDraftCmdlet : NetworkBaseCmdlet
    {
        public IFirewallPolicyRuleCollectionGroupDraftsOperations AzureFirewallPolicyRuleCollectionGroupDraftClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.FirewallPolicyRuleCollectionGroupDrafts;
            }
        }

        protected string ExtractFirewallPolicyNameFromDraftResourceId(string resourceId)
        {
            string pattern = @"firewallpolicies\/([^,\/]+)";
            Match match = new Regex(pattern).Match(resourceId.ToLower());
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                throw new ArgumentException(Properties.Resources.InvalidResourceId);
            }
        }

        protected string ExtractFirewallPolicyRCGNameFromDraftResourceId(string resourceId)
        {
            string pattern = @"rulecollectiongroups\/([^,\/]+)";
            Match match = new Regex(pattern).Match(resourceId.ToLower());
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                throw new ArgumentException(Properties.Resources.InvalidResourceId);
            }
        }

        public PSAzureFirewallPolicyRuleCollectionGroupDraftWrapper GetAzureFirewallPolicyRuleCollectionGroupDraft(string resourceGroupName, string firewallPolicyName, string name)
        {
            var getRuleCollectionGroupDraft = this.AzureFirewallPolicyRuleCollectionGroupDraftClient.Get(resourceGroupName, firewallPolicyName, name);

            var ruleCollectionGroupDraft = new PSAzureFirewallPolicyRuleCollectionGroupDraft
            {
                RuleCollection = new List<PSAzureFirewallPolicyBaseRuleCollection>()
            };

            for (int ruleCollectionIndex = 0; ruleCollectionIndex < getRuleCollectionGroupDraft.RuleCollections.Count; ruleCollectionIndex++)
            {
                if (getRuleCollectionGroupDraft.RuleCollections[ruleCollectionIndex] is MNM.FirewallPolicyFilterRuleCollection)
                {
                    MNM.FirewallPolicyFilterRuleCollection filterRule = (MNM.FirewallPolicyFilterRuleCollection)getRuleCollectionGroupDraft.RuleCollections[ruleCollectionIndex];
                    PSAzureFirewallPolicyFilterRuleCollection filterRuleCollection = JsonConvert.DeserializeObject<PSAzureFirewallPolicyFilterRuleCollection>(JsonConvert.SerializeObject(getRuleCollectionGroupDraft.RuleCollections[ruleCollectionIndex]));
                    filterRuleCollection.RuleCollectionType = "FirewallPolicyFilterRuleCollection";
                    filterRuleCollection.Rules = new List<PSAzureFirewallPolicyRule>();
                    for (int ruleIndex = 0; ruleIndex < filterRule.Rules.Count; ruleIndex++)
                    {
                        if (filterRule.Rules[ruleIndex] is MNM.ApplicationRule)
                        {
                            PSAzureFirewallPolicyApplicationRule rule = JsonConvert.DeserializeObject<PSAzureFirewallPolicyApplicationRule>(JsonConvert.SerializeObject(filterRule.Rules[ruleIndex]));
                            rule.RuleType = "ApplicationRule";
                            filterRuleCollection.Rules.Add(rule);
                        }
                        else
                        {
                            PSAzureFirewallPolicyNetworkRule rule = JsonConvert.DeserializeObject<PSAzureFirewallPolicyNetworkRule>(JsonConvert.SerializeObject(filterRule.Rules[ruleIndex]));
                            rule.RuleType = "NetworkRule";
                            filterRuleCollection.Rules.Add(rule);
                        }
                    }
                    ruleCollectionGroupDraft.RuleCollection.Add(filterRuleCollection);
                }
                else
                {
                    var natRule = (MNM.FirewallPolicyNatRuleCollection)getRuleCollectionGroupDraft.RuleCollections[ruleCollectionIndex];
                    var natRuleCollection = JsonConvert.DeserializeObject<PSAzureFirewallPolicyNatRuleCollection>(JsonConvert.SerializeObject(getRuleCollectionGroupDraft.RuleCollections[ruleCollectionIndex]));
                    natRuleCollection.RuleCollectionType = "FirewallPolicyNatRuleCollection";
                    natRuleCollection.Rules = new List<PSAzureFirewallPolicyNatRule>();
                    for (int ruleIndex = 0; ruleIndex < natRule.Rules.Count; ruleIndex++)
                    {
                        var rule = JsonConvert.DeserializeObject<PSAzureFirewallPolicyNatRule>(JsonConvert.SerializeObject(natRule.Rules[ruleIndex]));
                        rule.RuleType = "NatRule";
                        natRuleCollection.Rules.Add(rule);
                    }

                    ruleCollectionGroupDraft.RuleCollection.Add(natRuleCollection);
                }
            }

            var ruleCollectionGroupWrapper = new PSAzureFirewallPolicyRuleCollectionGroupDraftWrapper();
            ruleCollectionGroupDraft.Priority = (uint)getRuleCollectionGroupDraft.Priority;
            ruleCollectionGroupDraft.Size = getRuleCollectionGroupDraft.Size;
            ruleCollectionGroupWrapper.Properties = ruleCollectionGroupDraft;
            ruleCollectionGroupWrapper.Name = getRuleCollectionGroupDraft.Name;
            ruleCollectionGroupWrapper.Properties.Id = getRuleCollectionGroupDraft.Id;

            return ruleCollectionGroupWrapper;
        }
    }
}

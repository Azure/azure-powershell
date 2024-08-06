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

using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    /// <summary>
    /// Wrapper of SDK type ObjectReplicationPolicy
    /// </summary>
    public class PSObjectReplicationPolicy
    {
        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 0)]
        public string ResourceGroupName { get; }
        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.Table, Position = 1)]
        public string StorageAccountName { get; }
        public string ResourceId { get; }
        public string Name { get; }
        public string Type { get; }

        [Ps1Xml(Label = "PolicyId", Target = ViewControl.Table, Position = 2)]
        public string PolicyId { get; set; }
        [Ps1Xml(Label = "EnabledTime", Target = ViewControl.Table, Position = 3)]
        public DateTime? EnabledTime { get; }
        [Ps1Xml(Label = "SourceAccount", Target = ViewControl.Table, Position = 4)]
        public string SourceAccount { get; set; }
        [Ps1Xml(Label = "DestinationAccount", Target = ViewControl.Table, Position = 5)]
        public string DestinationAccount { get; set; }
        [Ps1Xml(Label = "Rules", Target = ViewControl.Table, ScriptBlock = "if (($_.Rules -ne $null) -and ($_.Rules.Count -ne 0)) {'[' + $_.Rules[0].RuleId + ',...]'} else {$null}", Position = 6)]
        public PSObjectReplicationPolicyRule[] Rules { get; set; }

        public PSObjectReplicationPolicy()
        { }

        public PSObjectReplicationPolicy(ObjectReplicationPolicy policy, string ResourceGroupName, string StorageAccountName)
        {
            this.ResourceGroupName = ResourceGroupName;
            this.StorageAccountName = StorageAccountName;
            this.ResourceId = policy.Id;
            this.Name = policy.Name;
            this.Type = policy.Type;
            this.PolicyId = policy.PolicyId;
            this.EnabledTime = policy.EnabledTime;
            this.SourceAccount = policy.SourceAccount;
            this.DestinationAccount = policy.DestinationAccount;
            this.Rules = PSObjectReplicationPolicyRule.GetPSObjectReplicationPolicyRules(policy.Rules);
        }

        public ObjectReplicationPolicy ParseObjectReplicationPolicy()
        {
            ObjectReplicationPolicy policy = new ObjectReplicationPolicy()
            {
                SourceAccount = this.SourceAccount,
                DestinationAccount = this.DestinationAccount,
                Rules = PSObjectReplicationPolicyRule.ParseObjectReplicationPolicyRules(this.Rules)
            };
            return policy;
        }

        public static PSObjectReplicationPolicy[] GetPSObjectReplicationPolicies(IEnumerable<ObjectReplicationPolicy> policies, string ResourceGroupName, string StorageAccountName)
        {
            if (policies == null)
            {
                return null;
            }
            List<PSObjectReplicationPolicy> pspolicies = new List<PSObjectReplicationPolicy>();
            foreach (ObjectReplicationPolicy policy in policies)
            {
                pspolicies.Add(new PSObjectReplicationPolicy(policy, ResourceGroupName, StorageAccountName));
            }
            return pspolicies.ToArray();
        }
    }

    /// <summary>
    /// Wrapper of SDK type ObjectReplicationPolicyRule
    /// </summary>
    public class PSObjectReplicationPolicyRule
    {
        [Ps1Xml(Label = "RuleId", Target = ViewControl.Table, Position = 0)]
        public string RuleId { get; set; }
        [Ps1Xml(Label = "SourceContainer", Target = ViewControl.Table, Position = 1)]
        public string SourceContainer { get; set; }
        [Ps1Xml(Label = "DestinationContainer", Target = ViewControl.Table, Position = 2)]
        public string DestinationContainer { get; set; }
        [Ps1Xml(Label = "Filter.PrefixMatch", Target = ViewControl.Table, ScriptBlock = "if (($_.Filter -ne $null) -and ($_.Filter.PrefixMatch -ne $null) -and ($_.Filter.PrefixMatch.Count -ne 0)) {'[' + ($_.Filter.PrefixMatch -join ', ') + ']'} else {$null}", Position = 3)]
        public PSObjectReplicationPolicyFilter Filters { get; set; }

        public PSObjectReplicationPolicyRule()
        {
        }

        public PSObjectReplicationPolicyRule(ObjectReplicationPolicyRule rule)
        {
            this.RuleId = rule.RuleId;
            this.SourceContainer = rule.SourceContainer;
            this.DestinationContainer = rule.DestinationContainer;
            this.Filters = rule.Filters is null ? null : new PSObjectReplicationPolicyFilter(rule.Filters);
        }

        public ObjectReplicationPolicyRule ParseObjectReplicationPolicyRule()
        {
            ObjectReplicationPolicyRule rule = new ObjectReplicationPolicyRule();
            rule.RuleId = this.RuleId;
            rule.SourceContainer = this.SourceContainer;
            rule.DestinationContainer = this.DestinationContainer;
            rule.Filters = this.Filters is null ? null : this.Filters.ParseObjectReplicationPolicyFilter();
            return rule;
        }

        public static PSObjectReplicationPolicyRule[] GetPSObjectReplicationPolicyRules(IList<ObjectReplicationPolicyRule> rules)
        {
            if (rules == null)
            {
                return null;
            }
            List<PSObjectReplicationPolicyRule> psrules = new List<PSObjectReplicationPolicyRule>();
            foreach (ObjectReplicationPolicyRule rule in rules)
            {
                psrules.Add(new PSObjectReplicationPolicyRule(rule));
            }
            return psrules.ToArray();
        }

        public static List<ObjectReplicationPolicyRule> ParseObjectReplicationPolicyRules(PSObjectReplicationPolicyRule[] psrules)
        {
            if (psrules == null)
            {
                return null;
            }
            List<ObjectReplicationPolicyRule> rules = new List<ObjectReplicationPolicyRule>();
            foreach (PSObjectReplicationPolicyRule psrule in psrules)
            {
                rules.Add(psrule.ParseObjectReplicationPolicyRule());
            }
            return rules;
        }
    }

    /// <summary>
    /// Wrapper of SDK type ObjectReplicationPolicyFilter
    /// </summary>
    public class PSObjectReplicationPolicyFilter
    {
        public string[] PrefixMatch { get; set; }
        public DateTime? MinCreationTime;

        public PSObjectReplicationPolicyFilter()
        {
        }

        public PSObjectReplicationPolicyFilter(ObjectReplicationPolicyFilter filter)
        {
            if (filter != null)
            {
                this.PrefixMatch = filter.PrefixMatch is null ? null : new List<string>(filter.PrefixMatch).ToArray();
                if (string.IsNullOrEmpty(filter.MinCreationTime))
                {
                    this.MinCreationTime = null;
                }
                else
                {
                    if (filter.MinCreationTime.ToUpper()[filter.MinCreationTime.Length - 1] != 'Z')
                    {
                        filter.MinCreationTime = filter.MinCreationTime + "Z";
                    }
                    this.MinCreationTime = Convert.ToDateTime(filter.MinCreationTime, CultureInfo.GetCultureInfo("en-US"));
                }
            }
        }
        public ObjectReplicationPolicyFilter ParseObjectReplicationPolicyFilter()
        {
            return new ObjectReplicationPolicyFilter()
            {
                PrefixMatch = this.PrefixMatch is null ? null : new List<string>(this.PrefixMatch),
                //must be in format: 2020-02-19T16:05:00Z
                MinCreationTime = this.MinCreationTime is null ? null : this.MinCreationTime.Value.ToUniversalTime().ToString("s") + "Z"
            };
        }
    }
}

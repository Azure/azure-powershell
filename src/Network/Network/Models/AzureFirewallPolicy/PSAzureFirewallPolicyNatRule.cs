//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSAzureFirewallPolicyNatRule : PSAzureFirewallPolicyBaseRule
    {
        [JsonProperty(Order = 3)]
        public PSAzureFirewallPolicyNatRuleAction Action { get; set; }

        [JsonProperty(Order = 4)]
        public List<PSAzureFirewallPolicyNetworkRuleCondition> RuleConditions { get; set; }

        public string TranslatedAddress { get; set; }

        public string TranslatedPort { get; set; }

        [JsonIgnore]
        public string ActionText
        {
            get { return JsonConvert.SerializeObject(Action, Formatting.Indented); }
        }

        [JsonIgnore]
        public string RulesText
        {
            get { return JsonConvert.SerializeObject(RuleConditions, Formatting.Indented); }
        }

        public void AddRule(PSAzureFirewallPolicyNetworkRuleCondition rule)
        {
            // Validate
            if (this.RuleConditions != null)
            {
                if (this.RuleConditions.Any(rc => rc.Name.Equals(rule.Name)))
                {
                    throw new ArgumentException($"NAT Rule names must be unique. {rule.Name} name is already used.");
                }
            }
            else
            {
                this.RuleConditions = new List<PSAzureFirewallPolicyNetworkRuleCondition>();
            }

            this.RuleConditions.Add(rule);
        }

        public PSAzureFirewallPolicyNetworkRuleCondition GetRuleByName(string ruleName)
        {
            if (string.IsNullOrEmpty(ruleName))
            {
                throw new ArgumentException($"Rule name cannot be an empty string.");
            }

            var rule = this.RuleConditions?.FirstOrDefault(r => ruleName.Equals(r.Name, StringComparison.OrdinalIgnoreCase));

            if (rule == null)
            {
                throw new ArgumentException($"Rule with name {ruleName} does not exist.");
            }

            return rule;
        }

        public void RemoveRuleByName(string ruleName)
        {
            var rule = this.GetRuleByName(ruleName);
            this.RuleConditions?.Remove(rule);
        }
    }
}

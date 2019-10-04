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
    public class PSAzureFirewallPolicyFilterRuleCollection : PSAzureFirewallPolicyBaseRuleCollection
    {
        [JsonProperty(Order = 3)]
        public PSAzureFirewallPolicyFilterRuleCollectionAction Action { get; set; }

        [JsonProperty("ruleConditions")]
        public List<PSAzureFirewallPolicyRule> rules { get; set; }


        [JsonIgnore]
        public string ActionText
        {
            get { return JsonConvert.SerializeObject(Action, Formatting.Indented); }
        }

        [JsonIgnore]
        public string RulesText
        {
            get { return JsonConvert.SerializeObject(rules, Formatting.Indented); }
        }

        public void AddRule(PSAzureFirewallPolicyApplicationRule rule)
        {
            // Validate
            if (this.rules != null)
            {
                if (this.rules.Any(rc => rc.name.Equals(rule.name)))
                {
                    throw new ArgumentException($"Application Rule names must be unique. {rule.name} name is already used.");
                }
            }
            else
            {
                this.rules = new List<PSAzureFirewallPolicyRule>();
            }

            this.rules.Add(rule);
        }

        public PSAzureFirewallPolicyRule GetRuleConditionByName(string ruleName)
        {
            if (string.IsNullOrEmpty(ruleName))
            {
                throw new ArgumentException($"Rule name cannot be an empty string.");
            }

            var rule = this.rules?.FirstOrDefault(r => ruleName.Equals(r.name, StringComparison.OrdinalIgnoreCase));

            if (rule == null)
            {
                throw new ArgumentException($"Rule with name {ruleName} does not exist.");
            }

            return rule;
        }


        public void RemoveRuleByName(string ruleName)
        {
            var rule = this.GetRuleConditionByName(ruleName);
            this.rules?.Remove(rule);
        }
    }
}

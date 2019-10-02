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
        public PSAzureFirewallPolicyNetworkRuleCondition ruleCondition { get; set; }

        public string translatedAddress { get; set; }

        public string translatedPort { get; set; }

        [JsonIgnore]
        public string ActionText
        {
            get { return JsonConvert.SerializeObject(Action, Formatting.Indented); }
        }

        [JsonIgnore]
        public string RulesText
        {
            get { return JsonConvert.SerializeObject(ruleCondition, Formatting.Indented); }
        }


        public PSAzureFirewallPolicyNetworkRuleCondition GetRuleConditionByName(string ruleName)
        {
            if (string.IsNullOrEmpty(ruleName))
            {
                throw new ArgumentException($"Rule name cannot be an empty string.");
            }

            var rule = this.ruleCondition;

            if (rule == null)
            {
                throw new ArgumentException($"Rule with name {ruleName} does not exist.");
            }

            return rule;
        }
    }
}

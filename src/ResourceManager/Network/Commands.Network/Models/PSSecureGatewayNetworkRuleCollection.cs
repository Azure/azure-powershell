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
    public class PSSecureGatewayNetworkRuleCollection : PSChildResource
    {
        public uint Priority { get; set; }

        public List<PSSecureGatewayNetworkRule> Rules { get; set; }

        [JsonIgnore]
        public string RulesText
        {
            get { return JsonConvert.SerializeObject(Rules, Formatting.Indented); }
        }

        public void AddRule(PSSecureGatewayNetworkRule rule)
        {
            // Validate
            if (this.Rules != null)
            {
                if (this.Rules.Any(rc => rc.Name.Equals(rule.Name)))
                {
                    throw new ArgumentException($"Application Rule names must be unique. {rule.Name} name is already used.");
                }

                var samePriorityRules = this.Rules.Where(rc => rc.Priority == rule.Priority);
                if (samePriorityRules.Any())
                {
                    throw new ArgumentException($"Application Rule priorities must be unique. Priority {rule.Priority} is already used by Rule {samePriorityRules.First().Name}.");
                }
            }
            else
            {
                this.Rules = new List<PSSecureGatewayNetworkRule>();
            }

            this.Rules.Add(rule);
        }

        public PSSecureGatewayNetworkRule GetRuleByName(string ruleName)
        {
            if (null == ruleName)
            {
                return null;
            }

            return this.Rules?.FirstOrDefault(rule => ruleName.Equals(rule.Name));
        }

        public PSSecureGatewayNetworkRule GetRuleByPriority(uint priority)
        {
            return this.Rules?.FirstOrDefault(rule => rule.Priority == priority);
        }

        public void RemoveRuleByName(string ruleName)
        {
            var rule = this.GetRuleByName(ruleName);
            this.Rules?.Remove(rule);
        }

        public void RemoveRuleByPriority(uint priority)
        {
            var rule = this.GetRuleByPriority(priority);
            this.Rules?.Remove(rule);
        }
    }
}

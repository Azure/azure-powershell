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

namespace Microsoft.Azure.Commands.RedisCache.Models
{
    using System;
    using Management.Redis.Models;

    public class PSRedisFirewallRule
    {
        public string ResourceGroupName { get; set; }
        public string Name { get; set; }

        public string FirewallRuleId { get; set; }
        public string RuleName { get; set; }
        public string Type { get; set; }
        public string StartIP { get; set; }
        public string EndIP { get; set; }

        public PSRedisFirewallRule() { }

        internal PSRedisFirewallRule(string resourceGroupName, string cacheName, RedisFirewallRule redisFirewallRule)
        {
            ResourceGroupName = resourceGroupName;
            Name = cacheName;

            FirewallRuleId = redisFirewallRule.Id;
            RuleName = NormalizeFirewallRuleName(redisFirewallRule.Name);
            Type = redisFirewallRule.Type;
            StartIP = redisFirewallRule.StartIP;
            EndIP = redisFirewallRule.EndIP;
        }

        internal string NormalizeFirewallRuleName(string ruleName)
        {
            if (string.IsNullOrWhiteSpace(ruleName) || !ruleName.Contains("/"))
            {
                return ruleName;
            }
            return ruleName.Substring(ruleName.IndexOf("/") + 1);
        }
    }
}
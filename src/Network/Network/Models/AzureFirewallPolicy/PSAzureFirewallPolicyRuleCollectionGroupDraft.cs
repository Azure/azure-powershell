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
    public class PSAzureFirewallPolicyRuleCollectionGroupDraft : PSChildResource
    {

        [JsonProperty(Order = 2, PropertyName = "priority")]
        public uint Priority { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("ruleCollections")]
        public List<PSAzureFirewallPolicyBaseRuleCollection> RuleCollection { get; set; }

        public PSAzureFirewallPolicyBaseRuleCollection GetRuleCollectionByName(string ruleCollectionName)
        {
            if (string.IsNullOrEmpty(ruleCollectionName))
            {
                throw new ArgumentException($"Rule name cannot be an empty string.");
            }

            var rule = this.RuleCollection?.FirstOrDefault(r => ruleCollectionName.Equals(r.Name, StringComparison.OrdinalIgnoreCase));

            if (rule == null)
            {
                throw new ArgumentException($"Rule with name {ruleCollectionName} does not exist.");
            }

            return rule;
        }
    }
}

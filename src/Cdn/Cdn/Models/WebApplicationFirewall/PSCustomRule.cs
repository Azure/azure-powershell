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

using Microsoft.Azure.Management.Cdn.Models;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall
{
    /// <summary>
    /// A user-managed rule to apply to a WAF policy.
    /// </summary>
    public class PSCustomRule
    {
        /// <summary>
        /// The name of the rule.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether the rule is enabled.
        /// </summary>
        public PSCustomRuleEnabledState EnabledState { get; set; }

        /// <summary>
        /// The order the rule is evaluated in the overall list of custom rules
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Conditions used to determine if a request matches the rule.
        /// </summary>
        public ICollection<PSMatchCondition> MatchConditions { get; set; }

        /// <summary>
        /// The action to take when the rule matches.
        /// </summary>
        public PSActionType Action { get; set; }
    }
}

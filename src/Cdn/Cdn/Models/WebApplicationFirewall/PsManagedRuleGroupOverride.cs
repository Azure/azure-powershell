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

using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall
{
    /// <summary>
    /// A rate limit applied to a WAF Policy.
    /// </summary>
    public class PSManagedRuleGroupOverride
    {
        /// <summary>
        /// The managed rule group within the rule set to override.
        /// </summary>
        public string RuleGroupName { get; set; }

        /// <summary>
        /// List of rules that will be disabled. If none specified, all rules in the group will be disabled.
        /// </summary>
        public ICollection<PSManagedRuleOverride> Rules { get; set; }
    }
}

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
    /// Selects a managed rule set and defines overrides for it.
    /// </summary>
    public class PSManagedRuleSet
    {
        /// <summary>
        /// The type of the rule set.
        /// </summary>
        public string RuleSetType { get; set; }

        /// <summary>
        /// The rule set version to use.
        /// </summary>
        public string RuleSetVersion { get; set; }

        /// <summary>
        /// The rule overrides applied to the rule set.
        /// </summary>
        public ICollection<PSManagedRuleGroupOverride> RuleGroupOverrides { get; set; }
    }
}

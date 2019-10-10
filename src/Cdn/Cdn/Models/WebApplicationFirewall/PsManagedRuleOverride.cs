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
    /// Defines the settings to override for a managed rule.
    /// </summary>
    public class PSManagedRuleOverride
    {
        /// <summary>
        /// Identifier of the managed rule to override.
        /// </summary>
        public string RuleId { get; set; }

        /// <summary>
        /// Whether the managed rule is in enabled. Defaults to Disabled if not specified.
        /// </summary>
        public PSManagedRuleEnabledState EnabledState { get; set; }

        /// <summary>
        /// The override action to be applied when the rule matches.
        /// </summary>
        public PSActionType Action { get; set; }
    }
}

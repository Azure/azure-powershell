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

using Microsoft.Azure.Management.Insights.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the AlertRuleResource
    /// </summary>
    public class PSAlertRuleResource : AlertRuleResource
    {
        /// <summary>
        /// Initializes a new instance of the PSAlertRuleResource class.
        /// </summary>
        /// <param name="ruleSpec"></param>
        public PSAlertRuleResource(AlertRuleResource ruleSpec)
            : base(
               id: ruleSpec.Id,
               location: ruleSpec.Location,
               name: ruleSpec.Name,
               type: ruleSpec.Type,
               alertRuleResourceName: ruleSpec.Name,
               isEnabled: ruleSpec.IsEnabled,
               condition: ruleSpec.Condition,
               lastUpdatedTime: ruleSpec.LastUpdatedTime)
        {
            this.Tags = ruleSpec.Tags;
            this.Actions = ruleSpec.Actions;
            this.Description = ruleSpec.Description;
        }
    }
}

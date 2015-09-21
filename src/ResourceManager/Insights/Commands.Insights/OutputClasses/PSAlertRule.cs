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
    /// Wrapps around the RuleGetResponse
    /// </summary>
    public class PSAlertRule : PSManagementItemDescriptorWithDetails
    {
        /// <summary>
        /// Initializes a new instance of the PSAlertRule class.
        /// </summary>
        /// <param name="ruleSpec"></param>
        public PSAlertRule(RuleGetResponse ruleSpec)
        {
            this.Id = ruleSpec.Id;
            this.Location = ruleSpec.Location;
            this.Name = ruleSpec.Name;
            this.Properties = new PSAlertRuleProperty(ruleSpec.Properties);
            this.Tags = new PSDictionaryElement(ruleSpec.Tags);
        }

        /// <summary>
        /// Initializes a new instance of the PSAlertRule class.
        /// </summary>
        /// <param name="ruleSpec"></param>
        public PSAlertRule(RuleResource ruleSpec)
        {
            this.Id = ruleSpec.Id;
            this.Location = ruleSpec.Location;
            this.Name = ruleSpec.Name;
            this.Properties = new PSAlertRuleProperty(ruleSpec.Properties);
            this.Tags = new PSDictionaryElement(ruleSpec.Tags);
        }
    }
}

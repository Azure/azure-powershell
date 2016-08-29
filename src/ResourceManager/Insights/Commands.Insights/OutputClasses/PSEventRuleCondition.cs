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
using System.Text;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the ManagementEventRuleCondition class
    /// </summary>
    public class PSEventRuleCondition : IPSRuleCondition
    {
        /// <summary>
        /// Gets or sets the DataSource of the rule condition
        /// </summary>
        public RuleManagementEventDataSource DataSource { get; set; }

        /// <summary>
        /// Gets or sets the AggregationCondition of the rule condition
        /// </summary>
        public ManagementEventAggregationCondition AggregationCondition { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSEventRuleCondition class
        /// </summary>
        /// <param name="ruleCondition">The rule condition</param>
        public PSEventRuleCondition(ManagementEventRuleCondition ruleCondition)
        {
            this.DataSource = ruleCondition.DataSource as RuleManagementEventDataSource;
            this.AggregationCondition = ruleCondition.Aggregation;
        }

        /// <summary>
        /// A string representation of the object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine("    DataSource : " + this.DataSource.ToString(indentationTabs: 2));
            output.Append("    Condition  : " + this.AggregationCondition.ToString(indentationTabs: 2));
            return output.ToString();
        }
    }
}

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
using System;
using System.Text;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the ThresholdRuleCondition class
    /// </summary>
    public class PSThresholdRuleCondition : IPSRuleCondition
    {
        /// <summary>
        /// Gets or sets the DataSource of the rule condition
        /// </summary>
        public RuleMetricDataSource DataSource { get; set; }

        /// <summary>
        /// Gets or sets the Operator of the rule condition
        /// </summary>
        public ConditionOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the Threshold of the rule condition
        /// </summary>
        public double Threshold { get; set; }

        /// <summary>
        /// Gets or sets the TimeAggregation operator of the rule condition
        /// </summary>
        public TimeAggregationOperator? TimeAggregation { get; set; }

        /// <summary>
        /// Gets or sets the WindowSize of the rule condition
        /// </summary>
        public TimeSpan WindowsSize { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSThresholdRuleCondition class
        /// </summary>
        /// <param name="ruleCondition">The rule condition</param>
        public PSThresholdRuleCondition(ThresholdRuleCondition ruleCondition)
        {
            this.DataSource = ruleCondition.DataSource as RuleMetricDataSource;
            this.Operator = ruleCondition.Operator;
            this.Threshold = ruleCondition.Threshold;
            this.TimeAggregation = ruleCondition.TimeAggregation;
            this.WindowsSize = ruleCondition.WindowSize;
        }

        /// <summary>
        /// A string representation of the object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine("    DataSource          : " + this.DataSource.ToString(indentationTabs: 2));
            output.AppendLine("    Operator            : " + this.Operator);
            output.AppendLine("    Threshold           : " + this.Threshold);
            output.AppendLine("    Aggregation operator: " + this.TimeAggregation);
            output.Append("    Window size         : " + this.WindowsSize);
            return output.ToString();
        }
    }
}

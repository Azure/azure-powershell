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

using Microsoft.Azure.Commands.Insights.Properties;
using Microsoft.Azure.Management.Insights.Models;
using System;
using System.Globalization;
using System.Text;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    public class PSLocationThresholdRuleCondition : IPSRuleCondition
    {
        /// <summary>
        /// Gets or sets the RuleMetricDataSource of the rule condition
        /// </summary>
        public RuleMetricDataSource DataSource { get; set; }

        /// <summary>
        /// Gets or sets the FiledLocationCount of the rule condition
        /// </summary>
        public int FailedLocationCount { get; set; }

        /// <summary>
        /// Gets or sets the WindowSize of the rule condition
        /// </summary>
        public TimeSpan WindowSize { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSEventRuleCondition class
        /// </summary>
        /// <param name="ruleCondition">The rule condition</param>
        public PSLocationThresholdRuleCondition(LocationThresholdRuleCondition ruleCondition)
        {
            var dataSource = ruleCondition.DataSource as RuleMetricDataSource;
            if (dataSource != null)
            {
                this.DataSource = dataSource;
            }
            else
            {
                throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, ResourcesForAlertCmdlets.RuleDataSourceTypeNotSupported, ruleCondition.DataSource.GetType().Name));
            }

            this.FailedLocationCount = ruleCondition.FailedLocationCount;
            this.WindowSize = ruleCondition.WindowSize;
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
            output.AppendLine("    FailedLocationCount : " + this.FailedLocationCount);
            output.Append("    WindowSize          : " + this.WindowSize);
            return output.ToString();
        }
    }
}

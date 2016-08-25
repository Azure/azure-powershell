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
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the Rule class
    /// </summary>
    public class PSAlertRuleProperty : PSManagementPropertyDescriptor
    {
        /// <summary>
        /// Gets or sets the Action of the rule
        /// </summary>
        public IList<RuleAction> Actions { get; set; }

        /// <summary>
        /// Gets or sets the Condition of the rule
        /// </summary>
        public IPSRuleCondition Condition { get; set; }

        /// <summary>
        /// Gets or sets the Description of the rule
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Status of the rule
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSRuleProperties class.
        /// </summary>
        /// <param name="properties"></param>
        public PSAlertRuleProperty(Rule properties)
        {
            this.Actions = properties.Actions;

            var condition = properties.Condition as ThresholdRuleCondition;
            if (condition != null)
            {
                this.Condition = new PSThresholdRuleCondition(condition);
            }
            else
            {
                var eventCondition = properties.Condition as ManagementEventRuleCondition;
                if (eventCondition != null)
                {
                    this.Condition = new PSEventRuleCondition(eventCondition);
                }
                else
                {
                    var locationCondition = properties.Condition as LocationThresholdRuleCondition;
                    if (locationCondition != null)
                    {
                        this.Condition = new PSLocationThresholdRuleCondition(locationCondition);
                    }
                    else
                    {
                        throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, ResourcesForAlertCmdlets.RuleConditionTypeNotSupported, properties.Condition.GetType().Name));
                    }
                }
            }

            this.Description = properties.Description;
            this.Status = properties.IsEnabled ? "Enabled" : "Disabled";
            this.Name = properties.Name;
        }

        /// <summary>
        /// A string representation of the PSAlertRuleProperty
        /// </summary>
        /// <returns>A string representation of the PSAlertRuleProperty</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine("Name:       : " + this.Name);
            output.AppendLine("Condition   : " + this.Condition);
            output.AppendLine("Description : " + this.Description);
            output.AppendLine("Status      : " + this.Status);
            output.Append("Actions     : " + this.Actions.ToString(indentationTabs: 1));
            return output.ToString();
        }
    }
}

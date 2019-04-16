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

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Monitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Create Metric Criteria
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MetricAlertRuleV2Criteria", DefaultParameterSetName = StaticThresholdParameterSet), OutputType(typeof(PSMetricCriteria))]
    public class NewAzureRmMetricAlertRuleV2CriteriaCommand : MonitorCmdletBase
    {
        const string StaticThresholdParameterSet = "StaticThresholdParameterSet";
        const string DynamicThresholdParameterSet = "DynamicThresholdParameterSet";

        /// <summary>
        /// Gets or sets the MetricName parameter
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The metric name for rule")]
        [ValidateNotNullOrEmpty]
        public string MetricName { get; set; }

        /// <summary>
        /// Gets or sets MetricNamespace  parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The Namespace of the metric")]
        public String MetricNamespace { get; set; }

        /// <summary>
        /// Gets or sets Dimensions of the cmdlet
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "List of dimension conditions")]
        public PSMetricDimension[] DimensionSelection { get; set; }

        /// <summary>
        /// Gets or sets the TimeAggregationType parameter
        /// </summary>
        [Parameter(Mandatory = true,  HelpMessage = "The aggregation operation used to roll up multiple metric values across the window interval")]
        [PSArgumentCompleter("Average", "Minimum", "Maximum", "Total", "Count")]
        public String TimeAggregation { get; set; }

        /// <summary>
        /// Gets or sets the rule condition operator
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The rule condition operator")]
        [PSArgumentCompleter("GreaterThan", "GreaterThanOrEqual", "LessThan", "LessThanOrEqual")]
        public String Operator { get; set; }

        /// <summary>
        /// Gets or sets the rule threshold
        /// </summary>
        [Parameter(ParameterSetName = StaticThresholdParameterSet, Mandatory = true,  HelpMessage = "The threshold for rule condition")]
        public double Threshold { get; set; }

        /// <summary>
        /// Gets or sets the rule DynamicThreshold
        /// </summary>
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = true, HelpMessage = "The Dynamic Threshold for rule condition")]
        public string DynamicThreshold { get; set; }

        /// <summary>
        /// Gets or sets the rule sensitivity
        /// </summary>
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = false, HelpMessage = "The sensitivity for rule condition")]
        [PSArgumentCompleter("Low", "Medium", "High")]
        public String Sensitivity { get; set; }

        /// <summary>
        /// Gets or sets the rule FailingPeriod
        /// </summary>
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = false, HelpMessage = "The Failing Period for rule condition")]
        public int FailingPeriod { get; set; }

        /// <summary>
        /// Gets or sets the rule TotalPeriod
        /// </summary>
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = false,  HelpMessage = "The Total Period for rule condition")]
        public int TotalPeriod { get; set; }

        /// <summary>
        /// Gets or set IgnoreDataBefore  parameter
        /// </summary>
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = false, HelpMessage = "The IgnoreDataBefore parameter")]
        public DateTime IgnoreDataBefore { get; set; }

        protected override void ProcessRecordInternal()
        {
            if(String.IsNullOrWhiteSpace(this.DynamicThreshold))
            {
                List<MetricDimension> metricDimensions = new List<MetricDimension>();

                if (this.DimensionSelection!= null && this.DimensionSelection.Length > 0)
                {
                    foreach (var dimension in this.DimensionSelection)
                    {
                        if (dimension.IncludeValues != null && dimension.IncludeValues.Count() > 0)
                        {
                            metricDimensions.Add(new MetricDimension(dimension.Dimension, "Include", dimension.IncludeValues));
                        }
                        if (dimension.ExcludeValues != null && dimension.ExcludeValues.Count() > 0)
                        {
                            metricDimensions.Add(new MetricDimension(dimension.Dimension, "Exclude", dimension.ExcludeValues));
                        }
                    }
                }
                else
                {
                    metricDimensions = null;
                }
                MetricCriteria metricCriteria = new MetricCriteria(name: "metric1", metricName: this.MetricName, operatorProperty: this.Operator, timeAggregation: this.TimeAggregation, threshold: this.Threshold, metricNamespace: this.MetricNamespace, dimensions: metricDimensions);
                PSMetricCriteria result = new PSMetricCriteria(metricCriteria);
                WriteObject(sendToPipeline: result);
            }
            else
            {
                WriteExceptionError(new Exception("Creating criteria for Dynamic Threshold is not yet supported"));
            }
        }
    }
}

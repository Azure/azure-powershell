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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Create Metric Criteria
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MetricAlertRuleV2Criteria", DefaultParameterSetName = StaticThresholdParameterSet), 
     OutputType(typeof(PSMetricCriteria), ParameterSetName = new[] { StaticThresholdParameterSet }), 
     OutputType(typeof(PSDynamicMetricCriteria), ParameterSetName = new[] { DynamicThresholdParameterSet})]
    public class NewAzureRmMetricAlertRuleV2CriteriaCommand : MonitorCmdletBase
    {
        const string StaticThresholdParameterSet = "StaticThresholdParameterSet";
        const string DynamicThresholdParameterSet = "DynamicThresholdParameterSet";
        const string AvailabilityParameterSet = "WebtestParameterSet";

        // Create a script for the Operator parameter completer based on the active Parameter Set 
        // Since Parameter Set isn't accessible - check if one of the dynamic threshold parameters are assigned
        const string IsDynamicThresholdParameterSetSelectedScript = "$fakeBoundParameters.DynamicThreshold -or $fakeBoundParameters.ThresholdSensitivity -ne $null -or $fakeBoundParameters.NumberOfViolations -ne $null -or $fakeBoundParameters.NumberOfExaminedAggregatedPoints -ne $null -or $fakeBoundParameters.IgnoreDataBefore -ne $null";
        const string DynamicOperatorValues = "'GreaterThan', 'LessThan', 'GreaterOrLessThan'";
        const string StaticOperatorValues = "'GreaterThan', 'GreaterThanOrEqual', 'LessThan', 'LessThanOrEqual'";
        const string OperatorCompleterScript = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameters)\n if (" + IsDynamicThresholdParameterSetSelectedScript + ") {" + DynamicOperatorValues + " } else {" + StaticOperatorValues + "}";

        /// <summary>
        /// Gets or sets the rule DynamicThreshold
        /// </summary>
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = true, HelpMessage = "Switch parameter for using Dynamic Threshold Type")]
        public SwitchParameter DynamicThreshold { get; set; }

        /// <summary>
        /// Gets or sets the rule AvailabilityCriteria
        /// </summary>
        [Parameter(ParameterSetName = AvailabilityParameterSet, Mandatory = false, HelpMessage = "Switch parameter for using availability criteria Type")]
        public SwitchParameter WebTest { get; set; }

        /// <summary>
        /// Gets or sets the MetricName parameter
        /// </summary>
        [Parameter(ParameterSetName = StaticThresholdParameterSet, Mandatory = true, HelpMessage = "The metric name for rule")]
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = true, HelpMessage = "The metric name for rule")]
        [ValidateNotNullOrEmpty]
        public string MetricName { get; set; }

        /// <summary>
        /// Gets or sets MetricNamespace parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = StaticThresholdParameterSet, Mandatory = false, HelpMessage = "The Namespace of the metric")]
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = false, HelpMessage = "The Namespace of the metric")]
        public String MetricNamespace { get; set; }

        /// <summary>
        /// Gets or sets SkipMetricValidation parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = StaticThresholdParameterSet, Mandatory = false, HelpMessage = "Allows creating an alert rule on a custom metric that isn't yet emitted, by causing the metric validation to be skipped")]
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = false, HelpMessage = "Allows creating an alert rule on a custom metric that isn't yet emitted, by causing the metric validation to be skipped")]
        public Boolean SkipMetricValidation { get; set; }

        /// <summary>
        /// Gets or sets Dimensions of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = StaticThresholdParameterSet, Mandatory = false, ValueFromPipeline = true, HelpMessage = "List of dimension conditions")]
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = false, ValueFromPipeline = true, HelpMessage = "List of dimension conditions")]
        public PSMetricDimension[] DimensionSelection { get; set; }

        /// <summary>
        /// Gets or sets the TimeAggregationType parameter
        /// </summary>
        [Parameter(ParameterSetName = StaticThresholdParameterSet, Mandatory = true, HelpMessage = "The aggregation operation used to roll up multiple metric values across the window interval")]
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = true,  HelpMessage = "The aggregation operation used to roll up multiple metric values across the window interval")]
        [PSArgumentCompleter("Average", "Minimum", "Maximum", "Total", "Count")]
        public String TimeAggregation { get; set; }

        /// <summary>
        /// Gets or sets the rule condition operator
        /// </summary>
        [Parameter(ParameterSetName = StaticThresholdParameterSet, Mandatory = true, HelpMessage = "The rule condition operator")]
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = true, HelpMessage = "The rule condition operator")]
        [PSArgumentCompleterWithScript(OperatorCompleterScript)]
        public String Operator { get; set; }

        /// <summary>
        /// Gets or sets the rule threshold
        /// </summary>
        [Parameter(ParameterSetName = StaticThresholdParameterSet, Mandatory = true,  HelpMessage = "The threshold for rule condition")]
        public double Threshold { get; set; }
        
        /// <summary>
        /// Gets or sets the rule sensitivity
        /// </summary>
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = false, HelpMessage = "The sensitivity for rule condition")]
        [PSArgumentCompleter("Low", "Medium", "High")]
        [Alias("Sensitivity")]
        public String ThresholdSensitivity { get; set; } = "Medium";

        /// <summary>
        /// Gets or sets the rule Number of violated points
        /// </summary>
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = false, HelpMessage = "The minimum number of violations required within the selected lookback time window required to raise an alert")]
        [Alias("FailingPeriod", "NumberOfViolations")]
        public int ViolationCount { get; set; } = 4;

        /// <summary>
        /// Gets or sets the rule TotalPeriod
        /// </summary>
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = false, HelpMessage = "The Total number of examined points")]
        [Alias("TotalPeriod", "NumberOfExaminedAggregatedPoints")]
        public int ExaminedAggregatedPointCount { get; set; } = 4;

        /// <summary>
        /// Gets or set IgnoreDataBefore  parameter
        /// </summary>
        [Parameter(ParameterSetName = DynamicThresholdParameterSet, Mandatory = false, HelpMessage = "The date from which to start learning the metric historical data and calculate the dynamic thresholds")]
        public DateTime IgnoreDataBefore { get; set; }

        /// <summary>
        /// Gets or sets the web test id
        /// </summary>
        [Parameter(ParameterSetName = AvailabilityParameterSet, Mandatory = true, HelpMessage = "The Application Insights web test Id.")]
        public string WebTestId { get; set; }

        /// <summary>
        /// Gets or sets the application insights id
        /// </summary>
        [Parameter(ParameterSetName = AvailabilityParameterSet, Mandatory = true, HelpMessage = "The Application Insights resource Id.")]
        [Alias("componentId")]
        public string ApplicationInsightsId { get; set; }

        /// <summary>
        /// Gets or sets the rule number of failed locations
        /// </summary>
        [Parameter(ParameterSetName = AvailabilityParameterSet, Mandatory = false, HelpMessage = "The minimum number of failed locations to raise an alert.")]
        [Alias("AlertLocationThreshold")]
        public int FailedLocationCount { get; set; } = 2;

        protected override void ProcessRecordInternal()
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

            IPSMultiMetricCriteria result;
            if (this.WebTest.IsPresent || !string.IsNullOrWhiteSpace(this.WebTestId))
            {
                WebtestLocationAvailabilityCriteria webtestMetricCriteria = new WebtestLocationAvailabilityCriteria(this.WebTestId, this.ApplicationInsightsId, this.FailedLocationCount);
                result = new PSWebtestLocationAvailabilityCriteria(webtestMetricCriteria);
            }
            else if (this.DynamicThreshold.IsPresent)
            {
                DynamicThresholdFailingPeriods failingPeriods = new DynamicThresholdFailingPeriods(this.ExaminedAggregatedPointCount, this.ViolationCount);
                DynamicMetricCriteria dynamicMetricCriteria = new DynamicMetricCriteria(name: "metric1",
                    metricName: this.MetricName,
                    operatorProperty: this.Operator,
                    timeAggregation: this.TimeAggregation,
                    metricNamespace: this.MetricNamespace,
                    dimensions: metricDimensions,
                    failingPeriods: failingPeriods,
                    alertSensitivity: this.ThresholdSensitivity,
                    ignoreDataBefore: this.IsParameterBound(c => c.IgnoreDataBefore) ? (DateTime?) this.IgnoreDataBefore : null,
                    skipMetricValidation: this.SkipMetricValidation
                    );
                result = new PSDynamicMetricCriteria(dynamicMetricCriteria);
            }
            else
            {
                MetricCriteria metricCriteria = new MetricCriteria(name: "metric1", metricName: this.MetricName, operatorProperty: this.Operator, timeAggregation: this.TimeAggregation, threshold: this.Threshold, metricNamespace: this.MetricNamespace, dimensions: metricDimensions, skipMetricValidation: this.SkipMetricValidation);
                result = new PSMetricCriteria(metricCriteria);
            }

            WriteObject(sendToPipeline: result);
        }
    }
}

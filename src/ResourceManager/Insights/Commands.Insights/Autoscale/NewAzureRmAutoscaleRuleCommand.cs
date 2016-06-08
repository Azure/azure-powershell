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
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Insights.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Autoscale
{
    /// <summary>
    /// Create an Autoscale rule
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAutoscaleRule"), OutputType(typeof(ScaleRule))]
    public class NewAzureRmAutoscaleRuleCommand : AzureRMCmdlet
    {
        private readonly TimeSpan MinimumTimeWindow = TimeSpan.FromMinutes(5);
        private readonly TimeSpan MinimumTimeGrain = TimeSpan.FromMinutes(1);

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the MetricName parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric name for the setting")]
        [ValidateNotNullOrEmpty]
        public string MetricName { get; set; }

        /// <summary>
        /// Gets or sets the MetricResourceId parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric resource id for the setting")]
        [ValidateNotNullOrEmpty]
        public string MetricResourceId { get; set; }

        /// <summary>
        /// Gets or sets the setting condition operator
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The setting condition operator")]
        public ComparisonOperationType Operator { get; set; }

        /// <summary>
        /// Gets or sets the MetricStatistic
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The setting metric statistic")]
        public MetricStatisticType MetricStatistic { get; set; }

        /// <summary>
        /// Gets or sets the Threshold
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The threshold for the setting condition")]
        public double Threshold { get; set; }

        /// <summary>
        /// Gets or sets the TimeAggregationOperator parameter
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The time aggregation operator for the setting")]
        public TimeAggregationType TimeAggregationOperator { get; set; }

        /// <summary>
        /// Gets or sets the time grain
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric trigger time grain for the setting")]
        public TimeSpan TimeGrain { get; set; }

        /// <summary>
        /// Gets or sets the TimeWindow
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric trigger timewindow for the setting")]
        public TimeSpan TimeWindow { get; set; }

        /// <summary>
        /// Gets or sets the scale action cooldown time
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scale action cooldown time for the setting")]
        public TimeSpan ScaleActionCooldown { get; set; }

        /// <summary>
        /// Gets or sets the scale action direction
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The acale action direction for the setting")]
        public ScaleDirection ScaleActionDirection { get; set; }

        /// <summary>
        /// Gets or sets the scale action type
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scale action type for the setting")]
        public ScaleType ScaleActionScaleType { get; set; }

        /// <summary>
        /// Gets or sets the scale action value
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scale action value for the setting")]
        [ValidateNotNullOrEmpty]
        public string ScaleActionValue { get; set; }

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ScaleRule rule = this.CreateSettingRule();
            WriteObject(rule);
        }

        /// <summary>
        /// Create an Autoscale setting rule based on the properties of the object
        /// </summary>
        /// <returns>A ScaleRule created based on the properties of the object</returns>
        public ScaleRule CreateSettingRule()
        {
            if (this.TimeWindow != default(TimeSpan) && this.TimeWindow < MinimumTimeWindow)
            {
                throw new ArgumentOutOfRangeException("TimeWindow", this.TimeWindow, ResourcesForAutoscaleCmdlets.MinimumTimeWindow5min);
            }

            if (this.TimeGrain < MinimumTimeGrain)
            {
                throw new ArgumentOutOfRangeException("TimeGrain", this.TimeGrain, ResourcesForAutoscaleCmdlets.MinimumTimeGrain1min);
            }

            MetricTrigger trigger = new MetricTrigger()
            {
                MetricName = this.MetricName,
                MetricResourceUri = this.MetricResourceId,
                Operator = this.Operator,
                Statistic = this.MetricStatistic,
                Threshold = this.Threshold,
                TimeAggregation = this.TimeAggregationOperator,
                TimeGrain = this.TimeGrain,
                TimeWindow = this.TimeWindow == default(TimeSpan) ? MinimumTimeWindow : this.TimeWindow,
            };

            ScaleAction action = new ScaleAction()
            {
                Cooldown = this.ScaleActionCooldown,
                Direction = this.ScaleActionDirection,
                Type = this.ScaleActionScaleType,
                Value = this.ScaleActionValue,
            };

            return new ScaleRule()
            {
                MetricTrigger = trigger,
                ScaleAction = action,
            };
        }
    }
}

﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.Insights.TransitionalClasses;
using Microsoft.Azure.Management.Monitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Add an Alert rule
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MetricAlertRule", SupportsShouldProcess = true), OutputType(typeof(PSAddAlertRuleOperationResponse))]
    public class AddAzureRmMetricAlertRuleCommand : AddAzureRmAlertRuleCommandBase
    {
        /// <summary>
        /// Gets or sets the time window size of the threshold condition
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The window size for rule")]
        public TimeSpan WindowSize { get; set; }

        /// <summary>
        /// Gets or sets the rule condition operator
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The rule condition operator")]
        public Management.Monitor.Management.Models.ConditionOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the rule threshold
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The threshold for rule condition")]
        public double Threshold { get; set; }

        /// <summary>
        /// Gets or sets the TargetResourceId parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target resource id for rule")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Gets or sets the MetricName parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric name for rule")]
        [ValidateNotNullOrEmpty]
        public string MetricName { get; set; }

        /// <summary>
        /// Gets or sets the TimeAggregationType parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The aggregation operation used to roll up multiple metric values across the window interval")]
        public Management.Monitor.Management.Models.TimeAggregationOperator? TimeAggregationOperator { get; set; }

        private ThresholdRuleCondition CreateThresholdRuleCondition()
        {
            return new ThresholdRuleCondition
            {
                DataSource = new RuleMetricDataSource
                {
                    MetricName = this.MetricName,
                    ResourceUri = this.TargetResourceId,
                },
                OperatorProperty = TransitionHelpers.ConvertNamespace(this.Operator),
                Threshold = this.Threshold,
                TimeAggregation = TransitionHelpers.ConvertNamespace(this.TimeAggregationOperator),
                WindowSize = this.WindowSize,
            };
        }

        private RuleCondition CreateRuleCondition()
        {
            WriteVerboseWithTimestamp(String.Format("CreateRuleCondition: Creating threshold rule condition (metric-based rule)"));
            return this.CreateThresholdRuleCondition();
        }

        protected override AlertRuleResource CreateSdkCallParameters()
        {
            RuleCondition condition = this.CreateRuleCondition();

            WriteVerboseWithTimestamp(String.Format("CreateSdkCallParameters: Creating rule object"));
            return new AlertRuleResource()
            {
                Description = this.Description ?? Utilities.GetDefaultDescription("metric alert rule"),
                Condition = condition,
                Actions = this.Action?.Select(TransitionHelpers.ToMirrorNamespace).ToList(),
                Location = this.Location,
                IsEnabled = !this.DisableRule,
                AlertRuleResourceName = this.Name,

                // DO NOT REMOVE OR CHANGE the following. The two elements in the Tags are required by other services.
                Tags = new Dictionary<string, string>()
                {
                    {"$type" , "Microsoft.WindowsAzure.Management.Common.Storage.CasePreservedDictionary,Microsoft.WindowsAzure.Management.Common.Storage"},
                    {"hidden-link:" + this.TargetResourceId, "Resource" },
                },
            };
        }
    }
}

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

using Hyak.Common;
using Microsoft.Azure.Management.Insights.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Add an Alert rule
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmWebtestAlertRule"), OutputType(typeof(List<PSObject>))]
    public class AddAzureRmWebtestAlertRuleCommand : AddAzureRmAlertRuleCommandBase
    {
        /// <summary>
        /// Gets or sets the metric name of the condition
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric name for rule")]
        [ValidateNotNullOrEmpty]
        public string MetricName { get; set; }

        /// <summary>
        /// Gets or sets the target resource Uri of the condition
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target resource Uri for rule")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceUri { get; set; }

        /// <summary>
        /// Gets or sets the time window size of the location threshold condition
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The window size for rule")]
        public TimeSpan WindowSize { get; set; }

        /// <summary>
        /// Gets or sets the FailedLocationCount parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The failed location count for rule")]
        public int FailedLocationCount { get; set; }

        /// <summary>
        /// Gets or sets the metric namespace of the condition
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric namespace for rule")]
        public string MetricNamespace { get; set; }

        private RuleCondition CreateRuleCondition()
        {
            WriteVerboseWithTimestamp(string.Format("CreateRuleCondition: Creating location threshold rule condition (webtest rule)"));
            var dataSource = new RuleMetricDataSource
            {
                MetricName = this.MetricName,
                MetricNamespace = this.MetricNamespace,
                ResourceUri = this.TargetResourceUri
            };

            return new LocationThresholdRuleCondition()
            {
                DataSource = dataSource,
                FailedLocationCount = this.FailedLocationCount,
                WindowSize = this.WindowSize,
            };
        }

        protected override RuleCreateOrUpdateParameters CreateSdkCallParameters()
        {
            RuleCondition condition = this.CreateRuleCondition();

            WriteVerboseWithTimestamp(string.Format("CreateSdkCallParameters: Creating rule object"));
            return new RuleCreateOrUpdateParameters()
            {
                Location = this.Location,
                Properties = new Rule()
                {
                    Name = this.Name,
                    IsEnabled = !this.DisableRule,
                    Description = this.Description ?? Utilities.GetDefaultDescription("webtest alert rule"),
                    LastUpdatedTime = DateTime.Now,
                    Condition = condition,
                    Actions = this.Actions,
                },

                // DO NOT REMOVE OR CHANGE the following. The two elements in the Tags are required by other services.
                Tags = new LazyDictionary<string, string>()
                {
                    {"$type" , "Microsoft.WindowsAzure.Management.Common.Storage.CasePreservedDictionary,Microsoft.WindowsAzure.Management.Common.Storage"},
                    {"hidden-link:", "Resource" },
                },
            };
        }
    }
}

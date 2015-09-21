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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Hyak.Common;
using Microsoft.Azure.Commands.Insights.Properties;
using Microsoft.Azure.Management.Insights.Models;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Add an Alert rule
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AlertRule"), OutputType(typeof(List<PSObject>))]
    public class AddAlertRuleCommand : AddAlertRuleCommandBase
    {
        #region Cmdlet parameters for Event and Metric alert rules

        /// <summary>
        /// Gets or sets the rule condition operator
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The rule condition operator")]
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The rule condition operator")]
        public ConditionOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the rule threshold
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The threshold for rule condition")]
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The threshold for rule condition")]
        public double Threshold { get; set; }

        /// <summary>
        /// Gets or sets the ResourceId parameter
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id for rule")]
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id for rule")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        #endregion

        #region Cmdlet parameters for Event alert rules

        /// <summary>
        /// Gets or sets the EventName parameters
        /// </summary>
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The event name for rule")]
        [ValidateNotNullOrEmpty]
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the EventSource parameter
        /// </summary>
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The event source for rule")]
        public string EventSource { get; set; }

        /// <summary>
        /// Gets or sets the Level parameter
        /// </summary>
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The level for rule")]
        public string Level { get; set; }

        /// <summary>
        /// Gets or sets the OperationName parameter
        /// </summary>
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The operation name for rule")]
        public string OperationName { get; set; }

        /// <summary>
        /// Gets or sets the ResourceProvider parameter
        /// </summary>
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource provider for rule")]
        public string ResourceProvider { get; set; }

        /// <summary>
        /// Gets or sets the Status parameter
        /// </summary>
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The status for rule")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the SubStatus parameter
        /// </summary>
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The substatus for rule")]
        public string SubStatus { get; set; }

        #endregion

        #region Cmdlet parameters for Metric alert rules

        /// <summary>
        /// Gets or sets the EmailAddress parameter
        /// </summary>
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The e-mail address for rule")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the MetricName parameter
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric name for rule")]
        [ValidateNotNullOrEmpty]
        public string MetricName { get; set; }

        /// <summary>
        /// Gets or sets the TimeAggregationOperator parameter
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, ValueFromPipelineByPropertyName = true, HelpMessage = "The time aggregation operator for rule")]
        public TimeAggregationOperator? TimeAggregationOperator { get; set; }

        #endregion

        #region Cmdlet parameters for Webtest alert rules

        /// <summary>
        /// Gets or sets the FailedLocationCount parameter
        /// </summary>
        [Parameter(ParameterSetName = AddWebtestAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The failed location count for rule")]
        public int FailedLocationCount { get; set; }

        #endregion

        private ManagementEventRuleCondition CreateEventRuleCondition()
        {
            return new ManagementEventRuleCondition()
            {
                Aggregation = new ManagementEventAggregationCondition()
                {
                    Operator = this.Operator,
                    Threshold = this.Threshold,
                    WindowSize = this.WindowSize,
                },
                DataSource = new RuleManagementEventDataSource()
                {
                    EventName = this.EventName,
                    EventSource = this.EventSource,
                    Level = this.Level,
                    OperationName = this.OperationName,
                    ResourceGroupName = this.ResourceGroup,
                    ResourceProviderName = this.ResourceProvider,
                    ResourceUri = this.ResourceId,
                    Status = this.Status,
                    SubStatus = this.SubStatus,
                    Claims = new RuleManagementEventClaimsDataSource()
                    {
                        EmailAddress = this.EmailAddress,
                    },
                },
            };   
        }

        private void VerifyRuleTypeToParametersConsistency()
        {
            AlertRuleTypes type = AlertRuleTypes.Event;

            // NOTE: the parameters EventName and MetricName cannot appear both at same time (see the parameters declaration), but they can be both absent simultaneously (i.e. Webtest data source type) 
            if (string.IsNullOrWhiteSpace(this.EventName))
            {
                type = string.IsNullOrWhiteSpace(MetricName) ? AlertRuleTypes.Webtest : AlertRuleTypes.Metric;
            }

            // This comparison is more or less superflous because the parameter sets enforce consistency. But the user will be informed if the input is not consistent with the intention
            if (type != this.RuleType)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, ResourcesForAlertCmdlets.RuleTypeNotConsistentWithParamGroup, this.RuleType));
            }
        }

        private ThresholdRuleCondition CreateThresholdRuleCondition()
        {
            return new ThresholdRuleCondition()
            {
                DataSource = new RuleMetricDataSource()
                {
                    MetricName = this.MetricName,
                    ResourceUri = this.ResourceId,
                },
                Operator = this.Operator,
                Threshold = this.Threshold,
                TimeAggregation = this.TimeAggregationOperator ?? DefaultTimeAggregationOperator,
                WindowSize = this.WindowSize,
            };
        }

        private RuleCondition CreateRuleCondition()
        {
            // Since WindowSize is not mandatory, but it cannot be null (TimeSpan) checking for default value
            if (this.WindowSize == default(TimeSpan))
            {
                this.WindowSize = DefaultWindowSize;
            }

            RuleCondition condition;
            switch (this.RuleType)
            {
                case AlertRuleTypes.Event:
                    condition = this.CreateEventRuleCondition();
                    break;
                case AlertRuleTypes.Metric:
                    condition = this.CreateThresholdRuleCondition();
                    break;
                case AlertRuleTypes.Webtest:
                    condition = new LocationThresholdRuleCondition()
                    {
                        DataSource = new RuleMetricDataSource(),
                        FailedLocationCount = this.FailedLocationCount,
                        WindowSize = this.WindowSize,
                    };
                    break;
                default:
                    throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, ResourcesForAlertCmdlets.RuleTypeNotSupported, this.RuleType));
            }

            return condition;
        }

        protected override RuleCreateOrUpdateParameters CreateSdkCallParameters()
        {
            this.VerifyRuleTypeToParametersConsistency();

            RuleCondition condition = this.CreateRuleCondition();
            return new RuleCreateOrUpdateParameters()
            {
                Location = this.Location,
                Properties = new Rule()
                {
                    Name = this.Name,
                    IsEnabled = !this.DisableRule,
                    Description = this.Description ?? Utilities.GetDefaultDescription("alert rule"),
                    LastUpdatedTime = DateTime.Now,
                    Condition = condition,
                    Action = new RuleEmailAction()
                    {
                        CustomEmails = this.CustomEmails == null ? null : this.CustomEmails.Where(e => !string.IsNullOrWhiteSpace(e)).ToList(), 
                        SendToServiceOwners = this.SendToServiceOwners,
                    },
                },

                // DO NOT REMOVE OR CHANGE the following. The two elements in the Tags are required by other services.
                Tags = new LazyDictionary<string, string>()
                {
                    {"$type" , "Microsoft.WindowsAzure.Management.Common.Storage.CasePreservedDictionary,Microsoft.WindowsAzure.Management.Common.Storage"},
                    {"hidden-link:" + this.ResourceId, "Resource" },
                },
            };
        }
    }
}

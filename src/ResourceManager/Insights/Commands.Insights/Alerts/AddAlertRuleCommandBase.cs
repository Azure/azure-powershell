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
using System.Management.Automation;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Add an Alert rule command base
    /// </summary>
    public abstract class AddAlertRuleCommandBase : ManagementCmdletBase
    {
        internal const string AddMetricAlertParamGroup = "Parameters for AddAlert cmdlet for metrics";
        internal const string AddEventAlertParamGroup = "Parameters for AddAlert cmdlet for events";
        internal const string AddWebtestAlertParamGroup = "Parameters for AddAlert cmdlet for webtests";

        protected static readonly TimeSpan DefaultWindowSize = TimeSpan.FromHours(1);
        protected const TimeAggregationOperator DefaultTimeAggregationOperator = TimeAggregationOperator.Average;

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the rule type of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The rule type")]
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The rule type")]
        [Parameter(ParameterSetName = AddWebtestAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The rule type")]
        public AlertRuleTypes RuleType { get; set; }

        /// <summary>
        /// Gets or sets the Location parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Location name")]
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Location name")]
        [Parameter(ParameterSetName = AddWebtestAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Location name")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Description (rule description) parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The rule description")]
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The rule description")]
        [Parameter(ParameterSetName = AddWebtestAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The rule description")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the DisableRule flag.
        /// <para>Using DisableRule to make false the default, i.e. if the user does not include it in the call, the rule will be enabled.</para>
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The disable rule (status) flag")]
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The disable rule (status) flag")]
        [Parameter(ParameterSetName = AddWebtestAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The disable rule (status) flag")]
        public SwitchParameter DisableRule { get; set; }

        /// <summary>
        /// Gets or sets the ResourceGroupName parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [Parameter(ParameterSetName = AddWebtestAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the rule name parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The alert rule name")]
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The alert rule name")]
        [Parameter(ParameterSetName = AddWebtestAlertParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The alert rule name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The window size for rule")]
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The window size for rule")]
        [Parameter(ParameterSetName = AddWebtestAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The window size for rule")]
        public TimeSpan WindowSize { get; set; }

        /// <summary>
        /// Gets or sets the SendToServiceOwners flag
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The send to service owner flag")]
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The send to service owner flag")]
        [Parameter(ParameterSetName = AddWebtestAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The send to service owner flag")]
        public SwitchParameter SendToServiceOwners { get; set; }

        /// <summary>
        /// Gets or sets the CustomEmails. A comma-separated list of e-mail addresses
        /// </summary>
        [Parameter(ParameterSetName = AddMetricAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of custom e-mails")]
        [Parameter(ParameterSetName = AddEventAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of custom e-mails")]
        [Parameter(ParameterSetName = AddWebtestAlertParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of custom e-mails")]
        [ValidateNotNull]
        [ValidatePattern("([^@]+@[^@]+)+")]
        public string[] CustomEmails { get; set; }

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            RuleCreateOrUpdateParameters parameters = this.CreateSdkCallParameters();
            var result = this.InsightsManagementClient.AlertOperations.CreateOrUpdateRuleAsync(resourceGroupName: this.ResourceGroup, parameters: parameters).Result;
            WriteObject(result);
        }

        /// <summary>
        /// When overriden by a descendant class this method creates the set of parameters for the call to the sdk
        /// </summary>
        /// <returns>The set of parameters for the call to the sdk</returns>
        protected abstract RuleCreateOrUpdateParameters CreateSdkCallParameters();
    }
}

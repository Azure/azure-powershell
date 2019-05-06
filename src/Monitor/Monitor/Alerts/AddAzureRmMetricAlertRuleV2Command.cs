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
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Alerts
{
    /// <summary>
    /// Add a GenV2 Metric Alert rule
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MetricAlertRuleV2", DefaultParameterSetName = "CreateAlertByResourceId", SupportsShouldProcess = true), OutputType(typeof(PSMetricAlertRuleV2))]
    public class AddAzureRmMetricAlertRuleV2Command : ManagementCmdletBase
    {
        const string CreateAlertByResourceId = "CreateAlertByResourceId";
        const string CreateAlertByScopes = "CreateAlertByScopes";

        /// <summary>
        /// Gets or sets Name  parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of metric alert rule")]
        [ValidateNotNullOrEmpty]
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets ResourceGroupName  parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceGroup")]
        public String ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the time window size of the threshold condition
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The window size for rule")]
        public TimeSpan WindowSize { get; set; }

        /// <summary>
        /// Gets or sets the frequency parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The evaluation frequency for rule")]
        [Alias("EvaluationFrequency")]
        public TimeSpan Frequency { get; set; }

        /// <summary>
        /// Gets or sets the TargetResourceId parameter
        /// </summary>
        [Parameter(ParameterSetName = CreateAlertByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target resource id for rule")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Gets or sets the TargetResourceScope parameter
        /// </summary>
        [Parameter(ParameterSetName = CreateAlertByScopes, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target resource scope for rule")]
        [ValidateNotNullOrEmpty]
        [Alias("Scopes")]
        public string[] TargetResourceScope { get; set; }

        /// <summary>
        /// Gets or sets the TargetResourceType  parameter
        /// </summary>
        [Parameter(ParameterSetName = CreateAlertByScopes, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target resource type for rule")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceType { get; set; }

        /// <summary>
        /// Gets or sets the TargetResourceRegion  parameter
        /// </summary>
        [Parameter(ParameterSetName = CreateAlertByScopes, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target resource region for rule")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceRegion { get; set; }

        /// <summary>
        /// Gets or sets the Condition  parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true,ValueFromPipelineByPropertyName = true, HelpMessage = "The condition for rule")]
        [ValidateNotNullOrEmpty]
        [Alias("Criteria")]
        public List<PSMetricCriteria> Condition { get; set; }

        /// <summary>
        /// Gets or sets the ActionGroup  parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true,ValueFromPipelineByPropertyName = true, HelpMessage = "The Action Group for rule")]
        [ValidateNotNullOrEmpty]
        [Alias("Actions")]
        public ActivityLogAlertActionGroup[] ActionGroup { get; set; }

        /// <summary>
        /// Gets or sets the DisableRule flag.
        /// <para>Using DisableRule to make false the default, i.e. if the user does not include it in the call, the rule will be enabled.</para>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The disable rule (status) flag")]
        public SwitchParameter DisableRule { get; set; }

        /// <summary>
        /// Gets or sets the description of the metric alert rule
        /// </summary>
        [Parameter(Mandatory = false,ValueFromPipelineByPropertyName = true,HelpMessage = "The description of the metric alert rule")]
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets the severity of the metric alert rule
        /// </summary>
        [Parameter(Mandatory =true,ValueFromPipelineByPropertyName =true,HelpMessage ="The severity for the metric alert rule")]
        public int Severity { get; set; }

        protected override void ProcessRecordInternal()
        {
            if (this.TargetResourceScope == null)//Single Resource Metric Alert Rule
            {
                var scopes = new List<string>();
                scopes.Add(this.TargetResourceId);
                var metricCriteria = new List<MetricCriteria>();
                foreach (var condition in this.Condition)
                {
                    metricCriteria.Add(new MetricCriteria(name: condition.Name, metricName: condition.MetricName, operatorProperty: condition.OperatorProperty.ToString(), timeAggregation: condition.TimeAggregation.ToString(), threshold: condition.Threshold, metricNamespace: condition.MetricNamespace, dimensions: condition.Dimensions));
                }
                var criteria = new MetricAlertSingleResourceMultipleMetricCriteria(
                    allOf: metricCriteria
                );
                var actions = new List<MetricAlertAction>();
                foreach (var actionGroup in this.ActionGroup)
                {
                    actions.Add(new MetricAlertAction(actionGroupId: actionGroup.ActionGroupId, webhookProperties: actionGroup.WebhookProperties));
                }
                var metricAlertResource = new MetricAlertResource(
                        description: this.Description ?? Utilities.GetDefaultDescription("new Metric alert rule"),
                        severity: this.Severity,
                        location: "global",
                        enabled: !this.DisableRule,
                        scopes: scopes,
                        evaluationFrequency: this.Frequency,
                        windowSize: this.WindowSize,
                        criteria: criteria,
                        actions: actions
                    );
                if (ShouldProcess(
                    target: string.Format("Create/update an alert rule: {0} from resource group: {1}", this.Name, this.ResourceGroupName),
                    action: "Create/update an alert rule"))
                {
                    var result = this.MonitorManagementClient.MetricAlerts.CreateOrUpdateAsync(resourceGroupName: this.ResourceGroupName, ruleName: this.Name, parameters: metricAlertResource).Result;
                    WriteObject(result);
                }
            }
            else// Multi Resource Metric Alert Rule
            {
                List<MultiMetricCriteria> multiMetricCriterias = new List<MultiMetricCriteria>();
                foreach (var condition in this.Condition)
                {
                    multiMetricCriterias.Add(new MetricCriteria(name: condition.Name, metricName: condition.MetricName, operatorProperty: condition.OperatorProperty.ToString(), timeAggregation: condition.TimeAggregation.ToString(), threshold: condition.Threshold, metricNamespace: condition.MetricNamespace, dimensions: condition.Dimensions));
                }
                MetricAlertMultipleResourceMultipleMetricCriteria metricCriteria = new MetricAlertMultipleResourceMultipleMetricCriteria(
                    allOf: multiMetricCriterias
                );
                var actions = new List<MetricAlertAction>();
                foreach (var actionGroup in this.ActionGroup)
                {
                    actions.Add(new MetricAlertAction(actionGroupId: actionGroup.ActionGroupId, webhookProperties: actionGroup.WebhookProperties));
                }
                var metricAlertResource = new MetricAlertResource(
                    description: this.Description ?? Utilities.GetDefaultDescription("New multi resource Metric alert rule"),
                    severity: this.Severity,
                    location: "global",
                    enabled: !this.DisableRule,
                    scopes: this.TargetResourceScope,
                    targetResourceRegion: this.TargetResourceRegion,
                    targetResourceType: this.TargetResourceType,
                    evaluationFrequency: this.Frequency,
                    windowSize: this.WindowSize,
                    criteria: metricCriteria,
                    actions: actions
                );
                if (ShouldProcess(
                    target: string.Format("Create/update an alert rule: {0} from resource group: {1}", this.Name, this.ResourceGroupName),
                    action: "Create/update an alert rule"))
                {
                    var result = this.MonitorManagementClient.MetricAlerts.CreateOrUpdateAsync(resourceGroupName: this.ResourceGroupName, ruleName: this.Name, parameters: metricAlertResource).Result;
                    WriteObject(result);
                }
                    
            }
        }
    }
}

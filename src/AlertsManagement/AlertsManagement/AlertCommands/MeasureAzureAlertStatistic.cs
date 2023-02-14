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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.AlertsManagement.OutputModels;
using Microsoft.Azure.Management.AlertsManagement.Models;

namespace Microsoft.Azure.Commands.AlertsManagement
{
    [Cmdlet("Measure", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertStatistic", DefaultParameterSetName = SummaryFilterParameterSet)]
    [OutputType(typeof(PSAlertsSummary))]
    public class MeasureAzureAlertStatistic : AlertsManagementBaseCmdlet
    {
        #region Parameter Sets

        private const string SummaryFilterParameterSet = "SummaryFilter";
        private const string SummaryTargetResourceIdFilterParameterSet = "SummaryTargetResourceIdFilter";

        #endregion

        #region Parameters declarations

        /// <summary>
        /// Group by mentioned property of alert
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = SummaryTargetResourceIdFilterParameterSet,
                   HelpMessage = "Summarize by property")]
        [Parameter(Mandatory = true,
                   ParameterSetName = SummaryFilterParameterSet,
                   HelpMessage = "Summarize by property")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Severity", "AlertState", "MonitorCondition", "MonitorService", "SignalType", "AlertRule")]
        public string GroupBy { get; set; }

        /// <summary>
        /// Resource Id
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = SummaryTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter on Resource Id of the target resource of alert.")]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Resource Type
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryFilterParameterSet,
                   HelpMessage = "Filter on Resource type of the target resource of alert.")]
        [ResourceTypeCompleter]
        public string TargetResourceType { get; set; }

        /// <summary>
        /// Resource Group Name
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryFilterParameterSet,
                   HelpMessage = "Filter on Resource group name of the target resource of alert.")]
        [ResourceGroupCompleter]
        public string TargetResourceGroup { get; set; }

        /// <summary>
        /// Monitor Service
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter on Moniter Service")]
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryFilterParameterSet,
                   HelpMessage = "Filter on Moniter Service")]
        [PSArgumentCompleter("Application Insights", "ActivityLog Administrative", "ActivityLog Security",
                                "ActivityLog Recommendation", "ActivityLog Policy", "ActivityLog Autoscale",
                                "Log Analytics", "Nagios", "Platform", "SCOM", "ServiceHealth", "SmartDetector",
                                "VM Insights", "Zabbix")]
        public string MonitorService { get; set; }

        /// <summary>
        /// Monitor Condition
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter on Monitor Condition")]
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryFilterParameterSet,
                   HelpMessage = "Filter on Monitor Condition")]
        [PSArgumentCompleter("Fired", "Resolved")]
        public string MonitorCondition { get; set; }

        /// <summary>
        /// Severity
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter on Severity of alert")]
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryFilterParameterSet,
                   HelpMessage = "Filter on Severity of alert")]
        [PSArgumentCompleter("Sev0", "Sev1", "Sev2", "Sev3", "Sev4")]
        public string Severity { get; set; }

        /// <summary>
        /// Alert State
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter on State of alert")]
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryFilterParameterSet,
                   HelpMessage = "Filter on State of alert")]
        [PSArgumentCompleter("New", "Acknowledged", "Closed")]
        public string State { get; set; }

        /// <summary>
        /// Alert Rule Id
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter on Alert Rule Id")]
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryFilterParameterSet,
                   HelpMessage = "Filter on Alert Rule Id")]
        public string AlertRuleId { get; set; }

        /// <summary>
        /// Time range
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryTargetResourceIdFilterParameterSet,
                   HelpMessage = "Supported time range values – 1h, 1d, 7d, 30d (Default is 1d)")]
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryFilterParameterSet,
                   HelpMessage = "Supported time range values – 1h, 1d, 7d, 30d (Default is 1d)")]
        [PSArgumentCompleter("1h", "1d", "7d", "30d")]
        public string TimeRange { get; set; }

        /// <summary>
        /// Custom time range
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryTargetResourceIdFilterParameterSet,
                   HelpMessage = "Supported format - <start-time>/<end-time> where time is in ISO-8601 format")]
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryFilterParameterSet,
                   HelpMessage = "Supported format - <start-time>/<end-time> where time is in ISO-8601 format")]
        public string CustomTimeRange { get; set; }

        /// <summary>
        /// Include SmartGroups Count
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryTargetResourceIdFilterParameterSet,
                   HelpMessage = "Include SmartGroups Count")]
        [Parameter(Mandatory = false,
                   ParameterSetName = SummaryFilterParameterSet,
                   HelpMessage = "Include SmartGroups Count")]
        [PSArgumentCompleter("true", "false")]
        public bool IncludeSmartGroupsCount { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            switch (ParameterSetName)
            {
                case SummaryFilterParameterSet:
                case SummaryTargetResourceIdFilterParameterSet:
                    PSAlertsSummary summary = new PSAlertsSummary(this.AlertsManagementClient.Alerts.GetSummaryWithHttpMessagesAsync(
                        groupby: GroupBy,
                        targetResource: TargetResourceId,
                        targetResourceType: TargetResourceType,
                        targetResourceGroup: TargetResourceGroup,
                        monitorService: MonitorService,
                        monitorCondition: MonitorCondition,
                        severity: Severity,
                        alertState: State,
                        alertRule: AlertRuleId,
                        timeRange: TimeRange,
                        customTimeRange: CustomTimeRange,
                        includeSmartGroupsCount: IncludeSmartGroupsCount
                        ).Result.Body);

                    WriteObject(summary);
                    break;
            }
        }
    }
}

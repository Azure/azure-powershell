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

using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.AlertsManagement.OutputModels;
using Microsoft.Azure.Management.AlertsManagement.Models;

namespace Microsoft.Azure.Commands.AlertsManagement
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Alert", DefaultParameterSetName = AlertsListByFilterParameterSet)]
    [OutputType(typeof(PSAlert))]
    public class GetAzureAlertCommand : AlertsManagementBaseCmdlet
    {
        #region Parameter Set Names

        private const string AlertsListByFilterParameterSet = "AlertsListByFilter";
        private const string AlertsListByTargetResourceIdFilterParameterSet = "AlertsListByTargetResourceIdFilter";
        private const string AlertByIdParameterSet = "AlertById";

        #endregion

        #region Parameters declarations

        /// <summary>
        /// Alert Id
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = AlertByIdParameterSet,
                   HelpMessage = "Unique Identifier of Alert / ResourceId of alert.")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string AlertId { get; set; }

        /// <summary>
        /// Resource Id
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter on Resource Id of the target resource of alert.")]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Resource Type
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Filter on Resource type of the target resource of alert.")]
        [ResourceTypeCompleter]
        public string TargetResourceType { get; set; }

        /// <summary>
        /// Resource Group Name
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Filter on Resource group name of the target resource of alert.")]
        [ResourceGroupCompleter]
        public string TargetResourceGroup { get; set; }

        /// <summary>
        /// Monitor Service
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Filter on Monitor Service")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter on Monitor Service")]
        [PSArgumentCompleter("Application Insights", "ActivityLog Administrative", "ActivityLog Security",
                                "ActivityLog Recommendation", "ActivityLog Policy", "ActivityLog Autoscale",
                                "Log Analytics", "Nagios", "Platform", "SCOM", "ServiceHealth", "SmartDetector",
                                "VM Insights", "Zabbix")]
        public string MonitorService { get; set; }

        /// <summary>
        /// Monitor Condition
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Filter on Monitor Condition")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter on Monitor Condition")]
        [PSArgumentCompleter("Fired", "Resolved")]
        public string MonitorCondition { get; set; }

        /// <summary>
        /// Severity
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Filter on Severity of alert")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter on Severity of alert")]
        [PSArgumentCompleter("Sev0", "Sev1", "Sev2", "Sev3", "Sev4")]
        public string Severity { get; set; }

        /// <summary>
        /// Alert State
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Filter on State of alert")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter on State of alert")]
        [PSArgumentCompleter("New", "Acknowledged", "Closed")]
        public string State { get; set; }

        /// <summary>
        /// Alert Rule Id
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Filter on Alert Rule Id")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter on Alert Rule Id")]
        public string AlertRuleId { get; set; }

        /// <summary>
        /// Smart Group Id
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Filter all the alerts having the Smart Group Id")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Filter all the alerts having the Smart Group Id")]
        public string SmartGroupId { get; set; }

        /// <summary>
        /// Include Context
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Include context (custom payload) of alert - true/false")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Include context (custom payload) of alert - true/false")]
        public bool IncludeContext { get; set; }

        /// <summary>
        /// Include EgressConfig
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Include EgressConfig - true/false")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Include EgressConfig - true/false")]
        public bool IncludeEgressConfig { get; set; }

        /// <summary>
        /// Page count
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Number of alerts to be fetched in a page.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Number of alerts to be fetched in a page.")]
        public int PageCount { get; set; }

        /// <summary>
        /// Alert property to use while sorting
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Alert property to use while sorting")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Alert property to use while sorting")]
        [PSArgumentCompleter("name", "severity", "alertState", "monitorCondition", "targetResource", "targetResourceName", "targetResourceGroup", "targetResourceType", "startDateTime", "lastModifiedDateTime")]
        public string SortBy { get; set; }

        /// <summary>
        /// Sort Order
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Sort Order")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Sort Order")]
        [PSArgumentCompleter("desc", "asc")]
        public string SortOrder { get; set; }

        /// <summary>
        /// Time range
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Supported time range values – 1h, 1d, 7d, 30d (Default is 1d)")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Supported time range values – 1h, 1d, 7d, 30d (Default is 1d)")]
        [PSArgumentCompleter("1h", "1d", "7d", "30d")]
        public string TimeRange { get; set; }

        /// <summary>
        /// Custom time range
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Supported format - <start-time>/<end-time> where time is in ISO-8601 format")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Supported format - <start-time>/<end-time> where time is in ISO-8601 format")]
        public string CustomTimeRange { get; set; }

        /// <summary>
        /// Select fields
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByFilterParameterSet,
                   HelpMessage = "Project the required fields out of essentials. Expected input is comma-separated.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = AlertsListByTargetResourceIdFilterParameterSet,
                   HelpMessage = "Project the required fields out of essentials. Expected input is comma-separated.")]

        public string Select { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            switch (ParameterSetName)
            {
                case AlertsListByFilterParameterSet:
                case AlertsListByTargetResourceIdFilterParameterSet:
                    List<Alert> resultList = new List<Alert>();
                    IPage<Alert> pageResult = new Page<Alert>();
                    pageResult = this.AlertsManagementClient.Alerts.GetAllWithHttpMessagesAsync(
                        targetResource: TargetResourceId,
                        targetResourceType: TargetResourceType,
                        targetResourceGroup: TargetResourceGroup,
                        monitorService: MonitorService,
                        monitorCondition: MonitorCondition,
                        severity: Severity,
                        alertState: State,
                        alertRule: AlertRuleId,
                        smartGroupId: SmartGroupId,
                        includeContext: IncludeContext,
                        includeEgressConfig: IncludeEgressConfig,
                        pageCount: PageCount,
                        sortBy: SortBy,
                        sortOrder: SortOrder,
                        timeRange: TimeRange,
                        customTimeRange: CustomTimeRange,
                        select: Select
                        ).Result.Body;

                    // Deal with paging in response
                    ulong first = MyInvocation.BoundParameters.ContainsKey("First") ? this.PagingParameters.First : ulong.MaxValue;
                    ulong skip = MyInvocation.BoundParameters.ContainsKey("Skip") ? this.PagingParameters.Skip : 0;

                    // Any items before this count should be return
                    ulong lastCount = MyInvocation.BoundParameters.ContainsKey("First") ? skip + first : ulong.MaxValue;
                    ulong currentCount = 0;
                    var nextPageLink = pageResult.NextPageLink;

                    do
                    {
                        nextPageLink = pageResult.NextPageLink;
                        List<Alert> tempList = pageResult.ToList();
                        if (currentCount + (ulong)tempList.Count - 1 < skip)
                        {
                            // skip the whole chunk if they are all in skip
                            currentCount += (ulong)tempList.Count;
                        }
                        else
                        {
                            foreach (Alert currentAlert in tempList)
                            {
                                // not return "skip" count of items in the begin, and only return "first" count of items after that.
                                if (currentCount >= skip && currentCount < lastCount)
                                {
                                    resultList.Add(currentAlert);
                                }
                                currentCount++;
                                if (currentCount >= lastCount)
                                {
                                    break;
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(nextPageLink))
                        {
                            pageResult = this.AlertsManagementClient.Alerts.GetAllNextWithHttpMessagesAsync(nextPageLink).Result.Body;
                        }

                    } while (!string.IsNullOrEmpty(nextPageLink) && currentCount < lastCount);

                    WriteObject(resultList.Select((r) => new PSAlert(r)), enumerateCollection: true);
                    break;
                
                case AlertByIdParameterSet:
                    string id = CommonUtils.GetIdFromARMResourceId(AlertId);
                    PSAlert alert = new PSAlert(this.AlertsManagementClient.Alerts.GetByIdWithHttpMessagesAsync(id).Result.Body);
                    WriteObject(sendToPipeline: alert);
                    break;
            }
        }
    }
}
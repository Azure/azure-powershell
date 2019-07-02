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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ActionRule", DefaultParameterSetName = ListActionRulesParameterSet)]
    [OutputType(typeof(PSActionRule))]
    public class GetAzureActionRule : AlertsManagementBaseCmdlet
    {
        #region Parameter Set Names

        private const string ResourceIdParameterSet = "ResourceId";
        private const string ListActionRulesParameterSet = "ListActionRules";
        private const string ListActionRulesByTargetResourceIdParameterSet = "ListActionRulesByTargetResourceId";
        private const string ListActionRulesByTargetResourceGroupParameterSet = "ListActionRulesByTargetResourceGroup";
        private const string ActionRuleByNameParameterSet = "ActionRuleByName";

        #endregion

        #region Parameters declarations

        /// <summary>
        /// Resource Id of Action rule
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ResourceIdParameterSet,
                   HelpMessage = "Get Action rule by resoure id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Action rule name
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ActionRuleByNameParameterSet,
                   HelpMessage = "Name of action rule.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesParameterSet,
                   HelpMessage = "Filter on Name of action rule.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceIdParameterSet,
                   HelpMessage = "Filter on Name of action rule.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceGroupParameterSet,
                   HelpMessage = "Filter on Name of action rule.")]
        public string Name { get; set; }

        /// <summary>
        /// Resource Group Name
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ActionRuleByNameParameterSet,
                   HelpMessage = "Resource Group Name in which action rule resides.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesParameterSet,
                   HelpMessage = "Filter on Resource Group Name in which action rule resides.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceIdParameterSet,
                   HelpMessage = "Filter on Resource Group Name in which action rule resides.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceGroupParameterSet,
                   HelpMessage = "Filter on Resource Group Name in which action rule resides.")]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Resource Id
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceIdParameterSet,
                   HelpMessage = "Filter on Resource Id of the target resource of alert.")]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Resource Type
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesParameterSet,
                   HelpMessage = "Filter on Resource type of the target resource of alert.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceIdParameterSet,
                   HelpMessage = "Filter on Resource type of the target resource of alert.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceGroupParameterSet,
                   HelpMessage = "Filter on Resource type of the target resource of alert.")]
        [ResourceTypeCompleter]
        public string TargetResourceType { get; set; }

        /// <summary>
        /// Resource Group Name
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceGroupParameterSet,
                   HelpMessage = "Filter on Resource group name of the target resource of alert.")]
        [ResourceGroupCompleter]
        public string TargetResourceGroup { get; set; }

        /// <summary>
        /// Monitor Service
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesParameterSet,
                   HelpMessage = "Filter on Moniter Service")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceIdParameterSet,
                   HelpMessage = "Filter on Moniter Service")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceGroupParameterSet,
                   HelpMessage = "Filter on Moniter Service")]
        [PSArgumentCompleter("Platform", "Log Analytics", "SCOM", "Activity Log")]
        public string MonitorService { get; set; }

        /// <summary>
        /// Severity
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesParameterSet,
                   HelpMessage = "Filter on Severity of alert")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceGroupParameterSet,
                   HelpMessage = "Filter on Severity of alert")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceIdParameterSet,
                   HelpMessage = "Filter on Severity of alert")]
        [PSArgumentCompleter("Sev0", "Sev1", "Sev2", "Sev3", "Sev4")]
        public string Severity { get; set; }

        /// <summary>
        /// Impacted scope
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesParameterSet,
                   HelpMessage = "Filter on Impacted scope")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceIdParameterSet,
                   HelpMessage = "Filter on Impacted scope")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceGroupParameterSet,
                   HelpMessage = "Filter on Impacted scope")]
        public string ImpactedScope { get; set; }

        /// <summary>
        /// Alert Rule Id
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesParameterSet,
                   HelpMessage = "Filter on Alert Rule Id")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceIdParameterSet,
                   HelpMessage = "Filter on Alert Rule Id")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceGroupParameterSet,
                   HelpMessage = "Filter on Alert Rule Id")]
        public string AlertRuleId { get; set; }

        /// <summary>
        /// Description of action group
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesParameterSet,
                   HelpMessage = "Filter all the alerts having the Smart Group Id")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceIdParameterSet,
                   HelpMessage = "Filter all the alerts having the Smart Group Id")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceGroupParameterSet,
                   HelpMessage = "Filter all the alerts having the Smart Group Id")]
        public string Description { get; set; }

        /// <summary>
        /// Include EgressConfig
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesParameterSet,
                   HelpMessage = "Action group")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceIdParameterSet,
                   HelpMessage = "Action group")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ListActionRulesByTargetResourceGroupParameterSet,
                   HelpMessage = "Action group")]
        public string ActionGroup { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            switch (ParameterSetName)
            {
                case ListActionRulesParameterSet:
                case ListActionRulesByTargetResourceIdParameterSet:
                case ListActionRulesByTargetResourceGroupParameterSet:
                    IPage<ActionRule> actionRuleList = new Page<ActionRule>();
                    List<ActionRule> resultList = new List<ActionRule>();
                    if (string.IsNullOrWhiteSpace(ResourceGroupName))
                    {
                        actionRuleList = this.AlertsManagementClient.ActionRules.ListBySubscriptionWithHttpMessagesAsync(
                            targetResource: TargetResourceId,
                            targetResourceType: TargetResourceType,
                            targetResourceGroup: TargetResourceGroup,
                            monitorService: MonitorService,
                            severity: Severity,
                            alertRuleId: AlertRuleId,
                            impactedScope: ImpactedScope,
                            actionGroup: ActionGroup,
                            description: Description,
                            name: Name
                        ).Result.Body;

                        // Deal with paging in response
                        resultList = actionRuleList.ToList();
                        var nextPageLink = actionRuleList.NextPageLink;
                        while (!string.IsNullOrEmpty(nextPageLink))
                        {
                            var pageResult = this.AlertsManagementClient.ActionRules.ListBySubscriptionNextWithHttpMessagesAsync(nextPageLink);
                            foreach (var pageItem in pageResult.Result.Body)
                            {
                                resultList.Add(pageItem);
                            }
                            nextPageLink = pageResult.Result.Body.NextPageLink;
                        }
                    }
                    else
                    {
                         actionRuleList = this.AlertsManagementClient.ActionRules.ListByResourceGroupWithHttpMessagesAsync(
                            resourceGroupName: ResourceGroupName,
                            targetResource: TargetResourceId,
                            targetResourceType: TargetResourceType,
                            targetResourceGroup: TargetResourceGroup,
                            monitorService: MonitorService,
                            severity: Severity,
                            alertRuleId: AlertRuleId,
                            impactedScope: ImpactedScope,
                            actionGroup: ActionGroup,
                            description: Description,
                            name: Name
                        ).Result.Body;

                        // Deal with paging in response
                        resultList = actionRuleList.ToList();
                        var nextPageLink = actionRuleList.NextPageLink;
                        while (!string.IsNullOrEmpty(nextPageLink))
                        {
                            var pageResult = this.AlertsManagementClient.ActionRules.ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink);
                            foreach (var pageItem in pageResult.Result.Body)
                            {
                                resultList.Add(pageItem);
                            }
                            nextPageLink = pageResult.Result.Body.NextPageLink;
                        }
                    }

                    WriteObject(resultList.Select((r) => new PSActionRule(r)), enumerateCollection: true);
                    break;

                case ActionRuleByNameParameterSet:
                    PSActionRule rulebyName = new PSActionRule(this.AlertsManagementClient.ActionRules.GetByNameWithHttpMessagesAsync(ResourceGroupName, Name).Result.Body);
                    WriteObject(sendToPipeline: rulebyName);
                    break;

                case ResourceIdParameterSet:
                    ExtractedInfo info = CommonUtils.ExtractFromActionRuleResourceId(ResourceId);
                    PSActionRule ruleById = new PSActionRule(this.AlertsManagementClient.ActionRules.GetByNameWithHttpMessagesAsync(info.ResourceGroupName, info.Resource).Result.Body);
                    WriteObject(sendToPipeline: ruleById);
                    break;
            }
        }
    }
}
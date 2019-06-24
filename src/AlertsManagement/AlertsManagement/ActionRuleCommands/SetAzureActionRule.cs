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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.AlertsManagement.OutputModels;
using Microsoft.Azure.Management.AlertsManagement.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.AlertsManagement
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ActionRule")]
    [OutputType(typeof(PSActionRule))]
    public class SetAzureActionRule : AlertsManagementBaseCmdlet
    {
        #region Parameter Set Names

        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";
        private const string ByJsonFormatActionRuleParameterSet = "ByJsonFormatActionRule";
        private const string BySimplifiedFormatActionRuleParameterSet = "BySimplifiedFormatActionRule";

        #endregion

        #region Parameters declarations

        /// <summary>
        /// Resource Id of Action rule
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByResourceIdParameterSet,
                   HelpMessage = "Get Action rule by resoure id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the input object
        /// </summary>
        [Parameter(ParameterSetName = ByInputObjectParameterSet,
                    Mandatory = true,
                    ValueFromPipeline = true,
                    HelpMessage = "The action rule resource")]
        public PSActionRule InputObject { get; set; }

        /// <summary>
        /// Resource Group Name
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = ByJsonFormatActionRuleParameterSet,
                HelpMessage = "Resource Group Name")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Action rule name
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = ByJsonFormatActionRuleParameterSet,
                HelpMessage = "Action rule Name")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Action rule Name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Action rule simplified format : Description
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Description of Action Rule")]
        public string Description { get; set; }

        /// <summary>
        /// Action rule simplified format : Status
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Status of Action Rule.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string Status { get; set; }

        /// <summary>
        /// Action rule Json
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = ByJsonFormatActionRuleParameterSet,
                HelpMessage = "Action rule Json format")]
        [ValidateNotNullOrEmpty]
        public string ActionRule { get; set; }

        /// <summary>
        /// Action rule simplified format : Scope Type
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Scope Type")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Resource", "ResourceGroup")]
        public string ScopeType { get; set; }

        /// <summary>
        /// Action rule simplified format : List of values
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Comma separated list of values")]
        [ValidateNotNullOrEmpty]
        public string ScopeValues { get; set; }

        /// <summary>
        /// Action rule simplified format : Severity Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Sev0,Sev1")]
        [ValidateNotNullOrEmpty]
        public string SeverityCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Monitor Service Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Platform,Log Analytics")]
        [ValidateNotNullOrEmpty]
        public string MonitorServiceCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Condition for Monitor Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. NotEquals:Resolved")]
        [ValidateNotNullOrEmpty]
        public string MonitorCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Target Resource Type Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Virtual Machines,Storage Account")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceTypeCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Rule ID Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:/subscriptions/ad825170-845c-47db-8f00-11978947b089/resourceGroups/abvarma/providers/microsoft.insights/metricAlerts/test-mrmc-vm-abvarma")]
        [ValidateNotNullOrEmpty]
        public string AlertRuleIdCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Description Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Test Alert")]
        [ValidateNotNullOrEmpty]
        public string DescriptionCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Alert Context Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:smartgroups")]
        [ValidateNotNullOrEmpty]
        public string AlertContextCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Action Rule Type
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = ByJsonFormatActionRuleParameterSet,
                HelpMessage = "Action rule Json format")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Action Rule Type - Suppression, Actiongroup or Diagnostics. \n" +
                    "Mention SuppressionType and SuppressionConfig for Suppression as parameter. \n" +
                    "Mention ActionGroupId for ActionGroup as parameter.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Suppression", "ActionGroup", "Diagnostics")]
        public string ActionRuleType { get; set; }

        /// <summary>
        /// Action rule simplified format : Suppression Schedule
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Specifies the duration when the suppression should be applied.")]
        [PSArgumentCompleter("Always", "Once", "Daily", "Weekly", "Monthly")]
        public string ReccurenceType { get; set; }

        /// <summary>
        /// Action rule simplified format : Suppression Start Time
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Suppression Start Time. Format 12/09/2018 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Supression Schedule - Once, Daily, Weekly or Monthly.")]
        public string SuppressionStartTime { get; set; }

        // <summary>
        /// Action rule simplified format : Suppression End Time
        /// </summary>
        [Parameter(Mandatory = false,
                 HelpMessage = "Suppression End Time. Format 12/09/2018 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Supression Schedule - Once, Daily, Weekly or Monthly.")]
        public string SuppressionEndTime { get; set; }

        // <summary>
        /// Action rule simplified format : Reccurent values
        /// </summary>
        [Parameter(Mandatory = false,
                 HelpMessage = "Reccurent values, if applicable." +
                    "In case of Weekly - [Saturday,Sunday]\n" +
                    "In case of Monthly - [1,3,5,30]\n")]
        public string ReccurentValues { get; set; }

        /// <summary>
        /// Action rule simplified format : Action Group Id
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionRuleParameterSet,
                HelpMessage = "Action Group Id which is to be notified.")]
        public string ActionGroupId { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            PSActionRule actionRule = new PSActionRule();
            switch (ParameterSetName)
            {
                case ByJsonFormatActionRuleParameterSet:
                    // TODO: Update the action rule json string
                    // ActionRule = ActionRule.Replace("\\\\\\", "+");
                    // Deserialize according to action rule type
                    ActionRule actionRuleObject = JsonConvert.DeserializeObject<ActionRule>(ActionRule);
                    actionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.CreateUpdateWithHttpMessagesAsync(
                            resourceGroupName: ResourceGroupName,
                            actionRuleName: Name,
                            actionRule: actionRuleObject
                        ).Result.Body);
                    break;

                case BySimplifiedFormatActionRuleParameterSet:
                    Conditions conditions = new Conditions(
                            severity: new Condition(
                                operatorProperty: SeverityCondition.Split(':')[0],
                                values: SeverityCondition.Split(':')[1].Split(',')),
                            monitorService: new Condition(
                                operatorProperty: MonitorServiceCondition.Split(':')[0],
                                values: MonitorServiceCondition.Split(':')[1].Split(',')),
                            monitorCondition: new Condition(
                                operatorProperty: MonitorCondition.Split(':')[0],
                                values: MonitorCondition.Split(':')[1].Split(',')),
                            targetResourceType: new Condition(
                                operatorProperty: TargetResourceTypeCondition.Split(':')[0],
                                values: TargetResourceTypeCondition.Split(':')[1].Split(',')),
                            description: new Condition(
                                operatorProperty: DescriptionCondition.Split(':')[0],
                                values: DescriptionCondition.Split(':')[1].Split(',')),
                            alertRuleId: new Condition(
                                operatorProperty: AlertRuleIdCondition.Split(':')[0],
                                values: AlertRuleIdCondition.Split(':')[1].Split(',')),
                            alertContext: new Condition(
                                operatorProperty: AlertContextCondition.Split(':')[0],
                                values: AlertContextCondition.Split(':')[1].Split(',')));

                    Scope scope = new Scope(
                            scopeType: ScopeType,
                            values: ScopeValues.Split(','));

                    switch (ActionRuleType)
                    {
                        case "Suppression":
                            List<int?> recurrentValues = new List<int?>();
                            string[] tokens = ReccurentValues.Split(',');
                            foreach (var token in tokens)
                            {
                                int i;
                                if (int.TryParse(token, out i))
                                {
                                    recurrentValues.Add(i);
                                }
                            }
                            
                            actionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.CreateUpdateWithHttpMessagesAsync(
                                resourceGroupName: ResourceGroupName,
                                actionRuleName: Name,
                                actionRule: new ActionRule(
                                    location: "Global",
                                    properties: new Suppression(
                                        description: Description,
                                        status: Status,
                                        scope: scope,
                                        conditions: conditions,
                                        suppressionConfig: new SuppressionConfig(
                                            recurrenceType: ReccurenceType,
                                            schedule: new SuppressionSchedule(
                                                startDate: SuppressionStartTime.Split(' ')[0],
                                                endDate: SuppressionEndTime.Split(' ')[0],
                                                startTime: SuppressionStartTime.Split(' ')[1],
                                                endTime: SuppressionEndTime.Split(' ')[1],
                                                recurrenceValues: recurrentValues
                                                )
                                            )
                                        )
                                    )
                                ).Result.Body);
                            break;
                        case "ActionGroup":
                            actionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.CreateUpdateWithHttpMessagesAsync(
                                resourceGroupName: ResourceGroupName,
                                actionRuleName: Name,
                                actionRule: new ActionRule(
                                    location: "Global",
                                    properties: new ActionGroup(
                                        description: Description,
                                        status: Status,
                                        scope: scope,
                                        conditions: conditions,
                                        actionGroupId: ActionGroupId
                                        )
                                    )
                                ).Result.Body);
                            break;
                        case "Diagnostics":
                            actionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.CreateUpdateWithHttpMessagesAsync(
                                resourceGroupName: ResourceGroupName,
                                actionRuleName: Name,
                                actionRule: new ActionRule(
                                    location: "Global",
                                    properties: new Diagnostics(
                                        description: Description,
                                        status: Status,
                                        scope: scope,
                                        conditions: conditions
                                        )
                                    )
                                ).Result.Body);
                            break;
                    }

                    break;

                case ByInputObjectParameterSet:
                    //var alert = this.AlertsManagementClient.ActionRules.(AlertId).Result;
                    break;

                case ByResourceIdParameterSet:
                    break;

            }

            WriteObject(sendToPipeline: string.Format("Successfully created Action Rule : {0}.", Name));
            WriteObject(sendToPipeline: actionRule);
        }
    }
}
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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.AlertsManagement.OutputModels;
using Microsoft.Azure.Management.AlertsManagement.Models;
using Newtonsoft.Json;
using Microsoft.Azure.PowerShell.Cmdlets.AlertsManagement.Properties;
using System.Globalization;
using System.Collections;

namespace Microsoft.Azure.Commands.AlertsManagement
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AlertProcessingRule", DefaultParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSAlertProcessingRule))]
    public class SetAzureAlertProcessingRule : AlertsManagementBaseCmdlet
    {
        #region Parameter Set Names

        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet = "BySimplifiedFormatSuppressionActionRule";
        private const string BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet = "BySimplifiedFormatActionGroupActionRule";

        #endregion

        #region Parameters declarations

        /// <summary>
        /// Gets or sets the input object
        /// </summary>
        [Parameter(ParameterSetName = ByInputObjectParameterSet,
                    Mandatory = true,
                    ValueFromPipeline = true,
                    HelpMessage = "The alert processing rule resource")]
        public PSAlertProcessingRule InputObject { get; set; }

        /// <summary>
        /// Resource Group Name
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Resource Group Name")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Alert Processing rule name
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Alert Processing rule Name")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Alert Processing rule Name")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string Name { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Description
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Description of Alert Processing Rule")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Description of Alert Processing Rule")]
        public string Description { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Enabled
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Indicate if the given alert processing rule is enabled or disabled (default is enabled).Allowed values: False,True.")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Indicate if the given alert processing rule is enabled or disabled (default is enabled).Allowed values: False,True.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("True", "False")]
        public string Enabled { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : List of values
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "List of resource IDs, Comma separated list of values. " +
                               "The rule will apply to alerts that fired on resources within that scope")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "List of resource IDs, Comma separated list of values. " +
                               "The rule will apply to alerts that fired on resources within that scope")]
        [ValidateNotNullOrEmpty]
        public List<string> Scope { get; set; }


        /// <summary>
        /// Gets or sets simplified property of patch object : tag
        /// </summary>
        [Parameter(Mandatory = false, 
            ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet, 
            HelpMessage = "Alert Processing rule tags" +
            "For eg.@{<tag1> = <key1>;<tag2>= <key2>} Use {} to clear existing tags. ")]
        [Parameter(Mandatory = false, 
            ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
            HelpMessage = "Alert Processing rule tags" +
            "For eg.@{<tag1> = <key1>;<tag2>= <key2>} Use {} to clear existing tags. ")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Severity Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Sev0,Sev1" +
                              "severity: one of <Sev0, Sev1, Sev2, Sev3, Sev4>.")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Sev0,Sev1" +
                              "severity: one of <Sev0, Sev1, Sev2, Sev3, Sev4>.")]
        public string FilterSeverity { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Monitor Service Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Platform,Log Analytics" +
                              "operation: one of <Equals, NotEquals, Contains, DoesNotContain>")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Platform,Log Analytics" +
                              "operation: one of <Equals, NotEquals, Contains, DoesNotContain>")]
        public string FilterMonitorService { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Condition for Monitor Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. NotEquals:Resolved" +
                              "operation: one of < Equals, NotEquals, Contains, DoesNotContain > ")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. NotEquals:Resolved" +
                              "operation: one of < Equals, NotEquals, Contains, DoesNotContain > ")]
        public string FilterMonitorCondition { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Target Resource Type Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:mySQLDataBaseName" +
                              "operation: one of <Equals, NotEquals, Contains, DoesNotContain>")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:mySQLDataBaseName" +
                              "operation: one of <Equals, NotEquals, Contains, DoesNotContain>")]
        public string FilterTargetResource { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Target Resource Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Virtual Machines,Storage Account" +
                              "operation: one of <Equals, NotEquals, Contains, DoesNotContain>")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Virtual Machines,Storage Account" +
                              "operation: one of <Equals, NotEquals, Contains, DoesNotContain>")]
        public string FilterTargetResourceType { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Target Resource Group Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. NotEquals:/subscriptions/<subscriptionID>/resourceGroups/test")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. NotEquals:/subscriptions/<subscriptionID>/resourceGroups/test")]
        public string FilterTargetResourceGroup { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Rule ID Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:ARM_ID_1,ARM_ID_2")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:ARM_ID_1,ARM_ID_2")]
        public string FilterAlertRuleId { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Rule Name Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:ARM Name Test1,ARM Name Test2")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:ARM Name Test1,ARM Name Test2")]
        public string FilterAlertRuleName { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Description Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Test Alert")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Test Alert")]
        public string FilterDescription { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Alert Context Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:smartgroups")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:smartgroups")]
        public string FilterAlertContext { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Signal Type Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Metric")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Metric")]
        public string FilterSignalType { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Action Rule Type
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Alert Processing rule Type. Allowed values: AddActionGroups, RemoveAllActionGroups.")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Alert Processing rule Type. Allowed values: AddActionGroups, RemoveAllActionGroups.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("RemoveAllActionGroups", "AddActionGroups")]
        public string AlertProcessingRuleType { get; set; }


        /// <summary>
        /// Alert Processing rule simplified format : Start Date Time
        /// </summary>
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
               HelpMessage = "Start Date Time. Format 2022-09-21 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent  Schedule - Once, Daily, Weekly or Monthly.")]
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
               HelpMessage = "Start Date Time. Format 2022-09-21 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Schedule - Once, Daily, Weekly or Monthly.")]
        public string ScheduleStartDateTime { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : End Date Time
        /// </summary>
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
               HelpMessage = "End Date Time. Format 2022-09-21 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent  Schedule - Once, Daily, Weekly or Monthly.")]
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
               HelpMessage = "End Date Time. Format 2022-09-21 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Schedule - Once, Daily, Weekly or Monthly.")]
        public string ScheduleEndDateTime { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Time Zone
        /// </summary>
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
               HelpMessage = "Schedule time zone.  Default: UTC.")]
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
               HelpMessage = "Schedule time zone.  Default: UTC.")]
        public string ScheduleTimeZone { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Schedule Reccurence Type
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Specifies when the processing rule should be applied, Default to Always")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Specifies when the processing rule should be applied, Default to Always")]
        [PSArgumentCompleter("Daily", "Weekly", "Monthly")]
        public string ScheduleReccurenceType { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Schedule Reccurence Type
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Specifies when the processing rule should be applied, Default to Always")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Specifies when the processing rule should be applied, Default to Always")]
        [PSArgumentCompleter("Daily", "Weekly", "Monthly")]
        public string ScheduleReccurence2Type { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Reccurence Days Of Week
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. Monday,Saturday")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. Monday,Saturday")]
        public string ScheduleReccurenceDaysOfWeek { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : second reccurence Days Of Week
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. Monday,Saturday")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. Monday,Saturday")]
        public string ScheduleReccurence2DaysOfWeek { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Reccurence Days Of Month
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. 1,3,12")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. 1,3,12")]
        public string ScheduleReccurenceDaysOfMonth { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Second reccurence Days Of Month
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. 1,3,12")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. 1,3,12")]
        public string ScheduleReccurence2DaysOfMonth { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Reccurence Start Time
        /// </summary>
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
               HelpMessage = "Reccurence Start Time. Format 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent  Schedule - Daily, Weekly or Monthly.")]
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
               HelpMessage = "Reccurence Start Time. Format 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Schedule - Daily, Weekly or Monthly.")]
        public string ScheduleReccurenceStartTime { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : second reccurence Start Time
        /// </summary>
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
               HelpMessage = "Reccurence Start Time. Format 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent  Schedule - Daily, Weekly or Monthly.")]
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
               HelpMessage = "Reccurence Start Time. Format 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Schedule - Daily, Weekly or Monthly.")]
        public string ScheduleReccurence2StartTime { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Reccurence End Time
        /// </summary>
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
               HelpMessage = "Reccurence End Time. Format 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent  Schedule - Daily, Weekly or Monthly.")]
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
               HelpMessage = "Reccurence End Time. Format 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Schedule - Daily, Weekly or Monthly.")]
        public string ScheduleReccurenceEndTime { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Second reccurence End Time
        /// </summary>
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
               HelpMessage = "Reccurence End Time. Format 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent  Schedule - Daily, Weekly or Monthly.")]
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
               HelpMessage = "Reccurence End Time. Format 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Schedule - Daily, Weekly or Monthly.")]
        public string ScheduleReccurence2EndTime { get; set; }

        /// <summary>
        /// Alert Processing simplified format : Action Group Id
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Action Group Ids which are to be notified, Comma separated list of values.\n" +
                              "Required only if alert processing rule type is AddActionGroups.")]
        public string ActionGroupId { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            AlertProcessingRule result = new AlertProcessingRule();
            if (ShouldProcess(
                target: string.Format(Resources.TargetWithRG, this.Name, this.ResourceGroupName),
                action: Resources.CreateOrUpdateAlertProcessingRule_Action))
            {
                try
                {
                    switch (ParameterSetName)
                    {
                        case BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet:
                            if (AlertProcessingRuleType != "AddActionGroups")
                            {
                                throw new PSInvalidOperationException(string.Format(Resources.IncorrectActionRuleType_Exception, "AddActionGroups"));
                            }

                            // Create Alert Processing Rule
                            AlertProcessingRule actionGroupAR = new AlertProcessingRule(
                                location: "Global",
                                tags: ParseTags(),
                                properties: new AlertProcessingRuleProperties(
                                    scopes: Scope,
                                    actions: ParseAddActionGroupsActions(),
                                    conditions: ParseConditions(),
                                    schedule: ValidateParseSchedule(),
                                    description: Description,
                                    enabled: Enabled == null ? true : bool.Parse(Enabled)
                                )
                            );

                            result = this.AlertsManagementClient.AlertProcessingRules.CreateOrUpdateWithHttpMessagesAsync(
                                resourceGroupName: ResourceGroupName, alertProcessingRuleName: Name, alertProcessingRule: actionGroupAR).Result.Body;
                            break;

                        case BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet:

                            if (AlertProcessingRuleType != "RemoveAllActionGroups")
                            {
                                throw new PSInvalidOperationException(string.Format(Resources.IncorrectActionRuleType_Exception, "RemoveAllActionGroups"));
                            }

                            // Create Action Rule
                            AlertProcessingRule suppressionAR = new AlertProcessingRule(
                                location: "Global",
                                tags: ParseTags(),
                                properties: new AlertProcessingRuleProperties(
                                    scopes: Scope,
                                    actions: ParseRemoveAllActionGroupsActions(),
                                    conditions: ParseConditions(),
                                    schedule: ValidateParseSchedule(),
                                    description: Description,
                                    enabled: Enabled == null ? true : bool.Parse(Enabled)
                                )
                            );

                            result = this.AlertsManagementClient.AlertProcessingRules.CreateOrUpdateWithHttpMessagesAsync(
                                resourceGroupName: ResourceGroupName, alertProcessingRuleName: Name, alertProcessingRule: suppressionAR).Result.Body;
                            break;

                        case ByInputObjectParameterSet:
                            ExtractedInfo info = CommonUtils.ExtractFromActionRuleResourceId(InputObject.Id);
                            switch (InputObject.AlertProcessingType)
                            {
                                case "AddActionGroups":
                                    // Create AlertProcessing Rule
                                    PSActionGroupAlertProcessingRule actionGroupInputObject = (PSActionGroupAlertProcessingRule)InputObject;
                                    AlertProcessingRule actionGroupAlertProcessingRuleFromInputObject = new AlertProcessingRule(
                                        location: "Global",
                                        tags: JsonConvert.DeserializeObject<IDictionary<string, string>>(actionGroupInputObject.Tags),
                                        properties: new AlertProcessingRuleProperties(
                                            scopes: JsonConvert.DeserializeObject<IList<string>>(actionGroupInputObject.Scopes),
                                            actions: ExtractActions(actionGroupInputObject.ActionGroupIds),
                                            conditions: JsonConvert.DeserializeObject<IList<Condition>>(actionGroupInputObject.Conditions),
                                            schedule: JsonConvert.DeserializeObject<Schedule>(actionGroupInputObject.Schedule),
                                            description: actionGroupInputObject.Description,
                                            enabled: actionGroupInputObject.Enabled == "True" ? true : false
                                        )
                                    );

                                    result = this.AlertsManagementClient.AlertProcessingRules.CreateOrUpdateWithHttpMessagesAsync(
                                        resourceGroupName: info.ResourceGroupName, alertProcessingRuleName: info.Resource, alertProcessingRule: actionGroupAlertProcessingRuleFromInputObject).Result.Body;
                                    break;

                                case "RemoveAllActionGroups":
                                    PSSuppressionAlertProcessingRule suppressionInputObject = (PSSuppressionAlertProcessingRule)InputObject;

                                    // Create AlertProcessing Rule
                                    AlertProcessingRule suppressionARFromInputObject = new AlertProcessingRule(
                                        location: "Global",
                                        tags: JsonConvert.DeserializeObject<IDictionary<string, string>>(suppressionInputObject.Tags),
                                        properties: new AlertProcessingRuleProperties(
                                            scopes: JsonConvert.DeserializeObject<IList<string>>(suppressionInputObject.Scopes),
                                            actions: ParseRemoveAllActionGroupsActions(),
                                            conditions: JsonConvert.DeserializeObject<IList<Condition>>(suppressionInputObject.Conditions),
                                            schedule: JsonConvert.DeserializeObject<Schedule>(suppressionInputObject.Schedule),
                                            description: suppressionInputObject.Description,
                                            enabled: suppressionInputObject.Enabled == "True" ? true : false
                                        )
                                    );

                                    result = this.AlertsManagementClient.AlertProcessingRules.CreateOrUpdateWithHttpMessagesAsync(
                                        resourceGroupName: info.ResourceGroupName, alertProcessingRuleName: info.Resource, alertProcessingRule: suppressionARFromInputObject).Result.Body;
                                    break;


                            }
                            break;
                    }
                }
                catch (System.Exception e)
                {
                    throw (e);
                }
                WriteObject(sendToPipeline: TransformOutput(result));
            }
        }

        private IList<Action> ExtractActions(string actionGroupId)
        {
            IList<Action> actions = new List<Action>();
            IList<string> actionGroupIds = new List<string>();
            actionGroupIds.Add(actionGroupId);
            AddActionGroups addActionGroups = new AddActionGroups(actionGroupIds);
            actions.Add(addActionGroups);
            return actions;
        }

        private IList<Action> ParseAddActionGroupsActions()
        {
            IList<Action> actions  = new List<Action>();
            AddActionGroups addActionGroups = new AddActionGroups(ActionGroupId.Split(',').ToList());
            actions.Add(addActionGroups);
            return actions;
        }

        private IList<Action> ParseRemoveAllActionGroupsActions()
        {
            IList<Action> actions = new List<Action>();
            RemoveAllActionGroups removeAllActionGroups = new RemoveAllActionGroups();
            actions.Add(removeAllActionGroups);
            return actions;
        }

        /// <summary>
        /// only if it's not Always ReccurenceType we need to parse and build schedule
        /// </summary>
        /// <returns></returns>
        private Schedule ValidateParseSchedule()
        {
            Schedule schedule = new Schedule();

            if (ScheduleReccurenceType == null && ScheduleStartDateTime == null && ScheduleEndDateTime == null)
            {
                return null;
            }

            ValidateSchedule();          
               
            if (ScheduleReccurenceType == null)
            {
                schedule = new Schedule(
                effectiveFrom: ScheduleStartDateTime.Split(' ')[0] + "T" + ScheduleStartDateTime.Split(' ')[1],
                effectiveUntil: ScheduleEndDateTime != null ? ScheduleEndDateTime.Split(' ')[0] + "T" + ScheduleEndDateTime.Split(' ')[1] : ScheduleEndDateTime,
                timeZone: ScheduleTimeZone == null ? "UTC" : ScheduleTimeZone
                );
            }
            else
            {
                IList<Recurrence> recurrences = new List<Recurrence>();

                if (ScheduleReccurenceType == "Daily")
                {
                    recurrences.Add(new DailyRecurrence(ScheduleReccurenceStartTime, ScheduleReccurenceEndTime));
                }

                if (ScheduleReccurenceType == "Weekly")
                {
                    IList<string> daysOfWeek = ScheduleReccurenceDaysOfWeek.Split(',');
                    recurrences.Add(new WeeklyRecurrence(daysOfWeek, ScheduleReccurenceStartTime, ScheduleReccurenceEndTime));
                }

                if (ScheduleReccurenceType == "Monthly")
                {
                    var daysOfMonth = ScheduleReccurenceDaysOfMonth.Split(',').Select(i => (int?)int.Parse(i)).ToList();
                    recurrences.Add(new MonthlyRecurrence(daysOfMonth, ScheduleReccurenceStartTime, ScheduleReccurenceEndTime));
                }
                if(ScheduleReccurence2Type != null)
                {
                    if (ScheduleReccurence2Type == "Daily")
                    {
                        recurrences.Add(new DailyRecurrence(ScheduleReccurence2StartTime, ScheduleReccurence2EndTime));
                    }

                    if (ScheduleReccurence2Type == "Weekly")
                    {
                        IList<string> daysOfWeek = ScheduleReccurence2DaysOfWeek.Split(',');
                        recurrences.Add(new WeeklyRecurrence(daysOfWeek, ScheduleReccurence2StartTime, ScheduleReccurence2EndTime));
                    }

                    if (ScheduleReccurence2Type == "Monthly")
                    {
                        var daysOfMonth = ScheduleReccurence2DaysOfMonth.Split(',').Select(i => (int?)int.Parse(i)).ToList();
                        recurrences.Add(new MonthlyRecurrence(daysOfMonth, ScheduleReccurence2StartTime, ScheduleReccurence2EndTime));
                    }
                }

                schedule = new Schedule(
                    effectiveFrom: ScheduleStartDateTime.Split(' ')[0] + "T" + ScheduleStartDateTime.Split(' ')[1],
                    effectiveUntil: ScheduleEndDateTime.Split(' ')[0] + "T" + ScheduleEndDateTime.Split(' ')[1],
                    timeZone: ScheduleTimeZone == null ? "UTC" : ScheduleTimeZone,
                    recurrences: recurrences
                    );
            }

            return schedule;
        }

        private void ValidateSchedule()
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            System.DateTime outDateTime;

            if (ScheduleStartDateTime == null)
            {
                throw new PSInvalidOperationException("ScheduleStartDateTime must be provided");
            }

            // check start and end date time Format
            if (System.DateTime.TryParseExact(ScheduleStartDateTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDateTime) == false)
            {
                throw new PSInvalidOperationException("Invalid ScheduleStartDateTime Format");
            }
            if (ScheduleEndDateTime != null)
            {
                if (System.DateTime.TryParseExact(ScheduleEndDateTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDateTime) == false)
                {
                    throw new PSInvalidOperationException("Invalid ScheduleEndDateTime Format");
                }
            }
            
            if (ScheduleReccurenceType != null)
            {
                if(ScheduleReccurenceType != "Daily" && ScheduleReccurenceType != "Weekly" && ScheduleReccurenceType != "Monthly")
                {
                    throw new PSInvalidOperationException("ScheduleReccurenceType is Invalid");
                }

                if (ScheduleReccurenceStartTime == null)
                {
                    throw new PSInvalidOperationException("ScheduleReccurenceStartTime must be provided");
                }
                if (ScheduleReccurenceEndTime == null)
                {
                    throw new PSInvalidOperationException("ScheduleReccurenceEndTime must be provided");
                }
                if (System.DateTime.TryParseExact("2022-01-12 " + ScheduleReccurenceStartTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDateTime) == false)
                {
                    throw new PSInvalidOperationException("Invalid ScheduleReccurenceStartTime Format");
                }
                if (System.DateTime.TryParseExact("2022-01-12 " + ScheduleReccurenceEndTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDateTime) == false)
                {
                    throw new PSInvalidOperationException("Invalid ScheduleReccurenceEndTime Format");
                }
                if (ScheduleReccurenceType == "Weekly")
                {
                    if(ScheduleReccurenceDaysOfWeek == null)
                    {
                        throw new PSInvalidOperationException("ScheduleReccurenceDaysOfWeek must be provided");
                    }
                }

                if (ScheduleReccurenceType == "Monthly")
                {
                    if (ScheduleReccurenceDaysOfMonth == null)
                    {
                        throw new PSInvalidOperationException("ScheduleReccurenceDaysOfMonth must be provided");
                    }
                }
            }
            if (ScheduleReccurence2Type != null && ScheduleReccurenceType == null)
            {
                throw new PSInvalidOperationException("The scheduleReccurence must be provided first then you can use scheduleReccurence2");
            }

            if (ScheduleReccurence2Type != null)
            {
                if (ScheduleReccurence2Type != "Daily" && ScheduleReccurence2Type != "Weekly" && ScheduleReccurence2Type != "Monthly")
                {
                    throw new PSInvalidOperationException("ScheduleReccurence2Type is Invalid");
                }
                if (ScheduleReccurence2StartTime == null)
                {
                    throw new PSInvalidOperationException("ScheduleReccurence2StartTime must be provided");
                }
                if (ScheduleReccurence2EndTime == null)
                {
                    throw new PSInvalidOperationException("ScheduleReccurence2EndTime must be provided");
                }
                if (System.DateTime.TryParseExact("2022-01-12 " + ScheduleReccurence2StartTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDateTime) == false)
                {
                    throw new PSInvalidOperationException("Invalid ScheduleReccurence2StartTime Format");
                }
                if (System.DateTime.TryParseExact("2022-01-12 " + ScheduleReccurence2EndTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDateTime) == false)
                {
                    throw new PSInvalidOperationException("Invalid ScheduleReccurence2EndTime Format");
                }
                if (ScheduleReccurence2Type == "Weekly")
                {
                    if (ScheduleReccurence2DaysOfWeek == null)
                    {
                        throw new PSInvalidOperationException("ScheduleReccurence2DaysOfWeek must be provided");
                    }
                }

                if (ScheduleReccurence2Type == "Monthly")
                {
                    if (ScheduleReccurence2DaysOfMonth == null)
                    {
                        throw new PSInvalidOperationException("ScheduleReccurence2DaysOfMonth must be provided");
                    }
                }
            }
        }

        private IDictionary<string, string> ParseTags()
        {
            Dictionary<string, string> tagsDictionary = new Dictionary<string, string>();
            if (Tag != null)
            {
                foreach (var key in Tag.Keys)
                {
                    tagsDictionary.Add((string)key, (string)Tag[key]);
                }
            }

            return tagsDictionary;
        }

        private IList<Condition> ParseConditions()
        {
            bool conditionExist = false;
            IList<Condition> conditions = new List<Condition>();
            if (FilterSeverity != null)
            {
                string operatorProperty = FilterSeverity.Split(':')[0];
                validateCondition(operatorProperty, "FilterSeverity");
                conditions.Add(new Condition(
                        field: "severity",
                        operatorProperty: FilterSeverity.Split(':')[0],
                        values: FilterSeverity.Split(':')[1].Split(',')));
                conditionExist = true;
            }

            if (FilterMonitorService != null)
            {
                string operatorProperty = FilterMonitorService.Split(':')[0];
                validateCondition(operatorProperty, "FilterMonitorService");
                conditions.Add(new Condition(
                        field: "MonitorService",
                        operatorProperty: FilterMonitorService.Split(':')[0],
                        values: FilterMonitorService.Split(':')[1].Split(',')));
                conditionExist = true;
            }

            if (FilterMonitorCondition != null)
            {
                string operatorProperty = FilterMonitorCondition.Split(':')[0];
                validateCondition(operatorProperty, "FilterMonitorCondition");
                conditions.Add(new Condition(
                        field: "MonitorCondition",
                        operatorProperty: FilterMonitorCondition.Split(':')[0],
                        values: FilterMonitorCondition.Split(':')[1].Split(',')));
                conditionExist = true;
            }

            if (FilterTargetResourceType != null)
            {
                string operatorProperty = FilterTargetResourceType.Split(':')[0];
                validateCondition(operatorProperty, "FilterTargetResourceType");
                conditions.Add(new Condition(
                        field: "TargetResourceType",
                        operatorProperty: FilterTargetResourceType.Split(':')[0],
                        values: FilterTargetResourceType.Split(':')[1].Split(',')));
                conditionExist = true;
            }

            if (FilterDescription != null)
            {
                string operatorProperty = FilterDescription.Split(':')[0];
                validateCondition(operatorProperty, "FilterDescription");
                conditions.Add(new Condition(
                        field: "Description",
                        operatorProperty: FilterDescription.Split(':')[0],
                        values: FilterDescription.Split(':')[1].Split(',')));
                conditionExist = true;
            }

             if (FilterAlertRuleName != null)
            {
                string operatorProperty = FilterAlertRuleName.Split(':')[0];
                validateCondition(operatorProperty, "FilterAlertRuleName");
                conditions.Add(new Condition(
                        field: "AlertRuleName",
                        operatorProperty: FilterAlertRuleName.Split(':')[0],
                        values: FilterAlertRuleName.Split(':')[1].Split(',')));
                conditionExist = true;
            }

            if (FilterAlertRuleId != null)
            {
                string operatorProperty = FilterAlertRuleId.Split(':')[0];
                validateCondition(operatorProperty, "FilterAlertRuleId");
                conditions.Add(new Condition(
                        field: "AlertRuleId",
                        operatorProperty: FilterAlertRuleId.Split(':')[0],
                        values: FilterAlertRuleId.Split(':')[1].Split(',')));
                conditionExist = true;
            }
            
            if (FilterAlertContext != null)
            {
                string operatorProperty = FilterAlertContext.Split(':')[0];
                validateCondition(operatorProperty, "FilterAlertContext");
                conditions.Add(new Condition(
                        field: "AlertContext",
                        operatorProperty: FilterAlertContext.Split(':')[0],
                        values: FilterAlertContext.Split(':')[1].Split(',')));
                conditionExist = true;
            }

            if (FilterSignalType != null)
            {
                string operatorProperty = FilterSignalType.Split(':')[0];
                validateCondition(operatorProperty, "FilterSignalType");
                conditions.Add(new Condition(
                        field: "SignalType",
                        operatorProperty: FilterSignalType.Split(':')[0],
                        values: FilterSignalType.Split(':')[1].Split(',')));
                conditionExist = true;
            }

            if(conditionExist == true)
            {
                return conditions;
            }

            return null;
           
        }

        private void validateCondition(string operatorProperty, string conditionType)
        {
            if(operatorProperty != "Equals" && operatorProperty != "NotEquals" && operatorProperty != "Contains" && operatorProperty != "DoesNotContain")
            {
                throw new PSInvalidOperationException(conditionType + ": uncorrect operatorProperty");
            }
        }
        private PSAlertProcessingRule TransformOutput(AlertProcessingRule input)
        {
            if (input.Properties.Actions[0] is AddActionGroups)
            {
                return new PSActionGroupAlertProcessingRule(input);
            }
            else
            {
                return new PSSuppressionAlertProcessingRule(input);
            }

        }
    }
}
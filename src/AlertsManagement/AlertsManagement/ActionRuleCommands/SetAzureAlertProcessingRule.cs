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
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Does Alert Processing Rule Enabled or Not.")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Does Alert Processing Rule Enabled or Not.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("True", "False")]
        public string Enabled { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : List of values
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Comma separated list of values")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Comma separated list of values")]
        [ValidateNotNullOrEmpty]
        public List<string> Scopes { get; set; }


        /// <summary>
        /// Gets or sets simplified property of patch object : tags
        /// </summary>
        [Parameter(Mandatory = false, 
            ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet, 
            HelpMessage = "Alert Processing rule tags")]
        [Parameter(Mandatory = false, 
            ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
            HelpMessage = "Alert Processing rule tags")]
        public Hashtable Tags { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Severity Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Sev0,Sev1")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Sev0,Sev1")]
        public string SeverityCondition { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Monitor Service Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Platform,Log Analytics")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Platform,Log Analytics")]
        public string MonitorServiceCondition { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Condition for Monitor Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. NotEquals:Resolved")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. NotEquals:Resolved")]
        public string MonitorCondition { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Target Resource Type Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:mySQLDataBaseName")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:mySQLDataBaseName")]
        public string TargetResourceTypeCondition { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Target Resource Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Virtual Machines,Storage Account")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Virtual Machines,Storage Account")]
        public string TargetResourceCondition { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Target Resource Group Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. NotEquals:/subscriptions/<subscriptionID>/resourceGroups/test")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. NotEquals:/subscriptions/<subscriptionID>/resourceGroups/test")]
        public string TargetResourceGroupCondition { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Rule ID Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:ARM_ID_1,ARM_ID_2")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:ARM_ID_1,ARM_ID_2")]
        public string AlertRuleIdCondition { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Rule ID Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:ARM Name Test1,ARM Name Test2")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:ARM Name Test1,ARM Name Test2")]
        public string AlertRuleNameCondition { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Description Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Test Alert")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Test Alert")]
        public string DescriptionCondition { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Alert Context Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:smartgroups")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:smartgroups")]
        public string AlertContextCondition { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Signal Type Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Metric")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Metric")]
        public string SignalTypeCondition { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Action Rule Type
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "AlertProcessing Rule Type")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "AlertProcessing Rule Type")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("RemoveAllActionGroups", "AddActionGroups")]
        public string AlertProcessingRuleType { get; set; }


        /// <summary>
        /// Alert Processing rule simplified format : Start Date Time
        /// </summary>
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
               HelpMessage = "Start Date Time. Format 12/09/2018 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent  Schedule - Once, Daily, Weekly or Monthly.")]
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
               HelpMessage = "Start Date Time. Format 12/09/2018 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Schedule - Once, Daily, Weekly or Monthly.")]
        public string StartDateTime { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : End Date Time
        /// </summary>
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
               HelpMessage = "End Date Time. Format 12/09/2018 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent  Schedule - Once, Daily, Weekly or Monthly.")]
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
               HelpMessage = "End Date Time. Format 12/09/2018 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Schedule - Once, Daily, Weekly or Monthly.")]
        public string EndDateTime { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Time Zone
        /// </summary>
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
               HelpMessage = "Time Zone. Format 12/09/2018 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent  Schedule - Once, Daily, Weekly or Monthly.")]
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
               HelpMessage = "Time Zone. Format 12/09/2018 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Schedule - Once, Daily, Weekly or Monthly.")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Schedule Reccurence Type
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Specifies the duration when the action should be applied, Default to Always")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Specifies the duration when the action should be applied, Default to Always")]
        [PSArgumentCompleter("Always", "Once", "Daily", "Weekly", "Monthly")]
        public string ReccurenceType { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Schedule Reccurence Type
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Specifies the duration when the action should be applied.")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Specifies the duration when the action should be applied.")]
        [PSArgumentCompleter("Always", "Once", "Daily", "Weekly", "Monthly")]
        public string ReccurenceType2 { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Reccurence Days Of Week
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. Monday,Saturday")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. Monday,Saturday")]
        public string ReccurenceDaysOfWeek { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : second reccurence Days Of Week
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. Monday,Saturday")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. Monday,Saturday")]
        public string ReccurenceDaysOfWeek2 { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Reccurence Days Of Month
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. 1,3,12")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. 1,3,12")]
        public string ReccurenceDaysOfMonth { get; set; }

        /// <summary>
        /// Alert Processing rule simplified format : Second reccurence Days Of Month
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. 1,3,12")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Expected format - {<comma separated list of values>} For eg. 1,3,12")]
        public string ReccurenceDaysOfMonth2 { get; set; }

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
        public string ReccurenceStartTime { get; set; }

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
        public string ReccurenceStartTime2 { get; set; }

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
        public string ReccurenceEndTime { get; set; }

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
        public string ReccurenceEndTime2 { get; set; }

        /// <summary>
        /// Alert Processing simplified format : Action Group Id
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupAlertProcessingRuleParameterSet,
                HelpMessage = "Action Group Id which is to be notified.")]
        public string ActionGroupId { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            AlertProcessingRule result = new AlertProcessingRule();
            if (ShouldProcess(
                target: string.Format(Resources.TargetWithRG, this.Name, this.ResourceGroupName),
                action: Resources.CreateOrUpdateAlertProcessingRule_Action))
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
                                scopes: Scopes,
                                actions: ParseAddActionGroupsActions(),
                                conditions: ParseConditions(),
                                schedule: ValidateParseSchedule(),                     
                                description: Description,
                                enabled: bool.Parse(Enabled)
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
                                scopes: Scopes,
                                actions: ParseRemoveAllActionGroupsActions(),
                                conditions: ParseConditions(),
                                schedule: ValidateParseSchedule(),
                                description: Description,
                                enabled: bool.Parse(Enabled)
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
                                    tags: JsonConvert.DeserializeObject <IDictionary<string, string>> (actionGroupInputObject.Tags),
                                    properties: new AlertProcessingRuleProperties(
                                        scopes: JsonConvert.DeserializeObject<IList<string>>(actionGroupInputObject.Scopes),
                                        actions: ExtractActions(actionGroupInputObject.ActionGroupId),
                                        conditions: JsonConvert.DeserializeObject<IList<Condition>>(actionGroupInputObject.Conditions),
                                        schedule: actionGroupInputObject.Schedule,
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
                                        schedule: suppressionInputObject.Schedule,
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
            
            if(ReccurenceType == null || ReccurenceType == "Always")
            {
                return null;
            }

            ValidateSchedule();          
               
            if (ReccurenceType == "Once")
            {
                schedule = new Schedule(
                effectiveFrom: StartDateTime.Split(' ')[0] + "T" + StartDateTime.Split(' ')[1],
                effectiveUntil: EndDateTime != null ? EndDateTime.Split(' ')[0] + "T" + EndDateTime.Split(' ')[1] : EndDateTime,
                timeZone: TimeZone
                );
            }
            else
            {
                IList<Recurrence> recurrences = new List<Recurrence>();

                if (ReccurenceType == "Daily")
                {
                    recurrences.Add(new DailyRecurrence(ReccurenceStartTime, ReccurenceEndTime));
                }

                if (ReccurenceType == "Weekly")
                {
                    IList<string> daysOfWeek = ReccurenceDaysOfWeek.Split(',');
                    recurrences.Add(new WeeklyRecurrence(daysOfWeek, ReccurenceStartTime, ReccurenceEndTime));
                }

                if (ReccurenceType == "Monthly")
                {
                    var daysOfMonth = ReccurenceDaysOfMonth.Split(',').Select(i => (int?)int.Parse(i)).ToList();
                    recurrences.Add(new MonthlyRecurrence(daysOfMonth, ReccurenceStartTime, ReccurenceEndTime));
                }

                schedule = new Schedule(
                    effectiveFrom: StartDateTime.Split(' ')[0] + "T" + StartDateTime.Split(' ')[1],
                    effectiveUntil: EndDateTime.Split(' ')[0] + "T" + EndDateTime.Split(' ')[1],
                    timeZone: TimeZone,
                    recurrences: recurrences
                    );
            }

            return schedule;
        }

        private void ValidateSchedule()
        {
            string format = "yyyy-MM-dd hh:mm:ss";
            System.DateTime outDateTime;

            if (StartDateTime == null)
            {
                throw new PSInvalidOperationException("StartDateTime must be provided");
            }

            // check start and end date time Format
            if (System.DateTime.TryParseExact(StartDateTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDateTime) == false)
            {
                throw new PSInvalidOperationException("Invalid StartDateTime Format");
            }
            if (EndDateTime != null)
            {
                if (System.DateTime.TryParseExact(StartDateTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDateTime) == false)
                {
                    throw new PSInvalidOperationException("Invalid EndDateTime Format");
                }
            }
            if(ReccurenceType != "Once")
            {
                if (ReccurenceStartTime == null)
                {
                    throw new PSInvalidOperationException("ReccurenceStartTime must be provided");
                }
                if (ReccurenceEndTime == null)
                {
                    throw new PSInvalidOperationException("ReccurenceEndTime must be provided");
                }
                if (System.DateTime.TryParseExact("2022-01-12 " + ReccurenceStartTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDateTime) == false)
                {
                    throw new PSInvalidOperationException("Invalid ReccurenceStartTime Format");
                }
                if (System.DateTime.TryParseExact("2022-01-12 " + ReccurenceEndTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDateTime) == false)
                {
                    throw new PSInvalidOperationException("Invalid ReccurenceEndTime Format");
                }
                if (ReccurenceType == "Weekly")
                {
                    if(ReccurenceDaysOfWeek == null)
                    {
                        throw new PSInvalidOperationException("ReccurenceDaysOfWeek must be provided");
                    }
                }

                if (ReccurenceType == "Monthly")
                {
                    if (ReccurenceDaysOfMonth == null)
                    {
                        throw new PSInvalidOperationException("ReccurenceDaysOfMonth must be provided");
                    }
                }
            }
        }

        private IDictionary<string, string> ParseTags()
        {
            Dictionary<string, string> tagsDictionary = new Dictionary<string, string>();
            if (Tags != null)
            {
                foreach (var key in Tags.Keys)
                {
                    tagsDictionary.Add((string)key, (string)Tags[key]);
                }
            }

            return tagsDictionary;
        }

        private IList<Condition> ParseConditions()
        {
            IList<Condition> conditions = new List<Condition>();
            if (SeverityCondition != null)
            {
                conditions.Add(new Condition(
                        field: "severity",
                        operatorProperty: SeverityCondition.Split(':')[0],
                        values: SeverityCondition.Split(':')[1].Split(',')));
            }

            if (MonitorServiceCondition != null)
            {
                conditions.Add(new Condition(
                        field: "MonitorService",
                        operatorProperty: MonitorServiceCondition.Split(':')[0],
                        values: MonitorServiceCondition.Split(':')[1].Split(',')));
            }

            if (MonitorCondition != null)
            {
                conditions.Add(new Condition(
                        field: "MonitorCondition",
                        operatorProperty: MonitorCondition.Split(':')[0],
                        values: MonitorCondition.Split(':')[1].Split(',')));
            }

            if (TargetResourceTypeCondition != null)
            {
                conditions.Add(new Condition(
                        field: "TargetResourceType",
                        operatorProperty: TargetResourceTypeCondition.Split(':')[0],
                        values: TargetResourceTypeCondition.Split(':')[1].Split(',')));
            }

            if (DescriptionCondition != null)
            {
                conditions.Add(new Condition(
                        field: "Description",
                        operatorProperty: DescriptionCondition.Split(':')[0],
                        values: DescriptionCondition.Split(':')[1].Split(',')));
            }

             if (AlertRuleNameCondition != null)
            {
                conditions.Add(new Condition(
                        field: "AlertRuleName",
                        operatorProperty: AlertRuleNameCondition.Split(':')[0],
                        values: AlertRuleNameCondition.Split(':')[1].Split(',')));
            }

            if (AlertRuleIdCondition != null)
            {
                conditions.Add(new Condition(
                        field: "AlertRuleId",
                        operatorProperty: AlertRuleIdCondition.Split(':')[0],
                        values: AlertRuleIdCondition.Split(':')[1].Split(',')));
            }
            
            if (AlertContextCondition != null)
            {
                conditions.Add(new Condition(
                        field: "AlertContext",
                        operatorProperty: AlertContextCondition.Split(':')[0],
                        values: AlertContextCondition.Split(':')[1].Split(',')));
            }

            if (SignalTypeCondition != null)
            {
                conditions.Add(new Condition(
                        field: "SignalType",
                        operatorProperty: SignalTypeCondition.Split(':')[0],
                        values: SignalTypeCondition.Split(':')[1].Split(',')));
            }

            return conditions;
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
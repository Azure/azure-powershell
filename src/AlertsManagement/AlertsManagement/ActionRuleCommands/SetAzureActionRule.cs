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

namespace Microsoft.Azure.Commands.AlertsManagement
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ActionRule", DefaultParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSActionRule))]
    public class SetAzureActionRule : AlertsManagementBaseCmdlet
    {
        #region Parameter Set Names

        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string BySimplifiedFormatSuppressionActionRuleParameterSet = "BySimplifiedFormatSuppressionActionRule";
        private const string BySimplifiedFormatActionGroupActionRuleParameterSet = "BySimplifiedFormatActionGroupActionRule";
        private const string BySimplifiedFormatDiagnosticsActionRuleParameterSet = "BySimplifiedFormatDiagnosticsActionRule";

        #endregion

        #region Parameters declarations

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
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Resource Group Name")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Resource Group Name")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Resource Group Name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Action rule name
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Action rule Name")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Action rule Name")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Action rule Name")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string Name { get; set; }

        /// <summary>
        /// Action rule simplified format : Description
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Description of Action Rule")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Description of Action Rule")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Description of Action Rule")]
        public string Description { get; set; }

        /// <summary>
        /// Action rule simplified format : Status
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Status of Action Rule.")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Status of Action Rule.")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Status of Action Rule.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string Status { get; set; }

        /// <summary>
        /// Action rule simplified format : List of values
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Comma separated list of values")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Comma separated list of values")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Comma separated list of values")]
        [ValidateNotNullOrEmpty]
        public List<string> Scope { get; set; }

        /// <summary>
        /// Action rule simplified format : Severity Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Sev0,Sev1")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Sev0,Sev1")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Sev0,Sev1")]
        public string SeverityCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Monitor Service Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Platform,Log Analytics")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Platform,Log Analytics")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:Platform,Log Analytics")]
        public string MonitorServiceCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Condition for Monitor Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. NotEquals:Resolved")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. NotEquals:Resolved")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. NotEquals:Resolved")]
        public string MonitorCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Target Resource Type Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Virtual Machines,Storage Account")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Virtual Machines,Storage Account")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Virtual Machines,Storage Account")]
        public string TargetResourceTypeCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Rule ID Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:ARM_ID_1,ARM_ID_2")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:ARM_ID_1,ARM_ID_2")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Equals:ARM_ID_1,ARM_ID_2")]
        public string AlertRuleIdCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Description Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Test Alert")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Test Alert")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:Test Alert")]
        public string DescriptionCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Alert Context Condition
        /// </summary>
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:smartgroups")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:smartgroups")]
        [Parameter(Mandatory = false,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Expected format - {<operation>:<comma separated list of values>} For eg. Contains:smartgroups")]
        public string AlertContextCondition { get; set; }

        /// <summary>
        /// Action rule simplified format : Action Rule Type
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Action rule Type")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Action rule Type")]
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatDiagnosticsActionRuleParameterSet,
                HelpMessage = "Action rule Type")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Suppression", "ActionGroup", "Diagnostics")]
        public string ActionRuleType { get; set; }

        /// <summary>
        /// Action rule simplified format : Suppression Schedule
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                HelpMessage = "Specifies the duration when the suppression should be applied.")]
        [PSArgumentCompleter("Always", "Once", "Daily", "Weekly", "Monthly")]
        public string ReccurenceType { get; set; }

        /// <summary>
        /// Action rule simplified format : Suppression Start Time
        /// </summary>
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
               HelpMessage = "Suppression Start Time. Format 12/09/2018 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Supression Schedule - Once, Daily, Weekly or Monthly.")]
        public string SuppressionStartTime { get; set; }

        // <summary>
        /// Action rule simplified format : Suppression End Time
        /// </summary>
        [Parameter(Mandatory = false,
               ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
               HelpMessage = "Suppression End Time. Format 12/09/2018 06:00:00\n +" +
                    "Should be mentioned in case of Reccurent Supression Schedule - Once, Daily, Weekly or Monthly.")]
        public string SuppressionEndTime { get; set; }

        // <summary>
        /// Action rule simplified format : Reccurent values
        /// </summary>
        [Parameter(Mandatory = false,
                 ParameterSetName = BySimplifiedFormatSuppressionActionRuleParameterSet,
                 HelpMessage = "Reccurent values, if applicable." +
                    "In case of Weekly - 1,3,5 \n" +
                    "In case of Monthly - 16,24,28 \n")]
        public int[] ReccurentValue { get; set; }

        /// <summary>
        /// Action rule simplified format : Action Group Id
        /// </summary>
        [Parameter(Mandatory = true,
                ParameterSetName = BySimplifiedFormatActionGroupActionRuleParameterSet,
                HelpMessage = "Action Group Id which is to be notified.")]
        public string ActionGroupId { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            ActionRule result = new ActionRule();
            if (ShouldProcess(
                target: string.Format(Resources.TargetWithRG, this.Name, this.ResourceGroupName),
                action: Resources.CreateOrUpdateActionRule_Action))
            {
                switch (ParameterSetName)
                {
                    case BySimplifiedFormatActionGroupActionRuleParameterSet:
                        if (ActionRuleType != "ActionGroup")
                        {
                            throw new PSInvalidOperationException(string.Format(Resources.IncorrectActionRuleType_Exception, "ActionGroup"));
                        }

                        // Create Action Rule
                        ActionRule actionGroupAR = new ActionRule(
                            location: "Global",
                            tags: new Dictionary<string, string>(),
                            properties: new ActionGroup(
                                scope: ParseScope(),
                                conditions: ParseConditions(),
                                actionGroupId: ActionGroupId,
                                description: Description,
                                status: Status
                            )
                        );

                        result = this.AlertsManagementClient.ActionRules.CreateUpdateWithHttpMessagesAsync(
                            resourceGroupName: ResourceGroupName, actionRuleName: Name, actionRule: actionGroupAR).Result.Body;
                        break;

                    case BySimplifiedFormatSuppressionActionRuleParameterSet:

                        if (ActionRuleType != "Suppression")
                        {
                            throw new PSInvalidOperationException(string.Format(Resources.IncorrectActionRuleType_Exception, "Suppression"));
                        }

                        SuppressionConfig config = new SuppressionConfig(recurrenceType: ReccurenceType);
                        if (ReccurenceType != "Always")
                        {
                            config.Schedule = new SuppressionSchedule(
                                startDate: SuppressionStartTime.Split(' ')[0],
                                endDate: SuppressionEndTime.Split(' ')[0],
                                startTime: SuppressionStartTime.Split(' ')[1],
                                endTime: SuppressionEndTime.Split(' ')[1]
                                );

                            if (ReccurentValue.Length > 0)
                            {
                                config.Schedule.RecurrenceValues = ReccurentValue.OfType<int?>().ToList();
                            }
                        }

                        // Create Action Rule
                        ActionRule suppressionAR = new ActionRule(
                            location: "Global",
                            tags: new Dictionary<string, string>(),
                            properties: new Suppression(
                                scope: ParseScope(),
                                conditions: ParseConditions(),
                                description: Description,
                                status: Status,
                                suppressionConfig: config
                            )
                        );

                        result = this.AlertsManagementClient.ActionRules.CreateUpdateWithHttpMessagesAsync(
                            resourceGroupName: ResourceGroupName, actionRuleName: Name, actionRule: suppressionAR).Result.Body;
                        break;

                    case BySimplifiedFormatDiagnosticsActionRuleParameterSet:
                        if (ActionRuleType != "Diagnostics")
                        {
                            throw new PSInvalidOperationException(string.Format(Resources.IncorrectActionRuleType_Exception, "Diagnostics"));
                        }

                        // Create Action Rule
                        ActionRule diagnosticsAR = new ActionRule(
                            location: "Global",
                            tags: new Dictionary<string, string>(),
                            properties: new Diagnostics(
                                scope: ParseScope(),
                                conditions: ParseConditions(),
                                description: Description,
                                status: Status
                            )
                        );

                        result = this.AlertsManagementClient.ActionRules.CreateUpdateWithHttpMessagesAsync(
                            resourceGroupName: ResourceGroupName, actionRuleName: Name, actionRule: diagnosticsAR).Result.Body;

                        break;
                    case ByInputObjectParameterSet:
                        ExtractedInfo info = CommonUtils.ExtractFromActionRuleResourceId(InputObject.Id);
                        switch (InputObject.ActionRuleType)
                        {
                            case "ActionGroup":
                                // Create Action Rule
                                PSActionGroupActionRule actionGroupInputObject = (PSActionGroupActionRule)InputObject;
                                ActionRule actionGroupARFromInputObject = new ActionRule(
                                    location: "Global",
                                    tags: new Dictionary<string, string>(),
                                    properties: new ActionGroup(
                                        scope: JsonConvert.DeserializeObject<Scope>(actionGroupInputObject.Scope),
                                        conditions: JsonConvert.DeserializeObject<Conditions>(actionGroupInputObject.Conditions),
                                        actionGroupId: actionGroupInputObject.ActionGroupId,
                                        description: actionGroupInputObject.Description,
                                        status: actionGroupInputObject.Status
                                    )
                                );

                                result = this.AlertsManagementClient.ActionRules.CreateUpdateWithHttpMessagesAsync(
                                    resourceGroupName: info.ResourceGroupName, actionRuleName: info.Resource, actionRule: actionGroupARFromInputObject).Result.Body;
                                break;

                            case "Suppression":
                                PSSuppressionActionRule suppressionInputObject = (PSSuppressionActionRule)InputObject;
                                SuppressionConfig configFromInputObject = new SuppressionConfig(recurrenceType: suppressionInputObject.RecurrenceType);
                                if (suppressionInputObject.RecurrenceType != "Always")
                                {
                                    configFromInputObject.Schedule = new SuppressionSchedule(
                                        startDate: suppressionInputObject.StartDate,
                                        endDate: suppressionInputObject.EndDate,
                                        startTime: suppressionInputObject.StartTime,
                                        endTime: suppressionInputObject.EndTime
                                        );

                                    if (ReccurentValue.Length > 0)
                                    {
                                        configFromInputObject.Schedule.RecurrenceValues = suppressionInputObject.RecurrenceValues;
                                    }
                                }

                                // Create Action Rule
                                ActionRule suppressionARFromInputObject = new ActionRule(
                                    location: "Global",
                                    tags: new Dictionary<string, string>(),
                                    properties: new Suppression(
                                        scope: JsonConvert.DeserializeObject<Scope>(suppressionInputObject.Scope),
                                        conditions: JsonConvert.DeserializeObject<Conditions>(suppressionInputObject.Conditions),
                                        description: suppressionInputObject.Description,
                                        status: suppressionInputObject.Status,
                                        suppressionConfig: configFromInputObject
                                    )
                                );

                                result = this.AlertsManagementClient.ActionRules.CreateUpdateWithHttpMessagesAsync(
                                    resourceGroupName: info.ResourceGroupName, actionRuleName: info.Resource, actionRule: suppressionARFromInputObject).Result.Body;
                                break;

                            case "Diagnostics":
                                // Create Action Rule
                                PSDiagnosticsActionRule diagnosticsInputObject = (PSDiagnosticsActionRule)InputObject;
                                ActionRule diagnosticsARFromInputObject = new ActionRule(
                                    location: "Global",
                                    tags: new Dictionary<string, string>(),
                                    properties: new Diagnostics(
                                        scope: JsonConvert.DeserializeObject<Scope>(diagnosticsInputObject.Scope),
                                        conditions: JsonConvert.DeserializeObject<Conditions>(diagnosticsInputObject.Conditions),
                                        description: diagnosticsInputObject.Description,
                                        status: diagnosticsInputObject.Status
                                    )
                                );

                                result = this.AlertsManagementClient.ActionRules.CreateUpdateWithHttpMessagesAsync(
                                    resourceGroupName: info.ResourceGroupName, actionRuleName: info.Resource, actionRule: diagnosticsARFromInputObject).Result.Body;
                                break;
                        }
                        break;
                }

                WriteObject(sendToPipeline: TransformOutput(result));
            }
        }

        private Conditions ParseConditions()
        {
            Conditions conditions = new Conditions();
            if (SeverityCondition != null)
            {
                conditions.Severity = new Condition(
                        operatorProperty: SeverityCondition.Split(':')[0],
                        values: SeverityCondition.Split(':')[1].Split(','));
            }

            if (MonitorServiceCondition != null)
            {
                conditions.MonitorService = new Condition(
                        operatorProperty: MonitorServiceCondition.Split(':')[0],
                        values: MonitorServiceCondition.Split(':')[1].Split(','));
            }

            if (MonitorCondition != null)
            {
                conditions.MonitorCondition = new Condition(
                        operatorProperty: MonitorCondition.Split(':')[0],
                        values: MonitorCondition.Split(':')[1].Split(','));
            }

            if (TargetResourceTypeCondition != null)
            {
                conditions.MonitorCondition = new Condition(
                        operatorProperty: TargetResourceTypeCondition.Split(':')[0],
                        values: TargetResourceTypeCondition.Split(':')[1].Split(','));
            }

            if (DescriptionCondition != null)
            {
                conditions.Description = new Condition(
                        operatorProperty: DescriptionCondition.Split(':')[0],
                        values: DescriptionCondition.Split(':')[1].Split(','));
            }

            if (AlertRuleIdCondition != null)
            {
                conditions.AlertRuleId = new Condition(
                        operatorProperty: AlertRuleIdCondition.Split(':')[0],
                        values: AlertRuleIdCondition.Split(':')[1].Split(','));
            }

            if (AlertContextCondition != null)
            {
                conditions.AlertContext = new Condition(
                        operatorProperty: AlertContextCondition.Split(':')[0],
                        values: AlertContextCondition.Split(':')[1].Split(','));
            }

            return conditions;
        }

        private Scope ParseScope()
        {
            Scope scope = new Scope(
                scopeType: DetermineScopeType(Scope),
                values: Scope
            );
            return scope;
        }

        private string DetermineScopeType(List<string> scopeValues)
        {
            if (scopeValues == null || scopeValues?.Count == 0)
            {
                throw new PSInvalidOperationException(string.Format(Resources.EmptyScopeType_Exception));
            }
            else
            {
                // Identify the first scope value
                string scopeType = DetermineScopeType(scopeValues[0]);

                // Check that rest of the values are of same type
                foreach (string value in scopeValues)
                {
                    string current = DetermineScopeType(value);
                    if (current != scopeType)
                    {
                        throw new PSInvalidOperationException(string.Format(Resources.MixedScopeType_Exception));
                    }
                }
                return scopeType;
            }
        }

        private string DetermineScopeType(string value)
        {
            string[] tokens = value.Split('/');

            if (tokens.Length == 5)
            {
                return ScopeType.ResourceGroup;
            }
            else if (tokens.Length >= 9)
            {
                return ScopeType.Resource;
            }
            else
            {
                throw new PSInvalidOperationException(string.Format(Resources.InvalidScopeType_Exception));
            }
        }

        private PSActionRule TransformOutput(ActionRule input)
        {
            string actionRuleType = input.Properties.GetType().Name;

            switch (actionRuleType)
            {
                case "Suppression":
                    return new PSSuppressionActionRule(input);
                case "ActionGroup":
                    return new PSActionGroupActionRule(input);
                case "Diagnostics":
                    return new PSDiagnosticsActionRule(input);
                default:
                    return new PSActionRule(input);
            }
        }
    }
}
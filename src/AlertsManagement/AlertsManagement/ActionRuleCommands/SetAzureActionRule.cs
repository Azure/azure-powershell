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

        #endregion

        protected override void ProcessRecordInternal()
        {
            PSActionRule actionRule = new PSActionRule();
            switch (ParameterSetName)
            {
                case ByJsonFormatActionRuleParameterSet:
                    // TODO: Update the action rule json string
                    //ActionRule = ActionRule.Replace("\\\\\\", "+");
                    ActionRule actionRuleObject = JsonConvert.DeserializeObject<ActionRule>(ActionRule);
                    actionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.CreateUpdateWithHttpMessagesAsync(
                            resourceGroupName: ResourceGroupName,
                            actionRuleName: Name,
                            actionRule: actionRuleObject
                        ).Result.Body);
                    break;

                case BySimplifiedFormatActionRuleParameterSet:
                    actionRule = new PSActionRule(this.AlertsManagementClient.ActionRules.CreateUpdateWithHttpMessagesAsync(
                            resourceGroupName: ResourceGroupName,
                            actionRuleName: Name,
                            actionRule: new ActionRule(
                                location: "Global",
                                properties: new ActionRuleProperties(
                                    scope: new Scope(
                                        scopeType: ScopeType,
                                        values: ScopeValues.Split(',')
                                    ),
                                    conditions: new Conditions(
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
                                            values: AlertContextCondition.Split(':')[1].Split(','))
                                    )
                                )
                            )
                        ).Result.Body);
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
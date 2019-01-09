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
using Microsoft.Azure.Management.Monitor.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.ScheduledQueryRules
{
    /// <summary>
    /// Create a ScheduledQueryRule Trigger Condition object
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRuleTriggerCondition"), OutputType(typeof(PSScheduledQueryRuleTriggerCondition))]
    public class NewScheduledQueryRuleTriggerConditionCommand : MonitorCmdletBase
    {

        #region Cmdlet parameters

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The threshold operator : GreaterThan, LessThan or Equal")]
        [ValidateNotNullOrEmpty]
        public string ThresholdOperator { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The threshold above which alert gets fired")]
        public double Threshold { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The data source on which this alert is created")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleMetricTrigger MetricTrigger { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Type of Query - currently supported values : ResultCount")]
        public string QueryType { get; set; }

        #endregion
        protected override void ProcessRecordInternal()
        {
            TriggerCondition triggerCondition = new TriggerCondition(ThresholdOperator, Threshold, MetricTrigger);
            triggerCondition.Validate();
            WriteObject(new PSScheduledQueryRuleTriggerCondition(triggerCondition));
        }
    }
}

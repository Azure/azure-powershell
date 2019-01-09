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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.ScheduledQueryRules
{
    /// <summary>
    /// Create a ScheduledQueryRule Source object
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRuleAlertingAction"), OutputType(typeof(PSScheduledQueryRuleAlertingAction))]
    public class NewScheduledQueryRuleAlertingActionCommand : MonitorCmdletBase
    {

        #region Cmdlet parameters

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The AzNS action details")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleAznsAction AznsAction { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The severity for this alert")]
        public string Severity { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The duration in minutes for which alert should be throttled")]
        public int? ThrottlingInMin { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The alert trigger condition")]
        [ValidateNotNullOrEmpty]
        public PSScheduledQueryRuleTriggerCondition Trigger { get; set; }

        #endregion
        protected override void ProcessRecordInternal()
        {
            AlertingAction alertingAction = new AlertingAction(Severity, AznsAction, Trigger, ThrottlingInMin);
            alertingAction.Validate();
            WriteObject(new PSScheduledQueryRuleAlertingAction(alertingAction));
        }
    }
}

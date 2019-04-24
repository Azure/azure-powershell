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


namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    public class ScheduledQueryRuleAlertingAction : Monitor.Models.AlertingAction
    {
        public ScheduledQueryRuleAlertingAction() : base()
        { }
        /// <summary>
        /// Initializes a new instance of the ScheduledQueryRuleAlertingAction class.
        /// </summary>
        /// <param name="alertingAction">Specifiy action need to be taken when rule type is Alert</param>
        public ScheduledQueryRuleAlertingAction(Monitor.Models.AlertingAction alertingAction) :
            base(
                severity: alertingAction.Severity,
                aznsAction: alertingAction.AznsAction,
                trigger: alertingAction.Trigger,
                throttlingInMin: alertingAction.ThrottlingInMin)
        { }
    }
}

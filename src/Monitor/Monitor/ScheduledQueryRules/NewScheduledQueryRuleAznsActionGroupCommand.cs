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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledQueryRuleAznsActionGroup"), OutputType(typeof(PSScheduledQueryRuleAznsAction))]
    public class NewScheduledQueryRuleAznsActionGroupCommand : MonitorCmdletBase
    {

        #region Cmdlet parameters

        [Parameter(Mandatory = false, HelpMessage = "The list of action groups to send notification to")]
        public string[] ActionGroup { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The email subject of alert notification")]
        public string EmailSubject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The customized webhook payload")]
        public string CustomWebhookPayload { get; set; }

        #endregion
        protected override void ProcessRecordInternal()
        {
            AzNsActionGroup actionGroup = new AzNsActionGroup(actionGroup: ActionGroup, emailSubject: EmailSubject, customWebhookPayload: CustomWebhookPayload);
            WriteObject(new PSScheduledQueryRuleAznsAction(actionGroup));
        }
    }
}

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

using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{


    /// <summary>
    /// Wraps around the action group.
    /// </summary>
    public class PSActionGroupProperty : PSManagementPropertyDescriptor
    {
        /// <summary>
        /// Gets or sets the action group status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the action group short name.
        /// </summary>
        public string GroupShortName { get; set; }

        /// <summary>
        /// Gets or sets the list of email receivers.
        /// </summary>
        public IList<PSEmailReceiver> EmailReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of SMS receivers.
        /// </summary>
        public IList<PSSmsReceiver> SmsReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of webhook receviers.
        /// </summary>
        public IList<PSWebhookReceiver> WebhookReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of event hub receviers.
        /// </summary>
        public IList<PSEventHubReceiver> EventHubReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of itsm receviers.
        /// </summary>
        public IList<PSItsmReceiver> ItsmReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of voice receviers.
        /// </summary>
        public IList<PSVoiceReceiver> VoiceReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of armrole receviers.
        /// </summary>
        public IList<PSArmRoleReceiver> ArmRoleReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of azure function receviers.
        /// </summary>
        public IList<PSAzureFunctionReceiver> AzureFunctionReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of logic app receviers.
        /// </summary>
        public IList<PSLogicAppReceiver> LogicAppReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of automation runbook  receviers.
        /// </summary>
        public IList<PSAutomationRunbookReceiver> AutomationRunbookReceivers { get; set; }

        /// <summary>
        /// Gets or sets the list of azure app push receviers.
        /// </summary>
        public IList<PSAzureAppPushReceiver> AzureAppPushReceivers { get; set; }


        /// <summary>
        /// Initializes a new instance of the PSActionGroupProperty class.
        /// </summary>
        /// <param name="actionGroup">The action group to wrap.</param>
        public PSActionGroupProperty(ActionGroupResource actionGroup)
        {
            this.Status = actionGroup.Enabled ? "Enabled" : "Disabled";
            this.GroupShortName = actionGroup.GroupShortName;
            this.EmailReceivers = actionGroup.EmailReceivers.Select(e => new PSEmailReceiver(e)).ToList();
            this.SmsReceivers = actionGroup.SmsReceivers.Select(s => new PSSmsReceiver(s)).ToList();
            this.WebhookReceivers = actionGroup.WebhookReceivers.Select(w => new PSWebhookReceiver(w)).ToList();
            this.EventHubReceivers = actionGroup.EventHubReceivers.Select(w => new PSEventHubReceiver(w)).ToList();
            this.ItsmReceivers = actionGroup.ItsmReceivers.Select(w => new PSItsmReceiver(w)).ToList();
            this.VoiceReceivers = actionGroup.VoiceReceivers.Select(w => new PSVoiceReceiver(w)).ToList();
            this.ArmRoleReceivers = actionGroup.ArmRoleReceivers.Select(w => new PSArmRoleReceiver(w)).ToList();
            this.AzureFunctionReceivers = actionGroup.AzureFunctionReceivers.Select(w => new PSAzureFunctionReceiver(w)).ToList();
            this.LogicAppReceivers = actionGroup.LogicAppReceivers.Select(w => new PSLogicAppReceiver(w)).ToList();
            this.AutomationRunbookReceivers = actionGroup.AutomationRunbookReceivers.Select(w => new PSAutomationRunbookReceiver(w)).ToList();
            this.AzureAppPushReceivers = actionGroup.AzureAppPushReceivers.Select(w => new PSAzureAppPushReceiver(w)).ToList();
        }
    }
}

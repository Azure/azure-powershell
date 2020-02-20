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

using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wraps the AutomationRunbookReceiver class.
    /// </summary>
    public class PSAutomationRunbookReceiver : PSActionGroupReceiverBase
    {
        /// <summary>Gets or sets automation account identifier</summary>
        public string AutomationAccountId { get; set; }

        /// <summary>Gets or sets the name of the runbook.</summary>
        public string RunbookName { get; set; }

        /// <summary>Gets or sets the name of the webhook resource id.</summary>
        public string WebhookResourceId { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is global runbook</summary>
        public bool IsGlobalRunbook { get; set; }

        /// <summary>Gets or sets a value indicating whether or not use common alert schema.</summary>
        public bool UseCommonAlertSchema { get; set; }

        /// <summary> Gets or sets the URI where webhooks should be sent..</summary>
        public string ServiceUri { get; set; }

        /// <summary>Initializes a new instance of the PSAutomationRunbookReceiver class</summary>
        public PSAutomationRunbookReceiver()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PSAutomationRunbookReceiver class.
        /// </summary>
        /// <param name="receiver">The receiver to wrap.</param>
        public PSAutomationRunbookReceiver(AutomationRunbookReceiver receiver)
        {
            this.Name = receiver.Name;
            this.AutomationAccountId = receiver.AutomationAccountId;
            this.RunbookName = receiver.RunbookName;
            this.WebhookResourceId = receiver.WebhookResourceId;
            this.IsGlobalRunbook = receiver.IsGlobalRunbook;
            this.UseCommonAlertSchema = receiver.UseCommonAlertSchema;
            this.ServiceUri = receiver.ServiceUri;
        }
    }
}

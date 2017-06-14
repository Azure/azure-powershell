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

using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using System;
using System.Collections;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Create a new Webhook for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAutomationWebhook", SupportsShouldProcess = true)]
    [OutputType(typeof(Webhook))]
    public class NewAzureAutomationWebhook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the module name.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The webhook name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the contentLink
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Runbook Name associated with the webhook.")]
        [ValidateNotNullOrEmpty]
        public string RunbookName { get; set; }

        /// <summary>
        /// Gets or sets the Enabled property of the Webhook
        /// </summary>
        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Enable/Disable property of the Webhook")]
        [ValidateNotNullOrEmpty]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the Expiry Time
        /// </summary>
        [Parameter(Position = 5, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Expiry Time for webhook.")]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset ExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets the Runbook parameters
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false,
            HelpMessage = "The Runbook parameters name/value.")]
        public IDictionary Parameters { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Skip warning message about one-time viewable webhook URL")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            this.ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.WebhookOneTimeURL, "Webhook"),
                string.Format(Resources.WebhookOneTimeURL, "Webhook"),
                Name,
                () =>
                this.WriteObject(
                    this.AutomationClient.CreateWebhook(
                        this.ResourceGroupName,
                        this.AutomationAccountName,
                        this.Name,
                        this.RunbookName,
                        this.IsEnabled,
                        this.ExpiryTime,
                        this.Parameters)));

        }
    }
}

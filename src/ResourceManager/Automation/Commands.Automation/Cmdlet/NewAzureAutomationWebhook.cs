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

using System;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    using System.Collections.Generic;

    /// <summary>
    /// Create a new Webhook for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureAutomationWebhook")]
    [OutputType(typeof(Module))]
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
        /// Gets or sets the contentLink
        /// </summary>
        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Enable/Disable property of the Webhook")]
        [ValidateNotNullOrEmpty]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the contentLink
        /// </summary>
        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Expiry Time for webhook.")]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset ExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets the contentLink
        /// </summary>
        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Runbook parameters name/value.")]
        [ValidateNotNullOrEmpty]
        public Dictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            var createdWebhook = this.AutomationClient.CreateWebhook(
                this.ResourceGroupName,
                this.AutomationAccountName,
                this.Name,
                this.RunbookName,
                this.IsEnabled,
                this.ExpiryTime,
                this.Parameters);
            this.WriteObject(createdWebhook);
        }
    }
}

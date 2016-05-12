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

using Microsoft.Azure.Commands.Automation.Common;
using System;
using System.Collections;

namespace Microsoft.Azure.Commands.Automation.Model
{
    public class Webhook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Module"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The account name.
        /// </param>
        /// <param name="webhook">
        /// The Webhook.
        /// </param>
        /// <param name="webhookUri">
        /// The Webhook URI
        /// </param>
        public Webhook(
            string resourceGroupName,
            string automationAccountName,
            Azure.Management.Automation.Models.Webhook webhook,
            string webhookUri = "")
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("automationAccountName", automationAccountName).NotNull();
            Requires.Argument("webhook", webhook).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.Name = webhook.Name;

            if (webhook.Properties == null) return;

            this.CreationTime = webhook.Properties.CreationTime.ToLocalTime();
            this.Description = webhook.Properties.Description;
            this.ExpiryTime = webhook.Properties.ExpiryTime.ToLocalTime();
            this.IsEnabled = webhook.Properties.IsEnabled;
            if (webhook.Properties.LastInvokedTime.HasValue)
            {
                this.LastInvokedTime = webhook.Properties.LastInvokedTime.Value.ToLocalTime();
            }

            this.LastModifiedTime = webhook.Properties.LastModifiedTime.ToLocalTime();
            this.Parameters = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
            foreach (var kvp in webhook.Properties.Parameters)
            {
                this.Parameters.Add(kvp.Key, (object)PowerShellJsonConverter.Deserialize(kvp.Value));
            }

            this.RunbookName = webhook.Properties.Runbook.Name;
            this.WebhookURI = webhookUri;
        }

        public string ResourceGroupName { get; set; }

        public string AutomationAccountName { get; set; }

        public string Name { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        public string Description { get; set; }

        public DateTimeOffset ExpiryTime { get; set; }

        public bool? IsEnabled { get; set; }

        public DateTimeOffset LastInvokedTime { get; set; }

        public DateTimeOffset LastModifiedTime { get; set; }

        public Hashtable Parameters { get; set; }

        public string RunbookName { get; set; }

        public string WebhookURI { get; set; }
    }
}
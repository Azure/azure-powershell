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
using System.Collections;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Update a Webhook for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmAutomationWebhook")]
    [OutputType(typeof(Webhook))]
    public class SetAzureAutomationWebhook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the Webhook name.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Webhook name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the IsEnabled Property
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Enable/Disable property of the Webhook")]
        [ValidateNotNullOrEmpty]
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the Runbook parameters
        /// </summary>
        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Runbook parameters name/value.")]
        public IDictionary Parameters { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            var updatedWebhook = this.AutomationClient.UpdateWebhook(
                this.ResourceGroupName,
                this.AutomationAccountName,
                this.Name,
                this.Parameters,
                this.IsEnabled);
            this.WriteObject(updatedWebhook);
        }
    }
}

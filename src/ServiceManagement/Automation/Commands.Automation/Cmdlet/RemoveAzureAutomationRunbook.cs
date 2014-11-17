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
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Properties;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Removes an azure automation runbook.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureAutomationRunbook", SupportsShouldProcess = true, DefaultParameterSetName = ByRunbookName)]
    public class RemoveAzureAutomationRunbook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// The remove runbook by runbook id parameter set.
        /// </summary>
        private const string ByRunbookId = "ByRunbookId";

        /// <summary>
        /// The remove runbook by runbook name parameter set.
        /// </summary>
        private const string ByRunbookName = "ByRunbookName";

        /// <summary>
        /// Gets or sets the runbook id
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook id.")]
        [Alias("RunbookId")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook name.")]
        [Alias("RunbookName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter not to confirm on removing the runbook.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not confirm on removing the runbook.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(CultureInfo.CurrentCulture, Resources.RemoveAzureAutomationRunbookWarning),
                string.Format(CultureInfo.CurrentCulture, Resources.RemoveAzureAutomationRunbookDescription),
                this.Id.HasValue ? this.Id.Value.ToString() : this.Name,
                () =>
                    {
                        if (this.Id.HasValue)
                        {
                            // ByRunbookId
                            this.AutomationClient.DeleteRunbook(this.AutomationAccountName, this.Id.Value);
                        }
                        else
                        {
                            // ByRunbookName
                            this.AutomationClient.DeleteRunbook(this.AutomationAccountName, this.Name);
                        }
                    });
        }
    }
}

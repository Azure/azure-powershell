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
    /// <summary>
    /// Unregisters an azure automation scheduled runbook.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "AzureAutomationScheduledRunbook", DefaultParameterSetName = ByRunbookName)]
    [OutputType(typeof(Runbook))]
    public class UnregisterAzureAutomationScheduledRunbook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// The start runbook by runbook id parameter set.
        /// </summary>
        protected const string ByRunbookId = "ByRunbookId";

        /// <summary>
        /// The start runbook by runbook name parameter set.
        /// </summary>
        protected const string ByRunbookName = "ByRunbookName";

        /// <summary>
        /// Gets or sets the runbook Id
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookId, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The runbook id.")]
        [Alias("RunbookId")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The runbook name.")]
        [ValidateNotNullOrEmpty]
        [Alias("RunbookName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the schedule that will be used to start the runbook.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the schedule on which the runbook will be started.")]
        [ValidateNotNullOrEmpty]
        public string ScheduleName { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            Runbook runbook;

            if (this.Id.HasValue)
            {
                runbook = this.AutomationClient.UnregisterScheduledRunbook(
                    this.AutomationAccountName, this.Id.Value, this.ScheduleName);
            }
            else
            {
                runbook = this.AutomationClient.UnregisterScheduledRunbook(
                    this.AutomationAccountName, this.Name, this.ScheduleName);
            }

            this.WriteObject(runbook);
        }
    }
}

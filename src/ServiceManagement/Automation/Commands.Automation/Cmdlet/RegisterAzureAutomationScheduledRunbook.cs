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

using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Registers an azure automation scheduled runbook.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "AzureAutomationScheduledRunbook", DefaultParameterSetName = ByRunbookName)]
    [OutputType(typeof(Runbook))]
    public class RegisterAzureAutomationScheduledRunbook : StartAzureAutomationRunbookBase
    {
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
                runbook = this.AutomationClient.RegisterScheduledRunbook(
                    this.AutomationAccountName, this.Id.Value, this.Parameters, this.ScheduleName);
            }
            else
            {
                runbook = this.AutomationClient.RegisterScheduledRunbook(
                    this.AutomationAccountName, this.Name, this.Parameters, this.ScheduleName);
            }

            this.WriteObject(runbook);
        }
    }
}

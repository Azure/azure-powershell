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
using Microsoft.Azure.Commands.Automation.Properties;
using System;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Unregisters an azure automation scheduled runbook.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "AzureRmAutomationScheduledRunbook", SupportsShouldProcess = true, 
        DefaultParameterSetName = AutomationCmdletParameterSets.ByJobScheduleId)]
    public class UnregisterAzureAutomationScheduledRunbook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the runbook Id
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByJobScheduleId, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The job schedule id.")]
        public Guid? JobScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByRunbookNameAndScheduleName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The runbook name.")]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        public string RunbookName { get; set; }

        /// <summary>
        /// Gets or sets the schedule that will be used to start the runbook.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByRunbookNameAndScheduleName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the schedule on which the runbook will be started.")]
        [ValidateNotNullOrEmpty]
        public string ScheduleName { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter not to confirm on removing the runbook.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Forces the command to run without asking for user confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(CultureInfo.CurrentCulture, Resources.RemoveAzureAutomationJobScheduleWarning),
                string.Format(CultureInfo.CurrentCulture, Resources.RemoveAzureAutomationJobScheduleDescription),
                this.JobScheduleId.HasValue ? this.JobScheduleId.Value.ToString() : this.RunbookName,
                () =>
                    {
                        if (this.ParameterSetName == AutomationCmdletParameterSets.ByJobScheduleId)
                        {
                            this.AutomationClient.UnregisterScheduledRunbook(
                                this.ResourceGroupName, this.AutomationAccountName, this.JobScheduleId.Value);
                        }
                        else if (this.ParameterSetName == AutomationCmdletParameterSets.ByRunbookNameAndScheduleName)
                        {
                            this.AutomationClient.UnregisterScheduledRunbook(
                                this.ResourceGroupName, this.AutomationAccountName, this.RunbookName, this.ScheduleName);
                        }
                    });
        }
    }
}

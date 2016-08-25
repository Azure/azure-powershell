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
using Microsoft.Azure.Commands.Automation.Model;
using System.Collections;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Registers an azure automation scheduled runbook.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "AzureRmAutomationScheduledRunbook", DefaultParameterSetName = AutomationCmdletParameterSets.ByRunbookName)]
    [OutputType(typeof(JobSchedule))]
    public class RegisterAzureAutomationScheduledRunbook : AzureAutomationBaseCmdlet
    {
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
        /// Gets or sets the runbook parameters.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByRunbookNameAndScheduleName, Mandatory = false, ValueFromPipelineByPropertyName = false,
            HelpMessage = "The runbook parameters.")]
        public IDictionary Parameters { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            JobSchedule jobSchedule;

            jobSchedule = this.AutomationClient.RegisterScheduledRunbook(
                    this.ResourceGroupName, this.AutomationAccountName, this.RunbookName, this.ScheduleName, this.Parameters);

            this.WriteObject(jobSchedule);
        }
    }
}

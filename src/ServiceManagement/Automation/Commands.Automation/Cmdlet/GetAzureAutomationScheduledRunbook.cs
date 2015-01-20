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
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation job schedules for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureAutomationScheduledRunbook", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(JobSchedule))]
    public class GetAzureAutomationScheduledRunbook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the job id.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByJobScheduleId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The job schedule id.")]
        public Guid? JobScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the runbook name of the job.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByRunbookName, Mandatory = true, HelpMessage = "The runbook name of the job schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByRunbookNameAndScheduleName, Mandatory = true, HelpMessage = "The runbook name of the job schedule.")]
        [Alias("Name")]
        public string RunbookName { get; set; }

        /// <summary>
        /// Gets or sets the runbook name of the job.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByScheduleName, Mandatory = true, HelpMessage = "The schedule name of the job schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByRunbookNameAndScheduleName, Mandatory = true, HelpMessage = "The schedule name of the job schedule.")]
        public string ScheduleName { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            IEnumerable<JobSchedule> jobSchedules = null;

            if (this.ParameterSetName == AutomationCmdletParameterSets.ByJobScheduleId)
            {
                jobSchedules = new List<JobSchedule>
                                {
                                    this.AutomationClient.GetJobSchedule(
                                        this.AutomationAccountName, this.JobScheduleId .Value)
                                };
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByRunbookNameAndScheduleName)
            {
                jobSchedules = new List<JobSchedule>
                                {
                                    this.AutomationClient.GetJobSchedule(
                                        this.AutomationAccountName, this.RunbookName, this.ScheduleName)
                                };
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByRunbookName)
            {
                jobSchedules = this.AutomationClient.ListJobSchedulesByRunbookName(this.AutomationAccountName, this.RunbookName);
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByScheduleName)
            {
                jobSchedules = this.AutomationClient.ListJobSchedulesByScheduleName(this.AutomationAccountName, this.ScheduleName);
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByAll)
            {
                jobSchedules = this.AutomationClient.ListJobSchedules(this.AutomationAccountName);
            }

            this.GenerateCmdletOutput(jobSchedules);
        }
    }
}

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
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets Azure automation compilation job
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationDscCompilationJob", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(CompilationJob))]
    public class GetAzureAutomationDscCompilationJob : AzureAutomationBaseCmdlet
    {
        /// <summary> 
        /// Gets or sets the job id. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByJobId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The dsc compilation job id.")]
        [Alias("JobId")]
        public Guid Id { get; set; }

        /// <summary> 
        /// Gets or sets the runbook name of the job. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConfigurationName, Mandatory = true, HelpMessage = "The configuration name of the compilation job.")]
        [Alias("Name")]
        public string ConfigurationName { get; set; }

        /// <summary> 
        /// Gets or sets the status of a job. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConfigurationName, Mandatory = false, HelpMessage = "Filter jobs based on their status.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, HelpMessage = "Filter jobs based on their status.")]
        [ValidateSet("Completed", "Failed", "Queued", "Starting", "Resuming", "Running", "Stopped", "Stopping", "Suspended", "Suspending", "Activating")]
        public string Status { get; set; }

        /// <summary> 
        /// Gets or sets the start time filter. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConfigurationName, Mandatory = false, HelpMessage = "Filter compilation jobs so that the compilation job start time >= StartTime.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, HelpMessage = "Filter compilation jobs so that the compilation job start time >= StartTime.")]
        public DateTimeOffset? StartTime { get; set; }

        /// <summary> 
        /// Gets or sets the end time filter. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConfigurationName, Mandatory = false, HelpMessage = "Filter compilation jobs so that the compilation job end time <= EndTime.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, HelpMessage = "Filter compilation jobs so that the compilation job end time <= EndTime.")]
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            IEnumerable<CompilationJob> jobs;

            if (this.Id != null && !Guid.Empty.Equals(this.Id))
            {
                // ByJobId 
                jobs = new List<CompilationJob> { this.AutomationClient.GetCompilationJob(this.ResourceGroupName, this.AutomationAccountName, this.Id) };
            }
            else if (this.ConfigurationName != null)
            {
                // ByConfiguration 
                jobs = this.AutomationClient.ListCompilationJobsByConfigurationName(this.ResourceGroupName, this.AutomationAccountName, this.ConfigurationName, this.StartTime, this.EndTime, this.Status);
            }
            else
            {
                // ByAll 
                jobs = this.AutomationClient.ListCompilationJobs(this.ResourceGroupName, this.AutomationAccountName, this.StartTime, this.EndTime, this.Status);
            }

            this.WriteObject(jobs, true);
        }
    }
}

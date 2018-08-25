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
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets a Source Control Sync Job object for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationSourceControlSyncJob")]
    [OutputType(typeof(Microsoft.Azure.Commands.Automation.Model.SourceControlSyncJob),
                typeof(Microsoft.Azure.Commands.Automation.Model.SourceControlSyncJobRecord))]
    public class GetAzureAutomationSourceControlSyncJob : AzureAutomationBaseCmdlet
    {
        /// <summary> 
        /// Gets or sets the source control name of the job. 
        /// </summary> 
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The source control name of the job.")]
        [Alias("Name")]
        public string SourceControlName { get; set; }

        /// <summary> 
        /// Gets or sets the source control sync job id. 
        /// </summary> 
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
                   ValueFromPipeline = true, HelpMessage = "The source control sync job id.")]
        [Alias("SourceControlSyncJobId")]
        public Guid Id { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            if (this.Id != null && !Guid.Empty.Equals(this.Id))
            {
                // ByJobId 
                var job = this.AutomationClient.GetSourceControlSyncJob(
                            this.ResourceGroupName,
                            this.AutomationAccountName,
                            this.SourceControlName,
                            this.Id);

                this.WriteObject(job);
            }
            else
            {
                // ByAll 
                IEnumerable<Microsoft.Azure.Commands.Automation.Model.SourceControlSyncJob> jobs = null;
                var nextLink = string.Empty;

                do
                {
                    jobs = this.AutomationClient.ListSourceControlSyncJobs(
                                this.ResourceGroupName,
                                this.AutomationAccountName,
                                this.SourceControlName,
                                ref nextLink);

                    this.WriteObject(jobs, true);

                } while (!string.IsNullOrEmpty(nextLink));
            }
        }
    }
}

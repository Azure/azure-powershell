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
using System;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Starts an azure automation source control sync job.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationSourceControlSyncJob",
        SupportsShouldProcess = true)]
    [OutputType(typeof(SourceControlSyncJob))]
    public class StartAzureAutomationSourceControlSyncJob : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the source control name.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The source control name.")]
        [Alias("Name")]
        public string SourceControlName { get; set; }

        /// <summary>
        /// Gets or sets the source control sync job id. 
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The source control sync job id.")]
        [Alias("SourceControlSyncJobId")]
        public Guid JobId { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            if (ShouldProcess(SourceControlName, VerbsLifecycle.Start))
            {
                if (Guid.Empty.Equals(this.JobId))
                {
                    JobId = Guid.NewGuid();
                }

                var syncJob = this.AutomationClient.StartSourceControlSyncJob(
                                    this.ResourceGroupName,
                                    this.AutomationAccountName,
                                    this.SourceControlName,
                                    this.JobId);

                this.WriteObject(syncJob);
            }
        }
    }
}

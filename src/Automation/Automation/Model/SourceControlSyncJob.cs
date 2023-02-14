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
using System.Collections;

namespace Microsoft.Azure.Commands.Automation.Model
{
    using AutomationManagement = Azure.Management.Automation;

    /// <summary>
    /// The SourceControlSyncJob.
    /// </summary>
    public class SourceControlSyncJob
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceControlSyncJob"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The automation account name.
        /// </param>
        /// <param name="sourceControlName">
        /// The sourceControl name.
        /// </param>
        /// <param name="syncJob">
        /// The SourceControlSyncJob object.
        /// </param>
        public SourceControlSyncJob(
            string resourceGroupName,
            string automationAccountName,
            string sourceControlName,
            Microsoft.Azure.Management.Automation.Models.SourceControlSyncJob syncJob)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("accountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("sourceControlName", sourceControlName).NotNull();
            Requires.Argument("sourceControl", syncJob).NotNull();

            this.AutomationAccountName = automationAccountName;
            this.ResourceGroupName = resourceGroupName;
            this.SourceControlName = sourceControlName;
            this.SourceControlSyncJobId = new Guid(syncJob.SourceControlSyncJobId);
            this.ProvisioningState = syncJob.ProvisioningState;
            this.CreationTime = syncJob.CreationTime.ToLocalTime();            
            this.StartTime = syncJob.StartTime.HasValue ? syncJob.StartTime.Value.ToLocalTime() : (DateTimeOffset?)null;
            this.EndTime = syncJob.EndTime.HasValue ? syncJob.EndTime.Value.ToLocalTime() : (DateTimeOffset?)null;
            this.SyncType = syncJob.SyncType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceControlSyncJob"/> class.
        /// </summary>
        public SourceControlSyncJob()
        {
        }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the source control name.
        /// </summary>
        public string SourceControlName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the source control sync job id.
        /// </summary>
        public Guid SourceControlSyncJobId { get; set; }

        /// <summary>
        /// Gets or sets the status of the job.
        /// </summary>
        //public string Status { get; set; }
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the sync type.
        /// </summary>
        public string SyncType { get; set; }

        /// <summary>
        /// Gets or sets the start time of the job.
        /// </summary>
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the job.
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

    }
}

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
    public class SourceControlSyncJobRecord : SourceControlSyncJob
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceControlSyncJobRecord"/> class.
        /// </summary>
        /// <param name="automationAccoutName">
        /// The automation account name.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="sourceControlName">
        /// The sourceControl name.
        /// </param>
        /// <param name="syncJob">
        /// The SourceControlSyncJobById object.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public SourceControlSyncJobRecord(
            string resourceGroupName,
            string automationAccoutName,
            string sourceControlName,
            Microsoft.Azure.Management.Automation.Models.SourceControlSyncJobById syncJob) : base()
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("accountName", automationAccoutName).NotNullOrEmpty();
            Requires.Argument("sourceControlName", sourceControlName).NotNull();
            Requires.Argument("sourceControl", syncJob).NotNull();

            this.AutomationAccountName = automationAccoutName;
            this.ResourceGroupName = resourceGroupName;
            this.SourceControlName = sourceControlName;
            this.SourceControlSyncJobId = new Guid(syncJob.SourceControlSyncJobId.ToString());
            this.ProvisioningState = syncJob.ProvisioningState;
            this.CreationTime = syncJob.CreationTime.ToLocalTime();
            this.StartTime = syncJob.StartTime.HasValue ? syncJob.StartTime.Value.ToLocalTime() : (DateTimeOffset?)null;
            this.EndTime = syncJob.EndTime.HasValue ? syncJob.EndTime.Value.ToLocalTime() : (DateTimeOffset?)null;
            this.SyncType = syncJob.SyncType;

            if (!String.IsNullOrWhiteSpace(syncJob.Exception))
            {
                this.Exception = syncJob.Exception;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceControl"/> class.
        /// </summary>
        public SourceControlSyncJobRecord()
        {
        }

        /// <summary>
        /// Gets or sets the exception of the job.
        /// </summary>
        public string Exception { get; set; }
    }
}

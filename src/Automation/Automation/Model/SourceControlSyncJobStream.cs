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
using AutomationManagement = Microsoft.Azure.Management.Automation;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Source Control Sync Job Stream.
    /// </summary>
    public class SourceControlSyncJobStream
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceControlSyncJobStream"/> class.
        /// </summary>
        /// <param name="stream">
        /// The source control job stream.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The automation account name.
        /// </param>
        /// <param name="sourceControlName">
        /// The source control name.
        /// </param>
        /// <param name="sourceControlSyncJobId">
        /// The job Id.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public SourceControlSyncJobStream(
            AutomationManagement.Models.SourceControlSyncJobStream stream,
            string resourceGroupName,
            string automationAccountName,
            string sourceControlName,
            Guid sourceControlSyncJobId)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("accountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("sourceControlName", sourceControlName).NotNull();
            Requires.Argument("sourceControlSyncJobId", sourceControlSyncJobId).NotNull();

            this.AutomationAccountName = automationAccountName;
            this.ResourceGroupName = resourceGroupName;
            this.SourceControlName = sourceControlName;
            this.SourceControlSyncJobId = sourceControlSyncJobId;

            this.SourceControlSyncJobStreamId = stream.SourceControlSyncJobStreamId;
            this.Type = stream.StreamType;
            this.Time = stream.Time.HasValue ? stream.Time.Value.ToLocalTime() : (DateTimeOffset?)null;

            if (!String.IsNullOrWhiteSpace(stream.Summary))
            {
                this.Summary = stream.Summary;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceControlSyncJobStream"/> class.
        /// </summary>
        public SourceControlSyncJobStream()
        {
        }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        public string SourceControlName { get; set; }

        /// <summary>
        /// Gets or sets the Job Id.
        /// </summary>
        public Guid SourceControlSyncJobId { get; set; }

        /// <summary>
        /// Gets or sets the stream record id
        /// </summary>
        public string SourceControlSyncJobStreamId { get; set; }

        /// <summary>
        /// Gets or sets the stream time.
        /// </summary>
        public DateTimeOffset? Time { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the stream Type.
        /// </summary>
        public string Type { get; set; }
    }
}

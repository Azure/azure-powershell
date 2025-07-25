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
using System.Management.Automation;
using AutomationManagement = Microsoft.Azure.Management.Automation;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Source Control Sync Job Stream Record.
    /// </summary>
    public class SourceControlSyncJobStreamRecord : SourceControlSyncJobStream
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceControlSyncJobStreamRecord"/> class.
        /// </summary>
        /// <param name="syncJobStream">
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
        public SourceControlSyncJobStreamRecord(
            AutomationManagement.Models.SourceControlSyncJobStreamById syncJobStream,
            string resourceGroupName,
            string automationAccountName,
            string sourceControlName,
            Guid sourceControlSyncJobId) : base()
        {
            Requires.Argument("syncJobStream", syncJobStream).NotNull();
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("accountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("sourceControlName", sourceControlName).NotNull();
            Requires.Argument("sourceControlSyncJobId", sourceControlSyncJobId).NotNull();

            this.AutomationAccountName = automationAccountName;
            this.ResourceGroupName = resourceGroupName;
            this.SourceControlName = sourceControlName;
            this.SourceControlSyncJobId = sourceControlSyncJobId;
            this.SourceControlSyncJobStreamId = syncJobStream.SourceControlSyncJobStreamId;
            this.Type = syncJobStream.StreamType;
            this.Time = syncJobStream.Time.HasValue ? syncJobStream.Time.Value.ToLocalTime() : (DateTimeOffset?)null;

            if (!String.IsNullOrWhiteSpace(syncJobStream.Summary))
            {
                this.Summary = syncJobStream.Summary;
            }

            if (!String.IsNullOrWhiteSpace(syncJobStream.StreamText))
            {
                this.StreamText = syncJobStream.StreamText;
            }

            if (syncJobStream.Value != null)
            {
                this.Value = new Hashtable();
                foreach (var kvp in syncJobStream.Value)
                {
                    object paramValue;
                    try
                    {
                        paramValue = ((object)PowerShellJsonConverter.Deserialize(kvp.Value.ToString()));
                    }
                    catch (CmdletInvocationException exception)
                    {
                        if (!exception.Message.Contains("Invalid JSON primitive"))
                            throw;

                        paramValue = kvp.Value;
                    }
                    this.Value.Add(kvp.Key, paramValue);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobStreamRecord"/> class.
        /// </summary>
        public SourceControlSyncJobStreamRecord()
        {
        }

        /// <summary>
        /// Gets or sets the text of the sync job stream.
        /// </summary>
        public string StreamText { get; set; }

        /// <summary>
        /// Gets the value of the sync job stream.
        /// </summary>
        public Hashtable Value { get; set; }
    }
}

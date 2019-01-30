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
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets a Source Control Sync Job object for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationSourceControlSyncJobOutput")]
    [OutputType(typeof(SourceControlSyncJobStream),
                typeof(SourceControlSyncJobStreamRecord))]
    public class GetAzureAutomationSourceControlSyncJobOutput : AzureAutomationBaseCmdlet
    {
        /// <summary> 
        /// Gets or sets the source control name of the job. 
        /// </summary> 
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The source control name.")]
        [Alias("Name")]
        public string SourceControlName { get; set; }

        /// <summary> 
        /// Gets or sets the source control sync job id.
        /// </summary> 
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The source control sync job id.")]
        [Alias("SourceControlSyncJobId")]
        public Guid JobId { get; set; }

        /// <summary> 
        /// Gets or sets the stream type of the job. 
        /// </summary> 
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The stream type. Defaults to Any.")]
        public SourceControlSyncJobStreamType Stream { get; set; }

        /// <summary> 
        /// Gets or sets the stream type of the job. 
        /// </summary> 
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The stream id.")]
        [Alias("SourceControlSyncJobStreamId")]
        public string StreamId { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            if (this.StreamId != null && !Guid.Empty.Equals(this.StreamId))
            {
                // ByStreamId 
                var stream = this.AutomationClient.GetSourceControlSyncJobStreamRecord(
                                this.ResourceGroupName,
                                this.AutomationAccountName,
                                this.SourceControlName,
                                this.JobId,
                                this.StreamId);

                this.WriteObject(stream);
            }
            else
            {
                // ByAll 
                IEnumerable<Microsoft.Azure.Commands.Automation.Model.SourceControlSyncJobStream> streams = null;
                var nextLink = string.Empty;

                do
                {
                    streams = this.AutomationClient.GetSourceControlSyncJobStream(
                                    this.ResourceGroupName,
                                    this.AutomationAccountName,
                                    this.SourceControlName,
                                    this.JobId,
                                    this.Stream.ToString(),
                                    ref nextLink);
                    this.WriteObject(streams, true);

                } while (!string.IsNullOrEmpty(nextLink));
            }
        }
    }
}


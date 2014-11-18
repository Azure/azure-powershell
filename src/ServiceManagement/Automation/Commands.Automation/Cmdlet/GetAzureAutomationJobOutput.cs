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
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation job output streams for a given account and a given job.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureAutomationJobOutput")]
    [OutputType(typeof(JobStreamItem))]
    public class GetAzureAutomationJobOutput : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the job id.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The job id.")]
        [Alias("JobId")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the job start time.
        /// </summary>
        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The time from which job output streams should be retrieved.")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the output type.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(Constants.JobOutputParameter.Any, Constants.JobOutputParameter.Progress, Constants.JobOutputParameter.Output, Constants.JobOutputParameter.Warning, Constants.JobOutputParameter.Error, Constants.JobOutputParameter.Debug, Constants.JobOutputParameter.Verbose, IgnoreCase = true)]
        [Alias("OutputType")]
        public string Stream { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            // Assume local time if DateTimeKind.Unspecified
            if (this.StartTime.Kind == DateTimeKind.Unspecified)
            {
                this.StartTime = DateTime.SpecifyKind(this.StartTime, DateTimeKind.Local);
            }

            var streamTypeNames = new string[]
                                      {
                                          Constants.JobOutputParameter.Progress, Constants.JobOutputParameter.Output,
                                          Constants.JobOutputParameter.Warning, Constants.JobOutputParameter.Error,
                                          Constants.JobOutputParameter.Debug, Constants.JobOutputParameter.Verbose
                                      };
            string streamTypeName =
                streamTypeNames.FirstOrDefault(
                    name => string.Equals(this.Stream, name, StringComparison.OrdinalIgnoreCase));
            IEnumerable<JobStreamItem> streamItems = this.AutomationClient.ListJobStreamItems(
                this.AutomationAccountName, this.Id, this.StartTime, streamTypeName);
            this.WriteObject(streamItems, true);
        }
    }
}

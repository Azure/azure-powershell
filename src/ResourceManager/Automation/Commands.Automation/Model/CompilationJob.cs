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

namespace Microsoft.Azure.Commands.Automation.Model
{
    using Microsoft.Azure.Commands.Automation.Common;
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Linq;
    using AutomationManagement = Microsoft.Azure.Management.Automation;

    /// <summary>
    /// The Dsc Compilation Job
    /// </summary>
    public class CompilationJob
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompilationJob"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="accountName">
        /// The account name.
        /// </param>
        /// <param name="job">
        /// The Job.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public CompilationJob(string resourceGroupName, string accountName, AutomationManagement.Models.DscCompilationJob job)
        {
            Requires.Argument("job", job).NotNull();
            Requires.Argument("accountName", accountName).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = accountName;

            if (job.Properties == null) return;

            this.Id = job.Properties.JobId;
            this.CreationTime = job.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = job.Properties.LastModifiedTime.ToLocalTime();
            this.StartTime = job.Properties.StartTime.HasValue ? job.Properties.StartTime.Value.ToLocalTime() : (DateTimeOffset?)null;
            this.Status = job.Properties.Status;
            this.StatusDetails = job.Properties.StatusDetails;
            this.ConfigurationName = job.Properties.Configuration.Name;
            this.Exception = job.Properties.Exception;
            this.EndTime = job.Properties.EndTime.HasValue ? job.Properties.EndTime.Value.ToLocalTime() : (DateTimeOffset?)null;
            this.LastStatusModifiedTime = job.Properties.LastStatusModifiedTime;
            this.JobParameters = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
            foreach (var kvp in job.Properties.Parameters.Where(kvp => 0 != String.Compare(kvp.Key, Constants.JobStartedByParameterName, CultureInfo.InvariantCulture,
                CompareOptions.IgnoreCase)))
            {
                this.JobParameters.Add(kvp.Key, (object)(kvp.Value));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilationJob"/> class.
        /// </summary>
        public CompilationJob()
        {
        }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automaiton account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the job id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the status of the job.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the status details of the job.
        /// </summary>
        public string StatusDetails { get; set; }

        /// <summary>
        /// Gets or sets the start time of the job.
        /// </summary>
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the job.
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the exception of the job.
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// Gets or sets the last modified time of the job.
        /// </summary>
        public DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the last status modified time of the job."
        /// </summary>
        public DateTimeOffset LastStatusModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the parameters of the job.
        /// </summary>
        public Hashtable JobParameters { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        public string ConfigurationName { get; set; }
    }
}

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
using System.Globalization;
using System.Linq;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;

namespace Microsoft.Azure.Commands.Automation.Model
{
    using AutomationManagement = Management.Automation;

    /// <summary>
    /// The job.
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class.
        /// </summary>
        /// <param name="job">The job</param>
        /// The resource.
        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class.
        /// </summary>
        public Job(AutomationManagement.Models.Job job)
        {
            Requires.Argument("job", job).NotNull();

            if (job.Context == null || job.Context.RunbookVersion == null || job.Context.RunbookVersion.Runbook == null || job.Context.JobParameters == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidJobModel));
            }

            this.Id = new Guid(job.Id);
            this.AccountId = new Guid(job.AccountId);
            this.Exception = job.Exception;
            this.CreationTime = DateTime.SpecifyKind(job.CreationTime, DateTimeKind.Utc).ToLocalTime();
            this.LastModifiedTime = DateTime.SpecifyKind(job.LastModifiedTime, DateTimeKind.Utc).ToLocalTime();
            this.StartTime = job.StartTime.HasValue
                                 ? DateTime.SpecifyKind(job.StartTime.Value, DateTimeKind.Utc).ToLocalTime()
                                 : this.StartTime;
            this.EndTime = job.EndTime.HasValue
                                 ? DateTime.SpecifyKind(job.EndTime.Value, DateTimeKind.Utc).ToLocalTime()
                                 : this.EndTime;
            this.LastStatusModifiedTime = DateTime.SpecifyKind(job.LastStatusModifiedTime, DateTimeKind.Utc).ToLocalTime();
            this.Status = job.Status;
            this.StatusDetails = job.StatusDetails;
            this.RunbookId = new Guid(job.Context.RunbookVersion.Runbook.Id);
            this.RunbookName = job.Context.RunbookVersion.Runbook.Name;
            this.ScheduleName = job.Context.Schedule != null ? job.Context.Schedule.Name : string.Empty;
            this.JobParameters = from jobParameter in job.Context.JobParameters where jobParameter.Name != Constants.JobStartedByParameterName select new JobParameter(jobParameter);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class.
        /// </summary>
        public Job()
        {
        }

        /// <summary>
        /// Gets or sets the job id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the job status.
        /// </summary>
        public string Status { get; set; }       
        
        /// <summary>
        /// Gets or sets the job status details.
        /// </summary>
        public string StatusDetails { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the last time when the job status was modified.
        /// </summary>
        public DateTime LastStatusModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the job exception.
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// Gets or sets the runnook id.
        /// </summary>
        public Guid RunbookId { get; set; }

        /// <summary>
        /// Gets or sets the runbook name.
        /// </summary>
        public string RunbookName { get; set; }

        /// <summary>
        /// Gets or sets the schedule name.
        /// </summary>
        public string ScheduleName { get; set; }

        /// <summary>
        /// Gets or sets the job parameters.
        /// </summary>
        public IEnumerable<JobParameter> JobParameters { get; set; }
    }
}

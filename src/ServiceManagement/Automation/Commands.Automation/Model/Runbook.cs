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
    /// The Runbook.
    /// </summary>
    public class Runbook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Runbook"/> class.
        /// </summary>
        /// <param name="runbook">
        /// The runbook.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public Runbook(AutomationManagement.Models.Runbook runbook)
        {
            Requires.Argument("runbook", runbook).NotNull();
            if (runbook.Schedules == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidRunbookModel));
            }

            this.AccountId = new Guid(runbook.AccountId);
            this.Id = new Guid(runbook.Id);
            this.Name = runbook.Name;
            this.CreationTime = DateTime.SpecifyKind(runbook.CreationTime, DateTimeKind.Utc).ToLocalTime();
            this.LastModifiedTime = DateTime.SpecifyKind(runbook.LastModifiedTime, DateTimeKind.Utc).ToLocalTime();
            this.LastModifiedBy = runbook.LastModifiedBy;
            this.Description = runbook.Description;
            this.IsApiOnly = runbook.IsApiOnly;
            this.IsGlobal = runbook.IsGlobal;

            if (runbook.PublishedRunbookVersionId != null)
            {
                this.PublishedRunbookVersionId = new Guid(runbook.PublishedRunbookVersionId);
            }

            if (runbook.DraftRunbookVersionId != null)
            {
                this.DraftRunbookVersionId = new Guid(runbook.DraftRunbookVersionId);
            }

            this.Tags = runbook.Tags != null ? runbook.Tags.Split(Constants.RunbookTagsSeparatorChar) : new string[] { };
            this.LogDebug = runbook.LogDebug;
            this.LogVerbose = runbook.LogVerbose;
            this.LogProgress = runbook.LogProgress;
            this.ScheduleNames = from schedule in runbook.Schedules where (schedule.NextRun != null) select schedule.Name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Runbook"/> class.
        /// </summary>
        public Runbook()
        {
        }

        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        public DateTime LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified by.
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is api only.
        /// </summary>
        public bool IsApiOnly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is global.
        /// </summary>
        public bool IsGlobal { get; set; }

        /// <summary>
        /// Gets or sets the published runbook version id.
        /// </summary>
        public Guid? PublishedRunbookVersionId { get; set; }

        /// <summary>
        /// Gets or sets the draft runbook version id.
        /// </summary>
        public Guid? DraftRunbookVersionId { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether log debug is enabled.
        /// </summary>
        public bool LogDebug { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether log verbose is enabled.
        /// </summary>
        public bool LogVerbose { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether log progress is enabled.
        /// </summary>
        public bool LogProgress { get; set; }

        /// <summary>
        /// Gets or sets the schedule names.
        /// </summary>
        public IEnumerable<string> ScheduleNames { get; set; }
    }
}

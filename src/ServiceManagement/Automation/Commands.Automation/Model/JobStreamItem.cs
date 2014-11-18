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
using Microsoft.Azure.Commands.Automation.Common;

namespace Microsoft.Azure.Commands.Automation.Model
{
    using AutomationManagement = Management.Automation;

    /// <summary>
    /// The JobStreamItem.
    /// </summary>
    public class JobStreamItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobStreamItem"/> class.
        /// </summary>
        /// <param name="jobStreamItem">
        /// The job stream item.
        /// </param>
        public JobStreamItem(AutomationManagement.Models.JobStreamItem jobStreamItem)
        {
            Requires.Argument("jobStreamItem", jobStreamItem).NotNull();

            this.AccountId = new Guid(jobStreamItem.AccountId);
            this.JobId = new Guid(jobStreamItem.JobId);
            this.RunbookVersionId = new Guid(jobStreamItem.RunbookVersionId);
            this.Text = jobStreamItem.Text;
            this.Time = DateTime.SpecifyKind(jobStreamItem.Time, DateTimeKind.Utc).ToLocalTime();
            this.Type = jobStreamItem.Type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobStreamItem"/> class.
        /// </summary>
        public JobStreamItem()
        {
        }

        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the job id.
        /// </summary>
        public Guid JobId { get; set; }

        /// <summary>
        /// Gets or sets the runbook version id.
        /// </summary>
        public Guid RunbookVersionId { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }
    }
}
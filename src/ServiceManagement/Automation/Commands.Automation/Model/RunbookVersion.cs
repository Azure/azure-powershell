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
    /// The Runbook.
    /// </summary>
    public class RunbookVersion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RunbookVersion"/> class.
        /// </summary>
        /// <param name="runbookVersion">
        /// The runbook version.
        /// </param>
        public RunbookVersion(AutomationManagement.Models.RunbookVersion runbookVersion)
        {
            Requires.Argument("runbookVersion", runbookVersion).NotNull();

            this.AccountId = new Guid(runbookVersion.AccountId);
            this.Id = new Guid(runbookVersion.Id);
            this.RunbookId = new Guid(runbookVersion.RunbookId);
            this.VersionNumber = runbookVersion.VersionNumber;
            this.IsDraft = runbookVersion.IsDraft;
            this.CreationTime = DateTime.SpecifyKind(runbookVersion.CreationTime, DateTimeKind.Utc).ToLocalTime();
            this.LastModifiedTime = DateTime.SpecifyKind(runbookVersion.LastModifiedTime, DateTimeKind.Utc).ToLocalTime();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RunbookVersion"/> class.
        /// </summary>
        public RunbookVersion()
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
        /// Gets or sets the runbook id.
        /// </summary>
        public Guid RunbookId { get; set; }

        /// <summary>
        /// Gets or sets the version number.
        /// </summary>
        public int VersionNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is draft.
        /// </summary>
        public bool IsDraft { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        public DateTime LastModifiedTime { get; set; }
    }
}

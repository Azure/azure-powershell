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

            this.Name = runbook.Name;
            this.CreationTime = runbook.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = runbook.Properties.LastModifiedTime.ToLocalTime();
            this.Description = runbook.Properties.Description;
            // this.Tags = runbook.Tags != null ? runbook.Tags.Split(Constants.RunbookTagsSeparatorChar) : new string[] { };
            this.LogVerbose = runbook.Properties.LogVerbose;
            this.LogProgress = runbook.Properties.LogProgress;
            this.State = runbook.Properties.State;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Runbook"/> class.
        /// </summary>
        public Runbook()
        {
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        public DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified by.
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether log verbose is enabled.
        /// </summary>
        public bool LogVerbose { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether log progress is enabled.
        /// </summary>
        public bool LogProgress { get; set; }

        /// <summary>
        /// Gets or sets the state of runbook.
        /// </summary>
        public string State { get; set; }
    }
}

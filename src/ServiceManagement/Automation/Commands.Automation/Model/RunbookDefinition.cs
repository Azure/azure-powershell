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
    using AutomationManagement = WindowsAzure.Management.Automation;

    /// <summary>
    /// The Runbook Definition.
    /// </summary>
    public class RunbookDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RunbookDefinition"/> class.
        /// </summary>
        /// <param name="accountName">
        /// The runbook version.
        /// </param>
        /// <param name="runbook">
        /// The runbook version.
        /// </param>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <param name="slot">
        /// Slot published or draft.
        /// </param>
        public RunbookDefinition(string accountName, AutomationManagement.Models.Runbook runbook, string content, string slot)
        {
            Requires.Argument("runbook", runbook).NotNull();
            Requires.Argument("accountName", accountName).NotNull();
            Requires.Argument("slot", slot).NotNull();

            this.AutomationAccountName = accountName;
            this.Name = runbook.Name;
            this.Content = content;

            if (runbook.Properties == null) return;

            this.CreationTime = runbook.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = runbook.Properties.LastModifiedTime.ToLocalTime();
            this.Slot = slot;
            this.RunbookType = runbook.Properties.RunbookType;
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RunbookDefinition"/> class.
        /// </summary>
        public RunbookDefinition()
        {
        }

        /// <summary>
        /// Gets or sets the automaiton account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the slot (publised or draft) of runbook.
        /// </summary>
        public string Slot { get; set; }

        /// <summary>
        /// Gets or sets the runbook type.
        /// </summary>
        public string RunbookType { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        public DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the runbook version content.
        /// </summary>
        public string Content { get; set; }
    }
}

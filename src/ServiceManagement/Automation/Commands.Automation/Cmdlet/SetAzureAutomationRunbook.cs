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
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Sets an azure automation runbook's configuration values.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureAutomationRunbook", DefaultParameterSetName = ByRunbookName)]
    [OutputType(typeof(Runbook))]
    public class SetAzureAutomationRunbook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// The set runbook by runbook id parameter set.
        /// </summary>
        private const string ByRunbookId = "ByRunbookId";

        /// <summary>
        /// The set runbook by runbook name parameter set.
        /// </summary>
        private const string ByRunbookName = "ByRunbookName";

        /// <summary>
        /// Gets or sets the runbook Id
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook id.")]
        [Alias("RunbookId")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook name.")]
        [Alias("RunbookName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the runbook description.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The runbook description.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the runbook tags.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The runbook tags.")]
        public string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether debug logging should be turned on or off.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Indicate whether debug logging should be turned on or off.")]
        public bool? LogDebug { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether progress logging should be turned on or off.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Indicate whether progress logging should be turned on or off.")]
        public bool? LogProgress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether verbose logging should be turned on or off.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Indicate whether verbose logging should be turned on or off.")]
        public bool? LogVerbose { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            Runbook runbook;
            if (this.Id.HasValue)
            {
                // ByRunbookId
                runbook = this.AutomationClient.UpdateRunbook(
                    this.AutomationAccountName,
                    this.Id.Value,
                    this.Description,
                    this.Tags,
                    this.LogDebug,
                    this.LogProgress,
                    this.LogVerbose);
            }
            else
            {
                // ByRunbookName
                runbook = this.AutomationClient.UpdateRunbook(
                    this.AutomationAccountName,
                    this.Name,
                    this.Description,
                    this.Tags,
                    this.LogDebug,
                    this.LogProgress,
                    this.LogVerbose);
            }

            this.WriteObject(runbook);
        }
    }
}

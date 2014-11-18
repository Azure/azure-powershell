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
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation runbook definitions for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureAutomationRunbookDefinition", DefaultParameterSetName = ByRunbookName)]
    [OutputType(typeof(RunbookDefinition))]
    public class GetAzureAutomationRunbookDefinition : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// The get runbook defintion by runbook id parameter set.
        /// </summary>
        private const string ByRunbookId = "ByRunbookId";

        /// <summary>
        /// The get runbook defintion by runbook name parameter set.
        /// </summary>
        private const string ByRunbookName = "ByRunbookName";

        /// <summary>
        /// The get runbook defintion by runbook version id parameter set.
        /// </summary>
        private const string ByVersionId = "ByVersionId";

        /// <summary>
        /// The published slot.
        /// </summary>
        private const string Published = "Published";

        /// <summary>
        /// The draft slot.
        /// </summary>
        private const string Draft = "Draft";

        /// <summary>
        /// Gets or sets the runbook id
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook id.")]
        [Alias("RunbookId")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook name.")]
        [Alias("RunbookName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the runbook version id
        /// </summary>
        [Parameter(ParameterSetName = ByVersionId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook version id.")]
        public Guid? VersionId { get; set; }

        /// <summary>
        /// Gets or sets the runbook version type
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Returns the draft or the published runbook version only. If not set, return both.")]
        [ValidateSet(Published, Draft)]
        public string Slot { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            bool? isDraft = this.IsDraft();

            IEnumerable<RunbookDefinition> runbookDefinitions = null;
            if (this.Id.HasValue)
            {
                // ByRunbookId
                runbookDefinitions = this.AutomationClient.ListRunbookDefinitionsByRunbookId(
                    this.AutomationAccountName, this.Id.Value, isDraft);
            }
            else if (this.Name != null)
            {
                // ByRunbookName
                runbookDefinitions =
                    this.AutomationClient.ListRunbookDefinitionsByRunbookName(
                        this.AutomationAccountName, this.Name, isDraft);
            }
            else if (this.VersionId.HasValue)
            {
                // ByVersionId
                runbookDefinitions =
                    this.AutomationClient.ListRunbookDefinitionsByRunbookVersionId(
                        this.AutomationAccountName, this.VersionId.Value, isDraft);
            }

            this.WriteObject(runbookDefinitions, true);
        }

        /// <summary>
        /// Returns null if Slot is not provided; otherwise returns true if Slot is Draft.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool? IsDraft()
        {
            bool? isDraft = null;

            if (this.Slot != null)
            {
                isDraft = this.Slot == Draft;
            }

            return isDraft;
        }
    }
}

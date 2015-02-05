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
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using System.Globalization;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation runbook definitions for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureAutomationRunbookDefinition", DefaultParameterSetName = AutomationCmdletParameterSets.ByRunbookName)]
    [OutputType(typeof(RunbookDefinition))]
    public class GetAzureAutomationRunbookDefinition : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByRunbookName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook name.")]
        [Alias("RunbookName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the runbook version type
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Returns the draft or the published runbook version only. If not set, return both.")]
        [ValidateSet(Constants.Published, Constants.Draft)]
        public string Slot { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            bool? isDraft = this.IsDraft();

            // ByRunbookName
            var runbookDefinitions = this.AutomationClient.ListRunbookDefinitionsByRunbookName(this.AutomationAccountName, this.Name, isDraft);

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
                isDraft = (0 == String.Compare(this.Slot, Constants.Draft, CultureInfo.InvariantCulture,
                              CompareOptions.OrdinalIgnoreCase));
            }

            return isDraft;
        }
    }
}

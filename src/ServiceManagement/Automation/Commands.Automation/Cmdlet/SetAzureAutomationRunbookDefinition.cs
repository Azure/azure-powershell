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
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Sets an azure automation runbook definition.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureAutomationRunbookDefinition", DefaultParameterSetName = AutomationCmdletParameterSets.ByRunbookName)]
    [OutputType(typeof(RunbookDefinition))]
    public class SetAzureAutomationRunbookDefinition : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// True to overwrite the existing draft runbook definition; false otherwise.
        /// </summary>
        private bool overwriteExistingRunbookDefinition;

        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByRunbookName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook name.")]
        [ValidateNotNullOrEmpty]
        [Alias("RunbookName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the path of the updated runbook script
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, HelpMessage = "The path to the updated runbook script.")]
        [ValidateNotNullOrEmpty]
        [Alias("RunbookPath")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to overwrite the existing draft runbook definition.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates that the new draft runbook overwrites the existing draft, if one exists.")]
        public SwitchParameter Overwrite
        {
            get { return this.overwriteExistingRunbookDefinition; }
            set { this.overwriteExistingRunbookDefinition = value; }
        }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            // ByRunbookName
            var runbookDefinition = this.AutomationClient.UpdateRunbookDefinition(
                    this.AutomationAccountName, this.Name, this.ResolvePath(this.Path), this.Overwrite);

            this.WriteObject(runbookDefinition);
        }
    }
}

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

using System.Collections;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation schedules for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureAutomationRunbook", DefaultParameterSetName = AutomationCmdletParameterSets.ByRunbookName)]
    [OutputType(typeof (Runbook))]
    public class NewAzureAutomationRunbook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByRunbookName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook name.")]
        [Alias("RunbookName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the path of the runbook script
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByPath, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook file path.")]
        [Alias("RunbookPath")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the runbook description
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook description.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the runbook tags.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook tags.")]
        [Alias("Tag")]
        public string[] Tags { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            Runbook runbook = null;

            if (this.ParameterSetName == AutomationCmdletParameterSets.ByPath)
            {
                // ByRunbookPath
                runbook = this.AutomationClient.CreateRunbookByPath(
                    this.AutomationAccountName, this.ResolvePath(this.Path), this.Description, this.Tags);
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByRunbookName)
            {
                // ByRunbookName
                runbook = this.AutomationClient.CreateRunbookByName(
                    this.AutomationAccountName, this.Name, this.Description, this.Tags);
            }

            this.WriteObject(runbook);
        }
    }
}

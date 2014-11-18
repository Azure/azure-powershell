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

using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Creates an azure automation runbook.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureAutomationRunbook", DefaultParameterSetName = ByRunbookName)]
    [OutputType(typeof(Runbook))]
    public class NewAzureAutomationRunbook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// The create runbook by runbook path parameter set.
        /// </summary>
        private const string ByRunbookPath = "ByRunbookPath";

        /// <summary>
        /// The create runbook by runbook name parameter set.
        /// </summary>
        private const string ByRunbookName = "ByRunbookName";

        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook name.")]
        [Alias("RunbookName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the path of the runbook script
        /// </summary>
        [Parameter(ParameterSetName = ByRunbookPath, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook file path.")]
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
        public string[] Tags { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            Runbook runbook;

            if (this.Path != null)
            {
                // ByRunbookPath
                runbook = this.AutomationClient.CreateRunbookByPath(
                    this.AutomationAccountName, this.ResolvePath(this.Path), this.Description, this.Tags);
            }
            else
            {
                // ByRunbookName
                runbook = this.AutomationClient.CreateRunbookByName(
                    this.AutomationAccountName, this.Name, this.Description, this.Tags);
            }

            this.WriteObject(runbook);
        }
    }
}

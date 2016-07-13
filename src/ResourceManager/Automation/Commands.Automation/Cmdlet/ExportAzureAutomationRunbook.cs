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

using Microsoft.Azure.Commands.Automation.Common;
using System;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation runbook definitions for a given account.
    /// </summary>
    [Cmdlet(VerbsData.Export, "AzureRmAutomationRunbook", SupportsShouldProcess = true)]
    [OutputType(typeof(DirectoryInfo))]
    public class ExportAzureAutomationRunbook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByRunbookName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook name.")]
        [Alias("RunbookName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the runbook version type
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Specifies what version of the runbook, draft or published, should be returned.")]
        [ValidateSet(Constants.Published, Constants.Draft, IgnoreCase = true)]
        public string Slot { get; set; }

        /// <summary>
        /// Gets or sets the output folder for the configuration script.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The folder where the runbook should be placed.")]
        public string OutputFolder { get; set; }

        /// <summary>
        /// Gets or sets switch parameter to confirm overwriting of existing local runbook file.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Forces an overwrite of an existing local file with the same name.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            bool? isDraft = this.IsDraft();

            if (ShouldProcess(Name, VerbsData.Export))
            {
                var outputFolder = this.AutomationClient.ExportRunbook(this.ResourceGroupName,
                    this.AutomationAccountName, this.Name, isDraft, this.OutputFolder, this.Force.IsPresent);

                this.WriteObject(outputFolder, true);
            }
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

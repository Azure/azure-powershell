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
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets configuration script for given configuration name and account name.
    /// </summary>
    [Cmdlet(VerbsData.Export, "AzureRmAutomationDscConfiguration", SupportsShouldProcess = true,
        DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(DirectoryInfo))]
    public class ExportAzureAutomationDscConfiguration : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// True to overwrite the existing dsc configuration; false otherwise.
        /// </summary>        
        private bool overwriteExistingFile;

        /// <summary> 
        /// Gets or sets the configfuration name. 
        /// </summary> 
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The dsc configuration name.")]
        [Alias("ConfigurationName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the configuration version type
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Returns the draft or the published configuration version only. If not set, return published.")]
        [ValidateSet(Constants.Published, Constants.Draft)]
        public string Slot { get; set; }

        /// <summary>
        /// Gets or sets the output folder for the configuration script.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The folder where configuration script should be placed.")]
        public string OutputFolder { get; set; }

        /// <summary>
        /// Gets or sets switch parameter to confirm overwriting of existing configuration script.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Forces an overwrite of an existing local file with the same name.")]
        public SwitchParameter Force
        {
            get { return this.overwriteExistingFile; }
            set { this.overwriteExistingFile = value; }
        }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            bool? isDraft = this.IsDraft();
            if (ShouldProcess(Name, VerbsData.Export))
            {
                var ret = this.AutomationClient.GetConfigurationContent(this.ResourceGroupName,
                    this.AutomationAccountName, this.Name, isDraft, OutputFolder, this.Force);

                this.WriteObject(ret, true);
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
                isDraft = (0 == string.Compare(this.Slot, Constants.Draft, CultureInfo.InvariantCulture,
                              CompareOptions.OrdinalIgnoreCase));
            }

            return isDraft;
        }
    }
}
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

using Microsoft.Azure.Commands.Automation.Model;
using System.Collections;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Imports dsc configuration script
    /// </summary>
    [Cmdlet(VerbsData.Import, "AzureRmAutomationDscConfiguration", SupportsShouldProcess = true)]
    [OutputType(typeof(DscConfiguration))]
    public class ImportAzureAutomationDscConfiguration : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// True to overwrite the existing configuration; false otherwise.
        /// </summary>        
        private bool overwriteExistingConfiguration;

        /// <summary>
        /// True to publish the configuration; false otherwise.
        /// </summary>        
        private bool publishConfiguration;

        /// <summary>
        /// Gets or sets the source path.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Path to the configuration script .ps1 to import.")]
        [Alias("Path")]
        [ValidateNotNullOrEmpty]
        public string SourcePath { get; set; }

        /// <summary>
        /// Gets or sets the configuration tags.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The dsc configuration tags.")]
        [Alias("Tag")]
        public IDictionary Tags { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The description of the configuration being imported.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter to publish the configuration
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Import the configuration in published state.")]
        public SwitchParameter Published
        {
            get { return this.publishConfiguration; }
            set { this.publishConfiguration = value; }
        }

        /// <summary>
        /// Gets or sets switch parameter to confirm overwriting of existing configurations.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Forces the command to overwrite an existing configuration.")]
        public SwitchParameter Force
        {
            get { return this.overwriteExistingConfiguration; }
            set { this.overwriteExistingConfiguration = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether verbose logging should be turned on or off.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicate whether verbose logging should be turned on or off.")]
        public bool? LogVerbose { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(SourcePath, VerbsData.Import))
            {
                var configuration = this.AutomationClient.CreateConfiguration(
                    this.ResourceGroupName,
                    this.AutomationAccountName,
                    this.SourcePath,
                    this.Tags,
                    this.Description,
                    this.LogVerbose,
                    this.Published,
                    this.Force);

                this.WriteObject(configuration);
            }
        }
    }
}

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
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Imports dsc node configuration script
    /// </summary>
    [Cmdlet(VerbsData.Import, "AzureRmAutomationDscNodeConfiguration", SupportsShouldProcess = true)]
    [OutputType(typeof(NodeConfiguration))]
    public class ImportAzureAutomationDscNodeConfiguration : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// True to overwrite the existing configuration; false otherwise.
        /// </summary>        
        private bool overwriteExistingConfiguration;

        /// <summary>
        /// Gets or sets the source path.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Path to the node configuration .mof to import.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the configuration name for the node configuration.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the DSC Configuration to import the Node Configuration under. All Node Configurations in Azure Automation must exist under a Configuration. The name of the Configuration will become the namespace of the imported Node Configuration, in the form of 'ConfigurationName.MofFileName'")]
        public string ConfigurationName { get; set; }


        /// <summary>
        /// Gets or sets switch parameter to confirm overwriting of existing configurations.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Forces the command to overwrite an existing Node Configuration.")]
        public SwitchParameter Force
        {
            get { return this.overwriteExistingConfiguration; }
            set { this.overwriteExistingConfiguration = value; }
        }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Path, VerbsData.Import))
            {
                var nodeConfiguration = this.AutomationClient.CreateNodeConfiguration(
                    this.ResourceGroupName,
                    this.AutomationAccountName,
                    this.Path,
                    this.ConfigurationName,
                    this.Force);

                this.WriteObject(nodeConfiguration);
            }
        }
    }
}

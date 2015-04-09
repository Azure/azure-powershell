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

using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Imports dsc configuration script
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureAutomationDscConfiguration")]
    [OutputType(typeof(DscConfiguration))]
    public class NewAzureAutomationDscConfiguration : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The automation account name.")]
        [ValidateNotNullOrEmpty]
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the configuration name.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The configuration name.")]
        public string ConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets the source path.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The source path for importing the configuration script.")]
        public string SourcePath { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The description of the configuration being imported.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter to 
        /// </summary>
        [Parameter(Position = 5, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Import the configuration in published state.")]
        public SwitchParameter Published { get; set; }

        /// <summary>
        /// Gets or sets switch parameter to confirm overwriting of existing configurations.
        /// </summary>
        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Overwrites an existing configuration with same name.")]
        public SwitchParameter Overwrite { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether verbose logging should be turned on or off.
        /// </summary>
        [Parameter(Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicate whether verbose logging should be turned on or off.")]
        public bool? LogVerbose { get; set; }
        
        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            var configuration = this.AutomationClient.CreateConfiguration(this.ResourceGroupName, this.AutomationAccountName, this.ConfigurationName, this.SourcePath, this.Description, this.LogVerbose );
            this.WriteObject(configuration);
        }
    }
}

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
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation dsc onboarding meta configuration information for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureAutomationDscOnboardingMetaconfig")]
    [OutputType(typeof(DscOnboardingMetaconfig))]
    public class GetAzureAutomationDscOnboardingMetaconfig : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// True to overwrite the existing meta.mof; false otherwise.
        /// </summary>        
        private bool overwriteExistingFile;
        
        /// <summary>
        /// Gets or sets the output folder for the metaconfig mof files
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The folder where metaconfig mof files to be placed.")]
        public string OutputFolder { get; set; }

        /// <summary>
        /// Gets or sets the list of computer names
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The names of computers. If not specified Localhost will be used.")]
        [Alias("ComputerName")]
        public string[] ComputerNames { get; set; }

        /// <summary>
        /// Gets or sets switch parameter to confirm overwriting of existing configurations.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Overwrites an existing configuration with same name.")]
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
            var ret = 
                this.AutomationClient.GetDscMetaConfig(this.ResourceGroupName, this.AutomationAccountName, this.OutputFolder, this.ComputerNames, this.Force);

            this.WriteObject(ret, true);
        }
    }
}

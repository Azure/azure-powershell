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
using Microsoft.Azure.Commands.Automation.Properties;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation dsc onboarding meta configuration information for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationDscOnboardingMetaconfig", SupportsShouldProcess = true)]
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
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The folder where metaconfig mof folder to be placed.")]
        public string OutputFolder { get; set; }

        /// <summary>
        /// Gets or sets the list of computer names
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The names of computers to generate a metaconfig mof for. If not specified localhost will be used.")]
        public string[] ComputerName { get; set; }

        /// <summary>
        /// Gets or sets switch parameter to confirm overwriting of existing configurations.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Forces the command to run without asking for user confirmation and overwrites an existing metaconfiguration with same name.")]
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
            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(CultureInfo.CurrentCulture, Resources.DscMetaMofHasKeysWarning),
                string.Format(CultureInfo.CurrentCulture, Resources.DscMetaMofHasKeysDescription),
                this.OutputFolder,
                () =>
                {
                    var ret = this.AutomationClient.GetDscMetaConfig(this.ResourceGroupName, this.AutomationAccountName, this.OutputFolder, this.ComputerName, this.Force);
                    this.WriteObject(ret, true);
                });
        }
    }
}

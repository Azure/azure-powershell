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
using Microsoft.Azure.Commands.Automation.Model;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Sets (updates) a Package in a Runtime Environment for automation.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationRuntimeEnvironmentPackage", DefaultParameterSetName = AutomationCmdletParameterSets.ByName, SupportsShouldProcess = true)]
    [OutputType(typeof(RuntimeEnvironmentPackage))]
    public class SetAzureAutomationRuntimeEnvironmentPackage : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the runtime environment name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The runtime environment name.")]
        [ValidateNotNullOrEmpty]
        public string RuntimeEnvironmentName { get; set; }

        /// <summary>
        /// Gets or sets the package name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The package name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the content URI.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The URI to the package content (e.g., a blob storage URL or PyPI/PowerShell Gallery URL).")]
        public string ContentUri { get; set; }

        /// <summary>
        /// Gets or sets the content version.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The version of the package content.")]
        public string ContentVersion { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            if (ShouldProcess(this.Name, "Update Runtime Environment Package"))
            {
                var updatedPackage = this.AutomationClient.UpdateRuntimeEnvironmentPackage(
                    this.ResourceGroupName,
                    this.AutomationAccountName,
                    this.RuntimeEnvironmentName,
                    this.Name,
                    this.ContentUri,
                    this.ContentVersion);

                this.WriteObject(updatedPackage);
            }
        }
    }
}

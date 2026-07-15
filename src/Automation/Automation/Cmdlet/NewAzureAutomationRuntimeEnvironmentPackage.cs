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
    /// Create a new Package in a Runtime Environment for automation.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationRuntimeEnvironmentPackage", SupportsShouldProcess = true)]
    [OutputType(typeof(RuntimeEnvironmentPackage))]
    public class NewAzureAutomationRuntimeEnvironmentPackage : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the runtime environment name.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The runtime environment name.")]
        [ValidateNotNullOrEmpty]
        public string RuntimeEnvironmentName { get; set; }

        /// <summary>
        /// Gets or sets the package name.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The package name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the content URI.
        /// </summary>
        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The URI to the package content (e.g., a blob storage URL or PyPI/PowerShell Gallery URL).")]
        [ValidateNotNullOrEmpty]
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
            var createdPackage = this.AutomationClient.CreateRuntimeEnvironmentPackage(
                this.ResourceGroupName,
                this.AutomationAccountName,
                this.RuntimeEnvironmentName,
                this.Name,
                this.ContentUri,
                this.ContentVersion);

            this.WriteObject(createdPackage);
        }
    }
}

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
using System.Security;
using System.Security.Permissions;
using System.Globalization;
using Microsoft.Azure.Commands.Automation.Properties;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Updates an azure automation source control for a given account.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationSourceControl",
        SupportsShouldProcess = true)]
    [OutputType(typeof(SourceControl))]
    public class UpdateAzureAutomationSourceControl : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the source control Name.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The source control name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Sets the source control AccessToken.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The source control access token.")]
        [ValidateNotNullOrEmpty]
        public SecureString AccessToken { get; set; }

        /// <summary>
        /// Sets the source control FolderPath.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The source control folder path.")]
        [ValidateNotNullOrEmpty]
        public string FolderPath { get; set; }

        /// <summary>
        /// Sets the source control Branch.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The source control branch.")]
        [ValidateNotNullOrEmpty]
        public string Branch { get; set; }

        /// <summary>
        /// Sets the source control Branch.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The source control description.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the autoSync switch.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The autoSync property for the source control.")]
        public bool? AutoSync { get; set; }

        /// <summary>
        /// Gets or sets the variable encrypted Property.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The publishRunbook property of the source control.")]
        public bool? PublishRunbook { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            string resource = string.Format(CultureInfo.CurrentCulture, Resources.SourceControlUpdateAction);
            if (ShouldProcess(Name, resource))
            {
                var sourceControl = this.AutomationClient.UpdateSourceControl(
                    this.ResourceGroupName,
                    this.AutomationAccountName,
                    this.Name,
                    this.Description,
                    this.AccessToken,
                    this.Branch,
                    this.FolderPath,
                    this.PublishRunbook,
                    this.AutoSync);

                this.WriteObject(sourceControl);
            }
        }
    }
}

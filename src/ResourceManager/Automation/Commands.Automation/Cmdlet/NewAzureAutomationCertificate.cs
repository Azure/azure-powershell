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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Create a new Certificate for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAutomationCertificate", DefaultParameterSetName = AutomationCmdletParameterSets.ByCertificateName)]
    [OutputType(typeof(CertificateInfo))]
    public class NewAzureAutomationCertificate : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the certificate name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByCertificateName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The certificate name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the certificate description.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByCertificateName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The certificate description.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the certificate password.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByCertificateName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The certificate password.")]
        public SecureString Password { get; set; }

        /// <summary>
        /// Gets or sets the certificate path.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByCertificateName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The certificate file path.")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the certificate exportable Property.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The exportable property of the certificate.")]
        public SwitchParameter Exportable { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {

            var createdCertificate = this.AutomationClient.CreateCertificate(this.ResourceGroupName, this.AutomationAccountName, this.Name, this.ResolvePath(this.Path), this.Password, this.Description, this.Exportable.IsPresent);

            this.WriteObject(createdCertificate);
        }
    }
}

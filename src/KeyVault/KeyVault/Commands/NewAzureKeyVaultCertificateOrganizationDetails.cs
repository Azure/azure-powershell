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

using Microsoft.Azure.Commands.KeyVault.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    /// <summary>
    /// New-AzureKeyVaultOrganizationDetails creates an in-memory organization details object
    /// </summary>
    [Cmdlet(VerbsCommon.New, CmdletNoun.AzureKeyVaultCertificateOrganizationDetails,
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(KeyVaultCertificateOrganizationDetails))]
    public class NewAzureKeyVaultCertificateOrganizationDetails : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions
        /// <summary>
        /// Id
        /// </summary>
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the identifier for the organization.")]
        public string Id { get; set; }

        /// <summary>
        /// AdministratorDetails
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the details of the administrators for the organization.")]
        public List<KeyVaultCertificateAdministratorDetails> AdministratorDetails { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(string.Empty, Properties.Resources.CreateCertificateAdministrator))
            {
                var organizationDetails = new KeyVaultCertificateOrganizationDetails
                {
                    Id = Id,
                    AdministratorDetails = AdministratorDetails,
                };

                this.WriteObject(organizationDetails);
            }
        }
    }
}

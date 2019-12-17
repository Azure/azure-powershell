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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    /// <summary>
    /// New-AzureKeyVaultCertificateAdministratorDetails creates an in-memory administrator details object
    /// </summary>
    [Cmdlet(VerbsCommon.New, CmdletNoun.AzureKeyVaultCertificateAdministratorDetails,
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(KeyVaultCertificateAdministratorDetails))]
    public class NewAzureKeyVaultCertificateAdministratorDetails : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// FirstName
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the first name of the administrator.")]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the last name of the administrator.")]
        public string LastName { get; set; }

        /// <summary>
        /// EmailAddress
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the email address of the administrator.")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the phone number of the administrator.")]
        public string PhoneNumber { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(string.Empty, Properties.Resources.CreateCertificateAdministrator))
            {
                var adminDetails = new KeyVaultCertificateAdministratorDetails
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    EmailAddress = EmailAddress,
                    PhoneNumber = PhoneNumber,
                };

                this.WriteObject(adminDetails);
            }
        }
    }
}

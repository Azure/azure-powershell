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
using Microsoft.Azure.KeyVault.Models;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Removes the certificate operation for the selected certificate
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, CmdletNoun.AzureKeyVaultCertificateOperation,
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.High,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(KeyVaultCertificateOperation))]
    public class RemoveAzureKeyVaultCertificateOperation : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Name
        /// </summary>       
        [Parameter(Mandatory = true,
                   Position = 1,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.CertificateName)]
        public string Name { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// PassThru
        /// </summary>
        [Parameter(HelpMessage = "Cmdlet does not return an object by default. If this switch is specified, the cmdlet returns the certificate operation object that was deleted.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            CertificateOperation certificateOperation = null;

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Are you sure you want to remove certificate operation for '{0}'?",
                    Name),
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Remove certificate operation for '{0}'",
                    Name),
                Name,
                () => { certificateOperation = this.DataServiceClient.DeleteCertificateOperation(VaultName, Name); });

            if (PassThru.IsPresent)
            {
                var kvCertificateOperation = KeyVaultCertificateOperation.FromCertificateOperation(certificateOperation);
                this.WriteObject(kvCertificateOperation);
            }
        }
    }
}

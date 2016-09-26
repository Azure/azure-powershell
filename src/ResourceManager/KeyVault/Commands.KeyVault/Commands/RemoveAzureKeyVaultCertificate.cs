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

using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Models;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// The Remove-AzureKeyVaultCertificate cmdlet deletes a certificate in an Azure Key Vault. 
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, CmdletNoun.AzureKeyVaultCertificate,
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.High,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(KeyVaultCertificate))]
    public class RemoveAzureKeyVaultCertificate : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the name of the vault to which this cmdlet adds the certificate.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Name
        /// </summary>       
        [Parameter(Mandatory = true,
                   Position = 1,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the name of the certificate in key vault.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(HelpMessage = "Cmdlet does not return an object by default. If this switch is specified, the cmdlet returns the certificate object that was deleted.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            CertificateBundle certBundle = null;

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    KeyVaultProperties.Resources.RemoveCertWarning,
                    Name),
                string.Format(
                    CultureInfo.InvariantCulture,
                    KeyVaultProperties.Resources.RemoveCertWhatIfMessage,
                    Name),
                Name,
                () => { certBundle = this.DataServiceClient.DeleteCertificate(VaultName, Name); });

            if (PassThru.IsPresent)
            {
                var certificate = KeyVaultCertificate.FromCertificateBundle(certBundle);
                this.WriteObject(certificate);
            }
        }
    }
}

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

using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Models;
using System.Globalization;

namespace Microsoft.Azure.Commands.KeyVault
{
    [Cmdlet(VerbsCommon.Remove, CmdletNoun.AzureKeyVaultCertificateIssuer,
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.High,
        DefaultParameterSetName = DefaultParameterSet,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(KeyVaultCertificateIssuer))]
    public class RemoveAzureKeyVaultCertificateIssuer : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string DefaultParameterSet = "Default";

        #endregion

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
        [Alias(Constants.IssuerName)]
        public string Name { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// PassThru
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Cmdlet does not return an object by default. If this switch is specified, the cmdlet returns the issuer object that was deleted.")]
        public SwitchParameter PassThru { get; set; }

        #endregion
        protected override void ProcessRecord()
        {
            KeyVaultCertificateIssuer issuer = null;

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Are you sure you want to remove certificate issuer '{0}'?",
                    Name),
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Remove certificate issuer '{0}'",
                    Name),
                Name,
                () => { issuer = KeyVaultCertificateIssuer.FromIssuer(this.DataServiceClient.DeleteCertificateIssuer(VaultName, Name)); });

            if (PassThru)
            {
                WriteObject(issuer);
            }
        }
    }
}

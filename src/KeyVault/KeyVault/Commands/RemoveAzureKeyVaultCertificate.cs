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
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// The Remove-AzKeyVaultCertificate cmdlet deletes a certificate in an Azure Key Vault. 
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultCertificate",SupportsShouldProcess = true,DefaultParameterSetName = ByVaultNameAndNameParameterSet)]
    [OutputType(typeof(PSDeletedKeyVaultCertificate))]
    public class RemoveAzureKeyVaultCertificate : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByVaultNameAndNameParameterSet = "ByVaultNameAndName";
        private const string ByObjectParameterSet = "ByObject";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByVaultNameAndNameParameterSet,
                   HelpMessage = "Specifies the name of the vault to which this cmdlet adds the certificate.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Name
        /// </summary>       
        [Parameter(Mandatory = true,
                   Position = 1,
                   ParameterSetName = ByVaultNameAndNameParameterSet,
                   HelpMessage = "Specifies the name of the certificate in key vault.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Vault Object
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByObjectParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "Certificate Object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultCertificateIdentityItem InputObject { get; set; }

        /// <summary>
        /// If present, operate on the deleted entity.
        /// </summary>
        [Parameter(Mandatory = false,
                    HelpMessage = "Permanently remove the previously deleted certificate.")]
        public SwitchParameter InRemovedState { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter( Mandatory = false,
                    HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter( Mandatory = false,
                    HelpMessage = "Cmdlet does not return an object by default. If this switch is specified, the cmdlet returns the certificate object that was deleted.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                Name = InputObject.Name;
            }

            if ( InRemovedState.IsPresent )
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.RemoveDeletedCertificateWarning,
                        Name ),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.RemoveDeletedCertificateWhatIfMessage,
                        Name ),
                    Name,
                    ( ) => { DataServiceClient.PurgeCertificate( VaultName, Name ); } );

                return;
            }

            PSDeletedKeyVaultCertificate certBundle = null;

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.RemoveCertWarning,
                    Name),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.RemoveCertWhatIfMessage,
                    Name),
                Name,
                () => { certBundle = this.DataServiceClient.DeleteCertificate(VaultName, Name); });

            if (PassThru.IsPresent)
            {
                WriteObject( certBundle );
            }
        }
    }
}

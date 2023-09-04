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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.KeyVault.Models;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Removes the certificate operation for the selected certificate
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultCertificateOperation",SupportsShouldProcess = true)]
    [OutputType(typeof(PSKeyVaultCertificateOperation))]
    public class RemoveAzureKeyVaultCertificateOperation : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string DefaultParameterSet = "Default";
        private const string InputObjectParameterSet = "InputObject";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = DefaultParameterSet,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Name
        /// </summary>       
        [Parameter(Mandatory = true,
                   Position = 1,
                   ParameterSetName = DefaultParameterSet,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.CertificateName)]
        public string Name { get; set; }

        /// <summary>
        /// Operation object
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = InputObjectParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "Operation object")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultCertificateOperation InputObject { get; set; }

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

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
                Name = InputObject.Name;
            }

            PSKeyVaultCertificateOperation certificateOperation = null;

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
                this.WriteObject(certificateOperation);
            }
        }
    }
}

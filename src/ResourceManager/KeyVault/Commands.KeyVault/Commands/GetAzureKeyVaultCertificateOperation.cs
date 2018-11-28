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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Gets the status of the certificate operation
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultCertificateOperation",DefaultParameterSetName = ByNameParameterSet)]
    [OutputType(typeof(PSKeyVaultCertificateOperation))]
    public class GetAzureKeyVaultCertificateOperation : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByNameParameterSet = "ByName";
        private const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByNameParameterSet,
                   Position = 0,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Name
        /// </summary>       
        [Parameter(Mandatory = true,
                   ParameterSetName = ByNameParameterSet,
                   Position = 1,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate operation from vault name, currently selected environment and certificate name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.CertificateName)]
        public string Name { get; set; }

        /// <summary>
        /// Certificate Object
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByInputObjectParameterSet,
                   Position = 0,
                   ValueFromPipeline = true,
                   HelpMessage = "Certificate Object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultCertificateIdentityItem InputObject { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName.ToString();
                Name = InputObject.Name.ToString();
            }

            var certificateOperation = this.DataServiceClient.GetCertificateOperation(VaultName, Name);
            if (certificateOperation != null)
            {
                certificateOperation.VaultName = VaultName;
                certificateOperation.Name = Name;
            }
            this.WriteObject(certificateOperation);
        }
    }
}

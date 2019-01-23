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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    /// <summary>
    /// Get-AzKeyVaultCertificatePolicy gets the policy for a certificate object in key vault.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultCertificatePolicy",        DefaultParameterSetName = ByVaultAndCertNameParameterSet)]
    [OutputType(typeof(PSKeyVaultCertificatePolicy))]
    public class GetAzureKeyVaultCertificatePolicy : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByVaultAndCertNameParameterSet = "VaultAndCertName";
        private const string ByInputObjectParameterSet = "InputObject";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByVaultAndCertNameParameterSet,
                   Position = 0,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Name
        /// </summary>       
        [Parameter(Mandatory = true,
                   ParameterSetName = ByVaultAndCertNameParameterSet,
                   Position = 1,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate policy from vault name, currently selected environment and certificate name.")]
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
            PSKeyVaultCertificatePolicy certificatePolicy;

            if (InputObject != null)
            {
                VaultName = InputObject.VaultName.ToString();
                Name = InputObject.Name.ToString();
            }

            try
            {
                certificatePolicy = this.DataServiceClient.GetCertificatePolicy(this.VaultName, this.Name);
            }
            catch (KeyVaultErrorException exception)
            {
                if (exception.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }

                certificatePolicy = null;
            }

            if (certificatePolicy != null)
            {
                this.WriteObject(certificatePolicy);
            }
        }
    }
}

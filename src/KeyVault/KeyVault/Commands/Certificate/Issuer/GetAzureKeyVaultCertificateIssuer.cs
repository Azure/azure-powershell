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
using System.Collections.Generic;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// The Get-AzKeyVaultCertificate cmdlet gets the certificates in an Azure Key Vault or the current version of the certificate.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultCertificateIssuer",        DefaultParameterSetName = ByNameParameterSet)]
    [OutputType(typeof(PSKeyVaultCertificateIssuerIdentityItem), typeof(PSKeyVaultCertificateIssuer))]
    public class GetAzureKeyVaultCertificateIssuer : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByNameParameterSet = "ByName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            Position = 0,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Vault object
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByInputObjectParameterSet,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "KeyVault object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        /// <summary>
        /// Vault resource id
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByResourceIdParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "KeyVault Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            HelpMessage = "Issuer name. Cmdlet constructs the FQDN of a certificate issuer from vault name, currently selected environment and issuer name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.IssuerName)]
        [SupportsWildcards]
        public string Name { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName.ToString();
            }
            else if (!string.IsNullOrEmpty(ResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                VaultName = parsedResourceId.ResourceName;
            }

            if (string.IsNullOrEmpty(Name) || WildcardPattern.ContainsWildcardCharacters(Name))
            {
                GetAndWriteCertificateIssuers(VaultName, Name);
            }
            else
            {
                var issuer = this.DataServiceClient.GetCertificateIssuer(VaultName, Name);
                if (issuer != null)
                {
                    issuer.VaultName = VaultName;
                }
                this.WriteObject(issuer);
            }
        }

        private void GetAndWriteCertificateIssuers(string vaultName, string name)
        {
            KeyVaultObjectFilterOptions options = new KeyVaultObjectFilterOptions
            {
                VaultName = VaultName,
                NextLink = null,
            };

            do
            {
                var pageResults = this.DataServiceClient.GetCertificateIssuers(options);
                var psPageResults = new List<PSKeyVaultCertificateIssuerIdentityItem>();
                foreach (var page in pageResults)
                {
                    page.VaultName = VaultName;
                    psPageResults.Add(page);
                }
                WriteObject(KVSubResourceWildcardFilter(name, psPageResults), true);
            } while (!string.IsNullOrEmpty(options.NextLink));
        }
    }
}

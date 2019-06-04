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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// The Get-AzKeyVaultCertificate cmdlet gets the certificates in an Azure Key Vault or the current version of the certificate.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultCertificate",        DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyVaultCertificateIdentityItem), typeof(PSKeyVaultCertificate), typeof(PSDeletedKeyVaultCertificate), typeof(PSDeletedKeyVaultCertificateIdentityItem))]
    public class GetAzureKeyVaultCertificate : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByVaultNameParameterSet = "ByName";
        private const string ByCertificateNameandVersionParameterSet = "ByCertificateNameAndVersion";
        private const string ByCertificateVersionsParameterSet = "ByCertificateAllVersions";

        private const string InputObjectByVaultNameParameterSet = "ByNameInputObject";
        private const string InputObjectByCertificateNameandVersionParameterSet = "ByCertificateNameAndVersionInputObject";
        private const string InputObjectByCertificateVersionsParameterSet = "ByCertificateAllVersionsInputObject";

        private const string ResourceIdByVaultNameParameterSet = "ByNameResourceId";
        private const string ResourceIdByCertificateNameandVersionParameterSet = "ByCertificateNameAndVersionResourceId";
        private const string ResourceIdByCertificateVersionsParameterSet = "ByCertificateAllVersionsResourceId";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByVaultNameParameterSet,
                   Position = 0,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
                   ParameterSetName = ByCertificateNameandVersionParameterSet,
                   Position = 0,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [Parameter(Mandatory = true,
                   ParameterSetName = ByCertificateVersionsParameterSet,
                   Position = 0,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        [Parameter(Mandatory = true,
                   ParameterSetName = InputObjectByVaultNameParameterSet,
                   Position = 0,
                   ValueFromPipeline = true,
                   HelpMessage = "KeyVault object.")]
        [Parameter(Mandatory = true,
                   ParameterSetName = InputObjectByCertificateNameandVersionParameterSet,
                   Position = 0,
                   ValueFromPipeline = true,
                   HelpMessage = "KeyVault object.")]
        [Parameter(Mandatory = true,
                   ParameterSetName = InputObjectByCertificateVersionsParameterSet,
                   Position = 0,
                   ValueFromPipeline = true,
                   HelpMessage = "KeyVault object.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        [Parameter(Mandatory = true,
                   ParameterSetName = ResourceIdByVaultNameParameterSet,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "KeyVault Resource Id.")]
        [Parameter(Mandatory = true,
                   ParameterSetName = ResourceIdByCertificateNameandVersionParameterSet,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "KeyVault Resource Id.")]
        [Parameter(Mandatory = true,
                   ParameterSetName = ResourceIdByCertificateVersionsParameterSet,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "KeyVault Resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Name
        /// </summary>       
        [Parameter(Mandatory = false,
                   Position = 1,
                   ParameterSetName = ByVaultNameParameterSet,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [Parameter(Mandatory = false,
                   Position = 1,
                   ParameterSetName = InputObjectByVaultNameParameterSet,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [Parameter(Mandatory = false,
                   Position = 1,
                   ParameterSetName = ResourceIdByVaultNameParameterSet,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [Parameter(Mandatory = true,
                   Position = 1,
                   ParameterSetName = ByCertificateNameandVersionParameterSet,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [Parameter(Mandatory = true,
                   Position = 1,
                   ParameterSetName = InputObjectByCertificateNameandVersionParameterSet,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [Parameter(Mandatory = true,
                   Position = 1,
                   ParameterSetName = ResourceIdByCertificateNameandVersionParameterSet,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [Parameter(Mandatory = true,
                   Position = 1,
                   ParameterSetName = ByCertificateVersionsParameterSet,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name." )]
        [Parameter(Mandatory = true,
                   Position = 1,
                   ParameterSetName = InputObjectByCertificateVersionsParameterSet,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [Parameter(Mandatory = true,
                   Position = 1,
                   ParameterSetName = ResourceIdByCertificateVersionsParameterSet,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.CertificateName)]
        [SupportsWildcards]
        public string Name { get; set; }

        /// <summary>
        /// Certificate version.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByCertificateNameandVersionParameterSet,
            Position = 2,
            HelpMessage = "Specifies the version of the certificate in key vault.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByCertificateNameandVersionParameterSet,
            Position = 2,
            HelpMessage = "Specifies the version of the certificate in key vault.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByCertificateNameandVersionParameterSet,
            Position = 2,
            HelpMessage = "Specifies the version of the certificate in key vault.")]
        [Alias("CertificateVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ByCertificateVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the certificate in the output.")]
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectByCertificateVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the certificate in the output.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdByCertificateVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the certificate in the output.")]
        public SwitchParameter IncludeVersions { get; set; }

        /// <summary>
        /// Switch specifying whether to apply the command to certificates in a deleted state.
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ByVaultNameParameterSet,
                   HelpMessage = "Specifies whether to show the previously deleted certificates in the output." )]
        [Parameter(Mandatory = false,
                   ParameterSetName = InputObjectByVaultNameParameterSet,
                   HelpMessage = "Specifies whether to show the previously deleted certificates in the output.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ResourceIdByVaultNameParameterSet,
                   HelpMessage = "Specifies whether to show the previously deleted certificates in the output.")]
        public SwitchParameter InRemovedState { get; set; }

        /// <summary>
        /// Switch specifying whether to include the pending certificates in the enumeration.
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ByVaultNameParameterSet,
                   HelpMessage = "Specifies whether to include the pending certificates in the output.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = InputObjectByVaultNameParameterSet,
                   HelpMessage = "Specifies whether to include the pending certificates in the output.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ResourceIdByVaultNameParameterSet,
                   HelpMessage = "Specifies whether to include the pending certificates in the output.")]
        public SwitchParameter IncludePending { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            PSKeyVaultCertificate certBundle;

            if (InputObject != null)
            {
                VaultName = InputObject.VaultName.ToString();
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                VaultName = resourceIdentifier.ResourceName;
            }

            if (!string.IsNullOrEmpty(Version))
            {
                certBundle = this.DataServiceClient.GetCertificate(VaultName, Name, Version);
                this.WriteObject(certBundle);
            }
            else if (IncludeVersions)
            {
                certBundle = this.DataServiceClient.GetCertificate(VaultName, Name, string.Empty);
                if (certBundle != null)
                {
                    WriteObject(certBundle);
                    GetAndWriteCertificatesVersions(VaultName, Name, certBundle.Version);
                }
            }
            else if (InRemovedState)
            {
                if (string.IsNullOrEmpty(Name) || WildcardPattern.ContainsWildcardCharacters(Name))
                {
                    GetAndWriteDeletedCertificates(VaultName, Name);
                }
                else
                {
                    PSDeletedKeyVaultCertificate deletedCert = DataServiceClient.GetDeletedCertificate(VaultName, Name);
                    WriteObject(deletedCert);
                }
            }
            else if (!string.IsNullOrEmpty(Name) && !WildcardPattern.ContainsWildcardCharacters(Name))
            {
                certBundle = this.DataServiceClient.GetCertificate(VaultName, Name, string.Empty);
                this.WriteObject(certBundle);
            }
            else
            {
                GetAndWriteCertificates(VaultName, Name);
            }
        }

        private void GetAndWriteCertificates(string vaultName, string name)
        {
            var options = new KeyVaultCertificateFilterOptions
            {
                VaultName = VaultName,
                NextLink = null,
                IncludePending = IncludePending
            };

            do
            {
                var pageResults = DataServiceClient.GetCertificates(options);
                WriteObject(KVSubResourceWildcardFilter(name, pageResults), true);
            } while (!string.IsNullOrEmpty(options.NextLink));
        }

        private void GetAndWriteCertificatesVersions(string vaultName, string name, string currentCertificateVersion)
        {
            KeyVaultObjectFilterOptions options = new KeyVaultObjectFilterOptions
            {
                VaultName = vaultName,
                NextLink = null,
                Name = name
            };

            do
            {
                var pageResults = DataServiceClient.GetCertificateVersions(options).Where(k => k.Version != currentCertificateVersion);
                WriteObject(pageResults, true);
            } while (!string.IsNullOrEmpty(options.NextLink));
        }

        private void GetAndWriteDeletedCertificates( string vaultName, string name )
        {
            var options = new KeyVaultCertificateFilterOptions
            {
                VaultName = VaultName,
                NextLink = null,
                IncludePending = IncludePending
            };

            do
            {
                var pageResults = DataServiceClient.GetDeletedCertificates(options);
                WriteObject(KVSubResourceWildcardFilter(name, pageResults), true );
            } while ( !string.IsNullOrEmpty( options.NextLink ) );
        }
    }
}

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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Models;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// The Get-AzureKeyVaultCertificate cmdlet gets the certificates in an Azure Key Vault or the current version of the certificate.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, CmdletNoun.AzureKeyVaultCertificate,        
        DefaultParameterSetName = ByVaultNameParameterSet,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(List<CertificateIdentityItem>), typeof(KeyVaultCertificate))]
    public class GetAzureKeyVaultCertificate : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByCertificateNameParameterSet = "ByCertificateName";
        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string ByCertificateVersionsParameterSet = "ByCertificateVersions";

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
                   ParameterSetName = ByCertificateNameParameterSet,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [Parameter(Mandatory = true,
                   Position = 1,
                   ValueFromPipelineByPropertyName = true,
                   ParameterSetName = ByCertificateVersionsParameterSet,
                   HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.CertificateName)]
        public string Name { get; set; }

        /// <summary>
        /// Certificate version.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByCertificateNameParameterSet,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the version of the certificate in key vault.")]
        [Alias("CertificateVersion")]
        public string Version { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ByCertificateVersionsParameterSet,
            HelpMessage = "Specifies whether to include the versions of the certificate in the output.")]
        public SwitchParameter IncludeVersions { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            CertificateBundle certBundle;

            switch (ParameterSetName)
            {
                case ByCertificateNameParameterSet:
                    certBundle = this.DataServiceClient.GetCertificate(VaultName, Name, Version ?? string.Empty);
                    var certificate = KeyVaultCertificate.FromCertificateBundle(certBundle);
                    this.WriteObject(certificate);
                    break;

                case ByCertificateVersionsParameterSet:
                    certBundle = this.DataServiceClient.GetCertificate(VaultName, Name, string.Empty);
                    if (certBundle != null)
                    {
                        WriteObject(new CertificateIdentityItem(certBundle));
                        GetAndWriteCertificatesVersions(VaultName, Name, certBundle.CertificateIdentifier.Version);
                    }
                    break;

                case ByVaultNameParameterSet:
                    GetAndWriteCertificates(VaultName);
                    break;

                default:
                    throw new ArgumentException(KeyVaultProperties.Resources.BadParameterSetName);
            }
        }

        private void GetAndWriteCertificates(string vaultName)
        {
            KeyVaultObjectFilterOptions options = new KeyVaultObjectFilterOptions
            {
                VaultName = VaultName,
                NextLink = null
            };

            do
            {
                var pageResults = DataServiceClient.GetCertificates(options);
                WriteObject(pageResults, true);
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
    }
}

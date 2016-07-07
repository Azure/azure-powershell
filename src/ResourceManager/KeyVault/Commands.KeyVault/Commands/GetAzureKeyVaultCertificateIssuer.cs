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

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// The Get-AzureKeyVaultCertificate cmdlet gets the certificates in an Azure Key Vault or the current version of the certificate.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, CmdletNoun.AzureKeyVaultCertificateIssuer,        
        DefaultParameterSetName = ByVaultNameParameterSet,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(List<CertificateIssuerIdentityItem>), typeof(KeyVaultCertificateIssuer))]
    public class GetAzureKeyVaultCertificateIssuer : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByNameParameterSet = "ByName";
        private const string ByVaultNameParameterSet = "ByVaultName";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByNameParameterSet,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Issuer name. Cmdlet constructs the FQDN of a certificate issuer from vault name, currently selected environment and issuer name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.IssuerName)]
        public string Name { get; set; }

        #endregion

        protected override void ProcessRecord()
        {

            switch (ParameterSetName)
            {
                case ByNameParameterSet:
                    var issuer = this.DataServiceClient.GetCertificateIssuer(VaultName, Name);
                    this.WriteObject(KeyVaultCertificateIssuer.FromIssuer(issuer));
                    break;

                case ByVaultNameParameterSet:
                    GetAndWriteCertificateIssuers(VaultName);
                    break;

                default:
                    throw new ArgumentException(KeyVaultProperties.Resources.BadParameterSetName);
            }
        }

        private void GetAndWriteCertificateIssuers(string vaultName)
        {
            KeyVaultObjectFilterOptions options = new KeyVaultObjectFilterOptions
            {
                VaultName = VaultName,
                NextLink = null,
            };

            do
            {
                var pageResults = this.DataServiceClient.GetCertificateIssuers(options);
                WriteObject(pageResults, true);
            } while (!string.IsNullOrEmpty(options.NextLink));
        }
    }
}

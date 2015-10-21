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
using Microsoft.Azure.KeyVault;
using System;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Security;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Adds a given certificate issuer to Key Vault for certificate management
    /// </summary>
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureKeyVaultCertificateIssuer,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(KeyVaultCertificateIssuer))]
    public class AddAzureKeyVaultCertificateIssuer : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the name of the vault to which this cmdlet adds the certificate issuer.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern(Constants.VaultNameRegExString)]
        public string VaultName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 1,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the name of the issuer.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern(Constants.ObjectNameRegExString)]
        [Alias(Constants.IssuerName)]
        public string Name { get; set; }

        /// <summary>
        /// IssuerProvider
        /// </summary>
        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the type of the issuer.")]
        [ValidateNotNullOrEmpty]
        public string IssuerProvider { get; set; }

        /// <summary>
        /// AccountId
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the account id to be used with the issuer.")]
        [ValidateNotNullOrEmpty]
        public string AccountId { get; set; }

        /// <summary>
        /// ApiKey
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the api key to be used with the issuer.")]
        [ValidateNotNullOrEmpty]
        public SecureString ApiKey { get; set; }

        /// <summary>
        /// OrganizationDetails
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the organization details to be used with the issuer.")]
        [ValidateNotNullOrEmpty]
        public KeyVaultCertificateOrganizationDetails OrganizationDetails { get; set; }

        /// <summary>
        /// PassThru parameter
        /// </summary>
        [Parameter(HelpMessage = "This cmdlet does not return an object by default. If this switch is specified, it returns the certificate issuer object.")]
        public SwitchParameter PassThru { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            try
            {
                var existingIssuer = this.DataServiceClient.GetCertificateIssuer(VaultName, Name);

                if (existingIssuer != null)
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The specified issuer '{0}' already exists.", Name));
                }
            }
            catch (KeyVaultClientException kvce)
            {
                if (kvce.Status != HttpStatusCode.NotFound)
                {
                    throw;
                }

                // Here the object is not found. This is the good case, so continue with creation
            }

            var resultantIssuer = this.DataServiceClient.CreateCertificateIssuer(VaultName, Name, IssuerProvider, AccountId, ApiKey, OrganizationDetails);

            if (PassThru.IsPresent)
            {
                this.WriteObject(KeyVaultCertificateIssuer.FromIssuer(resultantIssuer));
            }
        }
    }
}

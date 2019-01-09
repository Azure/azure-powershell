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
using System;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Set-AzKeyVaultCertificateIssuer sets the provided parameters on the
    /// issuer object
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultCertificateIssuer",SupportsShouldProcess = true,DefaultParameterSetName = ExpandedParameterSet)]
    [OutputType(typeof(PSKeyVaultCertificatePolicy))]
    public class SetAzureKeyVaultCertificateIssuer : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ExpandedParameterSet = "Expanded";
        private const string ByValueParameterSet = "ByValue";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// VaultName
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 1,
                   HelpMessage = "Issuer name. Cmdlet constructs the FQDN of a certificate issuer from vault name, currently selected environment and issuer name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.IssuerName)]
        public string Name { get; set; }

        #region Expanded Parameter Set parmeters
        /// <summary>
        /// IssuerProvider
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ExpandedParameterSet,
                   HelpMessage = "Specifies the type of the issuer.")]
        [ValidateNotNullOrEmpty]
        public string IssuerProvider { get; set; }

        /// <summary>
        /// AccountId
        /// </summary>
        [Parameter(ParameterSetName = ExpandedParameterSet,
                   HelpMessage = "Specifies the account id to be used with the issuer.")]
        [ValidateNotNullOrEmpty]
        public string AccountId { get; set; }

        /// <summary>
        /// ApiKey
        /// </summary>
        [Parameter(ParameterSetName = ExpandedParameterSet,
                   HelpMessage = "Specifies the api key to be used with the issuer.")]
        [ValidateNotNullOrEmpty]
        public SecureString ApiKey { get; set; }

        /// <summary>
        /// OrganizationDetails
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ExpandedParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "Specifies the organization details to be used with the issuer.")]
        [ValidateNotNullOrEmpty]
        public PSKeyVaultCertificateOrganizationDetails OrganizationDetails { get; set; }

        #endregion

        #region ByValue Parameter Set parmeters

        /// <summary>
        /// OrganizationDetails
        /// </summary>
        [Parameter(Mandatory = true,
                   ParameterSetName = ByValueParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "Specifies the certificate issuer to set.")]
        [ValidateNotNullOrEmpty]
        [Alias("Issuer")]
        public PSKeyVaultCertificateIssuerIdentityItem InputObject { get; set; }

        #endregion

        /// <summary>
        /// PassThru parameter
        /// </summary>
        [Parameter(HelpMessage = "This cmdlet does not return an object by default. If this switch is specified, it returns the contact object.")]
        public SwitchParameter PassThru { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.SetCertificateIssuer))
            {
                PSKeyVaultCertificateIssuer issuerToUse;

                if (InputObject != null)
                {
                    issuerToUse = (PSKeyVaultCertificateIssuer) InputObject;
                }
                else
                {
                    issuerToUse = new PSKeyVaultCertificateIssuer
                    {
                        Name = Name,
                        IssuerProvider = IssuerProvider,
                        AccountId = AccountId,
                        ApiKey = ApiKey,
                        OrganizationDetails = OrganizationDetails,
                    };
                }

                var resultantIssuer = this.DataServiceClient.SetCertificateIssuer(
                                            VaultName,
                                            Name,
                                            issuerToUse.IssuerProvider,
                                            issuerToUse.AccountId,
                                            issuerToUse.ApiKey,
                                            issuerToUse.OrganizationDetails);

                if (PassThru.IsPresent)
                {
                    this.WriteObject(resultantIssuer);
                }
            }
        }
    }
}

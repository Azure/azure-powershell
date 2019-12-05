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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using PSKeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Set-AzKeyVaultCertificatePolicy sets the provided parameters on the
    /// policy for the Certificate object
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultCertificatePolicy",SupportsShouldProcess = true,DefaultParameterSetName = ExpandedRenewPercentageParameterSet)]
    [OutputType(typeof(PSKeyVaultCertificatePolicy))]
    public class SetAzureKeyVaultCertificatePolicy : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ExpandedRenewPercentageParameterSet = "ExpandedRenewPercentage";
        private const string ExpandedRenewNumberParameterSet = "ExpandedRenewNumber";
        private const string ByValueParameterSet = "ByValue";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Secret name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "Certificate name. Cmdlet constructs the FQDN of a certificate from vault name, currently selected environment and certificate name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.CertificateName)]
        public string Name { get; set; }

        /// <summary>
        /// CertificatePolicy
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByValueParameterSet,
            HelpMessage = "Specifies the certificate policy.")]
        [ValidateNotNull]
        [Alias("CertificatePolicy")]
        public PSKeyVaultCertificatePolicy InputObject { get; set; }

        /// <summary>
        /// RenewAtNumberOfDaysBeforeExpiry
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the number of days before expiration when automatic renewal should start.")]
        [ValidateRange(1, int.MaxValue)]
        public int? RenewAtNumberOfDaysBeforeExpiry { get; set; }

        /// <summary>
        /// RenewAtPercentageLifetime
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the percentage of the lifetime after which the automatic process for the certificate renewal begins.")]
        [ValidateRange(0, 99)]
        public int? RenewAtPercentageLifetime { get; set; }

        /// <summary>
        /// SecretContentType
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the content type of the resulting Key Vault secret.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the content type of the resulting Key Vault secret.")]
        [ValidateSet(Constants.Pkcs12ContentType, Constants.PemContentType)]
        public string SecretContentType { get; set; }

        /// <summary>
        /// ReuseKeyOnRenewal
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies whether the certificate should use the old key during renewal.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies whether the certificate should use the old key during renewal.")]
        public bool? ReuseKeyOnRenewal { get; set; }

        /// <summary>
        /// ReuseKeyOnRenewal
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies whether the certificate policy is enabled or not.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies whether the certificate policy is enabled or not.")]
        public SwitchParameter Disabled { get; set; }

        /// <summary>
        /// SubjectName
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the subject name of the certificate.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the subject name of the certificate.")]
        public string SubjectName { get; set; }

        /// <summary>
        /// DnsNames
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the subject name of the certificate.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the subject name of the certificate.")]
        [Alias("DnsNames")]
        public List<string> DnsName { get; set; }

        /// <summary>
        /// Key Usage
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the key usages in the certificate.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the key usages in the certificate.")]
        public List<X509KeyUsageFlags> KeyUsage { get; set; }

        /// <summary>
        /// Ekus
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the enhanced key usages in the certificate.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the enhanced key usages in the certificate.")]
        public List<string> Ekus { get; set; }

        /// <summary>
        /// ValidityInMonths
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the number of months the certificate will be valid.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the number of months the certificate will be valid.")]
        public int? ValidityInMonths { get; set; }

        /// <summary>
        /// IssuerName
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the name of the issuer for this certificate.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the name of the issuer for this certificate.")]
        public string IssuerName { get; set; }

        /// <summary>
        /// CertificateType
        /// </summary>
        [Parameter(Mandatory = false,
                   ParameterSetName = ExpandedRenewPercentageParameterSet,
                   HelpMessage = "Specifies the type of certificate to the issuer.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = ExpandedRenewNumberParameterSet,
                   HelpMessage = "Specifies the type of certificate to the issuer.")]
        public string CertificateType { get; set; }

        /// <summary>
        /// EmailAtNumberOfDaysBeforeExpiry
        /// </summary>
        [Parameter(Mandatory = false,
                   HelpMessage = "Specifies how many days before expiry the automatic notification process begins.")]
        public int? EmailAtNumberOfDaysBeforeExpiry { get; set; }

        /// <summary>
        /// EmailAtPercentageLifetime
        /// </summary>
        [Parameter(Mandatory = false,
                   HelpMessage = "Specifies the percentage of the lifetime after which the automatic process for the notification begins.")]
        public int? EmailAtPercentageLifetime { get; set; }

        /// <summary>
        /// Key type
        /// </summary>
        [Parameter(Mandatory = false,
                   HelpMessage = "Specifies the key type of the key backing the certificate. Default is RSA.")]
        [ValidateSet(Constants.RSA, Constants.RSAHSM, Constants.EC, Constants.ECHSM)]
        public string KeyType { get; set; }

        /// <summary>
        /// Key size
        /// </summary>
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the key size of the certificate. Default is 2048.")]
        [ValidateSet("2048", "3072", "4096", "256", "384", "521")]
        public int KeySize { get; set; }

        /// <summary>
        /// KeyNotExportable
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies whether the key is not exportable.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies whether the key is not exportable.")]
        public SwitchParameter KeyNotExportable { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false,
            HelpMessage = "Indicates whether certificate transparency is enabled for this certificate/issuer; if not specified, the default is 'true'")]
        public bool? CertificateTransparency { get; set; }

        /// <summary>
        /// PassThru parameter
        /// </summary>
        [Parameter(HelpMessage = "This cmdlet does not return an object by default. If this switch is specified, it returns the policy object.")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Elliptic Curve Name of the key
        /// </summary>
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the elliptic curve name of the key of the ECC certificate.")]
        [ValidateSet(Constants.P256, Constants.P384, Constants.P521, Constants.P256K, Constants.SECP256K1)]
        public string Curve { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.SetCertificatePolicy))
            {
                PSKeyVaultCertificatePolicy policy = new PSKeyVaultCertificatePolicy();

                switch (ParameterSetName)
                {
                    case ExpandedRenewNumberParameterSet:
                    case ExpandedRenewPercentageParameterSet:
                        policy = new PSKeyVaultCertificatePolicy(
                            DnsName,
                            (KeyUsage == null || !KeyUsage.Any()) ? null : KeyUsage.Select(keyUsage => keyUsage.ToString()).ToList<string>(),
                            Ekus,
                            !Disabled.IsPresent,
                            IssuerName,
                            CertificateType,
                            RenewAtNumberOfDaysBeforeExpiry,
                            RenewAtPercentageLifetime,
                            EmailAtNumberOfDaysBeforeExpiry,
                            EmailAtPercentageLifetime,
                            ReuseKeyOnRenewal,
                            SecretContentType,
                            SubjectName,
                            ValidityInMonths,
                            KeyType,
                            KeySize,
                            Curve,
                            KeyNotExportable.IsPresent ? !KeyNotExportable.IsPresent : (bool?)null,
                            CertificateTransparency ?? (bool?)null);
                        break;

                    case ByValueParameterSet:
                        InputObject.Validate();
                        policy = InputObject;
                        break;
                }

                var resultantPolicy = DataServiceClient.UpdateCertificatePolicy(VaultName, Name, policy.ToCertificatePolicy());

                if (PassThru.IsPresent)
                {
                    this.WriteObject(resultantPolicy);
                }
            }
        }
    }
}

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
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using PSKeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Set-AzureKeyVaultCertificatePolicy sets the provided parameters on the
    /// policy for the Certificate object
    /// </summary>
    [Cmdlet(VerbsCommon.Set, CmdletNoun.AzureKeyVaultCertificatePolicy,
        SupportsShouldProcess = true,
        DefaultParameterSetName = ExpandedRenewPercentageParameterSet,
        HelpUri = Constants.KeyVaultHelpUri)]
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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Secret name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
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
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the number of days before expiration when automatic renewal should start.")]
        [ValidateRange(1, int.MaxValue)]
        public int? RenewAtNumberOfDaysBeforeExpiry { get; set; }

        /// <summary>
        /// RenewAtPercentageLifetime
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the percentage of the lifetime after which the automatic process for the certificate renewal begins.")]
        [ValidateRange(0, 99)]
        public int? RenewAtPercentageLifetime { get; set; }

        /// <summary>
        /// SecretContentType
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the content type of the resulting Key Vault secret.")]
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the content type of the resulting Key Vault secret.")]
        [ValidateSet(Constants.Pkcs12ContentType, Constants.PemContentType)]
        public string SecretContentType { get; set; }

        /// <summary>
        /// ReuseKeyOnRenewal
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies whether the certificate should use the old key during renewal.")]
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies whether the certificate should use the old key during renewal.")]
        public bool? ReuseKeyOnRenewal { get; set; }

        /// <summary>
        /// ReuseKeyOnRenewal
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies whether the certificate policy is enabled or not.")]
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies whether the certificate policy is enabled or not.")]
        public SwitchParameter Disabled { get; set; }

        /// <summary>
        /// SubjectName
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the subject name of the certificate.")]
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the subject name of the certificate.")]
        public string SubjectName { get; set; }

        /// <summary>
        /// DnsNames
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the subject name of the certificate.")]
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the subject name of the certificate.")]
        [Alias("DnsNames")]
        public List<string> DnsName { get; set; }

        /// <summary>
        /// Key Usage
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the key usages in the certificate.")]
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the key usages in the certificate.")]
        public List<string> KeyUsage { get; set; }

        /// <summary>
        /// Ekus
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the enhanced key usages in the certificate.")]
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the enhanced key usages in the certificate.")]
        public List<string> Ekus { get; set; }

        /// <summary>
        /// ValidityInMonths
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the number of months the certificate will be valid.")]
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the number of months the certificate will be valid.")]
        public int? ValidityInMonths { get; set; }

        /// <summary>
        /// IssuerName
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies the name of the issuer for this certificate.")]
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies the name of the issuer for this certificate.")]
        public string IssuerName { get; set; }

        /// <summary>
        /// CertificateType
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   ParameterSetName = ExpandedRenewPercentageParameterSet,
                   HelpMessage = "Specifies the type of certificate to the issuer.")]
        [Parameter(ValueFromPipelineByPropertyName = true,
                   ParameterSetName = ExpandedRenewNumberParameterSet,
                   HelpMessage = "Specifies the type of certificate to the issuer.")]
        public string CertificateType { get; set; }

        /// <summary>
        /// EmailAtNumberOfDaysBeforeExpiry
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies how many days before expiry the automatic notification process begins.")]
        public int? EmailAtNumberOfDaysBeforeExpiry { get; set; }

        /// <summary>
        /// EmailAtPercentageLifetime
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the percentage of the lifetime after which the automatic process for the notification begins.")]
        public int? EmailAtPercentageLifetime { get; set; }

        /// <summary>
        /// Key type
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the key type of the key backing the certificate.")]
        [ValidateSet(Constants.RSA, Constants.RSAHSM)]
        public string KeyType { get; set; }

        /// <summary>
        /// KeyNotExportable
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewPercentageParameterSet,
            HelpMessage = "Specifies whether the key is not exportable.")]
        [Parameter(ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedRenewNumberParameterSet,
            HelpMessage = "Specifies whether the key is not exportable.")]
        public SwitchParameter KeyNotExportable { get; set; }

        /// <summary>
        /// PassThru parameter
        /// </summary>
        [Parameter(HelpMessage = "This cmdlet does not return an object by default. If this switch is specified, it returns the policy object.")]
        public SwitchParameter PassThru { get; set; }
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

                        // Validate input parameters
                        ValidateSubjectName();
                        ValidateDnsNames();
                        ValidateKeyUsage();
                        ValidateEkus();

                        policy = new PSKeyVaultCertificatePolicy
                        {
                            DnsNames = DnsName,
                            KeyUsage = KeyUsage,
                            Ekus = Ekus,
                            Enabled = !Disabled.IsPresent,
                            IssuerName = IssuerName,
                            CertificateType = CertificateType,
                            RenewAtNumberOfDaysBeforeExpiry = RenewAtNumberOfDaysBeforeExpiry,
                            RenewAtPercentageLifetime = RenewAtPercentageLifetime,
                            EmailAtNumberOfDaysBeforeExpiry = EmailAtNumberOfDaysBeforeExpiry,
                            EmailAtPercentageLifetime = EmailAtPercentageLifetime,
                            SecretContentType = SecretContentType,
                            SubjectName = SubjectName,
                            ValidityInMonths = ValidityInMonths,
                            Kty = KeyType,
                            Exportable = KeyNotExportable.IsPresent ? !KeyNotExportable.IsPresent : (bool?)null
                        };

                        if (ReuseKeyOnRenewal.HasValue)
                        {
                            policy.ReuseKeyOnRenewal = ReuseKeyOnRenewal.Value;
                        }

                        break;

                    case ByValueParameterSet:
                        policy = InputObject;
                        break;
                }

                var resultantPolicy = DataServiceClient.UpdateCertificatePolicy(VaultName, Name, policy.ToCertificatePolicy());

                if (PassThru.IsPresent)
                {
                    this.WriteObject(PSKeyVaultCertificatePolicy.FromCertificatePolicy(resultantPolicy));
                }
            }
        }

        private void ValidateKeyUsage()
        {
            if (KeyUsage != null)
            {
                foreach (var usage in KeyUsage)
                {
                    if (string.IsNullOrWhiteSpace(usage))
                    {
                        throw new ArgumentException("One of the Key Usage provided is empty.");
                    }

                    X509KeyUsageFlags parsedUsage;
                    if (!Enum.TryParse(usage, true, out parsedUsage))
                    {
                        throw new ArgumentException(string.Format("Key Usage {0} is invalid.", usage));
                    }
                }
            }
        }

        private void ValidateEkus()
        {
            if (Ekus != null)
            {
                foreach (var eku in Ekus)
                {
                    if (string.IsNullOrWhiteSpace(eku))
                    {
                        throw new ArgumentException("One of the EKUs provided is empty.");
                    }
                }
            }
        }

        private void ValidateDnsNames()
        {
            if (DnsName != null)
            {
                foreach (var dnsName in DnsName)
                {
                    if (string.IsNullOrWhiteSpace(dnsName))
                    {
                        throw new ArgumentException("One of the DNS names provided is empty.");
                    }
                }
            }
        }

        private void ValidateSubjectName()
        {
            if (SubjectName != null)
            {
                try
                {
                    new X500DistinguishedName(SubjectName);
                }
                catch (CryptographicException e)
                {
                    throw new ArgumentException("The subject name provided is not a valid X500 name.", e);
                }
            }
        }
    }
}
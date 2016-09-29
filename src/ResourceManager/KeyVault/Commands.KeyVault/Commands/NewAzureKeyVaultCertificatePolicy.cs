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
using System.Globalization;
using System.Management.Automation;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// New-AzureKeyVaultCertificatePolicy creates an in-memory Certificate Policy object
    /// </summary>
    [Cmdlet(VerbsCommon.New, CmdletNoun.AzureKeyVaultCertificatePolicy,
        SupportsShouldProcess = true,
        HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(KeyVaultCertificatePolicy))]
    public class NewAzureKeyVaultCertificatePolicy : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// SecretContentType
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the content type of the resulting Key Vault secret.")]
        [ValidateSet(Constants.Pkcs12ContentType, Constants.PemContentType)]
        public string SecretContentType { get; set; }

        /// <summary>
        /// ReuseKeyOnRenewal
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies whether the certificate should use the old key during renewal.")]
        public SwitchParameter ReuseKeyOnRenewal { get; set; }

        /// <summary>
        /// ReuseKeyOnRenewal
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies whether the certificate policy is enabled or not.")]
        public SwitchParameter Disabled { get; set; }

        /// <summary>
        /// SubjectName
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the subject name of the certificate.")]
        public string SubjectName { get; set; }

        /// <summary>
        /// DnsNames
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the DNS names in the certificate.")]
        public List<string> DnsNames { get; set; }

        /// <summary>
        /// Key Usage
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,            
            HelpMessage = "Specifies the key usages in the certificate.")]
        public List<string> KeyUsage { get; set; }

        /// <summary>
        /// Ekus
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the enhanced key usages in the certificate.")]
        public List<string> Ekus { get; set; }

        /// <summary>
        /// ValidityInMonths
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the number of months the certificate will be valid.")]
        public int? ValidityInMonths { get; set; }

        /// <summary>
        /// IssuerName
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   Mandatory = true,
                   HelpMessage = "Specifies the name of the issuer for this certificate.")]
        public string IssuerName { get; set; }

        /// <summary>
        /// CertificateType
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the type of certificate to the issuer.")]
        public string CertificateType { get; set; }

        /// <summary>
        /// RenewAtNumberOfDaysBeforeExpiry
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies how many days before expiry the automatic certificate renewal process begins.")]
        public int? RenewAtNumberOfDaysBeforeExpiry { get; set; }

        /// <summary>
        /// RenewAtPercentageLifetime
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the percentage of the lifetime after which the automatic process for the certificate renewal begins.")]
        public int? RenewAtPercentageLifetime { get; set; }

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
            HelpMessage = "Specifies whether the key is not exportable.")]
        public SwitchParameter KeyNotExportable { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            if (ShouldProcess(string.Empty, Properties.Resources.CreateCertificatePolicy))
            {
                // Validate input parameters
                ValidateSubjectName();
                ValidateDnsNames();
                ValidateKeyUsage();
                ValidateEkus();
                ValidateRenewAtNumberOfDaysBeforeExpiry();
                ValidateRenewAtPercentageLifetime();

                // Validate combinations of parameters
                ValidateBothPercentageAndNumberOfDaysAreNotPresent();
                ValidateAtLeastOneOfSubjectNameAndDnsNamesIsPresent();

                var policy = new KeyVaultCertificatePolicy
                {
                    DnsNames = DnsNames,
                    Ekus = Ekus,
                    Enabled = !Disabled.IsPresent,
                    IssuerName = IssuerName,
                    CertificateType = CertificateType,
                    RenewAtNumberOfDaysBeforeExpiry = RenewAtNumberOfDaysBeforeExpiry,
                    RenewAtPercentageLifetime = RenewAtPercentageLifetime,
                    EmailAtNumberOfDaysBeforeExpiry = EmailAtNumberOfDaysBeforeExpiry,
                    EmailAtPercentageLifetime = EmailAtPercentageLifetime,
                    ReuseKeyOnRenewal = ReuseKeyOnRenewal.IsPresent,
                    SecretContentType = SecretContentType,
                    SubjectName = SubjectName,
                    ValidityInMonths = ValidityInMonths,
                    Kty = KeyType,
                    Exportable = KeyNotExportable.IsPresent ? !KeyNotExportable.IsPresent : (bool?)null
                };

                this.WriteObject(policy);
            }
        }

        private void ValidateAtLeastOneOfSubjectNameAndDnsNamesIsPresent()
        {
            if (SubjectName == null &&
                DnsNames == null)
            {
                throw new ArgumentException("At least one of subject name or DNS names must be specified.");
            }
        }

        private void ValidateBothPercentageAndNumberOfDaysAreNotPresent()
        {
            if (RenewAtNumberOfDaysBeforeExpiry != null &&
                RenewAtPercentageLifetime != null)
            {
                throw new ArgumentException("Both RenewAtNumberOfDaysBeforeExpiry and RenewAtPercentageLifetime cannot be specified.");
            }
        }

        private void ValidateRenewAtPercentageLifetime()
        {
            if (RenewAtPercentageLifetime != null)
            {
                if (RenewAtPercentageLifetime < 0)
                {
                    throw new ArgumentException("RenewAtPercentageLifetime must be larger than or equal to 0.");
                }

                if (RenewAtPercentageLifetime >= 100)
                {
                    throw new ArgumentException("RenewAtPercentageLifetime must be smaller than 100.");
                }
            }
        }

        private void ValidateRenewAtNumberOfDaysBeforeExpiry()
        {
            if (RenewAtNumberOfDaysBeforeExpiry != null)
            {
                if (RenewAtNumberOfDaysBeforeExpiry <= 0)
                {
                    throw new ArgumentException("RenewAtNumberOfDaysBeforeExpiry must be larger than 0.");
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
            if (DnsNames != null)
            {
                foreach (var dnsName in DnsNames)
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
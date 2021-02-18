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
<<<<<<< HEAD
=======
using System.Linq;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using System.Management.Automation;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// New-AzKeyVaultCertificatePolicy creates an in-memory Certificate Policy object
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultCertificatePolicy",SupportsShouldProcess = true,DefaultParameterSetName = SubjectNameParameterSet)]
    [OutputType(typeof(PSKeyVaultCertificatePolicy))]
    public class NewAzureKeyVaultCertificatePolicy : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string SubjectNameParameterSet = "SubjectName";
        private const string DNSNamesParameterSet = "DNSNames";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// IssuerName
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the name of the issuer for this certificate.")]
        public string IssuerName { get; set; }

        /// <summary>
        /// SubjectName
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 1,
                   ParameterSetName = SubjectNameParameterSet,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the subject name of the certificate.")]
        [Parameter(Mandatory = false,
                   ParameterSetName = DNSNamesParameterSet,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the subject name of the certificate.")]
        public string SubjectName { get; set; }

        /// <summary>
        /// DnsNames
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 1,
                   ParameterSetName = DNSNamesParameterSet,
                   ValueFromPipelineByPropertyName = true,
<<<<<<< HEAD
                   HelpMessage = "Specifies the DNS names in the certificate.")]
=======
                   HelpMessage = "Specifies the DNS names in the certificate. Subject Alternative Names (SANs) can be specified as DNS names.")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Alias("DnsNames")]
        public List<string> DnsName { get; set; }

        /// <summary>
        /// RenewAtNumberOfDaysBeforeExpiry
        /// </summary>
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies how many days before expiry the automatic certificate renewal process begins.")]
        [ValidateRange(1, int.MaxValue)]
        public int? RenewAtNumberOfDaysBeforeExpiry { get; set; }

        /// <summary>
        /// RenewAtPercentageLifetime
        /// </summary>
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the percentage of the lifetime after which the automatic process for the certificate renewal begins.")]
        [ValidateRange(0, 99)]
        public int? RenewAtPercentageLifetime { get; set; }

        /// <summary>
        /// SecretContentType
        /// </summary>
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the content type of the resulting Key Vault secret.")]
        [ValidateSet(Constants.Pkcs12ContentType, Constants.PemContentType)]
        public string SecretContentType { get; set; }

        /// <summary>
        /// ReuseKeyOnRenewal
        /// </summary>
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies whether the certificate should use the old key during renewal.")]
        public SwitchParameter ReuseKeyOnRenewal { get; set; }

        /// <summary>
        /// ReuseKeyOnRenewal
        /// </summary>
        [Parameter(Mandatory = false, 
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies whether the certificate policy is enabled or not.")]
        public SwitchParameter Disabled { get; set; }

        /// <summary>
        /// Key Usage
        /// </summary>
        [Parameter(Mandatory = false, 
                   ValueFromPipelineByPropertyName = true,            
                   HelpMessage = "Specifies the key usages in the certificate.")]
        public List<X509KeyUsageFlags> KeyUsage { get; set; }

        /// <summary>
        /// Ekus
        /// </summary>
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the enhanced key usages in the certificate.")]
        public List<string> Ekus { get; set; }

        /// <summary>
        /// ValidityInMonths
        /// </summary>
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the number of months the certificate will be valid.")]
        public int? ValidityInMonths { get; set; }

        /// <summary>
        /// CertificateType
        /// </summary>
        [Parameter(Mandatory = false, 
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the type of certificate to the issuer.")]
        public string CertificateType { get; set; }

        /// <summary>
        /// EmailAtNumberOfDaysBeforeExpiry
        /// </summary>
        [Parameter(Mandatory = false, 
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies how many days before expiry the automatic notification process begins.")]
        public int? EmailAtNumberOfDaysBeforeExpiry { get; set; }

        /// <summary>
        /// EmailAtPercentageLifetime
        /// </summary>
        [Parameter(Mandatory = false, 
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the percentage of the lifetime after which the automatic process for the notification begins.")]
        public int? EmailAtPercentageLifetime { get; set; }        

        /// <summary>
        /// Key type
        /// </summary>
        [Parameter(Mandatory = false, 
                   ValueFromPipelineByPropertyName = true,
<<<<<<< HEAD
                   HelpMessage = "Specifies the key type of the key backing the certificate.")]
        [ValidateSet(Constants.RSA, Constants.RSAHSM)]
        public string KeyType { get; set; }

      /// <summary>
      /// Key size
      /// </summary>
      [Parameter(Mandatory = false,
                 ValueFromPipelineByPropertyName = true,
                 HelpMessage = "Specifies the key size of the certificate.")]
      [ValidateSet("2048", "3072", "4096")]
      public int KeySize { get; set; } = 2048;
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        /// <summary>
        /// KeyNotExportable
        /// </summary>
<<<<<<< HEAD
        [Parameter(Mandatory = false, 
=======
        [Parameter(Mandatory = false,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies whether the key is not exportable.")]
        public SwitchParameter KeyNotExportable { get; set; }

<<<<<<< HEAD
=======

        [Parameter(Mandatory = false, 
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Indicates whether certificate transparency is enabled for this certificate/issuer; if not specified, the default is 'true'")]
        public bool? CertificateTransparency { get; set; }

        /// <summary>
        /// Elliptic Curve Name of the key
        /// </summary>
        [Parameter(Mandatory = false,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specifies the elliptic curve name of the key of the ECC certificate.")]
        [ValidateSet(Constants.P256, Constants.P384, Constants.P521, Constants.P256K, Constants.SECP256K1)]
        public string Curve { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(string.Empty, Properties.Resources.CreateCertificatePolicy))
            {
<<<<<<< HEAD
                // Validate input parameters
                ValidateSubjectName();
                ValidateDnsNames();
                ValidateEkus();
                ValidateBothPercentageAndNumberOfDaysAreNotPresent();

                List<String> convertedKeyUsage = null;
                if (KeyUsage != null)
                {
                    convertedKeyUsage = new List<string>();
                    foreach (var key in KeyUsage)
                    {
                        convertedKeyUsage.Add(key.ToString());
                    }
                }

                var policy = new PSKeyVaultCertificatePolicy
                {
                  DnsNames = DnsName,
                  KeyUsage = convertedKeyUsage,
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
                  KeySize = KeySize,
                  Exportable = KeyNotExportable.IsPresent ? !KeyNotExportable.IsPresent : (bool?)null
                };
=======
                var policy = new PSKeyVaultCertificatePolicy(
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
                    ReuseKeyOnRenewal.IsPresent,
                    SecretContentType,
                    SubjectName,
                    ValidityInMonths,
                    KeyType,
                    KeySize,
                    Curve,
                    KeyNotExportable.IsPresent ? !KeyNotExportable.IsPresent : (bool?)null,
                    CertificateTransparency ?? (bool?)null);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

                this.WriteObject(policy);
            }
        }
<<<<<<< HEAD

        private void ValidateBothPercentageAndNumberOfDaysAreNotPresent()
        {
            if (MyInvocation.BoundParameters.ContainsKey("RenewAtNumberOfDaysBeforeExpiry") &&
                MyInvocation.BoundParameters.ContainsKey("RenewAtPercentageLifetime"))
            {
                throw new ArgumentException("Both RenewAtNumberOfDaysBeforeExpiry and RenewAtPercentageLifetime cannot be specified.");
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
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}

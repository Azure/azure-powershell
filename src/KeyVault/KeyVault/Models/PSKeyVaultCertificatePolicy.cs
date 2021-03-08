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

using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultCertificatePolicy
    {
        public string SecretContentType { get; set; }
        public string Kty { get; set; }
        public int? KeySize { get; set; }
        public string Curve { get; set; }
        public bool? Exportable { get; set; }
        public bool? ReuseKeyOnRenewal { get; set; }
        public string SubjectName { get; set; }
        public List<string> DnsNames { get; set; }
        public List<string> KeyUsage { get; set; }
        public List<string> Ekus { get; set; }
        public int? ValidityInMonths { get; set; }
        public string IssuerName { get; set; }
        public string CertificateType { get; set; }
        public int? RenewAtNumberOfDaysBeforeExpiry { get; set; }
        public int? RenewAtPercentageLifetime { get; set; }
        public int? EmailAtNumberOfDaysBeforeExpiry { get; set; }
        public int? EmailAtPercentageLifetime { get; set; }
        public bool? CertificateTransparency { get; set; }

        public bool? Enabled { get; set; }
        public DateTime? Created { get; internal set; }
        public DateTime? Updated { get; internal set; }

        public PSKeyVaultCertificatePolicy()
        {
        }

        public PSKeyVaultCertificatePolicy(
            IList<string> dnsNames,
            IList<string> keyUsages,
            IList<string> ekus,
            bool? enabled,
            string issuerName,
            string certificateType,
            int? renewAtNumberOfDaysBeforeExpiry,
            int? renewAtPercentageLifetime,
            int? emailAtNumberOfDaysBeforeExpiry,
            int? emailAtPercentageLifetime,
            bool? reuseKeyOnRenewal,
            string secretContentType,
            string subjectName,
            int? validityInMonths,
            string keyType,
            int keySize,
            string curve,
            bool? exportable,
            bool? certificateTransparency)
        {
            ValidateInternal(
                dnsNames,
                ekus,
                renewAtNumberOfDaysBeforeExpiry,
                renewAtPercentageLifetime,
                emailAtNumberOfDaysBeforeExpiry,
                emailAtPercentageLifetime,
                subjectName,
                keyType,
                keySize,
                curve);

            var keyTypeToUse = GetDefaultKeyTypeIfNotSpecified(keyType);
            var keySizeToUse = GetDefaultKeySizeIfNotSpecified(keyTypeToUse, curve, keySize);

            DnsNames = (dnsNames == null || !dnsNames.Any()) ? null : dnsNames.ToList();
            KeyUsage = (keyUsages == null || !keyUsages.Any()) ? null : keyUsages.ToList();
            Ekus = (ekus == null || !ekus.Any()) ? null : ekus.ToList();
            Enabled = enabled;
            IssuerName = issuerName;
            CertificateType = certificateType;
            RenewAtNumberOfDaysBeforeExpiry = renewAtNumberOfDaysBeforeExpiry;
            RenewAtPercentageLifetime = renewAtPercentageLifetime;
            EmailAtNumberOfDaysBeforeExpiry = emailAtNumberOfDaysBeforeExpiry;
            EmailAtPercentageLifetime = emailAtPercentageLifetime;
            ReuseKeyOnRenewal = reuseKeyOnRenewal;
            SecretContentType = secretContentType;
            SubjectName = subjectName;
            ValidityInMonths = validityInMonths;
            Kty = keyTypeToUse;
            Curve = curve;
            KeySize = keySizeToUse;
            Exportable = exportable;
            CertificateTransparency = certificateTransparency;
        }

        internal CertificatePolicy ToCertificatePolicy()
        {
            var certificatePolicy = new CertificatePolicy();

            if (!string.IsNullOrWhiteSpace(SecretContentType))
            {
                certificatePolicy.SecretProperties = new SecretProperties { ContentType = SecretContentType };
            }

            if (!string.IsNullOrWhiteSpace(Kty) ||
                KeySize.HasValue ||
                !string.IsNullOrWhiteSpace(Curve) ||
                ReuseKeyOnRenewal.HasValue ||
                Exportable.HasValue)
            {
                certificatePolicy.KeyProperties = new KeyProperties
                {
                    KeyType = Kty,
                    KeySize = KeySize,
                    Curve = Curve,
                    Exportable = Exportable,
                    ReuseKey = ReuseKeyOnRenewal,
                };
            }

            if (!string.IsNullOrWhiteSpace(IssuerName))
            {
                if (certificatePolicy.IssuerParameters == null)
                {
                    certificatePolicy.IssuerParameters = new IssuerParameters();
                }

                certificatePolicy.IssuerParameters.Name = IssuerName;
            }

            if (CertificateTransparency.HasValue)
            {
                if (certificatePolicy.IssuerParameters == null)
                {
                    certificatePolicy.IssuerParameters = new IssuerParameters();
                }

                certificatePolicy.IssuerParameters.CertificateTransparency = CertificateTransparency;
            }

            if (!string.IsNullOrWhiteSpace(CertificateType))
            {
                if (certificatePolicy.IssuerParameters == null)
                {
                    certificatePolicy.IssuerParameters = new IssuerParameters();
                }

                certificatePolicy.IssuerParameters.CertificateType = CertificateType;
            }

            if (Enabled.HasValue)
            {
                certificatePolicy.Attributes = new CertificateAttributes
                {
                    Enabled = Enabled,
                };
            }

            if (!string.IsNullOrWhiteSpace(SubjectName) ||
                DnsNames != null ||
                Ekus != null ||
                KeyUsage != null |
                ValidityInMonths.HasValue)
            {
                var x509CertificateProperties = new X509CertificateProperties
                {
                    Subject = SubjectName,
                };

                if (KeyUsage != null)
                {
                    x509CertificateProperties.KeyUsage = new List<string>(KeyUsage);
                }

                if (Ekus != null)
                {
                    x509CertificateProperties.Ekus = Ekus == null ? null : new List<string>(Ekus);
                }                

                if (DnsNames != null)
                {
                    x509CertificateProperties.SubjectAlternativeNames = new SubjectAlternativeNames
                    {
                        DnsNames = new string[DnsNames.Count],
                    };

                    x509CertificateProperties.SubjectAlternativeNames.DnsNames = new List<string>(DnsNames);
                }

                if (ValidityInMonths.HasValue)
                {
                    x509CertificateProperties.ValidityInMonths = ValidityInMonths.Value;
                }

                certificatePolicy.X509CertificateProperties = x509CertificateProperties;
            }

            if (RenewAtNumberOfDaysBeforeExpiry.HasValue ||
                RenewAtPercentageLifetime.HasValue ||
                EmailAtNumberOfDaysBeforeExpiry.HasValue ||
                EmailAtPercentageLifetime.HasValue)
            {
                if ((RenewAtNumberOfDaysBeforeExpiry.HasValue ? 1:0) +
                    (RenewAtPercentageLifetime.HasValue ? 1:0) +
                    (EmailAtNumberOfDaysBeforeExpiry.HasValue ? 1:0) +
                    (EmailAtPercentageLifetime.HasValue ? 1:0) > 1)
                {
                    throw new ArgumentException("Only one of the values for RenewAtNumberOfDaysBeforeExpiry, RenewAtPercentageLifetime, EmailAtNumberOfDaysBeforeExpiry, EmailAtPercentageLifetime  can be set.");
                }

                if (certificatePolicy.LifetimeActions == null)
                {
                    certificatePolicy.LifetimeActions = new List<LifetimeAction>();
                }

                if (RenewAtNumberOfDaysBeforeExpiry.HasValue)
                {
                    certificatePolicy.LifetimeActions.Add(
                        new LifetimeAction
                        {
                            Action = new Azure.KeyVault.Models.Action { ActionType = ActionType.AutoRenew },
                            Trigger = new Trigger { DaysBeforeExpiry = RenewAtNumberOfDaysBeforeExpiry },
                        }
                    );
                }

                if (RenewAtPercentageLifetime.HasValue)
                {
                    certificatePolicy.LifetimeActions.Add(
                        new LifetimeAction
                        {
                            Action = new Azure.KeyVault.Models.Action { ActionType = ActionType.AutoRenew },
                            Trigger = new Trigger { LifetimePercentage = RenewAtPercentageLifetime },
                        }
                    );
                }
                if (EmailAtNumberOfDaysBeforeExpiry.HasValue)
                {
                    certificatePolicy.LifetimeActions.Add(
                        new LifetimeAction
                        {
                            Action = new Azure.KeyVault.Models.Action { ActionType = ActionType.EmailContacts },
                            Trigger = new Trigger { DaysBeforeExpiry = EmailAtNumberOfDaysBeforeExpiry },
                        }
                    );
                }

                if (EmailAtPercentageLifetime.HasValue)
                {
                    certificatePolicy.LifetimeActions.Add(
                        new LifetimeAction
                        {
                            Action = new Azure.KeyVault.Models.Action { ActionType = ActionType.EmailContacts },
                            Trigger = new Trigger { LifetimePercentage = EmailAtPercentageLifetime },
                        }
                    );
                }
            }

            return certificatePolicy;
        }

        internal static PSKeyVaultCertificatePolicy FromCertificatePolicy(CertificatePolicy certificatePolicy)
        {
            return new PSKeyVaultCertificatePolicy
            {
                SecretContentType = certificatePolicy.SecretProperties == null ? null : certificatePolicy.SecretProperties.ContentType,
                Kty = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.KeyType,
                KeySize = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.KeySize,
                Curve = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.Curve,
                Exportable = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.Exportable,
                ReuseKeyOnRenewal = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.ReuseKey,
                SubjectName = certificatePolicy.X509CertificateProperties == null ? null : certificatePolicy.X509CertificateProperties.Subject,
                DnsNames = certificatePolicy.X509CertificateProperties == null || certificatePolicy.X509CertificateProperties.SubjectAlternativeNames == null ?
                    null : new List<string>(certificatePolicy.X509CertificateProperties.SubjectAlternativeNames.DnsNames),
                KeyUsage = certificatePolicy.X509CertificateProperties == null ? null : certificatePolicy.X509CertificateProperties.KeyUsage == null ? null : new List<string>(certificatePolicy.X509CertificateProperties.KeyUsage),
                Ekus = certificatePolicy.X509CertificateProperties == null ? null : certificatePolicy.X509CertificateProperties.Ekus == null ? null : new List<string>(certificatePolicy.X509CertificateProperties.Ekus),               
                ValidityInMonths = certificatePolicy.X509CertificateProperties == null ? null : certificatePolicy.X509CertificateProperties.ValidityInMonths,
                CertificateTransparency = certificatePolicy.IssuerParameters == null ? null : certificatePolicy.IssuerParameters.CertificateTransparency,
                IssuerName = certificatePolicy.IssuerParameters == null ? null : certificatePolicy.IssuerParameters.Name,
                CertificateType = certificatePolicy.IssuerParameters == null ? null : certificatePolicy.IssuerParameters.CertificateType,
                RenewAtNumberOfDaysBeforeExpiry = certificatePolicy.LifetimeActions == null ? null : FindIntValueForAutoRenewAction(certificatePolicy.LifetimeActions, (trigger) => trigger.DaysBeforeExpiry),
                RenewAtPercentageLifetime = certificatePolicy.LifetimeActions == null ? null : FindIntValueForAutoRenewAction(certificatePolicy.LifetimeActions, (trigger) => trigger.LifetimePercentage),
                EmailAtNumberOfDaysBeforeExpiry = certificatePolicy.LifetimeActions == null ? null : FindIntValueForEmailAction(certificatePolicy.LifetimeActions, (trigger) => trigger.DaysBeforeExpiry),
                EmailAtPercentageLifetime = certificatePolicy.LifetimeActions == null ? null : FindIntValueForEmailAction(certificatePolicy.LifetimeActions, (trigger) => trigger.LifetimePercentage),
                Enabled = certificatePolicy.Attributes == null ? null : certificatePolicy.Attributes.Enabled,
                Created = certificatePolicy.Attributes == null ? null : certificatePolicy.Attributes.Created,
                Updated = certificatePolicy.Attributes == null ? null : certificatePolicy.Attributes.Updated,
            };
        }

        private static int? FindIntValueForAutoRenewAction(IEnumerable<LifetimeAction> lifetimeActions, Func<Trigger, int?> intValueGetter)
        {
            var lifetimeAction = lifetimeActions.FirstOrDefault(x => x.Action.ActionType.HasValue &&  0 == string.Compare(x.Action.ActionType.Value.ToString(), ActionType.AutoRenew.ToString(), true) && intValueGetter(x.Trigger).HasValue);

            if (lifetimeAction == null)
            {
                return null;                
            }

            return intValueGetter(lifetimeAction.Trigger);
        }

        private static int? FindIntValueForEmailAction(IEnumerable<LifetimeAction> lifetimeActions, Func<Trigger, int?> intValueGetter)
        {
            var lifetimeAction = lifetimeActions.FirstOrDefault(x => x.Action.ActionType.HasValue && 0 == string.Compare(x.Action.ActionType.Value.ToString(), ActionType.EmailContacts.ToString(), true) && intValueGetter(x.Trigger).HasValue);

            if (lifetimeAction == null)
            {
                return null;
            }

            return intValueGetter(lifetimeAction.Trigger);
        }

        private void ValidateInternal(
            IList<string> dnsNames,
            IList<string> ekus,
            int? renewAtNumberOfDaysBeforeExpiry,
            int? renewAtPercentageLifetime,
            int? emailAtNumberOfDaysBeforeExpiry,
            int? emailAtPercentageLifetime,
            string subjectName,
            string keyType,
            int keySize,
            string curve)
        {
            var keyTypeToUse = GetDefaultKeyTypeIfNotSpecified(keyType);
            ValidateKeyTypeAndCurve(keyTypeToUse, curve);

            var keySizeToUse = GetDefaultKeySizeIfNotSpecified(keyTypeToUse, curve, keySize);
            ValidateKeyTypeAndKeySize(keyTypeToUse, keySizeToUse);
            ValidateCurveAndKeySize(curve, keySizeToUse);

            ValidatePercentageAndNumberOfDaysForEmailAndRenew(renewAtNumberOfDaysBeforeExpiry, renewAtPercentageLifetime, emailAtNumberOfDaysBeforeExpiry, emailAtPercentageLifetime);
            ValidateEkus(ekus);
            ValidateDnsNames(dnsNames);
            ValidateSubjectName(subjectName);
        }

        public void Validate()
        {
            ValidateInternal(
                DnsNames,
                Ekus,
                RenewAtNumberOfDaysBeforeExpiry,
                RenewAtPercentageLifetime,
                EmailAtNumberOfDaysBeforeExpiry,
                EmailAtPercentageLifetime,
                SubjectName,
                Kty,
                KeySize ?? 0,
                Curve);
        }

        private string GetDefaultKeyTypeIfNotSpecified(string keyType)
        {
            return string.IsNullOrWhiteSpace(keyType) ? Constants.RSA : keyType;
        }

        private void ValidateKeyTypeAndCurve(string keyType, string curve)
        {
            if (Constants.RSA.Equals(keyType, StringComparison.OrdinalIgnoreCase) ||
                Constants.RSAHSM.Equals(keyType, StringComparison.OrdinalIgnoreCase))
            {
                if (!string.IsNullOrWhiteSpace(curve))
                {
                    throw new ArgumentException($"Curve cannot be specified with {keyType} key type.");
                }
            }

            if (Constants.EC.Equals(keyType, StringComparison.OrdinalIgnoreCase) ||
                Constants.ECHSM.Equals(keyType, StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(curve))
                {
                    throw new ArgumentException($"Curve must be specified with {keyType} key type.");
                }
            }
        }

        private int GetDefaultKeySizeIfNotSpecified(string keyType, string curve, int keySize)
        {
            if (keySize == 0)
            {
                if (Constants.RSA.Equals(keyType, StringComparison.OrdinalIgnoreCase) ||
                    Constants.RSAHSM.Equals(keyType, StringComparison.OrdinalIgnoreCase))
                {
                    return 2048;
                }

                if (Constants.EC.Equals(keyType, StringComparison.OrdinalIgnoreCase) ||
                    Constants.ECHSM.Equals(keyType, StringComparison.OrdinalIgnoreCase))
                {
                    if (Constants.P256.Equals(curve, StringComparison.OrdinalIgnoreCase) ||
                        Constants.P256K.Equals(curve, StringComparison.OrdinalIgnoreCase) ||
                        Constants.SECP256K1.Equals(curve, StringComparison.OrdinalIgnoreCase))
                    {
                        return 256;
                    }

                    if (Constants.P384.Equals(curve, StringComparison.OrdinalIgnoreCase))
                    {
                        return 384;
                    }

                    if (Constants.P521.Equals(curve, StringComparison.OrdinalIgnoreCase))
                    {
                        return 521;
                    }
                }
            }

            return keySize;
        }

        private void ValidateKeyTypeAndKeySize(string keyType, int keySize)
        {
            if (Constants.RSA.Equals(keyType, StringComparison.OrdinalIgnoreCase) ||
                Constants.RSAHSM.Equals(keyType, StringComparison.OrdinalIgnoreCase))
            {
                if (keySize == 256 || keySize == 384 || keySize == 521)
                {
                    throw new ArgumentException($"{keySize} cannot be specified with {keyType} key type. Valid values for KeySize are: 2048, 3084, and 4096.");
                }
            }

            if (Constants.EC.Equals(keyType, StringComparison.OrdinalIgnoreCase) ||
                Constants.ECHSM.Equals(keyType, StringComparison.OrdinalIgnoreCase))
            {
                 if (keySize == 2048 || keySize == 3084 || keySize == 4096)
                 {
                     throw new ArgumentException($"{keySize} cannot be specified with {keyType} key type. Valid values for KeySize are: 256, 384, and 521.");
                 }
            }
        }

        private void ValidateCurveAndKeySize(string curve, int keySize)
        {
            if (string.IsNullOrWhiteSpace(curve))
            {
                return;
            }

            if (Constants.P256.Equals(curve, StringComparison.OrdinalIgnoreCase) ||
                Constants.P256K.Equals(curve, StringComparison.OrdinalIgnoreCase) ||
                Constants.SECP256K1.Equals(curve, StringComparison.OrdinalIgnoreCase))
            {
                if (keySize != 256)
                {
                    throw new ArgumentException($"Only key size of 256 is allowed with {curve}.");
                }
            }

            if (Constants.P384.Equals(curve, StringComparison.OrdinalIgnoreCase))
            {
                if (keySize != 384)
                {
                    throw new ArgumentException($"Only key size of 384 is allowed with {curve}.");
                }
            }

            if (Constants.P521.Equals(curve, StringComparison.OrdinalIgnoreCase))
            {
                if (keySize != 521)
                {
                    throw new ArgumentException($"Only key size of 521 is allowed with {curve}.");
                }
            }
        }

        private void ValidatePercentageAndNumberOfDaysForEmailAndRenew(
            int? renewAtNumberOfDaysBeforeExpiry,
            int? renewAtPercentageLifetime,
            int? emailAtNumberOfDaysBeforeExpiry,
            int? emailAtPercentageLifetime)
        {
            if (renewAtNumberOfDaysBeforeExpiry.HasValue && renewAtPercentageLifetime.HasValue && emailAtNumberOfDaysBeforeExpiry.HasValue && emailAtPercentageLifetime.HasValue)
            {
                throw new ArgumentException("Only one of the values for RenewAtNumberOfDaysBeforeExpiry, RenewAtPercentageLifetime, EmailAtNumberOfDaysBeforeExpiry, EmailAtPercentageLifetime can be specified.");
            }
        }

        private void ValidateEkus(IList<string> ekus)
        {
            if (ekus == null || !ekus.Any())
            {
                return;
            }

            foreach (var eku in ekus)
            {
                if (string.IsNullOrWhiteSpace(eku))
                {
                    throw new ArgumentException("One of the EKUs provided is empty.");
                }
            }
        }

        private void ValidateDnsNames(IList<string> dnsNames)
        {
            if (dnsNames == null || !dnsNames.Any())
            {
                return;
            }

            foreach (var dnsName in dnsNames)
            {
                if (string.IsNullOrWhiteSpace(dnsName))
                {
                    throw new ArgumentException("One of the DNS names provided is empty.");
                }
            }
        }

        private void ValidateSubjectName(string subjectName)
        {
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                return;
            }

            try
            {
                new X500DistinguishedName(subjectName);
            }
            catch (CryptographicException e)
            {
                throw new ArgumentException("The subject name provided is not a valid X500 name.", e);
            }
        }
    }
}

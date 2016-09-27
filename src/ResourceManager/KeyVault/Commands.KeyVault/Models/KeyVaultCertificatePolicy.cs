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

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyVaultCertificatePolicy
    {
        public string SecretContentType { get; set; }
        public string Kty { get; set; }
        public int? KeySize { get; internal set; }
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

        public bool? Enabled { get; set; }
        public DateTime? Created { get; internal set; }
        public DateTime? Updated { get; internal set; }

        public KeyVaultCertificatePolicy()
        {
            // At this time, KV Certificate only support these options
            // and the service requires these values to be passed when
            // any key properties are present.
            KeySize = 2048;
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
                ReuseKeyOnRenewal.HasValue ||
                Exportable.HasValue)
            {
                certificatePolicy.KeyProperties = new KeyProperties
                {
                    KeyType = Kty,
                    KeySize = KeySize,
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

        internal static KeyVaultCertificatePolicy FromCertificatePolicy(CertificatePolicy certificatePolicy)
        {
            return new KeyVaultCertificatePolicy
            {
                SecretContentType = certificatePolicy.SecretProperties == null ? null : certificatePolicy.SecretProperties.ContentType,
                Kty = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.KeyType,
                KeySize = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.KeySize,
                Exportable = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.Exportable,
                ReuseKeyOnRenewal = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.ReuseKey,
                SubjectName = certificatePolicy.X509CertificateProperties == null ? null : certificatePolicy.X509CertificateProperties.Subject,
                DnsNames = certificatePolicy.X509CertificateProperties == null || certificatePolicy.X509CertificateProperties.SubjectAlternativeNames == null ?
                    null : new List<string>(certificatePolicy.X509CertificateProperties.SubjectAlternativeNames.DnsNames),
                KeyUsage = certificatePolicy.X509CertificateProperties == null ? null : certificatePolicy.X509CertificateProperties.KeyUsage == null ? null : new List<string>(certificatePolicy.X509CertificateProperties.KeyUsage),
                Ekus = certificatePolicy.X509CertificateProperties == null ? null : certificatePolicy.X509CertificateProperties.Ekus == null ? null : new List<string>(certificatePolicy.X509CertificateProperties.Ekus),               
                ValidityInMonths = certificatePolicy.X509CertificateProperties == null ? null : certificatePolicy.X509CertificateProperties.ValidityInMonths,
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
    }
}

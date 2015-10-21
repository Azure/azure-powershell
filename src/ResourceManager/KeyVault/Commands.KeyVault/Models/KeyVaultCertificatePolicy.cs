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

using Microsoft.Azure.KeyVault;
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
        public List<string> Ekus { get; set; }
        public int? ValidityInMonths { get; set; }
        public string IssuerName { get; set; }
        public int? RenewAtNumberOfDaysBeforeExpiry { get; set; }
        public int? RenewAtPercentageLifetime { get; set; }
        public bool EmailOnly { get; set; }

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
                    Kty = Kty,
                    KeySize = KeySize,
                    Exportable = Exportable,
                    ReuseKey = ReuseKeyOnRenewal,
                };
            }

            if (!string.IsNullOrWhiteSpace(IssuerName))
            {
                certificatePolicy.IssuerReference = new IssuerReference { Name = IssuerName };
            }

            if (Enabled.HasValue)
            {
                certificatePolicy.Attributes = new CertificatePolicyAttributes
                {
                    Enabled = Enabled,
                };
            }

            if (!string.IsNullOrWhiteSpace(SubjectName) ||
                DnsNames != null ||
                Ekus != null ||
                ValidityInMonths.HasValue)
            {
                var x509CertificateProperties = new X509CertificateProperties
                {
                    Subject = SubjectName,
                };

                if (Ekus != null)
                {
                    x509CertificateProperties.Ekus = new string[Ekus.Count];
                    Ekus.CopyTo(x509CertificateProperties.Ekus, 0);
                }

                if (DnsNames != null)
                {
                    x509CertificateProperties.SubjectAlternativeNames = new SubjectAlternativeNames
                    {
                        DnsNames = new string[DnsNames.Count],
                    };

                    DnsNames.CopyTo(x509CertificateProperties.SubjectAlternativeNames.DnsNames, 0);
                }

                if (ValidityInMonths.HasValue)
                {
                    x509CertificateProperties.ValidityInMonths = ValidityInMonths.Value;
                }

                certificatePolicy.X509CertificateProperties = x509CertificateProperties;
            }

            if (RenewAtNumberOfDaysBeforeExpiry.HasValue ||
                RenewAtPercentageLifetime.HasValue)
            {
                if (RenewAtNumberOfDaysBeforeExpiry.HasValue &&
                    RenewAtPercentageLifetime.HasValue)
                {
                    throw new ArgumentException("Both RenewAtPercentageLifetime and RenewAtNumberOfDaysBeforeExpiry cannot be set.");
                }

                var lifetimeActions = new List<LifetimeAction>();
                var actionType = EmailOnly ? "EmailContacts" : "AutoRenew";

                if (RenewAtNumberOfDaysBeforeExpiry.HasValue)
                {
                    lifetimeActions.Add(
                        new LifetimeAction
                        {
                            Action = new Azure.KeyVault.Action { Type = actionType },
                            Trigger = new Trigger { DaysBeforeExpiry = RenewAtNumberOfDaysBeforeExpiry },
                        }
                    );
                }

                if (RenewAtPercentageLifetime.HasValue)
                {
                    lifetimeActions.Add(
                        new LifetimeAction
                        {
                            Action = new Azure.KeyVault.Action { Type = actionType },
                            Trigger = new Trigger { LifetimePercentage = RenewAtPercentageLifetime },
                        }
                    );
                }

                certificatePolicy.LifetimeActions = lifetimeActions;
            }

            return certificatePolicy;
        }

        internal static KeyVaultCertificatePolicy FromCertificatePolicy(CertificatePolicy certificatePolicy)
        {
            return new KeyVaultCertificatePolicy
            {
                SecretContentType = certificatePolicy.SecretProperties == null ? null : certificatePolicy.SecretProperties.ContentType,
                Kty = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.Kty,
                KeySize = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.KeySize,
                Exportable = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.Exportable,
                ReuseKeyOnRenewal = certificatePolicy.KeyProperties == null ? null : certificatePolicy.KeyProperties.ReuseKey,
                SubjectName = certificatePolicy.X509CertificateProperties == null ? null : certificatePolicy.X509CertificateProperties.Subject,
                DnsNames = certificatePolicy.X509CertificateProperties == null || certificatePolicy.X509CertificateProperties.SubjectAlternativeNames == null ?
                    null : new List<string>(certificatePolicy.X509CertificateProperties.SubjectAlternativeNames.DnsNames),
                Ekus = certificatePolicy.X509CertificateProperties == null ? null : new List<string>(certificatePolicy.X509CertificateProperties.Ekus),
                ValidityInMonths = certificatePolicy.X509CertificateProperties == null ? null : certificatePolicy.X509CertificateProperties.ValidityInMonths,
                IssuerName = certificatePolicy.IssuerReference == null ? null : certificatePolicy.IssuerReference.Name,
                RenewAtNumberOfDaysBeforeExpiry = certificatePolicy.LifetimeActions == null ? null : FindIntValueForAutoRenewAction(certificatePolicy.LifetimeActions, (trigger) => trigger.DaysBeforeExpiry),
                RenewAtPercentageLifetime = certificatePolicy.LifetimeActions == null ? null : FindIntValueForAutoRenewAction(certificatePolicy.LifetimeActions, (trigger) => trigger.LifetimePercentage),
                Enabled = certificatePolicy.Attributes == null ? null : certificatePolicy.Attributes.Enabled,
                Created = certificatePolicy.Attributes == null ? null : certificatePolicy.Attributes.Created,
                Updated = certificatePolicy.Attributes == null ? null : certificatePolicy.Attributes.Updated,
            };
        }

        private static int? FindIntValueForAutoRenewAction(IEnumerable<LifetimeAction> lifetimeActions, Func<Trigger, int?> intValueGetter)
        {
            var lifetimeAction = lifetimeActions.FirstOrDefault(x => x.Action.Type == AutoRenewAction && intValueGetter(x.Trigger).HasValue);

            if (lifetimeAction == null)
            {
                lifetimeAction = lifetimeActions.FirstOrDefault(x => x.Action.Type == EmailAction && intValueGetter(x.Trigger).HasValue);
                if (lifetimeAction == null)
                {
                    return null;
                }
            }

            return intValueGetter(lifetimeAction.Trigger);
        }

        private const string AutoRenewAction = "AutoRenew";
        private const string EmailAction = "EmailContacts";
    }
}

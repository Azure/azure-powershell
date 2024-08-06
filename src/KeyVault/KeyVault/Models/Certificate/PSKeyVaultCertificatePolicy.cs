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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using Track2CertificateSDK = Azure.Security.KeyVault.Certificates;

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
        public List<string> Emails { get; set; }
        public List<string> UserPrincipalNames { get; set; }
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

            // DnsNames could be an empty list
            DnsNames = dnsNames?.ToList();
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

        internal PSKeyVaultCertificatePolicy(string filePath)
        {
            JsonElement policyJson;
            if (".json".Equals(Path.GetExtension(filePath), StringComparison.OrdinalIgnoreCase))
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    string jsonContent = r.ReadToEnd();
                    policyJson = JsonDocument.Parse(jsonContent).RootElement;
                }
            }
            else
            {
                throw new AzPSArgumentException(string.Format(Resources.UnsupportedFileFormat, filePath), nameof(filePath));
            }

            if (policyJson.ValueKind == JsonValueKind.Null) return;

            foreach (JsonProperty item in policyJson.EnumerateObject())
            {
                switch (item.Name)
                {
                    case "key_props":
                    case "key_properties":
                        this.ReadKeyProperties(item.Value);
                        break;
                    case "secret_props":
                    case "secret_properties":
                        this.ReadSecretProperties(item.Value);
                        break;
                    case "x509_props":
                    case "x509_certificate_properties":
                        this.ReadX509CertificateProperties(item.Value);
                        break;
                    case "issuer":
                    case "issuer_parameters":
                        this.ReadIssuerProperties(item.Value);
                        break;
                    case "attributes":
                        this.ReadAttributesProperties(item.Value);
                        break;

                    case "lifetime_actions":
                        string actionType = null;
                        string triggerType = null;
                        int? triggerValue = null;

                        foreach (JsonElement item2 in item.Value.EnumerateArray())
                        {
                            if (item.Value.EnumerateArray().Count() > 1)
                                throw new AzPSArgumentException(string.Format("Json file property {0} exceed expected number 1.", item.Name), nameof(item.Name));
                            foreach (JsonProperty item3 in item2.EnumerateObject())
                            {
                                if (item3.Name == "trigger")
                                {
                                    foreach (JsonProperty item4 in item3.Value.EnumerateObject())
                                    {
                                        triggerType = item4.Name;
                                        triggerValue = item4.Value.GetInt32();
                                    }
                                }
                                else if (item3.Name == "action")
                                {
                                    foreach (JsonProperty item4 in item3.Value.EnumerateObject())
                                    {
                                        if (item4.Name == "action_type")
                                            actionType = item4.Value.GetString();
                                    }
                                }
                            }
                        }

                        if (actionType == ActionType.AutoRenew.ToString())
                        {
                            if (triggerType == "days_before_expiry")
                                this.RenewAtNumberOfDaysBeforeExpiry = triggerValue;
                            else if (triggerType == "lifetime_percentage")
                                this.RenewAtPercentageLifetime = triggerValue;
                        }
                        else if (actionType == ActionType.EmailContacts.ToString())
                        {
                            if (triggerType == "days_before_expiry")
                                this.EmailAtNumberOfDaysBeforeExpiry = triggerValue;
                            else if (triggerType == "lifetime_percentage")
                                this.EmailAtPercentageLifetime = triggerValue;
                        }
                        break;
                }
            }
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
                KeyUsage != null ||
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
                    x509CertificateProperties.Ekus = new List<string>(Ekus);
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
        internal bool HasSubjectAlternativeNames()
        {
            if ((DnsNames != null && DnsNames.Any())
                || (Emails != null && Emails.Any())
                || (UserPrincipalNames != null && UserPrincipalNames.Any()))
            {
                return true;
            }
            else
                return false;
        }

        internal Track2CertificateSDK.SubjectAlternativeNames SetSubjectAlternativeNames(Track2CertificateSDK.SubjectAlternativeNames SubjectAlternativeNames)
        {
            if (DnsNames != null && DnsNames.Any())
                foreach (var dnsName in DnsNames)
                    SubjectAlternativeNames.DnsNames.Add(dnsName);
            if (Emails != null && Emails.Any())
                foreach (var email in Emails)
                    SubjectAlternativeNames.Emails.Add(email);
            if (UserPrincipalNames != null && UserPrincipalNames.Any())
                foreach (var principalName in UserPrincipalNames)
                    SubjectAlternativeNames.UserPrincipalNames.Add(principalName);
            return SubjectAlternativeNames;
        }

        internal Track2CertificateSDK.CertificatePolicy ToTrack2CertificatePolicy()
        {
            Track2CertificateSDK.CertificatePolicy certificatePolicy;
            if (!string.IsNullOrWhiteSpace(IssuerName) || !string.IsNullOrWhiteSpace(SubjectName) || HasSubjectAlternativeNames())
            {
                if (!string.IsNullOrWhiteSpace(SubjectName) && HasSubjectAlternativeNames())
                {
                    Track2CertificateSDK.SubjectAlternativeNames subjectAlternativeNames = new Track2CertificateSDK.SubjectAlternativeNames();
                    subjectAlternativeNames = SetSubjectAlternativeNames(subjectAlternativeNames);
                    certificatePolicy = new Track2CertificateSDK.CertificatePolicy(IssuerName, SubjectName, subjectAlternativeNames);
                    
                }
                else if (!string.IsNullOrWhiteSpace(SubjectName))
                {
                    certificatePolicy = new Track2CertificateSDK.CertificatePolicy(IssuerName, SubjectName);
                }
                else if (HasSubjectAlternativeNames())
                {
                    Track2CertificateSDK.SubjectAlternativeNames subjectAlternativeNames = new Track2CertificateSDK.SubjectAlternativeNames();
                    subjectAlternativeNames = SetSubjectAlternativeNames(subjectAlternativeNames);
                    certificatePolicy = new Track2CertificateSDK.CertificatePolicy(IssuerName, subjectAlternativeNames);
                }
                else
                    certificatePolicy = new Track2CertificateSDK.CertificatePolicy(IssuerName, SubjectName);
            }
            else
            {
                certificatePolicy = new Track2CertificateSDK.CertificatePolicy();
            }
            certificatePolicy.ContentType = SecretContentType;
            if ( !string.IsNullOrEmpty(Kty) )
                certificatePolicy.KeyType = Kty;
            certificatePolicy.KeySize = KeySize;
            if (!string.IsNullOrEmpty(Curve))
                certificatePolicy.KeyCurveName = Curve;
            certificatePolicy.ReuseKey = ReuseKeyOnRenewal;
            certificatePolicy.Exportable = Exportable;
            certificatePolicy.CertificateTransparency = CertificateTransparency;
            if (!string.IsNullOrWhiteSpace(CertificateType))
                certificatePolicy.CertificateType = CertificateType;
            certificatePolicy.Enabled = Enabled;
            certificatePolicy.ValidityInMonths = ValidityInMonths;

            if (RenewAtNumberOfDaysBeforeExpiry.HasValue ||
                RenewAtPercentageLifetime.HasValue ||
                EmailAtNumberOfDaysBeforeExpiry.HasValue ||
                EmailAtPercentageLifetime.HasValue)
            {
                if ((RenewAtNumberOfDaysBeforeExpiry.HasValue ? 1 : 0) +
                    (RenewAtPercentageLifetime.HasValue ? 1 : 0) +
                    (EmailAtNumberOfDaysBeforeExpiry.HasValue ? 1 : 0) +
                    (EmailAtPercentageLifetime.HasValue ? 1 : 0) > 1)
                {
                    throw new ArgumentException("Only one of the values for RenewAtNumberOfDaysBeforeExpiry, RenewAtPercentageLifetime, EmailAtNumberOfDaysBeforeExpiry, EmailAtPercentageLifetime  can be set.");
                }

                if (RenewAtNumberOfDaysBeforeExpiry.HasValue)
                {
                    certificatePolicy.LifetimeActions.Add(
                        new Track2CertificateSDK.LifetimeAction(Track2CertificateSDK.CertificatePolicyAction.AutoRenew)
                        {
                            DaysBeforeExpiry = RenewAtNumberOfDaysBeforeExpiry
                        }
                    );
                }

                if (RenewAtPercentageLifetime.HasValue)
                {
                    certificatePolicy.LifetimeActions.Add(
                        new Track2CertificateSDK.LifetimeAction(Track2CertificateSDK.CertificatePolicyAction.AutoRenew)
                        {
                            LifetimePercentage = RenewAtPercentageLifetime
                        }
                    );
                }
                if (EmailAtNumberOfDaysBeforeExpiry.HasValue)
                {
                    certificatePolicy.LifetimeActions.Add(
                        new Track2CertificateSDK.LifetimeAction(Track2CertificateSDK.CertificatePolicyAction.EmailContacts)
                        {
                            DaysBeforeExpiry = EmailAtNumberOfDaysBeforeExpiry
                        }
                    );
                }

                if (EmailAtPercentageLifetime.HasValue)
                {
                    certificatePolicy.LifetimeActions.Add(
                        new Track2CertificateSDK.LifetimeAction(Track2CertificateSDK.CertificatePolicyAction.EmailContacts)
                        {
                            LifetimePercentage = EmailAtPercentageLifetime
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
                SecretContentType = certificatePolicy?.SecretProperties?.ContentType,
                Kty = certificatePolicy?.KeyProperties?.KeyType,
                KeySize = certificatePolicy?.KeyProperties?.KeySize,
                Curve = certificatePolicy?.KeyProperties?.Curve,
                Exportable = certificatePolicy?.KeyProperties?.Exportable,
                ReuseKeyOnRenewal = certificatePolicy?.KeyProperties?.ReuseKey,
                SubjectName = certificatePolicy?.X509CertificateProperties?.Subject,
                DnsNames = certificatePolicy?.X509CertificateProperties?.SubjectAlternativeNames?.DnsNames?.ToList(),
                KeyUsage = certificatePolicy?.X509CertificateProperties?.KeyUsage?.ToList(),
                Ekus = certificatePolicy?.X509CertificateProperties?.Ekus?.ToList(),               
                ValidityInMonths = certificatePolicy?.X509CertificateProperties?.ValidityInMonths,
                CertificateTransparency = certificatePolicy?.IssuerParameters?.CertificateTransparency,
                IssuerName = certificatePolicy?.IssuerParameters?.Name,
                CertificateType = certificatePolicy?.IssuerParameters?  .CertificateType,
                RenewAtNumberOfDaysBeforeExpiry = certificatePolicy.LifetimeActions == null ? null : FindIntValueForAutoRenewAction(certificatePolicy.LifetimeActions, (trigger) => trigger.DaysBeforeExpiry),
                RenewAtPercentageLifetime = certificatePolicy.LifetimeActions == null ? null : FindIntValueForAutoRenewAction(certificatePolicy.LifetimeActions, (trigger) => trigger.LifetimePercentage),
                EmailAtNumberOfDaysBeforeExpiry = certificatePolicy.LifetimeActions == null ? null : FindIntValueForEmailAction(certificatePolicy.LifetimeActions, (trigger) => trigger.DaysBeforeExpiry),
                EmailAtPercentageLifetime = certificatePolicy.LifetimeActions == null ? null : FindIntValueForEmailAction(certificatePolicy.LifetimeActions, (trigger) => trigger.LifetimePercentage),
                Enabled = certificatePolicy?.Attributes?.Enabled,
                Created = certificatePolicy?.Attributes?.Created,
                Updated = certificatePolicy?.Attributes?.Updated,
            };
        }

        internal static PSKeyVaultCertificatePolicy FromTrack2CertificatePolicy(Track2CertificateSDK.CertificatePolicy certificatePolicy)
        {
            return new PSKeyVaultCertificatePolicy
            {
                SecretContentType = certificatePolicy.ContentType?.ToString(),
                Kty = certificatePolicy.KeyType?.ToString(),
                KeySize = certificatePolicy.KeySize,
                Curve = certificatePolicy.KeyCurveName?.ToString(),
                Exportable = certificatePolicy.Exportable,
                ReuseKeyOnRenewal = certificatePolicy.ReuseKey,
                SubjectName = certificatePolicy.Subject,
                DnsNames = certificatePolicy.SubjectAlternativeNames?.DnsNames?.ToList(),
                Emails = certificatePolicy.SubjectAlternativeNames?.Emails?.ToList(),
                UserPrincipalNames = certificatePolicy.SubjectAlternativeNames?.UserPrincipalNames?.ToList(),
                KeyUsage =  certificatePolicy?.KeyUsage?.Select(keyUsage => keyUsage.ToString())?.ToList(),
                Ekus = certificatePolicy?.EnhancedKeyUsage?.ToList(),
                ValidityInMonths = certificatePolicy.ValidityInMonths,
                CertificateTransparency = certificatePolicy.CertificateTransparency,
                IssuerName = certificatePolicy.IssuerName,
                CertificateType = certificatePolicy.CertificateType,
                RenewAtNumberOfDaysBeforeExpiry = certificatePolicy.LifetimeActions == null ? null : FindIntValueForAutoRenewAction(certificatePolicy.LifetimeActions),
                RenewAtPercentageLifetime = certificatePolicy.LifetimeActions == null ? null : FindIntValueForAutoRenewAction(certificatePolicy.LifetimeActions),
                EmailAtNumberOfDaysBeforeExpiry = certificatePolicy.LifetimeActions == null ? null : FindIntValueForEmailAction(certificatePolicy.LifetimeActions),
                EmailAtPercentageLifetime = certificatePolicy.LifetimeActions == null ? null : FindIntValueForEmailAction(certificatePolicy.LifetimeActions),
                Enabled = certificatePolicy.Enabled,
                Created = certificatePolicy.CreatedOn.HasValue ? certificatePolicy.CreatedOn.Value.DateTime : (DateTime?)null,
                Updated = certificatePolicy.UpdatedOn.HasValue ? certificatePolicy.UpdatedOn.Value.DateTime : (DateTime?)null,
            };
        }
        
        private void ReadKeyProperties(JsonElement json)
        {
            if (json.ValueKind == JsonValueKind.Null) return;

            foreach (JsonProperty item in json.EnumerateObject())
            {
                switch (item.Name)
                {
                    case "kty":
                    case "key_type":
                        Kty = item.Value.GetString();
                        break;
                    case "reuse_key":
                        ReuseKeyOnRenewal = item.Value.GetBoolean();
                        break;
                    case "exportable":
                        Exportable = item.Value.GetBoolean();
                        break;
                    case "crv":
                        Curve = item.Value.GetString();
                        break;
                    case "key_size":
                        KeySize = item.Value.GetInt32();
                        break;
                }
            }
        }
        
        private void ReadSecretProperties(JsonElement json)
        {
            if (json.ValueKind == JsonValueKind.Null) return;

            if (json.TryGetProperty("contentType", out var value1))
            {
                SecretContentType = value1.GetString();
            }
            if (json.TryGetProperty("content_type", out var value2))
            {
                SecretContentType = value2.GetString();
            }
        }

        private void ReadSubjectAlternativeNames(JsonProperty json)
        {
            if (json.Value.ValueKind == JsonValueKind.Null) return;

            foreach (JsonProperty item in json.Value.EnumerateObject())
            {
                if (item.Value.ValueKind == JsonValueKind.Null) continue;
                switch (item.Name)
                {
                    case "dns_names":
                        DnsNames = new List<string>();
                        foreach (JsonElement item2 in item.Value.EnumerateArray())
                        {
                            DnsNames.Add(item2.GetString());
                        }
                        break;
                    case "emails":
                        Emails = new List<string>();
                        foreach (JsonElement item2 in item.Value.EnumerateArray())
                        {
                            Emails.Add(item2.GetString());
                        }
                        break;
                    case "upns":
                        UserPrincipalNames = new List<string>();
                        foreach (JsonElement item2 in item.Value.EnumerateArray())
                        {
                            UserPrincipalNames.Add(item2.GetString());
                        }
                        break;
                }
            }
        }

        private void ReadX509CertificateProperties(JsonElement json)
        {
            foreach (JsonProperty item in json.EnumerateObject())
            {
                if (item.Value.ValueKind == JsonValueKind.Null) continue;

                switch (item.Name)
                {
                    case "subject":
                        SubjectName = item.Value.GetString();
                        break;
                    case "sans":
                    case "subject_alternative_names":
                        var SubjectAlternativeNames = new Track2CertificateSDK.SubjectAlternativeNames();
                        ReadSubjectAlternativeNames(item);
                        break;
                    case "key_usage":
                        KeyUsage = new List<string>();
                        foreach (JsonElement item2 in item.Value.EnumerateArray())
                        {
                            KeyUsage.Add(item2.GetString());
                        }
                        break;
                    case "ekus":
                        Ekus = new List<string>();
                        foreach (JsonElement item3 in item.Value.EnumerateArray())
                        {
                            Ekus.Add(item3.GetString());
                        }

                        break;
                    case "validity_months":
                    case "validity_in_months":
                        ValidityInMonths = item.Value.GetInt32();
                        break;
                }
            }
        }

        private void ReadIssuerProperties(JsonElement json)
        {
            foreach (JsonProperty item in json.EnumerateObject())
            {
                switch (item.Name)
                {
                    case "cert_transparency":
                        CertificateTransparency = item.Value.GetBoolean();
                        break;
                    
                    case "cty":
                        CertificateType = item.Value.GetString();
                        break;

                    case "name":
                        IssuerName = item.Value.GetString();
                        break;
                }
            }
        }

        private void ReadAttributesProperties(JsonElement json)
        {
            if (json.ValueKind == JsonValueKind.Null) return;
            foreach (JsonProperty item in json.EnumerateObject())
            {
                switch (item.Name)
                {
                    case "enabled":
                        Enabled = item.Value.GetBoolean();
                        break;
                    case "created":
                        Created = DateTimeOffset.FromUnixTimeSeconds(item.Value.GetInt64()).DateTime;
                        break;
                    case "updated":
                        Updated = DateTimeOffset.FromUnixTimeSeconds(item.Value.GetInt64()).DateTime;
                        break;
                }
            }
        }


        internal static PSKeyVaultCertificatePolicy FromJsonFile(string filePath)
        {
            return new PSKeyVaultCertificatePolicy(filePath);
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

        private static int? FindIntValueForAutoRenewAction(IList<Track2CertificateSDK.LifetimeAction> lifetimeActions)
        {
            var lifetimeAction = 
                lifetimeActions.FirstOrDefault(x => string.IsNullOrEmpty(x.Action.ToString()) && 0 == string.Compare(x.Action.ToString(), Track2CertificateSDK.CertificatePolicyAction.AutoRenew.ToString(), true)
                                                && (x.DaysBeforeExpiry.HasValue || x.LifetimePercentage.HasValue));
            return lifetimeAction == null ? null : (lifetimeAction.DaysBeforeExpiry ?? lifetimeAction.LifetimePercentage);
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

        private static int? FindIntValueForEmailAction(IList<Track2CertificateSDK.LifetimeAction> lifetimeActions)
        {
            var lifetimeAction =
                lifetimeActions.FirstOrDefault(x => !string.IsNullOrEmpty(x.Action.ToString()) && 0 == string.Compare(x.Action.ToString(), Track2CertificateSDK.CertificatePolicyAction.EmailContacts.ToString(), true)
                                                && (x.DaysBeforeExpiry.HasValue || x.LifetimePercentage.HasValue));
            return lifetimeAction == null ? null : (lifetimeAction.DaysBeforeExpiry ?? lifetimeAction.LifetimePercentage);
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

        public override string ToString()
        {
            if (this == null) return string.Empty;

            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendFormat("{0, -15}: {1}{2}", "Secret Content Type", SecretContentType, Environment.NewLine);
            sb.AppendFormat("{0, -15}: {1}{2}", "Issuer Name", IssuerName, Environment.NewLine);
            sb.AppendFormat("{0, -15}: {1}{2}", "Created On", Created, Environment.NewLine);
            sb.AppendFormat("{0, -15}: {1}{2}", "Updated On", Updated, Environment.NewLine);
            sb.AppendLine("...");
            return sb.ToString();
        }
    }
}

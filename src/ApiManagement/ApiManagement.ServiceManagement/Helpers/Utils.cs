//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using Newtonsoft.Json.Linq;

    public class Utils
    {
        static readonly Regex ApiVersionSetArmIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/apiVersionSets/(?<apiVersionSetId>[^/]+)", RegexOptions.IgnoreCase);

        static readonly Regex LoggerArmIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/loggers/(?<loggerId>[^/]+)", RegexOptions.IgnoreCase);

        static readonly Regex UserArmIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/users/(?<userId>[^/]+)", RegexOptions.IgnoreCase);

        static readonly Regex ProductArmIdRegex = new Regex(@"(.*?)/providers/microsoft.apimanagement/service/(?<serviceName>[^/]+)/products/(?<productId>[^/]+)", RegexOptions.IgnoreCase);

        public static string GetApiIdFullPath(string apiId, string apiRevision)
        {
            if (!string.IsNullOrEmpty(apiId) && !string.IsNullOrEmpty(apiRevision))
            {
                return apiId.ApiRevisionIdentifierFullPath(apiRevision);
            }
            else if (!string.IsNullOrEmpty(apiId))
            {
                return $"/apis/{apiId}";
            }

            return null;
        }

        public static string GetApiVersionIdFullPath(string apiVersionId)
        {
            if (string.IsNullOrEmpty(apiVersionId))
            {
                return null;
            }

            var match = ApiVersionSetArmIdRegex.Match(apiVersionId);
            if (match.Success)
            {
                // its already Arm Id.
                return apiVersionId;
            }

            return $"/apiVersionSets/{apiVersionId}";
        }

        public static string GetLoggerIdFullPath(string loggerId)
        {
            if (string.IsNullOrEmpty(loggerId))
            {
                return null;
            }

            var match = LoggerArmIdRegex.Match(loggerId);
            if (match.Success)
            {
                // its already Arm Id.
                return loggerId;
            }

            return $"/loggers/{loggerId}";
        }

        public static string GetLoggerIdentifier(string loggerArmId)
        {
            if (loggerArmId == null)
            {
                return null;
            }

            var match = LoggerArmIdRegex.Match(loggerArmId);
            if (match.Success)
            {
                var loggerNameGroup = match.Groups["loggerId"];
                if (loggerNameGroup != null && loggerNameGroup.Success)
                {
                    return loggerNameGroup.Value;
                }
            }

            return null;
        }

        public static string GetUserIdFullPath(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }

            var match = UserArmIdRegex.Match(userId);
            if (match.Success)
            {
                // its already Arm Id.
                return userId;
            }

            return $"/users/{userId}";
        }

        public static string GetProductIdFullPath(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return null;
            }

            var match = ProductArmIdRegex.Match(productId);
            if (match.Success)
            {
                // its already Arm Id.
                return productId;
            }

            return $"/products/{productId}";
        }

        public static IDictionary<string, object> ToBackendProperties(BackendTlsProperties tlsProperties)
        {
            if (tlsProperties == null)
            {
                return null;
            }

            var psTlsProperties = new Dictionary<string, object>();
            if (tlsProperties.ValidateCertificateChain.HasValue)
            {
                psTlsProperties.Add("skipCertificateChainValidation", !tlsProperties.ValidateCertificateChain.Value);
            }

            if (tlsProperties.ValidateCertificateName.HasValue)
            {
                psTlsProperties.Add("skipCertificateNameValidation", !tlsProperties.ValidateCertificateName.Value);
            }

            return psTlsProperties;
        }

        public static Dictionary<string, IList<string>> HashTableToDictionary(Hashtable table)
        {
            if (table == null)
            {
                return null;
            }

            var result = new Dictionary<string, IList<string>>();
            foreach (var entry in table.Cast<DictionaryEntry>())
            {
                var entryValue = entry.Value as object[];
                if (entryValue == null)
                {
                    throw new ArgumentException(
                        string.Format(CultureInfo.InvariantCulture,
                            "Invalid input type specified for Key '{0}', expected string[]",
                            entry.Key));
                }
                result.Add(entry.Key.ToString(), entryValue.Select(i => i.ToString()).ToList());
            }

            return result;
        }

        public static IList<X509CertificateName> HashTableToX509CertificateName(Hashtable certificates)
        {
            if (certificates == null)
            {
                return null;
            }

            var result = new List<X509CertificateName>();
            foreach (var keyEntry in certificates.Cast<DictionaryEntry>())
            {
                result.Add(new X509CertificateName()
                {
                    Name = keyEntry.Key.ToString(),
                    IssuerCertificateThumbprint = keyEntry.Value.ToString()
                });
            }

            return result.ToArray();
        }

        public static Hashtable X509CertificateToHashTable(IEnumerable<X509CertificateName> certificates)
        {
            if (certificates == null || !certificates.Any())
            {
                return null;
            }

            var result = new Hashtable();
            foreach (var keyEntry in certificates)
            {
                result.Add(keyEntry.Name, keyEntry.IssuerCertificateThumbprint);
            }

            return result;
        }

        public static Hashtable DictionaryToHashTable(IDictionary<string, IList<string>> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            var result = new Hashtable();
            foreach (var keyEntry in dictionary.Keys)
            {
                var keyValue = dictionary[keyEntry];

                result.Add(keyEntry, keyValue.Cast<object>().ToArray());
            }

            return result;
        }       

        public static AuthenticationSettingsContract ToAuthenticationSettings(PsApiManagementApi psApiManagementApi)
        {
            if (psApiManagementApi == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(psApiManagementApi.AuthorizationServerId) ||
                !string.IsNullOrEmpty(psApiManagementApi.AuthorizationScope))
            {
                var settings = new AuthenticationSettingsContract()
                {
                    OAuth2 = new OAuth2AuthenticationSettingsContract()
                    {
                        AuthorizationServerId = psApiManagementApi.AuthorizationServerId,
                        Scope = psApiManagementApi.AuthorizationScope
                    }
                };

                return settings;
            }
            else if (!string.IsNullOrWhiteSpace(psApiManagementApi.OpenidProviderId) ||
                (psApiManagementApi.BearerTokenSendingMethod != null && psApiManagementApi.BearerTokenSendingMethod.Any()))
            {
                var settings = new AuthenticationSettingsContract()
                {
                    Openid = new OpenIdAuthenticationSettingsContract()
                    {
                        OpenidProviderId = psApiManagementApi.OpenidProviderId,
                        BearerTokenSendingMethods = psApiManagementApi.BearerTokenSendingMethod
                    }
                };

                return settings;
            }

            return null;
        }

        public static SubscriptionKeyParameterNamesContract ToSubscriptionKeyParameterNamesContract(PsApiManagementApi psApiManagementApi)
        {
            if (psApiManagementApi == null ||
                (string.IsNullOrWhiteSpace(psApiManagementApi.SubscriptionKeyHeaderName) &&
                string.IsNullOrEmpty(psApiManagementApi.SubscriptionKeyQueryParamName)))
            {
                return null;
            }

            var subscriptionKeyParameters = new SubscriptionKeyParameterNamesContract()
            {
                Header = psApiManagementApi.SubscriptionKeyHeaderName,
                Query = psApiManagementApi.SubscriptionKeyQueryParamName
            };

            return subscriptionKeyParameters;
        }

        public static ApiLicenseInformation ToLicenseInformation(PsApiManagementApi psApiManagementApi)
        {
            if (psApiManagementApi == null ||
                (string.IsNullOrWhiteSpace(psApiManagementApi.LicenseUrl) &&
                string.IsNullOrEmpty(psApiManagementApi.LicenseName)))
            {
                return null;
            }

            var licenseParameters = new ApiLicenseInformation()
            {
                Name = psApiManagementApi.LicenseName,
                Url = psApiManagementApi.LicenseUrl
            };

            return licenseParameters;
        }

        public static ApiContactInformation ToContactInformation(PsApiManagementApi psApiManagementApi)
        {
            if (psApiManagementApi == null ||
                (string.IsNullOrWhiteSpace(psApiManagementApi.ContactEmail) &&
                string.IsNullOrWhiteSpace(psApiManagementApi.ContactName) &&
                string.IsNullOrEmpty(psApiManagementApi.ContactUrl)))
            {
                return null;
            }

            var contactParameters = new ApiContactInformation()
            {
                Email = psApiManagementApi.ContactEmail,
                Name = psApiManagementApi.ContactName,
                Url = psApiManagementApi.ContactUrl
            };

            return contactParameters;
        }

        public static string TrimApiResourceIdentifier(string armApiId)
        {
            if (string.IsNullOrEmpty(armApiId))
            {
                return null;
            }

            var apiIdArrary = armApiId.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            return apiIdArrary.Last();
        }

        public static string GetPolicyContentFormat(string format, bool uriFormat)
        {
            if (string.IsNullOrEmpty(format))
            {
                return uriFormat ? PolicyContentFormat.XmlLink : PolicyContentFormat.Xml;
            }

            switch (format)
            {
                case Constants.XmlPolicyFormat: return uriFormat ? PolicyContentFormat.XmlLink : PolicyContentFormat.Xml;
                case Constants.RawXmlPolicyFormat: return uriFormat ? PolicyContentFormat.RawxmlLink : PolicyContentFormat.Rawxml;
                case Constants.OldDefaultPolicyFormat: return uriFormat ? PolicyContentFormat.XmlLink : PolicyContentFormat.Xml;
                case Constants.OldNonEscapedXmlPolicyFormat: return uriFormat ? PolicyContentFormat.RawxmlLink : PolicyContentFormat.Rawxml;
                default: return uriFormat ? PolicyContentFormat.XmlLink : PolicyContentFormat.Xml;
            }
        }

        public static string GetAlwaysLog(string alwaysLog)
        {
            switch(alwaysLog)
            {
                case Constants.AllErrors: return "allErrors";
                default: return alwaysLog;
            }
        }

        public static string GetSamplingType(string samplingType)
        {
            if (string.IsNullOrEmpty(samplingType))
            {
                return null;
            }

            if (samplingType.Equals(Constants.FixedSamplingType, StringComparison.OrdinalIgnoreCase))
            {
                return Constants.FixedSamplingType.ToLower();
            }

            return samplingType;
        }

        public static string GetDiagnosticId(string diagnosticId)
        {
            if (string.IsNullOrEmpty(diagnosticId))
            {
                return diagnosticId;
            }

            switch(diagnosticId)
            {
                case Constants.ApplicationInsightsDiagnostics: return Constants.ApplicationInsightsDiagnostics.ToLower();
                case Constants.AzureMonitorDiagnostic: return Constants.AzureMonitorDiagnostic.ToLower();
                default: return diagnosticId.ToLower();
            }
        }

        public static string GetApiSchemaContentTypeFromPsSchemaContentType(string schemaContentType)
        {
            switch (schemaContentType.Trim())
            {
                case Constants.SwaggerDefinitions: return ApiSchemaContentType.SwaggerDefinition;
                case Constants.OpenApiComponents: return ApiSchemaContentType.OpenApiComponents;
                case Constants.XsdSchema: return ApiSchemaContentType.XsdSchema;
                case Constants.WadlGrammar: return ApiSchemaContentType.WadlGrammar;
            }

            // else we return the content-Type which user specified
            return schemaContentType.ToLowerInvariant().Trim();
        }

        public static string GetPsSchemaContentTypeFromApiSchemaContentType(string contentType)
        {
            switch (contentType.ToLower().Trim())
            {
                case ApiSchemaContentType.SwaggerDefinition : return Constants.SwaggerDefinitions;
                case ApiSchemaContentType.OpenApiComponents : return Constants.OpenApiComponents;
                case ApiSchemaContentType.XsdSchema : return Constants.XsdSchema;
                case ApiSchemaContentType.WadlGrammar : return Constants.WadlGrammar;
            }

            // else we return the content-Type which user specified
            return contentType.ToLowerInvariant().Trim();
        }

        public static string GetSchemaDocumentValue(SchemaContract schemaContract)
        {
            if (!string.IsNullOrEmpty(schemaContract.Value))
            {
                return schemaContract.Value;
            }
            else
            {
                try
                {
                    return (schemaContract.Definitions as JObject)?.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unable for parse Schema Document for ContentType {schemaContract.ContentType}.", ex);
                }
            }
        }

        public class ApiSchemaContentType
        {
            public const string SwaggerDefinition = "application/vnd.ms-azure-apim.swagger.definitions+json";

            public const string OpenApiComponents = "application/vnd.oai.openapi.components+json";

            public const string XsdSchema = "application/vnd.ms-azure-apim.xsd+xml";

            public const string WadlGrammar = "application/vnd.ms-azure-apim.wadl.grammars+xml";
        }
    }
}

// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;

namespace Microsoft.Azure.Commands.Cdn.AfdHelpers
{
    public static class AfdUtilities
    {
        public static bool IsValuePresent(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static string GetResourceName(this ResourceIdentifier resourceId, string resourceType)
        {
            string[] splitNames = resourceId.ToString().Split(new[] { '/' });

            for (int i = 0; i < splitNames.Length; i++)
            {
                if (splitNames[i].Equals(resourceType, StringComparison.OrdinalIgnoreCase))
                {
                    return splitNames[i + 1];
                }
            }

            return string.Empty;
        }
 
        public static Sku GenerateAfdProfileSku(string sku)
        {
            string lowercaseSku = sku.ToLower();

            Sku afdSku = new Sku();

            switch(lowercaseSku)
            {
                case "premium_azurefrontdoor":
                    afdSku.Name = AfdSkuConstants.PremiumAzureFrontDoor;
                    break;

                case "standard_azurefrontdoor":
                    afdSku.Name = AfdSkuConstants.StandardAzureFrontDoor;
                    break;

                default:
                    afdSku = null;
                    break;
            }

            return afdSku;
        }

        public static bool IsAfdProfile(PSAfdProfile psAfdProfile)
        {
            if (psAfdProfile.Sku == AfdSkuConstants.PremiumAzureFrontDoor || psAfdProfile.Sku == AfdSkuConstants.StandardAzureFrontDoor)
            {
                return true;
            }

            return false;
        }

        public static HealthProbeRequestType CreateProbeRequestType(string probeRequestType)
        {
            string lowercaseProbeRequestType = probeRequestType.ToLower();

            HealthProbeRequestType healthProbeRequestType;

            switch (lowercaseProbeRequestType)
            {
                case "get":
                    healthProbeRequestType = HealthProbeRequestType.GET;
                    break;
                case "head":
                    healthProbeRequestType = HealthProbeRequestType.HEAD;
                    break;
                case "notset":
                    healthProbeRequestType = HealthProbeRequestType.NotSet;
                    break;
                default:
                    throw new Exception($"{probeRequestType} is not a valid probe request type. Please use GET, HEAD, or NotSet.");
            }

            return healthProbeRequestType;
        }

        public static ProbeProtocol CreateProbeProtocol(string probeProtocol)
        {
            string lowercaseProbeProtocol = probeProtocol.ToLower();

            ProbeProtocol probeProtocolEnum;

            switch(lowercaseProbeProtocol)
            {
                case "http":
                    probeProtocolEnum = ProbeProtocol.Http;
                    break;
                case "https":
                    probeProtocolEnum = ProbeProtocol.Https;
                    break;
                case "notset":
                    probeProtocolEnum = ProbeProtocol.NotSet;
                    break;
                default:
                    throw new Exception($"{probeProtocol} is not valid probe protocol. Please use Http, Https, or NotSet.");
            }

            return probeProtocolEnum;
        }

        // determine if needed 
        public static ResponseBasedDetectedErrorTypes CreateResponseBasedDetectedErrorTypes(string responseBasedDetectedErrorTypes)
        {
            string lowercaseResponseBasedDetectedErrorTypes = responseBasedDetectedErrorTypes.ToLower();

            ResponseBasedDetectedErrorTypes responseBasedDetectedErrorTypesEnum;

            switch (lowercaseResponseBasedDetectedErrorTypes)
            {
                case "tcpandhttperrors":
                    responseBasedDetectedErrorTypesEnum = ResponseBasedDetectedErrorTypes.TcpAndHttpErrors;
                    break;
                case "tcperrorsonly":
                    responseBasedDetectedErrorTypesEnum = ResponseBasedDetectedErrorTypes.TcpErrorsOnly;
                    break;
                case "none":
                    responseBasedDetectedErrorTypesEnum = ResponseBasedDetectedErrorTypes.None;
                    break;
                default:
                    throw new Exception($"{responseBasedDetectedErrorTypes} is not a valid error type. Please use TcpAndHttpErrors, TcpErrorsOnly, or None.");   
            }

            return responseBasedDetectedErrorTypesEnum;
        }

        public static AfdQueryStringCachingBehavior CreateQueryStringCachingBehavior(string queryStringCachingBehavior)
        {
            string lowercaseQueryStringCachingBehavior = queryStringCachingBehavior.ToLower();

            AfdQueryStringCachingBehavior queryStringCachingBehaviorEnum;

            switch (lowercaseQueryStringCachingBehavior)
            {
                case "ignorequerystring":
                    queryStringCachingBehaviorEnum = AfdQueryStringCachingBehavior.IgnoreQueryString;
                    break;
                case "usequerystring":
                    queryStringCachingBehaviorEnum = AfdQueryStringCachingBehavior.UseQueryString;
                    break;
                case "notset":
                    queryStringCachingBehaviorEnum = AfdQueryStringCachingBehavior.NotSet;
                    break;
                default:
                    throw new Exception($"{queryStringCachingBehavior} is not a valid query string caching behavior type. Please use NotSet, UseQueryString, or IgnoreQueryString.");
            }

            return queryStringCachingBehaviorEnum;
        }

        public static string CreateHttpsRedirect(string httpsRedirect)
        {
            string lowercaseHttpsRedirect = httpsRedirect.ToLower();

            string httpsRedirectState = String.Empty;

            switch (lowercaseHttpsRedirect)
            {
                case "enabled":
                    httpsRedirectState = "Enabled";
                    break;
                case "disabled":
                    httpsRedirectState = "Disabled";
                    break;
                default:
                    throw new Exception($"{httpsRedirect} is not valid. Please use Enabled or Disbaled.");
            }

            return httpsRedirectState;
        }

        public static string CreateForwardingProtocol(string forwadingProtocol)
        {
            string lowercaseForwardingProtocol = forwadingProtocol.ToLower();

            string forwardingProtocolActual = String.Empty;

            switch (lowercaseForwardingProtocol)
            {
                case "httponly":
                    forwardingProtocolActual = "HttpOnly";
                    break;
                case "httpsonly":
                    forwardingProtocolActual = "HttpsOnly";
                    break;
                case "matchrequest":
                    forwardingProtocolActual = "MatchRequest";
                    break;
                default:
                    throw new Exception($"{forwadingProtocol} is not valid. Please use HttpOnly, HttpsOnly, or MatchRequest.");
            }

            return forwardingProtocolActual;
        }

        public static AfdMinimumTlsVersion CreateMinimumTlsVersion(string tlsVersion)
        {
            string lowercaseTlsVersion = tlsVersion.ToLower();

            switch (lowercaseTlsVersion)
            {
                case "tls10":
                    return AfdMinimumTlsVersion.TLS10;
                case "tls12":
                    return AfdMinimumTlsVersion.TLS12;
                default:
                    throw new Exception($"The TLS version {tlsVersion} is not valid. Accepted values TLS10 or TLS12.");
            }
        }
    }
}

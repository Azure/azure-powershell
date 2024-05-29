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
//
using System;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    /// <summary>
    /// Defines fields exposing the well known authority hosts for the Azure Public Cloud and sovereign clouds.
    /// </summary>
    public static class AzureAuthorityHosts
    {
        private const string AzurePublicCloudHostUrl = "https://login.microsoftonline.com/";
        private const string AzureChinaHostUrl = "https://login.chinacloudapi.cn/";
        private const string AzureGermanyHostUrl = "https://login.microsoftonline.de/";
        private const string AzureGovernmentHostUrl = "https://login.microsoftonline.us/";
        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure Public Cloud.
        /// </summary>
        public static Uri AzurePublicCloud { get; } = new Uri(AzurePublicCloudHostUrl);

        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure China Cloud.
        /// </summary>
        public static Uri AzureChina { get; } = new Uri(AzureChinaHostUrl);

        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure German Cloud.
        /// </summary>
        public static Uri AzureGermany { get; } = new Uri(AzureGermanyHostUrl);

        /// <summary>
        /// The host of the Azure Active Directory authority for tenants in the Azure US Government Cloud.
        /// </summary>
        public static Uri AzureGovernment { get; } = new Uri(AzureGovernmentHostUrl);

        internal static Uri GetDefault()
        {
            if (EnvironmentVariables.AuthorityHost != null)
            {
                return new Uri(EnvironmentVariables.AuthorityHost);
            }

            return AzurePublicCloud;
        }

        internal static string GetDefaultScope(Uri authorityHost)
        {
            switch (authorityHost.AbsoluteUri)
            {
                case AzurePublicCloudHostUrl:
                    // The double slash is intentional for public cloud.
                    return "https://management.azure.com//.default";
                case AzureChinaHostUrl:
                    return "https://management.chinacloudapi.cn/.default";
                case AzureGermanyHostUrl:
                    return "https://management.microsoftazure.de/.default";
                case AzureGovernmentHostUrl:
                    return "https://management.usgovcloudapi.net/.default";
                default:
                    return null;
            }
        }

        internal static Uri GetDeviceCodeRedirectUri(Uri authorityHost)
        {
            return new Uri(authorityHost, "/common/oauth2/nativeclient");
        }
    }
}

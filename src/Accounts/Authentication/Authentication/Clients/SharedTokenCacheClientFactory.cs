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

using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.WindowsAzure.Commands.Common;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public static class SharedTokenCacheClientFactory
    {
        private static readonly string PowerShellClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private static readonly string CacheFileName = "msal.cache";
        private static readonly string CacheFilePath =
            Path.Combine(SharedUtilities.GetUserRootDirectory(), ".IdentityService", CacheFileName);

        private static MsalCacheHelper InitializeCacheHelper(string clientId)
        {
            var builder = new StorageCreationPropertiesBuilder(Path.GetFileName(CacheFilePath), Path.GetDirectoryName(CacheFilePath), clientId);
            builder = builder.WithMacKeyChain(serviceName: "Microsoft.Developer.IdentityService", accountName: "MSALCache");
            builder = builder.WithLinuxKeyring(
                schemaName: "msal.cache",
                collection: "default",
                secretLabel: "MSALCache",
                attribute1: new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService"),
                attribute2: new KeyValuePair<string, string>("MsalClientVersion", "1.0.0.0"));
            var storageCreationProperties = builder.Build();
            return MsalCacheHelper.CreateAsync(storageCreationProperties).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public static IPublicClientApplication CreatePublicClient(
            string clientId = null,
            string authority = null,
            string redirectUri = null)
        {
            clientId = clientId ?? PowerShellClientId;
            var builder = PublicClientApplicationBuilder.Create(clientId);
            if (!string.IsNullOrEmpty(authority))
            {
                builder = builder.WithAuthority(authority);
            }

            if (!string.IsNullOrEmpty(redirectUri))
            {
                builder = builder.WithRedirectUri(redirectUri);
            }

            var client = builder.Build();
            var cacheHelper = InitializeCacheHelper(clientId);
            cacheHelper.RegisterCache(client.UserTokenCache);
            return client;
        }

        public static IConfidentialClientApplication CreateConfidentialClient(
            string clientId = null,
            string authority = null,
            string redirectUri = null,
            X509Certificate2 certificate = null,
            SecureString clientSecret = null)
        {
            clientId = clientId ?? PowerShellClientId;
            var builder = ConfidentialClientApplicationBuilder.Create(clientId);
            if (!string.IsNullOrEmpty(authority))
            {
                builder = builder.WithAuthority(authority);
            }

            if (!string.IsNullOrEmpty(redirectUri))
            {
                builder = builder.WithRedirectUri(redirectUri);
            }

            if (certificate != null)
            {
                builder = builder.WithCertificate(certificate);
            }

            if (clientSecret != null)
            {
                builder = builder.WithClientSecret(ConversionUtilities.SecureStringToString(clientSecret));
            }

            var client = builder.Build();
            var cacheHelper = InitializeCacheHelper(clientId);
            cacheHelper.RegisterCache(client.UserTokenCache);
            return client;
        }
    }
}

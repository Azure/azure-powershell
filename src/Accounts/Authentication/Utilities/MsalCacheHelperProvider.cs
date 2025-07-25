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
using Microsoft.Identity.Client.Extensions.Msal;

using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class MsalCacheHelperProvider
    {
        private static MsalCacheHelper MsalCacheHelper;
        private static object ObjectLock = new object();

        private const string AzureIdentityTokenCacheNameSuffixCae = ".cae";
        private const string AzureIdentityTokenCacheNameSuffixNoCae = ".nocae";

        public static string LegacyTokenCacheName { get; } = "msal.cache";

        public static string MsalTokenCachePath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ".IdentityService");

        public static string GetTokenCacheName(string name, bool caeEnabled)
        {
            return name + (caeEnabled ? AzureIdentityTokenCacheNameSuffixCae : AzureIdentityTokenCacheNameSuffixNoCae);
        }

        public static string GetTokenCacheNameWithoutSuffix(string name)
        {
            return name.Replace(MsalCacheHelperProvider.AzureIdentityTokenCacheNameSuffixCae, string.Empty)
                .Replace(MsalCacheHelperProvider.AzureIdentityTokenCacheNameSuffixNoCae, string.Empty);
        }

        public static void Reset()
        {
            if (MsalCacheHelper != null)
            {
                lock (ObjectLock)
                {
                    MsalCacheHelper = null;
                }
            }
        }
        public static MsalCacheHelper GetCacheHelper(string tokenCacheName)
        {
            if (string.IsNullOrEmpty(tokenCacheName))
            {
                throw new AzPSArgumentNullException($"{nameof(tokenCacheName)} cannot be null", nameof(tokenCacheName));
            }
            var keyRingSchema = GetTokenCacheNameWithoutSuffix(tokenCacheName);
            if(MsalCacheHelper == null)
            {
                lock(ObjectLock)
                {
                    if(MsalCacheHelper == null)
                    {
                        try
                        {
                            StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder(tokenCacheName, MsalTokenCachePath)
                                .WithMacKeyChain("Microsoft.Developer.IdentityService", tokenCacheName)
                                .WithLinuxKeyring(keyRingSchema, "default", tokenCacheName,
                                new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService"),
                                new KeyValuePair<string, string>("Microsoft.Developer.IdentityService", "1.0.0.0"))
                                .Build();

                            var cacheHelper = MsalCacheHelper.CreateAsync(storageProperties).ConfigureAwait(false).GetAwaiter().GetResult();
                            cacheHelper.VerifyPersistence();
                            MsalCacheHelper = cacheHelper;
                        }
                        catch(MsalCachePersistenceException)
                        {
                            StorageCreationProperties storageProperties = new StorageCreationPropertiesBuilder(tokenCacheName, MsalTokenCachePath)
                                .WithMacKeyChain("Microsoft.Developer.IdentityService", "MSALCache")
                                .WithLinuxUnprotectedFile()
                                .Build();

                            MsalCacheHelper = MsalCacheHelper.CreateAsync(storageProperties).ConfigureAwait(false).GetAwaiter().GetResult();
                        }
                    }
                }
            }

            return MsalCacheHelper;
        }
    }
}

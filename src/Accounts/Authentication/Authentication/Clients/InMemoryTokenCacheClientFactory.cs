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

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;

namespace Microsoft.Azure.Commands.Common.Authentication.Authentication.Clients
{
    public class InMemoryTokenCacheClientFactory : AuthenticationClientFactory
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string _cacheId = "CacheId";
        private static readonly object _lock = new object();

        public InMemoryTokenCacheClientFactory()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        public InMemoryTokenCacheClientFactory(string cacheToMigratePath)
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            TryCacheMigration(cacheToMigratePath);
        }

        public override void RegisterCache(IClientApplicationBase client)
        {
            client.UserTokenCache.SetBeforeAccess(BeforeAccessNotification);
            client.UserTokenCache.SetAfterAccess(AfterAccessNotification);
        }

        private void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            lock (_lock)
            {
                byte[] blob;
                if (_memoryCache.TryGetValue(_cacheId, out blob))
                {
                    args.TokenCache.DeserializeMsalV3(blob);
                }
            }
        }

        private void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            byte[] blob = args.TokenCache.SerializeMsalV3();
            _memoryCache.Set(_cacheId, blob);
        }

        private void TryCacheMigration(string cacheToMigratePath)
        {
            lock (_lock)
            {
                try
                {
                    var cacheStorage = GetCacheStorage(cacheToMigratePath);
                    byte[] data = cacheStorage.ReadData();
                    _memoryCache.Set(_cacheId, data);
                }
                catch { }
            }
        }

        private MsalCacheStorage GetCacheStorage(string filePath)
        {
            var builder = new StorageCreationPropertiesBuilder(Path.GetFileName(filePath), Path.GetDirectoryName(filePath), PowerShellClientId);
            builder = builder.WithMacKeyChain(serviceName: "Microsoft.Developer.IdentityService", accountName: "MSALCache");
            builder = builder.WithLinuxKeyring(
                schemaName: "msal.cache",
                collection: "default",
                secretLabel: "MSALCache",
                attribute1: new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService"),
                attribute2: new KeyValuePair<string, string>("MsalClientVersion", "1.0.0.0"));
            var storageCreationProperties = builder.Build();
            return new MsalCacheStorage(storageCreationProperties, new TraceSource("Azure PowerShell"));
        }

        public override void ClearCache()
        {
            _memoryCache.Set(_cacheId, new byte[] { });
        }
    }
}

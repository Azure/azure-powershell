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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Identity.Client;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Microsoft.Azure.Commands.Common.Authentication.Core
{
    /// <summary>
    /// An implementation of the Adal token cache that stores the cache items
    /// in the DPAPI-protected file.
    /// </summary>
    public class ProtectedFileTokenCache : IAzureTokenCache
    {
        private static readonly string CacheFileName = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "msal.cache");

        private static readonly Lazy<ProtectedFileTokenCache> instance = new Lazy<ProtectedFileTokenCache>(() => new ProtectedFileTokenCache());

        IDataStore _store;

        private object _tokenCache;

        public object GetUserCache()
        {
            if (_tokenCache == null)
            {
                _tokenCache = SharedTokenCacheClientFactory.GetTokenCache();
            }

            return _tokenCache;
        }

        private TokenCache UserCache
        {
            get
            {
                return (TokenCache)GetUserCache();
            }
        }

        public byte[] CacheData
        {
            get
            {
                return ProtectedData.Protect(UserCache.SerializeMsalV3(), null, DataProtectionScope.CurrentUser);
            }

            set
            {
                UserCache.DeserializeMsalV3(ProtectedData.Unprotect(value, null, DataProtectionScope.CurrentUser));
            }
        }

        // Initializes the cache against a local file.
        // If the file is already present, it loads its content in the ADAL cache
        private ProtectedFileTokenCache()
        {
            _store = AzureSession.Instance.DataStore;
        }

        public ProtectedFileTokenCache(byte[] inputData, IDataStore store = null) : this(CacheFileName, store)
        {
            CacheData = inputData;
        }

        public ProtectedFileTokenCache(string cacheFile, IDataStore store = null)
        {
            _store = store ?? AzureSession.Instance.DataStore;
        }

        public void Clear()
        {
            SharedTokenCacheClientFactory.ClearCache();
        }
    }
}

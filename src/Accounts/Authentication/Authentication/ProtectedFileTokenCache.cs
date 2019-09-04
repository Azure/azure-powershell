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
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation.Language;
using System.Security.Cryptography;

namespace Microsoft.Azure.Commands.Common.Authentication.Core
{
    /// <summary>
    /// An implementation of the MSAL token cache that stores the cache items
    /// in the OS-specific protected file.
    /// </summary>
    public class ProtectedFileTokenCache : IAzureTokenCache
    {
        private static readonly string PowerShellClientId = "1950a258-227b-4e31-a9cf-717495945fc2";
        private static readonly string CacheFileName = "msal.cache";
        private static readonly string CacheFilePath = Path.Combine(SharedUtilities.GetUserRootDirectory(), ".IdentityService", CacheFileName);
        private static readonly object fileLock = new object();

        private static readonly Lazy<ProtectedFileTokenCache> instance = new Lazy<ProtectedFileTokenCache>(() => new ProtectedFileTokenCache());

        private MsalCacheStorage GetMsalCacheStorage()
        {

            var builder = new StorageCreationPropertiesBuilder(Path.GetFileName(CacheFilePath), Path.GetDirectoryName(CacheFilePath), PowerShellClientId);
            builder = builder.WithMacKeyChain(serviceName: "Microsoft.Developer.IdentityService", accountName: "MSALCache");
            builder = builder.WithLinuxKeyring(
                schemaName: "msal.cache",
                collection: "default",
                secretLabel: "MSALCache",
                attribute1: new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService"),
                attribute2: new KeyValuePair<string, string>("MsalClientVersion", "1.0.0.0"));
            var storageCreationProperties = builder.Build();
            return new MsalCacheStorage(storageCreationProperties, null);
        }

        IDataStore _store;
        private object _tokenCache;

        public object GetUserCache()
        {
            if (_tokenCache == null)
            {
                var tokenCache = new TokenCache();
                tokenCache.SetBeforeAccess(BeforeAccessNotification);
                tokenCache.SetAfterAccess(AfterAccessNotification);
                _tokenCache = tokenCache;
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

        private byte[] _cacheDataToReturn = null;
        private byte[] _cacheDataToSet = null;

        public byte[] CacheData
        {
            get
            {
                return _cacheDataToReturn;
            }

            set
            {
                _cacheDataToSet = value;
            }
        }

        // Initializes the cache against a local file.
        // If the file is already present, it loads its content in the MSAL cache
        private ProtectedFileTokenCache()
        {
            _store = AzureSession.Instance.DataStore;
            Initialize(CacheFilePath);
        }

        public ProtectedFileTokenCache(byte[] inputData, IDataStore store = null) : this(CacheFilePath, store)
        {
            CacheData = inputData;
        }

        public ProtectedFileTokenCache(string cacheFile, IDataStore store = null)
        {
            _store = store ?? AzureSession.Instance.DataStore;
            Initialize(cacheFile);
        }

        private void Initialize(string fileName)
        {
            UserCache.SetAfterAccess(AfterAccessNotification);
            UserCache.SetBeforeAccess(BeforeAccessNotification);
        }

        // Triggered right before MSAL needs to access the cache.
        // Reload the cache from the persistent store in case it changed since the last access.
        void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            ReadFileIntoCache(args: args);
        }

        // Triggered right after MSAL accessed the cache.
        void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            // if the access operation resulted in a cache update
            EnsureStateSaved(args);
        }

        void EnsureStateSaved(TokenCacheNotificationArgs args)
        {
            if (args != null && args.HasStateChanged)
            {
                WriteCacheIntoFile(args);
            }
        }

        private void ReadFileIntoCache(TokenCacheNotificationArgs args, string cacheFileName = null)
        {
            if (cacheFileName == null)
            {
                cacheFileName = CacheFileName;
            }

            lock (fileLock)
            {
                if (_store.FileExists(cacheFileName))
                {
                    var existingData = GetMsalCacheStorage().ReadData();
                    if (_cacheDataToSet != null)
                    {
                        existingData = _cacheDataToSet;
                        _cacheDataToSet = null;
                    }

                    if (existingData != null)
                    {
                        try
                        {
                            args.TokenCache.DeserializeMsalV3(existingData);
                        }
                        catch (CryptographicException)
                        {
                            _store.DeleteFile(cacheFileName);
                        }
                    }
                }
            }
        }

        private void WriteCacheIntoFile(TokenCacheNotificationArgs args, string cacheFileName = null)
        {
            lock (fileLock)
            {
                var dataToWrite = args.TokenCache.SerializeMsalV3();
                _cacheDataToReturn = dataToWrite;
                if (args.HasStateChanged)
                {
                    GetMsalCacheStorage().WriteData(dataToWrite);
                }
            }
        }

        public void Clear()
        {
            if (_store.FileExists(CacheFileName))
            {
                _store.DeleteFile(CacheFileName);
            }

            _cacheDataToReturn = new byte[] { };
        }
    }
}

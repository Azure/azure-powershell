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
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// An implementation of the Adal token cache that stores the cache items
    /// in the DPAPI-protected file.
    /// </summary>
    public class ProtectedFileTokenCache : TokenCache, IAzureTokenCache
    {
        private static readonly string CacheFileName = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Resources.AzureDirectoryName, "TokenCache.dat");

        private static readonly object fileLock = new object();

        private static readonly Lazy<ProtectedFileTokenCache> instance = new Lazy<ProtectedFileTokenCache>(() => new ProtectedFileTokenCache());

        public byte[] CacheData
        {
            get
            {
                return Serialize();
            }

            set
            {
                Deserialize(value);
            }
        }

        // Initializes the cache against a local file.
        // If the file is already present, it loads its content in the ADAL cache
        private ProtectedFileTokenCache()
        {
            Initialize(CacheFileName);
        }

        public ProtectedFileTokenCache(byte[] inputData)
        {
            AfterAccess = AfterAccessNotification;
            BeforeAccess = BeforeAccessNotification;
            CacheData = inputData;
        }

        private void Initialize(string fileName)
        {
            AfterAccess = AfterAccessNotification;
            BeforeAccess = BeforeAccessNotification;
            lock (fileLock)
            {
                if (AzureSession.Instance.DataStore.FileExists(fileName))
                {
                    var existingData = AzureSession.Instance.DataStore.ReadFileAsBytes(fileName);
                    if (existingData != null)
                    {
                        try
                        {
                            Deserialize(ProtectedData.Unprotect(existingData, null, DataProtectionScope.CurrentUser));
                        }
                        catch (CryptographicException)
                        {
                            AzureSession.Instance.DataStore.DeleteFile(fileName);
                        }
                    }
                }
            }
        }

        public ProtectedFileTokenCache(string cacheFile)
        {
            Initialize(cacheFile);
        }

        // Empties the persistent store.
        public override void Clear()
        {
            base.Clear();
            if (AzureSession.Instance.DataStore.FileExists(CacheFileName))
            {
                AzureSession.Instance.DataStore.DeleteFile(CacheFileName);
            }
        }

        // Triggered right before ADAL needs to access the cache.
        // Reload the cache from the persistent store in case it changed since the last access.
        void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            lock (fileLock)
            {
                if (AzureSession.Instance.DataStore.FileExists(CacheFileName))
                {
                    var existingData = AzureSession.Instance.DataStore.ReadFileAsBytes(CacheFileName);
                    if (existingData != null)
                    {
                        try
                        {
                            Deserialize(ProtectedData.Unprotect(existingData, null, DataProtectionScope.CurrentUser));
                        }
                        catch (CryptographicException)
                        {
                            AzureSession.Instance.DataStore.DeleteFile(CacheFileName);
                        }
                    }
                }
            }
        }

        // Triggered right after ADAL accessed the cache.
        void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            // if the access operation resulted in a cache update
            if (HasStateChanged)
            {
                lock (fileLock)
                {
                    // reflect changes in the persistent store
                    AzureSession.Instance.DataStore.WriteFile(CacheFileName,
                        ProtectedData.Protect(Serialize(), null, DataProtectionScope.CurrentUser));
                    // once the write operation took place, restore the HasStateChanged bit to false
                    HasStateChanged = false;
                }
            }
        }
    }
}

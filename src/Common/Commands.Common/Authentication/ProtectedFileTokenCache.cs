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

using System;
using System.IO;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common.Authentication
{
    /// <summary>
    /// An implementation of the Adal token cache that stores the cache items
    /// in the DPAPI-protected file.
    /// </summary>
    public class ProtectedFileTokenCache : TokenCache
    {
        private static readonly string CacheFileName = Path.Combine(AzurePowerShell.ProfileDirectory, "TokenCache.dat");

        private static readonly object fileLock = new object();

        private static readonly Lazy<ProtectedFileTokenCache> instance =
            new Lazy<ProtectedFileTokenCache>(() => new ProtectedFileTokenCache());
        
        public static ProtectedFileTokenCache Instance
        {
            get
            {
                return instance.Value;
            }
        }

        // Initializes the cache against a local file.
        // If the file is already present, it loads its content in the ADAL cache
        private ProtectedFileTokenCache()
        {
            AfterAccess = AfterAccessNotification;
            BeforeAccess = BeforeAccessNotification;
            lock (fileLock)
            {
                if (ProfileClient.DataStore.FileExists(CacheFileName))
                {
                    var existingData = ProfileClient.DataStore.ReadFileAsBytes(CacheFileName);
                    if (existingData != null)
                    {
                        Deserialize(ProtectedData.Unprotect(existingData, null, DataProtectionScope.CurrentUser));
                    }
                }
            }
        }

        // Empties the persistent store.
        public override void Clear()
        {
            base.Clear();
            if (ProfileClient.DataStore.FileExists(CacheFileName))
            {
                ProfileClient.DataStore.DeleteFile(CacheFileName);
            }
        }

        // Triggered right before ADAL needs to access the cache.
        // Reload the cache from the persistent store in case it changed since the last access.
        void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            lock (fileLock)
            {
                if (ProfileClient.DataStore.FileExists(CacheFileName))
                {
                    var existingData = ProfileClient.DataStore.ReadFileAsBytes(CacheFileName);
                    if (existingData != null)
                    {
                        Deserialize(ProtectedData.Unprotect(existingData, null, DataProtectionScope.CurrentUser));
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
                    ProfileClient.DataStore.WriteFile(CacheFileName,
                        ProtectedData.Protect(Serialize(), null, DataProtectionScope.CurrentUser));
                    // once the write operation took place, restore the HasStateChanged bit to false
                    HasStateChanged = false;
                }
            }
        }

    }
}

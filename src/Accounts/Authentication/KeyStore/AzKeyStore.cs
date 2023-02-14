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
using System.Security;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class AzKeyStore : IDisposable
    {
        public const string Name = "AzKeyStore";

        public string FileName { get; set; }
        public string Directory { get; set; }

        private IKeyCache _inMemoryKeyCache = null;
        public IKeyCache InMemoryKeyCache
        {
            get => _inMemoryKeyCache;
            set => _inMemoryKeyCache = value;
        }

        private IStorage inputStorage = null;

        public bool IsProtected
        {
            get;
            private set;
        }

        public AzKeyStore(string directory, string fileName, bool enableContextAutoSaving = true, IStorage storage = null)
        {
            InMemoryKeyCache = new InMemoryKeyCache();

            if (enableContextAutoSaving)
            {
                InMemoryKeyCache.SetBeforeAccess(LoadStorage);
                InMemoryKeyCache.SetOnUpdate(UpdateStorage);
            }

            FileName = fileName;
            Directory = directory;

            inputStorage = storage;

            Common.InMemoryKeyCache.RegisterJsonConverter(typeof(ServicePrincipalKey), typeof(ServicePrincipalKey).Name);
            Common.InMemoryKeyCache.RegisterJsonConverter(typeof(SecureString), typeof(SecureString).Name, new SecureStringConverter());
        }


        private void LoadStorage(KeyStoreNotificationArgs args)
        {
            var asyncHelper = StorageHelper.GetStorageHelperAsync(true, FileName, Directory, args.KeyCache, inputStorage);
            var helper = asyncHelper.GetAwaiter().GetResult();
            IsProtected = helper.IsProtected;
        }

        private void UpdateStorage(KeyStoreNotificationArgs args)
        {
            var asyncHelper = StorageHelper.GetStorageHelperAsync(false, FileName, Directory, args.KeyCache, inputStorage);
            var helper = asyncHelper.GetAwaiter().GetResult();
            helper.WriteToCachedStorage(args.KeyCache);
        }

        public void Clear()
        {
            InMemoryKeyCache.Clear();
        }

        public void Dispose()
        {
            StorageHelper.TryClearLockedStorageHelper();
        }

        public void SaveSecureString(IKeyStoreKey key, SecureString value)
        {
            InMemoryKeyCache.SaveKey(key, value);
        }

        public SecureString GetSecureString(IKeyStoreKey key)
        {
            return InMemoryKeyCache.GetKey<SecureString>(key);
        }

        public bool RemoveSecureString(IKeyStoreKey key)
        {
            return InMemoryKeyCache.DeleteKey(key);
        }

        /* Case1: enable --> disable; The methold just unbind the StorageHelper, no influence to InMemoryKeyCache.
         * Case2: disable (not enabled before) --> enable; The methold will have the storage data loaded before any access to InMemoryKeyCache;
         *        InMemoryKeyCache data during the time of disabling will be discarded, which is consistant with the behaviour before AzKeyStore.
         * Case3: disable (enabled before) --> enable; The data from storage is already loaded and won't be loaded again.
         *        Both storage data and InMemoryKeyCache data can be preserved.
         */
        public void EnableSyncToStorage()
        {
            InMemoryKeyCache.SetBeforeAccess(LoadStorage);
            InMemoryKeyCache.SetOnUpdate(UpdateStorage);
        }

        public void DisableSyncToStorage()
        {
            InMemoryKeyCache.SetBeforeAccess(null);
            InMemoryKeyCache.SetOnUpdate(null);
        }
    }
}

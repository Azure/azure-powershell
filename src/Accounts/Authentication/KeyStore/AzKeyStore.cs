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

        private IKeyStore _inMemoryStore = null;
        public IKeyStore InMemoryStore
        {
            get => _inMemoryStore;
            set => _inMemoryStore = value;
        }

        private IStorage inputStorage = null;

        public bool IsProtected
        {
            get;
            private set;
        }

        public AzKeyStore(string directory, string fileName, IStorage storage = null)
        {
            InMemoryStore = new InMemoryKeyStore();
            InMemoryStore.SetBeforeAccess(LoadStorage);

            FileName = fileName;
            Directory = directory;

            inputStorage = storage;

            InMemoryKeyStore.RegisterJsonConverter(typeof(ServicePrincipalKey), typeof(ServicePrincipalKey).Name);
            InMemoryKeyStore.RegisterJsonConverter(typeof(SecureString), typeof(SecureString).Name, new SecureStringConverter());
        }


        private void LoadStorage(KeyStoreNotificationArgs args)
        {
            var asyncHelper = StorageHelper.GetStorageHelperAsync(true, FileName, Directory, args.KeyStore, inputStorage);
            var helper = asyncHelper.GetAwaiter().GetResult();
            IsProtected = helper.IsProtected;
        }

        public void Clear()
        {
            InMemoryStore.Clear();
        }

        public void Dispose()
        {
            StorageHelper.TryClearLockedStorageHelper();
        }

        public void SaveCredential(IKeyStoreKey key, SecureString value)
        {
            InMemoryStore.SaveKey(key, value);
        }

        public SecureString GetCredential(IKeyStoreKey key)
        {
            return InMemoryStore.GetKey<SecureString>(key);
        }

        public bool RemoveCredential(IKeyStoreKey key)
        {
            return InMemoryStore.DeleteKey(key);
        }
    }
}

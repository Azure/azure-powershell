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
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    internal class StorageHelper : IStorageHelper
    {
        private const string KeyChainServiceName = "Microsoft.Azure.PowerShell";

        private static readonly Lazy<TraceSourceLogger> s_staticLogger = new Lazy<TraceSourceLogger>(() =>
        {
            return new TraceSourceLogger(new TraceSource(nameof(StorageHelper)));
        });

        private readonly StorageCreationProperties _storageCreationProperties;

        internal IStorage PersistanceStore { get; }

        private readonly TraceSourceLogger _logger;

        private bool _protected;
        public bool IsProtected
        {
            get => _protected;
            private set => _protected = value;
        }

        private static AsyncLockWithValue<StorageHelper> cacheHelperLock = new AsyncLockWithValue<StorageHelper>();

        internal StorageHelper(StorageCreationProperties storageProperties, bool isProtected, IStorage store = null)
        {
            _logger = s_staticLogger.Value;
            _storageCreationProperties = storageProperties;
            PersistanceStore = store ?? new StorageWrapper()
            {
                StorageCreationProperties = _storageCreationProperties,
                LoggerSource = _logger.Source
            };
            PersistanceStore.Create();
            _protected = isProtected;
        }

        private static StorageHelper GetProtectedStorageHelper(string fileName, string directory, IStorage storage = null)
        {
            var storageProperties = new StorageCreationPropertiesBuilder(fileName, directory)
                                .WithMacKeyChain(KeyChainServiceName + ".other_secrets", fileName)
                                .WithLinuxKeyring(fileName, "default", "AzKeyStoreCache",
                                new KeyValuePair<string, string>("AzureClientID", "Microsoft.Developer.Azure.PowerShell"),
                                new KeyValuePair<string, string>("Microsoft.Developer.Azure.PowerShell", "1.0.0.0")).Build();
            return StorageHelper.Create(storageProperties, true, storage);
        }

        private static StorageHelper GetFallbackStorageHelper(string fileName, string directory, IStorage storage = null)
        {
            var storageProperties = new StorageCreationPropertiesBuilder(fileName, directory)
                .WithUnprotectedFile().Build();
            return StorageHelper.Create(storageProperties, false, storage);
        }

        private static StorageHelper Create(StorageCreationProperties storageCreationProperties, bool isProtected, IStorage storage = null)
        {
            if (storageCreationProperties is null)
            {
                throw new ArgumentNullException(nameof(storageCreationProperties));
            }

            using (CreateCrossPlatLock(storageCreationProperties))
            {
                return new StorageHelper(storageCreationProperties, isProtected, storage);
            }
        }

        #region Public API
        public static async Task<IStorageHelper> GetStorageHelperAsync(bool async, string fileName, string directory, IKeyCache keycache, IStorage storage = null)
        {
            StorageHelper storageHelper = null;

            using (var asyncLock = await cacheHelperLock.GetLockOrValueAsync(async).ConfigureAwait(false))
            {
                if (asyncLock.HasValue)
                {
                    return asyncLock.Value;
                }

                try
                {
                    storageHelper = GetProtectedStorageHelper(fileName, directory, storage);
                    storageHelper.VerifyPersistence();
                }
                catch (Exception)
                {
                    storageHelper = GetFallbackStorageHelper(fileName, directory, storage);
                    storageHelper.VerifyPersistence();
                }
                storageHelper.LoadFromCachedStorage(keycache);
                asyncLock.SetValue(storageHelper);
            }
            return storageHelper;
        }

        public static bool TryClearLockedStorageHelper()
        {
            return cacheHelperLock.TryClearValue();
        }

        public void Clear()
        {
            using (CreateCrossPlatLock(_storageCreationProperties))
            {
                PersistanceStore.Clear();
            }
        }

        public void LoadFromCachedStorage(IKeyCache keycache)
        {
            LogMessage(EventLogLevel.Verbose, $"Before access\nAcquiring lock for keystore");

            using (CreateCrossPlatLock(_storageCreationProperties))
            {
                LogMessage(EventLogLevel.Verbose, $"Before access, the store has changed");

                byte[] cachedStoreData = null;
                try
                {
                    cachedStoreData = PersistanceStore.ReadData();
                }
                catch (Exception ex)
                {
                    LogMessage(EventLogLevel.Error, $"Could not read the keystore. Ignoring. Exception: {ex}");
                    return;

                }
                LogMessage(EventLogLevel.Verbose, $"Read '{cachedStoreData?.Length}' bytes from storage");

                try
                {
                    LogMessage(EventLogLevel.Verbose, $"Deserializing the store");
                    //Overwrite in memory cache always
                    keycache.Deserialize(cachedStoreData, true);
                }
                catch (Exception e)
                {
                    LogMessage(EventLogLevel.Error, $"An exception was encountered while deserializing the {nameof(StorageHelper)} : {e}");
                    LogMessage(EventLogLevel.Error, $"No data found in the store, clearing the cache in memory.");

                    PersistanceStore.Clear();
                    throw;
                }
            }
        }

        public void WriteToCachedStorage(IKeyCache keycache)
        {
            using (CreateCrossPlatLock(_storageCreationProperties))
            {
                LogMessage(EventLogLevel.Verbose, $"After access");
                byte[] data = null;
                LogMessage(EventLogLevel.Verbose, $"After access, cache in memory HasChanged");
                try
                {
                    data = keycache.Serialize();
                }
                catch (Exception e)
                {
                    LogMessage(EventLogLevel.Error, $"An exception was encountered while serializing the {nameof(StorageHelper)} : {e}");
                    LogMessage(EventLogLevel.Error, $"No data found in the store, clearing the cache in memory.");

                    PersistanceStore.Clear();
                    throw;
                }

                if (data != null)
                {
                    LogMessage(EventLogLevel.Verbose, $"Serializing '{data.Length}' bytes");

                    try
                    {
                        PersistanceStore.WriteData(data);
                    }
                    catch (Exception)
                    {
                        LogMessage(EventLogLevel.Error, $"Could not write the keystore. Ignoring. See previous error message.");
                    }
                }
            }
        }
        #endregion

        private static CrossPlatLock CreateCrossPlatLock(StorageCreationProperties storageCreationProperties)
        {
            return new CrossPlatLock(
                storageCreationProperties.CacheFilePath + ".lockfile",
                storageCreationProperties.LockRetryDelay,
                storageCreationProperties.LockRetryCount);
        }

        public void VerifyPersistence()
        {
            PersistanceStore.VerifyPersistence();
        }

        private void LogMessage(EventLogLevel level, string message)
        {
            LogMessage(level, message, _logger);
        }

        private static void LogMessage(EventLogLevel level, string message, TraceSourceLogger traceSourceLogger)
        {
            message = $"[{KeyChainServiceName}] {message}";

            switch (level)
            {
                case EventLogLevel.Warning:
                    traceSourceLogger.LogWarning(message);
                    break;
                case EventLogLevel.Error:
                    traceSourceLogger.LogError(message);
                    break;
                case EventLogLevel.Verbose:
                    traceSourceLogger.LogInformation(message);
                    break;
            }
        }
    }
}
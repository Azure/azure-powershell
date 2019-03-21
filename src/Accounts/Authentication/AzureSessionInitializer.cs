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
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Identity.Client;
using System;
using System.IO;
using System.Diagnostics;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Newtonsoft.Json;
using TraceLevel = System.Diagnostics.TraceLevel;
using System.Linq;
#if NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Core;
#endif

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Initializer for the current Azure session.
    /// </summary>
    public static class AzureSessionInitializer
    {
        private const string ContextAutosaveSettingFileName = ContextAutosaveSettings.AutoSaveSettingsFile;
        private const string DataCollectionFileName = AzurePSDataCollectionProfile.DefaultFileName;

        /// <summary>
        /// Initialize the azure session if it is not already initialized
        /// </summary>
        public static void InitializeAzureSession()
        {
            AzureSession.Initialize(() => CreateInstance());
        }

        /// <summary>
        /// Create a new session and replace any existing session
        /// </summary>
        public static void CreateOrReplaceSession()
        {
            CreateOrReplaceSession(new DiskDataStore());
        }

        /// <summary>
        /// Create a new session and replace any existing session
        /// </summary>
        public static void CreateOrReplaceSession(IDataStore dataStore)
        {
            AzureSession.Initialize(() => CreateInstance(dataStore), true);
        }

        static IAzureTokenCache InitializeTokenCache(IDataStore store, string cacheDirectory, string cacheFile, string autoSaveMode)
        {
            IAzureTokenCache result = new AuthenticationStoreTokenCache(new AzureTokenCache());
            if (autoSaveMode == ContextSaveMode.CurrentUser)
            {
                try
                {
                    FileUtilities.DataStore = store;
                    FileUtilities.EnsureDirectoryExists(cacheDirectory);
                    var cachePath = Path.Combine(cacheDirectory, cacheFile);
                    result = new ProtectedFileTokenCache(cachePath, store);
                }
                catch
                {
                }
            }

            return result;
        }

        static bool MigrateSettings(IDataStore store, string oldProfileDirectory, string newProfileDirectory)
        {
            var filesToMigrate = new string[] { ContextAutosaveSettingFileName,
                                                DataCollectionFileName };
            try
            {
                if (!store.DirectoryExists(newProfileDirectory))
                {
                    store.CreateDirectory(newProfileDirectory);
                }

                // Only migrate if
                // (1) all files to migrate can be found in the old directory, and
                // (2) none of the files to migrate can be found in the new directory
                var oldFiles = Directory.EnumerateFiles(oldProfileDirectory).Where(f => filesToMigrate.Contains(Path.GetFileName(f)));
                var newFiles = Directory.EnumerateFiles(newProfileDirectory).Where(f => filesToMigrate.Contains(Path.GetFileName(f)));
                if (store.DirectoryExists(oldProfileDirectory) && oldFiles.Count() == filesToMigrate.Length && !newFiles.Any())
                {
                    foreach (var oldFilePath in oldFiles)
                    {
                        var fileName = Path.GetFileName(oldFilePath);
                        var newFilePath = Path.Combine(newProfileDirectory, fileName);
                        store.CopyFile(oldFilePath, newFilePath);
                    }

                    return true;
                }
            }
            catch
            {
                // ignore exceptions in reading settings from disk
            }

            return false;
        }

        static ContextAutosaveSettings InitializeSessionSettings(IDataStore store, string profileDirectory, string settingsFile, bool migrated = false)
        {
            return InitializeSessionSettings(store, profileDirectory, profileDirectory, settingsFile, migrated);
        }

        static ContextAutosaveSettings InitializeSessionSettings(IDataStore store, string cacheDirectory, string profileDirectory, string settingsFile, bool migrated = false)
        {
            var result = new ContextAutosaveSettings
            {
                CacheDirectory = cacheDirectory,
                ContextDirectory = profileDirectory,
                Mode = ContextSaveMode.Process,
                CacheFile = "msal.cache",
                ContextFile = "AzureRmContext.json"
            };

            var settingsPath = Path.Combine(profileDirectory, settingsFile);

            try
            {
                if (store.FileExists(settingsPath))
                {
                    var settingsText = store.ReadFileAsText(settingsPath);
                    ContextAutosaveSettings settings = JsonConvert.DeserializeObject<ContextAutosaveSettings>(settingsText);
                    result.CacheDirectory = migrated ? cacheDirectory : settings.CacheDirectory == null ? cacheDirectory : string.Equals(settings.CacheDirectory, profileDirectory) ? cacheDirectory : settings.CacheDirectory;
                    result.CacheFile = settings.CacheFile == null ? result.CacheFile : string.Equals(settings.CacheFile, "TokenCache.dat") ? result.CacheFile : settings.CacheFile;
                    result.ContextDirectory = migrated ? profileDirectory : settings.ContextDirectory ?? result.ContextDirectory;
                    result.Mode = settings.Mode;
                    result.ContextFile = settings.ContextFile ?? result.ContextFile;
                    if (migrated)
                    {
                        string autoSavePath = Path.Combine(profileDirectory, settingsFile);
                        store.WriteFile(autoSavePath, JsonConvert.SerializeObject(result));
                    }
                }
                else
                {
                    string directoryPath = Path.GetDirectoryName(profileDirectory);
                    if (!store.DirectoryExists(directoryPath))
                    {
                        store.CreateDirectory(directoryPath);
                    }
                    string autoSavePath = Path.Combine(profileDirectory, settingsFile);
                    result.Mode = ContextSaveMode.CurrentUser;
                    store.WriteFile(autoSavePath, JsonConvert.SerializeObject(result));
                }
            }
            catch
            {
                // ignore exceptions in reading settings from disk
                result.Mode = ContextSaveMode.Process;
            }

            return result;
        }

        static void InitializeDataCollection(IAzureSession session)
        {
            session.RegisterComponent(DataCollectionController.RegistryKey, () => DataCollectionController.Create(session));
        }

        static IAzureSession CreateInstance(IDataStore dataStore = null)
        {
            string profilePath = Path.Combine(
#if NETSTANDARD
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    Resources.AzureDirectoryName);
            string oldProfilePath = Path.Combine(
#endif
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    Resources.OldAzureDirectoryName);
            dataStore = dataStore ?? new DiskDataStore();

            string cachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var session = new AdalSession
            {
                ClientFactory = new ClientFactory(),
                AuthenticationFactory = new AuthenticationFactory(),
                DataStore = dataStore,
                OldProfileFile = "WindowsAzureProfile.xml",
                OldProfileFileBackup = "WindowsAzureProfile.xml.bak",
                ProfileDirectory = profilePath,
                ProfileFile = "AzureProfile.json",
            };

            var migrated =
#if !NETSTANDARD
                false;
#else
                MigrateSettings(dataStore, oldProfilePath, profilePath);
#endif
            var autoSave = InitializeSessionSettings(dataStore, cachePath, profilePath, ContextAutosaveSettings.AutoSaveSettingsFile, migrated);
            session.ARMContextSaveMode = autoSave.Mode;
            session.ARMProfileDirectory = autoSave.ContextDirectory;
            session.ARMProfileFile = autoSave.ContextFile;
            session.TokenCacheDirectory = autoSave.CacheDirectory;
            session.TokenCacheFile = autoSave.CacheFile;
            session.TokenCache = InitializeTokenCache(dataStore, session.TokenCacheDirectory, session.TokenCacheFile, autoSave.Mode);
            InitializeDataCollection(session);
            session.RegisterComponent(HttpClientOperationsFactory.Name, () => HttpClientOperationsFactory.Create());
            return session;
        }

        public class AdalSession : AzureSession
        {
#if !NETSTANDARD
            public override TraceLevel AuthenticationLegacyTraceLevel
            {
                get { return AdalTrace.LegacyTraceSwitch.Level; }
                set { AdalTrace.LegacyTraceSwitch.Level = value; }
            }

            public override TraceListenerCollection AuthenticationTraceListeners => AdalTrace.TraceSource.Listeners;

            public override SourceLevels AuthenticationTraceSourceLevel
            {
                get { return AdalTrace.TraceSource.Switch.Level; }
                set { AdalTrace.TraceSource.Switch.Level = value; }
            }
#else
            public AdalSession()
            {

            }

            public override TraceLevel AuthenticationLegacyTraceLevel
            {
                get => TraceLevel.Off;
                set { }
            }

            public override TraceListenerCollection AuthenticationTraceListeners => Trace.Listeners;

            public override SourceLevels AuthenticationTraceSourceLevel
            {
                get => SourceLevels.Off;
                set { }
            }
#endif
        }
    }
}

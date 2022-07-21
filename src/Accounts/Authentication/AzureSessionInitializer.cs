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
using System.Diagnostics;
using System.IO;
using System.Linq;

using Hyak.Common;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Azure.Commands.Common.Authentication.Authentication.TokenCache;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Config;
using Newtonsoft.Json;

using TraceLevel = System.Diagnostics.TraceLevel;
using System.Collections.Generic;
using System.Threading;

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
        public static void InitializeAzureSession(Action<string> writeWarning = null)
        {
            AzureSession.Initialize(() => CreateInstance(null, writeWarning));
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

        public static void MigrateAdalCache(IAzureSession session, Func<IAzureContextContainer> getContextContainer, Action<string> writeWarning)
        {
            try
            {
                if (session.ARMContextSaveMode == ContextSaveMode.Process)
                {
                    // Don't attempt to migrate if context autosave is disabled
                    return;
                }

                var adalCachePath = Path.Combine(session.ProfileDirectory, "TokenCache.dat");
                var msalCachePath = Path.Combine(session.TokenCacheDirectory, "msal.cache");
                var store = session.DataStore;
                if (!store.FileExists(adalCachePath) || store.FileExists(msalCachePath))
                {
                    // Return if
                    // (1) The ADAL cache doesn't exist (nothing to migrate), or
                    // (2) The MSAL cache does exist (don't override existing cache)
                    return;
                }

                byte[] adalData;
                try
                {
                    adalData = File.ReadAllBytes(adalCachePath);
                }
                catch
                {
                    // Return if there was an error converting the ADAL data safely
                    return;
                }

                if (adalData != null && adalData.Length > 0)
                {
                    new AdalTokenMigrator(adalData, getContextContainer).MigrateFromAdalToMsal();
                }
            }
            catch (Exception e)
            {
                writeWarning(Resources.FailedToMigrateAdal2Msal.FormatInvariant(e.Message));
            }
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
            catch (Exception ex)
            {
                // ignore exceptions in reading settings from disk
                result.Mode = ContextSaveMode.Process;
                TracingAdapter.Information("[AzureSessionInitializer]: Cannot read settings from disk. Falling back to 'Process' mode.");
                TracingAdapter.Information($"[AzureSessionInitializer]: Message: {ex.Message}; Stacktrace: {ex.StackTrace}");
            }

            return result;
        }

        static void InitializeDataCollection(IAzureSession session)
        {
            session.RegisterComponent(DataCollectionController.RegistryKey, () => DataCollectionController.Create(session));
        }

        static IAzureSession CreateInstance(IDataStore dataStore = null, Action<string> writeWarning = null)
        {
            string profilePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    Resources.AzureDirectoryName);
            string oldProfilePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    Resources.OldAzureDirectoryName);
            dataStore = dataStore ?? new DiskDataStore();


            string oldCachePath = Path.Combine(profilePath, "TokenCache.dat");
            string cachePath = Path.Combine(SharedUtilities.GetUserRootDirectory(), ".IdentityService");
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
                MigrateSettings(dataStore, oldProfilePath, profilePath);
            var autoSave = InitializeSessionSettings(dataStore, cachePath, profilePath, ContextAutosaveSettings.AutoSaveSettingsFile, migrated);
            session.ARMContextSaveMode = autoSave.Mode;
            session.ARMProfileDirectory = autoSave.ContextDirectory;
            session.ARMProfileFile = autoSave.ContextFile;
            session.TokenCacheDirectory = autoSave.CacheDirectory;
            session.TokenCacheFile = autoSave.CacheFile;

            InitializeConfigs(session, profilePath, writeWarning);
            InitializeDataCollection(session);
            session.RegisterComponent(HttpClientOperationsFactory.Name, () => HttpClientOperationsFactory.Create());
            session.TokenCache = session.TokenCache ?? new AzureTokenCache();
            return session;
        }

        private static void InitializeConfigs(AzureSession session, string profilePath, Action<string> writeWarning)
        {
            if (writeWarning == null) { writeWarning = (string s) => { }; };
            var fallbackList = new List<string>()
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".Azure", "PSConfig.json"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ".Azure", "PSConfig.json")
            };
            ConfigInitializer configInitializer = new ConfigInitializer(fallbackList);

            using (var mutex = new Mutex(false, @"Global\AzurePowerShellConfigInit"))
            {
                if (mutex.WaitOne(1000))
                {
                    // regular initialization
                    try
                    {
                        configInitializer.MigrateConfigs(profilePath);
                        configInitializer.Initialize(session);
                        return; // done, return.
                    }
                    catch (Exception ex)
                    {
                        writeWarning($"[AzureSessionInitializer] Failed to initialize the configs, reason: {ex.Message}.");
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                }
                else
                {
                    writeWarning($"[AzureSessionInitializer] Timed out when initializing the configs.");
                }

                // initialize in safe mode and do not try to migrate configs
                writeWarning($"[AzureSessionInitializer] Config manager will be re-initialized in safe mode. All configs will have only default values.");
                configInitializer.SafeInitialize(session);
            }
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
                AdalLogger = new AdalLogger(WriteToTraceListeners);
                //LoggerCallbackHandler.UseDefaultLogging = false;
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

            /// <summary>
            /// Adal Logger for Adal 3.x +
            /// </summary>
            public AdalLogger AdalLogger { get; private set; }

            /// <summary>
            /// Write messages to the existing trace listeners when log messages occur
            /// </summary>
            /// <param name="message"></param>
            private void WriteToTraceListeners(string message)
            {
                for (var i = 0; i < AuthenticationTraceListeners.Count; ++i) // don't use foreach, enumerator is not thread safe
                {
                    try
                    {
                        AuthenticationTraceListeners[i].WriteLine(message);
                    }
                    catch
                    {
                        // ignroe any exception
                    }
                }
            }
#endif
        }
    }
}

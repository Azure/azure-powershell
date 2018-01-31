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
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.IO;
using System.Diagnostics;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Initializer for the current Azure session.
    /// </summary>
    public static class AzureSessionInitializer
    {
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

        static ContextAutosaveSettings InitializeSessionSettings(IDataStore store, string profileDirectory, string settingsFile)
        {
            var result = new ContextAutosaveSettings
            {
                CacheDirectory = profileDirectory,
                ContextDirectory = profileDirectory,
                Mode = ContextSaveMode.Process,
                CacheFile = "TokenCache.dat",
                ContextFile = "AzureRmContext.json"
            };

            var settingsPath = Path.Combine(profileDirectory, settingsFile);

            try
            {
                if (store.FileExists(settingsPath))
                {
                    var settingsText = store.ReadFileAsText(settingsPath);
                    ContextAutosaveSettings settings = JsonConvert.DeserializeObject<ContextAutosaveSettings>(settingsText);
                    result.CacheDirectory = settings.CacheDirectory ?? result.CacheDirectory;
                    result.CacheFile = settings.CacheFile ?? result.CacheFile;
                    result.ContextDirectory = settings.ContextDirectory ?? result.ContextDirectory;
                    result.Mode = settings.Mode;
                    result.ContextFile = settings.ContextFile ?? result.ContextFile;
                }
            }
            catch
            {
                // ignore exceptions in reading settings from disk
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
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    Resources.AzureDirectoryName);
            dataStore = dataStore ?? new DiskDataStore();

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

            var autoSave = InitializeSessionSettings(dataStore, profilePath, ContextAutosaveSettings.AutoSaveSettingsFile);
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
                get
                {
                    return AdalTrace.LegacyTraceSwitch.Level;
                }

                set
                {
                    AdalTrace.LegacyTraceSwitch.Level = value;
                }
            }

            public override TraceListenerCollection AuthenticationTraceListeners
            {
                get
                {
                    return AdalTrace.TraceSource.Listeners;
                }
            }

            public override SourceLevels AuthenticationTraceSourceLevel
            {
                get
                {
                    return AdalTrace.TraceSource.Switch.Level;
                }

                set
                {
                    AdalTrace.TraceSource.Switch.Level = value;
                }
            }
#else
            public AdalSession()
                : base()
            {
            }

            public override System.Diagnostics.TraceLevel AuthenticationLegacyTraceLevel
            {
                get
                {
                    return System.Diagnostics.TraceLevel.Off;
                }
                set
                {
                    
                }
            }

            public override TraceListenerCollection AuthenticationTraceListeners { get => Trace.Listeners; }

            public override SourceLevels AuthenticationTraceSourceLevel
            {
                get
                {
                    return SourceLevels.Off;
                }
                set
                {

                }
            }
#endif
        }
    }
}

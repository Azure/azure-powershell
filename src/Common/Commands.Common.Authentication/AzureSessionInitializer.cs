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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.Azure.Commands.Common.Authentication.Properties;

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
            AzureSession.Initialize(CreateInstance);
        }

        static IAzureSession CreateInstance()
        {
            var session = new AdalSession
            {
                ClientFactory = new ClientFactory(),
                AuthenticationFactory = new AuthenticationFactory(),
                DataStore = new DiskDataStore(),
                OldProfileFile = "WindowsAzureProfile.xml",
                OldProfileFileBackup = "WindowsAzureProfile.xml.bak",
                ProfileDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Resources.AzureDirectoryName),
                ProfileFile = "AzureProfile.json",
                TokenCacheFile = "TokenCache.dat"
            };
            try
            {
                FileUtilities.DataStore = session.DataStore;
                FileUtilities.EnsureDirectoryExists(session.ProfileDirectory);
                var cacheFile = Path.Combine(session.ProfileDirectory, session.TokenCacheFile);
                var contents = new byte[0];
                if (session.DataStore.FileExists(cacheFile))
                {
                    contents = session.DataStore.ReadFileAsBytes(cacheFile);
                }

                if (contents != null  && contents.Length > 0)
                {
                    contents = ProtectedData.Unprotect(contents, null, DataProtectionScope.CurrentUser);
                }

                session.TokenCache = new ProtectedFileTokenCache(contents);
            }
            catch
            {
                session.TokenCache = new AuthenticationStoreTokenCache(new AzureTokenCache());
            }

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

            public override TraceLevel AuthenticationLegacyTraceLevel
            {
                get
                {
                    return TraceLevel.Off;
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

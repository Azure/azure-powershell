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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using Newtonsoft.Json;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Context
{
    [Cmdlet(VerbsLifecycle.Disable, "AzureRmContextAutosave", SupportsShouldProcess = true)]
    [OutputType(typeof(ContextAutosaveSettings))]
    public class DisableAzureRmContextAutosave : AzureContextModificationCmdlet
    {
        public override void ExecuteCmdlet()
        {
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Scope)) && Scope == ContextModificationScope.Process)
            {
                ConfirmAction("Do not autosave the context in the current session", "Current session", () =>
                {
                    ModifyContext((profile, client) =>
                    {
                        ContextAutosaveSettings settings = null;
                        AzureSession.Modify((session) => DisableAutosave(session, false, out settings));
                        ResourceManagerProfileProvider.InitializeResourceManagerProfile(true);
                        AzureRmProfileProvider.Instance.Profile = profile;
                        WriteObject(settings);
                    });
                });
            }
            else
            {
                ConfirmAction("Never autosave the context for the current user", "Current user",
                    () =>
                    {
                        ModifyContext((profile, client) =>
                        {
                            ContextAutosaveSettings settings = null;
                            AzureSession.Modify((session) => DisableAutosave(session, true, out settings));
                            ResourceManagerProfileProvider.InitializeResourceManagerProfile(true);
                            AzureRmProfileProvider.Instance.Profile = profile;
                            WriteObject(settings);
                        });
                    });
            }
        }

        void DisableAutosave(IAzureSession session, bool writeAutoSaveFile, out ContextAutosaveSettings result)
        {
            var store = session.DataStore;
            string tokenPath = Path.Combine(session.TokenCacheDirectory, session.TokenCacheFile);
            result = new ContextAutosaveSettings
            {
                Mode = ContextSaveMode.Process
            };

            FileUtilities.DataStore = session.DataStore;
            session.ARMContextSaveMode = ContextSaveMode.Process;
            var memoryCache = session.TokenCache as AuthenticationStoreTokenCache;
            if (memoryCache == null)
            {
                var diskCache = session.TokenCache as ProtectedFileTokenCache;
                memoryCache = new AuthenticationStoreTokenCache(new AzureTokenCache());
                if (diskCache != null && diskCache.Count > 0)
                {
                    memoryCache.Deserialize(diskCache.Serialize());
                }

                session.TokenCache = memoryCache;
            }

            if (writeAutoSaveFile)
            {
                FileUtilities.EnsureDirectoryExists(session.ProfileDirectory);
                string autoSavePath = Path.Combine(session.ProfileDirectory, ContextAutosaveSettings.AutoSaveSettingsFile);
                session.DataStore.WriteFile(autoSavePath, JsonConvert.SerializeObject(result));
            }
        }
    }
}

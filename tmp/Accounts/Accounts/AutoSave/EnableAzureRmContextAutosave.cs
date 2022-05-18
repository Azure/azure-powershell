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

using System.IO;
using System.Management.Automation;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;

using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Profile.Context
{
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContextAutosave", SupportsShouldProcess = true)]
    [OutputType(typeof(ContextAutosaveSettings))]
    public class EnableAzureRmContextAutosave : AzureContextModificationCmdlet
    {
        protected override bool RequireDefaultContext() { return false; }

        public override void ExecuteCmdlet()
        {
            if (!SharedTokenCacheProvider.SupportCachePersistence(out string message))
            {
                WriteWarning(Resources.TokenCacheEncryptionNotSupportedWithFallback);
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Scope)) && Scope == ContextModificationScope.Process)
            {
                ConfirmAction("Autosave the context in the current session", "Current session", () =>
                {
                    ContextAutosaveSettings settings = null;
                    AzureSession.Modify((session) => EnableAutosave(session, false, out settings));
                    ProtectedProfileProvider.InitializeResourceManagerProfile(true);
                    WriteObject(settings);
                });
            }
            else
            {
                ConfirmAction("Always autosave the context for the current user", "Current user",
                    () =>
                    {
                        ContextAutosaveSettings settings = null;
                        AzureSession.Modify((session) => EnableAutosave(session, true, out settings));
                        ProtectedProfileProvider.InitializeResourceManagerProfile(true);
                        WriteObject(settings);
                    });
            }
        }

        void EnableAutosave(IAzureSession session, bool writeAutoSaveFile, out ContextAutosaveSettings result)
        {
            var store = session.DataStore;
            string contextPath = Path.Combine(session.ARMProfileDirectory, session.ARMProfileFile);
            string tokenPath = Path.Combine(session.TokenCacheDirectory, session.TokenCacheFile);
            if (!IsValidPath(contextPath))
            {
                throw new PSInvalidOperationException(string.Format("'{0}' is not a valid path. You cannot enable context autosave without a valid context path", contextPath));
            }

            if (!IsValidPath(tokenPath))
            {
                throw new PSInvalidOperationException(string.Format("'{0}' is not a valid path. You cannot enable context autosave without a valid token cache path", tokenPath));
            }

            result = new ContextAutosaveSettings
            {
                CacheDirectory = session.TokenCacheDirectory,
                CacheFile = session.TokenCacheFile,
                ContextDirectory = session.ARMProfileDirectory,
                ContextFile = session.ARMProfileFile,
                Mode = ContextSaveMode.CurrentUser
            };

            FileUtilities.DataStore = session.DataStore;
            session.ARMContextSaveMode = ContextSaveMode.CurrentUser;

            AzureSession.Instance.TryGetComponent(nameof(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey), out PowerShellTokenCacheProvider originalCacheProvider);
            if(originalCacheProvider is InMemoryTokenCacheProvider inMemoryTokenCacheProvider)
            {
                var tokenData = inMemoryTokenCacheProvider.ReadTokenData();
                //must use explicit interface type PowerShellTokenCacheProvider below instead of var, otherwise could not retrieve registered component
                PowerShellTokenCacheProvider newCacheProvider = new SharedTokenCacheProvider();
                if (tokenData != null && tokenData.Length > 0)
                {
                    newCacheProvider.UpdateTokenDataWithoutFlush(tokenData);
                    newCacheProvider.FlushTokenData();
                }
                AzureSession.Instance.RegisterComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, () => newCacheProvider, true);
            }


            if (writeAutoSaveFile)
            {
                try
                {
                    FileUtilities.EnsureDirectoryExists(session.ProfileDirectory);
                    string autoSavePath = Path.Combine(session.ProfileDirectory, ContextAutosaveSettings.AutoSaveSettingsFile);
                    session.DataStore.WriteFile(autoSavePath, JsonConvert.SerializeObject(result));
                }
                catch
                {
                    // do not fail for file system errors in writing the autosave setting
                    // it may impact automation environment and module import.
                }
            }
        }

        bool IsValidPath(string path)
        {
            FileInfo valid = null;
            try
            {
                valid = new FileInfo(path);
            }
            catch
            {
                // swallow any exception
            }
            return valid != null;
        }
    }
}

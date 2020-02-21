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
using Microsoft.Identity.Client;
using Microsoft.Azure.Commands.Common.Authentication.Authentication.Clients;

namespace Microsoft.Azure.Commands.Profile.Context
{
    [Cmdlet("Disable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContextAutosave", SupportsShouldProcess = true)]
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
            
            AuthenticationClientFactory authenticationClientFactory = new InMemoryTokenCacheClientFactory();
            if (AzureSession.Instance.TryGetComponent(
                    AuthenticationClientFactory.AuthenticationClientFactoryKey,
                    out AuthenticationClientFactory OriginalAuthenticationClientFactory))
            {
                var token = OriginalAuthenticationClientFactory.ReadTokenData();
                authenticationClientFactory.UpdateTokenDataWithoutFlush(token);
                authenticationClientFactory.FlushTokenData();
            }
            AzureSession.Instance.UnregisterComponent<AuthenticationClientFactory>(AuthenticationClientFactory.AuthenticationClientFactoryKey);
            AzureSession.Instance.RegisterComponent(AuthenticationClientFactory.AuthenticationClientFactoryKey, () => authenticationClientFactory);
            if (writeAutoSaveFile)
            {
                FileUtilities.EnsureDirectoryExists(session.ProfileDirectory);
                string autoSavePath = Path.Combine(session.ProfileDirectory, ContextAutosaveSettings.AutoSaveSettingsFile);
                session.DataStore.WriteFile(autoSavePath, JsonConvert.SerializeObject(result));
            }
        }
    }
}

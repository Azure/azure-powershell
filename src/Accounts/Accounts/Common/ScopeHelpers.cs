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
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.Profile.Properties;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Microsoft.Azure.Commands.Profile.Common
{
    public delegate void DebugWriter(string format, params object[] parameters);

    // Helper classes for handling autosave scopes
    public static class ScopeHelpers
    {
        /// <summary>
        /// Get the context modification scope for the current process.  This will be 'Process' if changes should 
        /// only affect the current PowerShell session, or 'CurrentUser'  if any changes should be global.
        /// </summary>
        /// <param name="writer">A writer to write debug messages</param>
        /// <returns>'Process'  if all changes should only impact the current session, or 'CurrentUser' if 
        /// changes should be global.</returns>
        public static ContextModificationScope GetContextModificationScopeForProcess(DebugWriter writer)
        {
            ContextModificationScope scope = AzureSession.Instance.ARMContextSaveMode == ContextSaveMode.Process ? ContextModificationScope.Process : ContextModificationScope.CurrentUser;
            try
            {
                writer(Resources.AutosaveSettingFromSession, scope);
                var autoSaveSetting = Environment.GetEnvironmentVariable(AzureRmProfileConstants.ProfileAutoSaveVariable);
                bool autoSaveEnabled = false;
                if (autoSaveSetting != null && bool.TryParse(autoSaveSetting, out autoSaveEnabled))
                {
                    scope = autoSaveEnabled ? ContextModificationScope.CurrentUser : ContextModificationScope.Process;
                    writer(Resources.AutosaveSettingFromEnvironment, AzureRmProfileConstants.ProfileAutoSaveVariable, autoSaveSetting);
                }
                else
                {
                    writer(Resources.CouldNotRetrieveAutosaveSetting, AzureRmProfileConstants.ProfileAutoSaveVariable);
                }
            }
            catch (Exception exception)
            {
                writer(Resources.ErrorRetrievingAutosaveSetting, AzureRmProfileConstants.ProfileAutoSaveVariable, exception);
            }

            return scope;
        }

        /// <summary>
        /// Get the context modification scope for the current user.  This will be 'Process' if changes should 
        /// only affect the current PowerShell session, or 'CurrentUser'  if any changes should be global.
        /// </summary>
        /// <param name="writer">A writer to write debug messages</param>
        /// <returns>'Process'  if all changes should only impact the current session, or 'CurrentUser' if 
        /// changes should be global.</returns>
        public static ContextModificationScope GetContextModificationScopeForUser(IAzureSession session, DebugWriter writer)
        {
            ContextModificationScope scope =  ContextModificationScope.Process;
            try
            {
                string autoSavePath = Path.Combine(session.ProfileDirectory, ContextAutosaveSettings.AutoSaveSettingsFile);
                var store = session.DataStore;
                if (store.FileExists(autoSavePath))
                {
                    var settings = JsonConvert.DeserializeObject<ContextAutosaveSettings>(store.ReadFileAsText(autoSavePath));
                    if (settings != null && !string.IsNullOrWhiteSpace(settings.Mode))
                    {
                        scope = GetContextModificationScopeFromSaveMode(settings.Mode);
                        writer(Resources.AutosaveSettingFromFile, autoSavePath, settings.Mode);
                    }
                }

                var userAutoSaveSetting = Environment.GetEnvironmentVariable(AzureRmProfileConstants.ProfileAutoSaveVariable, EnvironmentVariableTarget.User);
                var machineAutoSaveSetting = Environment.GetEnvironmentVariable(AzureRmProfileConstants.ProfileAutoSaveVariable, EnvironmentVariableTarget.Machine);
                bool autoSaveEnabled = false;
                if (userAutoSaveSetting != null && bool.TryParse(userAutoSaveSetting, out autoSaveEnabled))
                {
                    scope = autoSaveEnabled ? ContextModificationScope.CurrentUser : ContextModificationScope.Process;
                    writer(Resources.AutosaveSettingFromEnvironment, AzureRmProfileConstants.ProfileAutoSaveVariable, userAutoSaveSetting);
                }
                else if (machineAutoSaveSetting != null && bool.TryParse(machineAutoSaveSetting, out autoSaveEnabled))
                {
                    scope = autoSaveEnabled ? ContextModificationScope.CurrentUser : ContextModificationScope.Process;
                    writer(Resources.AutosaveSettingFromEnvironment, AzureRmProfileConstants.ProfileAutoSaveVariable, machineAutoSaveSetting);
                }
                else
                {
                    writer(Resources.CouldNotRetrieveAutosaveSetting, AzureRmProfileConstants.ProfileAutoSaveVariable);
                }

            }
            catch (Exception exception)
            {
                writer(Resources.ErrorRetrievingAutosaveSetting, AzureRmProfileConstants.ProfileAutoSaveVariable, exception);
            }

            return scope;
        }

        /// <summary>
        /// Translate the ContextModificationScope enum into a string
        /// </summary>
        /// <param name="scope">The scope to translate</param>
        /// <returns>A string representation of the scope</returns>
        public static string GetContextSaveMode(ContextModificationScope scope)
        {
            return (scope == ContextModificationScope.CurrentUser? ContextSaveMode.CurrentUser : ContextSaveMode.Process);
        }

        /// <summary>
        /// Translate a string representation of the save mode into the ContextModificatioNScope enum
        /// </summary>
        /// <param name="saveMode">A string representing the context save mode</param>
        /// <returns>The corresponding value in the ContextModificatioNScope enum</returns>
        public static ContextModificationScope GetContextModificationScopeFromSaveMode(string saveMode)
        {
            return (saveMode == ContextSaveMode.CurrentUser ? ContextModificationScope.CurrentUser : ContextModificationScope.Process);
        }
    }
}

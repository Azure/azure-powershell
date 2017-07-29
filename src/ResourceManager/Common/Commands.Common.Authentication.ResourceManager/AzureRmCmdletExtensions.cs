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
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;

namespace Microsoft.Azure.Commands.Common.Authentication.ResourceManager
{
    public static class AzureRmCmdletExtensions
    {
        const string ProfileAutoSaveVariable = "AzureRmContextAutoSave";
        const string AutoSaveDisabled = "Disabled";

        public static bool GetAutosaveSetting(this AzureRMCmdlet cmdlet)
        {
            bool autoSave = true;
            try
            {
                var autoSaveVariable = cmdlet.SessionState.PSVariable.Get(ProfileAutoSaveVariable);
                if (autoSaveVariable != null)
                {
                    string autoSaveSetting = autoSaveVariable.Value as string;
                    if (autoSaveSetting != null)
                    {
                        if (string.Equals(autoSaveSetting, AutoSaveDisabled, StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(autoSaveSetting, "False", StringComparison.OrdinalIgnoreCase))
                        {
                            autoSave = false;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                cmdlet.WriteDebug(string.Format("Unable to retrieve variable value '{0}' to determine AutoSaveSetting, received exception '{1}' setting AutoSave to true", ProfileAutoSaveVariable, exception));
            }

            cmdlet.WriteDebug(string.Format("AUtosave set to '{0}'", autoSave));
            return autoSave;
        }
    }
}

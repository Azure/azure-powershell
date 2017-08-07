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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Common
{
    public class AzureContextModificationCmdlet : AzureRMCmdlet
    {
        [Parameter(Mandatory =false, HelpMessage="Determines the scope of context changes, for example, wheher changes apply only to the cusrrent process, or to all sessions started by this user")]
        public ContextModificationScope Scope { get; set; }


        public virtual void ModifyContext(Action<AzureRmProfile, RMProfileClient> contextAction)
        {
            using (var profile = GetDefaultProfile())
            {
                contextAction(profile.ToProfile(), new RMProfileClient(profile));
            }
        }

        public virtual IProfileOperations GetDefaultProfile()
        {
            IProfileOperations result = null;
            var currentProfile = AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>();
            switch (GetContextModificationScope())
            {
                case ContextModificationScope.Process:
                    result = currentProfile;
                    break;
                case ContextModificationScope.CurrentUser:
                    result = new AzureRmAutosaveProfile(currentProfile, ProtectedFileProvider.CreateFileProvider(Path.Combine(AzureSession.Instance.ARMProfileDirectory, AzureSession.Instance.ResourceManagerContextFile), FileProtection.ExclusiveWrite));
                    break;
            }

            return result;
        }

        public virtual ContextModificationScope GetContextModificationScope()
        {
            ContextModificationScope scope = ContextModificationScope.CurrentUser;
            if (MyInvocation != null && MyInvocation.BoundParameters != null && MyInvocation.BoundParameters.ContainsKey(nameof(Scope)))
            {
                scope = Scope;
            }
            else if (SessionState != null && SessionState.PSVariable != null )
            {
                try
                {
                    var autoSaveVariable = SessionState.PSVariable.Get(AzureRmProfileConstants.ProfileAutoSaveVariable);
                    string autoSaveSetting = autoSaveVariable == null? null : autoSaveVariable.Value as string;
                    if (autoSaveVariable != null && autoSaveSetting != null 
                            && (string.Equals(autoSaveSetting, AzureRmProfileConstants.AutoSaveDisabled, StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(autoSaveSetting, "False", StringComparison.OrdinalIgnoreCase)))
                        {
                            scope = ContextModificationScope.Process;
                            WriteDebugWithTimestamp(string.Format(Resources.UsingAutoSaveSettins, AzureRmProfileConstants.ProfileAutoSaveVariable, autoSaveSetting));
                        }
                    else
                    {
                        WriteDebugWithTimestamp(string.Format(Resources.CouldNotRetrieveAutosaveSetting, AzureRmProfileConstants.ProfileAutoSaveVariable));
                    }
                }
                catch (Exception exception)
                {
                    WriteDebugWithTimestamp(string.Format(Resources.ErrorRetrievingAutosaveSetting, AzureRmProfileConstants.ProfileAutoSaveVariable, exception));
                }
            }

            return scope;
        }

        /// <summary>
        /// Initialize the profile provider based on the autosave setting
        /// </summary>
        internal void InitializeProfileProvider(bool useAutoSaveProfile = true)
        {
#if DEBUG
            if (!TestMockSupport.RunningMocked)
            {
#endif
                if (!useAutoSaveProfile)
                {
                    ResourceManagerProfileProvider.InitializeResourceManagerProfile();
                }
                else
                {
                    switch (GetContextModificationScope())
                    {
                        case ContextModificationScope.Process:
                            ResourceManagerProfileProvider.InitializeResourceManagerProfile();
                            break;
                        case ContextModificationScope.CurrentUser:
                            ProtectedProfileProvider.InitializeResourceManagerProfile();
                            break;
                    }
                }
#if DEBUG
            }
            else
            {
                ResourceManagerProfileProvider.InitializeResourceManagerProfile();
            }
#endif
        }
    }
}

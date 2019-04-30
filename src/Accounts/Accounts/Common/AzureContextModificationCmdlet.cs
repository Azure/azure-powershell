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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Common
{
    /// <summary>
    /// Base class for cmdlets that modify the current context
    /// </summary>
    public class AzureContextModificationCmdlet : AzureRMCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Determines the scope of context changes, for example, whether changes apply only to the current process, or to all sessions started by this user.")]
        public ContextModificationScope Scope { get; set; }


        /// <summary>
        /// Modify the context according to the appropriate scope for this cmdlet invociation
        /// </summary>
        /// <param name="contextAction">The action that modifes the context given a profile and profile client</param>
        protected virtual void ModifyContext(Action<AzureRmProfile, RMProfileClient> contextAction)
        {
            using (var profile = GetDefaultProfile())
            {
                contextAction(profile.ToProfile(), new RMProfileClient(profile));
            }
        }

        /// <summary>
        /// Modify the Profile according to the selected scope for thsi invocation
        /// </summary>
        /// <param name="profileAction">The action to take over the given profile</param>
        protected virtual void ModifyProfile(Action<IProfileOperations> profileAction)
        {
            using (var profile = GetDefaultProfile())
            {
                profileAction(profile);
            }
        }

        /// <summary>
        /// Get the default profile for the current cmdlet invocation
        /// </summary>
        /// <returns>The default profile, whether it is a process-specific profile, ot a profile for the current user</returns>
        protected virtual IProfileOperations GetDefaultProfile()
        {
            IProfileOperations result = null;
            var currentProfile = DefaultProfile as AzureRmProfile;
            switch (GetContextModificationScope())
            {
                case ContextModificationScope.Process:
                    result = currentProfile;
                    break;
                case ContextModificationScope.CurrentUser:
                    result = new AzureRmAutosaveProfile(currentProfile, ProtectedFileProvider.CreateFileProvider(Path.Combine(AzureSession.Instance.ARMProfileDirectory, AzureSession.Instance.ARMProfileFile), FileProtection.ExclusiveWrite));
                    break;
            }

            return result;
        }

        /// <summary>
        /// Get the context modification scope for the current cmdlet invoication
        /// </summary>
        /// <returns>Process if the cmdlet should only change the current process, CurrentUser 
        /// if any changes should occur globally.</returns>
        protected virtual ContextModificationScope GetContextModificationScope()
        {
            ContextModificationScope scope = ScopeHelpers.GetContextModificationScopeForProcess(WriteDebugWithTimestamp);

            // override default scope with appropriate scope for thsi cmdlet invocation
            if (MyInvocation != null && MyInvocation.BoundParameters != null && MyInvocation.BoundParameters.ContainsKey(nameof(DefaultProfile)))
            {
                // never autosave with a passed-in profile
                scope = ContextModificationScope.Process;
                WriteDebugWithTimestamp(Resources.AutosaveDisabledForContextParameter);
            }
            else if (MyInvocation != null && MyInvocation.BoundParameters != null && MyInvocation.BoundParameters.ContainsKey(nameof(Scope)))
            {
                scope = Scope;
                WriteDebugWithTimestamp(Resources.AutosaveSettingFromScope, scope);
            }

            WriteDebugWithTimestamp(Resources.AutosaveSettingFinalValue, scope);
            return scope;
        }

        /// <summary>
        /// Initialize the profile provider based on the autosave setting
        /// </summary>
        internal void InitializeProfileProvider(bool useAutoSaveProfile = false)
        {
#if DEBUG
            if (!TestMockSupport.RunningMocked)
            {
#endif
                if (useAutoSaveProfile)
                {
                    ProtectedProfileProvider.InitializeResourceManagerProfile();
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

        internal void TrySetupContextsFromCache()
        {
            using (var profile = GetDefaultProfile())
            {
                var profileClient = new RMProfileClient(profile);
                profileClient.TrySetupContextsFromCache();
            }
        }

        internal void TryRefreshContextsFromCache()
        {
            using (var profile = GetDefaultProfile())
            {
                var profileClient = new RMProfileClient(profile);
                profileClient.TryRefreshContextsFromCache();
            }
        }

        /// <summary>
        /// Generate a runtime parameter with ValidateSet matching the current context
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="runtimeParameter">The returned runtime parameter for context, with appropriate validate set</param>
        /// <returns>True if one or more contexts were found, otherwise false</returns>
        protected  bool TryGetExistingContextNameParameter(string name, out RuntimeDefinedParameter runtimeParameter)
        {
            var result = false;
            var profile = DefaultProfile as AzureRmProfile;
            runtimeParameter = null;
            if (profile != null && profile.Contexts != null && profile.Contexts.Any())
            {
                runtimeParameter =  new RuntimeDefinedParameter(
                    name, typeof(string),
                    new Collection<Attribute>()
                    {
                    new ParameterAttribute { Position =0, Mandatory=true, HelpMessage="The name of the context" },
                    new ValidateSetAttribute(profile.Contexts.Keys.ToArray())
                    }
                );
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Generate a runtime parameter with ValidateSet matching the current context
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="runtimeParameter">The returned runtime parameter for context, with appropriate validate set</param>
        /// <returns>True if one or more contexts were found, otherwise false</returns>
        protected bool TryGetExistingContextNameParameter(string name, string parameterSetName, out RuntimeDefinedParameter runtimeParameter)
        {
            var result = false;
            var profile = DefaultProfile as AzureRmProfile;
            runtimeParameter = null;
            if (profile != null && profile.Contexts != null && profile.Contexts.Any())
            {
                runtimeParameter = new RuntimeDefinedParameter(
                    name, typeof(string),
                    new Collection<Attribute>()
                    {
                    new ParameterAttribute { Position =0, Mandatory=true, HelpMessage="The name of the context", ParameterSetName = parameterSetName },
                    new ValidateSetAttribute(profile.Contexts.Keys.ToArray())
                    }
                );
                result = true;
            }

            return result;
        }

    }
}

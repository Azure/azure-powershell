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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Context
{
    [Cmdlet(VerbsCommon.Get, "AzureRmContextAutosaveSetting")]
    [OutputType(typeof(ContextAutosaveSettings))]
    public class GetzureRmContextAutosaveSetting : AzureContextModificationCmdlet
    {
        const string NoDirectory = "None";
        public override void ExecuteCmdlet()
        {
            var session = AzureSession.Instance;
            ContextModificationScope scope;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Scope)) && Scope == ContextModificationScope.CurrentUser)
            {
                scope = ScopeHelpers.GetContextModificationScopeForUser(session, WriteDebugWithTimestamp);
            }
            else
            {
                scope = ScopeHelpers.GetContextModificationScopeForProcess(WriteDebugWithTimestamp);
            }

            WriteObject(GetAutoSaveSettings(session, scope));
        }

        ContextAutosaveSettings GetAutoSaveSettings(IAzureSession session, ContextModificationScope scope)
        {
            ContextAutosaveSettings settings = null;
            switch(scope)
            {
                case ContextModificationScope.CurrentUser:
                    settings = new ContextAutosaveSettings
                    {
                        CacheDirectory = session.TokenCacheDirectory,
                        CacheFile = session.TokenCacheFile,
                        ContextDirectory = session.ARMProfileDirectory,
                        ContextFile = session.ARMProfileFile,
                        Mode = ContextSaveMode.CurrentUser
                    };
                    break;
                default:
                    settings = new ContextAutosaveSettings
                    {
                        CacheDirectory = NoDirectory,
                        CacheFile = NoDirectory,
                        ContextDirectory = NoDirectory,
                        ContextFile = NoDirectory,
                        Mode = ContextSaveMode.Process
                    };
                    break;
            }

            return settings;
        }

    }
}

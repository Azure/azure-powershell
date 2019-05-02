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
// TODO: Remove IfDef
#if NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Core;
#endif
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Context
{
    [Cmdlet("Clear", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Context", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class ClearAzureRmContext : AzureContextModificationCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Return a value indicating success or failure")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Delete all users and groups from the global scope without prompting")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (GetContextModificationScope())
            {
                case ContextModificationScope.Process:
                    if (ShouldProcess(Resources.ClearContextProcessMessage, Resources.ClearContextProcessTarget))
                    {
                        ModifyContext(ClearContext);
                    }

                    break;
                case ContextModificationScope.CurrentUser:
                    ConfirmAction(Force.IsPresent, Resources.ClearContextUserContinueMessage, 
                        Resources.ClearContextUserProcessMessage, Resources.ClearContextUserTarget, 
                        () => ModifyContext(ClearContext),
                        () => 
                        {
                            var session = AzureSession.Instance;
                            var contextFilePath = Path.Combine(session.ARMProfileDirectory, session.ARMProfileFile);
                            return session.DataStore.FileExists(contextFilePath);
                        });
                    break;
            }
        }

        void ClearContext(AzureRmProfile profile, RMProfileClient client)
        {
            bool result = false;
            if (profile != null)
            {
                var contexts = profile.Contexts.Values;
                foreach (var context in contexts)
                {
                    client.TryRemoveContext(context);
                }

                var defaultContext = new AzureContext();
                var cache = AzureSession.Instance.TokenCache;
                if (GetContextModificationScope() == ContextModificationScope.CurrentUser)
                {
                    SharedTokenCacheClientFactory.ClearCache();
                }
                else
                {
                    var localCache = cache as AuthenticationStoreTokenCache;
                    if (localCache != null)
                    {
                        localCache.Clear();
                    }
                }

                defaultContext.TokenCache = cache;
                profile.TrySetDefaultContext(defaultContext);
                result = true;
            }

            if (PassThru.IsPresent)
            {
                WriteObject(result);
            }
        }
    }
}

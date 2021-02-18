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

<<<<<<< HEAD
using Microsoft.Azure.Commands.Common.Authentication;
// TODO: Remove IfDef
#if NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Core;
#endif
=======
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
<<<<<<< HEAD
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.IO;
using System.Management.Automation;
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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

<<<<<<< HEAD
=======
        protected override bool RequireDefaultContext() { return false; }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
                    ConfirmAction(Force.IsPresent, Resources.ClearContextUserContinueMessage, 
                        Resources.ClearContextUserProcessMessage, Resources.ClearContextUserTarget, 
                        () => ModifyContext(ClearContext),
                        () => 
=======
                    ConfirmAction(Force.IsPresent, Resources.ClearContextUserContinueMessage,
                        Resources.ClearContextUserProcessMessage, Resources.ClearContextUserTarget,
                        () => ModifyContext(ClearContext),
                        () =>
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
                var defaultContext = new AzureContext();
                var cache = AzureSession.Instance.TokenCache;
                if (GetContextModificationScope() == ContextModificationScope.CurrentUser)
                {
                    var fileCache = cache as ProtectedFileTokenCache;
                    if (fileCache == null)
                    {
                        try
                        {
                            var session = AzureSession.Instance;
                            fileCache = new ProtectedFileTokenCache(Path.Combine(session.TokenCacheDirectory, session.TokenCacheFile), session.DataStore);
                            fileCache.Clear();
                        }
                        catch
                        {
                            // ignore exceptions from creating a token cache
                        }
                    }

                    cache.Clear();
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

=======
                PowerShellTokenCacheProvider tokenCacheProvider;
                if (!AzureSession.Instance.TryGetComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, out tokenCacheProvider))
                {
                    WriteWarning(Resources.ClientFactoryNotRegisteredClear);
                }
                else
                {
                    tokenCacheProvider.ClearCache();
                    var defaultContext = new AzureContext();
                    profile.TrySetDefaultContext(defaultContext);
                    result = true;
                }
            }

            AzureSession.Instance.RaiseContextClearedEvent();

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            if (PassThru.IsPresent)
            {
                WriteObject(result);
            }
        }
    }
}

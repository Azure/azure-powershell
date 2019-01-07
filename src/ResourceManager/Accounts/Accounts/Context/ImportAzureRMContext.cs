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
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Models;
// TODO: Remove IfDef
#if NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Core;
using Microsoft.Azure.Commands.Profile.Models.Core;
#endif
using Microsoft.Azure.Commands.Profile.Properties;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Selects Microsoft Azure profile.
    /// </summary>
    [Cmdlet("Import", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Context", SupportsShouldProcess = true, DefaultParameterSetName = ProfileFromDiskParameterSet), OutputType(typeof(PSAzureProfile))]
    public class ImportAzureRMContextCommand : AzureContextModificationCmdlet
    {
        internal const string InMemoryProfileParameterSet = "InMemoryProfile";
        internal const string ProfileFromDiskParameterSet = "ProfileFromDisk";

        [Parameter(ParameterSetName = InMemoryProfileParameterSet, Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [Alias("Profile")]
        public AzureRmProfile AzureContext { get; set; }

        [Parameter(ParameterSetName = ProfileFromDiskParameterSet, Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        protected override void BeginProcessing()
        {
            // Do not access the DefaultContext when loading a profile
        }

        void CopyProfile(AzureRmProfile source, IProfileOperations target)
        {
            if (source == null || target == null)
            {
                return;
            }

            foreach (var environment in source.Environments)
            {
                IAzureEnvironment merged;
                target.TrySetEnvironment(environment, out merged);
            }

            foreach (var context in source.Contexts)
            {
                target.TrySetContext(context.Key, context.Value);
            }

            if (!string.IsNullOrWhiteSpace(source.DefaultContextKey))
            {
                target.TrySetDefaultContext(source.DefaultContextKey);
            }

            AzureRmProfileProvider.Instance.SetTokenCacheForProfile(target.ToProfile());
            EnsureProtectedCache(target, source.DefaultContext?.TokenCache?.CacheData);
        }

        void EnsureProtectedCache(IProfileOperations profile, byte[] cacheData)
        {
            if (profile == null || cacheData == null)
            {
                return;
            }

            AzureRmAutosaveProfile autosave = profile as AzureRmAutosaveProfile;
            var protectedcache = AzureSession.Instance.TokenCache as ProtectedFileTokenCache;
            if (autosave != null && protectedcache == null && cacheData.Any())
            {
                try
                {
                    var cache = new ProtectedFileTokenCache(cacheData, AzureSession.Instance.DataStore);
                }
                catch
                {
                    WriteWarning(Resources.ImportAuthenticationFailure);
                }
            }
        }

        public override void ExecuteCmdlet()
        {
            bool executionComplete = false;
            if (MyInvocation.BoundParameters.ContainsKey("Path"))
            {
                Path = this.ResolveUserPath(Path);
                ConfirmAction(string.Format(Resources.ProcessImportContextFromFile, Path), Resources.ImportContextTarget, () =>
                {
                    if (!AzureSession.Instance.DataStore.FileExists(Path))
                    {
                        throw new PSArgumentException(string.Format(
                            Microsoft.Azure.Commands.Profile.Properties.Resources.FileNotFound,
                            Path));
                    }

                    ModifyProfile((profile) =>
                    {
                        CopyProfile(new AzureRmProfile(Path), profile);
                        executionComplete = true;
                    });
                });
            }
            else if (AzureContext != null)
            {
                ConfirmAction(Resources.ProcessImportContextFromObject, Resources.ImportContextTarget, () =>
                {
                    ModifyProfile((profile) =>
                    {
                        CopyProfile(AzureContext, profile);
                        executionComplete = true;
                    });
                });
            }

            if (executionComplete)
            {
                var profile = DefaultProfile as AzureRmProfile;
                if (profile == null)
                {
                    WriteExceptionError(new ArgumentException(Resources.AzureProfileMustNotBeNull));
                }
                else
                {
                    if (profile.DefaultContext != null &&
                        profile.DefaultContext.Subscription != null &&
                        profile.DefaultContext.Subscription.State != null &&
                        !profile.DefaultContext.Subscription.State.Equals(
                        "Enabled",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        WriteWarning(string.Format(
                                       Microsoft.Azure.Commands.Profile.Properties.Resources.SelectedSubscriptionNotActive,
                                       profile.DefaultContext.Subscription.State));
                    }

                    WriteObject((PSAzureProfile)profile);
                }
            }
        }
    }
}

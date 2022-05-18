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

using System;
using System.Linq;
using System.Management.Automation;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Models.Core;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;

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
            if (!AzureSession.Instance.TryGetComponent(AzKeyStore.Name, out AzKeyStore keyStore))
            {
                keyStore = null;
            }
            foreach (var context in source.Contexts)
            {
                target.TrySetContext(context.Key, context.Value);
                if (keyStore != null)
                {
                    var account = context.Value.Account;
                    if (account != null)
                    {
                        var secret = account.GetProperty(AzureAccount.Property.ServicePrincipalSecret);
                        if (!string.IsNullOrEmpty(secret))
                        {
                            keyStore.SaveKey(new ServicePrincipalKey(AzureAccount.Property.ServicePrincipalSecret, account.Id, context.Value.Tenant?.Id)
                                , secret.ConvertToSecureString());
                        }
                        var password = account.GetProperty(AzureAccount.Property.CertificatePassword);
                        if (!string.IsNullOrEmpty(password))
                        {
                            keyStore.SaveKey(new ServicePrincipalKey(AzureAccount.Property.CertificatePassword, account.Id, context.Value.Tenant?.Id)
                                ,password.ConvertToSecureString());
                        }
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(source.DefaultContextKey))
            {
                target.TrySetDefaultContext(source.DefaultContextKey);
            }

            EnsureProtectedMsalCache();
        }

        void EnsureProtectedMsalCache()
        {
            try
            {
                if (AzureSession.Instance.TryGetComponent(
                    PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey,
                    out PowerShellTokenCacheProvider tokenCacheProvider))
                {
                    tokenCacheProvider.FlushTokenData();
                }
            }
            catch
            {
                WriteWarning(Resources.ImportAuthenticationFailure);
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
                        CopyProfile(new AzureRmProfile(Path, false), profile);
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
                    var defaultContext = profile.DefaultContext;
                    if (defaultContext != null &&
                        defaultContext.Subscription != null &&
                        defaultContext.Subscription.State != null &&
                        !defaultContext.Subscription.State.Equals(
                        "Enabled",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        WriteWarning(string.Format(
                                       Microsoft.Azure.Commands.Profile.Properties.Resources.SelectedSubscriptionNotActive,
                                       defaultContext.Subscription.State));
                    }

                    WriteObject((PSAzureProfile)profile);
                }
            }
        }
    }
}

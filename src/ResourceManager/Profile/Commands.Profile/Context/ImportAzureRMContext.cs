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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Selects Microsoft Azure profile.
    /// </summary>
    [Cmdlet(VerbsData.Import, "AzureRmContext", SupportsShouldProcess = true), OutputType(typeof(PSAzureProfile))]
    [Alias("Select-AzureRmProfile")]
    [Obsolete("Select-AzureRmProfile will be renamed to Import-AzureRmContext in the next release.")]
    public class ImportAzureRMContextCommand : AzureRMCmdlet
    {
        internal const string InMemoryProfileParameterSet = "InMemoryProfile";
        internal const string ProfileFromDiskParameterSet = "ProfileFromDisk";

        [Parameter(ParameterSetName = InMemoryProfileParameterSet, Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [Alias("Profile")]
        public AzureRMProfile AzureContext { get; set; }

        [Parameter(ParameterSetName = ProfileFromDiskParameterSet, Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        protected override void BeginProcessing()
        {
            // Do not access the DefaultContext when loading a profile
        }

        public override void ExecuteCmdlet()
        {
            bool executionComplete = false;
            if (MyInvocation.BoundParameters.ContainsKey("Path"))
            {
                ConfirmAction(string.Format(Resources.ProcessImportContextFromFile, Path), Resources.ImportContextTarget, () =>
                {
                    if (!Common.Authentication.AzureSession.Instance.DataStore.FileExists(Path))
                    {
                        throw new PSArgumentException(string.Format(
                            Microsoft.Azure.Commands.Profile.Properties.Resources.FileNotFound,
                            Path));
                    }

                    AzureRmProfileProvider.Instance.Profile = new AzureRMProfile(Path);
                    executionComplete = true;
                });
            }
            else
            {
                ConfirmAction(Resources.ProcessImportContextFromObject, Resources.ImportContextTarget, () =>
                {
                    AzureRmProfileProvider.Instance.Profile = AzureContext;
                    executionComplete = true;
                });
            }

            if (executionComplete)
            {
                if (AzureRmProfileProvider.Instance.Profile == null)
                {
                    WriteExceptionError( new ArgumentException(Resources.AzureProfileMustNotBeNull));
                }

                if (AzureRmProfileProvider.Instance.Profile.Context != null &&
                    AzureRmProfileProvider.Instance.Profile.Context.Subscription != null &&
                    AzureRmProfileProvider.Instance.Profile.Context.Subscription.State != null &&
                    !AzureRmProfileProvider.Instance.Profile.Context.Subscription.State.Equals(
                    "Enabled",
                    StringComparison.OrdinalIgnoreCase))
                {
                    WriteWarning(string.Format(
                                   Microsoft.Azure.Commands.Profile.Properties.Resources.SelectedSubscriptionNotActive,
                                   AzureRmProfileProvider.Instance.Profile.Context.Subscription.State));
                }

                WriteObject((PSAzureProfile)AzureRmProfileProvider.Instance.Profile);
            }
        }
    }
}

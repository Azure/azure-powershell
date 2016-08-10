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
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Saves Microsoft Azure profile.
    /// </summary>
    [Cmdlet(VerbsData.Save, "AzureRmProfile", SupportsShouldProcess = true), OutputType(typeof(PSAzureProfile))]
    public class SaveAzureRMProfileCommand : AzureRMCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = true)]
        public AzureRMProfile Profile { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        public string Path { get; set; }

        [Parameter(Mandatory=false, HelpMessage="Overwrite the given file if it exists")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (Profile != null)
            {
                if (ShouldProcess(string.Format(Resources.ProfileArgumentWrite, Path),
                    string.Format(Resources.ProfileWriteWarning, Path),
                    string.Empty))
                {
                    if (!AzureSession.DataStore.FileExists(Path) || Force ||
                        ShouldContinue(string.Format(Resources.FileOverwriteMessage, Path), 
                        Resources.FileOverwriteCaption))
                    {
                        Profile.Save(Path);
                        WriteVerbose(string.Format(Resources.ProfileArgumentSaved, Path));
                    }
                }
            }
            else
            {
                if (ShouldProcess(string.Format(Resources.ProfileCurrentWrite, Path),
                    string.Format(Resources.ProfileWriteWarning, Path), string.Empty))
                {
                    if (AzureRmProfileProvider.Instance.Profile == null)
                    {
                        throw new ArgumentException(Resources.AzureProfileMustNotBeNull);
                    }

                    if (!AzureSession.DataStore.FileExists(Path) || Force ||
                        ShouldContinue(string.Format(Resources.FileOverwriteMessage, Path), 
                        Resources.FileOverwriteCaption))
                    {
                        AzureRmProfileProvider.Instance.Profile.Save(Path);
                        WriteVerbose(string.Format(Resources.ProfileCurrentSaved, Path));
                    }
                }
            }

        }

    }
}

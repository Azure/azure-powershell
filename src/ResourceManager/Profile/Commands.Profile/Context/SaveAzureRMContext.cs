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
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Commands.Profile.Netcore;
using Commands.Profile.Netcore.Properties;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Saves Microsoft Azure profile.
    /// </summary>
    [Cmdlet(VerbsData.Save, "AzureRmContext", SupportsShouldProcess = true), OutputType(typeof(PSAzureProfile))]
    [Alias("Save-AzureRmProfile")]
    [Obsolete("Save-AzureRmProfile will be renamed to Save-AzureRmContext in the next release.", false)]
    public class SaveAzureRMContextCommand : AzureRMCmdlet
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
                if (ShouldProcess(string.Format(Messages.ProfileArgumentWrite, Path),
                    string.Format(Messages.ProfileWriteWarning, Path),
                    string.Empty))
                {
                    if (!AzureSession.DataStore.FileExists(Path) || Force ||
                        ShouldContinue(string.Format(Messages.FileOverwriteMessage, Path),
                        Messages.FileOverwriteCaption))
                    {
                        Profile.Save(Path);
                        WriteVerbose(string.Format(Messages.ProfileArgumentSaved, Path));
                    }
                }
            }
            else
            {
                if (ShouldProcess(string.Format(Messages.ProfileCurrentWrite, Path),
                    string.Format(Messages.ProfileWriteWarning, Path), string.Empty))
                {
                    if (AzureRmProfileProvider.Instance.Profile == null)
                    {
                        throw new ArgumentException(Messages.AzureProfileMustNotBeNull);
                    }

                    if (!AzureSession.DataStore.FileExists(Path) || Force.IsPresent ||
                        ShouldContinue(string.Format(Messages.FileOverwriteMessage, Path),
                        Messages.FileOverwriteCaption))
                    {
                        AzureRmProfileProvider.Instance.Profile.Save(Path);
                        WriteVerbose(string.Format(Messages.ProfileCurrentSaved, Path));
                    }
                }
            }

        }

    }
}

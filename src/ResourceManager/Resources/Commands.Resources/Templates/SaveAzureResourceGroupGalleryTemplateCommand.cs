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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Resources.Models;

namespace Microsoft.Azure.Commands.Resources.Templates
{
    /// <summary>
    /// Downloads a template file to the disk.
    /// </summary>
    [Cmdlet(VerbsData.Save, "AzureResourceGroupGalleryTemplate"), OutputType(typeof(PSObject))]
    public class SaveAzureResourceGroupGalleryTemplateCommand : ResourcesBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The gallery template identity.")]
        [ValidateNotNullOrEmpty]
        public string Identity { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The output path of the file.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            string path = GalleryTemplatesClient.DownloadGalleryTemplateFile(
                Identity,
                string.IsNullOrEmpty(Path) ? System.IO.Path.Combine(CurrentPath(), Identity) : this.TryResolvePath(Path),
                Force,
                ConfirmAction);
            WriteObject(PowerShellUtilities.ConstructPSObject(null, "Path", path));
        }
    }
}

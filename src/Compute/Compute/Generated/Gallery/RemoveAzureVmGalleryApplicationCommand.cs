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
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmGalleryApplication", SupportsShouldProcess = true)]
    [OutputType(typeof(PSVirtualMachine))]
    public class RemoveAzureVmGalleryApplicationCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The PSVirtualMachine object to delete a Gallery Application Reference ID from.")]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Package Reference Id of the Gallery Application to delete.")]
        [ValidateNotNullOrEmpty]
        public string GalleryApplicationsReferenceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (VM.ApplicationProfile == null)
            {
                WriteObject(VM);
            }

            for (int i = 0; i < VM.ApplicationProfile.GalleryApplications.Count; i++) 
            {
                if (VM.ApplicationProfile.GalleryApplications[i].PackageReferenceId == GalleryApplicationsReferenceId)
                {
                    VM.ApplicationProfile.GalleryApplications.RemoveAt(i);
                    break;
                }
            }
            WriteObject(VM);
        }
    }
}

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
using Microsoft.Azure.Commands.Compute.Automation.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssGalleryApplication", SupportsShouldProcess = true)]
    [OutputType(typeof(PSVirtualMachineScaleSetVMProfile))]
    public class RemoveAzureVmssGalleryApplicationCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The PSVirtualMachineScaleSetVMProfile object to delete a Gallery Application Reference ID from.")]
        public PSVirtualMachineScaleSetVMProfile VirtualMachineScaleSetVM { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Package Reference Id of the Gallery Application to delete.")]
        [ValidateNotNullOrEmpty]
        public string GalleryApplicationsReferenceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (VirtualMachineScaleSetVM.ApplicationProfile == null)
            {
                WriteObject(VirtualMachineScaleSetVM);
            }

            for (int i = 0; i < VirtualMachineScaleSetVM.ApplicationProfile.GalleryApplications.Count; i++)
            {
                if (VirtualMachineScaleSetVM.ApplicationProfile.GalleryApplications[i].PackageReferenceId == GalleryApplicationsReferenceId)
                {
                    VirtualMachineScaleSetVM.ApplicationProfile.GalleryApplications.RemoveAt(i);
                    break;
                }
            }
            WriteObject(VirtualMachineScaleSetVM);
        }
    }
}

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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.DiskRepository
{
    [Cmdlet(
        VerbsCommon.Remove,
        AzureVMImageNoun),
    OutputType(
        typeof(ManagementOperationContext))]
    public class RemoveAzureVMImage : ServiceManagementBaseCmdlet
    {
        protected const string AzureVMImageNoun = "AzureVMImage";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the image in the image library to remove.")]
        [ValidateNotNullOrEmpty]
        public string ImageName { get; set; }

        [Parameter(
            Position = 1,
            HelpMessage = "Specify to remove the underlying VHD from the blob storage.")]
        public SwitchParameter DeleteVHD { get; set; }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            this.ExecuteClientActionNewSM(
                    null,
                    this.CommandRuntime.ToString(),
                    () =>
                    {
                        AzureOperationResponse op = null;

                        var imageType = new VirtualMachineImageHelper(this.ComputeClient).GetImageType(this.ImageName);
                        bool isOSImage = imageType.HasFlag(VirtualMachineImageType.OSImage);
                        bool isVMImage = imageType.HasFlag(VirtualMachineImageType.VMImage);

                        if (isOSImage && isVMImage)
                        {
                            WriteErrorWithTimestamp(
                                string.Format(Resources.DuplicateNamesFoundInBothVMAndOSImages, this.ImageName));
                        }
                        else if (isVMImage)
                        {
                            op = this.ComputeClient.VirtualMachineVMImages.Delete(this.ImageName, this.DeleteVHD.IsPresent);
                        }
                        else
                        {
                            // Remove the image from the image repository
                            op = this.ComputeClient.VirtualMachineOSImages.Delete(this.ImageName, this.DeleteVHD.IsPresent);
                        }

                        return op;
                    });
        }
    }
}

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
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ImagePublishing
{
    [Cmdlet(VerbsCommon.Remove, "AzurePlatformVMImage"), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzurePlatformVMImage : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the image in the image library.")]
        [ValidateNotNullOrEmpty]
        public string ImageName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            var imageType = new VirtualMachineImageHelper(this.ComputeClient).GetImageType(this.ImageName);
            bool isOSImage = imageType.HasFlag(VirtualMachineImageType.OSImage);
            bool isVMImage = imageType.HasFlag(VirtualMachineImageType.VMImage);

            if (isOSImage && isVMImage)
            {
                WriteErrorWithTimestamp(
                    string.Format(Resources.DuplicateNamesFoundInBothVMAndOSImages, this.ImageName));
            }
            else if (isOSImage || !isVMImage)
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () =>
                    {
                        this.ComputeClient.VirtualMachineOSImages.Get(this.ImageName);
                        return this.ComputeClient.VirtualMachineOSImages.Unreplicate(this.ImageName);
                    });
            }
            else
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () =>
                    {
                        this.ComputeClient.VirtualMachineVMImages.GetDetails(this.ImageName);
                        return this.ComputeClient.VirtualMachineVMImages.Unreplicate(this.ImageName);
                    });
            }
        }
    }
}

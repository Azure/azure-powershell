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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.DiskRepository
{
    [Cmdlet(
        VerbsCommon.Get,
        AzureVMImageNoun),
    OutputType(
        typeof(OSImageContext),
        typeof(VMImageContext))]
    public class GetAzureVMImage : ServiceManagementBaseCmdlet
    {
        protected const string AzureVMImageNoun = "AzureVMImage";

        [Parameter(
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Name of the image in the image library.")]
        [ValidateNotNullOrEmpty]
        public string ImageName { get; set; }

        protected void GetAzureVMImageProcess()
        {
            ServiceManagementProfile.Initialize();

            if (string.IsNullOrEmpty(this.ImageName))
            {
                this.ExecuteClientActionNewSM(
                    null,
                    this.CommandRuntime.ToString(),
                    () => this.ComputeClient.VirtualMachineOSImages.List(),
                    (s, response) => response.Images.Select(
                        t => this.ContextFactory<VirtualMachineOSImageListResponse.VirtualMachineOSImage, OSImageContext>(t, s)));

                this.ExecuteClientActionNewSM(
                    null,
                    this.CommandRuntime.ToString(),
                    () => this.ComputeClient.VirtualMachineVMImages.List(),
                    (s, response) => response.VMImages.Select(
                        t => this.ContextFactory<VirtualMachineVMImageListResponse.VirtualMachineVMImage, VMImageContext>(t, s)));
            }
            else
            {
                var imageType = new VirtualMachineImageHelper(this.ComputeClient).GetImageType(this.ImageName);
                bool isOSImage = imageType.HasFlag(VirtualMachineImageType.OSImage);
                bool isVMImage = imageType.HasFlag(VirtualMachineImageType.VMImage);

                if (isOSImage || !isVMImage)
                {
                    this.ExecuteClientActionNewSM(
                        null,
                        this.CommandRuntime.ToString(),
                        () => this.ComputeClient.VirtualMachineOSImages.Get(this.ImageName),
                        (s, t) => this.ContextFactory<VirtualMachineOSImageGetResponse, OSImageContext>(t, s));
                }

                if (isVMImage)
                {
                    this.ExecuteClientActionNewSM(
                        null,
                        this.CommandRuntime.ToString(),
                        () => this.ComputeClient.VirtualMachineVMImages.List(),
                        (s, imgs) => imgs
                            .Where(t => string.Equals(t.Name, this.ImageName, StringComparison.OrdinalIgnoreCase))
                            .Select(t => this.ContextFactory<VirtualMachineVMImageListResponse.VirtualMachineVMImage, VMImageContext>(t, s)));
                }
            }
        }

        protected override void OnProcessRecord()
        {
            GetAzureVMImageProcess();
        }
    }
}

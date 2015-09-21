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
using System.Net;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Management.Compute;
using Hyak.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Helpers
{
    public class VirtualMachineImageHelper
    {
        private ComputeManagementClient computeClient;

        public VirtualMachineImageHelper(ComputeManagementClient computeClient)
        {
            this.computeClient = computeClient;
        }

        public VirtualMachineImageType GetImageType(string imageName)
        {
            var imageType = VirtualMachineImageType.None;

            try
            {
                var isOSImage = string.Equals(
                        computeClient.VirtualMachineOSImages.Get(imageName).Name,
                        imageName,
                        StringComparison.OrdinalIgnoreCase);

                imageType |= isOSImage ? VirtualMachineImageType.OSImage : VirtualMachineImageType.None;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            try
            {
                var isVMImage = computeClient.VirtualMachineVMImages.List()
                    .VMImages.Any(e => string.Equals(
                        e.Name,
                        imageName,
                        StringComparison.OrdinalIgnoreCase));

                imageType |= isVMImage ? VirtualMachineImageType.VMImage : VirtualMachineImageType.None;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            return imageType;
        }
    }
}

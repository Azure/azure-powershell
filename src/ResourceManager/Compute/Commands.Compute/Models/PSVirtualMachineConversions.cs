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

using Microsoft.Azure.Management.Compute.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public static class PSVirtualMachineConversions
    {
        public static PSVirtualMachine ToPSVirtualMachine(
            this VirtualMachineGetResponse response,
            string resourceGroupName = null)
        {
            if (response == null)
            {
                return null;
            }

            return response.VirtualMachine.ToPSVirtualMachine(resourceGroupName);
        }

        public static PSVirtualMachine ToPSVirtualMachine(
            this VirtualMachine virtualMachine,
            string resourceGroupName = null)
        {
            PSVirtualMachine result = new PSVirtualMachine
            {
                ResourceGroupName = resourceGroupName,
                Name = virtualMachine == null ? null : virtualMachine.Name,
                ProvisioningState = virtualMachine.VirtualMachineProperties.ProvisioningState,
                Tags = virtualMachine.Tags,
                OSProfile = virtualMachine.VirtualMachineProperties.OSProfile,
                HardwareProfile = virtualMachine.VirtualMachineProperties.HardwareProfile,
                StorageProfile = virtualMachine.VirtualMachineProperties.StorageProfile,
                NetworkProfile = virtualMachine.VirtualMachineProperties.NetworkProfile
            };

            return result;
        }

        public static List<PSVirtualMachine> ToPSVirtualMachineList(
            this VirtualMachineListResponse response,
            string resourceGroupName = null)
        {
            List<PSVirtualMachine> results = new List<PSVirtualMachine>();

            if (response != null && response.VirtualMachines != null)
            {
                foreach (var item in response.VirtualMachines)
                {
                    var vm = item.ToPSVirtualMachine(resourceGroupName);
                    results.Add(vm);
                }
            }

            return results;
        }
    }
}

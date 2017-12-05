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

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.Common.Strategies.Compute
{
    public static class VirtualMachineScaleSetStrategy
    {
        public static ResourceStrategy<VirtualMachineScaleSet> Strategy { get; }
            = ComputePolicy.Create(
                "virtual machine scale set",
                "virtualMachines",
                client => client.VirtualMachineScaleSets,
                (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, p.CancellationToken),
                (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                _ => 180);

        public static ResourceConfig<VirtualMachineScaleSet> CreateVirtualMachineScaleSetConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            string adminUsername,
            string adminPassword,
            Image image)
            => Strategy.CreateConfig(
                resourceGroup,
                name, 
                subscription => new VirtualMachineScaleSet
                {

                });
    }
}

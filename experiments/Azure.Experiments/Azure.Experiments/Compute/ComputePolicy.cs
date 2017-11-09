using Microsoft.Azure.Experiments.ResourceManager;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments.Compute
{
    public static class ComputePolicy
    {
        public static ResourcePolicy<ResourceName, Info> Create<Operations, Info>(
            Func<IComputeManagementClient, Operations> getOperations,
            Func<Operations, ResourceName, Task<Info>> getAsync,
            Func<Operations, ResourceName, Info, Task<Info>> createOrUpdateAsync)
            where Info : Management.Compute.Models.Resource
            => OperationsPolicy
                .Create(getAsync, createOrUpdateAsync)
                .Transform(getOperations)
                .CreateResourcePolicy(i => i.Location, (i, location) => i.Location = location);

        public static ResourcePolicy<ResourceName, VirtualMachine> VirtualMachine
        { get; }
            = Create(
                client => client.VirtualMachines,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<ResourceName, VirtualMachine> CreateVirtualMachineConfig(
            this ResourceConfig<string, ResourceGroup> resourceGroup,
            string name,
            ResourceConfig<ResourceName, NetworkInterface> networkInterface)
            => resourceGroup.CreateResourceConfig(
                VirtualMachine,
                name,
                new VirtualMachine(),
                new [] { networkInterface });
    }
}

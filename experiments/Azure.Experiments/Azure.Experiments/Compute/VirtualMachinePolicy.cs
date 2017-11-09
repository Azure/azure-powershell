using Microsoft.Azure.Experiments.ResourceManager;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.Compute
{
    public static class VirtualMachinePolicy
    {
        public static ResourcePolicy<ResourceName, VirtualMachine> Policy { get; }
            = ComputePolicy.Create(
                client => client.VirtualMachines,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<ResourceName, VirtualMachine> CreateVirtualMachineConfig(
            this ResourceConfig<string, ResourceGroup> resourceGroup,
            string name,
            ResourceConfig<ResourceName, NetworkInterface> networkInterface)
            => resourceGroup.CreateResourceConfig(
                Policy,
                name,
                _ => new VirtualMachine(),
                new[] { networkInterface });
    }
}

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Compute
{
    public static class VirtualMachinePolicy
    {
        public static ResourcePolicy<VirtualMachine> Policy { get; }
            = ComputePolicy.Create(
                client => client.VirtualMachines,
                (operations, name) => operations.GetAsync(name.ResourceGroupName, name.Name),
                (operations, name, info)
                    => operations.CreateOrUpdateAsync(name.ResourceGroupName, name.Name, info));

        public static ResourceConfig<VirtualMachine> CreateVirtualMachineConfig(
            this ResourceName name,
            ResourceConfig<NetworkInterface> networkInterface)
            => Policy.CreateConfig(
                name,
                _ => new VirtualMachine(),
                new[] { networkInterface });
    }
}

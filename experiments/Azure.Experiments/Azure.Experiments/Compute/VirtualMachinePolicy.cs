using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.Compute
{
    public static class VirtualMachinePolicy
    {
        public static ResourcePolicy<VirtualMachine> Policy { get; }
            = ComputePolicy.Create(
                "virtualMachines",
                client => client.VirtualMachines,
                p => p.Operations.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                p => p.Operations.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Config, p.CancellationToken));

        public static ResourceConfig<VirtualMachine> CreateVirtualMachineConfig(
            this ResourceConfig<ResourceGroup> resourceGroup, string name)
            => Policy.CreateConfig(resourceGroup, name);
    }
}

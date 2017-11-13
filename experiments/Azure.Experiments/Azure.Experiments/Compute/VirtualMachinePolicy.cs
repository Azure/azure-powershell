using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.Compute
{
    public static class VirtualMachinePolicy
    {
        public static ResourcePolicy<ResourceName, VirtualMachine> Policy { get; }
            = ComputePolicy.Create(
                client => client.VirtualMachines,
                (operations, name, cancellationTokent)
                    => operations.GetAsync(
                        name.ResourceGroupName, name.Name, cancellationToken: cancellationTokent),
                (operations, name, config, cancellationTokent)
                    => operations.CreateOrUpdateAsync(
                        name.ResourceGroupName, name.Name, config, cancellationTokent));

        public static ResourceConfig<ResourceName, VirtualMachine> CreateVirtualMachineConfig(
            this ResourceConfig<string, ResourceGroup> resourceGroup, string name)
            => Policy.CreateConfig(resourceGroup, name);
    }
}

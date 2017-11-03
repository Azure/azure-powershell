using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments.Compute
{
    public static class VirtualMachineConfig
    {
        public static ResourceConfig<VirtualMachine> Create(
            string name,
            ResourceConfig<ResourceGroup> resourceGroup,
            ResourceConfig<NetworkInterface> networkInterface)
            => ManagedResourceConfig.Create(
                resourceGroup,
                name,
                new[] { networkInterface },
                c => c
                    .CreateComputeManagementClient()
                    .VirtualMachines
                    .GetAsync(resourceGroup.Name, name),
                c => c.Location);
    }
}

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
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
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            ResourceConfig<NetworkInterface> networkInterface,
            string adminUsername,
            string adminPassword)
            => Policy.CreateConfig(
                resourceGroup,
                name, 
                subscription => new VirtualMachine
                {
                    OsProfile = new OSProfile
                    {
                        ComputerName = name,
                        WindowsConfiguration = new WindowsConfiguration
                        {
                        },
                        AdminUsername = adminUsername,
                        AdminPassword = adminPassword,
                    },
                    NetworkProfile = new NetworkProfile
                    {
                        NetworkInterfaces = new[]
                        {
                            new NetworkInterfaceReference
                            {
                                Id = networkInterface.GetId(subscription).IdToString()
                            }
                        }
                    },
                    HardwareProfile = new HardwareProfile
                    {
                        VmSize = "Standard_DS1_v2"
                    },
                    StorageProfile = new StorageProfile
                    {
                        ImageReference = new ImageReference
                        {
                            Publisher = "MicrosoftWindowsServer",
                            Offer = "WindowsServer",
                            Sku = "2016-Datacenter",
                            Version = "latest"
                        }
                    },
                },
                new[] { networkInterface });
    }
}

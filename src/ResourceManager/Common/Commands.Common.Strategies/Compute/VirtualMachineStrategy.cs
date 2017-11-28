using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.Common.Strategies.Compute
{
    public static class VirtualMachineStrategy
    {
        public static ResourceStrategy<VirtualMachine> Strategy { get; }
            = ComputePolicy.Create(
                "virtual machine",
                "virtualMachines",
                client => client.VirtualMachines,
                (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken));

        public static ResourceConfig<VirtualMachine> CreateVirtualMachineConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            ResourceConfig<NetworkInterface> networkInterface,
            string adminUsername,
            string adminPassword,
            Image image)
            => Strategy.CreateConfig(
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
                            Publisher = image.publisher,
                            Offer = image.offer,
                            Sku = image.sku,
                            Version = image.version
                        }
                    },
                },
                new[] { networkInterface });
    }
}

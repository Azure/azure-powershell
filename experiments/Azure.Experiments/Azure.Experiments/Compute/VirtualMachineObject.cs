using Azure.Experiments.Network;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System.Threading.Tasks;

namespace Azure.Experiments.Compute
{
    public sealed class VirtualMachineObject 
        : ResourceObject<VirtualMachine, ComputePolicy<VirtualMachine>>
    {
        public VirtualMachineObject(
            Context c,
            string name,
            ResourceGroupObject rg,
            NetworkInterfaceObject ni,
            string adminUsername,
            string adminPassword) 
            : base(name, rg, new[] { ni })
        {
            Client = new ComputeManagementClient(c.Credentials)
                {
                    SubscriptionId = c.SubscriptionId
                }
                .VirtualMachines;
            AdminUsername = adminUsername;
            AdminPassword = adminPassword;
            Ni = ni;
        }

        protected override Task<VirtualMachine> CreateAsync(string location)
            => Client.CreateOrUpdateAsync(
                ResourceGroupName,
                Name,
                new VirtualMachine
                {
                    Location = "eastus",
                    OsProfile = new OSProfile
                    {           
                        ComputerName = Name,
                        WindowsConfiguration = new WindowsConfiguration
                        {                            
                        },
                        AdminUsername = AdminUsername,
                        AdminPassword = AdminPassword,
                    },
                    NetworkProfile = new NetworkProfile
                    {
                        NetworkInterfaces = new NetworkInterfaceReference[]
                        {
                            new NetworkInterfaceReference(Ni.Info.Id)
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
                });

        protected override Task<VirtualMachine> GetOrThrowAsync()
            => Client.GetAsync(ResourceGroupName, Name);

        private string AdminUsername { get; }

        private string AdminPassword { get; }

        private NetworkInterfaceObject Ni { get; }

        private IVirtualMachinesOperations Client { get; }
    }
}

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    public sealed class VmObject 
        : ResourceObject<VirtualMachine, IVirtualMachinesOperations>
    {
        public VmObject(
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

        protected override Task<VirtualMachine> CreateAsync(
            IVirtualMachinesOperations _)
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

        protected override IVirtualMachinesOperations CreateClient(Context c)
            => new ComputeManagementClient(c.Credentials)
                {
                    SubscriptionId = c.SubscriptionId
                }
                .VirtualMachines;

        protected override Task<VirtualMachine> GetOrThrowAsync(IVirtualMachinesOperations _)
            => Client.GetAsync(ResourceGroupName, Name);

        private string AdminUsername { get; }

        private string AdminPassword { get; }

        private NetworkInterfaceObject Ni { get; }

        private IVirtualMachinesOperations Client { get; }
    }
}

using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Experiments.Compute
{
    public sealed class VirtualMachinePolicy
        : ComputePolicy<VirtualMachine, IVirtualMachinesOperations>
    {
        public override Task<VirtualMachine> CreateOrUpdateAsync(CreateParams p)
            => p.Operations.CreateOrUpdateAsync(
                p.ResourceGroupName, p.Name, p.Info, p.CancellationToken);

        public override Task<VirtualMachine> GetAsync(GetParams p)
            => p.Operations.GetAsync(
                p.ResourceGroupName, p.Name, cancellationToken: p.CancellationToken);

        public override IVirtualMachinesOperations GetOperations(IComputeManagementClient client)
            => client.VirtualMachines;
    }

    /*
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
                state => new VirtualMachine
                {
                    NetworkProfile = new NetworkProfile
                    {
                        NetworkInterfaces = new []
                        {
                            new NetworkInterfaceReference
                            {
                                Id = state.Get(networkInterface).Id
                            }
                        }
                    }
                },
                new[] { networkInterface });
    }
    */
}

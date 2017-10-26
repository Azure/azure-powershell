using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Experiments.Network;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute;

namespace Microsoft.Azure.Experiments.Compute
{
    public sealed class VirtualMachineParameters : ResourceParameters<VirtualMachine>
    {
        public NetworkInterfaceParameters Ni { get; }

        public VirtualMachineParameters(
            string name,
            ResourceGroupParameters resourceGroup,
            NetworkInterfaceParameters ni)
            : base(name, resourceGroup, new[] { ni })
        {
            Ni = ni;
        }

        public override Task<VirtualMachine> GetAsync(GetContext context)
            => context
                .Context
                .CreateCompute()
                .VirtualMachines
                .GetAsync(ResourceGroup.Name, Name);
    }
}

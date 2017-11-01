using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Experiments.Network;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments.Compute
{
    public sealed class VirtualMachineParameters
        : ResourceParameters<VirtualMachine>
    {
        public override string Name { get; }

        public NetworkInterfaceParameters Ni { get; }

        public override ResourceGroupParameters ResourceGroup { get; }

        public override IEnumerable<Parameters> ResourceDependencies => new[] { Ni };

        public VirtualMachineParameters(
            string name,
            ResourceGroupParameters resourceGroup,
            NetworkInterfaceParameters ni)
        {
            Name = name;
            ResourceGroup = resourceGroup;
            Ni = ni;
        }

        protected override Task<VirtualMachine> GetAsync(
            Context context, IGetParameters _)
            => context
                .CreateCompute()
                .VirtualMachines
                .GetAsync(ResourceGroup.Name, Name);

        public override string GetLocation(VirtualMachine value)
            => value.Location;
    }
}

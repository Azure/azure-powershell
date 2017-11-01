using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Models;
using System.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class SubnetParameters : Parameters<Subnet>
    {
        public override string Name { get; }

        public VirtualNetworkParameters VirtualNetwork { get; }

        public override IEnumerable<Parameters> Dependencies
            => new[] { VirtualNetwork };

        public override bool HasCommonLocation => true;

        public SubnetParameters(
            string name, VirtualNetworkParameters virtualNetwork)
        {
            Name = name;
            VirtualNetwork = virtualNetwork;
        }

        protected override async Task<Subnet> GetAsync(
            Context context, IGetParameters getParameters)
        {
            var virtualNetwork =
                await VirtualNetwork.GetOrNullAsync(context, getParameters);
            return virtualNetwork?.Subnets.FirstOrDefault(s => s.Name == Name);
        }

        public override string GetLocation(Subnet _)
            => null;
    }
}

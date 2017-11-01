using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Models;
using System.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class SubnetParameters : ResourceParameters<Subnet>
    {
        public override string Name { get; }

        public VirtualNetworkParameters VirtualNetwork { get; }

        public override IEnumerable<ResourceParameters> Dependencies => new[] { VirtualNetwork };

        public override bool HasCommonLocation => true;

        public SubnetParameters(string name, VirtualNetworkParameters virtualNetwork)
        {
            Name = name;
            VirtualNetwork = virtualNetwork;
        }

        protected override async Task<Subnet> GetAsync(IGetInfoContext getContext)
        {
            var virtualNetwork =
                await VirtualNetwork.GetOrNullAsync(getContext);
            return virtualNetwork?.Subnets.FirstOrDefault(s => s.Name == Name);
        }

        /// <summary>
        /// Subnet doesn't have a location.
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public override string GetLocation(Subnet _) => null;
    }
}

using Microsoft.Azure.Management.Network.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments.Network
{
    public static class SubnetConfig
    {
        public static ResourceConfig<Subnet> Create(
            string name, ResourceConfig<VirtualNetwork> virtualNetwork)
            => ResourceConfig.Create(
                name,
                new[] { virtualNetwork },
                _ => Task.FromResult<Subnet>(null),
                null,
                (map, _) => map.Get(virtualNetwork)?.Subnets?.FirstOrDefault(v => v.Name == name),
                (_0, _1) => null);
    }
}

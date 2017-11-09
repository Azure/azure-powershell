using Microsoft.Azure.Management.Network.Models;
using System.Linq;

namespace Microsoft.Azure.Experiments.Network
{
    public static class SubnetPolicy
    {
        public static ChildResourcePolicy<Subnet, VirtualNetwork> Policy { get; }
            = ChildResourcePolicy.Create<Subnet, VirtualNetwork>(
                (p, name) => p.Subnets.FirstOrDefault(s => s.Name == name),
                (p, subnet) => p.Subnets = p.Subnets.Concat(new[] { subnet }).ToArray());

        public static ChildResourceConfig<Subnet, VirtualNetwork> CreateSubnetConfig(
            ResourceConfig<VirtualNetwork> virtualNetwork, string name)
            => Policy.CreateConfig(virtualNetwork, name);
    }
}

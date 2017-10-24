using Microsoft.Azure.Management.Network.Models;

namespace Azure.Experiments
{
    public struct SubnetPolicy : IInfoPolicy<Subnet>
    {
        public string GetLocation(Subnet value) => null;
    }
}

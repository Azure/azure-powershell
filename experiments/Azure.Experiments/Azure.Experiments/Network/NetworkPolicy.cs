using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Experiments.Network
{
    public abstract class NetworkPolicy<Info, Operations> 
        : ResourcePolicy<Info, INetworkManagementClient, Operations>
        where Info : Resource
    {
        public sealed override string GetLocation(Info info)
            => info.Location;

        public sealed override void SetLocation(Info info, string location)
            => info.Location = location;
    }
}

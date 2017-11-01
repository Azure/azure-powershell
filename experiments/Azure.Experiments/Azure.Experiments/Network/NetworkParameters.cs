using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Experiments.Network
{
    public abstract class NetworkParameters<T> : ManagedResourceParameters<T>
        where T : Resource
    {
        public sealed override string GetLocation(T value) => value.Location;

        protected sealed override Task<T> GetAsync(IGetInfoContext context)
            => GetAsync(context.Context.CreateNetworkManagementClient());

        protected abstract Task<T> GetAsync(NetworkManagementClient client);
    }
}

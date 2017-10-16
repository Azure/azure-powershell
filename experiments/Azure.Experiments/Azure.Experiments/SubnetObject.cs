using Microsoft.Azure.Management.Network;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    sealed class SubnetObject : AzureObject<object, IVirtualNetworksOperations>
    {
        public SubnetObject(string name, VirtualNetworkObject vn) 
            : base(name, new[] { vn })
        {
            Vn = vn;
        }

        protected override Task<object> CreateAsync(IVirtualNetworksOperations c)
        {
            throw new NotImplementedException();
        }

        protected override IVirtualNetworksOperations CreateClient(Context c)
            => c.CreateNetwork().VirtualNetworks;

        protected override Task DeleteAsync(IVirtualNetworksOperations c)
        {
            throw new NotImplementedException();
        }

        protected override async Task<object> GetOrThrowAsync(IVirtualNetworksOperations c)
            => (await Vn.GetOrNullAsync(c))
                ?.Subnets
                .FirstOrDefault(s => s.Name == Name);

        private VirtualNetworkObject Vn { get; }
    }
}

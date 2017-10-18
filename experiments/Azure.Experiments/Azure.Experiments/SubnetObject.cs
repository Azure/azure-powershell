using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    public sealed class SubnetObject : AzureObject<Subnet>
    {
        public string AddressPrefix { get; }

        public SubnetObject(
            string name, VirtualNetworkObject vn, string addressPrefix) 
            : base(name, new[] { vn })
        {
            Vn = vn;
            AddressPrefix = addressPrefix;
        }

        protected override async Task<Subnet> CreateAsync()
        {
            // The Virtual Network should be created at this point.
            var vn = await Vn.GetOrNullAsync();
            vn.Subnets.Add(new Subnet { Name = Name, AddressPrefix = AddressPrefix });
            vn = await Vn.Client.CreateOrUpdateAsync(
                Vn.ResourceGroupName, Vn.Name, vn);
            return GetSubnet(vn);
        }

        protected override async Task<Subnet> GetOrThrowAsync()
            => GetSubnet(await Vn.GetOrNullAsync());

        private VirtualNetworkObject Vn { get; }

        private Subnet GetSubnet(VirtualNetwork vn)
            => vn?.Subnets.FirstOrDefault(s => s.Name == Name);
    }
}

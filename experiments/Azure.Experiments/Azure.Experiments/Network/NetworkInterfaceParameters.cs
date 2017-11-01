using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class NetworkInterfaceParameters 
        : NetworkParameters<NetworkInterface>
    {
        public override string Name { get; }

        public override ResourceGroupParameters ResourceGroup { get; }

        public SubnetParameters Subnet { get; }

        public NetworkSecurityGroupParameters Nsg { get; }

        public PublicIpAddressParameters Pia { get; }

        public override IEnumerable<Parameters> ResourceDependencies 
            => new Parameters[] { Subnet, Nsg, Pia };

        public NetworkInterfaceParameters(
            string name,
            ResourceGroupParameters resourceGroup,
            SubnetParameters subnet,
            NetworkSecurityGroupParameters nsg,
            PublicIpAddressParameters pia)
        {
            Name = name;
            ResourceGroup = resourceGroup;
            Subnet = subnet;
            Nsg = nsg;
            Pia = pia;
        }

        protected override Task<NetworkInterface> GetAsync(
            Context context, IGetParameters _)
            => context
                .CreateNetwork()
                .NetworkInterfaces
                .GetAsync(ResourceGroup.Name, Name);
    }
}

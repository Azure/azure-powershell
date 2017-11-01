using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class NetworkInterfaceParameters : NetworkParameters<NetworkInterface>
    {
        public override string Name { get; }

        public override ResourceGroupParameters ResourceGroup { get; }

        public SubnetParameters Subnet { get; }

        public NetworkSecurityGroupParameters SecurityGroup { get; }

        public PublicIpAddressParameters PublicIpAddress { get; }

        public override IEnumerable<ResourceParameters> ResourceDependencies
            => new ResourceParameters[] { Subnet, SecurityGroup, PublicIpAddress };

        public NetworkInterfaceParameters(
            string name,
            ResourceGroupParameters resourceGroup,
            SubnetParameters subnet,
            NetworkSecurityGroupParameters securityGroup,
            PublicIpAddressParameters publicIpAddress)
        {
            Name = name;
            ResourceGroup = resourceGroup;
            Subnet = subnet;
            SecurityGroup = securityGroup;
            PublicIpAddress = publicIpAddress;
        }

        protected override Task<NetworkInterface> GetAsync(NetworkManagementClient client)
            => client.NetworkInterfaces.GetAsync(ResourceGroup.Name, Name);
    }
}

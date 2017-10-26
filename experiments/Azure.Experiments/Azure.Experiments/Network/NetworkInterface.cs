using System.Collections.Generic;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class NetworkInterfaceParameters 
        : ResourceParameters<NetworkInterface>
    {
        public SubnetParameters Subnet { get; }

        public NetworkSecurityGroupParameters Nsg { get; }

        public PublicIpAddressParameters Pia { get; }

        public NetworkInterfaceParameters(
            string name,
            ResourceGroupParameters resourceGroup,
            SubnetParameters subnet,
            NetworkSecurityGroupParameters nsg,
            PublicIpAddressParameters pia) 
            : base(name, resourceGroup, new Parameters[] { subnet, nsg, pia })
        {
            Subnet = subnet;
            Nsg = nsg;
            Pia = pia;
        }
    }
}

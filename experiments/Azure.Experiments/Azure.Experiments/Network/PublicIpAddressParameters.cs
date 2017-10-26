using System.Collections.Generic;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Experiments.Network
{
    public sealed class PublicIpAddressParameters 
        : ResourceParameters<PublicIPAddress>
    {
        public PublicIpAddressParameters(
            string name, ResourceGroupParameters resourceGroup)
            : base(name, resourceGroup, NoDependencies)
        {
        }
    }
}

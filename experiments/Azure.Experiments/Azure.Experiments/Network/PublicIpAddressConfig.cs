using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Experiments.Network
{
    public static class PublicIpAddressConfig
    {
        public static ResourceConfig<PublicIPAddress> Create(
            ResourceConfig<ResourceGroup> resourceGroup, string name)
            => NetworkResourceConfig.Create(
                resourceGroup,
                name,                
                new IResourceConfig[] { },
                c => c.PublicIPAddresses.GetAsync(resourceGroup.Name, name));
    }
}

using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.Common.Strategies.Network
{
    public static class PublicIPAddressStrategy
    {
        public static ResourceStrategy<PublicIPAddress> Strategy { get; }
            = NetworkStrategy.Create(
                "publicIPAddresses",
                client => client.PublicIPAddresses,
                (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, null, p.CancellationToken),
                (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken));

        public static ResourceConfig<PublicIPAddress> CreatePublicIPAddressConfig(
            this ResourceConfig<ResourceGroup> resourceGroup,
            string name,
            string domainNameLabel,
            string allocationMethod)
            => Strategy.CreateConfig(
                resourceGroup,
                name,
                _ => new PublicIPAddress
                {
                    PublicIPAllocationMethod = allocationMethod,
                    DnsSettings = new PublicIPAddressDnsSettings
                    {
                        DomainNameLabel = domainNameLabel,                       
                    }
                });
    }
}

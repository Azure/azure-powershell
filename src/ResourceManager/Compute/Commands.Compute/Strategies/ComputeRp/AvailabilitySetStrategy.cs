using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Common.Strategies.Compute;
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class AvailabilitySetStrategy
    {
        public static ResourceStrategy<AvailabilitySet> Strategy { get; }
            = ComputePolicy.Create(
                type: "availability set",
                provider: "availabilitySets",
                getOperations: client => client.AvailabilitySets,
                getAsync: (o, p) => o.GetAsync(
                    p.ResourceGroupName, p.Name, p.CancellationToken),
                createOrUpdateAsync: (o, p) => o.CreateOrUpdateAsync(
                    p.ResourceGroupName, p.Name, p.Model, p.CancellationToken),
                createTime: c => 1);

        public static ResourceConfig<AvailabilitySet> CreateAvailabilitySetConfig(
            this ResourceConfig<ResourceGroup> resourceGroup, string name)
            => Strategy.CreateResourceConfig(
                resourceGroup: resourceGroup,
                name: name,
                createModel: subscription => new AvailabilitySet
                {
                    Sku = new Azure.Management.Compute.Models.Sku {  Name = "Aligned" },
                    PlatformFaultDomainCount = 2,
                    PlatformUpdateDomainCount = 2,
                });
    }
}

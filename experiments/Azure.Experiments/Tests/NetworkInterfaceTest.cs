using Microsoft.Azure.Experiments.Network;
using Microsoft.Azure.Experiments.ResourceManager;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Experiments.Tests
{
    public class NetworkInterfaceTest
    {
        [Fact]
        public async Task CreateAsyncTest()
        {
            var rg = ResourceGroupPolicy.CreateResourceGroupConfig("nirg");
            var vn = rg.CreateVirtualNetworkConfig("Vnni", "192.168.0.0/16");
            var sn = vn.CreateSubnet("mysubnet", "192.168.1.0/24");
            var pipa = rg.CreatePublicIPAddressConfig("pipani");
            var nsg = rg.CreateNetworkSecurityGroupConfig("nsgni");
            var ni = rg.CreateNetworkInterfaceConfig("ni", sn, pipa, nsg);

            var client = new Client(Credentials.Get());
            var state = await ni.GetAsync(client, new CancellationToken());
            var location = state.GetLocation(rg);
            var parameters = ni.GetParameters(client.Context.SubscriptionId, "eastus");
            var nic = parameters.GetOrNull(ni);
            var createState = await ni.CreateOrUpdateAsync(
                client, state, parameters, new CancellationToken());
            var nicc = createState.GetOrNull(ni);
            Assert.Equal("eastus", nicc.Location);
            Assert.Equal("ni", nicc.Name);
            Assert.Equal(ni.GetId(client.Context.SubscriptionId).IdToString(), nicc.Id);
        }
    }
}

using Microsoft.Azure.Experiments.Network;
using Microsoft.Azure.Experiments.ResourceManager;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Experiments.Tests
{
    public class SubnetTest
    {
        [Fact]
        public async Task CreateAsyncTest()
        {
            var rg = ResourceGroupPolicy.CreateResourceGroupConfig("Snrg");
            var vn = rg.CreateVirtualNetworkConfig("Vn", "192.168.0.0/16");
            var sn = vn.CreateSubnet("mysubnet", "192.168.1.0/24");

            var client = new Client(Credentials.Get());
            var state = await sn.GetAsync(client, new CancellationToken());
            var location = state.GetLocation(rg);
            var parameters = sn.GetParameters(client.Context.SubscriptionId, "eastus");
            var snc = parameters.GetOrNull(sn);
            var createState = await sn.CreateOrUpdateAsync(
                client, state, parameters, new CancellationToken());
            var sncc = createState.GetOrNull(sn);
            Assert.Equal("mysubnet", sncc.Name);
            Assert.Equal(sn.GetId(client.Context.SubscriptionId).IdToString(), sncc.Id);
        }
    }
}

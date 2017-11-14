using Microsoft.Azure.Experiments.ResourceManager;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Experiments.Tests
{
    public class ResourceGroupTest
    {
        [Fact]
        public void CreateConfigTest()
        {
            var rg = ResourceGroupPolicy.CreateResourceGroupConfig("new");
            var id = rg.GetId("12345").IdToString();
            Assert.Equal("/subscriptions/12345/resourceGroups/new", id);
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            var rg = ResourceGroupPolicy.CreateResourceGroupConfig("new");
            var client = new Client(Credentials.Get());
            var state = await rg.GetAsync(client, new CancellationToken());
            var location = state.GetLocation(rg);
            Assert.Null(location);
        }

        [Fact]
        public async Task CreateParameterTest()
        {
            var rg = ResourceGroupPolicy.CreateResourceGroupConfig("new");
            var client = new Client(Credentials.Get());
            var state = await rg.GetAsync(client, new CancellationToken());
            var location = state.GetLocation(rg);
            var parameters = rg.GetParameters(client.Context.SubscriptionId, "eastus");
            var rgc = parameters.GetOrNull(rg);
            Assert.Equal("eastus", rgc.Location);
        }

        [Fact]
        public async Task CreateAsyncTest()
        {
            var rg = ResourceGroupPolicy.CreateResourceGroupConfig("new1");
            var client = new Client(Credentials.Get());
            var state = await rg.GetAsync(client, new CancellationToken());
            var location = state.GetLocation(rg);
            var parameters = rg.GetParameters(client.Context.SubscriptionId, "eastus");
            var rgc = parameters.GetOrNull(rg);
            var createState = await rg.CreateOrUpdateAsync(
                client, state, parameters, new CancellationToken());
            var rgcc = createState.GetOrNull(rg);
            Assert.Equal("eastus", rgcc.Location);
            Assert.Equal("new1", rgcc.Name);
            Assert.Equal(rg.GetId(client.Context.SubscriptionId).IdToString(), rgcc.Id);
        }
    }
}

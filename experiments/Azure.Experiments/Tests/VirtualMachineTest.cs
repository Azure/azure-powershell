using Microsoft.Azure.Experiments.Compute;
using Microsoft.Azure.Experiments.Network;
using Microsoft.Azure.Experiments.ResourceManager;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Experiments.Tests
{
    public sealed class VirtualMachineTest
    {
        [Fact]
        public async Task CreateAsyncTest()
        {
            var rg = ResourceGroupPolicy.CreateResourceGroupConfig("vmrg");
            var vn = rg.CreateVirtualNetworkConfig("Vnni", "192.168.0.0/16");
            var sn = vn.CreateSubnet("mysubnet", "192.168.1.0/24");
            var pipa = rg.CreatePublicIPAddressConfig("pipavm");
            var nsg = rg.CreateNetworkSecurityGroupConfig("nsgvm");
            var ni = rg.CreateNetworkInterfaceConfig("nivm", sn, pipa, nsg);
            var vm = rg.CreateVirtualMachineConfig("vm", ni, "MyVMUser", "@3as54dDd");

            var client = new Client(Credentials.Get());
            var state = await vm.GetAsync(client, new CancellationToken());
            var location = state.GetLocation(rg);
            var parameters = vm.GetParameters(client.Context.SubscriptionId, "eastus");
            var vmc = parameters.GetOrNull(vm);
            var createState = await vm.CreateOrUpdateAsync(
                client, state, parameters, new CancellationToken());
            var vmcc = createState.GetOrNull(vm);
            Assert.Equal("eastus", vmcc.Location);
            Assert.Equal("vm", vmcc.Name);
            Assert.Equal(vm.GetId(client.Context.SubscriptionId).IdToString(), vmcc.Id);
        }
    }
}

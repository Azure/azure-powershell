using Xunit;
using Microsoft.Azure.Management.Compute;
using System.Threading.Tasks;

namespace Azure.Experiments.Tests
{
    public class ComputeTest
    {
        [Fact]
        public async Task ResourceGroupTest()
        {
            var c = Credentials.Get();
            var rg = new ResourceGroupObject("My");
            var info = await rg.GetOrNullAsync(c);
            var infoCreate = await rg.GetOrCreateAsync(c);
            // await rg.DeleteAsync(c);
        }

        [Fact]
        public async Task VirtualNetworkTest()
        {
            var c = Credentials.Get();
            var rg = new ResourceGroupObject("My1");
            var vn = new VirtualNetworkObject("My1", rg, "192.168.0.0/16");
            var info = await vn.GetOrNullAsync(c);
            var infoCreate = await vn.GetOrCreateAsync(c);
        }

        [Fact]
        public async Task PublicIpAddressTest()
        {
            var c = Credentials.Get();
            var rg = new ResourceGroupObject("MyPIA");
            var pia = new PublicIpAddressObject("MyPIA", rg);
            var info = await pia.GetOrCreateAsync(c);
        }

        [Fact]
        public async Task Test1()
        {
            var c = Credentials.Get();
            var client = new ComputeManagementClient(c.Credentials)
            {
                SubscriptionId = c.SubscriptionId
            };
            var list = await client.VirtualMachines.ListAllAsync();
        }
    }
}

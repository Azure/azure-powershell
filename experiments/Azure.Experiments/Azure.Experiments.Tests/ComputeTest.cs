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
        public async Task NetworkSecurityGroupTest()
        {
            var c = Credentials.Get();
            var rg = new ResourceGroupObject("MyNSG");
            var nsg = new NetworkSecurityGroupObject("MyNSG", rg);
            var info = await nsg.GetOrCreateAsync(c);
        }

        [Fact]
        public async Task SubnetTest()
        {
            var c = Credentials.Get();
            var rg = new ResourceGroupObject("MySubnet");
            var vn = new VirtualNetworkObject("MySubnet", rg, "192.168.0.0/16");
            var subnet = new SubnetObject("MySubnet", vn, "192.168.1.0/24");
            var info = await subnet.GetOrCreateAsync(c);
        }

        [Fact]
        public async Task NetworkInterfaceObject()
        {
            var c = Credentials.Get();
            var rg = new ResourceGroupObject("MyNI");
            var vn = new VirtualNetworkObject("MyNI", rg, "192.168.0.0/16");
            var subnet = new SubnetObject("MyNI", vn, "192.168.1.0/24");
            var pia = new PublicIpAddressObject("MyNI", rg);
            var nsg = new NetworkSecurityGroupObject("MyNI", rg);
            var ni = new NetworkInterfaceObject("MyNI", rg, subnet, pia, nsg);
            var info = await ni.GetOrCreateAsync(c);
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

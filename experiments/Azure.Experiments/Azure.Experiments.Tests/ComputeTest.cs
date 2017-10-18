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
            var rg = new ResourceGroupObject(c, "My");
            var info = await rg.GetOrNullAsync(c);
            var infoCreate = await rg.GetOrCreateAsync(c);
            // await rg.DeleteAsync(c);
        }

        [Fact]
        public async Task VirtualNetworkTest()
        {
            var c = Credentials.Get();
            var rg = new ResourceGroupObject(c, "My1");
            var vn = new VirtualNetworkObject(c.CreateNetwork(), "My1", rg, "192.168.0.0/16");
            var info = await vn.GetOrNullAsync(c);
            var infoCreate = await vn.GetOrCreateAsync(c);
        }

        [Fact]
        public async Task PublicIpAddressTest()
        {
            var c = Credentials.Get();
            var rg = new ResourceGroupObject(c, "MyPIA");
            var pia = new PublicIpAddressObject(c.CreateNetwork(), "MyPIA", rg);
            var info = await pia.GetOrCreateAsync(c);
        }

        [Fact]
        public async Task NetworkSecurityGroupTest()
        {
            var c = Credentials.Get();
            var rg = new ResourceGroupObject(c, "MyNSG");
            var nsg = new NetworkSecurityGroupObject(c.CreateNetwork(), "MyNSG", rg);
            var info = await nsg.GetOrCreateAsync(c);
        }

        [Fact]
        public async Task SubnetTest()
        {
            var c = Credentials.Get();
            var rg = new ResourceGroupObject(c, "MySubnet");
            var vn = new VirtualNetworkObject(c.CreateNetwork(), "MySubnet", rg, "192.168.0.0/16");
            var subnet = new SubnetObject("MySubnet", vn, "192.168.1.0/24");
            var info = await subnet.GetOrCreateAsync(c);
        }

        [Fact]
        public async Task NetworkInterfaceObject()
        {
            var c = Credentials.Get();
            var network = c.CreateNetwork();
            var rg = new ResourceGroupObject(c, "MyNI");
            var vn = new VirtualNetworkObject(network, "MyNI", rg, "192.168.0.0/16");
            var subnet = new SubnetObject("MyNI", vn, "192.168.1.0/24");
            var pia = new PublicIpAddressObject(network, "MyNI", rg);
            var nsg = new NetworkSecurityGroupObject(network, "MyNI", rg);
            var ni = new NetworkInterfaceObject(network, "MyNI", rg, subnet, pia, nsg);
            var info = await ni.GetOrCreateAsync(c);
        }

        [Fact]
        public async Task VmObject()
        {
            var c = Credentials.Get();
            var network = c.CreateNetwork();
            var rg = new ResourceGroupObject(c, "MyVM");
            var vn = new VirtualNetworkObject(network, "MyVM", rg, "192.168.0.0/16");
            var subnet = new SubnetObject("MyVM", vn, "192.168.1.0/24");
            var pia = new PublicIpAddressObject(network, "MyVM", rg);
            var nsg = new NetworkSecurityGroupObject(network, "MyVM", rg);
            var ni = new NetworkInterfaceObject(network, "MyVM", rg, subnet, pia, nsg);
            var vm = new VmObject(c, "MyVM", rg, ni, "MyVMUser", "@3as54dDd");
            var info = await vm.GetOrCreateAsync(c);
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

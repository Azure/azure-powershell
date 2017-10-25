using Azure.Experiments.Compute;
using Azure.Experiments.Network;
using Microsoft.Rest;
using Xunit;

namespace Azure.Experiments.Tests
{
    public class UnitTests
    {
        private static Context C { get; }
            = new Context(new TokenCredentials("a"), string.Empty);

        [Fact]
        public void ResourceGroupObjectTest()
        {
            var rg = new ResourceGroupObject(C, "My");
            Assert.Equal(1, rg.Priority);
        }

        [Fact]
        public void VirtualNetworkObjectTest()
        {
            var rg = new ResourceGroupObject(C, "My1");
            var vn = new VirtualNetworkObject(C.CreateNetwork(), "My1", rg, "192.168.0.0/16");
            Assert.Equal(2, vn.Priority);
        }

        [Fact]
        public void PublicIpAddressObjectTest()
        {
            var rg = new ResourceGroupObject(C, "MyPIA");
            var pia = new PublicIpAddressObject(C.CreateNetwork(), "MyPIA", rg);
            Assert.Equal(2, pia.Priority);
        }

        //[Fact]
        public void NetworkSecurityGroupTest()
        {
            var c = Credentials.Get();
            var rg = new ResourceGroupObject(c, "MyNSG");
            var nsg = new NetworkSecurityGroupObject(c.CreateNetwork(), "MyNSG", rg);
            Assert.Equal(2, nsg.Priority);
        }

        [Fact]
        public void SubnetObjectTest()
        {
            var rg = new ResourceGroupObject(C, "MySubnet");
            var vn = new VirtualNetworkObject(C.CreateNetwork(), "MySubnet", rg, "192.168.0.0/16");
            var subnet = new SubnetObject("MySubnet", vn, "192.168.1.0/24");
            Assert.Equal(3, subnet.Priority);
        }

        [Fact]
        public void NetworkInterfaceObjectTest()
        {
            var network = C.CreateNetwork();
            var rg = new ResourceGroupObject(C, "MyNI");
            var vn = new VirtualNetworkObject(network, "MyNI", rg, "192.168.0.0/16");
            var subnet = new SubnetObject("MyNI", vn, "192.168.1.0/24");
            var pia = new PublicIpAddressObject(network, "MyNI", rg);
            var nsg = new NetworkSecurityGroupObject(network, "MyNI", rg);
            var ni = new NetworkInterfaceObject(network, "MyNI", rg, subnet, pia, nsg);
            Assert.Equal(4, ni.Priority);
        }

        [Fact]
        public void VmObjectTest()
        {
            var network = C.CreateNetwork();
            var rg = new ResourceGroupObject(C, "MyVM");
            var vn = new VirtualNetworkObject(network, "MyVM", rg, "192.168.0.0/16");
            var subnet = new SubnetObject("MyVM", vn, "192.168.1.0/24");
            var pia = new PublicIpAddressObject(network, "MyVM", rg);
            var nsg = new NetworkSecurityGroupObject(network, "MyVM", rg);
            var ni = new NetworkInterfaceObject(network, "MyVM", rg, subnet, pia, nsg);
            var vm = new VirtualMachineObject(C, "MyVM", rg, ni, "MyVMUser", "@3as54dDd");
            Assert.Equal(5, vm.Priority);
        }
    }
}

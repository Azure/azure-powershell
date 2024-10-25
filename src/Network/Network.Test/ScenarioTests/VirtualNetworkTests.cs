// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class VirtualNetworkTests : NetworkTestRunner
    {
        public VirtualNetworkTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkCRUDWithDDoSProtection()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkCRUDWithDDoSProtection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkCRUDWithIpamPool()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkCRUDWithIpamPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkSubnetCRUD()
        {
            TestRunner.RunTestScript("Test-subnetCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestSubnetWithDefaultOutboundAccessCRUD()
        {
            TestRunner.RunTestScript("Test-subnetWithDefaultOutboundAccessCRUD");
        }

        [Fact(Skip = "Authentication failed for auxiliary token: The '1' auxiliary tokens contains duplicates which are from the same tenant.")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkBgpCommunitiesCRUD()
        {
            TestRunner.RunTestScript("Test-bgpCommunitiesCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkSubnetDelegationCRUD()
        {
            TestRunner.RunTestScript("Test-subnetDelegationCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkSubnetNetworkSecurityGroupCRUD()
        {
            TestRunner.RunTestScript("Test-subnetNetworkSecurityGroupCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkSubnetRouteTableCRUD()
        {
            TestRunner.RunTestScript("Test-subnetRouteTableCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkMultiPrefixSubnetCRUD()
        {
            TestRunner.RunTestScript("Test-multiPrefixSubnetCRUD");
        }

        [Fact(Skip = "'The '1' auxiliary tokens are either not application token(s) or are from the application(s) ... which are different from the application of primary identity <...>.' StatusCode: 401; ReasonPhrase: Unauthorized.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.vnetpeeringdev)]
        public void TestVirtualNetworkPeeringCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkPeeringCRUD");
        }

        [Fact(Skip ="We need to update the way tokens are aquired, as of now aquiring tokens for multiple tenants is broken")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestMultiTenantVNetPCRUD()
        {
            //this test is special, it requires 2 vnets, one of them created in a tenant other than the current context
            //The test assumes one of the vnet (n the other tenant) is already up and runing 
            //The test will create the second vnet and the peer them
            //The underlying cmdlet will actually get a token for the other tenant and pass it on in the REST call..
            //Because of the need to get a token for the remote VNets's tenant, we cant ruin this under a service principal
            //This test needs to be run in a live user mode only where the user is asusmed to  have access to both the tenants

            TestRunner.RunTestScript("Test-MultiTenantVNetPCRUD");

        }

        [Fact(Skip = "test is timing out , ahmed salma to fix")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestResourceNavigationLinksOnSubnetCRUD()
        {
            TestRunner.RunTestScript("Test-ResourceNavigationLinksCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkUsage()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkUsage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkSubnetServiceEndpoint()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkSubnetServiceEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkSubnetServiceEndpointWithNetworkIdentifier()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkSubnetServiceEndpointWithNetworkIdentifier");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkSubnetServiceEndpointConfig()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkSubnetServiceEndpointConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkSubnetServiceEndpointPolicies()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkSubnetServiceEndpointPolicies");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkCRUDFlowTimeout()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkCRUD-FlowTimeout");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.vnetpeeringdev)]
        public void TestVirtualNetworkPeeringSyncCRUD()
        {
            TestRunner.RunTestScript("Test-SyncVirtualNetworkPeeringCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkInEdgeZone()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkInEdgeZone");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkEdgeZone()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkEdgeZone");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev_subset1)]
        public void TestVirtualNetworkEncryption()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkEncryption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.plcpdev)]
        public void TestVirtualNetworkPrivateEndpointVNetPolicies()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkPrivateEndpointVNetPolicies");
        }
    }
}

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

using System;
using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class VirtualNetworkGatewayTests : NetworkTestRunner
    {
        public VirtualNetworkGatewayTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset2)]
        public void TestVirtualNetworkExpressRouteGatewayCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkExpressRouteGatewayCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset2)]
        public void TestVirtualNetworkGatewayCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset2)]
        public void TestVirtualNetworkGatewayP2SAndSKU()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayP2SAndSKU");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset2)]
        public void TestSetVirtualNetworkGatewayCRUD()
        {
            TestRunner.RunTestScript("Test-SetVirtualNetworkGatewayCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset2)]
        public void VirtualNetworkGatewayDisableIPsecProtection()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayDisableIPsecProtection");
        }

        [Fact(Skip = "Skipped due to intermittent backend failures")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset2)]
        public void VirtualNetworkGatewayActiveActiveFeatureTest()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayActiveActiveFeatureOperations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset3)]
        public void VirtualNetworkGatewayRouteApiTest()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayBgpRouteApi");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset3)]
        public void TestVirtualNetworkGatewayP2SVpnProfile()
        {
            TestRunner.RunTestScript(string.Format(
                "Test-VirtualNetworkGatewayGenerateVpnProfile -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset3)]
        public void VirtualNetworkGatewayIkeV2Test()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayIkeV2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset3)]
        public void VirtualNetworkGatewayOpenVPNTest()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayOpenVPN");
        }

        [Fact(Skip="VPN AAD authentication configuration is not supported for the gateway")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset3)]
        public void VirtualNetworkGatewayOpenVPNAADAuthTest()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayOpenVPNAADAuth");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset3)]
        public void VirtualNetworkGatewayRadiusTest()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayRadius");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset3)]
        public void VirtualNetworkGatewayVpnCustomIpsecPolicySetTest()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayVpnCustomIpsecPolicySet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset3)]
        public void VirtualNetworkGatewayVpnclientConnectionHealthTest()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayVpnClientConnectionHealth");
        }

        [Fact(Skip = "Skipped due to intermittent backend failures")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset5)]
        public void TestVirtualNetworKGatewayPacketCapture()
        {
            TestRunner.RunTestScript("Test-VirtualNetworKGatewayPacketCapture");
        }

        [Fact(Skip = "Skipped due to intermittent backend failures")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset5)]
        public void TestDisconnectVirtualNetworkGatewayVpnConnection()
        {
            TestRunner.RunTestScript("Test-DisconnectVNGVpnConnection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset2)]
        public void TestVirtualNetworkGatewayNatRuleCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayNatRuleCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset2)]
        public void TestVirtualNetworkGatewayPolicyGroupCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayPolicyGroupCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset2)]
        public void TestVirtualNetworkGatewayMultiAuth()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayMultiAuth");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.exrdev)]
        public void TestVirtualNetworkExpressRouteGatewayCRUDwithAdminState()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkExpressRouteGatewayCRUDwithAdminState");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.exrdev)]
        public void TestVirtualNetworkExpressRouteGatewayUpdatesForDifferentCustomerBlockTrafficPreferences()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkExpressRouteGatewayForDifferentCustomerBlockTrafficPreferences");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.exrdev)]
        public void TestVirtualNetworkExpressRouteGatewayCRUDwithResiliencyModel()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkExpressRouteGatewayCRUDwithResiliencyModel");
        }
    }
}

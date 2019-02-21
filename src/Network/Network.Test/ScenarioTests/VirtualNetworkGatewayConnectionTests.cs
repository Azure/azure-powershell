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
    public class VirtualNetworkGatewayConnectionTests : NetworkTestRunner
    {
        public VirtualNetworkGatewayConnectionTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset1)]
        public void TestVirtualNetworkGatewayConnectionCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayConnectionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset1)]
        public void TestVirtualNetworkGatewayConnectionSharedKeyCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayConnectionSharedKeyCRUD");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset1)]
        public void TestVirtualNetworkeExpressRouteGatewayConnectionCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkeExpressRouteGatewayConnectionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset1)]
        public void TestVirtualNetworkGatewayConnectionWithBgpCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayConnectionWithBgpCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset1)]
        public void TestVirtualNetworkGatewayConnectionwithIpsecPoliciesCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayConnectionWithIpsecPoliciesCRUD");
	    }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset1)]
        public void TestVirtualNetworkGatewayConnectionWithActiveAcitveGateway()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayConnectionWithActiveActiveGateway");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.brooklynft_subset1)]
        public void TestVirtualNetworkGatewayVpnDeviceConfigurationScripts()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkGatewayConnectionVpnDeviceConfigurations");
        }
    }
}

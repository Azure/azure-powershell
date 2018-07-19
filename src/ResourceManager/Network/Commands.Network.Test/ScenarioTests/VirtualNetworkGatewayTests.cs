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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class VirtualNetworkGatewayTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public VirtualNetworkGatewayTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void TestVirtualNetworkExpressRouteGatewayCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkExpressRouteGatewayCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void TestVirtualNetworkGatewayCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkGatewayCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void TestVirtualNetworkGatewayP2SAndSKU()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkGatewayP2SAndSKU");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void TestSetVirtualNetworkGatewayCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-SetVirtualNetworkGatewayCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void VirtualNetworkGatewayActiveActiveFeatureTest()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkGatewayActiveActiveFeatureOperations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void VirtualNetworkGatewayRouteApiTest()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkGatewayBgpRouteApi");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void TestVirtualNetworkGatewayP2SVpnProfile()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, string.Format(
                "Test-VirtualNetworkGatewayGenerateVpnProfile -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void VirtualNetworkGatewayIkeV2Test()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkGatewayIkeV2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void VirtualNetworkGatewayOpenVPNTest()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkGatewayOpenVPN");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void VirtualNetworkGatewayVpnCustomIpsecPolicySetTest()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkGatewayVpnCustomIpsecPolicySet");
        }
    }
}

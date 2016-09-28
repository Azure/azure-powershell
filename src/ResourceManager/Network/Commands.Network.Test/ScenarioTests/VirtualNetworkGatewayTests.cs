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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class VirtualNetworkGatewayTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualNetworkExpressRouteGatewayCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-VirtualNetworkExpressRouteGatewayCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualNetworkGatewayCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-VirtualNetworkGatewayCRUD");
        }

        [Fact(Skip = "Need to record afterwards, failing due to product issue.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualNetworkGatewayP2SAndSKU()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-VirtualNetworkGatewayP2SAndSKU");
        }

        [Fact]
        public void TestSetVirtualNetworkGatewayCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-SetVirtualNetworkGatewayCRUD");
        }

        [Fact]
        public void VirtualNetworkGatewayActiveActiveFeatureTest()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-VirtualNetworkGatewayActiveActiveFeatureOperations");
        }
    }
}

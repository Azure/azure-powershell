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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class VirtualNetworkTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public VirtualNetworkTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualNetworkCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-VirtualNetworkCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualNetworkSubnetCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-subnetCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualNetworkPeeringCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-VirtualNetworkPeeringCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResourceNavigationLinksOnSubnetCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-ResourceNavigationLinksCRUD");
        }
    }
}

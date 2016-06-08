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
    public class NetworkInterfaceTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public NetworkInterfaceTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkInterfaceCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-NetworkInterfaceCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkInterfaceCRUDUsingId()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-NetworkInterfaceCRUDUsingId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkInterfaceCRUDStaticAllocation()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-NetworkInterfaceCRUDStaticAllocation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkInterfaceNoPublicIpAddress()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-NetworkInterfaceNoPublicIpAddress");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkInterfaceSet()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-NetworkInterfaceSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkInterfaceIDns()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-NetworkInterfaceIDns");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkInterfaceEnableIPForwarding()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-NetworkInterfaceEnableIPForwarding");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkInterfaceExpandResource()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-NetworkInterfaceExpandResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkInterfaceIpv6()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-NetworkInterfaceIpv6");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkInterfaceWithIpConfiguration()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-NetworkInterfaceWithIpConfiguration");
        }
    }
}

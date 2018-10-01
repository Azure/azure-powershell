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
        public XunitTracingInterceptor _logger;

        public NetworkInterfaceTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestNetworkInterfaceCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestNetworkInterfaceCRUDUsingId()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceCRUDUsingId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestNetworkInterfaceCRUDStaticAllocation()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceCRUDStaticAllocation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestNetworkInterfaceNoPublicIpAddress()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceNoPublicIpAddress");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestNetworkInterfaceSet()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestNetworkInterfaceIDns()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceIDns");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestNetworkInterfaceEnableIPForwarding()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceEnableIPForwarding");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestNetworkInterfaceExpandResource()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceExpandResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestNetworkInterfaceIpv6()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceIpv6");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestNetworkInterfaceWithIpConfiguration()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceWithIpConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestNetworkInterfaceWithAcceleratedNetworking()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-NetworkInterfaceWithAcceleratedNetworking");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestNetworkInterfaceTapConfigurationCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, string.Format("Test-NetworkInterfaceTapConfigurationCRUD"));
        }
    }
}

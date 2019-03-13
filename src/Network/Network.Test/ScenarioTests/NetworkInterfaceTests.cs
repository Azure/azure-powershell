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
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class NetworkInterfaceTests : NetworkTestRunner
    {
        public NetworkInterfaceTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkInterfaceCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceCRUDUsingId()
        {
            TestRunner.RunTestScript("Test-NetworkInterfaceCRUDUsingId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceCRUDStaticAllocation()
        {
            TestRunner.RunTestScript("Test-NetworkInterfaceCRUDStaticAllocation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceNoPublicIpAddress()
        {
            TestRunner.RunTestScript("Test-NetworkInterfaceNoPublicIpAddress");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceSet()
        {
            TestRunner.RunTestScript("Test-NetworkInterfaceSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceIDns()
        {
            TestRunner.RunTestScript("Test-NetworkInterfaceIDns");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceEnableIPForwarding()
        {
            TestRunner.RunTestScript("Test-NetworkInterfaceEnableIPForwarding");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceExpandResource()
        {
            TestRunner.RunTestScript("Test-NetworkInterfaceExpandResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceIpv6()
        {
            TestRunner.RunTestScript("Test-NetworkInterfaceIpv6");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceWithIpConfiguration()
        {
            TestRunner.RunTestScript("Test-NetworkInterfaceWithIpConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceWithAcceleratedNetworking()
        {
            TestRunner.RunTestScript("Test-NetworkInterfaceWithAcceleratedNetworking");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceTapConfigurationCRUD()
        {
            TestRunner.RunTestScript(string.Format("Test-NetworkInterfaceTapConfigurationCRUD"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestNetworkInterfaceVmss()
        {
            TestRunner.RunTestScript("Test-NetworkInterfaceVmss");
        }
    }
}

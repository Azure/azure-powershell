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
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestVirtualNetworkCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestVirtualNetworkCRUDWithDDoSProtection()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkCRUDWithDDoSProtection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestVirtualNetworkSubnetCRUD()
        {
            TestRunner.RunTestScript("Test-subnetCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualNetworkPeeringCRUD()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkPeeringCRUD");
        }

        [Fact(Skip = "test is timing out , ahmed salma to fix")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestResourceNavigationLinksOnSubnetCRUD()
        {
            TestRunner.RunTestScript("Test-ResourceNavigationLinksCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestVirtualNetworkUsage()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkUsage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestVirtualNetworkSubnetServiceEndpoint()
        {
            TestRunner.RunTestScript("Test-VirtualNetworkSubnetServiceEndpoint");
        }
    }
}

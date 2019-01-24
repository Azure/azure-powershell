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
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class ExpressRouteCircuitTests : NetworkTestRunner
    {
        public ExpressRouteCircuitTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRouteCircuitStageCRUD()
        {
            TestRunner.RunTestScript("Test-ExpressRouteCircuitStageCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRouteCircuitCRUD()
        {
            TestRunner.RunTestScript("Test-ExpressRouteCircuitCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRouteCircuitPrivatePublicPeeringCRUD()
        {
            TestRunner.RunTestScript("Test-ExpressRouteCircuitPrivatePublicPeeringCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRouteCircuitMicrosoftPeeringCRUD()
        {
            TestRunner.RunTestScript("Test-ExpressRouteCircuitMicrosoftPeeringCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRouteCircuitAuthorizationCRUD()
        {
            TestRunner.RunTestScript("Test-ExpressRouteCircuitAuthorizationCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRouteBgpServiceCommunitiesGet()
        {
            TestRunner.RunTestScript("Test-ExpressRouteBGPServiceCommunities");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRouteRouteFilterCRUD()
        {
            TestRunner.RunTestScript("Test-ExpressRouteRouteFilters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRouteCircuitConnectionCRUD()
        {
            TestRunner.RunTestScript("Test-ExpressRouteCircuitConnectionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRouteCircuitPeeringWithRouteFilter()
        {
            TestRunner.RunTestScript("Test-ExpressRouteCircuitPeeringWithRouteFilter");
        }
    }
}

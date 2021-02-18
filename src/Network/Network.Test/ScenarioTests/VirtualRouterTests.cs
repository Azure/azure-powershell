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
    public class VirtualRouterTests : NetworkTestRunner
    {
        public VirtualRouterTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestVirtualRouterCRUDMinimalParameters()
        {
            TestRunner.RunTestScript(string.Format("Test-VirtualRouterCRUD"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestRouteServerCRUD()
        {
            TestRunner.RunTestScript(string.Format("Test-RouteServerCRUD"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestVirtualRouterPeerCRUD()
        {
            TestRunner.RunTestScript(string.Format("Test-VirtualRouterPeerCRUD"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestRouteServerPeerCRUD()
        {
            TestRunner.RunTestScript(string.Format("Test-RouteServerPeerCRUD"));
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestVirtualRouterPeerRoutes()
        {
            TestRunner.RunTestScript(string.Format("Test-VirtualRouterPeerRoutes"));
        }
    }
}

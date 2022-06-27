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
    public class ExpressRoutePortTests : NetworkTestRunner
    {
        public ExpressRoutePortTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip = "No bandwidth available")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRoutePortCRUDMinimalParameters()
        {
            TestRunner.RunTestScript(string.Format("Test-ExpressRoutePortCRUD"));
        }

        [Fact(Skip = "No bandwidth available")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRoutePortIdentityCRUD()
        {
            TestRunner.RunTestScript("Test-ExpressRoutePortIdentityCRUD");
        }

        [Fact(Skip = "Nfv-RP rollout in progress")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRoutePortGenerateLOA()
        {
            TestRunner.RunTestScript("Test-ExpressRoutePortGenerateLOA");
        }

        [Fact(Skip = "No bandwidth available")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.pgtm)]
        public void TestExpressRoutePortAuthorizationCRUD()
        {
            TestRunner.RunTestScript("Test-ExpressRoutePortAuthorizationCRUD");
        }
    }
}

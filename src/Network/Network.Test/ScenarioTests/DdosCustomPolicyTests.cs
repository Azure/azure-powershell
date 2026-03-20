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
    public class DdosCustomPolicyTests : NetworkTestRunner
    {
        public DdosCustomPolicyTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyCrud()
        {
            TestRunner.RunTestScript(string.Format("Test-DdosCustomPolicyCRUD"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyCrudWithTags()
        {
            TestRunner.RunTestScript(string.Format("Test-DdosCustomPolicyCRUDWithTags"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestLoadBalancerFrontendWithDdosCustomPolicy()
        {
            TestRunner.RunTestScript(string.Format("Test-LoadBalancerFrontendWithDdosCustomPolicy"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestAddLoadBalancerFrontendWithDdosCustomPolicy()
        {
            TestRunner.RunTestScript(string.Format("Test-AddLoadBalancerFrontendWithDdosCustomPolicy"));
        }
    }
}

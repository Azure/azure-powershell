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
    public class InterconnectGroupTests : NetworkTestRunner
    {
        public InterconnectGroupTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev)]
        public void TestInterconnectGroupCRUD()
        {
            TestRunner.RunTestScript("Test-InterconnectGroupCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev)]
        public void TestInterconnectGroupCRUDWithTags()
        {
            TestRunner.RunTestScript("Test-InterconnectGroupCRUDWithTags");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev)]
        public void TestInterconnectGroupCRUDWithSubgroupProfile()
        {
            TestRunner.RunTestScript("Test-InterconnectGroupCRUDWithSubgroupProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev)]
        public void TestInterconnectGroupGetByResourceId()
        {
            TestRunner.RunTestScript("Test-InterconnectGroupGetByResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev)]
        public void TestInterconnectGroupList()
        {
            TestRunner.RunTestScript("Test-InterconnectGroupList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev)]
        public void TestInterconnectGroupSet()
        {
            TestRunner.RunTestScript("Test-InterconnectGroupSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev)]
        public void TestInterconnectGroupRemoveByPipeline()
        {
            TestRunner.RunTestScript("Test-InterconnectGroupRemoveByPipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev)]
        public void TestInterconnectGroupSubgroupGet()
        {
            TestRunner.RunTestScript("Test-InterconnectGroupSubgroupGet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.wanrpdev)]
        public void TestInterconnectGroupNodeAvailability()
        {
            TestRunner.RunTestScript("Test-InterconnectGroupNodeAvailability");
        }
    }
}

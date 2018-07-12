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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class ManagementGroupsTests : TestManagerBuilder
    {
        public ManagementGroupsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroup()
        {
            TestManager.RunTestScript("Test-GetManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupWithExpand()
        {
            TestManager.RunTestScript("Test-GetManagementGroupWithExpand");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupWithExpandAndRecurse()
        {
            TestManager.RunTestScript("Test-GetManagementGroupWithExpandAndRecurse");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroup()
        {
            TestManager.RunTestScript("Test-NewManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupWithDisplayName()
        {
            TestManager.RunTestScript("Test-NewManagementGroupWithDisplayName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupWithParentId()
        {
            TestManager.RunTestScript("Test-NewManagementGroupWithParentId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupWithDisplayNameAndParentId()
        {
            TestManager.RunTestScript("Test-NewManagementGroupWithDisplayNameAndParentId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagementGroupWithDisplayName()
        {
            TestManager.RunTestScript("Test-UpdateManagementGroupWithDisplayName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagementGroupWithParentId()
        {
            TestManager.RunTestScript("Test-UpdateManagementGroupWithParentId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagementGroupWithDisplayNameAndParentId()
        {
            TestManager.RunTestScript("Test-UpdateManagementGroupWithDisplayNameAndParentId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveManagementGroup()
        {
            TestManager.RunTestScript("Test-RemoveManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewRemoveManagementGroupSubscription()
        {
            TestManager.RunTestScript("Test-NewRemoveManagementGroupSubscription");
        }
    }
}

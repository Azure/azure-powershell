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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class ManagementGroupsTests : ResourceTestRunner
    {
        public ManagementGroupsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroup()
        {
            TestRunner.RunTestScript("Test-GetManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupWithExpand()
        {
            TestRunner.RunTestScript("Test-GetManagementGroupWithExpand");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupWithExpandAndRecurse()
        {
            TestRunner.RunTestScript("Test-GetManagementGroupWithExpandAndRecurse");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroup()
        {
            TestRunner.RunTestScript("Test-NewManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupWithDisplayName()
        {
            TestRunner.RunTestScript("Test-NewManagementGroupWithDisplayName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupWithParentId()
        {
            TestRunner.RunTestScript("Test-NewManagementGroupWithParentId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupWithDisplayNameAndParentId()
        {
            TestRunner.RunTestScript("Test-NewManagementGroupWithDisplayNameAndParentId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagementGroupWithDisplayName()
        {
            TestRunner.RunTestScript("Test-UpdateManagementGroupWithDisplayName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagementGroupWithParentId()
        {
            TestRunner.RunTestScript("Test-UpdateManagementGroupWithParentId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagementGroupWithDisplayNameAndParentId()
        {
            TestRunner.RunTestScript("Test-UpdateManagementGroupWithDisplayNameAndParentId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveManagementGroup()
        {
            TestRunner.RunTestScript("Test-RemoveManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewRemoveManagementGroupSubscription()
        {
            TestRunner.RunTestScript("Test-NewRemoveManagementGroupSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetEntities()
        {
            TestRunner.RunTestScript("Test-GetEntities");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCheckNameAvailabilityTrue()
        {
            TestRunner.RunTestScript("Test-CheckNameAvailabilityTrue");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCheckNameAvailabilityFalse()
        {
            TestRunner.RunTestScript("Test-CheckNameAvailabilityFalse");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCheckNameWithInvalidCharacters()
        {
            TestRunner.RunTestScript("Test-CheckNameWithInvalidCharacters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetTenantBackfillStatus()
        {
            TestRunner.RunTestScript("Test-GetTenantBackfillStatus");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartTenantBackfill()
        {
            TestRunner.RunTestScript("Test-StartTenantBackfill");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupSubscription()
        {
            TestRunner.RunTestScript("Test-GetManagementGroupSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetsubscriptionsUnderManagementGroup()
        {
            TestRunner.RunTestScript("Test-GetSubscriptionsUnderManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAuthorizationHierarcySetting()
        {
            TestRunner.RunTestScript("Test-NewAuthHierarchySetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDefaultMGHierarcySetting()
        {
            TestRunner.RunTestScript("Test-NewDefaultMGHierarcySetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewHierarchySettings()
        {
            TestRunner.RunTestScript("Test-NewHierarchySettings");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveHierarcySetting()
        {
            TestRunner.RunTestScript("Test-RemoveHierarchySetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateHierarchySettingsAuth()
        {
            TestRunner.RunTestScript("Test-UpdateAuthHierarchySetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateHierarchySettingsDefaultMG()
        {
            TestRunner.RunTestScript("Test-UpdateAuthHierarchySetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateBothHierarchySettings()
        {
            TestRunner.RunTestScript("Test-UpdateBothHierarchySettings");
        }
    }
}

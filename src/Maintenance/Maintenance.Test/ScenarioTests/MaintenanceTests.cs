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

namespace Microsoft.Azure.Commands.Maintenance.Test.ScenarioTests
{
    public class MaintenanceTests : MaintenanceTestRunner
    {
        public MaintenanceTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMaintenanceConfiguration()
        {
            TestRunner.RunTestScript("Test-AzMaintenanceConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMaintenanceConfigurationInGuestPatch()
        {
            TestRunner.RunTestScript("Test-AzMaintenanceConfigurationInGuestPatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConfigurationAssignment()
        {
            TestRunner.RunTestScript("Test-AzConfigurationAssignment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMaintenanceUpdate()
        {
            TestRunner.RunTestScript("Test-AzMaintenanceUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzMaintenanceConfiguration()
        {
            TestRunner.RunTestScript("Test-GetAzMaintenanceConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPublicMaintenanceConfiguration()
        {
            TestRunner.RunTestScript("Test-AzMaintenancePublicConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzConfigurationAssignmentDynamicGroupForSubscription()
        {
            TestRunner.RunTestScript("Test-AzConfigurationAssignmentDynamicGroupForSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzConfigurationAssignmentDynamicGroupForResourceGroup()
        {
            TestRunner.RunTestScript("Test-AzConfigurationAssignmentDynamicGroupForResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzApplyUpdateCancelConfiguration()
        {
            TestRunner.RunTestScript("Test-AzApplyUpdateCancelConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzApplyUpdateWithParentResource()
        {
            TestRunner.RunTestScript("Test-GetAzApplyUpdateWithParentResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzApplyUpdateWithoutParentResource()
        {
            TestRunner.RunTestScript("Test-GetAzApplyUpdateWithoutParentResource");
        }
    }
}

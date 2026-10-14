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
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class DeploymentStackWhatIfTests : ResourcesTestRunner
    {
        public DeploymentStackWhatIfTests(ITestOutputHelper output) : base(output)
        {
        }

        // ---- Resource Group Scope ----

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupDeploymentStackWhatIfResult");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetResourceGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-SetResourceGroupDeploymentStackWhatIfResult");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-GetResourceGroupDeploymentStackWhatIfResult");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveResourceGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-RemoveResourceGroupDeploymentStackWhatIfResult");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupDeploymentStackWhatIfReturnsPropertyChanges()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupDeploymentStackWhatIfReturnsPropertyChanges");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceGroupDeploymentStackWhatIfWithIncludePropertyChange()
        {
            TestRunner.RunTestScript("Test-GetResourceGroupDeploymentStackWhatIfWithIncludePropertyChange");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceGroupDeploymentStackWhatIfResultByResourceId()
        {
            TestRunner.RunTestScript("Test-GetResourceGroupDeploymentStackWhatIfResultByResourceId");
        }

        // ---- Subscription Scope ----

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSubscriptionDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentStackWhatIfResult");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetSubscriptionDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-SetSubscriptionDeploymentStackWhatIfResult");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSubscriptionDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-GetSubscriptionDeploymentStackWhatIfResult");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSubscriptionDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-RemoveSubscriptionDeploymentStackWhatIfResult");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSubscriptionDeploymentStackWhatIfReturnsPropertyChanges()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentStackWhatIfReturnsPropertyChanges");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSubscriptionDeploymentStackWhatIfWithIncludePropertyChange()
        {
            TestRunner.RunTestScript("Test-GetSubscriptionDeploymentStackWhatIfWithIncludePropertyChange");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSubscriptionDeploymentStackWhatIfResultByResourceId()
        {
            TestRunner.RunTestScript("Test-GetSubscriptionDeploymentStackWhatIfResultByResourceId");
        }

        // ---- Management Group Scope ----

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-NewManagementGroupDeploymentStackWhatIfResult");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetManagementGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-SetManagementGroupDeploymentStackWhatIfResult");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-GetManagementGroupDeploymentStackWhatIfResult");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveManagementGroupDeploymentStackWhatIfResult()
        {
            TestRunner.RunTestScript("Test-RemoveManagementGroupDeploymentStackWhatIfResult");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupDeploymentStackWhatIfReturnsPropertyChanges()
        {
            TestRunner.RunTestScript("Test-NewManagementGroupDeploymentStackWhatIfReturnsPropertyChanges");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupDeploymentStackWhatIfWithIncludePropertyChange()
        {
            TestRunner.RunTestScript("Test-GetManagementGroupDeploymentStackWhatIfWithIncludePropertyChange");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupDeploymentStackWhatIfResultByResourceId()
        {
            TestRunner.RunTestScript("Test-GetManagementGroupDeploymentStackWhatIfResultByResourceId");
        }
    }
}

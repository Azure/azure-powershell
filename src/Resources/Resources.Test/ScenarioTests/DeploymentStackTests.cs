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
    public class DeploymentStackTests : ResourcesTestRunner
    {
        public DeploymentStackTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-GetResourceGroupDeploymentStack");
        }
    
        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTestResourceGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-TestResourceGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupDeploymentStackUnmanageActions()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupDeploymentStackUnmanageActions");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetResourceGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-SetResourceGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetResourceGroupDeploymentStackDenySettings()
        {
            TestRunner.RunTestScript("Test-NewAndSetResourceGroupDeploymentStackDenySettings");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetResourceGroupDeploymentStackUnmanageActions()
        {
            TestRunner.RunTestScript("Test-SetResourceGroupDeploymentStackUnmanageActions");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetAndSaveResourceGroupDeploymentStackWithTemplateSpec()
        {
            TestRunner.RunTestScript("Test-NewAndSetAndSaveResourceGroupDeploymentStackWithTemplateSpec");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetResourceGroupDeploymentStackWithBicep()
        {
            TestRunner.RunTestScript("Test-NewAndSetResourceGroupDeploymentStackWithBicep");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSaveResourceGroupDeploymentStackTemplate()
        {
            TestRunner.RunTestScript("Test-SaveResourceGroupDeploymentStackTemplate");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveResourceGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-RemoveResourceGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetResourceGroupDeploymentStackWithTags()
        {
            TestRunner.RunTestScript("Test-NewAndSetResourceGroupDeploymentStackWithTags");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSaveAndRemoveResourceGroupDeploymentStackWithPipeOperator()
        {
            TestRunner.RunTestScript("Test-SaveAndRemoveResourceGroupDeploymentStackWithPipeOperator");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSubscriptionDeploymentStack()
        {
            TestRunner.RunTestScript("Test-GetSubscriptionDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSubscriptionDeploymentStack()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTestSubscriptionDeploymentStack()
        {
            TestRunner.RunTestScript("Test-TestSubscriptionDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSubscriptionDeploymentStackUnmanageActions()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentStackUnmanageActions");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetSubscriptionDeploymentStackDenySettings()
        {
            TestRunner.RunTestScript("Test-NewAndSetSubscriptionDeploymentStackDenySettings");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetSubscriptionDeploymentStack()
        {
            TestRunner.RunTestScript("Test-SetSubscriptionDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetSubscriptionDeploymentStackUnmanageActions()
        {
            TestRunner.RunTestScript("Test-SetSubscriptionDeploymentStackUnmanageActions");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetAndSaveSubscriptionDeploymentStackWithTemplateSpec()
        {
            TestRunner.RunTestScript("Test-NewAndSetAndSaveSubscriptionDeploymentStackWithTemplateSpec");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetSubscriptionDeploymentStackWithBicep()
        {
            TestRunner.RunTestScript("Test-NewAndSetSubscriptionDeploymentStackWithBicep");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSaveSubscriptionDeploymentStackTemplate()
        {
            TestRunner.RunTestScript("Test-SaveSubscriptionDeploymentStackTemplate");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSubscriptionDeploymentStack()
        {
            TestRunner.RunTestScript("Test-RemoveSubscriptionDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetSubscriptionDeploymentStackWithTags()
        {
            TestRunner.RunTestScript("Test-NewAndSetSubscriptionDeploymentStackWithTags");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSaveAndRemoveSubscriptionDeploymentStackWithPipeOperator()
        {
            TestRunner.RunTestScript("Test-SaveAndRemoveSubscriptionDeploymentStackWithPipeOperator");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagementGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-GetManagementGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-NewManagementGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTestManagementGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-TestManagementGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewManagementGroupDeploymentStackUnmanageActions()
        {
            TestRunner.RunTestScript("Test-NewManagementGroupDeploymentStackUnmanageActions");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetManagementGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-SetManagementGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetManagementGroupDeploymentStackDenySettings()
        {
            TestRunner.RunTestScript("Test-NewAndSetManagementGroupDeploymentStackDenySettings");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetManagementGroupDeploymentStackUnmanageActions()
        {
            TestRunner.RunTestScript("Test-SetManagementGroupDeploymentStackUnmanageActions");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetAndSaveManagementGroupDeploymentStackWithTemplateSpec()
        {
            TestRunner.RunTestScript("Test-NewAndSetAndSaveManagementGroupDeploymentStackWithTemplateSpec");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetManagementGroupDeploymentStackWithBicep()
        {
            TestRunner.RunTestScript("Test-NewAndSetManagementGroupDeploymentStackWithBicep");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSaveManagementGroupDeploymentStackTemplate()
        {
            TestRunner.RunTestScript("Test-SaveManagementGroupDeploymentStackTemplate");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveManagementGroupDeploymentStack()
        {
            TestRunner.RunTestScript("Test-RemoveManagementGroupDeploymentStack");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAndSetManagementGroupDeploymentStackWithTags()
        {
            TestRunner.RunTestScript("Test-NewAndSetManagementGroupDeploymentStackWithTags");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSaveAndRemoveManagementGroupDeploymentStackWithPipeOperator()
        {
            TestRunner.RunTestScript("Test-SaveAndRemoveManagementGroupDeploymentStackWithPipeOperator");
        }
    }
}

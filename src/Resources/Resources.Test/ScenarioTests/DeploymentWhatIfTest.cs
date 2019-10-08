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

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    using WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;

    public class DeploymentWhatIfTest : ResourceTestRunner
    {
        public DeploymentWhatIfTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupLevelWhatIf_BlankTemplate_ReturnsNoChange()
        {
            TestRunner.RunTestScript("Test-NewWhatIfWithBlankTemplateAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupLevelWhatIf_ResourceIdOnlyMode_ReturnsChangesWithResourceIdsOnly()
        {
            TestRunner.RunTestScript("Test-NewWhatIfWithResourceIdOnlyAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupLevelWhatIf_CreateResources_ReturnsCreateChanges()
        {
            TestRunner.RunTestScript("Test-NewWhatIfCreateResourcesAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupLevelWhatIf_ModifyResources_ReturnsModifyChanges()
        {
            TestRunner.RunTestScript("Test-NewWhatIfModifyResourcesAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupLevelWhatIf_DeleteResources_ReturnsDeleteChanges()
        {
            TestRunner.RunTestScript("Test-NewWhatIfDeleteResourcesAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionLevelWhatIf_BlankTemplate_ReturnsNoChange()
        {
            TestRunner.RunTestScript("Test-NewWhatIfWithBlankTemplateAtSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionLevelWhatIf_ResourceIdOnlyMode_ReturnsChangesWithResourceIdOnly()
        {
            TestRunner.RunTestScript("Test-NewWhatIfWithResourceIdOnlyAtSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionLevelWhatIf_CreateResources_ReturnsCreateChanges()
        {
            TestRunner.RunTestScript("Test-NewWhatIfCreateResourcesAtSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionLevelWhatIf_ModifyResources_ReturnsModifyChanges()
        {
            TestRunner.RunTestScript("Test-NewWhatIfModifyResourcesAtSubscriptionScope");
        }
    }
}

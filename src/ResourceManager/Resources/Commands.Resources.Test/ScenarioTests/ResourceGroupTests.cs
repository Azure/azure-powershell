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
    public class ResourceGroupTests : ResourcesTestsBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewSimpleResourceGroup()
        {
            RunPowerShellTest("Test-CreatesNewSimpleResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdatesExistingResourceGroup()
        {
            RunPowerShellTest("Test-UpdatesExistingResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesAndRemoveResourceGroupViaPiping()
        {
            RunPowerShellTest("Test-CreatesAndRemoveResourceGroupViaPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingResourceGroup()
        {
            RunPowerShellTest("Test-GetNonExistingResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupInNonExistingLocation()
        {
            RunPowerShellTest("Test-NewResourceGroupInNonExistingLocation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNonExistingResourceGroup()
        {
            RunPowerShellTest("Test-RemoveNonExistingResourceGroup");
        }

        [Fact (Skip = "TODO: Fix the broken test.")]
        public void TestAzureTagsEndToEnd()
        {
            RunPowerShellTest("Test-AzureTagsEndToEnd");
        }

        [Fact(Skip = "Depends on Bug 2040630")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentAndProviderRegistration()
        {
            RunPowerShellTest("Test-NewDeploymentAndProviderRegistration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupWithTemplateThenGetWithAndWithoutDetails()
        {
            RunPowerShellTest("Test-NewResourceGroupWithTemplateThenGetWithAndWithoutDetails");
        }
    }
}

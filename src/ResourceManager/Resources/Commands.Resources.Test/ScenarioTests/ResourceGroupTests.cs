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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class ResourceGroupTests : RMTestBase
    {
        public ResourceGroupTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewSimpleResourceGroup()
        {
            ResourcesController.NewInstance.RunPsTest("Test-CreatesNewSimpleResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdatesExistingResourceGroup()
        {
            ResourcesController.NewInstance.RunPsTest("Test-UpdatesExistingResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesAndRemoveResourceGroupViaPiping()
        {
            ResourcesController.NewInstance.RunPsTest("Test-CreatesAndRemoveResourceGroupViaPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingResourceGroup()
        {
            ResourcesController.NewInstance.RunPsTest("Test-GetNonExistingResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupInNonExistingLocation()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NewResourceGroupInNonExistingLocation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNonExistingResourceGroup()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RemoveNonExistingResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFindResourceGroup()
        {
            ResourcesController.NewInstance.RunPsTest("Test-FindResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExportResourceGroup()
        {
            ResourcesController.NewInstance.RunPsTest("Test-ExportResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResourceGroupWithPositionalParams()
        {
            ResourcesController.NewInstance.RunPsTest("Test-ResourceGroupWithPositionalParams");
        }

        [Fact(Skip = "TODO: Fix the broken test.")]
        public void TestAzureTagsEndToEnd()
        {
            ResourcesController.NewInstance.RunPsTest("Test-AzureTagsEndToEnd");
        }

        [Fact(Skip = "Depends on Bug 2040630")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentAndProviderRegistration()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NewDeploymentAndProviderRegistration");
        }

        [Fact]
        public void TestRemoveDeployment()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RemoveDeployment");
        }

        [Fact(Skip = "Doesn't add any value. Will improve negative tests in a future release")]
        public void TestGetNonExistingResourceGroupWithDebugStream()
        {
            ResourcesController.NewInstance.RunPsTest("Test-GetNonExistingResourceGroupWithDebugStream");
        }
    }
}

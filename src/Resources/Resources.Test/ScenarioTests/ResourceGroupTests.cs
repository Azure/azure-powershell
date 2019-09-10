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
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class ResourceGroupTests : ResourceTestRunner
    {
        public ResourceGroupTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewSimpleResourceGroup()
        {
            TestRunner.RunTestScript("Test-CreatesNewSimpleResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdatesExistingResourceGroup()
        {
            TestRunner.RunTestScript("Test-UpdatesExistingResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesAndRemoveResourceGroupViaPiping()
        {
            TestRunner.RunTestScript("Test-CreatesAndRemoveResourceGroupViaPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingResourceGroup()
        {
            TestRunner.RunTestScript("Test-GetNonExistingResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceGroupInNonExistingLocation()
        {
            TestRunner.RunTestScript("Test-NewResourceGroupInNonExistingLocation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNonExistingResourceGroup()
        {
            TestRunner.RunTestScript("Test-RemoveNonExistingResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFindResourceGroup()
        {
            TestRunner.RunTestScript("Test-FindResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExportResourceGroup()
        {
            TestRunner.RunTestScript("Test-ExportResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExportResourceGroupWithFiltering()
        {
            TestRunner.RunTestScript("Test-ExportResourceGroupWithFiltering");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResourceGroupWithPositionalParams()
        {
            TestRunner.RunTestScript("Test-ResourceGroupWithPositionalParams");
        }

        [Fact(Skip = "TODO: Fix the broken test.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureTagsEndToEnd()
        {
            TestRunner.RunTestScript("Test-AzureTagsEndToEnd");
        }

        [Fact(Skip = "Depends on Bug 2040630")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentAndProviderRegistration()
        {
            TestRunner.RunTestScript("Test-NewDeploymentAndProviderRegistration");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait("Re-record", "ClientRuntime changes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveDeployment()
        {
            TestRunner.RunTestScript("Test-RemoveDeployment");
        }

        [Fact(Skip = "Doesn't add any value. Will improve negative tests in a future release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingResourceGroupWithDebugStream()
        {
            TestRunner.RunTestScript("Test-GetNonExistingResourceGroupWithDebugStream");
        }
    }
}

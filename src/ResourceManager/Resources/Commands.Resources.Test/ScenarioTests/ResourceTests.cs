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
    public class ResourceTests : TestManagerBuilder// : RMTestBase
    {
        public ResourceTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewSimpleResource()
        {
            TestManager.RunTestScript("Test-CreatesNewSimpleResource");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewComplexResource()
        {
            TestManager.RunTestScript("Test-CreatesNewComplexResource");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesViaPiping()
        {
            TestManager.RunTestScript("Test-GetResourcesViaPiping");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesFromEmptyGroup()
        {
            TestManager.RunTestScript("Test-GetResourcesFromEmptyGroup");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesFromNonExisingGroup()
        {
            TestManager.RunTestScript("Test-GetResourcesFromNonExisingGroup");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesForNonExisingType()
        {
            TestManager.RunTestScript("Test-GetResourcesForNonExisingType");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceForNonExisingResource()
        {
            TestManager.RunTestScript("Test-GetResourceForNonExisingResource");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesViaPipingFromAnotherResource()
        {
            TestManager.RunTestScript("Test-GetResourcesViaPipingFromAnotherResource");
        }

        [Fact(Skip = "Successfully re-recorded, but still failing in playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMoveAResourceTest()
        {
            TestManager.RunTestScript("Test-MoveAResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMoveResourceFailed()
        {
            TestManager.RunTestScript("Test-MoveResourceFailed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAResourceTest()
        {
            TestManager.RunTestScript("Test-SetAResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAResourceWithPatchTest()
        {
            TestManager.RunTestScript("Test-SetAResourceWithPatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFindAResourceTest()
        {
            TestManager.RunTestScript("Test-FindAResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFindAResourceByTag()
        {
            TestManager.RunTestScript("Test-FindAResource-ByTag");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceWithExpandProperties()
        {
            TestManager.RunTestScript("Test-GetResourceExpandProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceByIdAndProperties()
        {
            TestManager.RunTestScript("Test-GetResourceByIdAndProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceByComponentsAndProperties()
        {
            TestManager.RunTestScript("Test-GetResourceByComponentsAndProperties");
        }

        [Fact(Skip = "Zones are disabled for now.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageResourceWithZones()
        {
            TestManager.RunTestScript("Test-ManageResourceWithZones");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAResourceTest()
        {
            TestManager.RunTestScript("Test-RemoveAResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveASetOfResourcesTest()
        {
            TestManager.RunTestScript("Test-RemoveASetOfResources");
        }
    }
}

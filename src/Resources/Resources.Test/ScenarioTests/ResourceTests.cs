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
    public class ResourceTests : ResourceTestRunner
    {
        public ResourceTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewSimpleResource()
        {
            TestRunner.RunTestScript("Test-CreatesNewSimpleResource");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewComplexResource()
        {
            TestRunner.RunTestScript("Test-CreatesNewComplexResource");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesViaPiping()
        {
            TestRunner.RunTestScript("Test-GetResourcesViaPiping");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesFromEmptyGroup()
        {
            TestRunner.RunTestScript("Test-GetResourcesFromEmptyGroup");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesFromNonExisingGroup()
        {
            TestRunner.RunTestScript("Test-GetResourcesFromNonExisingGroup");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesForNonExisingType()
        {
            TestRunner.RunTestScript("Test-GetResourcesForNonExisingType");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceForNonExisingResource()
        {
            TestRunner.RunTestScript("Test-GetResourceForNonExisingResource");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesViaPipingFromAnotherResource()
        {
            TestRunner.RunTestScript("Test-GetResourcesViaPipingFromAnotherResource");
        }

        [Fact(Skip = "Successfully re-recorded, but still failing in playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMoveAResourceTest()
        {
            TestRunner.RunTestScript("Test-MoveAResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMoveResourceFailed()
        {
            TestRunner.RunTestScript("Test-MoveResourceFailed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAResourceTest()
        {
            TestRunner.RunTestScript("Test-SetAResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAResourceUsingPiping()
        {
            TestRunner.RunTestScript("Test-SetAResourceUsingPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAResourceWithPatchTest()
        {
            TestRunner.RunTestScript("Test-SetAResourceWithPatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFindAResourceTest()
        {
            TestRunner.RunTestScript("Test-FindAResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFindAResourceByTag()
        {
            TestRunner.RunTestScript("Test-FindAResource-ByTag");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceWithExpandProperties()
        {
            TestRunner.RunTestScript("Test-GetResourceExpandProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceByIdAndProperties()
        {
            TestRunner.RunTestScript("Test-GetResourceByIdAndProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetChildResourcesById()
        {
            TestRunner.RunTestScript("Test-GetChildResourcesById");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNestedResourceByPiping()
        {
            TestRunner.RunTestScript("Test-SetNestedResourceByPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceByComponentsAndProperties()
        {
            TestRunner.RunTestScript("Test-GetResourceByComponentsAndProperties");
        }

        [Fact(Skip = "Zones are disabled for now.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageResourceWithZones()
        {
            TestRunner.RunTestScript("Test-ManageResourceWithZones");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAResourceTest()
        {
            TestRunner.RunTestScript("Test-RemoveAResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveASetOfResourcesTest()
        {
            TestRunner.RunTestScript("Test-RemoveASetOfResources");
        }
    }
}

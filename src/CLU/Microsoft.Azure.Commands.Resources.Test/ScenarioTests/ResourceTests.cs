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


using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class ResourceTests : RMTestBase
    {
        private const string CallingClass = "Microsoft.Azure.Commands.Resources.Test.ScenarioTests.ResourceTests";

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewSimpleResource()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "TestCreatesNewSimpleResource",
                "Test-CreatesNewSimpleResource");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewComplexResource()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "TestCreatesNewComplexResource",
                "Test-CreatesNewComplexResource");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesViaPiping()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "TestGetResourcesViaPiping",
                "Test-GetResourcesViaPiping");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesFromEmptyGroup()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "TestGetResourcesFromEmptyGroup",
                "Test-GetResourcesFromEmptyGroup");
        }

        [Fact (Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesFromNonExisingGroup()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "TestGetResourcesFromNonExisingGroup",
                "Test-GetResourcesFromNonExisingGroup");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesForNonExisingType()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "TestGetResourcesForNonExisingType",
                "Test-GetResourcesForNonExisingType");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceForNonExisingResource()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "TestGetResourceForNonExisingResource",
                "Test-GetResourceForNonExisingResource");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesViaPipingFromAnotherResource()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "TestGetResourcesViaPipingFromAnotherResource",
                "Test-GetResourcesViaPipingFromAnotherResource");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMoveAResourceTest()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "TestMoveAResourceTest",
                "Test-MoveAResource");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAResourceTest()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "TestSetAResourceTest",
                "Test-SetAResource");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFindAResourceTest()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "TestFindAResourceTest",
                "Test-FindAResource");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceWithExpandProperties()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "TestGetResourceWithExpandProperties",
                "Test-GetResourceExpandProperties");
        }
    }
}

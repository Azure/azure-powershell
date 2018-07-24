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
    public class ResourceTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public ResourceTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewSimpleResource()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-CreatesNewSimpleResource");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewComplexResource()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-CreatesNewComplexResource");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesViaPiping()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetResourcesViaPiping");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesFromEmptyGroup()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetResourcesFromEmptyGroup");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesFromNonExisingGroup()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetResourcesFromNonExisingGroup");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesForNonExisingType()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetResourcesForNonExisingType");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceForNonExisingResource()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetResourceForNonExisingResource");
        }

        [Fact(Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesViaPipingFromAnotherResource()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetResourcesViaPipingFromAnotherResource");
        }

        [Fact(Skip = "Successfully re-recorded, but still failing in playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMoveAResourceTest()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-MoveAResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMoveResourceFailed()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-MoveResourceFailed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAResourceTest()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-SetAResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAResourceUsingPiping()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-SetAResourceUsingPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAResourceWithPatchTest()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-SetAResourceWithPatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFindAResourceTest()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-FindAResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFindAResourceByTag()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-FindAResource-ByTag");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceWithExpandProperties()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetResourceExpandProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceByIdAndProperties()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetResourceByIdAndProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceByComponentsAndProperties()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetResourceByComponentsAndProperties");
        }

        [Fact(Skip = "Zones are disabled for now.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageResourceWithZones()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-ManageResourceWithZones");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAResourceTest()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RemoveAResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveASetOfResourcesTest()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RemoveASetOfResources");
        }
    }
}

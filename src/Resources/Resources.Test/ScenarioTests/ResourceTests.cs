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
    public class ResourceTests : ResourcesTestRunner
    {
        public ResourceTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzResourceSimpleByResourceName()
        {
            TestRunner.RunTestScript("Test-NewAzResourceSimpleByResourceName");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzResourceSimpleByResourceId()
        {
            TestRunner.RunTestScript("Test-NewAzResourceSimpleByResourceId");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzResourceWithApiVersion()
        {
            TestRunner.RunTestScript("Test-NewAzResourceWithApiVersion");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzResourceComplexByResourceName()
        {
            TestRunner.RunTestScript("Test-NewAzResourceComplexByResourceName");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzResourceComplexByResourceId()
        {
            TestRunner.RunTestScript("Test-NewAzResourceComplexByResourceId");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzResourceByResourceName()
        {
            TestRunner.RunTestScript("Test-GetAzResourceByResourceName");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzResourceByResourceId()
        {
            TestRunner.RunTestScript("Test-GetAzResourceByResourceId");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzResourceByTag()
        {
            TestRunner.RunTestScript("Test-GetAzResourceByTag");
        }


        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzResourceViaPiping()
        {
            TestRunner.RunTestScript("Test-GetAzResourceViaPiping");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzResourceWithExpandProperties()
        {
            TestRunner.RunTestScript("Test-GetAzResourceWithExpandProperties");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzAResourceWithWildcard()
        {
            TestRunner.RunTestScript("Test-GetAzAResourceWithWildcard");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzResourceFromEmptyResourceGroup()
        {
            TestRunner.RunTestScript("Test-GetAzResourceFromEmptyResourceGroup");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzResourceFromNonExisingResourceGroup()
        {
            TestRunner.RunTestScript("Test-GetAzResourceFromNonExisingResourceGroup");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzResourceForNonExisingResource()
        {
            TestRunner.RunTestScript("Test-GetAzResourceForNonExisingResource");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzResourceForNonExisingResourceType()
        {
            TestRunner.RunTestScript("Test-GetAzResourceForNonExisingResourceType");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMoveAzResourceByResourceId()
        {
            TestRunner.RunTestScript("Test-MoveAzResourceByResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMoveAzResourceInDifferentResourceGroups()
        {
            TestRunner.RunTestScript("Test-MoveAzResourceInDifferentResourceGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMoveAzResourceToNonExistingResourceGroup()
        {
            TestRunner.RunTestScript("Test-MoveAzResourceToNonExistingResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMoveAzResourceNonExisting()
        {
            TestRunner.RunTestScript("Test-MoveAzResourceNonExisting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzResourceByResourceName()
        {
            TestRunner.RunTestScript("Test-SetAzResourceByResourceName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzResourceByResourceId()
        {
            TestRunner.RunTestScript("Test-SetAzResourceByResourceId");
        }

        [Fact(Skip = "Potential issue with InputObject parameter.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzResourceByResourceObject()
        {
            TestRunner.RunTestScript("Test-SetAzResourceByResourceObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzResourceViaPiping()
        {
            TestRunner.RunTestScript("Test-SetAzResourceViaPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzResourceWithPatch()
        {
            TestRunner.RunTestScript("Test-SetAzResourceWithPatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzResourceTags()
        {
            TestRunner.RunTestScript("Test-SetAzResourceTags");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzResourceForNonExistingResourceGroup()
        {
            TestRunner.RunTestScript("Test-SetAzResourceForNonExistingResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzResourceForNonExistingResource()
        {
            TestRunner.RunTestScript("Test-SetAzResourceForNonExistingResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzResourceForNonExistingResourceType()
        {
            TestRunner.RunTestScript("Test-SetAzResourceForNonExistingResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzResourceByResourceName()
        {
            TestRunner.RunTestScript("Test-RemoveAzResourceByResourceName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzResourceByResourceId()
        {
            TestRunner.RunTestScript("Test-RemoveAzResourceByResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzResourceViaPiping()
        {
            TestRunner.RunTestScript("Test-RemoveAzResourceViaPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzResourceParentResourceType()
        {
            TestRunner.RunTestScript("Test-RemoveAzResourceParentResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzResourceChildResourceType()
        {
            TestRunner.RunTestScript("Test-RemoveAzResourceChildResourceType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzResourceWithWildcard()
        {
            TestRunner.RunTestScript("Test-RemoveAzResourceWithWildcard");
        }
    }
}

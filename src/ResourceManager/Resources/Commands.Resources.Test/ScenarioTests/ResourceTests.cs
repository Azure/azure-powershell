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
    public class ResourceTests : ResourcesTestsBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewSimpleResource()
        {
            RunPowerShellTest("Test-CreatesNewSimpleResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatesNewComplexResource()
        {
            RunPowerShellTest("Test-CreatesNewComplexResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesViaPiping()
        {
            RunPowerShellTest("Test-GetResourcesViaPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesFromEmptyGroup()
        {
            RunPowerShellTest("Test-GetResourcesFromEmptyGroup");
        }

        [Fact (Skip = "TODO: Re-record")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesFromNonExisingGroup()
        {
            RunPowerShellTest("Test-GetResourcesFromNonExisingGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesForNonExisingType()
        {
            RunPowerShellTest("Test-GetResourcesForNonExisingType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceForNonExisingResource()
        {
            RunPowerShellTest("Test-GetResourceForNonExisingResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourcesViaPipingFromAnotherResource()
        {
            RunPowerShellTest("Test-GetResourcesViaPipingFromAnotherResource");
        }
    }
}

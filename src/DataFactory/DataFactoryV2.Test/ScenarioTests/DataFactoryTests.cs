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

using Microsoft.Azure.Commands.DataFactoryV2.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.DataFactoryV2.Test
{
    public class DataFactoryTests : DataFactoryV2TestRunner
    {
        public DataFactoryTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDataFactoriesInSubscriptionV2()
        {
            TestRunner.RunTestScript("Test-GetDataFactoriesInSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateFactoryGlobalParameters()
        {
            TestRunner.RunTestScript("Test-UpdateFactoryGlobalParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactoryV2WithUserAssignedIdentity()
        {
            TestRunner.RunTestScript("Test-CreateDataFactoryV2WithUserAssignedIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactoryV2WithCMK()
        {
            TestRunner.RunTestScript("Test-CreateDataFactoryV2WithCMK");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingDataFactoryV2()
        {
            TestRunner.RunTestScript("Test-GetNonExistingDataFactory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactoryV2()
        {
            TestRunner.RunTestScript("Test-CreateDataFactory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactoryV2WithVSTSRepoConfig()
        {
            TestRunner.RunTestScript("Test-CreateDataFactoryV2WithVSTSRepoConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactoryV2WithGitHubRepoConfig()
        {
            TestRunner.RunTestScript("Test-CreateDataFactoryV2WithGitHubRepoConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteDataFactoryWithDataFactoryParameterV2()
        {
            TestRunner.RunTestScript("Test-DeleteDataFactoryWithDataFactoryParameter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDataFactoryPipingV2()
        {
            TestRunner.RunTestScript("Test-DataFactoryPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetFactoryByNameParameterSetV2()
        {
            TestRunner.RunTestScript("Test-GetFactoryByNameParameterSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateDataFactoryV2()
        {
            TestRunner.RunTestScript("Test-UpdateDataFactory");
        }
    }
}

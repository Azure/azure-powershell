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

namespace Microsoft.Azure.Commands.DataFactoryV2.Test
{
    public class DataFactoryTests : DataFactoriesScenarioTestsBase
    {
        public XunitTracingInterceptor _logger;

        public DataFactoryTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDataFactoriesInSubscriptionV2()
        {
            RunPowerShellTest(_logger, "Test-GetDataFactoriesInSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingDataFactoryV2()
        {
            RunPowerShellTest(_logger, "Test-GetNonExistingDataFactory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactoryV2()
        {
            RunPowerShellTest(_logger, "Test-CreateDataFactory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactoryV2WithVSTSRepoConfig()
        {
            RunPowerShellTest(_logger, "Test-CreateDataFactoryV2WithVSTSRepoConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactoryV2WithGitHubRepoConfig()
        {
            RunPowerShellTest(_logger, "Test-CreateDataFactoryV2WithGitHubRepoConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteDataFactoryWithDataFactoryParameterV2()
        {
            RunPowerShellTest(_logger, "Test-DeleteDataFactoryWithDataFactoryParameter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDataFactoryPipingV2()
        {
            RunPowerShellTest(_logger, "Test-DataFactoryPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetFactoryByNameParameterSetV2()
        {
            RunPowerShellTest(_logger, "Test-GetFactoryByNameParameterSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateDataFactoryV2()
        {
            RunPowerShellTest(_logger, "Test-UpdateDataFactory");
        }
    }
}

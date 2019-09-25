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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class AppServicePlanTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public AppServicePlanTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewAppServicePlan()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CreateNewAppServicePlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewAppServicePlanHyperV()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CreateNewAppServicePlanHyperV");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAppServicePlan()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-SetAppServicePlan");
        }

        [Fact(Skip = "Needs investigation. Fails running playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAppServicePlan()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-GetAppServicePlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAppServicePlan()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-RemoveAppServicePlan");
        }

        [Fact(Skip = "TODO #5594: This test requires a pre-set AppService Environment with specific settings.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewAppServicePlanInAse()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CreateNewAppServicePlanInAse");
        }
    }
}

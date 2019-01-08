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

namespace Microsoft.Azure.Commands.Insights.Test.ScenarioTests
{
    public class AutoscaleTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public AutoscaleTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmAutoscaleSetting()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-AddAzureRmAutoscaleSetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAutoscaleSetting()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-GetAzureRmAutoscaleSetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAutoscaleSettingByName()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-GetAzureRmAutoscaleSettingByName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmAutoscaleSetting()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-RemoveAzureRmAutoscaleSetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAutoscaleHistory()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-GetAzureRmAutoscaleHistory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmAutoscaleNotification()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-NewAzureRmAutoscaleNotification");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmAutoscaleWebhook()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-NewAzureRmAutoscaleWebhook");
        }
    }
}

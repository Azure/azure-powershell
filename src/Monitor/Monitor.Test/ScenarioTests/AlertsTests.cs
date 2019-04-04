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
    public class AlertsTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public AlertsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmAlertRuleWebhook()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-NewAzureRmAlertRuleWebhook");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmAlertRuleEmail()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-NewAzureRmAlertRuleEmail");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmMetricAlertRule()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-AddAzureRmMetricAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmWebtestAlertRule()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-AddAzureRmWebtestAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAlertRule()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-GetAzureRmAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAlertRuleByName()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-GetAzureRmAlertRuleByName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmAlertRule()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-RemoveAzureRmAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAlertHistory()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-GetAzureRmAlertHistory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmMetricAlertRuleV2()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-GetAzureRmMetricAlertRuleV2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmMetricAlertRuleV2()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-RemoveAzureRmAlertRuleV2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmMetricAlertRuleV2()
        {
            TestsController.NewInstance.RunPsTest(_logger, "Test-AddAzureRmMetricAlertRuleV2");
        }
    }
}

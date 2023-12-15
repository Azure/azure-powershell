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

namespace Microsoft.Azure.Commands.Insights.Test.ScenarioTests
{
    public class AlertsTests : MonitorTestRunner
    {
        public AlertsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmAlertRuleWebhook()
        {
            TestRunner.RunTestScript("Test-NewAzureRmAlertRuleWebhook");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmAlertRuleEmail()
        {
            TestRunner.RunTestScript("Test-NewAzureRmAlertRuleEmail");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmMetricAlertRule()
        {
            TestRunner.RunTestScript("Test-AddAzureRmMetricAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmWebtestAlertRule()
        {
            TestRunner.RunTestScript("Test-AddAzureRmWebtestAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAlertRule()
        {
            TestRunner.RunTestScript("Test-GetAzureRmAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAlertRuleByName()
        {
            TestRunner.RunTestScript("Test-GetAzureRmAlertRuleByName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmAlertRule()
        {
            TestRunner.RunTestScript("Test-RemoveAzureRmAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAlertHistory()
        {
            TestRunner.RunTestScript("Test-GetAzureRmAlertHistory");
        }

        [Fact(Skip = "Test case fails due to the ActionGroup migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestGetAzureRmMetricAlertRuleV2()
        {
            TestRunner.RunTestScript("Test-GetAzureRmMetricAlertRuleV2");
        }

        [Fact(Skip = "Test case fails due to the ActionGroup migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestRemoveAzureRmMetricAlertRuleV2()
        {
            TestRunner.RunTestScript("Test-RemoveAzureRmAlertRuleV2");
        }

        [Fact(Skip = "Test case fails due to the ActionGroup migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestAddAzureRmMetricAlertRuleV2()
        {
            TestRunner.RunTestScript("Test-AddAzureRmMetricAlertRuleV2");
        }

        [Fact(Skip = "Test case fails due to the ActionGroup migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestAddAzureRmMetricAlertRuleV2WithoutActionGroup()
        {
            TestRunner.RunTestScript("Test-AddAzureRmMetricAlertRuleV2-NoActionGroup");
        }

        [Fact(Skip = "Test case fails due to the ActionGroup migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestAddAzureRmMetricAlertRuleV2WithActionGroupId()
        {
            TestRunner.RunTestScript("Test-AddAzureRmMetricAlertRuleV2-ActionGroupId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmMetricAlertRuleV2WithSkipMetricValidation()
        {
            TestRunner.RunTestScript("Test-AddAzureRmMetricAlertRuleV2-SkipMetricValidation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmMetricAlertRuleV2WithAutoMitigate()
        {
            TestRunner.RunTestScript("Test-AddAzureRmMetricAlertRuleV2-autoMitigate");
        }

        [Fact(Skip = "Test case fails due to the ActionGroup migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestDisableAzureRmMetricAlertRuleV2WithActionGroups()
        {
            TestRunner.RunTestScript("Test-DisableAzureRmMetricAlertRuleV2WithActionGroups");
        }

        [Fact(Skip = "Test case fails due to the ActionGroup migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestAddAzureRmDynamicMetricAlertRuleV2()
        {
            TestRunner.RunTestScript("Test-AddAzureRmMetricAlertRuleV2-DynamicThreshold");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestAddAzureRmWebtestAlertRuleV2()
        {
            TestRunner.RunTestScript("Test-AddAzureRmMetricAlertRuleV2-Webtest");
        }
    }
}

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
    public class AzureRmDiagnosticSettingTests : MonitorTestRunner
    {
        public AzureRmDiagnosticSettingTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmDiagnosticSetting()
        {
            TestRunner.RunTestScript("Test-GetAzureRmDiagnosticSetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingCreate()
        {
            TestRunner.RunTestScript("Test-SetAzureRmDiagnosticSettingCreate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingUpdate()
        {
            TestRunner.RunTestScript("Test-SetAzureRmDiagnosticSettingUpdate");
        }

        [Fact] //(Skip = "TODO: fixing this test after introducing Swagger specs")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingWithRetention()
        {
            TestRunner.RunTestScript("Test-SetAzureRmDiagnosticSettingWithRetention");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingCategoriesOnly()
        {
            TestRunner.RunTestScript("Test-SetAzureRmDiagnosticSetting-CategoriesOnly");
        }

        [Fact] //(Skip = "TODO: fixing this test after introducing Swagger specs")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingTimeGrainsOnly()
        {
            TestRunner.RunTestScript("Test-SetAzureRmDiagnosticSetting-TimegrainsOnly");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingEventHub()
        {
            TestRunner.RunTestScript("Test-SetAzureRmDiagnosticSetting-EventHub");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmDiagnosticSettingLogAnalytics()
        {
            TestRunner.RunTestScript("Test-SetAzureRmDiagnosticSetting-LogAnalytics");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzDiagnosticSettingCategory()
        {
            TestRunner.RunTestScript("Test-GetAzDiagnosticSettingCategory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestSubscriptionDiagnosticSetting()
        {
            TestRunner.RunTestScript("Test-SubscriptionDiagnosticSetting");
        }
    }
}

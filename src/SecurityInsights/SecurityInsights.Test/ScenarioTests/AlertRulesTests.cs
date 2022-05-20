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

namespace Microsoft.Azure.Commands.SecurityInsights.Test.ScenarioTests
{
    public class AlertRulesTests : SecurityInsightsTestRunner
    {
        public AlertRulesTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListAlertRules()
        {
            TestRunner.RunTestScript("Get-AzSentinelAlertRule-List");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAction()
        {
            TestRunner.RunTestScript("Get-AzSentinelAlertRule-Get");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateAlertRuleFusion()
        {
            TestRunner.RunTestScript("New-AzSentinelAlertRule-CreateFusion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateAlertRuleMSIC()
        {
            TestRunner.RunTestScript("New-AzSentinelAlertRule-CreateMSIC");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateAlertRuleScheduled()
        {
            TestRunner.RunTestScript("New-AzSentinelAlertRule-CreateScheduled");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAlertRule()
        {
            TestRunner.RunTestScript("Update-AzSentinelAlertRule-Update");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InputObject()
        {
            TestRunner.RunTestScript("Update-AzSentinelAlertRule-InputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveAlertRule()
        {
            TestRunner.RunTestScript("Remove-AzSentinelAlertRule-Delete");
        }
    }
}

﻿// ----------------------------------------------------------------------------------
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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.ScenarioTests
{
    public class AlertsTests : RMTestBase
    {
        public AlertsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmAlertRuleWebhook()
        {
            TestsController.NewInstance.RunPsTest("Test-NewAzureRmAlertRuleWebhook");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmAlertRuleEmail()
        {
            TestsController.NewInstance.RunPsTest("Test-NewAzureRmAlertRuleEmail");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmMetricAlertRule()
        {
            TestsController.NewInstance.RunPsTest("Test-AddAzureRmMetricAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmLogAlertRule()
        {
            TestsController.NewInstance.RunPsTest("Test-AddAzureRmLogAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmWebtestAlertRule()
        {
            TestsController.NewInstance.RunPsTest("Test-AddAzureRmWebtestAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAlertRule()
        {
            TestsController.NewInstance.RunPsTest("Test-GetAzureRmAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAlertRuleByName()
        {
            TestsController.NewInstance.RunPsTest("Test-GetAzureRmAlertRuleByName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmAlertRule()
        {
            TestsController.NewInstance.RunPsTest("Test-RemoveAzureRmAlertRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAlertHistory()
        {
            TestsController.NewInstance.RunPsTest("Test-GetAzureRmAlertHistory");
        }
    }
}

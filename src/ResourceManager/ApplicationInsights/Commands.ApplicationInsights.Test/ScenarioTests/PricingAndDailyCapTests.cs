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


using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ApplicationInsights.Test.ScenarioTests
{
    public class PricingAndDailyCapTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public PricingAndDailyCapTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPricingPlan()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetApplicationInsightsPricingPlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPricingPlan()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-SetApplicationInsightsPricingPlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetApplicationInsightsDailyCap()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetApplicationInsightsDailyCap");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetApplicationInsightsDailyCap()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-SetApplicationInsightsDailyCap");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDailyCapStatus()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetApplicationInsightsDailyCapStatus");
        }
    }
}

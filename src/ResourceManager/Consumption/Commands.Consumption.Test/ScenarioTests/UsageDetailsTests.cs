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

using Microsoft.Azure.Commands.Consumption.Test.ScenarioTests.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Consumption.Test.ScenarioTests
{
    public class UsageDetailsTests
    {
        private ServiceManagemenet.Common.Models.XunitTracingInterceptor _logger;

        public UsageDetailsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output);
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListUsageDetails()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListUsageDetails");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListUsageDetailsWithExpand()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListUsageDetailsWithExpand");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListUsageDetailsWithFilter()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListUsageDetailsWithFilter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListInvoiceUsageDetails()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListInvoiceUsageDetails");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListInvoiceUsageDetailsWithExpand()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListInvoiceUsageDetailsWithExpand");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListInvoiceUsageDetailsWithFilter()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListInvoiceUsageDetailsWithFilter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListBillingPeriodUsageDetails()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListBillingPeriodUsageDetails");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListBillingPeriodUsageDetailsWithExpand()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListBillingPeriodUsageDetailsWithExpand");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListBillingPeriodUsageDetailsWithFilter()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListBillingPeriodUsageDetailsWithFilter");
        }

    }
}

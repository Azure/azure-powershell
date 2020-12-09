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

using Microsoft.Azure.Commands.Billing.Test.ScenarioTests.ScenarioTest;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Billing.Test.ScenarioTests
{
    public class InvoicesTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public InvoicesTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListInvoices()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListInvoices");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListInvoicesWithDownloadUrl()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListInvoicesWithDownloadUrl");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListInvoicesWithMaxCount()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListInvoicesWithMaxCount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLatestInvoice()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetLatestInvoice");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetInvoiceByNameWithDownloadUrl()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetInvoiceByNameWithDownloadUrl");
        }

        // Modern invoice
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetModernInvoiceByName()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetModernInvoiceByName");
        }

        // billing Account tests
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModernInvoicesByBillingAccountName()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListModernInvoicesByBillingAccountName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModernInvoicesByBillingAccountNameWithDownloadUrl()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListModernInvoicesByBillingAccountNameWithDownloadUrl");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModernInvoicesByBillingAccountNameWithMaxCount()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListModernInvoicesByBillingAccountNameWithMaxCount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLatestModernInvoiceByBillingAccountName()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetLatestModernInvoiceByBillingAccountName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLatestModernInvoiceByBillingAccountNameWithDownloadUrl()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetLatestModernInvoiceByBillingAccountNameWithDownloadUrl");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetModernInvoiceByBillingAccountNameAndInvoiceNameWithDownloadUrl()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetModernInvoiceByBillingAccountNameAndInvoiceNameWithDownloadUrl");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetModernInvoiceByBillingAccountNameAndInvoiceName()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetModernInvoiceByBillingAccountNameAndInvoiceName");
        }

        // billing Profile tests
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModernInvoicesByBillingProfileName()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListModernInvoicesByBillingProfileName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModernInvoicesByBillingProfileNameWithDownloadUrl()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListModernInvoicesByBillingProfileNameWithDownloadUrl");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModernInvoicesByBillingProfileNameMaxCount()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListModernInvoicesByBillingProfileNameMaxCount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLatestInvoicesByBillingProfileName()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetLatestInvoicesByBillingProfileName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetModernInvoicesByBillingAccountNameBillingProfileNameBillingPeriod()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetInvoicesByBillingAccountNameBillingProfileNameBillingPeriod");
        }
    }
}

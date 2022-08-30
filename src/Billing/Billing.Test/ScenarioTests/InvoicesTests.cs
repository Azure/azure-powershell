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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Billing.Test.ScenarioTests
{
    public class InvoicesTests : BillingTestRunner
    {
        public InvoicesTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListInvoices()
        {
            TestRunner.RunTestScript("Test-ListInvoices");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListInvoicesWithDownloadUrl()
        {
            TestRunner.RunTestScript("Test-ListInvoicesWithDownloadUrl");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListInvoicesWithMaxCount()
        {
            TestRunner.RunTestScript("Test-ListInvoicesWithMaxCount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLatestInvoice()
        {
            TestRunner.RunTestScript("Test-GetLatestInvoice");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetInvoiceByNameWithDownloadUrl()
        {
            TestRunner.RunTestScript("Test-GetInvoiceByNameWithDownloadUrl");
        }

        // Modern invoice
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetModernInvoiceByName()
        {
            TestRunner.RunTestScript("Test-GetModernInvoiceByName");
        }

        // billing Account tests
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModernInvoicesByBillingAccountName()
        {
            TestRunner.RunTestScript("Test-ListModernInvoicesByBillingAccountName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModernInvoicesByBillingAccountNameWithDownloadUrl()
        {
            TestRunner.RunTestScript("Test-ListModernInvoicesByBillingAccountNameWithDownloadUrl");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModernInvoicesByBillingAccountNameWithMaxCount()
        {
            TestRunner.RunTestScript("Test-ListModernInvoicesByBillingAccountNameWithMaxCount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLatestModernInvoiceByBillingAccountName()
        {
            TestRunner.RunTestScript("Test-GetLatestModernInvoiceByBillingAccountName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLatestModernInvoiceByBillingAccountNameWithDownloadUrl()
        {
            TestRunner.RunTestScript("Test-GetLatestModernInvoiceByBillingAccountNameWithDownloadUrl");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetModernInvoiceByBillingAccountNameAndInvoiceNameWithDownloadUrl()
        {
            TestRunner.RunTestScript("Test-GetModernInvoiceByBillingAccountNameAndInvoiceNameWithDownloadUrl");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetModernInvoiceByBillingAccountNameAndInvoiceName()
        {
            TestRunner.RunTestScript("Test-GetModernInvoiceByBillingAccountNameAndInvoiceName");
        }

        // billing Profile tests
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModernInvoicesByBillingProfileName()
        {
            TestRunner.RunTestScript("Test-ListModernInvoicesByBillingProfileName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModernInvoicesByBillingProfileNameWithDownloadUrl()
        {
            TestRunner.RunTestScript("Test-ListModernInvoicesByBillingProfileNameWithDownloadUrl");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModernInvoicesByBillingProfileNameMaxCount()
        {
            TestRunner.RunTestScript("Test-ListModernInvoicesByBillingProfileNameMaxCount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLatestInvoicesByBillingProfileName()
        {
            TestRunner.RunTestScript("Test-GetLatestInvoicesByBillingProfileName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetModernInvoicesByBillingAccountNameBillingProfileNameBillingPeriod()
        {
            TestRunner.RunTestScript("Test-GetInvoicesByBillingAccountNameBillingProfileNameBillingPeriod");
        }
    }
}

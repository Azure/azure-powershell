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
    public class BillingAccountsTests : BillingTestRunner
    {
        public BillingAccountsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListBillingAccounts()
        {
            TestRunner.RunTestScript("Test-ListBillingAccounts");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListBillingAccountsWithAddress()
        {
            TestRunner.RunTestScript("Test-ListBillingAccountsWithAddress");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListBillingAccountsWithBillingProfiles()
        {
            TestRunner.RunTestScript("Test-ListBillingAccountsWithBillingProfiles");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListBillingAccountsWithInvoiceSections()
        {
            TestRunner.RunTestScript("Test-ListBillingAccountsWithInvoiceSections");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListBillingEntitiesToCreateSubscription()
        {
            TestRunner.RunTestScript("Test-ListBillingEntitiesToCreateSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBillingAccountWithName()
        {
            TestRunner.RunTestScript("Test-GetBillingAccountWithName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBillingAccountWithNames()
        {
            TestRunner.RunTestScript("Test-GetBillingAccountWithNames");
        }
    }
}

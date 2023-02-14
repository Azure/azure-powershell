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
    public class ReservationTests : ConsumptionTestRunner
    {
        public ReservationTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListReservationSummariesMonthlyWithOrderId()
        {
            TestRunner.RunTestScript("Test-ListReservationSummariesMonthlyWithOrderId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListReservationSummariesMonthlyWithOrderIdAndId()
        {
            TestRunner.RunTestScript("Test-ListReservationSummariesMonthlyWithOrderIdAndId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListReservationSummariesDailyWithOrderId()
        {
            TestRunner.RunTestScript("Test-ListReservationSummariesDailyWithOrderId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListReservationSummariesDailyWithOrderIdAndId()
        {
            TestRunner.RunTestScript("Test-ListReservationSummariesDailyWithOrderIdAndId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListReservationDetailsWithOrderId()
        {
            TestRunner.RunTestScript("Test-ListReservationDetailsWithOrderId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListReservationDetailsWithOrderIdAndId()
        {
            TestRunner.RunTestScript("Test-ListReservationDetailsWithOrderIdAndId");
        }
    }
}

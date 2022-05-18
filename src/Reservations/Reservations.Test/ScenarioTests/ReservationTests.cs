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

namespace Microsoft.Azure.Commands.Reservations.Test.ScenarioTests
{
    public class ReservationTests : ReservationsTestRunner
    {
        public ReservationTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMergeReservation()
        {
            TestRunner.RunTestScript("Test-MergeReservation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSplitReservation()
        {
            TestRunner.RunTestScript("Test-SplitReservation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetReservation()
        {
            TestRunner.RunTestScript("Test-GetReservation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateReservationToSingle()
        {
            TestRunner.RunTestScript("Test-UpdateReservationToSingle");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateReservationToShared()
        {
            TestRunner.RunTestScript("Test-UpdateReservationToShared");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListReservations()
        {
            TestRunner.RunTestScript("Test-ListReservations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListReservationHistory()
        {
            TestRunner.RunTestScript("Test-ListReservationHistory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetReservationOrderId()
        {
            TestRunner.RunTestScript("Test-GetReservationOrderId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetCatalog()
        {
            TestRunner.RunTestScript("Test-GetCatalog");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCalculatePrice()
        {
            TestRunner.RunTestScript("Test-CalculatePrice");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPurchase()
        {
            TestRunner.RunTestScript("Test-Purchase");
        }
    }
}

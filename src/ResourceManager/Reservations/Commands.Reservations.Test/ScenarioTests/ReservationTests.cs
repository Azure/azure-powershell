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

using Microsoft.Azure.Commands.Reservations.Test.ScenarioTests.ScenarioTest;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Reservations.Test.ScenarioTests
{
    public class ReservationTests
    {
        private ServiceManagemenet.Common.Models.XunitTracingInterceptor _logger;

        public ReservationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output);
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMergeReservation()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-MergeReservation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSplitReservation()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SplitReservation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetReservation()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetReservation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateReservationToSingle()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-UpdateReservationToSingle");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateReservationToShared()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-UpdateReservationToShared");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListReservations()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListReservations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListReservationHistory()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListReservationHistory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetReservationOrderId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetReservationOrderId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetCatalog()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetCatalog");
        }

    }
}

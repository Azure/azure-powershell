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

namespace Microsoft.Azure.Commands.Peering.Test.ScenarioTests.ScenarioTests
{
    using System;

    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    using Xunit;

    public class SetPeeringTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public SetPeeringTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this._logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this._logger);
            // Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAndSetUseForPeeringService()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-GetAndSetUseForPeeringService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNewIP()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-SetNewIP");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNewIPv6()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-SetNewIPv6");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNewBandwidth()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-SetNewBandwidth");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNewMd5Hash()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-SetNewMd5Hash");
        }
    }
}

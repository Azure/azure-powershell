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

    /// <summary>
    /// The create new peering tests.
    /// </summary>
    public class CreateNewExchangePeeringTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public CreateNewExchangePeeringTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this._logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this._logger);
            // Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewExchangePeering()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-NewExchangePeering");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewExchangePeeringPipe()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-NewExchangePeeringPipe");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewExchangePeeringPipeTwoConnections()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-NewExchangePeeringPipeTwoConnections");
        }
    }
}

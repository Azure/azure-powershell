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
    public class ScenerioExchangePeeringTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public ScenerioExchangePeeringTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this._logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this._logger);
            // Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAsn()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-Asn");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLegacyPeering()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-GetLegacyPeering Amsterdam");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConvertLegacyToExchange()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-ConvertLegacyToExchange");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateExchangeIPv4OnResourceId()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-UpdateExchangeIPv4OnResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateExchangeIPv4OnInputObject()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-UpdateExchangeIPv4OnInputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateExchangeMd5OnNameAndResourceGroup()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-UpdateExchangeMd5OnNameAndResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAsnExchange()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-RemoveAsnExchange");
        }
        
    }
}

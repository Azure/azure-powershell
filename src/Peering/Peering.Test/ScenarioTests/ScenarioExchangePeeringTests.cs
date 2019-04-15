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

namespace Microsoft.Azure.Commands.Peering.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    using Xunit;

    /// <summary>
    /// The scenario exchange peering tests.
    /// </summary>
    public class ScenarioExchangePeeringTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioExchangePeeringTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public ScenarioExchangePeeringTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this.logger);
        }

        /// <summary>
        /// The test get legacy peering.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLegacyPeering()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetLegacyPeering Ashburn");
        }

        /// <summary>
        /// The test convert legacy to exchange.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConvertLegacyToExchange()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-ConvertLegacyToExchange");
        }

        /// <summary>
        /// The test update exchange i pv 4 on resource id.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateExchangeIPv4OnResourceId()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-UpdateExchangeIPv4OnResourceId");
        }

        /// <summary>
        /// The test update exchange i pv 4 on input object.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateExchangeIPv4OnInputObject()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-UpdateExchangeIPv4OnInputObject");
        }

        /// <summary>
        /// The test update exchange md 5 on name and resource group.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateExchangeMd5OnNameAndResourceGroup()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-UpdateExchangeMd5OnNameAndResourceGroup");
        }
    }
}

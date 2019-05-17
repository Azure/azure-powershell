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
    /// The get location tests.
    /// </summary>
    public class GetLocationTests
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private ServiceManagement.Common.Models.XunitTracingInterceptor logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLocationTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public GetLocationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this.logger);
        }

        /// <summary>
        /// The test get location kind direct.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLocationKindDirect()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetLocationKindDirect");
        }

        /// <summary>
        /// The test get location kind exchange.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLocationKindExchange()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetLocationKindExchange");
        }

        /// <summary>
        /// The test get location kind exchange seattle.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLocationKindExchangeSeattle()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetLocationKindExchangeSeattle");
        }

        /// <summary>
        /// The test get location kind direct seattle.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLocationKindDirectSeattle()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetLocationKindDirectSeattle");
        }
    }
}

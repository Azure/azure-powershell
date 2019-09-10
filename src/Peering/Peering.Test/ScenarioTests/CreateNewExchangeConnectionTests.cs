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
    /// The create new exchange connection tests.
    /// </summary>
    public class CreateNewExchangeConnectionTests
    {
        /// <summary>
        /// The _logger.
        /// </summary>
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewExchangeConnectionTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public CreateNewExchangeConnectionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this._logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this._logger);
        }

        /// <summary>
        /// The test new exchange connection v 4 v 6.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewExchangeConnectionV4V6()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-NewExchangeConnectionV4V6");
        }

        /// <summary>
        /// The test new exchange connection v 4.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewExchangeConnectionV4()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-NewExchangeConnectionV4");
        }

        /// <summary>
        /// The test new exchange connection v 6.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewExchangeConnectionV6()
        {
            TestController.NewInstance.RunPowerShellTest(this._logger, "Test-NewExchangeConnectionV6");
        }
    }
}

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
    /// The get legacy tests.
    /// </summary>
    public class GetLegacyTests
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private ServiceManagement.Common.Models.XunitTracingInterceptor logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacyTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public GetLegacyTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this.logger);
        }

        /// <summary>
        /// The test get legacy kind exchange amsterdam.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLegacyKindDirectAmsterdam()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetLegacyKindDirectAmsterdam");
        }

        /// <summary>
        /// The test get legacy kind direct amsterdam.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLegacyKindExchangeAshburn()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetLegacyKindExchangeAshburn");
        }
    }
}

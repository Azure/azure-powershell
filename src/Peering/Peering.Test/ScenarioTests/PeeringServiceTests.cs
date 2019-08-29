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
    public class PeeringServiceTests
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
        public PeeringServiceTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this.logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPeeringServiceProviders()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetPeeringServiceProviders");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPeeringServiceLocations()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetPeeringServiceLocations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPeeringServiceByResourceGroup()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetPeeringServiceByResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPeeringServiceByResourceId()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetPeeringServiceByResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListPeeringService()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-ListPeeringService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPeeringService()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-NewPeeringService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPeeringServicePrefix()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-NewPeeringServicePrefix");
        }
    }
}

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
    /// The set peering tests.
    /// </summary>
    public class SetPeeringTests
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private ServiceManagement.Common.Models.XunitTracingInterceptor logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetPeeringTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public SetPeeringTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this.logger);
            
        }

        /// <summary>
        /// The test get and set use for peering service.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAndSetUseForPeeringService()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetAndSetUseForPeeringService");
        }

        /// <summary>
        /// The test set new ip.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNewIP()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-SetNewIP");
        }

        /// <summary>
        /// The test set new i pv 6.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNewIPv6()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-SetNewIPv6");
        }

        /// <summary>
        /// The test set new bandwidth.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNewBandwidth()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-SetNewBandwidth");
        }

        /// <summary>
        /// The test set new md 5 hash.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNewMd5Hash()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-SetNewMd5Hash");
        }
    }
}

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
    /// The create new peering tests.
    /// </summary>
    public class PeeringAsnTests
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private ServiceManagement.Common.Models.XunitTracingInterceptor logger;

        public PeeringAsnTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this.logger);
        }

        /// <summary>
        /// The test new peer asn.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPeerAsn()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-NewPeerAsn");
        }

        /// <summary>
        /// The test get peer asn.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPeerAsn()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-GetPeerAsn");
        }

        /// <summary>
        /// The test list peer asn.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListPeerAsn()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-ListPeerAsn");
        }

        /// <summary>
        /// The test set peer asn.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPeerAsn()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-SetPeerAsn");
        }

        /// <summary>
        /// The test remove peer asn.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePeerAsn()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-RemovePeerAsn");
        }
    }
}

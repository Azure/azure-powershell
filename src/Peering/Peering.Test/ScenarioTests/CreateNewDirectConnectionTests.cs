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
    using Microsoft.Azure.ServiceManagement.Common.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// The create new direct connection tests.
    /// </summary>
    public class CreateNewDirectConnectionTests
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private XunitTracingInterceptor logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewDirectConnectionTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public CreateNewDirectConnectionTests(ITestOutputHelper output)
        {
            this.logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this.logger);
        }

        /// <summary>
        /// The test new direct connection high bandwidth.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionHighBandwidth()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-NewDirectConnectionHighBandwidth");
        }

        /// <summary>
        /// The test new direct connection low bandwidth.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionLowBandwidth()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-NewDirectConnectionLowBandwidth");
        }

        /// <summary>
        /// The test new direct connection no session.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionNoSession()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-NewDirectConnectionNoSession");
        }

        /// <summary>
        /// The test new direct connection with v 4.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithV4()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-NewDirectConnectionWithV4");
        }

        /// <summary>
        /// The test new direct connection with v 4 v 6.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithV4V6()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-NewDirectConnectionWithV4V6");
        }

        /// <summary>
        /// The test new direct connection with v 6.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithV6()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-NewDirectConnectionWithV6");
        }

        /// <summary>
        /// The test new direct connection wrong v 4.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWrongV4()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-NewDirectConnectionWrongV4");
        }

        /// <summary>
        /// The test new direct connection wrong v 6.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWrongV6()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-NewDirectConnectionWrongV6");
        }
    }
}
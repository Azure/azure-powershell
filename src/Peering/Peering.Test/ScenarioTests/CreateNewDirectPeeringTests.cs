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
    public class CreateNewDirectPeeringTests : PeeringTestRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewDirectPeeringTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public CreateNewDirectPeeringTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// The test new direct peering.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectPeering()
        {
            TestRunner.RunTestScript("Test-NewDirectPeering");
        }

        /// <summary>
        /// The test new direct peering with pipe.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectPeeringWithPipe()
        {
            TestRunner.RunTestScript("Test-NewDirectPeeringWithPipe");
        }

        /// <summary>
        /// The test new direct peering pipe two connections.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectPeeringPipeTwoConnections()
        {
            TestRunner.RunTestScript("Test-NewDirectPeeringPipeTwoConnections");
        }

        /// <summary>
        /// The test new direct peering pipe two connections and sku premium direct free.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectPeeringPremiumDirectFree()
        {
            TestRunner.RunTestScript("Test-NewDirectPeeringPremiumDirectFree");
        }

        /// <summary>
        /// The test new direct peering pipe two connections and sku premium direct unlimited.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectPeeringPremiumDirectUnlimited()
        {
            TestRunner.RunTestScript("Test-NewDirectPeeringPremiumDirectUnlimited");
        }
    }
}

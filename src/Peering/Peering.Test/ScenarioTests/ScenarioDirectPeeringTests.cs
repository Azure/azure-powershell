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
    public class ScenarioDirectPeeringTests : PeeringTestRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioExchangePeeringTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public ScenarioDirectPeeringTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// The test get legacy peering.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateGetListRemovePeeringServicePrefix()
        {
            TestRunner.RunTestScript("Test-CreateGetListRemovePeeringServicePrefix");
        }
    }
}

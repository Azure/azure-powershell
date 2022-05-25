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
    public class SetPeeringTests : PeeringTestRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetPeeringTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public SetPeeringTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
            
        }

        /// <summary>
        /// The test set new bandwidth.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNewBandwidth()
        {
            TestRunner.RunTestScript("Test-SetNewBandwidth");
        }

        /// <summary>
        /// The test set new bandwidth.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNewIP()
        {
            TestRunner.RunTestScript("Test-SetNewIP");
        }

        /// <summary>
        /// The test set new bandwidth.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNewIPv6()
        {
            TestRunner.RunTestScript("Test-SetNewIPv6");
        }

        /// <summary>
        /// The test set new bandwidth.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNewMd5Hash()
        {
            TestRunner.RunTestScript("Test-SetNewMd5Hash");
        }
    }
}

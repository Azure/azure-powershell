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
    public class PeeringServiceTests : PeeringTestRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacyTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public PeeringServiceTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPeeringServiceProviders()
        {
            TestRunner.RunTestScript("Test-GetPeeringServiceProviders");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPeeringServiceLocations()
        {
            TestRunner.RunTestScript("Test-GetPeeringServiceLocations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPeeringServiceByResourceGroup()
        {
            TestRunner.RunTestScript("Test-GetPeeringServiceByResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPeeringServiceByResourceId()
        {
            TestRunner.RunTestScript("Test-GetPeeringServiceByResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListPeeringService()
        {
            TestRunner.RunTestScript("Test-ListPeeringService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPeeringService()
        {
            TestRunner.RunTestScript("Test-NewPeeringService");
        }
    }
}

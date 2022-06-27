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
    using Xunit.Abstractions;

    /// <summary>
    /// The create new direct connection tests.
    /// </summary>
    public class CreateNewDirectConnectionTests : PeeringTestRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewDirectConnectionTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public CreateNewDirectConnectionTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// The test new direct connection high bandwidth.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionHighBandwidth()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionHighBandwidth");
        }

        /// <summary>
        /// The test new direct connection low bandwidth.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionLowBandwidth()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionLowBandwidth");
        }

        /// <summary>
        /// The test new direct connection no session.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionNoSession()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionNoSession");
        }

        /// <summary>
        /// The test new direct connection with v 4.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithV4()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionWithV4");
        }

        /// <summary>
        /// The test new direct connection with v 4 v 6.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithV4V6()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionWithV4V6");
        }

        /// <summary>
        /// The test new direct connection with v 6.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithV6()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionWithV6");
        }

        /// <summary>
        /// The test new direct connection wrong v 4.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWrongV4()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionWrongV4");
        }

        /// <summary>
        /// The test new direct connection wrong v 6.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWrongV6()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionWrongV6");
        }

        /// <summary>
        /// The test new direct connection with microsoft ip address
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithMicrosoftSession()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionWithMicrosoftSession");
        }

        /// <summary>
        /// The test new direct connection with microsoft ip address
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithMicrosoftSessionWithPeeringService()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionWithMicrosoftSessionWithPeeringService");
        }

        /// <summary>
        /// The test new direct connection with microsoft ip address
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithMicrosoftSessionInvalidV4()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionWithMicrosoftSessionInvalidV4");
        }

        /// <summary>
        /// The test new direct connection with microsoft ip address
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithMicrosoftSessionInvalidV6()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionWithMicrosoftSessionInvalidV6");
        }

        /// <summary>
        /// The test new direct connection with microsoft ip address
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithNoPeeringFacility()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionWithNoPeeringFacility");
        }

        /// <summary>
        /// The test new direct connection with microsoft ip address
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithNoBgpSession()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionWithNoBgpSession");
        }

        /// <summary>
        /// The test new direct connection with microsoft ip address
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDirectConnectionWithMicrosoftIpProvidedAddress()
        {
            TestRunner.RunTestScript("Test-NewDirectConnectionWithMicrosoftIpProvidedAddress");
        }
    }
}
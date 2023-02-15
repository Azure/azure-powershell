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

namespace Microsoft.Azure.Commands.LogicApp.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    /// <summary>
    /// Scenario tests for integration account partner commands.
    /// </summary>
    public class IntegrationAccountPartnerTests : LogicAppTestRunner
    {
        public IntegrationAccountPartnerTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Test New-AzIntegrationAccountPartner command to create a new integration account partner.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatePartner()
        {
            TestRunner.RunTestScript("Test-CreateIntegrationAccountPartner");
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountPartner command to get the integration account partner.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPartner()
        {
            TestRunner.RunTestScript("Test-GetIntegrationAccountPartner");
        }

        /// <summary>
        /// Test Remove-AzIntegrationAccountPartner command to remove the integration account partner.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePartner()
        {
            TestRunner.RunTestScript("Test-RemoveIntegrationAccountPartner");
        }

        /// <summary>
        /// Test Set-AzIntegrationAccountPartner command to update the integration account partner.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdatePartner()
        {
            TestRunner.RunTestScript("Test-UpdateIntegrationAccountPartner");
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountPartner command to get all the integration account partners.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListPartner()
        {
            TestRunner.RunTestScript("Test-ListIntegrationAccountPartner");
        }
    }
}
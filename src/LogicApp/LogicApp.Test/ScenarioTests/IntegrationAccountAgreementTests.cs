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
    /// Scenario tests for integration account agreement commands.
    /// </summary>
    public class IntegrationAccountAgreementTests : LogicAppTestRunner
    {
        public IntegrationAccountAgreementTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Test New-AzIntegrationAccountAgreement command to create a new X12 integration account agreement.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAgreementX12()
        {
            TestRunner.RunTestScript("Test-CreateIntegrationAccountAgreementX12");
        }

        /// <summary>
        /// Test New-AzIntegrationAccountAgreement command with invalid partner and qualifier value.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAgreementWithFailure()
        {
            TestRunner.RunTestScript("Test-CreateIntegrationAccountAgreementWithFailure");
        }

        /// <summary>
        /// Test New-AzIntegrationAccountAgreement command to create a new AS2 integration account agreement.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAgreementAs2()
        {
            TestRunner.RunTestScript("Test-CreateIntegrationAccountAgreementAS2");
        }

        /// <summary>
        /// Test New-AzIntegrationAccountAgreement command to create a new EDIFACT integration account agreement.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAgreementEdifact()
        {
            TestRunner.RunTestScript("Test-CreateIntegrationAccountAgreementEdifact");
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountAgreement command to get the integration account agreement.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAgreement()
        {
            TestRunner.RunTestScript("Test-GetIntegrationAccountAgreement");
        }

        /// <summary>
        /// Test Remove-AzIntegrationAccountAgreement command to remove the integration account agreement.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAgreement()
        {
            TestRunner.RunTestScript("Test-RemoveIntegrationAccountAgreement");
        }

        /// <summary>
        /// Test Set-AzIntegrationAccountAgreement command to update the integration account agreement.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateAgreement()
        {
            TestRunner.RunTestScript("Test-UpdateIntegrationAccountAgreement");
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountAgreement command to get all the integration account agreements.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAgreement()
        {
            TestRunner.RunTestScript("Test-ListIntegrationAccountAgreement");
        }
    }
}
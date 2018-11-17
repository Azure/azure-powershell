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
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using ServiceManagemenet.Common.Models;
    using Xunit;

    /// <summary>
    /// Scenario tests for integration account agreement commands.
    /// </summary>
    public class IntegrationAccountAgreementTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public IntegrationAccountAgreementTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        /// <summary>
        /// Test New-AzureRmIntegrationAccountAgreement command to create a new X12 integration account agreement.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateIntegrationAccountAgreementX12()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-CreateIntegrationAccountAgreementX12");
        }

        /// <summary>
        /// Test New-AzureRmIntegrationAccountAgreement command with invalid partner and qualifier value.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateIntegrationAccountAgreementWithFailure()
        {
            WorkflowController.NewInstance.RunPowerShellTest(
                _logger, "Test-CreateIntegrationAccountAgreementWithFailure");
        }

        /// <summary>
        /// Test New-AzureRmIntegrationAccountAgreement command to create a new AS2 integration account agreement.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateIntegrationAccountAgreementAs2()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-CreateIntegrationAccountAgreementAS2");
        }

        /// <summary>
        /// Test New-AzureRmIntegrationAccountAgreement command to create a new EDIFACT integration account agreement.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateIntegrationAccountAgreementEdifact()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-CreateIntegrationAccountAgreementEdifact");
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccountAgreement command to get the integration account agreement.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountAgreement()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-GetIntegrationAccountAgreement");
        }

        /// <summary>
        /// Test Remove-AzureRmIntegrationAccountAgreement command to remove the integration account agreement.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveIntegrationAccountAgreement()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-RemoveIntegrationAccountAgreement");
        }        

        /// <summary>
        /// Test Set-AzureRmIntegrationAccountAgreement command to update the integration account agreement.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateIntegrationAccountAgreement()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-UpdateIntegrationAccountAgreement");
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccountAgreement command to get all the integration account agreements.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListIntegrationAccountAgreement()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-ListIntegrationAccountAgreement");
        }
    }
}


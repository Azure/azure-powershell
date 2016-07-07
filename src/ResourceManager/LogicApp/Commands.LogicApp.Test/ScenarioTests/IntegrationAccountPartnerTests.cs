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
    using Xunit;

    /// <summary>
    /// Scenario tests for integration account partner commands.
    /// </summary>
    public class IntegrationAccountPartnerTests : RMTestBase
    {

        /// <summary>
        /// Test New-AzureRmIntegrationAccountPartner command to create a new integration account partner.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateIntegrationAccountPartner()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-CreateIntegrationAccountPartner");
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccountPartner command to get the integration account partner.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountPartner()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-GetIntegrationAccountPartner");
        }

        /// <summary>
        /// Test Remove-AzureRmIntegrationAccountPartner command to remove the integration account partner.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveIntegrationAccountPartner()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-RemoveIntegrationAccountPartner");
        }        

        /// <summary>
        /// Test Set-AzureRmIntegrationAccountPartner command to update the integration account partner.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateIntegrationAccountPartner()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-UpdateIntegrationAccountPartner");
        }               
    }
}


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
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;

    /// <summary>
    /// Scenario tests for integration account commands.
    /// </summary>
    public class IntegrationAccountTests : RMTestBase
    {

        /// <summary>
        /// Test New-AzureRmIntegrationAccount command to create a new integration account.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateIntegrationAccount()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-CreateIntegrationAccount");
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccount command to get the integration account.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndGetIntegrationAccount()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-CreateAndGetIntegrationAccount");
        }

        /// <summary>
        /// Test Remove-AzureRmIntegrationAccount command to delete the integration account.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveIntegrationAccount()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-RemoveIntegrationAccount");
        }

        /// <summary>
        /// Test Update-AzureRmIntegrationAccount command to update the integration account.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateIntegrationAccount()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-UpdateIntegrationAccount");
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccountCallbackUrl command to get the integration account.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountCallbackUrl()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-GetIntegrationAccountCallbackUrl");
        }
    }
}
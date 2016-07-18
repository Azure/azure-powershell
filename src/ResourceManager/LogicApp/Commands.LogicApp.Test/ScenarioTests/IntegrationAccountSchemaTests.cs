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
    /// Scenario tests for integration account schema commands.
    /// </summary>
    public class IntegrationAccountSchemaTests : RMTestBase
    {

        /// <summary>
        /// Test New-AzureRmIntegrationAccountSchema command to create a new integration account schema.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateIntegrationAccountSchema()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-CreateIntegrationAccountSchema");
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccountSchema command to get the integration account schema.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountSchema()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-GetIntegrationAccountSchema");
        }

        /// <summary>
        /// Test Remove-AzureRmIntegrationAccountSchema command to remove the integration account schema.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveIntegrationAccountSchema()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-RemoveIntegrationAccountSchema");
        }        

        /// <summary>
        /// Test Set-AzureRmIntegrationAccountSchema command to update the integration account schema.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateIntegrationAccountSchema()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-UpdateIntegrationAccountSchema");
        }               
    }
}


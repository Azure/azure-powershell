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
    /// Scenario tests for integration account map commands.
    /// </summary>
    public class IntegrationAccountMapTests : RMTestBase
    {

        /// <summary>
        /// Test New-AzureRmIntegrationAccountMap command to create a new integration account map.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateIntegrationAccountMap()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-CreateIntegrationAccountMap");
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccountMap command to get the integration account map.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountMap()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-GetIntegrationAccountMap");
        }

        /// <summary>
        /// Test Remove-AzureRmIntegrationAccountMap command to remove the integration account map.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveIntegrationAccountMap()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-RemoveIntegrationAccountMap");
        }        

        /// <summary>
        /// Test Set-AzureRmIntegrationAccountMap command to update the integration account map.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateIntegrationAccountMap()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-UpdateIntegrationAccountMap");
        }               
    }
}


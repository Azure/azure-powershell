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
    /// Scenario tests for integration account generated Edifact control number commands.
    /// </summary>
    public class IntegrationAccountGeneratedEdifactIcnTests : RMTestBase
    {
        /// <summary>
        /// Test Get-AzureRmIntegrationAccountGeneratedIcn command to get the integration account generated Edifact interchange control number.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountGeneratedEdifactIcn()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-GetIntegrationAccountGeneratedEdifactControlNumber");
        }

        /// <summary>
        /// Test Set-AzureRmIntegrationAccountGeneratedIcn command to update the integration account generated Edifact interchange control number.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateIntegrationAccountGeneratedEdifactIcn()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-UpdateIntegrationAccountGenEdifactCN");
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccountGeneratedIcn command to get all the integration account generated Edifact interchange control numbers.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListIntegrationAccountGeneratedEdifactIcn()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-ListIntegrationAccountGenEdifactCN");
        }
    }
}

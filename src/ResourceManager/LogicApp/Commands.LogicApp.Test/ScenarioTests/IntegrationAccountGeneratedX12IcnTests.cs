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
    /// Scenario tests for integration account generated X12 control number commands.
    /// </summary>
    public class IntegrationAccountGeneratedX12IcnTests : RMTestBase
    {
        /// <summary>
        /// Test Get-AzureRmIntegrationAccountGeneratedIcn command to get the integration account generated X12 interchange control number.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountGeneratedX12Icn()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-GetIntegrationAccountGeneratedX12ControlNumber");
        }

        /// <summary>
        /// Test Set-AzureRmIntegrationAccountGeneratedIcn command to update the integration account generated X12 interchange control number.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateIntegrationAccountGeneratedX12Icn()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-UpdateIntegrationAccountGenX12CN");
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccountGeneratedIcn command to get all the integration account generated X12 interchange control numbers.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListIntegrationAccountGeneratedX12Icn()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-ListIntegrationAccountGenX12CN");
        }
    }
}

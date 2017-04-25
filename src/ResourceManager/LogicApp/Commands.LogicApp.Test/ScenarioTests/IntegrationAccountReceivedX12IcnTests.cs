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
    /// Scenario tests for integration account received x12 control number commands.
    /// </summary>
    public class IntegrationAccountReceivedX12IcnTests : RMTestBase
    {
        /// <summary>
        /// Test Get-AzureRmIntegrationAccountReceivedX12Icn command to get the integration account received x12 interchange control number.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountReceivedX12Icn()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-GetIntegrationAccountReceivedX12Icn");
        }

        /// <summary>
        /// Test Remove-AzureRmIntegrationAccountReceivedX12Icn command to update the integration account receied x12 interchange control number.
        /// </summary>
        /// <remarks>The test method name is abbreviated to avoid running into legacy path length limit inside the underlying http mock recorder.</remarks>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveIntegrationAccountReceivedX12Icn()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-RemoveIntegrationAccountReceivedX12Icn");
        }

        /// <summary>
        /// Test Set-AzureRmIntegrationAccountReceivedX12Icn command to update the integration account received x12 interchange control number.
        /// </summary>
        /// <remarks>The test method name is abbreviated to avoid running into legacy path length limit inside the underlying http mock recorder.</remarks>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateIntegrationAccountReceivedX12Icn()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-UpdateIntegrationAccountReceivedX12Icn");
        }
    }
}

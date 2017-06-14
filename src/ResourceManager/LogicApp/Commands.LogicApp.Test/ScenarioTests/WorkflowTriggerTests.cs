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
    using Xunit.Abstractions;

    /// <summary>
    /// Scenario tests for the Workflow trigger commands
    /// </summary>
    public class WorkflowTriggerTests : RMTestBase
    {
        public WorkflowTriggerTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        /// <summary>
        /// Test Test-GetAzureLogicAppTrigger command to verify the trigger in the workflow.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureLogicAppTrigger()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-GetAzureLogicAppTrigger");
        }

        /// <summary>
        /// Test Get-AzureLogicAppTriggerHistory command to verify the trigger history for the workflow.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureLogicAppTriggerHistory()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-GetAzureLogicAppTriggerHistory");
        }

        /// <summary>
        /// Test Get-AzureLogicAppTriggerHistory command to verify the trigger history for the workflow.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureLogicAppTriggerCallbackUrl()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-GetAzureLogicAppTriggerCallbackUrl");
        }

        /// <summary>
        /// Test Start-AzureLogicAppTrigger command to run the trigger of the workflow.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartAzureLogicAppTrigger()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-StartAzureLogicAppTrigger");
        }
    }
}
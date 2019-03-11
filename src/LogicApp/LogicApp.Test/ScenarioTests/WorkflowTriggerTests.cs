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
    using ServiceManagement.Common.Models;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Scenario tests for the Workflow trigger commands
    /// </summary>
    public class WorkflowTriggerTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public WorkflowTriggerTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        /// <summary>
        /// Test Test-GetAzLogicAppTrigger command to verify the trigger in the workflow.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzLogicAppTrigger()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-GetAzLogicAppTrigger");
        }

        /// <summary>
        /// Test Get-AzLogicAppTriggerHistory command to verify the trigger history for the workflow.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzLogicAppTriggerHistory()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-GetAzLogicAppTriggerHistory");
        }

        /// <summary>
        /// Test Get-AzLogicAppTriggerHistory command to verify the trigger history for the workflow.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzLogicAppTriggerCallbackUrl()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-GetAzLogicAppTriggerCallbackUrl");
        }

        /// <summary>
        /// Test Start-AzLogicAppTrigger command to run the trigger of the workflow.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartAzLogicAppTrigger()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-StartAzLogicAppTrigger");
        }
    }
}
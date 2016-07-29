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
    /// Scenario tests for the Create logic app command
    /// </summary>
    public class WorkflowTests : RMTestBase
    {
        public WorkflowTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        /// <summary>
        ///Test New-AzureLogicApp with physical file paths
        ///Test New-AzureLogicApp using definition object and parameter file
        ///Test New-AzureLogicApp using piped input
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndRemoveLogicApp()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-CreateAndRemoveLogicApp");
        }

        /// <summary>
        /// Test New-AzurelogicApp command to create workflow with duplicate name.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateLogicAppWithDuplicateName()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-CreateLogicAppWithDuplicateName");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with workflow object for parameters and definition input.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateLogicAppUsingInputfromWorkflowObject()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-CreateLogicAppUsingInputfromWorkflowObject");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with parameters parameter as Hashtable
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateLogicAppUsingInputParameterAsHashTable()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-CreateLogicAppUsingInputParameterAsHashTable");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with workflow definition with triggers
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateLogicAppUsingDefinitionWithTriggers()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-CreateLogicAppUsingDefinitionWithTriggers");
        }

        /// <summary>
        ///Test New-AzureLogicApp with only definition
        ///Test Get-AzureLogicApp 
        ///Test Get-AzureLogicApp for a non-existing logic app
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndGetLogicAppUsingDefinitionWithActions()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-CreateAndGetLogicAppUsingDefinitionWithActions");
        }

        /// <summary>
        /// Test Remove-AzurelogicApp command to remove non-existing workflow
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNonExistingLogicApp()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-RemoveNonExistingLogicApp");
        }

        /// <summary>
        ///Test Set-AzureLogicApp command to update workflow defintion without parametrs.
        ///Test Set-AzureLogicApp command to update workflow defintion and state to Disabled.
        ///Test Set-AzureLogicApp command to update workflow state to Enabled.
        ///Test Set-AzureLogicApp command to set logic app with null definition.
        ///Test Set-AzureLogicApp command to set non-existing logic app.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateLogicApp()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-UpdateLogicApp");
        }

        /// <summary>
        /// Test Test-AzureRmLogicApp command to validate given workflow definition.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestValidateLogicApp()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-ValidateLogicApp");
        }

        /// <summary>
        ///Test New-AzureLogicApp to create logic app for non-existing service plan. Constraint validation.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateLogicAppWithNonExistingAppServicePlan()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-CreateLogicAppWithNonExistingAppServicePlan");
        }

        /// <summary>
        ///Test Set-AzureLogicApp command to update workflow defintion without parametrs.
        ///Test Set-AzureLogicApp command to update workflow defintion and state to Disabled.
        ///Test Set-AzureLogicApp command to update workflow state to Enabled.
        ///Test Set-AzureLogicApp command to set logic app with null definition.
        ///Test Set-AzureLogicApp command to set non-existing logic app.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetUpgradedDefinitionForLogicApp()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-GetUpgradedDefinitionForLogicApp");
        }
    }
}
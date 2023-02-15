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
    using Xunit;
    using Xunit.Abstractions;
    /// <summary>
    /// Scenario tests for the Create logic app command
    /// </summary>
    public class WorkflowTests : LogicAppTestRunner
    {
        public WorkflowTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        ///Test New-AzLogicApp with physical file paths
        ///Test New-AzLogicApp using definition object and parameter file
        ///Test New-AzLogicApp using piped input
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndRemoveLogicApp()
        {
            TestRunner.RunTestScript("Test-CreateAndRemoveLogicApp");
        }

        /// <summary>
        /// Test New-AzurelogicApp command to create workflow with duplicate name.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateLogicAppWithDuplicateName()
        {
            TestRunner.RunTestScript("Test-CreateLogicAppWithDuplicateName");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with workflow object for parameters and definition input.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateLogicAppUsingInputfromWorkflowObject()
        {
            TestRunner.RunTestScript("Test-CreateLogicAppUsingInputfromWorkflowObject");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with parameters parameter as Hashtable
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateLogicAppUsingInputParameterAsHashTable()
        {
            TestRunner.RunTestScript("Test-CreateLogicAppUsingInputParameterAsHashTable");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with workflow definition with triggers
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateLogicAppUsingDefinitionWithTriggers()
        {
            TestRunner.RunTestScript("Test-CreateLogicAppUsingDefinitionWithTriggers");
        }

        /// <summary>
        ///Test New-AzLogicApp with only definition
        ///Test Get-AzLogicApp 
        ///Test Get-AzLogicApp for a non-existing logic app
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndGetLogicAppUsingDefinitionWithActions()
        {
            TestRunner.RunTestScript("Test-CreateAndGetLogicAppUsingDefinitionWithActions");
        }

        /// <summary>
        /// Test Remove-AzurelogicApp command to remove non-existing workflow
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNonExistingLogicApp()
        {
            TestRunner.RunTestScript("Test-RemoveNonExistingLogicApp");
        }

        /// <summary>
        ///Test Set-AzLogicApp command to update workflow definition without parameters.
        ///Test Set-AzLogicApp command to update workflow definition and state to Disabled.
        ///Test Set-AzLogicApp command to update workflow state to Enabled.
        ///Test Set-AzLogicApp command to set logic app with null definition.
        ///Test Set-AzLogicApp command to set non-existing logic app.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateLogicApp()
        {
            TestRunner.RunTestScript("Test-UpdateLogicApp");
        }

        /// <summary>
        /// Test Test-AzLogicApp command to validate given workflow definition.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestValidateLogicApp()
        {
            TestRunner.RunTestScript("Test-ValidateLogicApp");
        }

        /// <summary>
        ///Test Set-AzLogicApp command to update workflow definition without parameters.
        ///Test Set-AzLogicApp command to update workflow definition and state to Disabled.
        ///Test Set-AzLogicApp command to update workflow state to Enabled.
        ///Test Set-AzLogicApp command to set logic app with null definition.
        ///Test Set-AzLogicApp command to set non-existing logic app.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetUpgradedDefinitionForLogicApp()
        {
            TestRunner.RunTestScript("Test-GetUpgradedDefinitionForLogicApp");
        }

        /// <summary>
        ///Test Set-AzLogicApp command to update workflow with integration account.
        ///Test Set-AzLogicApp command to remove integration account from a workflow.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateLogicAppWithIntegrationAccount()
        {
            TestRunner.RunTestScript("Test-UpdateLogicAppWithIntegrationAccount");
        }
    }
}
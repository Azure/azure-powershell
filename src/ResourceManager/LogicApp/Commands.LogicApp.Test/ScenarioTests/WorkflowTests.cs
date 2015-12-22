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
    /// Scenario tests for the Create logic app command
    /// </summary>
    public class WorkflowTests : RMTestBase
    {

        /// <summary>
        /// Test New-AzurelogicApp command with Definition file and parameter file.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewLogicAppUsingDefinitionFilePath()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-NewLogicAppUsingDefinitionFilePath");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with Definition and parameter object as parameter.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewLogicAppUsingDefinitionObject()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-NewLogicAppUsingDefinitionObject");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with Definition  object and parameter file as parameter.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewLogicAppUsingDefinitionObjectAndParameterFile()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-NewLogicAppUsingDefinitionObjectAndParameterFile");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with pipe input from resource group.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewLogicAppUsingResourcegroupPipeline()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-NewLogicAppUsingResourcegroupPipeline");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with plan id.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewLogicAppWithPlanId()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-NewLogicAppWithPlanId");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with pipe input for SKU parameters.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewLogicAppUsingSkuPipeline()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-NewLogicAppUsingSkuPipeline");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with workflow object for parameters and definition input.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewLogicAppUsingInputfromWorkflowObject()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-NewLogicAppUsingInputfromWorkflowObject");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with parameters parameter as Hashtable
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewLogicAppUsingInputParameterAsHashTable()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-NewLogicAppUsingInputParameterAsHashTable");
        }                 

        /// <summary>
        /// Test New-AzurelogicApp command with workflow definition with triggers
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewLogicAppUsingDefinitionWithTriggers()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-NewLogicAppUsingDefinitionWithTriggers");
        }

        /// <summary>
        /// Test New-AzurelogicApp command with workflow definition with actions
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewLogicAppUsingDefinitionWithActions()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-NewLogicAppUsingDefinitionWithActions");
        }                         
    }
}
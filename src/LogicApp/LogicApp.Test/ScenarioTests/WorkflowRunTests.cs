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
    /// Scenario tests for the Workflow run commands
    /// </summary>
    public class WorkflowRunTests : LogicAppTestRunner
    {
        public WorkflowRunTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Test Start-Azurelogicapp and Stop-Azurelogicapp command to run workflow
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRunLogicApp()
        {
            TestRunner.RunTestScript("Test-StartLogicApp");
        }

        /// <summary>
        /// Test Get-AzLogicAppRun and Get-AzLogicAppRunHistory command to get logic app run history
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzLogicAppRunHistory()
        {
            TestRunner.RunTestScript("Test-GetAzLogicAppRunHistory");
        }

        /// <summary>
        /// Test Get-AzLogicAppRunAction command to get logic app run action
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzLogicAppRunAction()
        {
            TestRunner.RunTestScript("Test-GetAzLogicAppRunAction");
        }

        /// <summary>
        /// Test Stop-AzLogicAppRun command to cancel logic app run
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStopAzLogicAppRun()
        {
            TestRunner.RunTestScript("Test-StopAzLogicAppRun");
        }
    }
}
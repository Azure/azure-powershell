﻿// ----------------------------------------------------------------------------------
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
    /// Scenario tests for the Workflow run commands
    /// </summary>
    public class WorkflowRunTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public WorkflowRunTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        /// <summary>
        /// Test Start-Azurelogicapp and Stop-Azurelogicapp command to run workflow
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRunLogicApp()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-StartLogicApp");
        }

        /// <summary>
        /// Test Get-AzLogicAppRun and Get-AzLogicAppRunHistory command to get logic app run history
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzLogicAppRunHistory()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-GetAzLogicAppRunHistory");
        }

        /// <summary>
        /// Test Get-AzLogicAppRunAction command to get logic app run action
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzLogicAppRunAction()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-GetAzLogicAppRunAction");
        }

        /// <summary>
        /// Test Stop-AzLogicAppRun command to cancel logic app run
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStopAzLogicAppRun()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-StopAzLogicAppRun");
        }
    }
}
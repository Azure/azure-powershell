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
    using ServiceManagemenet.Common.Models;
    using Xunit;
    using Xunit.Abstractions;
    /// <summary>
    /// Scenario tests for the Workflow access key commands
    /// </summary>
    public class WorkflowAccessKeyTests : RMTestBase
    {
        public WorkflowAccessKeyTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        /// <summary>
        /// Test Get-AzureLogicAppAccessKey command to verify the get operation for access keys of a workflow.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureLogicAppAccessKey()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-GetAzureLogicAppAccessKey");
        }

        /// <summary>
        /// Test Set-AzureLogicAppAccessKey command to verify the secret regeneration operation for the access keys of a workflow.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureLogicAppAccessKey()
        {
            WorkflowController.NewInstance.RunPowerShellTest("Test-SetAzureLogicAppAccessKey");
        }
    }
}
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

    /// <summary>
    /// Scenario tests for integration account assembly commands.
    /// </summary>
    public class IntegrationAccountAssemblyTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;
        public IntegrationAccountAssemblyTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this._logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(this._logger);
        }

        /// <summary>
        /// Test New-AzureRmIntegrationAccountAssembly command to create a new integration account assembly.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateIntegrationAccountAssembly()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-CreateIntegrationAccountAssembly");
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccountAssembly command to get the integration account assembly.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountAssembly()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-GetIntegrationAccountAssembly");
        }

        /// <summary>
        /// Test Remove-AzureRmIntegrationAccountAssembly command to remove the integration account assembly.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveIntegrationAccountAssembly()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-RemoveIntegrationAccountAssembly");
        }

        /// <summary>
        /// Test Set-AzureRmIntegrationAccountAssembly command to update the integration account assembly.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateIntegrationAccountAssembly()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-UpdateIntegrationAccountAssembly");
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccountAssembly command to get all the integration account assembly.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListIntegrationAccountAssembly()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-ListIntegrationAccountAssembly");
        }

        /// <summary>
        /// Test end to end piping.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndToEndAssemblyPiping()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-EndToEndAssemblyPiping");
        }
    }
}
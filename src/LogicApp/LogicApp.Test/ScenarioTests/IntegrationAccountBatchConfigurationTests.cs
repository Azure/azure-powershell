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
    using Microsoft.Azure.ServiceManagement.Common.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;

    /// <summary>
    /// Scenario tests for integration account batch configuration commands.
    /// </summary>
    public class IntegrationAccountBatchConfigurationTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;
        public IntegrationAccountBatchConfigurationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this._logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(this._logger);
        }

        /// <summary>
        /// Test New-AzIntegrationAccountBatchConfiguration command to create a new integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateBatchConfiguration()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-CreateIntegrationAccountBatchConfiguration");
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountBatchConfiguration command to get the integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBatchConfiguration()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-GetIntegrationAccountBatchConfiguration");
        }

        /// <summary>
        /// Test Remove-AzIntegrationAccountBatchConfiguration command to remove the integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveBatchConfiguration()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-RemoveIntegrationAccountBatchConfiguration");
        }

        /// <summary>
        /// Test Set-AzIntegrationAccountBatchConfiguration command to update the integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateBatchConfiguration()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-UpdateIntegrationAccountBatchConfiguration");
        }
    }
}
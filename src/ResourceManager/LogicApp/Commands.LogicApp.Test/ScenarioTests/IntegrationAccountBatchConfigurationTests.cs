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
        /// Test New-AzureRmIntegrationAccountBatchConfiguration command to create a new integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateIntegrationAccountBatchConfiguration()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-CreateIntegrationAccountBatchConfiguration");
        }
         /// <summary>
        /// Test Get-AzureRmIntegrationAccountBatchConfiguration command to get the integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountBatchConfiguration()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-GetIntegrationAccountBatchConfiguration");
        }
         /// <summary>
        /// Test Remove-AzureRmIntegrationAccountBatchConfiguration command to remove the integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveIntegrationAccountBatchConfiguration()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-RemoveIntegrationAccountBatchConfiguration");
        }        
         /// <summary>
        /// Test Set-AzureRmIntegrationAccountBatchConfiguration command to update the integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateIntegrationAccountBatchConfiguration()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-UpdateIntegrationAccountBatchConfiguration");
        }
         /// <summary>
        /// Test Get-AzureRmIntegrationAccountBatchConfiguration command to get all the integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListIntegrationAccountBatchConfiguration()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-ListIntegrationAccountBatchConfiguration");
        }

        /// <summary>
        /// Test end to end piping.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndToEndAssemblyPiping()
        {
            WorkflowController.NewInstance.RunPowerShellTest(this._logger, "Test-EndToEndBatchConfigurationPiping");
        }
    }
}
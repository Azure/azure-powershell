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

    /// <summary>
    /// Scenario tests for integration account batch configuration commands.
    /// </summary>
    public class IntegrationAccountBatchConfigurationTests : LogicAppTestRunner
    {
        public IntegrationAccountBatchConfigurationTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Test New-AzIntegrationAccountBatchConfiguration command to create a new integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewBatchConfiguration()
        {
            TestRunner.RunTestScript("Test-NewIntegrationAccountBatchConfiguration");
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountBatchConfiguration command to get the integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBatchConfiguration()
        {
            TestRunner.RunTestScript("Test-GetIntegrationAccountBatchConfiguration");
        }

        /// <summary>
        /// Test Remove-AzIntegrationAccountBatchConfiguration command to remove the integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveBatchConfiguration()
        {
            TestRunner.RunTestScript("Test-RemoveIntegrationAccountBatchConfiguration");
        }

        /// <summary>
        /// Test Set-AzIntegrationAccountBatchConfiguration command to update the integration account batch configuration.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetBatchConfiguration()
        {
            TestRunner.RunTestScript("Test-SetIntegrationAccountBatchConfiguration");
        }
    }
}
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
    /// Scenario tests for integration account commands.
    /// </summary>
    public class IntegrationAccountTests : LogicAppTestRunner
    {
        public IntegrationAccountTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Test New-AzIntegrationAccount command to create a new integration account.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateIntegrationAccount()
        {
            TestRunner.RunTestScript("Test-CreateIntegrationAccount");
        }

        /// <summary>
        /// Test Get-AzIntegrationAccount command to get the integration account.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndGetIntegrationAccount()
        {
            TestRunner.RunTestScript("Test-GetIntegrationAccount");
        }

        /// <summary>
        /// Test Remove-AzIntegrationAccount command to delete the integration account.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveIntegrationAccount()
        {
            TestRunner.RunTestScript("Test-RemoveIntegrationAccount");
        }

        /// <summary>
        /// Test Update-AzIntegrationAccount command to update the integration account.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateIntegrationAccount()
        {
            TestRunner.RunTestScript("Test-UpdateIntegrationAccount");
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountCallbackUrl command to get the integration account.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountCallbackUrl()
        {
            TestRunner.RunTestScript("Test-GetIntegrationAccountCallbackUrl");
        }
    }
}
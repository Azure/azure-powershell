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
    /// Scenario tests for integration account schema commands.
    /// </summary>
    public class IntegrationAccountSchemaTests : LogicAppTestRunner
    {
        public IntegrationAccountSchemaTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Test New-AzIntegrationAccountSchema command to create a new integration account schema.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateSchema()
        {
            TestRunner.RunTestScript("Test-CreateIntegrationAccountSchema");
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountSchema command to get the integration account schema.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSchema()
        {
            TestRunner.RunTestScript("Test-GetIntegrationAccountSchema");
        }

        /// <summary>
        /// Test Remove-AzIntegrationAccountSchema command to remove the integration account schema.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSchema()
        {
            TestRunner.RunTestScript("Test-RemoveIntegrationAccountSchema");
        }

        /// <summary>
        /// Test Set-AzIntegrationAccountSchema command to update the integration account schema.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateSchema()
        {
            TestRunner.RunTestScript("Test-UpdateIntegrationAccountSchema");
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountSchema command to get all the integration account schema.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListSchema()
        {
            TestRunner.RunTestScript("Test-ListIntegrationAccountSchema");
        }
    }
}
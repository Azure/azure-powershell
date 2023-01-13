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
    /// Scenario tests for integration account generated control number commands.
    /// </summary>
    public class IntegrationAccountGeneratedIcnTests : LogicAppTestRunner
    {
        public IntegrationAccountGeneratedIcnTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountGeneratedIcn command to get the integration account generated interchange control number.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetGeneratedIcn()
        {
            TestRunner.RunTestScript("Test-GetGeneratedControlNumber");
        }

        /// <summary>
        /// Test Set-AzIntegrationAccountGeneratedIcn command to update the integration account generated interchange control number.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateGeneratedIcn()
        {
            TestRunner.RunTestScript("Test-UpdateGeneratedControlNumber");
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountGeneratedIcn command to get all the integration account generated interchange control numbers.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListGeneratedIcn()
        {
            TestRunner.RunTestScript("Test-ListGeneratedControlNumber");
        }
    }
}
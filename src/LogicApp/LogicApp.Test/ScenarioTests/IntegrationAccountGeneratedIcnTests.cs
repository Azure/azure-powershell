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
    using ServiceManagement.Common.Models;
    using Xunit;

    /// <summary>
    /// Scenario tests for integration account generated control number commands.
    /// </summary>
    public class IntegrationAccountGeneratedIcnTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public IntegrationAccountGeneratedIcnTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountGeneratedIcn command to get the integration account generated interchange control number.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetGeneratedIcn()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-GetGeneratedControlNumber");
        }

        /// <summary>
        /// Test Set-AzIntegrationAccountGeneratedIcn command to update the integration account generated interchange control number.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateGeneratedIcn()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-UpdateGeneratedControlNumber");
        }

        /// <summary>
        /// Test Get-AzIntegrationAccountGeneratedIcn command to get all the integration account generated interchange control numbers.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListGeneratedIcn()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-ListGeneratedControlNumber");
        }
    }
}
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

    /// <summary>
    /// Scenario tests for integration account received control number commands.
    /// </summary>
    public class IntegrationAccountReceivedIcnTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public IntegrationAccountReceivedIcnTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccountReceivedIcn command to get the integration account generated interchange control number.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountReceivedIcnWithoutAgreementType()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-GetIntegrationAccountReceivedIcn-NoAgreementType");
        }

        /// <summary>
        /// Test Get-AzureRmIntegrationAccountReceivedIcn command to get the integration account generated interchange control number.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIntegrationAccountReceivedIcn()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-GetIntegrationAccountReceivedIcn");
        }

        /// <summary>
        /// Test Remove-AzureRmIntegrationAccountReceivedIcn command to update the integration account generated interchange control number.
        /// </summary>
        /// <remarks>The test method name is abbreviated to avoid running into legacy path length limit inside the underlying http mock recorder.</remarks>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveIntegrationAccountReceivedIcn()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-RemoveIntegrationAccountReceivedIcn");
        }

        /// <summary>
        /// Test Set-AzureRmIntegrationAccountReceivedIcn command to update the integration account generated interchange control number.
        /// </summary>
        /// <remarks>The test method name is abbreviated to avoid running into legacy path length limit inside the underlying http mock recorder.</remarks>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateIntegrationAccountReceivedIcn()
        {
            WorkflowController.NewInstance.RunPowerShellTest(_logger, "Test-UpdateIntegrationAccountReceivedIcn");
        }
    }
}

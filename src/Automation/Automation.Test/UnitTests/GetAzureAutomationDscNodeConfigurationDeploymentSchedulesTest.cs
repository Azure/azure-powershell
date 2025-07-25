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

using Microsoft.Azure.Commands.Automation.Cmdlet;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    public class GetAzureAutomationDscNodeConfigurationDeploymentSchedulesTest : RMTestBase
    {
        private readonly Mock<IAutomationPSClient> mockAutomationClient;

        private readonly MockCommandRuntime mockCommandRuntime;

        private readonly GetAzureAutomationDscNodeConfigurationDeploymentSchedule cmdlet;

        public GetAzureAutomationDscNodeConfigurationDeploymentSchedulesTest()
        {
            mockAutomationClient = new Mock<IAutomationPSClient>();
            mockCommandRuntime = new MockCommandRuntime();
            cmdlet = new GetAzureAutomationDscNodeConfigurationDeploymentSchedule
            {
                AutomationClient = mockAutomationClient.Object,
                CommandRuntime = mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureAutomationDscNodeConfigurationDeploymentSchedulesByJobScheduleIdSuccessful()
        {
            // Setup
            var resourceGroupName = "resourceGroup";
            var accountName = "automation";
            var jobScheduleId = Guid.NewGuid();

            mockAutomationClient.Setup(
                f =>
                    f.GetNodeConfigurationDeploymentSchedule(resourceGroupName, accountName, jobScheduleId)
                );

            // Test
            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.AutomationAccountName = accountName;
            cmdlet.JobScheduleId = jobScheduleId;
            cmdlet.SetParameterSet("ByJobScheduleId");

            cmdlet.ExecuteCmdlet();

            // Assert
            mockAutomationClient.Verify(
                f =>
                    f.GetNodeConfigurationDeploymentSchedule(resourceGroupName, accountName, jobScheduleId), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureAutomationDscNodeConfigurationDeploymentSchedulesByAllSuccessful()
        {
            // Setup
            var resourceGroupName = "resourceGroup";
            var accountName = "automation";
            var nextLink = string.Empty;

            mockAutomationClient.Setup(
                f => f.ListNodeConfigurationDeploymentSchedules(resourceGroupName, accountName, ref nextLink)).Returns((string a, string b, string c) => new List<NodeConfigurationDeploymentSchedule>());

            // Test
            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.AutomationAccountName = accountName;
            cmdlet.SetParameterSet("ByAll");

            cmdlet.ExecuteCmdlet();

            // Assert
            mockAutomationClient.Verify(f => f.ListNodeConfigurationDeploymentSchedules(resourceGroupName, accountName, ref nextLink), Times.Once());
        }
    }
}

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
using Moq;
using Xunit;
using System;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    public class GetAzureAutomationDscNodeConfigurationDeploymentTest : RMTestBase
    {
        private readonly Mock<IAutomationPSClient> mockAutomationClient;

        private readonly MockCommandRuntime mockCommandRuntime;

        private readonly GetAzureAutomationDscNodeConfigurationDeployment cmdlet;

        public GetAzureAutomationDscNodeConfigurationDeploymentTest()
        {
            mockAutomationClient = new Mock<IAutomationPSClient>();
            mockCommandRuntime = new MockCommandRuntime();
            cmdlet = new GetAzureAutomationDscNodeConfigurationDeployment
            {
                AutomationClient = mockAutomationClient.Object,
                CommandRuntime = mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureAutomationDscCompilationJobTestSuccessful()
        {
            // Setup
            var resourceGroupName = "resourceGroup";
            var accountName = "automation";
            var jobId = Guid.NewGuid();

            string[][] nodeNames =
            {
                new[] {"WebServerPilot1", "WebServerPilot2"},
                new[] {"WebServerProd1", "WebServerProd2"}
            };

            mockAutomationClient.Setup(
                f =>
                    f.GetNodeConfigurationDeployment(resourceGroupName, accountName, jobId)
                );

            // Test
            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.AutomationAccountName = accountName;
            cmdlet.JobId = jobId;
            cmdlet.SetParameterSet("ByJobId");

            cmdlet.ExecuteCmdlet();

            // Assert
            mockAutomationClient.Verify(
                f =>
                    f.GetNodeConfigurationDeployment(resourceGroupName, accountName, jobId), Times.Once());
        }
    }
}
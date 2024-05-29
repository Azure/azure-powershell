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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    public class StartAzureAutomationDscNodeConfigurationDeploymentTest : RMTestBase
    {
        private readonly Mock<IAutomationPSClient> mockAutomationClient;

        private readonly MockCommandRuntime mockCommandRuntime;

        private readonly StartAzureAutomationDscNodeConfigurationDeployment cmdlet;

        public StartAzureAutomationDscNodeConfigurationDeploymentTest()
        {
            mockAutomationClient = new Mock<IAutomationPSClient>();
            mockCommandRuntime = new MockCommandRuntime();
            cmdlet = new StartAzureAutomationDscNodeConfigurationDeployment
            {
                AutomationClient = mockAutomationClient.Object,
                CommandRuntime = mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StartAzureAutomationDscCompilationJobTestSuccessful()
        {
            // Setup
            var resourceGroupName = "resourceGroup";
            var accountName = "automation";
            var nodeConfigurationName = "config.runbook";
            string[][] nodeNames =
            {
                new[] {"WebServerPilot1", "WebServerPilot2"},
                new[] {"WebServerProd1", "WebServerProd2"}
            };

            mockAutomationClient.Setup(
                f =>
                    f.StartNodeConfigurationDeployment(resourceGroupName, accountName, nodeConfigurationName, nodeNames,
                        null)
                );

            // Test
            cmdlet.ResourceGroupName = resourceGroupName;
            cmdlet.AutomationAccountName = accountName;
            cmdlet.NodeConfigurationName = nodeConfigurationName;
            cmdlet.NodeName = nodeNames;
            cmdlet.Schedule = null;
            cmdlet.SetParameterSet("ByAll");

            cmdlet.ExecuteCmdlet();

            // Assert
            mockAutomationClient.Verify(
                f =>
                    f.StartNodeConfigurationDeployment(resourceGroupName, accountName, nodeConfigurationName, nodeNames,
                        null), Times.Once());
        }
    }
}
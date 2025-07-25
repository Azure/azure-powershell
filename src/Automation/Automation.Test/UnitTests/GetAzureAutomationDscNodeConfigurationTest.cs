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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    public class GetAzureAutomationDscNodeConfigurationTest : RMTestBase
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureAutomationDscNodeConfiguration cmdlet;

        
        public GetAzureAutomationDscNodeConfigurationTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new GetAzureAutomationDscNodeConfiguration
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]

        public void GetAzureAutomationGetDscNodeConfigurationByName()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "account";
            string nodeConfigurationName = "config.localhost";
            string rollupStatus = "Good";
            
            this.mockAutomationClient.Setup(f => f.GetNodeConfiguration(resourceGroupName, accountName, nodeConfigurationName, rollupStatus));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = nodeConfigurationName;
            this.cmdlet.RollupStatus = rollupStatus;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetNodeConfiguration(resourceGroupName, accountName, nodeConfigurationName, rollupStatus), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]

        public void GetAzureAutomationDscNodeConfigurationByConfigurationName()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "account";
            string configurationName = "configuration";
            string rollupStatus = "Good";
            string nextLink = string.Empty;
            
            this.mockAutomationClient.Setup(f => f.ListNodeConfigurationsByConfigurationName(resourceGroupName, accountName, configurationName, rollupStatus, ref nextLink));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.ConfigurationName = configurationName;
            this.cmdlet.RollupStatus = rollupStatus;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListNodeConfigurationsByConfigurationName(resourceGroupName, accountName, configurationName, rollupStatus, ref nextLink), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]

        public void GetAzureAutomationDscNodeConfigurations()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "account";
            string rollupStatus = "Good";
            string nextLink = string.Empty;
            
            this.mockAutomationClient.Setup(f => f.ListNodeConfigurations(resourceGroupName, accountName, rollupStatus, ref nextLink));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.RollupStatus = rollupStatus;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListNodeConfigurations(resourceGroupName, accountName, rollupStatus, ref nextLink), Times.Once());
        }
    }
}
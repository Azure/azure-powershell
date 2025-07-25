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

using System;
using Microsoft.Azure.Commands.Automation.Cmdlet;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    public class GetAzureAutomationDscNodeTest : RMTestBase
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureAutomationDscNode cmdlet;

        
        public GetAzureAutomationDscNodeTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new GetAzureAutomationDscNode
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]

        public void GetAzureAutomationGetNodeById()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "account";
            Guid id = Guid.NewGuid();
            this.cmdlet.SetParameterSet("ById");

            this.mockAutomationClient.Setup(f => f.GetDscNodeById(resourceGroupName, accountName, id)).Returns((string a, string b, Guid c) => new DscNode());

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Id = id;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetDscNodeById(resourceGroupName, accountName, id), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]

        public void GetAzureAutomationDscNodeByName()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "account";
            string nodeName = "configuration";
            string nextLink = string.Empty;
            string status = DscNodeStatus.Compliant.ToString();
            this.cmdlet.SetParameterSet("ByName");

            this.mockAutomationClient.Setup(f => f.ListDscNodesByName(resourceGroupName, accountName, nodeName, status, ref nextLink));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = nodeName;
            this.cmdlet.Status = DscNodeStatus.Compliant;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListDscNodesByName(resourceGroupName, accountName, nodeName, status, ref nextLink), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]

        public void GetAzureAutomationDscNodeByNodeConfiguration()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "account";
            string nodeConfigurationName = "config.localhost";
            string nextLink = string.Empty;
            string status = DscNodeStatus.Compliant.ToString();
            this.cmdlet.SetParameterSet("ByNodeConfiguration");

            this.mockAutomationClient.Setup(f => f.ListDscNodesByNodeConfiguration(resourceGroupName, accountName, nodeConfigurationName, status, ref nextLink));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.NodeConfigurationName = nodeConfigurationName;
            this.cmdlet.Status = DscNodeStatus.Compliant;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListDscNodesByNodeConfiguration(resourceGroupName, accountName, nodeConfigurationName, status, ref nextLink), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureAutomationDscNodeByConfiguration()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "account";
            string nextLink = string.Empty;
            string configurationName = "config";
            string status = DscNodeStatus.Compliant.ToString();
            this.cmdlet.SetParameterSet("ByConfiguration");

            this.mockAutomationClient.Setup(f => f.ListDscNodesByConfiguration(resourceGroupName, accountName, configurationName, status, ref nextLink));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Status = DscNodeStatus.Compliant;
            this.cmdlet.ConfigurationName = configurationName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListDscNodesByConfiguration(resourceGroupName, accountName, configurationName, status, ref nextLink), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureAutomationDscNodes()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "account";
            string nextLink = string.Empty;
            string status = DscNodeStatus.Compliant.ToString();
            this.cmdlet.SetParameterSet("ByAll");

            this.mockAutomationClient.Setup(f => f.ListDscNodes(resourceGroupName, accountName, status, ref nextLink));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Status = DscNodeStatus.Compliant;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListDscNodes(resourceGroupName, accountName, status, ref nextLink), Times.Once());
        }
    }
}
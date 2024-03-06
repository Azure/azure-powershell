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
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    [TestClass]
    public class NewAzureAutomationHybridWorkerGroupTest : RMTestBase
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private NewAzureAutomationHybridRunbookWorkerGroup cmdlet;

        
        public NewAzureAutomationHybridWorkerGroupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new NewAzureAutomationHybridRunbookWorkerGroup
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureAutomationHybridWorkerGroupSuccessfull()
        {
            //Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string hybridRunbookWorkerGroupName = "hybridRunbookWorkerGroup";

            var mockHWG = new Microsoft.Azure.Management.Automation.Models.HybridRunbookWorkerGroup(hybridRunbookWorkerGroupName)
            {
                GroupType = "User"
            };

            this.mockAutomationClient.Setup(f => f.CreateOrUpdateRunbookWorkerGroup(resourceGroupName, accountName, hybridRunbookWorkerGroupName, null)).Returns(mockHWG);

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = hybridRunbookWorkerGroupName;
            this.cmdlet.CredentialName = null;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.CreateOrUpdateRunbookWorkerGroup(resourceGroupName, accountName, hybridRunbookWorkerGroupName, null), Times.Once());
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateAzureAutomationHybridWorkerGroupSuccessfull()
        {
            //Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string hybridRunbookWorkerGroupName = "hybridRunbookWorkerGroup";

            var mockHWG = new Microsoft.Azure.Management.Automation.Models.HybridRunbookWorkerGroup(hybridRunbookWorkerGroupName)
            {
                GroupType = "User"
            };

            this.mockAutomationClient.Setup(f => f.CreateOrUpdateRunbookWorkerGroup(resourceGroupName, accountName, hybridRunbookWorkerGroupName, null)).Returns(mockHWG);

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = hybridRunbookWorkerGroupName;
            this.cmdlet.CredentialName = null;
            this.cmdlet.ExecuteCmdlet();

            mockHWG.Credential = new RunAsCredentialAssociationProperty() { Name = "test" };
            this.mockAutomationClient.Setup(f => f.CreateOrUpdateRunbookWorkerGroup(resourceGroupName, accountName, hybridRunbookWorkerGroupName, "test")).Returns(mockHWG);

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = hybridRunbookWorkerGroupName;
            this.cmdlet.CredentialName = "test";
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.CreateOrUpdateRunbookWorkerGroup(resourceGroupName, accountName, hybridRunbookWorkerGroupName, null), Times.Once());
            this.mockAutomationClient.Verify(f => f.CreateOrUpdateRunbookWorkerGroup(resourceGroupName, accountName, hybridRunbookWorkerGroupName, "test"), Times.Once());
        }
    }
}

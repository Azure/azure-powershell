using Microsoft.Azure.Commands.Automation.Cmdlet;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    [TestClass]
    public class NewAzureAutomationHybridWorkerGroupTest
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private NewAzureAutomationHybridWorkerGroup cmdlet;

        
        public NewAzureAutomationHybridWorkerGroupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new NewAzureAutomationHybridWorkerGroup
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

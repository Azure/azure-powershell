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
    public class RemoveAzureAutomationHybridWorkerGroupTest
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private RemoveAzureAutomationHybridWorkerGroup setCmdlet;


        public RemoveAzureAutomationHybridWorkerGroupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.setCmdlet = new RemoveAzureAutomationHybridWorkerGroup
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureAutomationHybridWorkerGroupSuccessfull()
        {
            //Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string hybridRunbookWorkerGroupName = "hybridRunbookWorkerGroup";

            this.mockAutomationClient.Setup(f => f.DeleteHybridRunbookWorkerGroup(resourceGroupName, accountName, hybridRunbookWorkerGroupName));

            // Test
            this.setCmdlet.ResourceGroupName = resourceGroupName;
            this.setCmdlet.AutomationAccountName = accountName;
            this.setCmdlet.Name = hybridRunbookWorkerGroupName;
            this.setCmdlet.ExecuteCmdlet();


            // Assert
            this.mockAutomationClient.Verify(f => f.DeleteHybridRunbookWorkerGroup(resourceGroupName, accountName, hybridRunbookWorkerGroupName), Times.Once());
        }
    }
}

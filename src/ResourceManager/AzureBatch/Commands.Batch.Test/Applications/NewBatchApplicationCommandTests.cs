using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

using Moq;

using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.Applications
{
    public class NewBatchApplicationCommandTests : RMTestBase
    {
        private NewBatchApplicationCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewBatchApplicationCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewBatchApplicationCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddBatchApplicationTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string applicationId = "applicationId";
            string displayName = "displayName";

            PSApplication expected = new PSApplication();

            batchClientMock.Setup(b => b.AddApplication(resourceGroup, accountName, applicationId, true, displayName)).Returns(expected);

            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.AccountName = accountName;
            cmdlet.ApplicationId = applicationId;
            cmdlet.AllowUpdates = true;
            cmdlet.DisplayName = displayName;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(expected), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddBatchApplicationTestWithoutAllowUpdates()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string applicationId = "applicationId";
            string displayName = "displayName";

            PSApplication expected = new PSApplication();

            batchClientMock.Setup(b => b.AddApplication(resourceGroup, accountName, applicationId, null, displayName)).Returns(expected);

            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.AccountName = accountName;
            cmdlet.ApplicationId = applicationId;

            cmdlet.DisplayName = displayName;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(expected), Times.Once());
        }
    }
}

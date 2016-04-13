using System;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Applications
{
    public class UpdateBatchApplicationCommandTests
    {
        private SetBatchApplicationCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public UpdateBatchApplicationCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SetBatchApplicationCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateBatchApplicationTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string applicationId = "applicationId";
            string displayName = "name";
            string defaultVersion = "version";

            AzureOperationResponse updateResponse = new AzureOperationResponse();

            batchClientMock.Setup(b => b.UpdateApplication(resourceGroup, accountName, applicationId, true, defaultVersion, displayName)).Returns(updateResponse);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationId = applicationId;
            cmdlet.AllowUpdates = true;
            cmdlet.DefaultVersion = defaultVersion;
            cmdlet.DisplayName = displayName;

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

            batchClientMock.Verify(b => b.UpdateApplication(resourceGroup, accountName, applicationId, true, defaultVersion, displayName), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateBatchApplicationTest2()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string applicationId = "applicationId";

            AzureOperationResponse updateResponse = new AzureOperationResponse();

            batchClientMock.Setup(b => b.UpdateApplication(resourceGroup, accountName, applicationId, false, null, null)).Returns(updateResponse);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationId = applicationId;

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

            batchClientMock.Verify(b => b.UpdateApplication(resourceGroup, accountName, applicationId, false, null, null), Times.Once());
        }
    }
}

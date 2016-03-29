using System;

using Microsoft.Azure.Commands.Batch.Applications;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Applications
{
    public class UpdateBatchApplicationCommandTests
    {
        private UpdateBatchApplicationCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public UpdateBatchApplicationCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new UpdateBatchApplicationCommand()
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
            cmdlet.allowUpdates = true;
            cmdlet.defaultVersion = defaultVersion;
            cmdlet.displayName = displayName;

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

            batchClientMock.Verify(b => b.UpdateApplication(resourceGroup, accountName, applicationId, true, defaultVersion, displayName), Times.Once());
        }
    }
}

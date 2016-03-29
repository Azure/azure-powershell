using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Commands.Batch.Applications;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Moq;

using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.Applications
{
    public class DeleteBatchApplicationPackageCommandTests
    {
        private DeleteBatchApplicationPackageCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public DeleteBatchApplicationPackageCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new DeleteBatchApplicationPackageCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DeleteBatchApplicationPackageTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string applicationId = "applicationId";
            string version = "version";

            AzureOperationResponse deleteResponse = new AzureOperationResponse();

            batchClientMock.Setup(b => b.DeleteApplicationPackage(resourceGroup, accountName, applicationId, version)).Returns(deleteResponse);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationId = applicationId;
            cmdlet.ApplicationVersion = version;

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

            batchClientMock.Verify(b => b.DeleteApplicationPackage(resourceGroup, accountName, applicationId, version), Times.Once());
        }
    }
}

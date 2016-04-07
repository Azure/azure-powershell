using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Commands.Batch.Applications;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Moq;

using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.Applications
{
    public class UploadBatchApplicationCommandTests
    {
        private UploadBatchApplicationCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public UploadBatchApplicationCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new UploadBatchApplicationCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UploadBatchApplicationPackageTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string applicationId = "applicationId";
            string filePath = "~/fake/filepath";
            string version = "version";
            string format = "zip";

            PSApplicationPackage applicationPackageResponse = new PSApplicationPackage();

            batchClientMock.Setup(b => b.UploadApplicationPackage(resourceGroup, accountName, applicationId, version, filePath, format)).Returns(applicationPackageResponse);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationId = applicationId;
            cmdlet.FilePath = filePath;
            cmdlet.ApplicationVersion = version;
            cmdlet.Format = format;

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

            batchClientMock.Verify(b => b.UploadApplicationPackage(resourceGroup, accountName, applicationId, version, filePath, format), Times.Once());
        }
    }
}

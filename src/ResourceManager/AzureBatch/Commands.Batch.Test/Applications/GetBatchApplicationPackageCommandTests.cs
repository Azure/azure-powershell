using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Moq;

using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.Applications
{
    public class GetBatchApplicationPackageCommandTests
    {
        private GetBatchApplicationPackageCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchApplicationPackageCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchApplicationPackageCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchApplicationsTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string applicationId = "test";
            string applicationVersion = "foo";

            PSApplicationPackage expected = new PSApplicationPackage() { Id = applicationId, Version = applicationVersion };
            batchClientMock.Setup(b => b.GetApplicationPackage(resourceGroup, accountName, applicationId, applicationVersion)).Returns(expected);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationId = applicationId;
            cmdlet.ApplicationVersion = applicationVersion;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(expected), Times.Once());
        }
    }
}
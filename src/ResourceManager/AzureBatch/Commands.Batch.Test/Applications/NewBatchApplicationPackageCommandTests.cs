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
using System.Management.Automation;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.Applications
{
    public class NewBatchApplicationPackageCommandTests
    {
        private NewBatchApplicationPackageCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewBatchApplicationPackageCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewBatchApplicationPackageCommand()
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

            batchClientMock.Setup(b => b.UploadAndActivateApplicationPackage(resourceGroup, accountName, applicationId, version, filePath, format, false)).Returns(applicationPackageResponse);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationId = applicationId;
            cmdlet.FilePath = filePath;
            cmdlet.ApplicationVersion = version;
            cmdlet.Format = format;


            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

            batchClientMock.Verify(b => b.UploadAndActivateApplicationPackage(resourceGroup, accountName, applicationId, version, filePath, format, false), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UploadBatchApplicationPackageNoFilePathProvidedTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string applicationId = "applicationId";
            string version = "version";
            string format = "zip";
            string filePath = "";

            cmdlet.BatchClient = new BatchClient();

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationId = applicationId;
            cmdlet.ApplicationVersion = version;
            cmdlet.FilePath = filePath;
            cmdlet.Format = format;
            cmdlet.ActivateOnly = false;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ActivateApplicationPackageOnly()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string applicationId = "applicationId";
            string version = "version";
            string format = "zip";

            PSApplicationPackage applicationPackageResponse = new PSApplicationPackage();

            batchClientMock.Setup(b => b.UploadAndActivateApplicationPackage(resourceGroup, accountName, applicationId, version, null, format, true)).Returns(applicationPackageResponse);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationId = applicationId;
            cmdlet.ApplicationVersion = version;
            cmdlet.Format = format;
            cmdlet.ActivateOnly = true;


            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

            batchClientMock.Verify(b => b.UploadAndActivateApplicationPackage(resourceGroup, accountName, applicationId, version, null, format, true), Times.Once());
        }
    }
}

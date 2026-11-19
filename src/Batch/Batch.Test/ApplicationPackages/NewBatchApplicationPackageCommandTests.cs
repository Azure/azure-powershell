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
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ApplicationPackages
{
    public class NewBatchApplicationPackageCommandTests : RMTestBase
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
            string applicationName = "applicationName";
            string filePath = "~/fake/filepath";
            string version = "version";
            string format = "zip";

            PSApplicationPackage applicationPackageResponse = new PSApplicationPackage();

            batchClientMock.Setup(b => b.UploadAndActivateApplicationPackage(resourceGroup, accountName, applicationName, version, filePath, format, false)).Returns(applicationPackageResponse);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationName = applicationName;
            cmdlet.FilePath = filePath;
            cmdlet.ApplicationVersion = version;
            cmdlet.Format = format;


            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

            batchClientMock.Verify(b => b.UploadAndActivateApplicationPackage(resourceGroup, accountName, applicationName, version, filePath, format, false), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UploadBatchApplicationPackageNoFilePathProvidedTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string applicationName = "applicationName";
            string version = "version";
            string format = "zip";
            string filePath = "";

            cmdlet.BatchClient = new BatchClient();

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationName = applicationName;
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
            string applicationName = "applicationName";
            string version = "version";
            string format = "zip";

            PSApplicationPackage applicationPackageResponse = new PSApplicationPackage();

            batchClientMock.Setup(b => b.UploadAndActivateApplicationPackage(resourceGroup, accountName, applicationName, version, null, format, true)).Returns(applicationPackageResponse);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationName = applicationName;
            cmdlet.ApplicationVersion = version;
            cmdlet.Format = format;
            cmdlet.ActivateOnly = true;


            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

            batchClientMock.Verify(b => b.UploadAndActivateApplicationPackage(resourceGroup, accountName, applicationName, version, null, format, true), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FailedUploadDeletesTheNewVersion()
        {
            Mock<IApplicationPackageOperations> packageOperations = UseManagementClientWhoseUploadFails(versionExists: false);

            Assert.Throws<NewApplicationPackageException>(() => cmdlet.ExecuteCmdlet());

            packageOperations.Verify(p => p.DeleteWithHttpMessagesAsync("resourceGroup", "account01", "applicationName", "version", It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FailedUploadKeepsTheVersionThatExisted()
        {
            Mock<IApplicationPackageOperations> packageOperations = UseManagementClientWhoseUploadFails(versionExists: true);

            Assert.Throws<NewApplicationPackageException>(() => cmdlet.ExecuteCmdlet());

            packageOperations.Verify(p => p.DeleteWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()), Times.Never());
        }

        /// <summary>
        /// Gives the cmdlet a BatchClient over a fake management client. The package it creates gets a storage URL that
        /// isn't a URL, so the upload fails before anything is sent.
        /// </summary>
        private Mock<IApplicationPackageOperations> UseManagementClientWhoseUploadFails(bool versionExists)
        {
            string resourceGroup = "resourceGroup";
            string accountName = "account01";
            string applicationName = "applicationName";
            string version = "version";

            var packageOperations = new Mock<IApplicationPackageOperations>();
            var getVersion = packageOperations.Setup(p => p.GetWithHttpMessagesAsync(resourceGroup, accountName, applicationName, version, It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()));
            if (versionExists)
            {
                getVersion.Returns(Task.FromResult(new Microsoft.Rest.Azure.AzureOperationResponse<ApplicationPackage> { Body = new ApplicationPackage() }));
            }
            else
            {
                var notFound = new CloudException("The specified application package does not exist.")
                {
                    Response = new HttpResponseMessageWrapper(new HttpResponseMessage(HttpStatusCode.NotFound), string.Empty)
                };
                getVersion.Returns(Task.FromException<Microsoft.Rest.Azure.AzureOperationResponse<ApplicationPackage>>(notFound));
            }

            packageOperations.Setup(p => p.CreateWithHttpMessagesAsync(resourceGroup, accountName, applicationName, version, It.IsAny<IDictionary<string, string>>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Microsoft.Rest.Azure.AzureOperationResponse<ApplicationPackage> { Body = new ApplicationPackage(storageUrl: "not a URL") }));
            packageOperations.Setup(p => p.DeleteWithHttpMessagesAsync(resourceGroup, accountName, applicationName, version, It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Microsoft.Rest.Azure.AzureOperationResponse()));

            var applicationOperations = new Mock<IApplicationOperations>();
            applicationOperations.Setup(a => a.GetWithHttpMessagesAsync(resourceGroup, accountName, applicationName, It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Microsoft.Rest.Azure.AzureOperationResponse<Application> { Body = new Application(allowUpdates: true) }));

            var managementClient = new Mock<IBatchManagementClient>();
            managementClient.Setup(c => c.ApplicationPackage).Returns(packageOperations.Object);
            managementClient.Setup(c => c.Application).Returns(applicationOperations.Object);

            cmdlet.BatchClient = new BatchClient(managementClient.Object, new Mock<IResourceManagementClient>().Object);
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.AccountName = accountName;
            cmdlet.ApplicationName = applicationName;
            cmdlet.ApplicationVersion = version;
            cmdlet.Format = "zip";
            // Any file that exists; the upload fails before reading it.
            cmdlet.FilePath = typeof(NewBatchApplicationPackageCommandTests).Assembly.Location;
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            return packageOperations;
        }
    }
}

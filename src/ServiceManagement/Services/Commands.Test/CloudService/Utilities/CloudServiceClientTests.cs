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
using System.IO;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Models;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using Moq;
using MockStorageService = Microsoft.WindowsAzure.Commands.Test.Utilities.Common.MockStorageService;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Utilities
{
    
    public class CloudServiceClientTests : SMTestBase
    {
        private AzureSubscription subscription;

        private ClientMocks clientMocks;

        private Mock<CloudBlobUtility> cloudBlobUtilityMock;

        private ICloudServiceClient client;

        private const string serviceName = "cloudService";

        private const string storageName = "storagename";

        private MockServicesHost services;
        private MockStorageService storageService;

        private void ExecuteInTempCurrentDirectory(string path, Action action)
        {
            string currentDirectory = System.Environment.CurrentDirectory;

            try
            {
                System.Environment.CurrentDirectory = path;
                action();
            }
            catch
            {
                System.Environment.CurrentDirectory = currentDirectory;
                throw;
            }
        }

        private void SetupStorage(string name, MockStorageService.StorageAccountData a)
        {
            a.Name = name;
            a.BlobEndpoint = "http://awesome.blob.core.windows.net/";
            a.QueueEndpoint = "http://awesome.queue.core.windows.net/";
            a.TableEndpoint = "http://awesome.table.core.windows.net/";
            a.PrimaryKey =
                "MNao3bm7t7B/x+g2/ssh9HnG0mEh1QV5EHpcna8CetYn+TSRoA8/SBoH6B3Ufwtnz3jZLSw9GEUuCTr3VooBWq==";// [SuppressMessage("Microsoft.Security", "CS001:SecretInline")]
            a.SecondaryKey = "secondaryKey";
        }

        private void RemoveDeployments()
        {
            services.Clear()
                .Add(s => { s.Name = serviceName; });
        }

        public CloudServiceClientTests()
        {
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;

            storageService = new MockStorageService()
                .Add(a => SetupStorage(serviceName.ToLowerInvariant(), a))
                .Add(a => SetupStorage(storageName.ToLowerInvariant(), a));

            services = new MockServicesHost()
                .Add(s =>
                {
                    s.Name = serviceName;
                    s.AddDeployment(d =>
                    {
                        d.Slot = DeploymentSlot.Production;
                        d.Name = "mydeployment";
                    });
                });

            subscription = new AzureSubscription
            {
                Properties = new Dictionary<AzureSubscription.Property,string> {{AzureSubscription.Property.Default, "True"}},
                Id = Guid.NewGuid(),
                Name = Test.Utilities.Common.Data.Subscription1,
            };

            cloudBlobUtilityMock = new Mock<CloudBlobUtility>();
            cloudBlobUtilityMock.Setup(f => f.UploadPackageToBlob(
                It.IsAny<StorageManagementClient>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<BlobRequestOptions>())).Returns(new Uri("http://www.packageurl.azure.com"));

            clientMocks = new ClientMocks(subscription.Id);

            services.InitializeMocks(clientMocks.ComputeManagementClientMock);
            storageService.InitializeMocks(clientMocks.StorageManagementClientMock);

            client = new CloudServiceClient(subscription,
                clientMocks.ManagementClientMock.Object,
                clientMocks.StorageManagementClientMock.Object,
                clientMocks.ComputeManagementClientMock.Object
                )
            {
                CloudBlobUtility = cloudBlobUtilityMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartCloudService()
        {
            client.StartCloudService(serviceName);

            Assert.True(services.LastDeploymentStatusUpdate.HasValue);
            Assert.Equal(UpdatedDeploymentStatus.Running, services.LastDeploymentStatusUpdate.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStopCloudService()
        {
            client.StopCloudService(serviceName);

            Assert.True(services.LastDeploymentStatusUpdate.HasValue);
            Assert.Equal(UpdatedDeploymentStatus.Suspended, services.LastDeploymentStatusUpdate.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveCloudService()
        {
            clientMocks.ComputeManagementClientMock.Setup(
                c => c.Deployments.DeleteByNameAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns((string s, string deploymentName, bool deleteAll, CancellationToken cancellationToken) => Tasks.FromResult(
                    CreateComputeOperationResponse("req0")));

            clientMocks.ComputeManagementClientMock.Setup(
                c => c.HostedServices.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new AzureOperationResponse
                {
                    RequestId = "request000",
                    StatusCode = HttpStatusCode.OK
                }));

            // Test
            client.RemoveCloudService(serviceName);

            // Assert
            clientMocks.ComputeManagementClientMock.Verify(
                c => c.Deployments.DeleteByNameAsync(serviceName, "mydeployment", false, It.IsAny<CancellationToken>()), Times.Once);

            clientMocks.ComputeManagementClientMock.Verify(
                c => c.HostedServices.DeleteAsync(serviceName, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveCloudServiceWithStaging()
        {
            services.Clear()
                .Add(s =>
                {
                    s.Name = serviceName;
                    s.AddDeployment(d =>
                    {
                        d.Name = "myStagingdeployment";
                        d.Slot = DeploymentSlot.Staging;
                    });
                });

            clientMocks.ComputeManagementClientMock.Setup(
                c => c.Deployments.DeleteByNameAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns((string s, string deploymentName, bool deleteAll, CancellationToken cancellationToken) => Tasks.FromResult(
                    CreateComputeOperationResponse("request001")));

            clientMocks.ComputeManagementClientMock.Setup(
                c => c.HostedServices.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new AzureOperationResponse
                {
                    RequestId = "request000",
                    StatusCode = HttpStatusCode.OK
                }));

            // Test
            client.RemoveCloudService(serviceName);

            // Assert
            clientMocks.ComputeManagementClientMock.Verify(
                c => c.Deployments.DeleteByNameAsync(serviceName, "myStagingdeployment", false, It.IsAny<CancellationToken>()), Times.Once);

            clientMocks.ComputeManagementClientMock.Verify(
                c => c.HostedServices.DeleteAsync(serviceName, It.IsAny<CancellationToken>()), Times.Once);

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveCloudServiceWithoutDeployments()
        {
            RemoveDeployments();

            clientMocks.ComputeManagementClientMock.Setup(
                c => c.Deployments.BeginDeletingBySlotAsync(It.IsAny<string>(), DeploymentSlot.Production, It.IsAny<CancellationToken>()))
                .Returns((string s, DeploymentSlot slot, CancellationToken cancellationToken) => Tasks.FromResult(new AzureOperationResponse
                {
                    RequestId = "req0",
                    StatusCode = HttpStatusCode.OK
                }));

            clientMocks.ComputeManagementClientMock.Setup(
                c => c.HostedServices.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new AzureOperationResponse
                {
                    RequestId = "request000",
                    StatusCode = HttpStatusCode.OK
                }));

            // Test
            client.RemoveCloudService(serviceName);

            // Assert
            clientMocks.ComputeManagementClientMock.Verify(
                c => c.Deployments.BeginDeletingBySlotAsync(serviceName, DeploymentSlot.Production, It.IsAny<CancellationToken>()), Times.Never);

            clientMocks.ComputeManagementClientMock.Verify(
                c => c.HostedServices.DeleteAsync(serviceName, It.IsAny<CancellationToken>()), Times.Once);

        }

        [Fact (Skip = "Ignore")]
        public void TestPublishNewCloudService()
        {
            RemoveDeployments();

            clientMocks.ComputeManagementClientMock.Setup(
                c =>
                c.HostedServices.CreateAsync(It.IsAny<HostedServiceCreateParameters>(), It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new AzureOperationResponse
                {
                    RequestId = "request001",
                    StatusCode = HttpStatusCode.OK
                }));

            using (var files = new FileSystemHelper(this) { EnableMonitoring = true })
            {
                // Setup
                string rootPath = files.CreateNewService(serviceName);
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                var cloudServiceProject = new CloudServiceProject(rootPath, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
                cloudServiceProject.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);


                ExecuteInTempCurrentDirectory(rootPath, () => client.PublishCloudService(location: "West US"));

                clientMocks.ComputeManagementClientMock.Verify(c => c.Deployments.CreateAsync(
                    serviceName, DeploymentSlot.Production, It.IsAny<DeploymentCreateParameters>(), It.IsAny<CancellationToken>()), Times.Once);
            }

        }

        [Fact(Skip = "Ignore")]
        public void TestUpgradeCloudService()
        {
            clientMocks.ComputeManagementClientMock.Setup(
                c =>
                c.HostedServices.CreateAsync(It.IsAny<HostedServiceCreateParameters>(), It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new AzureOperationResponse
                {
                    RequestId = "request001",
                    StatusCode = HttpStatusCode.OK
                }));

            clientMocks.ComputeManagementClientMock.Setup(
                c =>
                c.Deployments.UpgradeBySlotAsync(It.IsAny<string>(), DeploymentSlot.Production,
                                                 It.IsAny<DeploymentUpgradeParameters>(),
                                                 It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(CreateComputeOperationResponse("req002")));

            using (var files = new FileSystemHelper(this) { EnableMonitoring = true })
            {
                // Setup
                string rootPath = files.CreateNewService(serviceName);
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                var cloudServiceProject = new CloudServiceProject(rootPath, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
                cloudServiceProject.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);

                ExecuteInTempCurrentDirectory(rootPath, () => client.PublishCloudService(location: "West US"));

                clientMocks.ComputeManagementClientMock.Verify(c => c.Deployments.UpgradeBySlotAsync(serviceName, DeploymentSlot.Production, It.IsAny<DeploymentUpgradeParameters>(), It.IsAny<CancellationToken>()), Times.Once);
            }

        }

        [Fact(Skip = "Ignore")]
        public void TestCreateStorageServiceWithPublish()
        {
            RemoveDeployments();
            
            clientMocks.ComputeManagementClientMock.Setup(
                c =>
                c.HostedServices.CreateAsync(It.IsAny<HostedServiceCreateParameters>(), It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new AzureOperationResponse
                {
                    RequestId = "request001",
                    StatusCode = HttpStatusCode.OK
                }));

            storageService.Clear();

            using (var files = new FileSystemHelper(this) { EnableMonitoring = true })
            {
                // Setup
                string rootPath = files.CreateNewService(serviceName);
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                var cloudServiceProject = new CloudServiceProject(rootPath, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
                cloudServiceProject.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);

                ExecuteInTempCurrentDirectory(rootPath, () => client.PublishCloudService(location: "West US"));

                clientMocks.StorageManagementClientMock.Verify(c => c.StorageAccounts.CreateAsync(It.IsAny<StorageAccountCreateParameters>(), It.IsAny<CancellationToken>()), Times.Once);
            }            
        }

        [Fact(Skip = "Ignore")]
        public void TestPublishWithCurrentStorageAccount()
        {
            RemoveDeployments();

            clientMocks.ComputeManagementClientMock.Setup(
                c =>
                c.HostedServices.CreateAsync(It.IsAny<HostedServiceCreateParameters>(), It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new AzureOperationResponse
                {
                    RequestId = "request001",
                    StatusCode = HttpStatusCode.OK
                }));

            using (var files = new FileSystemHelper(this) { EnableMonitoring = true })
            {
                // Setup
                string rootPath = files.CreateNewService(serviceName);
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                var cloudServiceProject = new CloudServiceProject(rootPath, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
                cloudServiceProject.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                subscription.Properties[AzureSubscription.Property.StorageAccount] = storageName;

                ExecuteInTempCurrentDirectory(rootPath, () => client.PublishCloudService(location: "West US"));

                cloudBlobUtilityMock.Verify(f => f.UploadPackageToBlob(
                    clientMocks.StorageManagementClientMock.Object,
                    subscription.GetProperty(AzureSubscription.Property.StorageAccount),
                    It.IsAny<string>(),
                    It.IsAny<BlobRequestOptions>()), Times.Once());
            }           
        }

        [Fact(Skip = "Ignore")]
        public void TestPublishWithDefaultLocation()
        {
            RemoveDeployments();

            clientMocks.ComputeManagementClientMock.Setup(
                c =>
                c.HostedServices.CreateAsync(It.IsAny<HostedServiceCreateParameters>(), It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new AzureOperationResponse
                {
                    RequestId = "request001",
                    StatusCode = HttpStatusCode.OK
                }));

            clientMocks.ManagementClientMock.Setup(c => c.Locations.ListAsync(It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new LocationsListResponse
                {
                    Locations =
                    {
                        new LocationsListResponse.Location {DisplayName = "East US", Name = "EastUS"}
                    }
                }));

            using (var files = new FileSystemHelper(this) { EnableMonitoring = true })
            {
                // Setup
                string rootPath = files.CreateNewService(serviceName);
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                var cloudServiceProject = new CloudServiceProject(rootPath, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
                cloudServiceProject.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);

                ExecuteInTempCurrentDirectory(rootPath, () => client.PublishCloudService());

                clientMocks.ManagementClientMock.Verify(c => c.Locations.ListAsync(It.IsAny<CancellationToken>()), Times.Once);
            }            
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPublishFromPackageUsingDefaultLocation()
        {
            RemoveDeployments();

            clientMocks.ComputeManagementClientMock.Setup(
                c =>
                c.HostedServices.CreateAsync(It.IsAny<HostedServiceCreateParameters>(), It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new AzureOperationResponse
                {
                    RequestId = "request001",
                    StatusCode = HttpStatusCode.OK
                }));

            clientMocks.ManagementClientMock.Setup(c => c.Locations.ListAsync(It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new LocationsListResponse
                {
                    Locations =
                    {
                        new LocationsListResponse.Location {DisplayName = "East US", Name = "EastUS"}
                    }
                }));

            using (var files = new FileSystemHelper(this) { EnableMonitoring = false })
            {
                // Setup
                string packageName = serviceName;
                string package, configuration;
                files.CreateDirectoryWithPrebuiltPackage(packageName, out package, out configuration);
                files.CreateAzureSdkDirectoryAndImportPublishSettings();

                // Execute
                ExecuteInTempCurrentDirectory(Path.GetDirectoryName(package),
                    () => client.PublishCloudService(package, configuration, null, null, null, null, null, false, false));

                // Verify
                clientMocks.ComputeManagementClientMock.Verify(c => c.Deployments.CreateAsync(
                    serviceName, DeploymentSlot.Production, It.IsAny<DeploymentCreateParameters>(), It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpgradeCloudServiceFromAPackage()
        {
            clientMocks.ComputeManagementClientMock.Setup(
                c =>
                c.HostedServices.CreateAsync(It.IsAny<HostedServiceCreateParameters>(), It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new AzureOperationResponse
                {
                    RequestId = "request001",
                    StatusCode = HttpStatusCode.OK
                }));

            clientMocks.ComputeManagementClientMock.Setup(
                c =>
                c.Deployments.UpgradeBySlotAsync(It.IsAny<string>(), DeploymentSlot.Production,
                                                 It.IsAny<DeploymentUpgradeParameters>(),
                                                 It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(CreateComputeOperationResponse("req002")));


            clientMocks.ManagementClientMock.Setup(c => c.Locations.ListAsync(It.IsAny<CancellationToken>()))
                .Returns(Tasks.FromResult(new LocationsListResponse
                {
                    Locations =
                    {
                        new LocationsListResponse.Location {DisplayName = "East US", Name = "EastUS"}
                    }
                }));

            using (var files = new FileSystemHelper(this) { EnableMonitoring = true })
            {
                // Setup
                string packageName = serviceName;
                string package, configuration;
                files.CreateDirectoryWithPrebuiltPackage(packageName, out package, out configuration);
                files.CreateAzureSdkDirectoryAndImportPublishSettings();

                // Execute
                ExecuteInTempCurrentDirectory(Path.GetDirectoryName(package),
                    () => client.PublishCloudService(package, configuration, null, null, null, null, null, false, false));

                // Verify
                clientMocks.ComputeManagementClientMock.Verify(c => c.Deployments.UpgradeBySlotAsync(serviceName, 
                    DeploymentSlot.Production, It.IsAny<DeploymentUpgradeParameters>(), It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        private OperationStatusResponse CreateComputeOperationResponse(string requestId, OperationStatus status = OperationStatus.Succeeded)
        {
            return new OperationStatusResponse
            {
                Error = null,
                HttpStatusCode = HttpStatusCode.OK,
                Id = "id",
                RequestId = requestId,
                Status = status,
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}

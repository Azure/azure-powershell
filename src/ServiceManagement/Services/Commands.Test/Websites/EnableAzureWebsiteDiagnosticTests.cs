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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities;
using Microsoft.WindowsAzure.Commands.Websites;
using Moq;
using Xunit;
using Microsoft.Azure.Common.Authentication;
using System;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    public class EnableAzureWebsiteApplicationDiagnosticTests : WebsitesTestBase
    {
        private const string websiteName = "website1";

        private Mock<IWebsitesClient> websitesClientMock = new Mock<IWebsitesClient>();

        private EnableAzureWebsiteApplicationDiagnosticCommand enableAzureWebsiteApplicationDiagnosticCommand;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private Dictionary<DiagnosticProperties, object> properties;

        public EnableAzureWebsiteApplicationDiagnosticTests()
        {
            websitesClientMock = new Mock<IWebsitesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            properties = new Dictionary<DiagnosticProperties, object>();
            properties[DiagnosticProperties.LogLevel] = LogEntryType.Information;
        }

        [Fact]
        public void EnableAzureWebsiteApplicationDiagnosticApplication()
        {
            // Setup
            websitesClientMock.Setup(f => f.EnableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.FileSystem,
                properties, null));

            enableAzureWebsiteApplicationDiagnosticCommand = new EnableAzureWebsiteApplicationDiagnosticCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object,
                File = true,
                LogLevel = LogEntryType.Information
            };

            currentProfile = new AzureProfile();
            var subscription = new AzureSubscription { Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            // Test
            enableAzureWebsiteApplicationDiagnosticCommand.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.EnableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.FileSystem,
                properties, null), Times.Once());

            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Never());
        }

        [Fact]
        public void EnableAzureWebsiteApplicationDiagnosticApplicationTableLog()
        {
            // Setup
            string storageName = "MyStorage";
            string tableName = "MyTable";
            properties[DiagnosticProperties.StorageAccountName] = storageName;
            properties[DiagnosticProperties.StorageTableName] = tableName.ToLowerInvariant();
            websitesClientMock.Setup(f => f.EnableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.StorageTable,
                properties, null));

            enableAzureWebsiteApplicationDiagnosticCommand = new EnableAzureWebsiteApplicationDiagnosticCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object,
                TableStorage = true,
                LogLevel = LogEntryType.Information,
                StorageAccountName = storageName,
                StorageTableName = tableName
            };

            currentProfile = new AzureProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            // Test
            enableAzureWebsiteApplicationDiagnosticCommand.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.EnableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.StorageTable,
                properties, null), Times.Once());

            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Never());
        }

        [Fact]
        public void EnableAzureWebsiteApplicationDiagnosticApplicationTableLogUseCurrentStorageAccount()
        {
            // Setup
            string storageName = "MyStorage";
            string tableName = "MyTable";
            properties[DiagnosticProperties.StorageAccountName] = storageName;
            properties[DiagnosticProperties.StorageTableName] = tableName.ToLowerInvariant();
            websitesClientMock.Setup(f => f.EnableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.StorageTable,
                properties, null));

            enableAzureWebsiteApplicationDiagnosticCommand = new EnableAzureWebsiteApplicationDiagnosticCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object,
                TableStorage = true,
                LogLevel = LogEntryType.Information,
                StorageTableName = tableName
            };

            currentProfile = new AzureProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;
            currentProfile.CurrentContext.Subscription.Properties[AzureSubscription.Property.StorageAccount] = storageName;

            // Test
            enableAzureWebsiteApplicationDiagnosticCommand.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.EnableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.StorageTable,
                properties, null), Times.Once());

            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Never());
        }

        [Fact]
        public void EnableAzureWebsiteApplicationDiagnosticApplicationBlobLog()
        {
            // Setup
            string storageName = "MyStorage";
            string blobContainerName = "MyBlobContainer";
            properties[DiagnosticProperties.StorageAccountName] = storageName;
            properties[DiagnosticProperties.StorageBlobContainerName] = blobContainerName.ToLowerInvariant();
            websitesClientMock.Setup(f => f.EnableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.StorageBlob,
                properties, null));

            enableAzureWebsiteApplicationDiagnosticCommand = new EnableAzureWebsiteApplicationDiagnosticCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object,
                BlobStorage = true,
                LogLevel = LogEntryType.Information,
                StorageAccountName = storageName,
                StorageBlobContainerName = blobContainerName
            };

            currentProfile = new AzureProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            // Test
            enableAzureWebsiteApplicationDiagnosticCommand.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.EnableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.StorageBlob,
                properties, null), Times.Once());

            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Never());
        }

        [Fact]
        public void EnableAzureWebsiteApplicationDiagnosticApplicationBlobLogUseCurrentStorageAccount()
        {
            // Setup
            string storageName = "MyStorage";
            string blobContainerName = "MyBlobContainer";
            properties[DiagnosticProperties.StorageAccountName] = storageName;
            properties[DiagnosticProperties.StorageBlobContainerName] = blobContainerName.ToLowerInvariant();
            websitesClientMock.Setup(f => f.EnableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.StorageBlob,
                properties, null));

            enableAzureWebsiteApplicationDiagnosticCommand = new EnableAzureWebsiteApplicationDiagnosticCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object,
                BlobStorage = true,
                LogLevel = LogEntryType.Information,
                StorageBlobContainerName = blobContainerName
            };

            currentProfile = new AzureProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;
            currentProfile.CurrentContext.Subscription.Properties[AzureSubscription.Property.StorageAccount] = storageName;

            // Test
            enableAzureWebsiteApplicationDiagnosticCommand.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.EnableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.StorageBlob,
                properties, null), Times.Once());

            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Never());
        }

        [Fact]
        public void EnableApplicationDiagnosticOnSlot()
        {
            string slot = "staging";
            // Setup
            websitesClientMock.Setup(f => f.EnableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.FileSystem,
                properties,
                slot));

            enableAzureWebsiteApplicationDiagnosticCommand = new EnableAzureWebsiteApplicationDiagnosticCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object,
                File = true,
                LogLevel = LogEntryType.Information,
                Slot = slot
            };

            currentProfile = new AzureProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            // Test
            enableAzureWebsiteApplicationDiagnosticCommand.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.EnableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.FileSystem,
                properties,
                slot), Times.Once());

            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Never());
        }
    }
}

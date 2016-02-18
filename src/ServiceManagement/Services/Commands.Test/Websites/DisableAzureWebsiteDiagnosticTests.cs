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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Websites;
using Moq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication;
using System;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    public class DisableAzureWebsiteApplicationDiagnosticTests : WebsitesTestBase
    {
        private const string websiteName = "website1";

        private Mock<IWebsitesClient> websitesClientMock = new Mock<IWebsitesClient>();

        private DisableAzureWebsiteApplicationDiagnosticCommand disableAzureWebsiteApplicationDiagnosticCommand;

        private Mock<ICommandRuntime> commandRuntimeMock;

        public DisableAzureWebsiteApplicationDiagnosticTests()
        {
            websitesClientMock = new Mock<IWebsitesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableAzureWebsiteApplicationDiagnosticApplication()
        {
            // Setup
            websitesClientMock.Setup(f => f.DisableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.FileSystem, null));

            disableAzureWebsiteApplicationDiagnosticCommand = new DisableAzureWebsiteApplicationDiagnosticCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object,
                File = true,
            };

            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            // Test
            disableAzureWebsiteApplicationDiagnosticCommand.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.DisableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.FileSystem, null), Times.Once());

            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Never());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableAzureWebsiteApplicationDiagnosticApplicationTableLog()
        {
            // Setup
            websitesClientMock.Setup(f => f.DisableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.StorageTable, null));

            disableAzureWebsiteApplicationDiagnosticCommand = new DisableAzureWebsiteApplicationDiagnosticCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object,
                TableStorage = true
            };

            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            // Test
            disableAzureWebsiteApplicationDiagnosticCommand.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.DisableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.StorageTable, null), Times.Once());

            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Never());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableAzureWebsiteApplicationDiagnosticApplicationBlobLog()
        {
            // Setup
            websitesClientMock.Setup(f => f.DisableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.StorageTable, null));

            disableAzureWebsiteApplicationDiagnosticCommand = new DisableAzureWebsiteApplicationDiagnosticCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object,
                BlobStorage = true
            };

            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            // Test
            disableAzureWebsiteApplicationDiagnosticCommand.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.DisableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.StorageBlob, null), Times.Once());

            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Never());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisablesApplicationDiagnosticOnSlot()
        {
            // Setup
            string slot = "staging";
            websitesClientMock.Setup(f => f.DisableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.FileSystem, slot));

            disableAzureWebsiteApplicationDiagnosticCommand = new DisableAzureWebsiteApplicationDiagnosticCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object,
                File = true,
                Slot = slot
            };

            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            // Test
            disableAzureWebsiteApplicationDiagnosticCommand.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.DisableApplicationDiagnostic(
                websiteName,
                WebsiteDiagnosticOutput.FileSystem, slot), Times.Once());

            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Never());
        }
    }
}

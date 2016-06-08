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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Websites;
using Moq;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    
    public class RestartAzureWebsiteTests : WebsitesTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProcessRestartWebsiteTest()
        {
            // Setup
            const string websiteName = "website1";
            Mock<IWebsitesClient> websitesClientMock = new Mock<IWebsitesClient>();
            websitesClientMock.Setup(f => f.RestartWebsite(websiteName, null));

            // Test
            RestartAzureWebsiteCommand restartAzureWebsiteCommand = new RestartAzureWebsiteCommand()
            {
                CommandRuntime = new MockCommandRuntime(),
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object
            };

            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            restartAzureWebsiteCommand.ExecuteCmdlet();

            websitesClientMock.Verify(f => f.RestartWebsite(websiteName, null), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RestartsWebsiteSlot()
        {
            // Setup
            const string websiteName = "website1";
            const string slot = "staging";

            Mock<IWebsitesClient> websitesClientMock = new Mock<IWebsitesClient>();
            websitesClientMock.Setup(f => f.RestartWebsite(websiteName, slot));

            // Test
            RestartAzureWebsiteCommand restartAzureWebsiteCommand = new RestartAzureWebsiteCommand()
            {
                CommandRuntime = new MockCommandRuntime(),
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object,
                Slot = slot
            };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            restartAzureWebsiteCommand.ExecuteCmdlet();

            websitesClientMock.Verify(f => f.RestartWebsite(websiteName, slot), Times.Once());
        }
    }
}

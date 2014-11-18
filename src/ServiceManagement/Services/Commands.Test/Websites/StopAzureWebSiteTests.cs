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
using Xunit;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Websites;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    
    public class StopAzureWebsiteTests : WebsitesTestBase
    {
        [Fact]
        public void ProcessStopWebsiteTest()
        {
            const string websiteName = "website1";

            // Setup
            Mock<IWebsitesClient> websitesClientMock = new Mock<IWebsitesClient>();
            websitesClientMock.Setup(f => f.StopWebsite(websiteName, null));

            // Test
            StopAzureWebsiteCommand stopAzureWebsiteCommand = new StopAzureWebsiteCommand()
            {
                CommandRuntime = new MockCommandRuntime(),
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object
            };
            AzureSession.SetCurrentContext(new AzureSubscription { Id = new Guid(base.subscriptionId) }, null, null);

            stopAzureWebsiteCommand.ExecuteCmdlet();

            websitesClientMock.Verify(f => f.StopWebsite(websiteName, null), Times.Once());
        }

        [Fact]
        public void StopsWebsiteSlot()
        {
            const string slot = "staging";
            const string websiteName = "website1";

            // Setup
            Mock<IWebsitesClient> websitesClientMock = new Mock<IWebsitesClient>();
            websitesClientMock.Setup(f => f.StopWebsite(websiteName, slot));

            // Test
            StopAzureWebsiteCommand stopAzureWebsiteCommand = new StopAzureWebsiteCommand()
            {
                CommandRuntime = new MockCommandRuntime(),
                Name = websiteName,
                WebsitesClient = websitesClientMock.Object,
                Slot = slot
            };
            AzureSession.SetCurrentContext(new AzureSubscription { Id = new Guid(base.subscriptionId) }, null, null);

            stopAzureWebsiteCommand.ExecuteCmdlet();

            websitesClientMock.Verify(f => f.StopWebsite(websiteName, slot), Times.Once());
        }
    }
}

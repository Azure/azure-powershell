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
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;
using Microsoft.WindowsAzure.Commands.Websites;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    
    public class RemoveAzureWebsiteTests : WebsitesTestBase
    {
        [Fact]
        public void ProcessRemoveWebsiteTest()
        {
            // Setup
            var mockClient = new Mock<IWebsitesClient>();
            string slot = "staging";

            mockClient.Setup(c => c.GetWebsite("website1", slot))
                .Returns(new Site { Name = "website1", WebSpace = "webspace1" });
            mockClient.Setup(c => c.DeleteWebsite("webspace1", "website1", slot)).Verifiable();

            // Test
            RemoveAzureWebsiteCommand removeAzureWebsiteCommand = new RemoveAzureWebsiteCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                WebsitesClient = mockClient.Object,
                Name = "website1",
                Slot = slot
            };
            AzureSession.SetCurrentContext(new AzureSubscription { Id = new Guid(base.subscriptionId) }, null, null);

            // Delete existing website
            removeAzureWebsiteCommand.ExecuteCmdlet();
            mockClient.Verify(c => c.DeleteWebsite("webspace1", "website1", slot), Times.Once());
        }
    }
}
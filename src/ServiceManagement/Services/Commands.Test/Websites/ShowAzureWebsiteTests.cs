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
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;
using Microsoft.WindowsAzure.Commands.Websites;
using Moq;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    
    public class ShowAzureWebsiteTests : WebsitesTestBase
    {
        [Fact(Skip = "Consider removing these.")]
        public void ProcessShowWebsiteTest()
        {
            // Setup
            var mockClient = new Mock<IWebsitesClient>();
            mockClient.Setup(c => c.GetWebsite("website1", null))
                .Returns(new Site
                {
                    Name = "website1",
                    WebSpace = "webspace1",
                    HostNames = new[] {"website1.cloudapp.com"}
                });

            // Test
            ShowAzureWebsiteCommand showAzureWebsiteCommand = new ShowAzureWebsiteCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                Name = "website1",
                WebsitesClient = mockClient.Object
            };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            // Show existing website
            showAzureWebsiteCommand.ExecuteCmdlet();
        }
    }
}
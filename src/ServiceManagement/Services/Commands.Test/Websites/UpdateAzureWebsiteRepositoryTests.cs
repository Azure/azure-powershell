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
    
    public class UpdateAzureWebsiteRepositoryTests : WebsitesTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdatesRemote()
        {
            // Setup
            var mockClient = new Mock<IWebsitesClient>();
            string slot = WebsiteSlotName.Staging.ToString();
            SiteProperties props = new SiteProperties()
            {
                Properties = new List<NameValuePair>()
                {
                    new NameValuePair() { Name = "RepositoryUri", Value = "https://test@website.scm.azurewebsites.net:443/website.git" },
                    new NameValuePair() { Name = "PublishingUsername", Value = "test" }
                }
            };

            mockClient.Setup(c => c.GetWebsiteSlots("website1"))
                .Returns(
                new List<Site> { 
                    new Site { Name = "website1", WebSpace = "webspace1", SiteProperties = props },
                    new Site { Name = "website1(staging)", WebSpace = "webspace1", SiteProperties = props }
                });
            mockClient.Setup(c => c.GetSlotName("website1"))
                .Returns(WebsiteSlotName.Production.ToString())
                .Verifiable();
            mockClient.Setup(c => c.GetSlotName("website1(staging)"))
                .Returns(WebsiteSlotName.Staging.ToString())
                .Verifiable();

            // Test
            UpdateAzureWebsiteRepositoryCommand cmdlet = new UpdateAzureWebsiteRepositoryCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                WebsitesClient = mockClient.Object,
                Name = "website1",
            };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            // Switch existing website
            cmdlet.ExecuteCmdlet();
            mockClient.Verify(c => c.GetSlotName("website1(staging)"), Times.Once());
            mockClient.Verify(c => c.GetSlotName("website1"), Times.Once());
        }
    }
}
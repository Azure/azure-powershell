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
    
    public class SwitchAzureWebsiteSlotTests : WebsitesTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SwitchesSlots()
        {
            // Setup
            var mockClient = new Mock<IWebsitesClient>();
            string slot1 = WebsiteSlotName.Production.ToString();
            string slot2 = "staging";

            mockClient.Setup(c => c.GetWebsiteSlots("website1"))
                .Returns(new List<Site> { 
                    new Site { Name = "website1", WebSpace = "webspace1" },
                    new Site { Name = "website1(staging)", WebSpace = "webspace1" }
                });
            mockClient.Setup(f => f.GetSlotName("website1")).Returns(slot1);
            mockClient.Setup(f => f.GetSlotName("website1(staging)")).Returns(slot2);
            mockClient.Setup(f => f.SwitchSlots("webspace1", "website1(staging)", slot1, slot2)).Verifiable();
            mockClient.Setup(f => f.GetWebsiteNameFromFullName("website1")).Returns("website1");

            // Test
            SwitchAzureWebsiteSlotCommand switchAzureWebsiteCommand = new SwitchAzureWebsiteSlotCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                WebsitesClient = mockClient.Object,
                Name = "website1",
                Force = true
            };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription { Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            // Switch existing website
            switchAzureWebsiteCommand.ExecuteCmdlet();
            mockClient.Verify(c => c.SwitchSlots("webspace1", "website1", slot1, slot2), Times.Once());
        }
    }
}
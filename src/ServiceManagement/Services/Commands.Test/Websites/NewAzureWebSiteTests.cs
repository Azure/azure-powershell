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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;
using Microsoft.WindowsAzure.Commands.Websites;
using Microsoft.WindowsAzure.Management.WebSites.Models;
using Moq;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{

    public class NewAzureWebsiteTests : WebsitesTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProcessNewWebsiteTest()
        {
            const string websiteName = "website1";
            const string webspaceName = "webspace1";
            const string suffix = "azurewebsites.com";

            // Setup
            Mock<IWebsitesClient> clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.GetWebsiteDnsSuffix()).Returns(suffix);
            clientMock.Setup(f => f.GetWebsite(websiteName)).Returns(new Site() { Name = websiteName });
            clientMock.Setup(f => f.GetWebsiteConfiguration(websiteName, null)).Returns(new SiteConfig() { PublishingUsername = "user1" });
            clientMock.Setup(c => c.ListWebSpaces())
                .Returns(new[]
                {
                    new WebSpace {Name = "webspace1", GeoRegion = "webspace1"},
                    new WebSpace {Name = "webspace2", GeoRegion = "webspace2"}
                });

            clientMock.Setup(c => c.GetWebsiteConfiguration("website1"))
                .Returns(new SiteConfig { PublishingUsername = "user1" });

            string createdSiteName = null;
            string createdWebspaceName = null;

            clientMock.Setup(c => c.CreateWebsite(webspaceName, It.IsAny<SiteWithWebSpace>(), null))
                .Returns((string space, SiteWithWebSpace site, string slot) => site)
                .Callback((string space, SiteWithWebSpace site, string slot) =>
                {
                    createdSiteName = site.Name;
                    createdWebspaceName = space;
                });

            SetupProfile(null);
            // Test
            MockCommandRuntime mockRuntime = new MockCommandRuntime();
            NewAzureWebsiteCommand newAzureWebsiteCommand = new NewAzureWebsiteCommand
            {
                ShareChannel = true,
                CommandRuntime = mockRuntime,
                Name = websiteName,
                Location = webspaceName,
                WebsitesClient = clientMock.Object
            };

            newAzureWebsiteCommand.ExecuteWithProcessing();
            Assert.Equal(websiteName, createdSiteName);
            Assert.Equal(webspaceName, createdWebspaceName);
            Assert.Equal<string>(websiteName, (mockRuntime.OutputPipeline[0] as SiteWithConfig).Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsWebsiteDefaultLocation()
        {
            const string websiteName = "website1";
            const string suffix = "azurewebsites.com";
            const string location = "West US";

            bool created = false;

            // Setup
            Mock<IWebsitesClient> clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.GetWebsiteDnsSuffix()).Returns(suffix);
            clientMock.Setup(c => c.GetDefaultLocation()).Returns(location);

            clientMock.Setup(c => c.ListWebSpaces()).Returns(new WebSpaces());
            clientMock.Setup(c => c.GetWebsite(websiteName)).Returns(new Site() { Name = websiteName });
            clientMock.Setup(c => c.GetWebsiteConfiguration(websiteName, null))
                .Returns(new SiteConfig
                {
                    PublishingUsername = "user1"
                });

            clientMock.Setup(c => c.CreateWebsite(It.IsAny<string>(), It.IsAny<SiteWithWebSpace>(), null))
                .Returns((string space, SiteWithWebSpace site, string slot) => site)
                .Callback((string space, SiteWithWebSpace site, string slot) =>
                {
                    created = true;
                });

            SetupProfile(null);

            // Test
            MockCommandRuntime mockRuntime = new MockCommandRuntime();
            NewAzureWebsiteCommand newAzureWebsiteCommand = new NewAzureWebsiteCommand()
            {
                ShareChannel = true,
                CommandRuntime = mockRuntime,
                Name = websiteName,
                WebsitesClient = clientMock.Object
            };

            newAzureWebsiteCommand.ExecuteWithProcessing();
            Assert.True(created);
            Assert.Equal<string>(websiteName, (mockRuntime.OutputPipeline[0] as SiteWithConfig).Name);
            clientMock.Verify(f => f.GetDefaultLocation(), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateStageSlot()
        {
            string slot = "staging";
            const string websiteName = "website1";
            const string webspaceName = "webspace1";
            const string suffix = "azurewebsites.com";

            // Setup
            Mock<IWebsitesClient> clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.GetWebsiteDnsSuffix()).Returns(suffix);
            clientMock.Setup(c => c.ListWebSpaces())
                .Returns(new[]
                {
                    new WebSpace {Name = "webspace1", GeoRegion = "webspace1"},
                    new WebSpace {Name = "webspace2", GeoRegion = "webspace2"}
                });

            clientMock.Setup(c => c.GetWebsiteConfiguration("website1", slot))
                .Returns(new SiteConfig { PublishingUsername = "user1" });


            clientMock.Setup(f => f.WebsiteExists(websiteName)).Returns(true);
            clientMock.Setup(f => f.GetWebsite(websiteName)).Returns(new Site() { Name = websiteName, Sku = SkuOptions.Standard, WebSpace = webspaceName });

            SetupProfile(null);
            // Test
            MockCommandRuntime mockRuntime = new MockCommandRuntime();
            NewAzureWebsiteCommand newAzureWebsiteCommand = new NewAzureWebsiteCommand
            {
                ShareChannel = true,
                CommandRuntime = mockRuntime,
                Name = websiteName,
                Location = webspaceName,
                WebsitesClient = clientMock.Object,
                Slot = slot
            };

            newAzureWebsiteCommand.ExecuteWithProcessing();
            clientMock.Verify(c => c.CreateWebsite(webspaceName, It.IsAny<SiteWithWebSpace>(), slot), Times.Once());
        }
    }
}

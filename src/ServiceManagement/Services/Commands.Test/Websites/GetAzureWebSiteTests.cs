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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;
using Microsoft.WindowsAzure.Commands.Websites;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    public static class WebsiteCmdletTestsExtensions
    {
        public static void ExecuteWithProcessing(this AzureSMCmdlet cmdlt)
        {
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

        }
    }
       
    public class GetAzureWebsiteTests : WebsitesTestBase
    {

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProcessGetWebsiteTest()
        {
            // Setup
            var clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.ListWebSpaces())
                .Returns(new[] {new WebSpace {Name = "webspace1"}, new WebSpace {Name = "webspace2"}});

            clientMock.Setup(c => c.ListSitesInWebSpace("webspace1"))
                .Returns(new[] {new Site {Name = "website1", WebSpace = "webspace1"}});

            clientMock.Setup(c => c.ListSitesInWebSpace("webspace2"))
                .Returns(new[] {new Site {Name = "website2", WebSpace = "webspace2"}});
            clientMock.Setup(c => c.ListWebsites())
                .Returns(new List<Site> { new Site { Name = "website1", WebSpace = "webspace1" },
                new Site { Name = "website2", WebSpace = "webspace2" }});

            SetupProfile(null);
            // Test
            var getAzureWebsiteCommand = new GetAzureWebsiteCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                WebsitesClient = clientMock.Object
            };

            getAzureWebsiteCommand.ExecuteWithProcessing();

            var sites = System.Management.Automation.LanguagePrimitives.GetEnumerable(((MockCommandRuntime)getAzureWebsiteCommand.CommandRuntime).OutputPipeline).Cast<Site>();

            Assert.NotNull(sites);
            Assert.NotEmpty(sites);
            Assert.True(sites.Any(website => (website).Name.Equals("website1") && (website).WebSpace.Equals("webspace1")));
            Assert.True(sites.Any(website => (website).Name.Equals("website2") && (website).WebSpace.Equals("webspace2")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetWebsiteProcessShowTest()
        {
            // Setup
            var clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.GetWebsiteSlots(It.IsAny<string>()))
                .Returns(new Sites() { new Site
                {
                    Name = "website1",
                    WebSpace = "webspace1"
                }});

            clientMock.Setup(c => c.GetWebsiteConfiguration(It.IsAny<string>()))
                .Returns(new SiteConfig
                {
                    PublishingUsername = "user1"
                }
                );
            clientMock.Setup(c => c.GetWebsiteConfiguration(It.IsAny<string>(), null))
                .Returns(new SiteConfig {
                    PublishingUsername = "user1"}
                );

            SetupProfile(null);

            // Test
            var getAzureWebsiteCommand = new GetAzureWebsiteCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                Name = "website1",
                WebsitesClient = clientMock.Object
            };

            getAzureWebsiteCommand.ExecuteWithProcessing();
            Assert.Equal(1, ((MockCommandRuntime)getAzureWebsiteCommand.CommandRuntime).OutputPipeline.Count);

            SiteWithConfig website = ((MockCommandRuntime)getAzureWebsiteCommand.CommandRuntime).OutputPipeline[0] as SiteWithConfig;
            Assert.NotNull(website);
            Assert.NotNull(website);
            Assert.Equal("website1", website.Name);
            Assert.Equal("webspace1", website.WebSpace);

            SetupProfile(null);

            // Run with mixed casing
            getAzureWebsiteCommand = new GetAzureWebsiteCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                Name = "WEBSiTe1",
                WebsitesClient = clientMock.Object
            };

            getAzureWebsiteCommand.ExecuteWithProcessing();
            Assert.Equal(1, ((MockCommandRuntime)getAzureWebsiteCommand.CommandRuntime).OutputPipeline.Count);

            website = ((MockCommandRuntime)getAzureWebsiteCommand.CommandRuntime).OutputPipeline[0] as SiteWithConfig;
            Assert.NotNull(website);
            Assert.NotNull(website);
            Assert.Equal("website1", website.Name);
            Assert.Equal("webspace1", website.WebSpace);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProcessGetWebsiteWithNullSubscription()
        {
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            currentProfile.Subscriptions.Clear();
            currentProfile.Save();
            AzureSMCmdlet.CurrentProfile = currentProfile;

            // Test
            var getAzureWebsiteCommand = new GetAzureWebsiteCommand
            {
                CommandRuntime = new MockCommandRuntime()
            };

            Testing.AssertThrows<Exception>(getAzureWebsiteCommand.ExecuteWithProcessing, Resources.InvalidDefaultSubscription);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureWebsiteWithDiagnosticsSettings()
        {
            // Setup
            string slot = "production";
            var websitesClientMock = new Mock<IWebsitesClient>();
            websitesClientMock.Setup(c => c.GetWebsite(It.IsAny<string>(), slot))
                .Returns(new Site
                {
                    Name = "website1", WebSpace = "webspace1", State = "Running"
                });

            websitesClientMock.Setup(c => c.GetWebsiteConfiguration(It.IsAny<string>()))
                .Returns(new SiteConfig { PublishingUsername = "user1" });
            websitesClientMock.Setup(c => c.GetWebsiteConfiguration(It.IsAny<string>(), slot))
                .Returns(new SiteConfig {PublishingUsername = "user1"});

            SetupProfile(null);

            var getAzureWebsiteCommand = new GetAzureWebsiteCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                Name = "website1",
                WebsitesClient = websitesClientMock.Object,
                Slot = slot
            };

            // Test
            getAzureWebsiteCommand.ExecuteWithProcessing();

            // Assert
            Assert.Equal(1, ((MockCommandRuntime)getAzureWebsiteCommand.CommandRuntime).OutputPipeline.Count);
            websitesClientMock.Verify(f => f.GetApplicationDiagnosticsSettings("website1"), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsWebsiteSlot()
        {
            // Setup
            string slot = "staging";
            var clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.GetWebsite(It.IsAny<string>(), slot))
                .Returns(new Site
                {
                    Name = "website1(stage)",
                    WebSpace = "webspace1"
                });

            clientMock.Setup(c => c.GetWebsiteConfiguration(It.IsAny<string>()))
                .Returns(new SiteConfig
                {
                    PublishingUsername = "user1"
                });
            clientMock.Setup(c => c.GetWebsiteConfiguration(It.IsAny<string>(), slot))
                .Returns(new SiteConfig
                {
                    PublishingUsername = "user1"
                });

            SetupProfile(null);
            // Test
            var getAzureWebsiteCommand = new GetAzureWebsiteCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                Name = "website1",
                WebsitesClient = clientMock.Object,
                Slot = slot
            };

            getAzureWebsiteCommand.ExecuteWithProcessing();
            Assert.Equal(1, ((MockCommandRuntime)getAzureWebsiteCommand.CommandRuntime).OutputPipeline.Count);

            var website = ((MockCommandRuntime)getAzureWebsiteCommand.CommandRuntime).OutputPipeline[0] as SiteWithConfig;
            Assert.NotNull(website);
            Assert.Equal("website1(stage)", website.Name);
            Assert.Equal("webspace1", website.WebSpace);
            Assert.Equal("user1", website.PublishingUsername);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsSlots()
        {
            // Setup
            string slot = "staging";
            var clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.ListWebsites(slot))
                .Returns(new List<Site> {new Site
                {
                    Name = "website1(stage)",
                    WebSpace = "webspace1"
                }, new Site
                {
                    Name = "website2(stage)",
                    WebSpace = "webspace1"
                }});

            clientMock.Setup(c => c.GetWebsiteConfiguration(It.IsAny<string>(), slot))
                .Returns(new SiteConfig
                {
                    PublishingUsername = "user1"
                });

            SetupProfile(null);

            // Test
            var getAzureWebsiteCommand = new GetAzureWebsiteCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                WebsitesClient = clientMock.Object,
                Slot = slot
            };

            getAzureWebsiteCommand.ExecuteWithProcessing();

            IEnumerable<Site> sites = System.Management.Automation.LanguagePrimitives.GetEnumerable(((MockCommandRuntime)getAzureWebsiteCommand.CommandRuntime).OutputPipeline).Cast<Site>();

            Assert.NotNull(sites);
            Assert.NotEmpty(sites);
            Assert.Equal(2, sites.Count());
            var website1 = sites.ElementAt(0);
            var website2 = sites.ElementAt(1);
            Assert.NotNull(website1);
            Assert.NotNull(website2);
            Assert.Equal("website1(stage)", website1.Name);
            Assert.Equal("website2(stage)", website2.Name);
        }
    }
}

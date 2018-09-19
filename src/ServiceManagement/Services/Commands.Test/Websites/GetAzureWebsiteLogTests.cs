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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;
using Microsoft.WindowsAzure.Commands.Websites;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    
    public class GetAzureWebsiteLogTests : WebsitesTestBase
    {

        private Mock<ICommandRuntime> commandRuntimeMock;

        private Mock<IWebsitesClient> websitesClientMock;

        private GetAzureWebsiteLogCommand getAzureWebsiteLogCmdlet;

        private string websiteName = "TestWebsiteName";

        private string repoUrl = "TheRepoUrl";

        private string slot = "staging";

        private List<string> logs;

        private Site website;

        Predicate<string> stopCondition;

        public GetAzureWebsiteLogTests()
        {
            base.SetupTest();
            websitesClientMock = new Mock<IWebsitesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            stopCondition = (string line) => line != null;
            websitesClientMock.Setup(f => f.StartLogStreaming(
                websiteName,
                slot,
                string.Empty,
                string.Empty,
                stopCondition,
                It.IsAny<int>()))
                .Returns(logs);
            logs = new List<string>() { "Log1", "Error: Log2", "Log3", "Error: Log4", null };
            getAzureWebsiteLogCmdlet = new GetAzureWebsiteLogCommand(null)
            {
                CommandRuntime = commandRuntimeMock.Object,
                WebsitesClient = websitesClientMock.Object,
                StopCondition = stopCondition,
                Name = websiteName,
                ShareChannel = true,
                Slot = slot
            };
            website = new Site()
            {
                Name = websiteName,
                WebSpace = "webspaceName",
                SiteProperties = new SiteProperties()
                {
                    Properties = new List<NameValuePair>()
                    {
                        new NameValuePair() { Name = UriElements.RepositoryUriProperty, Value = repoUrl }
                    }
                }
            };
            Cache.AddSite(currentProfile.Context.Subscription.Id.ToString(), website);
            websitesClientMock.Setup(c => c.GetWebsite(websiteName, slot))
                .Returns(website);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureWebsiteLogTest()
        {
            getAzureWebsiteLogCmdlet.Tail = true;

            getAzureWebsiteLogCmdlet.ExecuteCmdlet();

            websitesClientMock.Verify(f => f.StartLogStreaming(
                websiteName,
                slot,
                null,
                null,
                stopCondition,
                It.IsAny<int>()),
                Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGetAzureWebsiteLogWithPath()
        {
            getAzureWebsiteLogCmdlet.Tail = true;
            getAzureWebsiteLogCmdlet.Path = "http";

            getAzureWebsiteLogCmdlet.ExecuteCmdlet();

            websitesClientMock.Verify(f => f.StartLogStreaming(
                websiteName,
                slot,
                "http",
                null,
                stopCondition,
                It.IsAny<int>()),
                Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureWebsiteLogListPath()
        {
            List<LogPath> paths = new List<LogPath>() { 
                new LogPath() { Name = "http" }, new LogPath() { Name = "Git" }
            };
            List<string> expected = new List<string>() { "http", "Git" };
            List<string> actual = new List<string>();
            websitesClientMock.Setup(f => f.ListLogPaths(websiteName, slot)).Returns(paths);
            commandRuntimeMock.Setup(f => f.WriteObject(It.IsAny<IEnumerable<string>>(), true))
                .Callback<object, bool>((o, b) => actual = actual = ((IEnumerable<string>)o).ToList<string>());
            getAzureWebsiteLogCmdlet.ListPath = true;

            getAzureWebsiteLogCmdlet.ExecuteCmdlet();

            Assert.Equal(expected, actual);
        }
    }
}

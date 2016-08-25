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
using System.IO;
using System.Text;
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
using Moq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.Common.Test;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{

    public class SaveAzureWebsiteLogTests : WebsitesTestBase
    {
        private Site site1 = new Site
        {
            Name = "website1",
            WebSpace = "webspace1",
            SiteProperties = new SiteProperties
            {
                Properties = new List<NameValuePair>
                {
                    new NameValuePair {Name = "repositoryuri", Value = "http"},
                    new NameValuePair {Name = "PublishingUsername", Value = "user1"},
                    new NameValuePair {Name = "PublishingPassword", Value = "password1"}
                }
            }
        };

        private string slot = "staging";

        private List<WebSpace> spaces = new List<WebSpace>
        {
            new WebSpace {Name = "webspace1"},
            new WebSpace {Name = "webspace2"}
        };

        private Mock<IWebsitesClient> clientMock;

        public SaveAzureWebsiteLogTests()
        {
            clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.GetWebsite("website1", null))
                .Returns(site1);
            clientMock.Setup(c => c.GetWebsite("website1", slot))
                .Returns(site1);
            clientMock.Setup(c => c.ListWebSpaces())
                .Returns(spaces);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureWebsiteLogTest()
        {
            // Setup
            SimpleDeploymentServiceManagement deploymentChannel = new SimpleDeploymentServiceManagement
            {
                DownloadLogsThunk = ar => new MemoryStream(Encoding.UTF8.GetBytes("test"))
            };

            // Test
            SaveAzureWebsiteLogCommand getAzureWebsiteLogCommand = new SaveAzureWebsiteLogCommand(deploymentChannel)
            {
                Name = "website1",
                ShareChannel = true,
                WebsitesClient = clientMock.Object,
                CommandRuntime = new MockCommandRuntime(),
            };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription { Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            getAzureWebsiteLogCommand.DefaultCurrentPath = AppDomain.CurrentDomain.BaseDirectory;
            getAzureWebsiteLogCommand.ExecuteCmdlet();
            Assert.Equal("test", FileUtilities.DataStore.ReadFileAsText(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SaveAzureWebsiteLogCommand.DefaultOutput)));
        }

        [Fact (Skip="TODO: Investigate issue #2729. Test disabled temporarily.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureWebsiteLogWithNoFileExtensionTest()
        {
            TestExecutionHelpers.RetryAction(
               () =>
               {
                   // Setup
                   string expectedOutput = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file_without_ext.zip");

                   SimpleDeploymentServiceManagement deploymentChannel = new SimpleDeploymentServiceManagement
                   {
                       DownloadLogsThunk = ar => new MemoryStream(Encoding.UTF8.GetBytes("test with no extension"))
                   };

                   // Test
                   SaveAzureWebsiteLogCommand getAzureWebsiteLogCommand = new SaveAzureWebsiteLogCommand(deploymentChannel)
                   {
                       Name = "website1",
                       ShareChannel = true,
                       WebsitesClient = clientMock.Object,
                       CommandRuntime = new MockCommandRuntime(),
                       Output = "file_without_ext"
                   };
                   currentProfile = new AzureSMProfile();
                   var subscription = new AzureSubscription { Id = new Guid(base.subscriptionId) };
                   subscription.Properties[AzureSubscription.Property.Default] = "True";
                   currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

                   getAzureWebsiteLogCommand.DefaultCurrentPath = AppDomain.CurrentDomain.BaseDirectory;
                   getAzureWebsiteLogCommand.ExecuteCmdlet();
                   Assert.Equal("test with no extension", FileUtilities.DataStore.ReadFileAsText(expectedOutput));
               });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureWebsiteLogWithSlotTest()
        {
            TestExecutionHelpers.RetryAction(
               () =>
               {
                   // Setup
                   SimpleDeploymentServiceManagement deploymentChannel = new SimpleDeploymentServiceManagement
                   {
                       DownloadLogsThunk = ar => new MemoryStream(Encoding.UTF8.GetBytes("test"))
                   };

                   // Test
                   SaveAzureWebsiteLogCommand getAzureWebsiteLogCommand = new SaveAzureWebsiteLogCommand(deploymentChannel)
                   {
                       Name = "website1",
                       ShareChannel = true,
                       WebsitesClient = clientMock.Object,
                       CommandRuntime = new MockCommandRuntime(),
                       Slot = slot
                   };
                   currentProfile = new AzureSMProfile();
                   var subscription = new AzureSubscription { Id = new Guid(base.subscriptionId) };
                   subscription.Properties[AzureSubscription.Property.Default] = "True";
                   currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

                   getAzureWebsiteLogCommand.DefaultCurrentPath = AppDomain.CurrentDomain.BaseDirectory;
                   getAzureWebsiteLogCommand.ExecuteCmdlet();
                   Assert.Equal("test", FileUtilities.DataStore.ReadFileAsText(
                       Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SaveAzureWebsiteLogCommand.DefaultOutput)));
               });
        }
    }
}

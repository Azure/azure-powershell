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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;
using Microsoft.WindowsAzure.Commands.Websites;
using Moq;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    
    public class GetAzureWebsiteDeploymentTests : WebsitesTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureWebsiteDeploymentTest()
        {
            // Setup
            var clientMock = new Mock<IWebsitesClient>();
            var site1 = new Site
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

            clientMock.Setup(c => c.GetWebsite("website1", null))
                .Returns(site1);

            clientMock.Setup(c => c.ListWebSpaces())
                .Returns(new[] { new WebSpace { Name = "webspace1" }, new WebSpace { Name = "webspace2" } });
            clientMock.Setup(c => c.ListSitesInWebSpace("webspace1"))
                .Returns(new[] { site1 });

            clientMock.Setup(c => c.ListSitesInWebSpace("webspace2"))
                .Returns(new[] { new Site { Name = "website2", WebSpace = "webspace2" } });

            SimpleDeploymentServiceManagement deploymentChannel = new SimpleDeploymentServiceManagement();
            deploymentChannel.GetDeploymentsThunk = ar => new List<DeployResult> { new DeployResult(), new DeployResult() };

            // Test
            GetAzureWebsiteDeploymentCommand getAzureWebsiteDeploymentCommand = new GetAzureWebsiteDeploymentCommand(deploymentChannel)
            {
                Name = "website1",
                ShareChannel = true,
                WebsitesClient = clientMock.Object,
                CommandRuntime = new MockCommandRuntime(),
            };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(subscriptionId)] = subscription;


            getAzureWebsiteDeploymentCommand.ExecuteCmdlet();

            var deployments = System.Management.Automation.LanguagePrimitives.GetEnumerable(((MockCommandRuntime)getAzureWebsiteDeploymentCommand.CommandRuntime).OutputPipeline).Cast<DeployResult>();

            Assert.NotNull(deployments);
            Assert.Equal(2, deployments.Count());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureWebsiteDeploymentLogsTest()
        {
            // Setup
            var clientMock = new Mock<IWebsitesClient>();
            var site1 = new Site
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

            clientMock.Setup(c => c.ListWebSpaces())
                .Returns(new[] {new WebSpace {Name = "webspace1"}, new WebSpace {Name = "webspace2"}});
            clientMock.Setup(c => c.GetWebsite("website1", null)).Returns(site1);

            SimpleDeploymentServiceManagement deploymentChannel = new SimpleDeploymentServiceManagement();
            deploymentChannel.GetDeploymentsThunk = ar => new List<DeployResult> { new DeployResult { Id = "commit1" }, new DeployResult { Id = "commit2" } };
            deploymentChannel.GetDeploymentLogsThunk = ar =>
            {
                if (ar.Values["commitId"].Equals("commit1"))
                {
                    return new List<LogEntry> { new LogEntry { Id = "log1" }, new LogEntry { Id = "log2" } };
                }

                return new List<LogEntry>();
            };

            // Test
            GetAzureWebsiteDeploymentCommand getAzureWebsiteDeploymentCommand = new GetAzureWebsiteDeploymentCommand(deploymentChannel)
            {
                Name = "website1",
                ShareChannel = true,
                WebsitesClient = clientMock.Object,
                Details = true,
                CommandRuntime = new MockCommandRuntime(),
            };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(subscriptionId)] = subscription;

            getAzureWebsiteDeploymentCommand.ExecuteCmdlet();

            var deployments = System.Management.Automation.LanguagePrimitives.GetEnumerable(((MockCommandRuntime)getAzureWebsiteDeploymentCommand.CommandRuntime).OutputPipeline).Cast<DeployResult>();

            Assert.NotNull(deployments);
            Assert.Equal(2, deployments.Count());
            Assert.NotNull(deployments.First(d => d.Id.Equals("commit1")).Logs);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsDeploymentForSlot()
        {
            string slot = "staging";
            // Setup
            var clientMock = new Mock<IWebsitesClient>();
            var site1 = new Site
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

            clientMock.Setup(c => c.GetWebsite("website1", slot))
                .Returns(site1);

            clientMock.Setup(c => c.ListWebSpaces())
                .Returns(new[] { new WebSpace { Name = "webspace1" }, new WebSpace { Name = "webspace2" } });
            clientMock.Setup(c => c.ListSitesInWebSpace("webspace1"))
                .Returns(new[] { site1 });

            clientMock.Setup(c => c.ListSitesInWebSpace("webspace2"))
                .Returns(new[] { new Site { Name = "website2", WebSpace = "webspace2" } });

            SimpleDeploymentServiceManagement deploymentChannel = new SimpleDeploymentServiceManagement();
            deploymentChannel.GetDeploymentsThunk = ar => new List<DeployResult> { new DeployResult(), new DeployResult() };

            // Test
            GetAzureWebsiteDeploymentCommand getAzureWebsiteDeploymentCommand = new GetAzureWebsiteDeploymentCommand(deploymentChannel)
            {
                Name = "website1",
                ShareChannel = true,
                WebsitesClient = clientMock.Object,
                CommandRuntime = new MockCommandRuntime(),
                Slot = slot
            };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(subscriptionId)] = subscription;

            getAzureWebsiteDeploymentCommand.ExecuteCmdlet();

            var deployments = System.Management.Automation.LanguagePrimitives.GetEnumerable(((MockCommandRuntime)getAzureWebsiteDeploymentCommand.CommandRuntime).OutputPipeline).Cast<DeployResult>();
            Assert.NotNull(deployments);
            Assert.Equal(2, deployments.Count());
        }
    }
}

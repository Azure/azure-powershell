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
    
    public class RestoreAzureWebsiteDeploymentTests : WebsitesTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RestoreAzureWebsiteDeploymentTest()
        {
            // Setup
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

            var clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.ListWebSpaces())
                .Returns(new[] {new WebSpace {Name = "webspace1"}, new WebSpace {Name = "webspace2"}});
            clientMock.Setup(c => c.GetWebsite("website1", null))
                .Returns(site1);

            SimpleDeploymentServiceManagement deploymentChannel = new SimpleDeploymentServiceManagement();

            var deployments = new List<DeployResult> { new DeployResult { Id = "id1", Current = false }, new DeployResult { Id = "id2", Current = true } };
            deploymentChannel.GetDeploymentsThunk = ar => deployments;
            deploymentChannel.DeployThunk = ar =>
            {
                // Keep track of currently deployed id
                DeployResult newDeployment = deployments.FirstOrDefault(d => d.Id.Equals(ar.Values["commitId"]));
                if (newDeployment != null)
                {
                    // Make all inactive
                    deployments.ForEach(d => d.Complete = false);
                    
                    // Set new to active
                    newDeployment.Complete = true;
                }
            };

            // Test
            RestoreAzureWebsiteDeploymentCommand restoreAzureWebsiteDeploymentCommand =
                new RestoreAzureWebsiteDeploymentCommand(deploymentChannel)
            {
                Name = "website1",
                CommitId = "id2",
                ShareChannel = true,
                WebsitesClient = clientMock.Object,
                CommandRuntime = new MockCommandRuntime(),
            };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            restoreAzureWebsiteDeploymentCommand.ExecuteCmdlet();

            var responseDeployments = System.Management.Automation.LanguagePrimitives.GetEnumerable(((MockCommandRuntime) restoreAzureWebsiteDeploymentCommand.CommandRuntime).OutputPipeline).Cast<DeployResult>();

            Assert.NotNull(responseDeployments);
            Assert.Equal(2, responseDeployments.Count());
            Assert.True(responseDeployments.Any(d => d.Id.Equals("id2") && d.Complete));
            Assert.True(responseDeployments.Any(d => d.Id.Equals("id1") && !d.Complete));

            // Change active deployment to id1
            restoreAzureWebsiteDeploymentCommand = new RestoreAzureWebsiteDeploymentCommand(deploymentChannel)
            {
                Name = "website1",
                CommitId = "id1",
                ShareChannel = true,
                WebsitesClient = clientMock.Object,
                CommandRuntime = new MockCommandRuntime(),
            };
            currentProfile = new AzureSMProfile();
            subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            restoreAzureWebsiteDeploymentCommand.ExecuteCmdlet();

            responseDeployments = System.Management.Automation.LanguagePrimitives.GetEnumerable(((MockCommandRuntime)restoreAzureWebsiteDeploymentCommand.CommandRuntime).OutputPipeline).Cast<DeployResult>();
            Assert.NotNull(responseDeployments);
            Assert.Equal(2, responseDeployments.Count());
            Assert.True(responseDeployments.Any(d => d.Id.Equals("id1") && d.Complete));
            Assert.True(responseDeployments.Any(d => d.Id.Equals("id2") && !d.Complete));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RestoresDeploymentForSlot()
        {
            string slot = "staging";
            // Setup
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

            var clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.ListWebSpaces())
                .Returns(new[] { new WebSpace { Name = "webspace1" }, new WebSpace { Name = "webspace2" } });
            clientMock.Setup(c => c.GetWebsite("website1", slot))
                .Returns(site1);

            SimpleDeploymentServiceManagement deploymentChannel = new SimpleDeploymentServiceManagement();

            var deployments = new List<DeployResult> { new DeployResult { Id = "id1", Current = false }, new DeployResult { Id = "id2", Current = true } };
            deploymentChannel.GetDeploymentsThunk = ar => deployments;
            deploymentChannel.DeployThunk = ar =>
            {
                // Keep track of currently deployed id
                DeployResult newDeployment = deployments.FirstOrDefault(d => d.Id.Equals(ar.Values["commitId"]));
                if (newDeployment != null)
                {
                    // Make all inactive
                    deployments.ForEach(d => d.Complete = false);

                    // Set new to active
                    newDeployment.Complete = true;
                }
            };

            // Test
            RestoreAzureWebsiteDeploymentCommand restoreAzureWebsiteDeploymentCommand =
                new RestoreAzureWebsiteDeploymentCommand(deploymentChannel)
                {
                    Name = "website1",
                    CommitId = "id2",
                    ShareChannel = true,
                    WebsitesClient = clientMock.Object,
                    CommandRuntime = new MockCommandRuntime(),
                    Slot = slot
                };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;


            restoreAzureWebsiteDeploymentCommand.ExecuteCmdlet();

            var responseDeployments = System.Management.Automation.LanguagePrimitives.GetEnumerable(((MockCommandRuntime)restoreAzureWebsiteDeploymentCommand.CommandRuntime).OutputPipeline).Cast<DeployResult>();

            Assert.NotNull(responseDeployments);
            Assert.Equal(2, responseDeployments.Count());
            Assert.True(responseDeployments.Any(d => d.Id.Equals("id2") && d.Complete));
            Assert.True(responseDeployments.Any(d => d.Id.Equals("id1") && !d.Complete));

            // Change active deployment to id1
            restoreAzureWebsiteDeploymentCommand = new RestoreAzureWebsiteDeploymentCommand(deploymentChannel)
            {
                Name = "website1",
                CommitId = "id1",
                ShareChannel = true,
                WebsitesClient = clientMock.Object,
                CommandRuntime = new MockCommandRuntime(),
                Slot = slot
            };
            currentProfile = new AzureSMProfile();
            subscription = new AzureSubscription{Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            restoreAzureWebsiteDeploymentCommand.ExecuteCmdlet();

            responseDeployments = System.Management.Automation.LanguagePrimitives.GetEnumerable(((MockCommandRuntime)restoreAzureWebsiteDeploymentCommand.CommandRuntime).OutputPipeline).Cast<DeployResult>();

            Assert.NotNull(responseDeployments);
            Assert.Equal(2, responseDeployments.Count());
            Assert.True(responseDeployments.Any(d => d.Id.Equals("id1") && d.Complete));
            Assert.True(responseDeployments.Any(d => d.Id.Equals("id2") && !d.Complete));
        }
    }
}

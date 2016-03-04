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
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;
using Microsoft.WindowsAzure.Commands.Websites.WebHostingPlan;
using Moq;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.Websites.WebHostingPlans
{
    
    public class GetAzureWebHostingPlanTests : WebsitesTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListWebHostingPlansTest()
        {
            // Setup
            var clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.ListWebSpaces())
                .Returns(new[] {new WebSpace {Name = "webspace1"}, new WebSpace {Name = "webspace2"}});

            clientMock.Setup(c => c.ListWebHostingPlans())
                .Returns(new List<WebHostingPlan>
                {
                    new WebHostingPlan {Name = "Plan1", WebSpace = "webspace1"},
                    new WebHostingPlan { Name = "Plan2", WebSpace = "webspace2" }
                });
             
            // Test
            var command = new GetAzureWebHostingPlanCommand
            {
                CommandRuntime = new MockCommandRuntime(),
                WebsitesClient = clientMock.Object
            };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(subscriptionId)] = subscription;

            command.ExecuteCmdlet();

            var plans = System.Management.Automation.LanguagePrimitives.GetEnumerable(((MockCommandRuntime)command.CommandRuntime).OutputPipeline).Cast<WebHostingPlan>();

            Assert.NotNull(plans);
            Assert.Equal(2, plans.Count());
            Assert.True(plans.Any(p => (p).Name.Equals("Plan1") && (p).WebSpace.Equals("webspace1")));
            Assert.True(plans.Any(p => (p).Name.Equals("Plan2") && (p).WebSpace.Equals("webspace2")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureWebHostingPlanBasicTest()
        {
            // Setup
            var clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.ListWebSpaces())
                .Returns(new[] { new WebSpace { Name = "webspace1" }, new WebSpace { Name = "webspace2" } });

            clientMock.Setup(c => c.ListWebHostingPlans("webspace1"))
                .Returns(new List<WebHostingPlan> { new WebHostingPlan { Name = "Plan1", WebSpace = "webspace1" } });
             
            // Test
            var command = new GetAzureWebHostingPlanCommand
            {
                WebSpaceName = "webspace1",
                CommandRuntime = new MockCommandRuntime(),
                WebsitesClient = clientMock.Object
            };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription{Id = new Guid(subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(subscriptionId)] = subscription;

            command.ExecuteCmdlet();

            var plans = System.Management.Automation.LanguagePrimitives.GetEnumerable(((MockCommandRuntime)command.CommandRuntime).OutputPipeline).Cast<WebHostingPlan>();

            Assert.NotNull(plans);
            Assert.NotEmpty(plans);
            Assert.True(plans.Any(p => (p).Name.Equals("Plan1") && (p).WebSpace.Equals("webspace1")));
        }
    }
}

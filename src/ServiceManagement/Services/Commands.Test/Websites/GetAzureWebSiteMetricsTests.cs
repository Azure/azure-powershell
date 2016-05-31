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
using Microsoft.WindowsAzure.Commands.Websites;
using Moq;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    using System.Globalization;

    public class GetAzureWebsiteMetricsTests : WebsitesTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetWebsiteMetricsBasicTest()
        {
            // Setup
            var clientMock = new Mock<IWebsitesClient>();
            clientMock.Setup(c => c.ListWebSpaces())
                .Returns(new[] {new WebSpace {Name = "webspace1"}, new WebSpace {Name = "webspace2"}});

            clientMock.Setup(c => c.ListSitesInWebSpace("webspace1"))
                .Returns(new[] {new Site {Name = "website1", WebSpace = "webspace1"}});

            clientMock.Setup(c => c.GetHistoricalUsageMetrics("website1", null, null, null, null, null, false, false))
                .Returns(new[] {new MetricResponse() {Code = "Success", 
                    Data = new MetricSet()
                    {
                        Name = "CPU Time",
                        StartTime = DateTime.Parse("7/28/2014 1:00:00 AM", new CultureInfo("en-US")),
                        EndTime = DateTime.Parse("7/28/2014 2:00:00 AM", new CultureInfo("en-US")),
                        Values = new List<MetricSample>
                        {
                            new MetricSample
                            {
                                TimeCreated = DateTime.Parse("7/28/2014 1:00:00 AM", new CultureInfo("en-US")),
                                Total = 201,
                            }
                        }
                    }}});
            
            // Test
            var command = new GetAzureWebsiteMetricCommand
            {
                Name = "website1",
                CommandRuntime = new MockCommandRuntime(),
                WebsitesClient = clientMock.Object
            };
            currentProfile = new AzureSMProfile();
            var subscription = new AzureSubscription { Id = new Guid(base.subscriptionId) };
            subscription.Properties[AzureSubscription.Property.Default] = "True";
            currentProfile.Subscriptions[new Guid(base.subscriptionId)] = subscription;

            command.ExecuteCmdlet();
            Assert.Equal(1, ((MockCommandRuntime)command.CommandRuntime).OutputPipeline.Count);
            var metrics = (MetricResponse)((MockCommandRuntime)command.CommandRuntime).OutputPipeline.FirstOrDefault();
            Assert.NotNull(metrics);
            Assert.Equal("CPU Time", metrics.Data.Name);
            Assert.NotNull(metrics.Data.Values);
            Assert.NotNull(metrics.Data.Values[0]);
            Assert.Equal(201, metrics.Data.Values[0].Total);
        }
    }
}

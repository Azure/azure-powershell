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

using System.Collections.Generic;
using Microsoft.Azure.Commands.Insights.Metrics;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Metrics
{
    public class GetAzureRmMetricDefinitionTests
    {
        private readonly GetAzureRmMetricDefinitionCommand cmdlet;
        private readonly Mock<MonitorClient> MonitorClientMock;
        private readonly Mock<IMetricDefinitionsOperations> insightsMetricDefinitionOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private Microsoft.Rest.Azure.AzureOperationResponse<IEnumerable<MetricDefinition>> response;
        private string resourceId;
        private ODataQuery<MetricDefinition> filter;

        public GetAzureRmMetricDefinitionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            insightsMetricDefinitionOperationsMock = new Mock<IMetricDefinitionsOperations>();
            MonitorClientMock = new Mock<MonitorClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmMetricDefinitionCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorClient = MonitorClientMock.Object
            };

            response = new Microsoft.Rest.Azure.AzureOperationResponse<IEnumerable<MetricDefinition>>()
            {
                Body = Utilities.InitializeMetricDefinitionResponse()
            };

            insightsMetricDefinitionOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<ODataQuery<MetricDefinition>>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse<IEnumerable<MetricDefinition>>>(response))
                .Callback((string resource, ODataQuery<MetricDefinition> query, Dictionary<string, List<string>> header, CancellationToken t) =>
                {
                    resourceId = resource;
                    filter = query;
                });

            MonitorClientMock.SetupGet(f => f.MetricDefinitions).Returns(this.insightsMetricDefinitionOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetMetricDefinitionsCommandParametersProcessing()
        {
            // Testting defaults and required parameters
            cmdlet.ResourceId = Utilities.ResourceUri;

            cmdlet.ExecuteCmdlet();
            Assert.True(string.IsNullOrWhiteSpace(filter.Filter));
            Assert.Equal(Utilities.ResourceUri, resourceId);

            // Testing with optional parameters
            cmdlet.MetricName = new[] { "n1", "n2" };
            const string expected = "name.value eq 'n1' or name.value eq 'n2'";

            cmdlet.ExecuteCmdlet();
            Assert.Equal(expected, filter.Filter);
            Assert.Equal(Utilities.ResourceUri, resourceId);
        }
    }
}

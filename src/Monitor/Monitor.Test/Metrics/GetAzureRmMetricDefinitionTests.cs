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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Insights.Test.Metrics
{
    public class GetAzureRmMetricDefinitionTests
    {
        private readonly GetAzureRmMetricDefinitionCommand cmdlet;
        private readonly Mock<MonitorManagementClient> MonitorClientMock;
        private readonly Mock<IMetricDefinitionsOperations> insightsMetricDefinitionOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private Microsoft.Rest.Azure.AzureOperationResponse<IEnumerable<MetricDefinition>> response;
        private string resourceId;
        private string metricnamespace;

        public GetAzureRmMetricDefinitionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsMetricDefinitionOperationsMock = new Mock<IMetricDefinitionsOperations>();
            MonitorClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmMetricDefinitionCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = MonitorClientMock.Object
            };

            response = new Microsoft.Rest.Azure.AzureOperationResponse<IEnumerable<MetricDefinition>>()
            {
                Body = Utilities.InitializeMetricDefinitionResponse()
            };

            insightsMetricDefinitionOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse<IEnumerable<MetricDefinition>>>(response))
                .Callback((string resource, string metricNamespace, Dictionary<string, List<string>> header, CancellationToken t) =>
                {
                    resourceId = resource;
                    metricnamespace = metricNamespace;
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
            Assert.Equal(Utilities.ResourceUri, resourceId);

            // Testing with optional parameters
            cmdlet.MetricNamespace = Utilities.MetricNamespace;
            cmdlet.MetricName = new[] { "n1", "n2" };

            cmdlet.ExecuteCmdlet();
            Assert.Equal(Utilities.ResourceUri, resourceId);
            Assert.Equal(Utilities.MetricNamespace, metricnamespace);
        }
    }
}

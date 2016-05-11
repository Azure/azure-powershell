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

using Microsoft.Azure.Commands.Insights.Metrics;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
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
        private readonly Mock<InsightsClient> insightsClientMock;
        private readonly Mock<IMetricDefinitionOperations> insightsMetricDefinitionOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private MetricDefinitionListResponse response;
        private string resourceId;
        private string filter;

        public GetAzureRmMetricDefinitionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            insightsMetricDefinitionOperationsMock = new Mock<IMetricDefinitionOperations>();
            insightsClientMock = new Mock<InsightsClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmMetricDefinitionCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsClient = insightsClientMock.Object
            };

            response = Utilities.InitializeMetricDefinitionResponse();

            insightsMetricDefinitionOperationsMock.Setup(f => f.GetMetricDefinitionsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<MetricDefinitionListResponse>(response))
                .Callback((string f, string s, CancellationToken t) =>
                {
                    resourceId = f;
                    filter = s;
                });

            insightsClientMock.SetupGet(f => f.MetricDefinitionOperations).Returns(this.insightsMetricDefinitionOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetMetricDefinitionsCommandParametersProcessing()
        {
            // Testting defaults and required parameters
            cmdlet.ResourceId = Utilities.ResourceUri;

            cmdlet.ExecuteCmdlet();
            Assert.True(string.IsNullOrWhiteSpace(filter));
            Assert.Equal(Utilities.ResourceUri, resourceId);

            // Testing with optional parameters
            cmdlet.MetricNames = new[] { "n1", "n2" };
            const string expected = "name.value eq 'n1' or name.value eq 'n2'";

            cmdlet.ExecuteCmdlet();
            Assert.Equal(expected, filter);
            Assert.Equal(Utilities.ResourceUri, resourceId);
        }
    }
}

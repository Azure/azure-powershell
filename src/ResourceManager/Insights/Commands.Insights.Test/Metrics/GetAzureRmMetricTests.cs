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
using System.Xml;
using Microsoft.Azure.Commands.Insights.Metrics;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Metrics
{
    public class GetAzureRmMetricTests
    {
        private readonly GetAzureRmMetricCommand cmdlet;
        private readonly Mock<MonitorClient> MonitorClientMock;
        private readonly Mock<IMetricsOperations> insightsMetricOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private Microsoft.Rest.Azure.AzureOperationResponse<IEnumerable<Metric>> response;
        private string resourceId;
        private ODataQuery<Metric> filter;

        public GetAzureRmMetricTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            insightsMetricOperationsMock = new Mock<IMetricsOperations>();
            MonitorClientMock = new Mock<MonitorClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmMetricCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorClient = MonitorClientMock.Object
            };

            response = new Microsoft.Rest.Azure.AzureOperationResponse<IEnumerable<Metric>>()
            {
                Body = new List<Metric>()
            };

            insightsMetricOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<ODataQuery<Metric>>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse<IEnumerable<Metric>>>(response))
                .Callback((string r, ODataQuery<Metric> s, Dictionary<string, List<string>> headers, CancellationToken t) =>
                 {
                    resourceId = r;
                    filter = s;
                });

            MonitorClientMock.SetupGet(f => f.Metrics).Returns(this.insightsMetricOperationsMock.Object);
 }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetMetricsCommandParametersProcessing()
        {
            // Testting defaults and required parameters
            cmdlet.ResourceId = Utilities.ResourceUri;

            cmdlet.ExecuteCmdlet();
            Assert.True(filter != null && filter.Filter == null);
            Assert.Equal(Utilities.ResourceUri, resourceId);

            cmdlet.MetricName = new[] { "n1", "n2" };
            cmdlet.ExecuteCmdlet();
            Assert.True(filter != null);
            Assert.True(filter.Filter.Contains("(name.value eq 'n1' or name.value eq 'n2')"));
            Assert.Equal(Utilities.ResourceUri, resourceId);

            cmdlet.AggregationType = AggregationType.Total;
            cmdlet.ExecuteCmdlet();
            Assert.True(filter != null);
            Assert.True(filter.Filter.Contains("aggregationType eq 'Total'"));
            Assert.True(filter.Filter.Contains("(name.value eq 'n1' or name.value eq 'n2')"));
            Assert.Equal(Utilities.ResourceUri, resourceId);

            var endDate = DateTime.UtcNow.AddMinutes(-1);
            cmdlet.AggregationType = AggregationType.Average;
            cmdlet.EndTime = endDate;

            // Remove the value assigned in the last execution
            cmdlet.StartTime = default(DateTime);

            cmdlet.ExecuteCmdlet();
            Assert.True(filter != null);
            Assert.True(filter.Filter.Contains("aggregationType eq 'Average'"));
            Assert.True(filter.Filter.Contains("(name.value eq 'n1' or name.value eq 'n2')"));
            Assert.True(filter.Filter.Contains("startTime eq " + endDate.Subtract(GetAzureRmMetricCommand.DefaultTimeRange).ToString("O")));
            Assert.True(filter.Filter.Contains("endTime eq " + endDate.ToString("O")));
            Assert.Equal(Utilities.ResourceUri, resourceId);

            cmdlet.StartTime = endDate.Subtract(GetAzureRmMetricCommand.DefaultTimeRange).Subtract(GetAzureRmMetricCommand.DefaultTimeRange);

            cmdlet.ExecuteCmdlet();
            Assert.True(filter != null);
            Assert.True(filter.Filter.Contains("aggregationType eq 'Average'"));
            Assert.True(filter.Filter.Contains("(name.value eq 'n1' or name.value eq 'n2')"));
            Assert.True(filter.Filter.Contains("startTime eq " + endDate.Subtract(GetAzureRmMetricCommand.DefaultTimeRange).Subtract(GetAzureRmMetricCommand.DefaultTimeRange).ToString("O")));
            Assert.True(filter.Filter.Contains("endTime eq " + endDate.ToString("O")));
            Assert.Equal(Utilities.ResourceUri, resourceId);

            cmdlet.AggregationType = AggregationType.Maximum;
            cmdlet.TimeGrain = TimeSpan.FromMinutes(5);
            cmdlet.ExecuteCmdlet();
            Assert.True(filter != null);
            Assert.True(filter.Filter.Contains("aggregationType eq 'Maximum'"));
            Assert.True(filter.Filter.Contains("(name.value eq 'n1' or name.value eq 'n2')"));
            Assert.True(filter.Filter.Contains("startTime eq " + endDate.Subtract(GetAzureRmMetricCommand.DefaultTimeRange).Subtract(GetAzureRmMetricCommand.DefaultTimeRange).ToString("O")));
            Assert.True(filter.Filter.Contains("endTime eq " + endDate.ToString("O")));
            Assert.True(filter.Filter.Contains("timeGrain eq duration'" + XmlConvert.ToString(cmdlet.TimeGrain) + "'"));
            Assert.Equal(Utilities.ResourceUri, resourceId);
        }
    }
}

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
using Microsoft.Azure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Insights.Test.Metrics
{
    public class GetAzureRmMetricTests
    {
        private readonly GetAzureRmMetricCommand cmdlet;
        private readonly Mock<MonitorManagementClient> MonitorClientMock;
        private readonly Mock<IMetricsOperations> insightsMetricOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private Microsoft.Rest.Azure.AzureOperationResponse<Response> response;
        private string resourceId;
        private ODataQuery<MetadataValue> filter;
        private string timeSpan;
        private TimeSpan? metricQueryInterval;
        private string metricnames;
        private string aggregationType;
        private int? topNumber;
        private string orderby;
        private ResultType? resulttype;
        private string metricnamespace;

        public GetAzureRmMetricTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsMetricOperationsMock = new Mock<IMetricsOperations>();
            MonitorClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmMetricCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = MonitorClientMock.Object
            };

            response = new Microsoft.Rest.Azure.AzureOperationResponse<Response>();

            insightsMetricOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<ODataQuery<MetadataValue>>(), It.IsAny<string>(), It.IsAny<TimeSpan?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<ResultType?>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse<Response>>(response))
                .Callback((string resourceUri, ODataQuery<MetadataValue> odataQuery, string timespan, TimeSpan? interval, string metricNames, string aggregation, int? top, string orderBy, ResultType? resultType, string metricNamespace, Dictionary<string, List<string>> headers, CancellationToken t) =>
                 {
                     resourceId = resourceUri;
                     filter = odataQuery;
                     timeSpan = timespan;
                     metricQueryInterval = interval;
                     metricnames = metricNames;
                     aggregationType = aggregation;
                     topNumber = top;
                     orderby = orderBy;
                     resulttype = resultType;
                     metricnamespace = metricNamespace;
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
            Assert.Equal(Utilities.ResourceUri, resourceId);

            // Testing with optional parameters
            cmdlet.MetricName = new[] { "n1", "n2" };
            cmdlet.ExecuteCmdlet();
            string expectedMetricNames = string.Join(",", cmdlet.MetricName);
            Assert.Equal(Utilities.ResourceUri, resourceId);
            Assert.Equal(expectedMetricNames, metricnames);

            cmdlet.AggregationType = AggregationType.Total;
            cmdlet.ExecuteCmdlet();
            Assert.Equal(Utilities.ResourceUri, resourceId);
            Assert.Equal(expectedMetricNames, metricnames);
            Assert.Equal(AggregationType.Total.ToString(), aggregationType);

            var endDate = DateTime.UtcNow.AddMinutes(-1);
            cmdlet.AggregationType = AggregationType.Average;
            cmdlet.EndTime = endDate;

            // Remove the value assigned in the last execution
            cmdlet.StartTime = default(DateTime);

            cmdlet.ExecuteCmdlet();
            string expectedTimespan = string.Concat(endDate.Subtract(GetAzureRmMetricCommand.DefaultTimeRange).ToUniversalTime().ToString("O"), "/", endDate.ToUniversalTime().ToString("O"));
            Assert.Equal(Utilities.ResourceUri, resourceId);
            Assert.Equal(expectedMetricNames, metricnames);
            Assert.Equal(AggregationType.Average.ToString(), aggregationType);
            Assert.Equal(expectedTimespan, timeSpan);


            cmdlet.StartTime = endDate.Subtract(GetAzureRmMetricCommand.DefaultTimeRange).Subtract(GetAzureRmMetricCommand.DefaultTimeRange);

            cmdlet.ExecuteCmdlet();
            expectedTimespan = string.Concat(cmdlet.StartTime.ToUniversalTime().ToString("O"), "/", cmdlet.EndTime.ToUniversalTime().ToString("O"));
            Assert.Equal(Utilities.ResourceUri, resourceId);
            Assert.Equal(expectedMetricNames, metricnames);
            Assert.Equal(AggregationType.Average.ToString(), aggregationType);
            Assert.Equal(expectedTimespan, timeSpan);

            cmdlet.AggregationType = AggregationType.Maximum;
            cmdlet.TimeGrain = TimeSpan.FromMinutes(5);
            cmdlet.ExecuteCmdlet();
            Assert.Equal(Utilities.ResourceUri, resourceId);
            Assert.Equal(expectedMetricNames, metricnames);
            Assert.Equal(AggregationType.Maximum.ToString(), aggregationType);
            Assert.Equal(expectedTimespan, timeSpan);
            Assert.Equal(TimeSpan.FromMinutes(5), metricQueryInterval.Value);

            cmdlet.MetricNamespace = Utilities.MetricNamespace;
            cmdlet.Top = 5;
            cmdlet.OrderBy = "asc";
            cmdlet.ResultType = ResultType.Metadata;
            Assert.Equal(Utilities.ResourceUri, resourceId);
            Assert.Equal(expectedMetricNames, metricnames);
            Assert.Equal(AggregationType.Maximum.ToString(), aggregationType);
            Assert.Equal(expectedTimespan, timeSpan);
            Assert.Equal(TimeSpan.FromMinutes(5), metricQueryInterval.Value);
        }
    }
}

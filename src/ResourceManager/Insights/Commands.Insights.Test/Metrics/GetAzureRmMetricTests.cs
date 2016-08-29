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
        private readonly Mock<InsightsClient> insightsClientMock;
        private readonly Mock<IMetricOperations> insightsMetricOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private MetricListResponse response;
        private string resourceId;
        private string filter;

        public GetAzureRmMetricTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            insightsMetricOperationsMock = new Mock<IMetricOperations>();
            insightsClientMock = new Mock<InsightsClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmMetricCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsClient = insightsClientMock.Object
            };

            response = Utilities.InitializeMetricResponse();

            insightsMetricOperationsMock.Setup(f => f.GetMetricsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<MetricListResponse>(response))
                .Callback((string f, string s, CancellationToken t) =>
                {
                    resourceId = f;
                    filter = s;
                });

            insightsClientMock.SetupGet(f => f.MetricOperations).Returns(this.insightsMetricOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetMetricsCommandParametersProcessing()
        {
            // Testting defaults and required parameters
            cmdlet.ResourceId = Utilities.ResourceUri;
            cmdlet.TimeGrain = TimeSpan.FromMinutes(1);

            cmdlet.ExecuteCmdlet();
            Assert.True(filter != null && filter.Contains("timeGrain eq duration'PT1M'") && filter.Contains(" and startTime eq ") && filter.Contains(" and endTime eq "));
            Assert.Equal(Utilities.ResourceUri, resourceId);

            cmdlet.TimeGrain = TimeSpan.FromMinutes(5);

            cmdlet.ExecuteCmdlet();
            Assert.True(filter != null && filter.Contains("timeGrain eq duration'PT5M'") && filter.Contains(" and startTime eq ") && filter.Contains(" and endTime eq "));
            Assert.Equal(Utilities.ResourceUri, resourceId);

            var endDate = DateTime.Now.AddMinutes(-1);
            cmdlet.TimeGrain = TimeSpan.FromMinutes(5);
            cmdlet.EndTime = endDate;

            var startTime = endDate.Subtract(GetAzureRmMetricCommand.DefaultTimeRange).ToString("O");
            var endTime = endDate.ToString("O");
            var expected = "timeGrain eq duration'PT5M' and startTime eq " + startTime + " and endTime eq " + endTime;

            // Remove the value assigned in the last execution
            cmdlet.StartTime = default(DateTime);

            cmdlet.ExecuteCmdlet();
            Assert.Equal(expected, filter);
            Assert.Equal(Utilities.ResourceUri, resourceId);

            cmdlet.StartTime = endDate.Subtract(GetAzureRmMetricCommand.DefaultTimeRange).Subtract(GetAzureRmMetricCommand.DefaultTimeRange);
            startTime = cmdlet.StartTime.ToString("O");
            expected = "timeGrain eq duration'PT5M' and startTime eq " + startTime + " and endTime eq " + endTime;

            cmdlet.ExecuteCmdlet();
            Assert.Equal(expected, filter);
            Assert.Equal(Utilities.ResourceUri, resourceId);

            // Testing with optional parameters
            cmdlet.MetricNames = new[] { "n1", "n2" };
            expected = "(name.value eq 'n1' or name.value eq 'n2') and " + expected;

            cmdlet.ExecuteCmdlet();
            Assert.Equal(expected, filter);
            Assert.Equal(Utilities.ResourceUri, resourceId);
        }
    }
}

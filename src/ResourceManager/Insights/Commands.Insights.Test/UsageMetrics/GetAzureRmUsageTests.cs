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

using Microsoft.Azure.Commands.Insights.UsageMetrics;
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
    public class GetAzureRmUsageTests
    {
        private readonly GetAzureRmUsageCommand cmdlet;
        private readonly Mock<InsightsClient> insightsClientMock;
        private readonly Mock<IUsageMetricsOperations> insightsUsageMetricOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private UsageMetricListResponse response;
        private string resourceId;
        private string filter;
        private string apiVersion;

        public GetAzureRmUsageTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            insightsUsageMetricOperationsMock = new Mock<IUsageMetricsOperations>();
            insightsClientMock = new Mock<InsightsClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmUsageCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsClient = insightsClientMock.Object
            };

            response = Utilities.InitializeUsageMetricResponse();

            insightsUsageMetricOperationsMock
                .Setup(f => f.ListAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<UsageMetricListResponse>(response))
                .Callback((string f, string s, string a, CancellationToken t) =>
                {
                    resourceId = f;
                    filter = s;
                    apiVersion = a;
                });

            insightsClientMock
                .SetupGet(f => f.UsageMetricOperations)
                .Returns(this.insightsUsageMetricOperationsMock.Object);
        }

        private void CleanParamVariables()
        {
            resourceId = null;
            filter = null;
            apiVersion = null;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetUsageMetricsCommandParametersProcessing()
        {
            // Testting defaults and required parameters
            cmdlet.ResourceId = Utilities.ResourceUri;

            cmdlet.ExecuteCmdlet();
            Assert.True(filter != null && filter.Contains("startTime eq ") && filter.Contains(" and endTime eq "));
            Assert.Equal(Utilities.ResourceUri, resourceId);
            Assert.Equal(GetAzureRmUsageCommand.DefaultApiVersion, apiVersion);

            this.CleanParamVariables();
            var endDate = DateTime.Now.AddMinutes(-1);
            cmdlet.EndTime = endDate;

            var startTime = endDate
                .Subtract(GetAzureRmUsageCommand.DefaultTimeRange)
                .ToString("O");
            var endTime = endDate.ToString("O");
            var expected = "startTime eq " + startTime + " and endTime eq " + endTime;

            // Remove the value assigned in the last execution
            cmdlet.StartTime = default(DateTime);

            cmdlet.ExecuteCmdlet();
            Assert.Equal(expected, filter);
            Assert.Equal(Utilities.ResourceUri, resourceId);
            Assert.Equal(GetAzureRmUsageCommand.DefaultApiVersion, apiVersion);

            this.CleanParamVariables();
            cmdlet.StartTime = endDate
                .Subtract(GetAzureRmUsageCommand.DefaultTimeRange)
                .Subtract(GetAzureRmUsageCommand.DefaultTimeRange);
            startTime = cmdlet.StartTime.ToString("O");
            expected = "startTime eq " + startTime + " and endTime eq " + endTime;

            cmdlet.ExecuteCmdlet();
            Assert.Equal(expected, filter);
            Assert.Equal(Utilities.ResourceUri, resourceId);
            Assert.Equal(GetAzureRmUsageCommand.DefaultApiVersion, apiVersion);

            // Testing with optional parameters
            this.CleanParamVariables();
            cmdlet.MetricNames = new[] { "n1", "n2" };
            expected = "(name.value eq 'n1' or name.value eq 'n2') and " + expected;

            cmdlet.ExecuteCmdlet();
            Assert.Equal(expected, filter);
            Assert.Equal(Utilities.ResourceUri, resourceId);
            Assert.Equal(GetAzureRmUsageCommand.DefaultApiVersion, apiVersion);

            // Testing with another api version
            cmdlet.ApiVersion = "2015-01-01";
            cmdlet.ExecuteCmdlet();
            Assert.Equal(expected, filter);
            Assert.Equal(Utilities.ResourceUri, resourceId);
            Assert.Equal("2015-01-01", apiVersion);
        }
    }
}

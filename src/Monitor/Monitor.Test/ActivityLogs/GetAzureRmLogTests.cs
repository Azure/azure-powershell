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
using Microsoft.Azure.Commands.Insights.Events;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Insights.Test.Events
{
    public class GetAzureRmLogTests
    {
        private readonly GetAzureRmLogCommand cmdlet;
        private readonly Mock<MonitorManagementClient> MonitorClientMock;
        private readonly Mock<IActivityLogsOperations> insightsEventOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<IPage<EventData>> response;
        private AzureOperationResponse<IPage<EventData>> finalResponse;
        private ODataQuery<EventData> filter;
        private string selected;
        private string nextLink;

        public GetAzureRmLogTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsEventOperationsMock = new Mock<IActivityLogsOperations>();
            MonitorClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmLogCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = MonitorClientMock.Object
            };

            response = Utilities.InitializeResponse();
            finalResponse = Utilities.InitializeFinalResponse();

            insightsEventOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(It.IsAny<ODataQuery<EventData>>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<IPage<EventData>>>(response))
                .Callback((ODataQuery<EventData> f, string s, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    filter = f;
                    selected = s;
                });

            insightsEventOperationsMock.Setup(f => f.ListNextWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<IPage<EventData>>>(finalResponse))
                .Callback((string next, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    nextLink = next;
                });

            MonitorClientMock.SetupGet(f => f.ActivityLogs).Returns(this.insightsEventOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureSubscriptionIdLogCommandParametersProcessing()
        {
            var startDate = DateTime.Now.AddSeconds(-1);

            Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                insinsightsEventOperationsMockightsClientMock: this.insightsEventOperationsMock,
                requiredFieldName: null,
                requiredFieldValue: null,
                filter: ref this.filter,
                startDate: startDate,
                nextLink: ref this.nextLink);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureCorrelationIdLogCommandParametersProcessing()
        {
            var startDate = DateTime.Now.AddSeconds(-1);

            // Setting required parameter
            cmdlet.CorrelationId = Utilities.Correlation;
            cmdlet.ResourceId = null;
            cmdlet.ResourceGroupName = null;
            cmdlet.ResourceProvider = null;

            Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                insinsightsEventOperationsMockightsClientMock: this.insightsEventOperationsMock,
                requiredFieldName: "correlationId",
                requiredFieldValue: Utilities.Correlation,
                filter: ref this.filter,
                startDate: startDate,
                nextLink: ref this.nextLink);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureResourceGroupLogCommandParametersProcessing()
        {
            var startDate = DateTime.Now.AddSeconds(-1);

            // Setting required parameter
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.CorrelationId = null;
            cmdlet.ResourceId = null;
            cmdlet.ResourceProvider = null;

            Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                insinsightsEventOperationsMockightsClientMock: this.insightsEventOperationsMock,
                requiredFieldName: "resourceGroupName",
                requiredFieldValue: Utilities.ResourceGroup,
                filter: ref this.filter,
                startDate: startDate,
                nextLink: ref this.nextLink);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureResourceLogCommandParametersProcessing()
        {
            var startDate = DateTime.Now.AddSeconds(-1);

            // Setting required parameter
            cmdlet.ResourceId = Utilities.ResourceUri;
            cmdlet.ResourceGroupName = null;
            cmdlet.CorrelationId = null;
            cmdlet.ResourceProvider = null;

            Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                insinsightsEventOperationsMockightsClientMock: this.insightsEventOperationsMock,
                requiredFieldName: "resourceUri",
                requiredFieldValue: Utilities.ResourceUri,
                filter: ref this.filter,
                startDate: startDate,
                nextLink: ref this.nextLink);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureResourceProviderLogCommandParametersProcessing()
        {
            var startDate = DateTime.Now.AddSeconds(-1);

            // Setting required parameter
            cmdlet.ResourceProvider = Utilities.ResourceProvider;
            cmdlet.ResourceId = null;
            cmdlet.ResourceGroupName = null;
            cmdlet.CorrelationId = null;

            Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                insinsightsEventOperationsMockightsClientMock: this.insightsEventOperationsMock,
                requiredFieldName: "resourceProvider",
                requiredFieldValue: Utilities.ResourceProvider,
                filter: ref this.filter,
                startDate: startDate,
                nextLink: ref this.nextLink);
        }
    }
}

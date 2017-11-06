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
using Microsoft.Azure.Commands.Insights.Autoscale;
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

namespace Microsoft.Azure.Commands.Insights.Test.Autoscale
{
    public class GetAzureRmAutoscaleHistoryTests
    {
        private readonly GetAzureRmAutoscaleHistoryCommand cmdlet;
        private readonly Mock<MonitorClient> MonitorClientMock;
        private readonly Mock<IActivityLogsOperations> insightsEventOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<IPage<EventData>> response;
        private AzureOperationResponse<IPage<EventData>> finalResponse;
        private ODataQuery<EventData> filter;
        private string selected;
        private string nextLink;

        public GetAzureRmAutoscaleHistoryTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsEventOperationsMock = new Mock<IActivityLogsOperations>();
            MonitorClientMock = new Mock<MonitorClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmAutoscaleHistoryCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorClient = MonitorClientMock.Object
            };

            response = Test.Utilities.InitializeResponse();
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
        public void GetAutoscaleHistoryCommandParametersProcessing()
        {
            var startDate = DateTime.Now.AddSeconds(-1);

            Test.Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                insinsightsEventOperationsMockightsClientMock: this.insightsEventOperationsMock,
                requiredFieldName: "resourceType",
                requiredFieldValue: GetAzureRmAutoscaleHistoryCommand.AutoscaleResourceType,
                filter: ref this.filter,
                startDate: startDate,
                nextLink: ref this.nextLink);
        }
    }
}

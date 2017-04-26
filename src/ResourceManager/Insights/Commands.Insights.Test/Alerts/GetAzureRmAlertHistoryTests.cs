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
using Microsoft.Azure.Commands.Insights.Alerts;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Insights.Test.Alerts
{
    public class GetAzureRmAlertHistoryTests
    {
        private readonly GetAzureRmAlertHistoryCommand cmdlet;
        private readonly Mock<InsightsClient> insightsClientMock;
        private readonly Mock<IEventsOperations> insightsEventOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<IPage<EventData>> response;
        private ODataQuery<EventData> filter;
        private string selected;

        public GetAzureRmAlertHistoryTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            //XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            insightsEventOperationsMock = new Mock<IEventsOperations>();
            insightsClientMock = new Mock<InsightsClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmAlertHistoryCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsClient = insightsClientMock.Object
            };

            response = Test.Utilities.InitializeResponse();

            insightsEventOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(It.IsAny<ODataQuery<EventData>>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<IPage<EventData>>>(response))
                .Callback((ODataQuery<EventData> f, string s, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    filter = f;
                    selected = s;
                });

            insightsClientMock.SetupGet(f => f.Events).Returns(this.insightsEventOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAlertHistoryCommandParametersProcessing()
        {
            var startDate = DateTime.Now.AddSeconds(-1);

            Test.Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                insinsightsEventOperationsMockightsClientMock: this.insightsEventOperationsMock,
                requiredFieldName: "resourceType",
                requiredFieldValue: GetAzureRmAlertHistoryCommand.AlertResourceType,
                filter: ref this.filter,
                selected: ref this.selected,
                startDate: startDate,
                response: response);
        }
    }
}

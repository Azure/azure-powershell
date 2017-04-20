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

namespace Microsoft.Azure.Commands.Insights.Test.Events
{
    public class GetAzureRmLogTests
    {
        private readonly GetAzureRmLogCommand cmdlet;
        private readonly Mock<MonitorClient> MonitorClientMock;
        private readonly Mock<IActivityLogsOperations> insightsEventOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<IPage<EventData>> response;
        private ODataQuery<EventData> filter;
        private string selected;

        public GetAzureRmLogTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            //ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            insightsEventOperationsMock = new Mock<IActivityLogsOperations>();
            MonitorClientMock = new Mock<MonitorClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmLogCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorClient = MonitorClientMock.Object
            };

            response = Utilities.InitializeResponse();

            insightsEventOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(It.IsAny<ODataQuery<EventData>>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<IPage<EventData>>>(response))
                .Callback((ODataQuery<EventData> f, string s, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    filter = f;
                    selected = s;
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
                selected: ref this.selected,
                startDate: startDate,
                response: response);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureCorrelationIdLogCommandParametersProcessing()
        {
            var startDate = DateTime.Now.AddSeconds(-1);

            // Setting required parameter
            cmdlet.CorrelationId = Utilities.Correlation;
            cmdlet.ResourceId = null;
            cmdlet.ResourceGroup = null;
            cmdlet.ResourceProvider = null;

            Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                insinsightsEventOperationsMockightsClientMock: this.insightsEventOperationsMock,
                requiredFieldName: "correlationId",
                requiredFieldValue: Utilities.Correlation,
                filter: ref this.filter,
                selected: ref this.selected,
                startDate: startDate,
                response: response);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureResourceGroupLogCommandParametersProcessing()
        {
            var startDate = DateTime.Now.AddSeconds(-1);

            // Setting required parameter
            cmdlet.ResourceGroup = Utilities.ResourceGroup;
            cmdlet.CorrelationId = null;
            cmdlet.ResourceId = null;
            cmdlet.ResourceProvider = null;

            Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                insinsightsEventOperationsMockightsClientMock: this.insightsEventOperationsMock,
                requiredFieldName: "resourceGroupName",
                requiredFieldValue: Utilities.ResourceGroup,
                filter: ref this.filter,
                selected: ref this.selected,
                startDate: startDate,
                response: response);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureResourceLogCommandParametersProcessing()
        {
            var startDate = DateTime.Now.AddSeconds(-1);

            // Setting required parameter
            cmdlet.ResourceId = Utilities.ResourceUri;
            cmdlet.ResourceGroup = null;
            cmdlet.CorrelationId = null;
            cmdlet.ResourceProvider = null;

            Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                insinsightsEventOperationsMockightsClientMock: this.insightsEventOperationsMock,
                requiredFieldName: "resourceUri",
                requiredFieldValue: Utilities.ResourceUri,
                filter: ref this.filter,
                selected: ref this.selected,
                startDate: startDate,
                response: response);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureResourceProviderLogCommandParametersProcessing()
        {
            var startDate = DateTime.Now.AddSeconds(-1);

            // Setting required parameter
            cmdlet.ResourceProvider = Utilities.ResourceProvider;
            cmdlet.ResourceId = null;
            cmdlet.ResourceGroup = null;
            cmdlet.CorrelationId = null;

            Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                insinsightsEventOperationsMockightsClientMock: this.insightsEventOperationsMock,
                requiredFieldName: "resourceProvider",
                requiredFieldValue: Utilities.ResourceProvider,
                filter: ref this.filter,
                selected: ref this.selected,
                startDate: startDate,
                response: response);
        }
    }
}

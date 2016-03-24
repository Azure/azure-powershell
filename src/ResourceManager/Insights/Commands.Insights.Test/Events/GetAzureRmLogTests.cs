﻿// ----------------------------------------------------------------------------------
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

using System;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Insights.Events;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Events
{
    public class GetAzureRmLogTests
    {
        private readonly GetAzureRmLogCommand cmdlet;
        private readonly Mock<InsightsClient> insightsClientMock;
        private readonly Mock<IEventOperations> insightsEventOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private EventDataListResponse response;
        private string filter;
        private string selected;

        public GetAzureRmLogTests()
        {
            insightsEventOperationsMock = new Mock<IEventOperations>();
            insightsClientMock = new Mock<InsightsClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmLogCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsClient = insightsClientMock.Object
            };

            response = Utilities.InitializeResponse();

            insightsEventOperationsMock.Setup(f => f.ListEventsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<EventDataListResponse>(response))
                .Callback((string f, string s, CancellationToken t) =>
                {
                    filter = f;
                    selected = s;
                });

            insightsClientMock.SetupGet(f => f.EventOperations).Returns(this.insightsEventOperationsMock.Object);
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

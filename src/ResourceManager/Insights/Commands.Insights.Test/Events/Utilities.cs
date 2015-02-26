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

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Events
{
    public static class Utilities
    {
        public static readonly string Caller = "caller";
        public static readonly string Correlation = "correlation";
        public static readonly string ResourceGroup = "resource group";
        public static readonly string ResourceProvider = "Microsoft Resources";
        public static readonly string ResourceUri = "/subscriptions/ffce8037-a374-48bf-901d-dac4e3ea8c09/resourcegroups/foo/deployments/testdeploy";
        public static readonly string Status = "Succeeded";

        public static readonly string ContinuationToken = "more records";

        public static EventData CreateFakeEvent()
        {
            return new EventData()
            {
                Id = "ac7d2ab5-698a-4c33-9c19-0a93d3d7f527",
                EventName = new LocalizableString()
                {
                    LocalizedValue = "Start request",
                    Value = "Start request",
                },
                EventSource = new LocalizableString()
                {
                    LocalizedValue = "Microsoft Resources",
                    Value = "Microsoft Resources",
                },
                Authorization = new SenderAuthorization()
                {
                    Action = "PUT",
                    Condition = "",
                    Role = "Sender",
                    Scope = "None"
                },
                Caller = Caller,
                Claims = new Dictionary<string, string>
                {
                    {"aud", "https://management.core.windows.net/"},
                    {"iss", "https://sts.windows.net/123456/"},
                    {"iat", "h123445"}
                },
                CorrelationId = Correlation,
                Description = "fake event",
                EventChannels = EventChannels.Operation,
                Level = EventLevel.Informational,
                EventTimestamp = DateTime.Now,
                OperationId = "c0f2e85f-efb0-47d0-bf90-f983ec8be91d",
                OperationName = new LocalizableString()
                {
                    LocalizedValue = "Microsoft.Resources/subscriptions/resourcegroups/deployments/write",
                    Value = "Microsoft.Resources/subscriptions/resourcegroups/deployments/write",
                },
                Status = new LocalizableString()
                {
                    LocalizedValue = Status,
                    Value = Status,
                },
                SubStatus = new LocalizableString()
                {
                    LocalizedValue = "Created",
                    Value = "Created",
                },
                ResourceGroupName = ResourceGroup,
                ResourceProviderName = new LocalizableString()
                {
                    LocalizedValue = ResourceProvider,
                    Value = ResourceProvider,
                },
                ResourceUri = ResourceUri,
                HttpRequest = new HttpRequestInfo
                {
                    Uri = "http://path/subscriptions/ffce8037-a374-48bf-901d-dac4e3ea8c09/resourcegroups/foo/deployments/testdeploy",
                    Method = "PUT",
                    ClientRequestId = "1234",
                    ClientIpAddress = "123.123.123.123"
                },
                Properties = new Dictionary<string, string>(),
            };
        }

        public static EventDataListResponse InitializeResponse()
        {
            // This is effectively testing the conversion EventData -> PSEventData internally in the execution of the cmdlet
            EventData eventData = Utilities.CreateFakeEvent();
            return new EventDataListResponse()
            {
                EventDataCollection = new EventDataCollection()
                {
                    Value = new List<EventData>()
                    {
                        eventData,
                    },
                    NextLink = null,
                },
                RequestId = Guid.NewGuid().ToString(),
                StatusCode = HttpStatusCode.OK
            };
        }

        public static void VerifyDetailedOutput(EventCmdletBase cmdlet, ref string selected)
        {
            // Calling with detailed output
            cmdlet.DetailedOutput = true;
            cmdlet.ExecuteCmdlet();
            Assert.True(string.Equals(null, selected, StringComparison.OrdinalIgnoreCase), "Incorrect selected clause with detailed output on");
        }

        public static void VerifyContinuationToken(EventDataListResponse response, Mock<IEventOperations> insinsightsEventOperationsMockightsClientMock, EventCmdletBase cmdlet)
        {
                        // Make sure calls to Next work also
            response.EventDataCollection.NextLink = Utilities.ContinuationToken;
            var responseNext = new EventDataListResponse()
            {
                EventDataCollection = new EventDataCollection()
                {
                    Value = new List<EventData>()
                    {
                        Utilities.CreateFakeEvent(),
                    },
                    NextLink = null,
                },
                RequestId = Guid.NewGuid().ToString(),
                StatusCode = HttpStatusCode.OK
            };

            string nextToken = null;
            insinsightsEventOperationsMockightsClientMock.Setup(f => f.ListEventsNextAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<EventDataListResponse>(responseNext))
                .Callback((string n, CancellationToken t) => nextToken = n);

            // Calling without optional parameters
            cmdlet.ExecuteCmdlet();
            Assert.True(string.Equals(Utilities.ContinuationToken, nextToken, StringComparison.OrdinalIgnoreCase), "Incorrect continuation token");
        }

        public static void VerifyFilterIsUsable(string filter)
        {
            Assert.NotNull(filter);
            Assert.False(string.IsNullOrWhiteSpace(filter));
        }

        public static void VerifyConditionInFilter(string filter, string field, string value)
        {
            if (!string.IsNullOrWhiteSpace(field))
            {
                var condition = string.Format("and {0} eq '{1}'", field, value);
                Assert.True(filter.Contains(condition), "Filter does not contain required condition");
            }
        }

        public static void VerifyStartDateInFilter(string filter, DateTime? startDate)
        {
            var condition = startDate.HasValue ? string.Format("eventTimestamp ge '{0:o}'", startDate.Value.ToUniversalTime()) : string.Format("eventTimestamp ge '");
            Assert.True(filter.Contains(condition), "Filter does not contain start date condition");
        }

        public static void VerifyEndDateInFilter(string filter, DateTime endDate)
        {
            var condition = string.Format(" and eventTimestamp le '{0:o}'", endDate.ToUniversalTime());
            Assert.True(filter.Contains(condition), "Filter does not contain end date condition");
        }

        public static void VerifyCallerInCall(string filter, DateTime? startDate, string filedName, string fieldValue)
        {
            VerifyFilterIsUsable(filter: filter);
            VerifyStartDateInFilter(filter: filter, startDate: startDate);
            VerifyConditionInFilter(filter: filter, field: filedName, value: fieldValue);
            VerifyConditionInFilter(filter: filter, field: "caller", value: Utilities.Caller);
        }

        public static void VerifyStatusAndCallerInCall(string filter, DateTime? startDate, string filedName, string fieldValue)
        {
            VerifyFilterIsUsable(filter: filter);
            VerifyStartDateInFilter(filter: filter, startDate: startDate);
            VerifyConditionInFilter(filter: filter, field: filedName, value: fieldValue);
            VerifyConditionInFilter(filter: filter, field: "caller", value: Utilities.Caller);
            VerifyConditionInFilter(filter: filter, field: "status", value: Utilities.Status);
        }

        public static void ExecuteVerifications(EventCmdletBase cmdlet, Mock<IEventOperations> insinsightsEventOperationsMockightsClientMock, string requiredFieldName, string requiredFieldValue, ref string filter, ref string selected, DateTime startDate, EventDataListResponse response)
        {
            // Calling without optional parameters
            cmdlet.ExecuteCmdlet();

            VerifyFilterIsUsable(filter: filter);
            VerifyStartDateInFilter(filter: filter, startDate: null);
            VerifyConditionInFilter(filter: filter, field: requiredFieldName, value: requiredFieldValue);
            Assert.True(string.Equals(PSEventDataNoDetails.SelectedFieldsForQuery, selected, StringComparison.OrdinalIgnoreCase), "Incorrect selected clause without optional parameters");

            // Calling with only start date
            cmdlet.StartTime = startDate;
            cmdlet.ExecuteCmdlet();

            VerifyFilterIsUsable(filter: filter);
            VerifyStartDateInFilter(filter: filter, startDate: startDate);
            VerifyConditionInFilter(filter: filter, field: requiredFieldName, value: requiredFieldValue);

            // Calling with only start and end date
            cmdlet.EndTime = startDate.AddSeconds(2);
            cmdlet.ExecuteCmdlet();

            VerifyFilterIsUsable(filter: filter);
            VerifyStartDateInFilter(filter: filter, startDate: startDate);
            VerifyEndDateInFilter(filter: filter, endDate: startDate.AddSeconds(2));
            VerifyConditionInFilter(filter: filter, field: requiredFieldName, value: requiredFieldValue);

            // Calling with only caller
            cmdlet.EndTime = null;
            cmdlet.Caller = Utilities.Caller;
            cmdlet.ExecuteCmdlet();

            VerifyCallerInCall(filter: filter, startDate: startDate, filedName: requiredFieldName, fieldValue: requiredFieldValue);

            // Calling with caller and status
            cmdlet.Status = Utilities.Status;
            cmdlet.ExecuteCmdlet();

            VerifyStatusAndCallerInCall(filter: filter, startDate: startDate, filedName: requiredFieldName, fieldValue: requiredFieldValue);

            VerifyDetailedOutput(cmdlet: cmdlet, selected: ref selected);
            VerifyContinuationToken(response: response, insinsightsEventOperationsMockightsClientMock: insinsightsEventOperationsMockightsClientMock, cmdlet: cmdlet);

            // Execute negative tests
            cmdlet.StartTime = DateTime.Now.AddSeconds(1);
            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.StartTime = DateTime.Now.Subtract(TimeSpan.FromSeconds(20));
            cmdlet.EndTime = DateTime.Now.Subtract(TimeSpan.FromSeconds(21));
            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.StartTime = DateTime.Now.Subtract(TimeSpan.FromDays(30));
            cmdlet.EndTime = DateTime.Now.Subtract(TimeSpan.FromDays(14));
            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());
        }
    }
}

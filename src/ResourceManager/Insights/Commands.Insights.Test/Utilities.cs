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

using Microsoft.Azure.Commands.Insights.Alerts;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Xunit;
using LocalizableString = Microsoft.Azure.Management.Monitor.Models.LocalizableString;
using Microsoft.Azure.Commands.Insights.Events;

namespace Microsoft.Azure.Commands.Insights.Test
{
    public static class Utilities
    {
        public static readonly string Name = "checkrule3-4b135401-a30c-4224-ae21-fa53a5bd253d";
        public static readonly string Caller = "caller";
        public static readonly string Correlation = "correlation";
        public static readonly string ResourceGroup = "Default-Web-EastUS";
        public static readonly string ResourceProvider = "Microsoft Resources";
        public static readonly string ResourceUri = "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/garyyang1";
        public static readonly string Status = "Succeeded";
        public static readonly string ContinuationToken = "more records";

        #region Events

        public static EventData CreateFakeEvent(string id = null, bool newDates = true)
        {
            var fixedDate = new DateTime(2017, 06, 07, 22, 54, 0, DateTimeKind.Utc);
            return new EventData(
                id: id ?? "ac7d2ab5-698a-4c33-9c19-0a93d3d7f527",
                eventName: new LocalizableString(
                    localizedValue: "Start request",
                    value: "Start request"),
                category: new LocalizableString(
                    localizedValue: "Microsoft Resources",
                    value: "Microsoft Resources"),
                authorization: new SenderAuthorization(
                    action: "PUT",
                    role: "Sender",
                    scope: "None"),
                caller: Caller,
                claims: new Dictionary<string, string>
                {
                    {"aud", "https://management.core.windows.net/"},
                    {"iss", "https://sts.windows.net/123456/"},
                    {"iat", "h123445"}
                },
                correlationId: Correlation,
                description: "fake event",
                level: EventLevel.Informational,
                eventTimestamp: newDates ? DateTime.Now : fixedDate,
                operationId: "c0f2e85f-efb0-47d0-bf90-f983ec8be91d",
                operationName: new LocalizableString(
                    localizedValue: "Microsoft.Resources/subscriptions/resourcegroups/deployments/write",
                    value: "Microsoft.Resources/subscriptions/resourcegroups/deployments/write"),
                status: new LocalizableString(
                    localizedValue: Status,
                    value: Status),
                subStatus: new LocalizableString(
                    localizedValue: "Created",
                    value: "Created"),
                resourceGroupName: ResourceGroup,
                resourceProviderName: new LocalizableString(
                    localizedValue: ResourceProvider,
                    value: ResourceProvider),
                resourceId: ResourceUri,
                httpRequest: new HttpRequestInfo(
                    uri: "http://path/subscriptions/ffce8037-a374-48bf-901d-dac4e3ea8c09/resourcegroups/foo/deployments/testdeploy",
                    method: "PUT",
                    clientRequestId: "1234",
                    clientIpAddress: "123.123.123.123"),
                properties: new Dictionary<string, string>(),
                submissionTimestamp: newDates ? DateTime.Now : fixedDate);
        }

        public static List<EventData> CreateListOfFakeEvents(int numEvents = 1)
        {
            List<EventData> events = new List<EventData>(numEvents);

            // The first one is always completely known at compile time
            events.Add(CreateFakeEvent());
            for (int i = 0; i < numEvents - 1; i++)
            {
                // The rest of the events in the list have a unique id
                events.Add(CreateFakeEvent(Guid.NewGuid().ToString()));
            }

            return events;
        }

        public static AzureOperationResponse<IPage<EventData>> InitializeResponse(int numRecords = 10)
        {
            // 200 is the default page lenght of the backend, but these are tests -> using 10 as page length
            if (numRecords < 10)
            {
                return InitializeFinalResponse(numRecords);
            }

            List<EventData> events = Utilities.CreateListOfFakeEvents(numRecords);
            var x = JsonConvert.SerializeObject(events);
            x = string.Concat("{", string.Format("\"value\":{0},\"nextLink\":\"{1}\"", x, Utilities.ContinuationToken), "}");

            return new AzureOperationResponse<IPage<EventData>>()
            {
                Body = JsonConvert.DeserializeObject<Azure.Management.Monitor.Models.Page1<EventData>>(x)
            };
        }

        public static AzureOperationResponse<IPage<EventData>> InitializeFinalResponse(int numRecords = 5)
        {
            List<EventData> eventData = Utilities.CreateListOfFakeEvents(numRecords);
            var x = JsonConvert.SerializeObject(eventData);
            x = string.Concat("{\"value\":", x, ",\"nextLink\":null}");

            return new AzureOperationResponse<IPage<EventData>>()
            {
                Body = JsonConvert.DeserializeObject<Azure.Management.Monitor.Models.Page1<EventData>>(x)
            };
        }

        public static AzureOperationResponse<LogProfileResource> InitializeLogProfileResponse()
        {
            // This is effectively testing the conversion EventData -> PSEventData internally in the execution of the cmdlet
            EventData eventData = Utilities.CreateFakeEvent();
            var x = JsonConvert.SerializeObject(eventData);

            return new AzureOperationResponse<LogProfileResource>()
            {
                Body = new LogProfileResource(
                    name:Utilities.Name,
                    location: "East US", 
                    id: "MyLogProfileId", 
                    locations: new string[] { "EastUs" }, 
                    categories: new List<string>() { "cat2" },
                    retentionPolicy: new RetentionPolicy(enabled: true, days: 10))

                {
                    ServiceBusRuleId = "myBusId",
                    StorageAccountId = "myStorageAccId",
                    Tags = null
                }
            };
        }

        public static IEnumerable<Metric> InitializeMetricResponse()
        {
            return new List<Metric>();
        }

        public static IEnumerable<MetricDefinition> InitializeMetricDefinitionResponse()
        {
            return new List<MetricDefinition>();
        }

        public static void VerifyDetailedOutput(LogsCmdletBase cmdlet)
        {
            // Calling with detailed output
            cmdlet.DetailedOutput = true;
            cmdlet.ExecuteCmdlet();
        }

        public static void VerifyContinuationToken(string nextLink)
        {
            Assert.Equal(Utilities.ContinuationToken, nextLink, ignoreCase:true, ignoreLineEndingDifferences:true,ignoreWhiteSpaceDifferences:true);
        }

        public static void VerifyFilterIsUsable(ODataQuery<EventData> filter)
        {
            Assert.NotNull(filter);
            Assert.False(string.IsNullOrWhiteSpace(filter.Filter));
        }

        public static void VerifyConditionInFilter(ODataQuery<EventData> filter, string field, string value)
        {
            if (!string.IsNullOrWhiteSpace(field))
            {
                var condition = string.Format("and {0} eq '{1}'", field, value);
                Assert.True(filter.Filter.Contains(condition), string.Format("Filter: {0} does not contain required condition: {1}", filter, condition));
            }
        }

        public static void VerifyStartDateInFilter(ODataQuery<EventData> filter, DateTime? startDate)
        {
            var condition = startDate.HasValue ? string.Format("eventTimestamp ge '{0:o}'", startDate.Value.ToUniversalTime()) : string.Format("eventTimestamp ge '");
            Assert.True(filter.Filter.Contains(condition), "Filter does not contain start date condition");
        }

        public static void VerifyEndDateInFilter(ODataQuery<EventData> filter, DateTime endDate)
        {
            var condition = string.Format(" and eventTimestamp le '{0:o}'", endDate.ToUniversalTime());
            Assert.True(filter.Filter.Contains(condition), "Filter does not contain end date condition");
        }

        public static void VerifyCallerInCall(ODataQuery<EventData> filter, DateTime? startDate, string filedName, string fieldValue)
        {
            VerifyFilterIsUsable(filter: filter);
            VerifyStartDateInFilter(filter: filter, startDate: startDate);
            VerifyConditionInFilter(filter: filter, field: filedName, value: fieldValue);
            VerifyConditionInFilter(filter: filter, field: "caller", value: Utilities.Caller);
        }

        public static void VerifyStatusAndCallerInCall(ODataQuery<EventData> filter, DateTime? startDate, string filedName, string fieldValue)
        {
            VerifyFilterIsUsable(filter: filter);
            VerifyStartDateInFilter(filter: filter, startDate: startDate);
            VerifyConditionInFilter(filter: filter, field: filedName, value: fieldValue);
            VerifyConditionInFilter(filter: filter, field: "caller", value: Utilities.Caller);
            VerifyConditionInFilter(filter: filter, field: "status", value: Utilities.Status);
        }

        public static void ExecuteVerifications(LogsCmdletBase cmdlet, Mock<IActivityLogsOperations> insinsightsEventOperationsMockightsClientMock, string requiredFieldName, string requiredFieldValue, ref ODataQuery<EventData> filter, DateTime startDate, ref string nextLink)
        {
            // Calling without optional parameters
            cmdlet.ExecuteCmdlet();

            VerifyFilterIsUsable(filter: filter);
            VerifyStartDateInFilter(filter: filter, startDate: null);
            VerifyConditionInFilter(filter: filter, field: requiredFieldName, value: requiredFieldValue);
            VerifyContinuationToken(nextLink: nextLink);

            // Calling with only start date
            cmdlet.StartTime = startDate;
            nextLink = null;
            cmdlet.ExecuteCmdlet();

            VerifyFilterIsUsable(filter: filter);
            VerifyStartDateInFilter(filter: filter, startDate: startDate);
            VerifyConditionInFilter(filter: filter, field: requiredFieldName, value: requiredFieldValue);
            VerifyContinuationToken(nextLink: nextLink);

            // Calling with only start and end date
            cmdlet.EndTime = startDate.AddSeconds(2);
            nextLink = null;
            cmdlet.ExecuteCmdlet();

            VerifyFilterIsUsable(filter: filter);
            VerifyStartDateInFilter(filter: filter, startDate: startDate);
            VerifyEndDateInFilter(filter: filter, endDate: startDate.AddSeconds(2));
            VerifyConditionInFilter(filter: filter, field: requiredFieldName, value: requiredFieldValue);
            VerifyContinuationToken(nextLink: nextLink);

            // Calling with only caller
            cmdlet.EndTime = null;
            cmdlet.Caller = Utilities.Caller;
            nextLink = null;
            cmdlet.ExecuteCmdlet();

            VerifyCallerInCall(filter: filter, startDate: startDate, filedName: requiredFieldName, fieldValue: requiredFieldValue);
            VerifyContinuationToken(nextLink: nextLink);

            // Calling with caller and status
            cmdlet.Status = Utilities.Status;
            nextLink = null;
            cmdlet.ExecuteCmdlet();

            VerifyStatusAndCallerInCall(filter: filter, startDate: startDate, filedName: requiredFieldName, fieldValue: requiredFieldValue);
            VerifyDetailedOutput(cmdlet: cmdlet);
            VerifyContinuationToken(nextLink: nextLink);

            // Calling with maxEvents (Note: # of returned objects is not testable here, only the call is being tested)
            var cmdLetLogs = cmdlet as GetAzureRmLogCommand;
            if (cmdLetLogs != null)
            {
                cmdLetLogs.Caller = null;
                cmdLetLogs.Status = null;
                nextLink = null;
                cmdLetLogs.MaxRecord = 3;
                cmdLetLogs.ExecuteCmdlet();

                VerifyFilterIsUsable(filter: filter);
                VerifyStartDateInFilter(filter: filter, startDate: null);
                VerifyConditionInFilter(filter: filter, field: requiredFieldName, value: requiredFieldValue);

                // Negative value
                nextLink = null;
                cmdLetLogs.MaxRecord = -1;
                cmdLetLogs.ExecuteCmdlet();

                VerifyFilterIsUsable(filter: filter);
                VerifyStartDateInFilter(filter: filter, startDate: null);
                VerifyConditionInFilter(filter: filter, field: requiredFieldName, value: requiredFieldValue);

                // The default should have been used, check continuation token
                VerifyContinuationToken(nextLink: nextLink);

                cmdLetLogs.MaxRecord = 0;
            }

            // Execute negative tests
            cmdlet.Caller = null;
            cmdlet.Status = null;
            cmdlet.StartTime = DateTime.Now.AddSeconds(1);
            nextLink = null;
            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.StartTime = DateTime.Now.Subtract(TimeSpan.FromSeconds(20));
            cmdlet.EndTime = DateTime.Now.Subtract(TimeSpan.FromSeconds(21));
            nextLink = null;
            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());
        }

        #endregion

        #region Alerts

        public static AlertRuleResource CreateFakeRuleResource()
        {
            var condition = new ThresholdRuleCondition()
            {
                DataSource = new RuleMetricDataSource()
                {
                    MetricName = "CpuTime",
                    ResourceUri = ResourceUri,
                },
                OperatorProperty = ConditionOperator.GreaterThan,
                Threshold = 3,
                TimeAggregation = TimeAggregationOperator.Total,
                WindowSize = TimeSpan.FromMinutes(5),
            };

            return new AlertRuleResource(
                id: "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.insights/alertrules/checkrule3-4b135401-a30c-4224-ae21-fa53a5bd253d",
                location: "East US",
                alertRuleResourceName: Name,
                isEnabled: true,
                condition: condition)
            {
                Actions = new BindingList<RuleAction>()
                {
                    new RuleEmailAction(),
                },
                Description = null,
                Tags = new Dictionary<string, string>()
                {
                    {"$type", "Microsoft.WindowsAzure.Management.Common.Storage.CasePreservedDictionary,Microsoft.WindowsAzure.Management.Common.Storage"},
                    {"hidden-link:/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/garyyang1","Resource"}
                },
            };
        }

        /*
        public static RuleListResponse InitializeRuleListResponse()
        {
            // This is effectively testing the conversion EventData -> PSEventData internally in the execution of the cmdlet
            AlertRuleResource ruleResource = Utilities.CreateFakeRuleResource();
            return new RuleListResponse()
            {
                RuleResourceCollection = new RuleResourceCollection()
                {
                    Value = new List<AlertRuleResource>() { ruleResource },
                },
                RequestId = Guid.NewGuid().ToString(),
                StatusCode = HttpStatusCode.OK
            };
        }

        public static RuleGetResponse InitializeRuleGetResponse()
        {
            // This is effectively testing the conversion EventData -> PSEventData internally in the execution of the cmdlet
            AlertRuleResource ruleResource = Utilities.CreateFakeRuleResource();
            return new RuleGetResponse()
            {
                Id = ruleResource.Id,
                Location = ruleResource.Location,
                Name = ruleResource.Name,
                Properties = ruleResource.Properties,
                Tags = ruleResource.Tags,
                RequestId = Guid.NewGuid().ToString(),
                StatusCode = HttpStatusCode.OK
            };
        } */

        public static void VerifyDetailedOutput(GetAzureRmAlertRuleCommand cmdlet, string expectedResourceGroup, ref string resourceGroup, ref string nameOrTargetUri)
        {
            // Calling with detailed output
            cmdlet.DetailedOutput = true;
            cmdlet.Name = null;
            cmdlet.TargetResourceId = ResourceUri;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(expectedResourceGroup, resourceGroup);
            Assert.Equal(ResourceUri, nameOrTargetUri);
        }

        public static void VerifyFieldAndValueInCall(string filter, string filedName, string fieldValue)
        {
            VerifyFilterIsUsable(filter: filter);
            VerifyConditionInFilter(filter: filter, field: filedName, value: fieldValue);
        }

        public static void ExecuteVerifications(ManagementCmdletBase cmdlet, string expectedResourceGroup, ref string resourceGroup, ref string nameOrTargetUri)
        {
            // Calling without optional parameters
            cmdlet.ExecuteCmdlet();

            VerifyFilterIsUsable(filter: resourceGroup);
            Assert.Equal(expectedResourceGroup, resourceGroup);
            Assert.Null(nameOrTargetUri);

            var typedCmdlet = cmdlet as GetAzureRmAlertRuleCommand;
            if (typedCmdlet != null)
            {
                // Calling with Name
                typedCmdlet.Name = Name;
                typedCmdlet.ExecuteCmdlet();

                Assert.Equal(expectedResourceGroup, resourceGroup);
                Assert.Equal(Name, nameOrTargetUri);

                // Calling with ResourceUri
                typedCmdlet.Name = null;
                typedCmdlet.TargetResourceId = ResourceUri;
                typedCmdlet.ExecuteCmdlet();

                Assert.Equal(expectedResourceGroup, resourceGroup);
                Assert.Equal(ResourceUri, nameOrTargetUri);

                // Calling with Detailed ouput and resourceuri
                VerifyDetailedOutput(cmdlet: typedCmdlet, expectedResourceGroup: expectedResourceGroup, resourceGroup: ref resourceGroup, nameOrTargetUri: ref nameOrTargetUri);
            }
        }

        #endregion
    }
}

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
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using Microsoft.Azure.Management.Insights.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using LocalizableString = Microsoft.Azure.Insights.Models.LocalizableString;

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

        public static EventData CreateFakeEvent()
        {
            return new EventData(
                id: "ac7d2ab5-698a-4c33-9c19-0a93d3d7f527",
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
                eventTimestamp: DateTime.Now,
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
                submissionTimestamp: DateTime.Now);
        }

        public static AzureOperationResponse<IPage<EventData>> InitializeResponse()
        {
            // This is effectively testing the conversion EventData -> PSEventData internally in the execution of the cmdlet
            EventData eventData = Utilities.CreateFakeEvent();
            var x = JsonConvert.SerializeObject(eventData);

            return new AzureOperationResponse<IPage<EventData>>()
            {
                Body = JsonConvert.DeserializeObject<Azure.Insights.Models.Page<EventData>>(x)
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

        public static void VerifyDetailedOutput(LogsCmdletBase cmdlet, ref string selected)
        {
            // Calling with detailed output
            cmdlet.DetailedOutput = true;
            cmdlet.ExecuteCmdlet();
            Assert.Null(selected); // Incorrect nameOrTargetUri clause with detailed output on
        }

        public static void VerifyContinuationToken(AzureOperationResponse<IPage<EventData>> response, Mock<IActivityLogsOperations> insinsightsEventOperationsMockightsClientMock, LogsCmdletBase cmdlet)
        {
            // Make sure calls to Next work also
            string nextToken = ContinuationToken;
            insinsightsEventOperationsMockightsClientMock.Setup(f => f.ListNextWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<IPage<EventData>>>(response))
                .Callback((string n, Dictionary<string, List<string>> h, CancellationToken t) => nextToken = n);

            // Calling without optional parameters
            cmdlet.ExecuteCmdlet();
            Assert.Equal(Utilities.ContinuationToken, nextToken, ignoreCase:true, ignoreLineEndingDifferences:true,ignoreWhiteSpaceDifferences:true);
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

        public static void ExecuteVerifications(LogsCmdletBase cmdlet, Mock<IActivityLogsOperations> insinsightsEventOperationsMockightsClientMock, string requiredFieldName, string requiredFieldValue, ref ODataQuery<EventData> filter, ref string selected, DateTime startDate, AzureOperationResponse<IPage<EventData>> response)
        {
            // Calling without optional parameters
            cmdlet.ExecuteCmdlet();

            VerifyFilterIsUsable(filter: filter);
            VerifyStartDateInFilter(filter: filter, startDate: null);
            VerifyConditionInFilter(filter: filter, field: requiredFieldName, value: requiredFieldValue);
            Assert.True(string.Equals(PSEventDataNoDetails.SelectedFieldsForQuery, selected, StringComparison.OrdinalIgnoreCase), "Incorrect nameOrTargetUri clause without optional parameters");

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

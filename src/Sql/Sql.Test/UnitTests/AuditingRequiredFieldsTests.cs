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

using Microsoft.Azure.Commands.Sql.Auditing.Cmdlet;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AuditingRequiredFieldsTests
    {
        private static readonly string[] TestRequiredFields =
        {
            "event_time",
            "action_id",
            "statement"
        };

        [Theory]
        [InlineData(typeof(SetAzSqlServerAudit))]
        [InlineData(typeof(SetAzSqlDatabaseAudit))]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RequiredFieldsParameterIsOptionalStringArray(Type cmdletType)
        {
            PropertyInfo property = cmdletType.GetProperty(nameof(SetAzSqlServerAudit.RequiredFields));

            Assert.NotNull(property);
            Assert.Equal(typeof(string[]), property.PropertyType);
            Assert.False(property.GetCustomAttribute<ParameterAttribute>().Mandatory);
            Assert.Null(property.GetCustomAttribute<ValidateNotNullAttribute>());
            ValidateCountAttribute validateCount = property.GetCustomAttribute<ValidateCountAttribute>();
            Assert.NotNull(validateCount);
            Assert.Equal(0, validateCount.MinLength);
            Assert.Equal(52, validateCount.MaxLength);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RequiredFieldsValidationAcceptsApiSupportedInputs()
        {
            AuditingRequiredFieldsValidator.Validate(CreateValidationModel(new[] { " EVENT_TIME ", "action_id" }));
            AuditingRequiredFieldsValidator.Validate(CreateValidationModel(Array.Empty<string>(), false));
            AuditingRequiredFieldsValidator.Validate(CreateValidationModel(new[] { "event_time" }, false, false));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RequiredFieldsValidationEnforcesApiLimits()
        {
            PSArgumentException countException = Assert.Throws<PSArgumentException>(() =>
                AuditingRequiredFieldsValidator.Validate(CreateValidationModel(Enumerable.Repeat("event_time", 53).ToArray())));
            Assert.Contains("maximum allowed number of 52 fields", countException.Message);

            PSArgumentException lengthException = Assert.Throws<PSArgumentException>(() =>
                AuditingRequiredFieldsValidator.Validate(CreateValidationModel(new[] { new string('a', 36) })));
            Assert.Contains("cannot exceed 35 characters", lengthException.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RequiredFieldsValidationRejectsInvalidApiInputs()
        {
            PSArgumentException monitorException = Assert.Throws<PSArgumentException>(() =>
                AuditingRequiredFieldsValidator.Validate(CreateValidationModel(new[] { "event_time" }, false, true)));
            Assert.Contains("isAzureMonitorTargetEnabled is set to true", monitorException.Message);

            PSArgumentException duplicateException = Assert.Throws<PSArgumentException>(() =>
                AuditingRequiredFieldsValidator.Validate(CreateValidationModel(new[] { " event_time ", "EVENT_TIME" })));
            Assert.Contains("Duplicate field names found: 'event_time'", duplicateException.Message);

            PSArgumentException invalidFieldException = Assert.Throws<PSArgumentException>(() =>
                AuditingRequiredFieldsValidator.Validate(CreateValidationModel(new[] { "invalid_field" })));
            Assert.Contains("Invalid audit field name 'invalid_field'", invalidFieldException.Message);

            PSArgumentException emptyException = Assert.Throws<PSArgumentException>(() =>
                AuditingRequiredFieldsValidator.Validate(CreateValidationModel(new string[] { null })));
            Assert.Contains("at least one valid field name", emptyException.Message);

            PSArgumentException whitespaceException = Assert.Throws<PSArgumentException>(() =>
                AuditingRequiredFieldsValidator.Validate(CreateValidationModel(new[] { " " })));
            Assert.Contains("at least one valid field name", whitespaceException.Message);

            PSArgumentException commaDelimitedException = Assert.Throws<PSArgumentException>(() =>
                AuditingRequiredFieldsValidator.Validate(CreateValidationModel(new[] { "event_time,action_id" })));
            Assert.Contains("Invalid audit field name 'event_time,action_id'", commaDelimitedException.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RequiredFieldsRoundTripsThroughSharedAuditAdapter()
        {
            var adapter = new TestServerAuditAdapter();
            var policy = new ExtendedServerBlobAuditingPolicy
            {
                State = BlobAuditingPolicyState.Disabled,
                RequiredFields = TestRequiredFields
            };

            ServerAuditModel model = adapter.ToModel(policy);
            ExtendedServerBlobAuditingPolicy roundTripPolicy = adapter.ToPolicy(model);

            Assert.Equal(TestRequiredFields, model.RequiredFields);
            Assert.Equal(TestRequiredFields, roundTripPolicy.RequiredFields);
            Assert.NotNull(typeof(DatabaseAuditModel).GetProperty(nameof(ServerAuditModel.RequiredFields)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AuditingPolicyModelsSerializeRequiredFields()
        {
            using (var client = new SqlManagementClient(new TokenCredentials("token")))
            {
                AssertRequiredFieldsSerialized(client, new ServerBlobAuditingPolicy { RequiredFields = TestRequiredFields }, TestRequiredFields);
                AssertRequiredFieldsSerialized(client, new ExtendedServerBlobAuditingPolicy { RequiredFields = TestRequiredFields }, TestRequiredFields);
                AssertRequiredFieldsSerialized(client, new DatabaseBlobAuditingPolicy { RequiredFields = TestRequiredFields }, TestRequiredFields);
                AssertRequiredFieldsSerialized(client, new ExtendedDatabaseBlobAuditingPolicy { RequiredFields = TestRequiredFields }, TestRequiredFields);
                AssertRequiredFieldsSerialized(client, new ServerBlobAuditingPolicy { RequiredFields = Array.Empty<string>() }, Array.Empty<string>());
                AssertRequiredFieldsSerialized(client, new ExtendedServerBlobAuditingPolicy { RequiredFields = Array.Empty<string>() }, Array.Empty<string>());
                AssertRequiredFieldsSerialized(client, new DatabaseBlobAuditingPolicy { RequiredFields = Array.Empty<string>() }, Array.Empty<string>());
                AssertRequiredFieldsSerialized(client, new ExtendedDatabaseBlobAuditingPolicy { RequiredFields = Array.Empty<string>() }, Array.Empty<string>());

                string serialized = SafeJsonConvert.SerializeObject(
                    new ServerBlobAuditingPolicy(),
                    client.SerializationSettings);

                Assert.Null(JObject.Parse(serialized)["properties"]?["requiredFields"]);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AuditingGetOperationsUse2026ApiAndDeserializeRequiredFields()
        {
            const string responseBody = @"{
                'id': '/subscriptions/subscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Sql/servers/server/auditingSettings/default',
                'name': 'default',
                'type': 'Microsoft.Sql/servers/auditingSettings',
                'properties': {
                    'state': 'Disabled',
                    'requiredFields': [ 'event_time', 'action_id', 'statement' ]
                }
            }";

            var handler = new StubHttpMessageHandler(responseBody);
            using (var httpClient = new HttpClient(handler))
            using (var client = new SqlManagementClient(new TokenCredentials("token"), httpClient, false))
            {
                client.BaseUri = new Uri("https://management.azure.com");
                client.SubscriptionId = "subscriptionId";

                ServerBlobAuditingPolicy serverPolicy = client.ServerBlobAuditingPolicies.Get("resourceGroup", "server");
                ExtendedServerBlobAuditingPolicy extendedServerPolicy = client.ExtendedServerBlobAuditingPolicies.Get("resourceGroup", "server");
                DatabaseBlobAuditingPolicy databasePolicy = client.DatabaseBlobAuditingPolicies.Get("resourceGroup", "server", "database");
                ExtendedDatabaseBlobAuditingPolicy extendedDatabasePolicy = client.ExtendedDatabaseBlobAuditingPolicies.Get("resourceGroup", "server", "database");

                Assert.Equal(TestRequiredFields, serverPolicy.RequiredFields);
                Assert.Equal(TestRequiredFields, extendedServerPolicy.RequiredFields);
                Assert.Equal(TestRequiredFields, databasePolicy.RequiredFields);
                Assert.Equal(TestRequiredFields, extendedDatabasePolicy.RequiredFields);
                Assert.Equal(4, handler.RequestUris.Count);
                Assert.All(handler.RequestUris, requestUri =>
                    Assert.Contains("api-version=2026-08-01-preview", requestUri.Query));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task AuditingPutOperationsUse2026ApiAndSerializeRequiredFields()
        {
            const string responseBody = @"{
                'id': '/subscriptions/subscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Sql/servers/server/auditingSettings/default',
                'name': 'default',
                'type': 'Microsoft.Sql/servers/auditingSettings',
                'properties': {
                    'state': 'Disabled',
                    'requiredFields': [ 'event_time', 'action_id', 'statement' ]
                }
            }";

            var handler = new StubHttpMessageHandler(responseBody);
            using (var httpClient = new HttpClient(handler))
            using (var client = new SqlManagementClient(new TokenCredentials("token"), httpClient, false))
            {
                client.BaseUri = new Uri("https://management.azure.com");
                client.SubscriptionId = "subscriptionId";

                await client.ServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                    "resourceGroup",
                    "server",
                    new ServerBlobAuditingPolicy { State = BlobAuditingPolicyState.Disabled, RequiredFields = TestRequiredFields });
                await client.ExtendedServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                    "resourceGroup",
                    "server",
                    new ExtendedServerBlobAuditingPolicy { State = BlobAuditingPolicyState.Disabled, RequiredFields = TestRequiredFields });
                await client.DatabaseBlobAuditingPolicies.CreateOrUpdateWithHttpMessagesAsync(
                    "resourceGroup",
                    "server",
                    "database",
                    new DatabaseBlobAuditingPolicy { State = BlobAuditingPolicyState.Disabled, RequiredFields = TestRequiredFields });
                await client.ExtendedDatabaseBlobAuditingPolicies.CreateOrUpdateWithHttpMessagesAsync(
                    "resourceGroup",
                    "server",
                    "database",
                    new ExtendedDatabaseBlobAuditingPolicy { State = BlobAuditingPolicyState.Disabled, RequiredFields = TestRequiredFields });
                await client.ServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                    "resourceGroup",
                    "server",
                    new ServerBlobAuditingPolicy { State = BlobAuditingPolicyState.Disabled, RequiredFields = Array.Empty<string>() });
                await client.ExtendedServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                    "resourceGroup",
                    "server",
                    new ExtendedServerBlobAuditingPolicy { State = BlobAuditingPolicyState.Disabled, RequiredFields = Array.Empty<string>() });
                await client.DatabaseBlobAuditingPolicies.CreateOrUpdateWithHttpMessagesAsync(
                    "resourceGroup",
                    "server",
                    "database",
                    new DatabaseBlobAuditingPolicy { State = BlobAuditingPolicyState.Disabled, RequiredFields = Array.Empty<string>() });
                await client.ExtendedDatabaseBlobAuditingPolicies.CreateOrUpdateWithHttpMessagesAsync(
                    "resourceGroup",
                    "server",
                    "database",
                    new ExtendedDatabaseBlobAuditingPolicy { State = BlobAuditingPolicyState.Disabled, RequiredFields = Array.Empty<string>() });

                Assert.Equal(8, handler.RequestUris.Count);
                Assert.All(handler.RequestUris, requestUri =>
                    Assert.Contains("api-version=2026-08-01-preview", requestUri.Query));
                Assert.All(handler.RequestMethods, requestMethod => Assert.Equal(HttpMethod.Put, requestMethod));
                Assert.All(handler.RequestBodies.Take(4), requestBody =>
                    Assert.Equal(
                        TestRequiredFields,
                        JObject.Parse(requestBody)["properties"]?["requiredFields"]?.Values<string>()));
                Assert.All(handler.RequestBodies.Skip(4), requestBody =>
                {
                    JToken requiredFields = JObject.Parse(requestBody)["properties"]?["requiredFields"];
                    Assert.Equal(JTokenType.Array, requiredFields?.Type);
                    Assert.Empty(requiredFields.Values<string>());
                });
            }
        }

        private static void AssertRequiredFieldsSerialized(
            SqlManagementClient client,
            object policy,
            IEnumerable<string> expectedRequiredFields)
        {
            string serialized = SafeJsonConvert.SerializeObject(policy, client.SerializationSettings);
            IEnumerable<string> requiredFields = JObject.Parse(serialized)["properties"]?["requiredFields"]?.Values<string>();

            Assert.Equal(expectedRequiredFields, requiredFields);
        }

        private static ServerAuditModel CreateValidationModel(
            string[] requiredFields,
            bool isAzureMonitorEnabled = true,
            bool isPolicyEnabled = true)
        {
            return new ServerAuditModel
            {
                RequiredFields = requiredFields,
                BlobStorageTargetState = isPolicyEnabled && !isAzureMonitorEnabled ? AuditStateType.Enabled : AuditStateType.Disabled,
                StorageAccountResourceId = isPolicyEnabled && !isAzureMonitorEnabled ? "storageAccountResourceId" : null,
                EventHubTargetState = AuditStateType.Disabled,
                LogAnalyticsTargetState = isPolicyEnabled && isAzureMonitorEnabled ? AuditStateType.Enabled : AuditStateType.Disabled,
                WorkspaceResourceId = isAzureMonitorEnabled ? "workspaceResourceId" : null
            };
        }

        private sealed class TestServerAuditAdapter : SqlUserAuditAdapter<ServerBlobAuditingPolicy, ExtendedServerBlobAuditingPolicy, ServerAuditModel>
        {
            public TestServerAuditAdapter()
                : base(null)
            {
            }

            public ServerAuditModel ToModel(ExtendedServerBlobAuditingPolicy policy)
            {
                var model = new ServerAuditModel();
                ModelizeAuditPolicy(model, policy);
                return model;
            }

            public ExtendedServerBlobAuditingPolicy ToPolicy(ServerAuditModel model)
            {
                var policy = new ExtendedServerBlobAuditingPolicy();
                PolicizeAuditModel(model, policy);
                return policy;
            }

            protected override ExtendedServerBlobAuditingPolicy GetAuditingPolicy(string resourceGroup, string serverName)
            {
                throw new NotSupportedException();
            }

            protected override bool SetAuditingPolicy(string resourceGroup, string serverName, ServerBlobAuditingPolicy policy)
            {
                throw new NotSupportedException();
            }

            protected override bool SetExtendedAuditingPolicy(string resourceGroup, string serverName, ExtendedServerBlobAuditingPolicy policy)
            {
                throw new NotSupportedException();
            }
        }

        private sealed class StubHttpMessageHandler : HttpMessageHandler
        {
            private readonly string responseBody;

            public StubHttpMessageHandler(string responseBody)
            {
                this.responseBody = responseBody;
            }

            public IList<Uri> RequestUris { get; } = new List<Uri>();

            public IList<HttpMethod> RequestMethods { get; } = new List<HttpMethod>();

            public IList<string> RequestBodies { get; } = new List<string>();

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestUris.Add(request.RequestUri);
                RequestMethods.Add(request.Method);
                RequestBodies.Add(request.Content == null ? null : await request.Content.ReadAsStringAsync());
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(responseBody),
                    RequestMessage = request
                };
            }
        }
    }
}

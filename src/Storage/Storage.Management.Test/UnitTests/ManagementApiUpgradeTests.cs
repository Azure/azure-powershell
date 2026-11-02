// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Management.Storage.Test.UnitTests
{
    public class ManagementApiUpgradeTests : IDisposable
    {
        private readonly RecordingHandler handler = new RecordingHandler();
        private readonly StorageManagementClient client;
        private readonly AzureRmProfile profile;
        private readonly MockCommandRuntime runtime = new MockCommandRuntime();

        public ManagementApiUpgradeTests()
        {
            AzureSessionInitializer.InitializeAzureSession();
            client = new StorageManagementClient(new TokenCredentials("offline"), handler)
            {
                SubscriptionId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            };
            profile = new AzureRmProfile
            {
                DefaultContext = new AzureContext(
                    new AzureSubscription { Id = client.SubscriptionId.ToString() },
                    new AzureAccount { Id = "offline" },
                    AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud])
            };
        }

        [Fact]
        public void NewAccountOmitsUnspecifiedPolicies()
        {
            NewAccount().ExecuteCmdlet();

            var properties = WriteBody("PUT")["properties"];
            foreach (var name in new[] { "allowSharedKeyAccessForServices", "allowCrossTenantDelegationSas",
                "sasPolicy", "dataCollaborationPolicyProperties", "turboTier" })
            {
                Assert.Null(properties?[name]);
            }
            Assert.All(handler.Requests, request => Assert.Contains("api-version=2026-09-01", request.Uri.Query));
        }

        [Fact]
        public void ExistingSmartTierAndCopyScopeValuesAreRetained()
        {
            var create = NewAccount();
            create.AccessTier = "Smart";
            create.AllowedCopyScope = "All";
            create.ExecuteCmdlet();
            Assert.Equal("Smart", WriteBody("PUT")["properties"]["accessTier"].Value<string>());
            Assert.Equal("All", WriteBody("PUT")["properties"]["allowedCopyScope"].Value<string>());

            var update = SetAccount();
            update.AccessTier = "Smart";
            update.AllowedCopyScope = "All";
            update.Force = true;
            update.ExecuteCmdlet();
            Assert.Equal("Smart", WriteBody("PATCH")["properties"]["accessTier"].Value<string>());
            Assert.Equal("All", WriteBody("PATCH")["properties"]["allowedCopyScope"].Value<string>());
        }

        [Fact]
        public void ExistingTagReplicationAndStaticWebsiteContractsAreRetained()
        {
            var replication = JsonConvert.DeserializeObject<ObjectReplicationPolicy>(
                "{\"properties\":{\"tagsReplication\":{\"enabled\":true}}}", client.DeserializationSettings);
            var replicationJson = JObject.Parse(JsonConvert.SerializeObject(replication, client.SerializationSettings));
            Assert.True(replicationJson["properties"]["tagsReplication"]["enabled"].Value<bool>());

            var service = JsonConvert.DeserializeObject<BlobServiceProperties>(
                "{\"properties\":{\"staticWebsite\":{\"enabled\":true,\"defaultIndexDocumentPath\":\"/index.html\"}}}",
                client.DeserializationSettings);
            var serviceJson = JObject.Parse(JsonConvert.SerializeObject(service, client.SerializationSettings));
            Assert.True(serviceJson["properties"]["staticWebsite"]["enabled"].Value<bool>());
            Assert.Equal("/index.html", serviceJson["properties"]["staticWebsite"]["defaultIndexDocumentPath"].Value<string>());
        }

        [Theory]
        [InlineData("AllowSharedKeyAccessForBlob", "blob")]
        [InlineData("AllowSharedKeyAccessForFile", "file")]
        [InlineData("AllowSharedKeyAccessForQueue", "queue")]
        [InlineData("AllowSharedKeyAccessForTable", "table")]
        public void NewAccountDistinguishesFalseFromOmitted(string parameter, string service)
        {
            var command = NewAccount();
            command.GetType().GetProperty(parameter).SetValue(command, false);
            command.AllowCrossTenantDelegationSas = false;
            command.AllowBlobAccessPoints = false;
            command.ExecuteCmdlet();

            var properties = WriteBody("PUT")["properties"];
            var access = (JObject)properties["allowSharedKeyAccessForServices"];
            Assert.Single(access.Properties());
            Assert.False(access[service]["enabled"].Value<bool>());
            Assert.False(properties["allowCrossTenantDelegationSas"].Value<bool>());
            var collaboration = (JObject)properties["dataCollaborationPolicyProperties"];
            Assert.Single(collaboration.Properties());
            Assert.False(collaboration["allowBlobAccessPoints"].Value<bool>());
        }

        [Fact]
        public void NewAccountSendsCanonicalPolicyValuesWithoutInventingTurboTarget()
        {
            var command = NewAccount();
            command.SasExpirationPeriod = TimeSpan.FromDays(2);
            command.RequireUserBoundUserDelegationSas = false;
            command.RequireUserBoundUserDelegationSasAction = "bLoCk";
            command.TurboTierStatus = "eNaBlEd";
            command.ExecuteCmdlet();

            var properties = WriteBody("PUT")["properties"];
            Assert.False(properties["sasPolicy"]["requireUserBoundUserDelegationSas"].Value<bool>());
            Assert.Equal("Block", properties["sasPolicy"]["requireUserBoundUserDelegationSasAction"].Value<string>());
            Assert.Equal("Enabled", properties["turboTier"]["status"].Value<string>());
            Assert.Null(properties["turboTier"]["targetPercent"]);
        }

        [Fact]
        public void UserBoundPolicyRequiresExpirationOnCreate()
        {
            var command = NewAccount();
            command.RequireUserBoundUserDelegationSas = true;
            Assert.Contains("SasExpirationPeriod", Assert.Throws<ArgumentException>(() => command.ExecuteCmdlet()).Message);
            Assert.All(handler.Requests, request => Assert.EndsWith("/checkNameAvailability", request.Uri.AbsolutePath));
        }

        [Fact]
        public void SharedKeyAndCollaborationUpdatesPreserveUnchangedFields()
        {
            handler.AccountProperties = JObject.Parse(@"{
                'allowSharedKeyAccessForServices': {
                    'blob': {'enabled': true}, 'file': {'enabled': true},
                    'queue': {'enabled': false}, 'table': {'enabled': true}},
                'dataCollaborationPolicyProperties': {
                    'allowBlobAccessPoints': true, 'allowStorageConnectors': true,
                    'allowStorageDataShares': false, 'allowCrossTenantDataSharing': true}}");
            var command = SetAccount();
            command.AllowSharedKeyAccessForBlob = false;
            command.AllowBlobAccessPoints = false;
            command.ExecuteCmdlet();

            var properties = WriteBody("PATCH")["properties"];
            var access = properties["allowSharedKeyAccessForServices"];
            Assert.False(access["blob"]["enabled"].Value<bool>());
            Assert.True(access["file"]["enabled"].Value<bool>());
            Assert.False(access["queue"]["enabled"].Value<bool>());
            Assert.True(access["table"]["enabled"].Value<bool>());
            var collaboration = properties["dataCollaborationPolicyProperties"];
            Assert.False(collaboration["allowBlobAccessPoints"].Value<bool>());
            Assert.True(collaboration["allowStorageConnectors"].Value<bool>());
            Assert.False(collaboration["allowStorageDataShares"].Value<bool>());
            Assert.True(collaboration["allowCrossTenantDataSharing"].Value<bool>());
        }

        [Fact]
        public void ExpirationUpdatePreservesUserBoundPolicy()
        {
            handler.AccountProperties = JObject.Parse(@"{
                'sasPolicy': {'sasExpirationPeriod': '1.00:00:00', 'expirationAction': 'Block',
                    'requireUserBoundUserDelegationSas': true, 'requireUserBoundUserDelegationSasAction': 'Block'}}");
            var command = SetAccount();
            command.SasExpirationPeriod = TimeSpan.FromDays(3);
            command.ExecuteCmdlet();

            var policy = WriteBody("PATCH")["properties"]["sasPolicy"];
            Assert.Equal("3.00:00:00", policy["sasExpirationPeriod"].Value<string>());
            Assert.Equal("Block", policy["expirationAction"].Value<string>());
            Assert.True(policy["requireUserBoundUserDelegationSas"].Value<bool>());
            Assert.Equal("Block", policy["requireUserBoundUserDelegationSasAction"].Value<string>());
        }

        [Fact]
        public void UserBoundUpdatePreservesExpirationAndExplicitFalse()
        {
            handler.AccountProperties = JObject.Parse(@"{
                'sasPolicy': {'sasExpirationPeriod': '4.00:00:00', 'expirationAction': 'Block',
                    'requireUserBoundUserDelegationSas': true, 'requireUserBoundUserDelegationSasAction': 'Log'}}");
            var command = SetAccount();
            command.RequireUserBoundUserDelegationSas = false;
            command.ExecuteCmdlet();

            var policy = WriteBody("PATCH")["properties"]["sasPolicy"];
            Assert.Equal("4.00:00:00", policy["sasExpirationPeriod"].Value<string>());
            Assert.Equal("Block", policy["expirationAction"].Value<string>());
            Assert.False(policy["requireUserBoundUserDelegationSas"].Value<bool>());
            Assert.Equal("Log", policy["requireUserBoundUserDelegationSasAction"].Value<string>());
        }

        [Fact]
        public void UserBoundUpdateWithoutExistingExpirationFailsBeforePatch()
        {
            var command = SetAccount();
            command.RequireUserBoundUserDelegationSasAction = "Block";
            Assert.Contains("SasExpirationPeriod", Assert.Throws<ArgumentException>(() => command.ExecuteCmdlet()).Message);
            Assert.All(handler.Requests, request => Assert.Equal("GET", request.Method));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TurboTierUpdatesPreserveTheOtherField(bool updateStatus)
        {
            handler.AccountProperties = JObject.Parse(@"{'turboTier': {'status': 'Enabled', 'targetPercent': 60}}");
            var command = SetAccount();
            if (updateStatus)
            {
                command.TurboTierStatus = "disabled";
            }
            else
            {
                command.TurboTierTargetPercent = 100;
            }
            command.ExecuteCmdlet();

            var tier = WriteBody("PATCH")["properties"]["turboTier"];
            Assert.Equal(updateStatus ? "Disabled" : "Enabled", tier["status"].Value<string>());
            Assert.Equal(updateStatus ? 60 : 100, tier["targetPercent"].Value<int>());
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        public void TurboTierBoundaryValuesAreSentWithoutAdjustment(int percent)
        {
            var command = NewAccount();
            command.TurboTierTargetPercent = percent;
            command.ExecuteCmdlet();
            Assert.Equal(percent, WriteBody("PUT")["properties"]["turboTier"]["targetPercent"].Value<int>());
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ContainerAttachmentRequiresNameAndPreservesOmission(bool create)
        {
            var command = ContainerCommand(create);
            command.GetType().GetProperty("BlobAccessPointConfigurationUniqueId").SetValue(command, "offline-id");
            Assert.Contains("BlobAccessPointConfigurationName",
                Assert.Throws<ArgumentException>(() => command.ExecuteCmdlet()).Message);
            Assert.Empty(handler.Requests);

            command.GetType().GetProperty("BlobAccessPointConfigurationUniqueId").SetValue(command, null);
            command.ExecuteCmdlet();
            Assert.Null(WriteBody(create ? "PUT" : "PATCH")["properties"]?["blobAccessPointConfiguration"]);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ContainerAttachmentIsSentOnCreateAndUpdate(bool create)
        {
            var command = ContainerCommand(create);
            command.GetType().GetProperty("BlobAccessPointConfigurationName").SetValue(command, "point");
            command.GetType().GetProperty("BlobAccessPointConfigurationUniqueId").SetValue(command, "offline-id");
            command.ExecuteCmdlet();

            var connection = WriteBody(create ? "PUT" : "PATCH")["properties"]["blobAccessPointConfiguration"];
            Assert.Equal("point", connection["blobAccessPointConfigurationName"].Value<string>());
            Assert.Equal("offline-id", connection["blobAccessPointConfigurationUniqueId"].Value<string>());
        }

        [Fact]
        public void GetAndListContainerProjectionsIncludeAttachment()
        {
            var connection = new BlobAccessPointConfigurationConnection("point", "offline-id");
            var id = "/subscriptions/sub/resourceGroups/group/providers/Microsoft.Storage/storageAccounts/offline/blobServices/default/containers/container";
            var get = new PSContainer(new BlobContainer(id: id, name: "container", blobAccessPointConfiguration: connection));
            var list = new PSContainer(new ListContainerItem(id: id, name: "container", blobAccessPointConfiguration: connection));
            Assert.Same(connection, get.BlobAccessPointConfiguration);
            Assert.Same(connection, list.BlobAccessPointConfiguration);
        }

        [Fact]
        public void CollaborationPolicyConstructorPreservesExistingArgumentOrder()
        {
            var policy = new StorageDataCollaborationPolicyProperties(true, false, true);
            Assert.True(policy.AllowStorageConnectors);
            Assert.False(policy.AllowStorageDataShares);
            Assert.True(policy.AllowCrossTenantDataSharing);
            Assert.Null(policy.AllowBlobAccessPoints);
        }

        [Theory]
        [InlineData(typeof(Microsoft.Azure.Management.Storage.Models.StorageAccount))]
        [InlineData(typeof(StorageAccountCreateParameters))]
        [InlineData(typeof(StorageAccountUpdateParameters))]
        [InlineData(typeof(StorageAccountProperties))]
        [InlineData(typeof(StorageAccountPropertiesCreateParameters))]
        [InlineData(typeof(StorageAccountPropertiesUpdateParameters))]
        public void NewAccountConstructorParametersAreAppended(Type type)
        {
            var constructor = Assert.Single(type.GetConstructors(), candidate => candidate.GetParameters().Length != 0);
            var parameters = constructor.GetParameters();
            Assert.Equal("turboTier", parameters[parameters.Length - 2].Name);
            Assert.Equal("allowCrossTenantDelegationSas", parameters[parameters.Length - 1].Name);
            Assert.True(parameters[parameters.Length - 2].IsOptional);
            Assert.True(parameters[parameters.Length - 1].IsOptional);
        }

        [Fact]
        public void ExistingTrackedResourceUpdateBaseTypesArePreserved()
        {
            Assert.Equal(typeof(AzureResourceManagerCommonTypesTrackedResourceUpdate), typeof(ConnectorUpdate).BaseType);
            Assert.Equal(typeof(AzureResourceManagerCommonTypesTrackedResourceUpdate), typeof(DataShareUpdate).BaseType);
        }

        [Fact]
        public void AccountPoliciesAreProjectedAndSharingInputsAreNotExposed()
        {
            handler.AccountProperties = JObject.Parse(@"{
                'allowCrossTenantDelegationSas': false, 'allowSharedKeyAccessForServices': {'blob': {'enabled': false}},
                'dataCollaborationPolicyProperties': {'allowBlobAccessPoints': true},
                'turboTier': {'status': 'Enabled', 'targetPercent': 20}}");
            NewAccount().ExecuteCmdlet();
            var output = Assert.IsType<PSStorageAccount>(Assert.Single(runtime.OutputPipeline));
            Assert.False(output.AllowCrossTenantDelegationSas);
            Assert.False(output.AllowSharedKeyAccessForServices.Blob.Enabled);
            Assert.True(output.AllowBlobAccessPoints);
            Assert.Equal(20, output.TurboTier.TargetPercent);
            foreach (var type in new[] { typeof(NewAzureStorageAccountCommand), typeof(SetAzureStorageAccountCommand) })
            {
                foreach (var name in new[] { "AllowStorageConnectors", "AllowStorageDataShares", "AllowCrossTenantDataSharing" })
                {
                    Assert.Null(type.GetProperty(name));
                }
                var range = (ValidateRangeAttribute)Attribute.GetCustomAttribute(type.GetProperty("TurboTierTargetPercent"), typeof(ValidateRangeAttribute));
                Assert.Equal(10, range.MinRange);
                Assert.Equal(100, range.MaxRange);
            }
        }

        private NewAzureStorageAccountCommand NewAccount()
        {
            return new NewAzureStorageAccountCommand
            {
                StorageClient = client, DefaultProfile = profile, CommandRuntime = runtime,
                ResourceGroupName = "group", Name = "offline", Location = "eastus",
                SkuName = "Standard_LRS", Kind = "StorageV2"
            };
        }

        private SetAzureStorageAccountCommand SetAccount()
        {
            return new SetAzureStorageAccountCommand
            {
                StorageClient = client, DefaultProfile = profile, CommandRuntime = runtime,
                ResourceGroupName = "group", Name = "offline"
            };
        }

        private StorageBlobBaseCmdlet ContainerCommand(bool create)
        {
            StorageBlobBaseCmdlet command = create
                ? (StorageBlobBaseCmdlet)new NewAzureStorageContainerCommand { ResourceGroupName = "group", StorageAccountName = "offline", Name = "container" }
                : new UpdateAzureStorageContainerCommand { ResourceGroupName = "group", StorageAccountName = "offline", Name = "container" };
            command.StorageClient = client;
            command.DefaultProfile = profile;
            command.CommandRuntime = runtime;
            return command;
        }

        private JObject WriteBody(string method)
        {
            return JObject.Parse(Assert.Single(handler.Requests, request => request.Method == method).Body);
        }

        public void Dispose()
        {
            client.Dispose();
        }

        private sealed class RecordedRequest
        {
            public string Method { get; set; }
            public Uri Uri { get; set; }
            public string Body { get; set; }
        }

        private sealed class RecordingHandler : DelegatingHandler
        {
            public readonly List<RecordedRequest> Requests = new List<RecordedRequest>();
            public JObject AccountProperties = new JObject();

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Requests.Add(new RecordedRequest
                {
                    Method = request.Method.Method,
                    Uri = request.RequestUri,
                    Body = request.Content == null ? null : await request.Content.ReadAsStringAsync()
                });
                if (request.RequestUri.AbsolutePath.EndsWith("/checkNameAvailability"))
                {
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        RequestMessage = request,
                        Content = new StringContent("{\"nameAvailable\":true}", System.Text.Encoding.UTF8, "application/json")
                    };
                }
                bool container = request.RequestUri.AbsolutePath.Contains("/containers/");
                var body = new JObject
                {
                    ["id"] = request.RequestUri.AbsolutePath,
                    ["name"] = container ? "container" : "offline",
                    ["type"] = container ? "Microsoft.Storage/storageAccounts/blobServices/containers" : "Microsoft.Storage/storageAccounts",
                    ["location"] = "eastus",
                    ["kind"] = "StorageV2",
                    ["sku"] = new JObject { ["name"] = "Standard_LRS", ["tier"] = "Standard" },
                    ["properties"] = container ? new JObject() : AccountProperties.DeepClone()
                };
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json")
                };
            }
        }
    }
}

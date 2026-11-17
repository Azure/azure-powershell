// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

extern alias BackupSdk;
extern alias CrrSdk;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using BackupClient = BackupSdk::Microsoft.Azure.Management.RecoveryServices.Backup.RecoveryServicesBackupClient;
using Sdk = BackupSdk::Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrClient = CrrSdk::Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.RecoveryServicesBackupClient;
using Crr = CrrSdk::Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.UnitTests
{
    public class SqlInstanceSnapshotCrrTests
    {
        private const string SubscriptionId = "11111111-1111-1111-1111-111111111111";
        private const string ContainerName = "VMAppContainer;compute;sql-rg;sql-vm";
        private const string ItemName = "SQLInstance;mssqlserver";
        private const string ItemId = "/subscriptions/" + SubscriptionId +
            "/resourceGroups/sql-rg/providers/Microsoft.RecoveryServices/vaults/test-vault" +
            "/backupFabrics/Azure/protectionContainers/" + ContainerName + "/protectedItems/" + ItemName;
        private const string RecoveryPointId = "123456789";
        private const string IdentityId = "/subscriptions/" + SubscriptionId +
            "/resourceGroups/identity-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/restore-identity";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SecondaryItemDeserializesAndProjectsSqlInstance()
        {
            using (var client = new CrrClient(new TokenCredentials("test-token")))
            {
                var resource = new JObject
                {
                    ["id"] = ItemId,
                    ["name"] = ItemName,
                    ["properties"] = new JObject
                    {
                        ["protectedItemType"] = "AzureVmWorkloadSQLInstance",
                        ["backupManagementType"] = "AzureWorkload",
                        ["workloadType"] = "SQLInstance",
                        ["friendlyName"] = "mssqlserver",
                        ["serverName"] = "sql-vm",
                        ["protectionState"] = "Protected",
                        ["protectionStatus"] = "Healthy",
                        ["protectedItemDataSourceId"] = "instance-datasource",
                        ["childDatabaseNameList"] = new JArray("db1", "db2"),
                        ["instanceProtectionReadiness"] = "Ready",
                        ["isArchiveEnabled"] = false,
                        ["isScheduledForDeferredDelete"] = false,
                        ["softDeleteRetentionPeriodInDays"] = 30
                    }
                };
                var item = JsonConvert.DeserializeObject<Crr.ProtectedItemResource>(
                    resource.ToString(), client.DeserializationSettings);

                Assert.IsType<Crr.AzureVmWorkloadSQLInstanceProtectedItem>(item.Properties);
                var result = Assert.IsType<AzureWorkloadSQLInstanceProtectedItem>(ConversionHelpers.GetItemModelCrr(item));
                Assert.Equal(WorkloadType.MSSQL, result.WorkloadType);
                Assert.Equal("instance-datasource", result.ProtectedItemDataSourceId);
                Assert.Equal(new[] { "db1", "db2" }, result.ChildDatabaseNameList);
                Assert.Equal("Ready", result.InstanceProtectionReadiness);
                Assert.Equal("sql-vm", result.ServerName);
                Assert.Equal(30, result.SoftDeleteRetentionPeriodInDays);
                Assert.Equal(ItemDeleteState.NotDeleted, result.DeleteState);
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("SQLInstance")]
        [InlineData("SQLDataBase")]
        public void SecondaryRecoveryPointPreservesSnapshotMetadataWithoutDataDirectories(string workload)
        {
            using (var client = new CrrClient(new TokenCredentials("test-token")))
            {
                var response = JsonConvert.DeserializeObject<Crr.RecoveryPointResource>(
                    RecoveryPoint(true).ToString(), client.DeserializationSettings);
                var item = CreateItem(workload);

                var result = Assert.IsType<AzureWorkloadRecoveryPoint>(
                    RecoveryPointConversions.GetPSAzureWorkloadRecoveryPointForSecondaryRegion(response, item));

                Assert.Equal(item.WorkloadType, result.WorkloadType);
                Assert.Null(result.DataDirectoryPaths);
                Assert.Equal("db1", Assert.Single(result.IncludedDatabases).DatasourceName);
                AssertSnapshot(result.SnapshotRecoveryPointInfo);
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(false, false, false)]
        [InlineData(false, true, false)]
        [InlineData(true, false, false)]
        [InlineData(true, true, false)]
        [InlineData(true, true, true)]
        public void SnapshotConfigurationReadsOnlySelectedRegion(bool secondary, bool byTime, bool listHasMetadata)
        {
            var primaryHandler = new SnapshotHandler(listHasMetadata);
            var secondaryHandler = new SnapshotHandler(listHasMetadata);
            using (var primary = new BackupClient(new TokenCredentials("test-token"), primaryHandler))
            using (var crr = new CrrClient(new TokenCredentials("test-token"), secondaryHandler))
            {
                primary.SubscriptionId = crr.SubscriptionId = SubscriptionId;
                AzureSessionInitializer.InitializeAzureSession();
                var originalFactory = AzureSession.Instance.ClientFactory;
                try
                {
                    AzureSession.Instance.ClientFactory = new MockClientFactory(null, new List<object> { primary, crr });
                    var adapter = new ServiceClientAdapter(new AzureContext
                    {
                        Subscription = new AzureSubscription { Id = SubscriptionId }
                    });
                    var command = new SnapshotConfigCommand(adapter)
                    {
                        UseSecondaryRegion = secondary,
                        RecoveryPoint = new AzureWorkloadRecoveryPoint
                        {
                            Id = ItemId + "/recoveryPoints/" + RecoveryPointId,
                            RecoveryPointId = RecoveryPointId
                        }
                    };

                    var info = byTime
                        ? command.GetSnapshotRecoveryPointInfoByTime("test-vault", "sql-rg", ItemId, DateTime.UtcNow)
                        : command.GetSnapshotRecoveryPointInfo("test-vault", "sql-rg");

                    AssertSnapshot(info);
                    var selected = secondary ? secondaryHandler : primaryHandler;
                    Assert.Empty(secondary ? primaryHandler.Requests : secondaryHandler.Requests);
                    Assert.Equal(byTime && !listHasMetadata ? 2 : 1, selected.Requests.Count);
                    foreach (var uri in selected.Requests)
                    {
                        Assert.Contains("api-version=" + (secondary ? "2021-11-15" : "2026-10-01"), uri.Query);
                        Assert.Contains("/vaults/test-vault/", uri.AbsolutePath);
                        Assert.Contains("/resourceGroups/sql-rg/", uri.AbsolutePath);
                    }
                    if (byTime)
                    {
                        string query = Uri.UnescapeDataString(selected.Requests[0].Query);
                        Assert.Contains("restorePointQueryType eq 'Snapshot'", query);
                        Assert.Contains("getLatestRPOnly eq 'True'", query);
                    }
                }
                finally
                {
                    AzureSession.Instance.ClientFactory = originalFactory;
                }
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("SnapshotAttachAndRecover", false)]
        [InlineData("SnapshotAttachAndRecover", true)]
        [InlineData("SnapshotAttach", false)]
        [InlineData("SnapshotAttach", true)]
        [InlineData("RecoveryUsingSnapshot", false)]
        [InlineData("RecoveryUsingSnapshot", true)]
        [InlineData("WorkloadRecovery", false)]
        public async Task CrrRestoreWirePayloadRetainsSnapshotFields(string recoveryMode, bool pointInTime)
        {
            bool snapshot = recoveryMode != "WorkloadRecovery";
            Sdk.AzureWorkloadSQLRestoreRequest source = pointInTime
                ? new Sdk.AzureWorkloadSQLPointInTimeRestoreRequest { PointInTime = new DateTime(2026, 10, 23, 8, 0, 0, DateTimeKind.Utc) }
                : new Sdk.AzureWorkloadSQLRestoreRequest();
            source.RecoveryMode = recoveryMode;
            source.RecoveryType = "AlternateLocation";
            source.TargetVirtualMachineId = "/subscriptions/" + SubscriptionId + "/resourceGroups/target-rg/providers/Microsoft.Compute/virtualMachines/target-vm";
            source.TargetInfo = new Sdk.TargetRestoreInfo
            {
                ContainerId = "target-container",
                TargetDirectoryMapping = snapshot ? new Dictionary<string, string> { { "all", "X:\\logs" } } : null
            };
            if (snapshot)
            {
                source.TargetResourceGroupName = "target-rg";
                source.UserAssignedManagedIdentityDetails = new Sdk.UserAssignedManagedIdentityDetails(
                    IdentityId, "restore-identity", new Sdk.UserAssignedIdentityProperties("client-id", "principal-id"));
                source.SnapshotRestoreParameters = new Sdk.SnapshotRestoreParameters(false, "2026-10-23T08:00:00Z",
                    new List<string> { "clashing-disk-id" });
                source.AlternateDirectoryPaths = new List<Sdk.SQLDataDirectoryMapping>
                {
                    new Sdk.SQLDataDirectoryMapping { MappingType = "DiskDrives", SourcePath = "E:\\", TargetPath = "X:\\" }
                };
            }

            string serialized = JsonConvert.SerializeObject(source);
            Crr.RestoreRequest request = pointInTime
                ? (Crr.RestoreRequest)JsonConvert.DeserializeObject<Crr.AzureWorkloadSQLPointInTimeRestoreRequest>(serialized)
                : JsonConvert.DeserializeObject<Crr.AzureWorkloadSQLRestoreRequest>(serialized);
            var handler = new RestoreHandler();
            using (var client = new CrrClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = SubscriptionId;
                var response = await client.CrossRegionRestore.BeginTriggerWithHttpMessagesAsync("secondary-region",
                    new Crr.CrrAccessToken(), request);

                Assert.Equal(HttpStatusCode.Accepted, response.Response.StatusCode);
                Assert.Equal("/operations/restore-operation", response.Response.Headers.Location.AbsolutePath);
                Assert.Equal(HttpMethod.Post, handler.Method);
                Assert.Contains("/locations/secondary-region/backupCrossRegionRestore", handler.Uri.AbsolutePath);
                Assert.Equal("?api-version=2021-11-15", handler.Uri.Query);
                JObject body = (JObject)handler.Body["restoreRequest"];
                Assert.Equal(pointInTime ? "AzureWorkloadSQLPointInTimeRestoreRequest" : "AzureWorkloadSQLRestoreRequest",
                    (string)body["objectType"]);
                Assert.Equal(recoveryMode, (string)body["recoveryMode"]);
                if (snapshot)
                {
                    Assert.Equal("target-rg", (string)body["targetResourceGroupName"]);
                    Assert.Equal(IdentityId, (string)body["userAssignedManagedIdentityDetails"]["identityArmId"]);
                    Assert.Equal("principal-id", (string)body["userAssignedManagedIdentityDetails"]["userAssignedIdentityProperties"]["principalId"]);
                    Assert.Equal("X:\\logs", (string)body["targetInfo"]["targetDirectoryMapping"]["all"]);
                    Assert.Equal("X:\\", (string)body["alternateDirectoryPaths"][0]["targetPath"]);
                    Assert.Equal("clashing-disk-id", (string)body["snapshotRestoreParameters"]["disksToDetachOnClash"][0]);
                    Assert.Equal(new DateTime(2026, 10, 23, 8, 0, 0, DateTimeKind.Utc),
                        (DateTime)body["snapshotRestoreParameters"]["logPointInTimeForDBRecovery"]);
                }
                else
                {
                    Assert.Null(body["targetResourceGroupName"]);
                    Assert.Null(body["userAssignedManagedIdentityDetails"]);
                    Assert.Null(body["snapshotRestoreParameters"]);
                }
                Assert.Equal(pointInTime, body["pointInTime"] != null);
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(false)]
        [InlineData(true)]
        public void SecondaryItemQuerySupportsSqlInstanceWithAndWithoutName(bool named)
        {
            var primaryHandler = new ItemHandler(false);
            var secondaryHandler = new ItemHandler(true);
            using (var primary = new BackupClient(new TokenCredentials("test-token"), primaryHandler))
            using (var crr = new CrrClient(new TokenCredentials("test-token"), secondaryHandler))
            {
                primary.SubscriptionId = crr.SubscriptionId = SubscriptionId;
                AzureSessionInitializer.InitializeAzureSession();
                var originalFactory = AzureSession.Instance.ClientFactory;
                try
                {
                    AzureSession.Instance.ClientFactory = new MockClientFactory(null, new List<object> { primary, crr });
                    var adapter = new ServiceClientAdapter(new AzureContext
                    {
                        Subscription = new AzureSubscription { Id = SubscriptionId }
                    });
                    var provider = new AzureWorkloadPsBackupProvider();
                    provider.Initialize(new Dictionary<Enum, object>
                    {
                        { VaultParams.VaultName, "test-vault" },
                        { VaultParams.ResourceGroupName, "sql-rg" },
                        { ItemParams.Container, null },
                        { ItemParams.ItemName, named ? ItemName : null },
                        { ItemParams.ProtectionStatus, (ItemProtectionStatus)0 },
                        { ItemParams.ProtectionState, (ItemProtectionState)0 },
                        { ItemParams.WorkloadType, WorkloadType.MSSQLInstance },
                        { PolicyParams.ProtectionPolicy, null },
                        { CRRParams.UseSecondaryRegion, true }
                    }, adapter);

                    var result = Assert.IsType<AzureWorkloadSQLInstanceProtectedItem>(
                        Assert.Single(provider.ListProtectedItems()));
                    Assert.Equal("instance-datasource", result.ProtectedItemDataSourceId);
                    Assert.Equal("db1", Assert.Single(result.ChildDatabaseNameList));
                    Assert.Single(secondaryHandler.Requests);
                    Assert.Contains("itemType eq 'SQLInstance'",
                        Uri.UnescapeDataString(secondaryHandler.Requests[0].Query));
                    Assert.Equal(named ? 1 : 0, primaryHandler.Requests.Count);
                    if (named)
                    {
                        Assert.IsType<AzureWorkloadSQLInstanceProtectedItemExtendedInfo>(result.ExtendedInfo);
                        Assert.Equal(3, result.ExtendedInfo.RecoveryPointCount);
                    }
                }
                finally
                {
                    AzureSession.Instance.ClientFactory = originalFactory;
                }
            }
        }

        private static ItemBase CreateItem(string workload)
        {
            return new ItemBase(new Sdk.ProtectedItemResource(ItemId, ItemName)
            {
                Properties = new Sdk.AzureVmWorkloadProtectedItem(backupManagementType: "AzureWorkload", workloadType: workload)
            }, ContainerName, ContainerType.AzureVMAppContainer)
            {
                WorkloadType = workload == "SQLInstance" ? WorkloadType.MSSQLInstance : WorkloadType.MSSQL
            };
        }

        private static JObject RecoveryPoint(bool metadata)
        {
            var properties = new JObject
            {
                ["objectType"] = "AzureWorkloadSQLRecoveryPoint",
                ["type"] = "SnapshotFull",
                ["recoveryPointTimeInUTC"] = "2026-10-23T08:00:00Z"
            };
            if (metadata)
            {
                properties["extendedInfo"] = JObject.Parse(@"{
                    'includedDatabases': [{'datasourceId':'db-id','datasourceName':'db1'}],
                    'snapshotRecoveryPointInfo': {
                        'snapshotResourceGroup':'snapshot-rg',
                        'sourceFilesystemInfo': [{
                            'volumeGuid':'volume-id', 'fileSystemType':'NTFS', 'label':'Data',
                            'accessPaths':['E:\\'], 'isOnStorageSpace':true,
                            'storageSpaceInfo': {'storagePoolUniqueId':'pool-id','virtualDiskUniqueId':'virtual-disk-id'},
                            'diskInfoList':[{'diskNumber':1,'lun':0,'managedDiskId':'disk-id','sizeInBytes':10737418240}]
                        }]
                    }
                }");
            }
            return new JObject
            {
                ["id"] = ItemId + "/recoveryPoints/" + RecoveryPointId,
                ["name"] = RecoveryPointId,
                ["properties"] = properties
            };
        }

        private static void AssertSnapshot(Sdk.SnapshotRecoveryPointInfo info)
        {
            Assert.NotNull(info);
            Assert.Equal("snapshot-rg", info.SnapshotResourceGroup);
            var filesystem = Assert.Single(info.SourceFilesystemInfo);
            Assert.Equal("E:\\", Assert.Single(filesystem.AccessPaths));
            Assert.Equal("pool-id", filesystem.StorageSpaceInfo.StoragePoolUniqueId);
            Assert.Equal("disk-id", Assert.Single(filesystem.DiskInfoList).ManagedDiskId);
            Assert.Equal(10737418240L, filesystem.DiskInfoList[0].SizeInBytes);
        }

        private sealed class SnapshotConfigCommand : GetAzureRmRecoveryServicesBackupWorkloadRecoveryConfig
        {
            public SnapshotConfigCommand(ServiceClientAdapter adapter)
            {
                ServiceClientAdapter = adapter;
            }
        }

        private sealed class SnapshotHandler : DelegatingHandler
        {
            private readonly bool listHasMetadata;
            public List<Uri> Requests { get; } = new List<Uri>();

            public SnapshotHandler(bool listHasMetadata)
            {
                this.listHasMetadata = listHasMetadata;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.Equal(HttpMethod.Get, request.Method);
                Requests.Add(request.RequestUri);
                bool detail = request.RequestUri.AbsolutePath.EndsWith("/" + RecoveryPointId);
                JObject response = detail ? RecoveryPoint(true) :
                    new JObject { ["value"] = new JArray(RecoveryPoint(listHasMetadata)) };
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(response.ToString(), Encoding.UTF8, "application/json")
                });
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task CrrControlOperationsRetainSupportedApiVersion()
        {
            var handler = new ControlOperationHandler();
            using (var client = new CrrClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = SubscriptionId;
                await client.AadProperties.GetWithHttpMessagesAsync("secondary-region");
                await client.RecoveryPoints.GetAccessTokenWithHttpMessagesAsync(
                    "test-vault", "sql-rg", "Azure", ContainerName, ItemName, RecoveryPointId,
                    new Crr.AADPropertiesResource());
                await client.CrrOperationStatus.GetWithHttpMessagesAsync("secondary-region", "operation-id");
                await client.CrrOperationResults.GetWithHttpMessagesAsync("secondary-region", "operation-id");
                await client.BackupCrrJobDetails.GetWithHttpMessagesAsync("secondary-region", ItemId, "job-id");
                await client.BackupCrrJobs.ListWithHttpMessagesAsync("secondary-region", ItemId);

                Assert.Equal(6, handler.Requests.Count);
                foreach (var uri in handler.Requests)
                {
                    Assert.Contains("api-version=2021-11-15", uri.Query);
                }
            }
        }

        private sealed class ControlOperationHandler : DelegatingHandler
        {
            public List<Uri> Requests { get; } = new List<Uri>();

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Requests.Add(request.RequestUri);
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent("{\"properties\":{},\"value\":[]}", Encoding.UTF8, "application/json")
                });
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("AzureStorage", "AzureFileShare", "2021-11-15")]
        [InlineData("AzureIaasVM", "VM", "2021-11-15")]
        [InlineData("AzureWorkload", "SQLDataBase", "2021-11-15")]
        [InlineData("AzureWorkload", "SAPHanaDatabase", "2021-11-15")]
        [InlineData("AzureWorkload", "SQLInstance", "2021-11-15")]
        public void SecondaryItemDiscoveryRetainsCrrContract(
            string managementType, string dataSourceType, string version)
        {
            var handler = new ControlOperationHandler();
            using (var client = new CrrClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = SubscriptionId;
                AzureSessionInitializer.InitializeAzureSession();
                var originalFactory = AzureSession.Instance.ClientFactory;
                try
                {
                    AzureSession.Instance.ClientFactory = new MockClientFactory(null, new List<object> { client });
                    var adapter = new ServiceClientAdapter(new AzureContext
                    {
                        Subscription = new AzureSubscription { Id = SubscriptionId }
                    });
                    var helper = new AzureWorkloadProviderHelper(adapter);

                    Assert.Empty(helper.ListProtectedItemsByContainerCrr(
                        "test-vault", "sql-rg", null, null, managementType, dataSourceType));
                    Assert.Contains("api-version=" + version, Assert.Single(handler.Requests).Query);
                    Assert.Equal("2021-11-15", client.ApiVersion);

                    Assert.Empty(adapter.ListProtectedItemCrr(null, vaultName: "test-vault", resourceGroupName: "sql-rg"));
                    Assert.Contains("api-version=2021-11-15", handler.Requests[1].Query);
                }
                finally
                {
                    AzureSession.Instance.ClientFactory = originalFactory;
                }
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("AzureStorage", "AzureFileShare", "Snapshot")]
        [InlineData("AzureIaasVM", "VM", "Snapshot")]
        [InlineData("AzureWorkload", "SAPHanaDatabase", "Full")]
        [InlineData("AzureWorkload", "SQLDataBase", "Snapshot")]
        [InlineData("AzureWorkload", "SQLInstance", "Snapshot")]
        public void SecondaryRecoveryPointQueriesRetainCrrContract(
            string managementType, string workload, string queryType)
        {
            var handler = new ControlOperationHandler();
            using (var client = new CrrClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = SubscriptionId;
                AzureSessionInitializer.InitializeAzureSession();
                var originalFactory = AzureSession.Instance.ClientFactory;
                try
                {
                    AzureSession.Instance.ClientFactory = new MockClientFactory(null, new List<object> { client });
                    var helper = new AzureWorkloadProviderHelper(new ServiceClientAdapter(new AzureContext
                    {
                        Subscription = new AzureSubscription { Id = SubscriptionId }
                    }));
                    ItemBase item = new ItemBase(new Sdk.ProtectedItemResource(ItemId, ItemName)
                    {
                        Properties = new Sdk.ProtectedItem(backupManagementType: managementType, workloadType: workload)
                    }, ContainerName, ContainerType.AzureVMAppContainer);
                    if (workload == "SQLInstance")
                    {
                        item = new AzureWorkloadSQLInstanceProtectedItem(new Sdk.ProtectedItemResource(ItemId, ItemName)
                        {
                            Properties = new Sdk.AzureVmWorkloadSQLInstanceProtectedItem(
                                backupManagementType: "AzureWorkload", workloadType: "SQLInstance")
                            {
                                ProtectionState = "Protected"
                            }
                        }, ContainerName, ContainerType.AzureVMAppContainer, null);
                        Assert.Equal(WorkloadType.MSSQL, item.WorkloadType);
                    }
                    var data = new Dictionary<Enum, object>
                    {
                        { VaultParams.VaultName, "test-vault" },
                        { VaultParams.ResourceGroupName, "sql-rg" },
                        { RecoveryPointParams.Item, item },
                        { RecoveryPointParams.StartDate, DateTime.UtcNow.AddDays(-1) },
                        { RecoveryPointParams.EndDate, DateTime.UtcNow },
                        { RecoveryPointParams.RestorePointQueryType, queryType },
                        { RecoveryPointParams.TargetTier, (RecoveryPointTier)0 },
                        { RecoveryPointParams.IsReadyForMove, false },
                        { RecoveryPointParams.Tier, (RecoveryPointTier)0 },
                        { CRRParams.UseSecondaryRegion, true }
                    };
                    Assert.Empty(helper.ListRecoveryPoints(data));
                    string query = Uri.UnescapeDataString(Assert.Single(handler.Requests).Query);
                    Assert.Contains("api-version=2021-11-15", query);
                    Assert.Contains("restorePointQueryType eq '" + queryType + "'", query);
                    Assert.Equal("2021-11-15", client.ApiVersion);
                }
                finally
                {
                    AzureSession.Instance.ClientFactory = originalFactory;
                }
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(false)]
        [InlineData(true)]
        public void SecondaryDatabaseParentMetadataPreservesCrrDetailContract(bool underInstance)
        {
            var handler = new SnapshotHandler(true);
            using (var client = new CrrClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = SubscriptionId;
                AzureSessionInitializer.InitializeAzureSession();
                var originalFactory = AzureSession.Instance.ClientFactory;
                try
                {
                    AzureSession.Instance.ClientFactory = new MockClientFactory(null, new List<object> { client });
                    var resource = new Crr.ProtectedItemResource(ItemId, ItemName)
                    {
                        Properties = new Crr.AzureVmWorkloadSQLDatabaseProtectedItem
                        {
                            BackupManagementType = "AzureWorkload",
                            WorkloadType = "SQLDataBase",
                            ProtectionState = "Protected",
                            ProtectionLevel = underInstance ? "DatabaseUnderInstance" : "Database",
                            ParentProtectedItem = underInstance ? ItemName : null
                        }
                    };
                    var item = Assert.IsType<AzureWorkloadSQLDatabaseProtectedItem>(ConversionHelpers.GetItemModelCrr(resource));
                    Assert.Equal(underInstance ? ItemName : null, item.ParentProtectedItem);
                    Assert.Equal(underInstance ? "DatabaseUnderInstance" : "Database", item.ProtectionLevel);
                    var helper = new AzureWorkloadProviderHelper(new ServiceClientAdapter(new AzureContext
                    {
                        Subscription = new AzureSubscription { Id = SubscriptionId }
                    }));
                    var data = new Dictionary<Enum, object>
                    {
                        { VaultParams.VaultName, "test-vault" },
                        { VaultParams.ResourceGroupName, "sql-rg" },
                        { RecoveryPointParams.Item, item },
                        { RecoveryPointParams.RecoveryPointId, RecoveryPointId },
                        { CRRParams.UseSecondaryRegion, true }
                    };

                    Assert.NotNull(helper.GetRecoveryPointDetails(data));
                    Assert.Contains("api-version=2021-11-15", Assert.Single(handler.Requests).Query);
                    Assert.Equal("2021-11-15", client.ApiVersion);
                }
                finally
                {
                    AzureSession.Instance.ClientFactory = originalFactory;
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SecondarySnapshotReadsPreserveSecondaryPointsAndPagination()
        {
            var handler = new PagedSnapshotHandler();
            using (var client = new CrrClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = SubscriptionId;
                client.BaseUri = new Uri("https://backup.example.test");
                AzureSessionInitializer.InitializeAzureSession();
                var originalFactory = AzureSession.Instance.ClientFactory;
                try
                {
                    AzureSession.Instance.ClientFactory = new MockClientFactory(null, new List<object> { client });
                    var adapter = new ServiceClientAdapter(new AzureContext
                    {
                        Subscription = new AzureSubscription { Id = SubscriptionId }
                    });
                    var points = adapter.GetRecoveryPointsFromSecondaryRegion(
                        ContainerName, ItemName, null, vaultName: "test-vault", resourceGroupName: "sql-rg");
                    Assert.Equal(new[] { RecoveryPointId, "secondary-next-page" }, points.Select(point => point.Name));
                    Assert.DoesNotContain(points, point => point.Name == "primary-only-rp");
                    foreach (var point in points)
                    {
                        var sqlPoint = Assert.IsType<Crr.AzureWorkloadSQLRecoveryPoint>(point.Properties);
                        Assert.NotNull(sqlPoint.ExtendedInfo.SnapshotRecoveryPointInfo);
                    }
                    Assert.Equal(2, handler.Requests.Count);
                    Assert.Contains("api-version=2021-11-15", handler.Requests[0].Query);
                    Assert.Equal(PagedSnapshotHandler.NextLink, handler.Requests[1].AbsoluteUri);
                    Assert.Equal("2021-11-15", client.ApiVersion);
                }
                finally
                {
                    AzureSession.Instance.ClientFactory = originalFactory;
                }
            }
        }

        private sealed class PagedSnapshotHandler : DelegatingHandler
        {
            public const string NextLink = "https://backup.example.test/next?api-version=2021-11-15&$skiptoken=next-page";
            public List<Uri> Requests { get; } = new List<Uri>();

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Requests.Add(request.RequestUri);
                var point = RecoveryPoint(true);
                if (Requests.Count > 1)
                {
                    point["name"] = "secondary-next-page";
                    point["id"] = ItemId + "/recoveryPoints/secondary-next-page";
                }
                var values = new JArray(point);
                if (request.RequestUri.Query.Contains("api-version=2026-10-01"))
                {
                    var primaryOnlyPoint = RecoveryPoint(true);
                    primaryOnlyPoint["name"] = "primary-only-rp";
                    primaryOnlyPoint["id"] = ItemId + "/recoveryPoints/primary-only-rp";
                    values.Add(primaryOnlyPoint);
                }
                var body = new JObject { ["value"] = values };
                if (Requests.Count == 1)
                {
                    body["nextLink"] = NextLink;
                }
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(body.ToString(), Encoding.UTF8, "application/json")
                });
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CrrAccessTokensAreSanitizedInRecordings()
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(
                typeof(ScenarioTests.RecoveryServicesBackupTestRunner).TypeHandle);
            const string token = "test-crr-access-token";
            var response = new JObject { ["properties"] = new JObject { ["accessTokenString"] = token } };
            var request = new JObject { ["crossRegionRestoreAccessDetails"] = response["properties"].DeepClone() };

            foreach (var body in new[] { request, response })
            {
                var sanitized = JObject.Parse(
                    Microsoft.Azure.Commands.TestFx.Recorder.RecorderUtilities.TryFormatJson(body.ToString()));
                Assert.Equal("Sanitized", (string)sanitized.SelectToken("$..accessTokenString"));
                Assert.DoesNotContain(token, sanitized.ToString());
            }
        }

        private sealed class ItemHandler : DelegatingHandler
        {
            private readonly bool list;
            public List<Uri> Requests { get; } = new List<Uri>();

            public ItemHandler(bool list)
            {
                this.list = list;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.Equal(HttpMethod.Get, request.Method);
                Assert.Contains("api-version=" + (list ? "2021-11-15" : "2026-10-01"), request.RequestUri.Query);
                Requests.Add(request.RequestUri);
                var item = JObject.Parse(@"{
                    'properties': {
                        'protectedItemType':'AzureVmWorkloadSQLInstance',
                        'backupManagementType':'AzureWorkload', 'workloadType':'SQLInstance',
                        'friendlyName':'mssqlserver', 'protectionState':'Protected', 'protectionStatus':'Healthy',
                        'protectedItemDataSourceId':'instance-datasource', 'childDatabaseNameList':['db1'],
                        'extendedInfo':{'recoveryPointCount':3,'policyState':'Consistent'}
                    }
                }");
                item["id"] = ItemId;
                item["name"] = ItemName;
                JObject body = list ? new JObject { ["value"] = new JArray(item) } : item;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(body.ToString(), Encoding.UTF8, "application/json")
                });
            }
        }

        private sealed class RestoreHandler : DelegatingHandler
        {
            public Uri Uri { get; private set; }
            public HttpMethod Method { get; private set; }
            public JObject Body { get; private set; }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Uri = request.RequestUri;
                Method = request.Method;
                Body = JObject.Parse(await request.Content.ReadAsStringAsync());
                var response = new HttpResponseMessage(HttpStatusCode.Accepted) { RequestMessage = request };
                response.Headers.Location = new Uri("https://management.azure.com/operations/restore-operation");
                return response;
            }
        }
    }
}

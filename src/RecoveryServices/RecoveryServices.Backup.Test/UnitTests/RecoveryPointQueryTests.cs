// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

extern alias BackupSdk;
extern alias CrrSdk;

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Net.Http;
using System.Reflection;
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
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json.Linq;
using Xunit;
using BackupClient = BackupSdk::Microsoft.Azure.Management.RecoveryServices.Backup.RecoveryServicesBackupClient;
using Sdk = BackupSdk::Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrClient = CrrSdk::Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.RecoveryServicesBackupClient;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.UnitTests
{
    public class RecoveryPointQueryTests
    {
        private const string SubscriptionId = "11111111-1111-1111-1111-111111111111";
        private const string ContainerName = "VMAppContainer;compute;sql-rg;sql-vm";
        private const string ItemName = "SQLDataBase;mssqlserver;newdb";
        private const string ItemId = "/subscriptions/" + SubscriptionId +
            "/resourceGroups/sql-rg/providers/Microsoft.RecoveryServices/vaults/test-vault" +
            "/backupFabrics/Azure/protectionContainers/" + ContainerName + "/protectedItems/" + ItemName;
        private static readonly DateTime RangeStart = new DateTime(2026, 10, 23, 8, 5, 21, DateTimeKind.Utc);
        private static readonly DateTime RangeEnd = new DateTime(2026, 10, 23, 8, 31, 22, DateTimeKind.Utc);

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryPointQueryAllowsOnlySingleTimeQueryTypes()
        {
            var property = typeof(GetAzureRmRecoveryServicesBackupRecoveryPoint)
                .GetProperty(nameof(GetAzureRmRecoveryServicesBackupRecoveryPoint.RestorePointQueryType));
            var validation = property.GetCustomAttribute<ValidateSetAttribute>();

            Assert.NotNull(validation);
            Assert.Equal(new[]
            {
                "Full", "Differential", "FullAndDifferential", "Incremental",
                "SnapshotFull", "SnapshotCopyOnlyFull", "Snapshot", "FullDifferentialAndSnapshot"
            }, validation.ValidValues);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("Log")]
        [InlineData("log")]
        [InlineData("All")]
        [InlineData("all")]
        public void RecoveryPointBindingRejectsRangeQueryTypes(string queryType)
        {
            var state = InitialSessionState.CreateDefault2();
            state.Commands.Add(new SessionStateCmdletEntry(
                "Get-TestRecoveryPoint", typeof(GetAzureRmRecoveryServicesBackupRecoveryPoint), null));
            using (var powershell = System.Management.Automation.PowerShell.Create(state))
            {
                powershell.AddCommand("Get-TestRecoveryPoint")
                    .AddParameter("Item", CreateItem())
                    .AddParameter("RestorePointQueryType", queryType);

                ParameterBindingException error = Assert.ThrowsAny<ParameterBindingException>(() => { powershell.Invoke(); });

                Assert.Contains("RestorePointQueryType", error.Message);
                Assert.Contains(queryType, error.Message);
                Assert.Contains("ParameterArgumentValidationError", error.ErrorRecord.FullyQualifiedErrorId);
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(false, false)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(true, true)]
        public void LogChainQueryPreservesRangesAndSnapshotFilters(bool snapshotFilters, bool secondaryRegion)
        {
            var data = new Dictionary<Enum, object>
            {
                { VaultParams.VaultName, "test-vault" },
                { VaultParams.ResourceGroupName, "sql-rg" },
                { RecoveryPointParams.Item, CreateItem() },
                { RecoveryPointParams.StartDate, RangeStart.AddHours(-1) },
                { RecoveryPointParams.EndDate, RangeEnd.AddHours(1) },
                { RecoveryPointParams.RestorePointQueryType, "Log" },
                { CRRParams.UseSecondaryRegion, secondaryRegion }
            };
            if (snapshotFilters)
            {
                data[RecoveryPointParams.BaseSnapshotRPId] = "930916508998274";
                data[RecoveryPointParams.BaseRPDatasourceId] = "598134931741184";
                data[RecoveryPointParams.RecoveryMode] = "SnapshotAttachAndRecover";
            }

            var handler = new LogRangeHandler();
            var crrHandler = new LogRangeHandler();
            using (var client = new BackupClient(new TokenCredentials("test-token"), handler))
            using (var crrClient = new CrrClient(new TokenCredentials("test-token"), crrHandler))
            {
                client.SubscriptionId = SubscriptionId;
                crrClient.SubscriptionId = SubscriptionId;
                if (secondaryRegion)
                {
                    handler = crrHandler;
                }
                AzureSessionInitializer.InitializeAzureSession();
                var originalFactory = AzureSession.Instance.ClientFactory;
                try
                {
                    AzureSession.Instance.ClientFactory = new MockClientFactory(null, new List<object> { client, crrClient });
                    var context = new AzureContext
                    {
                        Subscription = new AzureSubscription { Id = SubscriptionId }
                    };
                    var helper = new AzureWorkloadProviderHelper(new ServiceClientAdapter(context));

                    PointInTimeBase range = Assert.Single(helper.ListLogChains(data));

                    Assert.Equal(RangeStart, range.StartTime);
                    Assert.Equal(RangeEnd, range.EndTime);
                    Assert.Equal(ItemName, range.ItemName);
                    Assert.Equal(ItemId + "/recoveryPoints", Uri.UnescapeDataString(handler.RequestUri.AbsolutePath).TrimEnd('/'));
                    string query = Uri.UnescapeDataString(handler.RequestUri.Query);
                    Assert.Contains("api-version=" + (secondaryRegion ? "2021-11-15" : "2026-10-01"), query);
                    Assert.Contains("restorePointQueryType eq 'Log'", query);
                    if (snapshotFilters)
                    {
                        Assert.Contains("recoveryMode eq 'SnapshotAttachAndRecover'", query);
                        Assert.Contains("baseRPDatasourceId eq '598134931741184'", query);
                        Assert.Contains("baseSnapshotRPId eq '930916508998274'", query);
                        Assert.DoesNotContain("baseRpDatasourceId", query);
                        Assert.DoesNotContain("baseSnapshotRpId", query);
                    }
                    else
                    {
                        Assert.DoesNotContain("recoveryMode", query);
                        Assert.DoesNotContain("baseRPDatasourceId", query);
                        Assert.DoesNotContain("baseSnapshotRPId", query);
                    }
                }
                finally
                {
                    AzureSession.Instance.ClientFactory = originalFactory;
                }
            }
        }

        private static ItemBase CreateItem()
        {
            return new ItemBase(new Sdk.ProtectedItemResource(ItemId, ItemName)
            {
                Properties = new Sdk.AzureVmWorkloadSQLDatabaseProtectedItem(
                    backupManagementType: "AzureWorkload", workloadType: "SQLDataBase")
            }, ContainerName, ContainerType.AzureVMAppContainer);
        }

        private sealed class LogRangeHandler : DelegatingHandler
        {
            public Uri RequestUri { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.Equal(HttpMethod.Get, request.Method);
                RequestUri = request.RequestUri;
                var body = new JObject
                {
                    ["value"] = new JArray(new JObject
                    {
                        ["id"] = ItemId + "/recoveryPoints/DefaultRangeRecoveryPoint",
                        ["name"] = "DefaultRangeRecoveryPoint",
                        ["properties"] = new JObject
                        {
                            ["objectType"] = "AzureWorkloadSQLPointInTimeRecoveryPoint",
                            ["type"] = "Log",
                            ["timeRanges"] = new JArray(new JObject
                            {
                                ["startTime"] = RangeStart,
                                ["endTime"] = RangeEnd
                            })
                        }
                    })
                };
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(body.ToString(), Encoding.UTF8, "application/json")
                });
            }
        }
    }
}

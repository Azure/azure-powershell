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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;
using BackupClient = BackupSdk::Microsoft.Azure.Management.RecoveryServices.Backup.RecoveryServicesBackupClient;
using Sdk = BackupSdk::Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.UnitTests
{
    public class PolicyRoundTripTests
    {
        private static readonly DateTime RunTime = new DateTime(2026, 10, 23, 2, 0, 0, DateTimeKind.Utc);
        private readonly ITestOutputHelper output;

        public PolicyRoundTripTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("SnapshotV2", "SQLInstance", "Schedule", true)]
        [InlineData("SnapshotV2", "SQLInstance", "Retention", true)]
        [InlineData("SnapshotV2", "SQLInstance", "Consistency", true)]
        [InlineData(null, "SQLInstance", "Schedule", true)]
        [InlineData(null, "SQLInstance", "Retention", true)]
        [InlineData(null, "SQLInstance", "Consistency", true)]
        [InlineData("Streaming", "SQLDataBase", "Schedule", true)]
        [InlineData("Streaming", "SQLDataBase", "Retention", true)]
        [InlineData("Streaming", "SQLDataBase", "Consistency", true)]
        [InlineData(null, "SQLDataBase", "Schedule", true)]
        [InlineData(null, "SQLDataBase", "Retention", true)]
        [InlineData(null, "SQLDataBase", "Consistency", true)]
        [InlineData("SnapshotV2", "SQLInstance", "Schedule", false)]
        [InlineData("SnapshotV2", "SQLInstance", "Retention", false)]
        [InlineData("SnapshotV2", "SQLInstance", "Consistency", false)]
        [InlineData(null, "SQLInstance", "Schedule", false)]
        [InlineData(null, "SQLInstance", "Retention", false)]
        [InlineData(null, "SQLInstance", "Consistency", false)]
        public void SqlPolicyUpdatePreservesSnapshotSettings(string policyType, string workloadType, string change, bool logsEnabled)
        {
            bool snapshot = workloadType == "SQLInstance" || policyType == "SnapshotV2";
            var details = snapshot ? new Sdk.SnapshotBackupAdditionalDetails
            {
                InstantRpRetentionRangeInDays = 2,
                InstantRpDetails = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/snapshot-rg",
                UserAssignedManagedIdentityDetails = new Sdk.UserAssignedManagedIdentityDetails
                {
                    IdentityArmId = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/identity-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/snapshot-identity",
                    IdentityName = "snapshot-identity",
                    UserAssignedIdentityProperties = new Sdk.UserAssignedIdentityProperties
                    {
                        ClientId = "22222222-2222-2222-2222-222222222222",
                        PrincipalId = "33333333-3333-3333-3333-333333333333"
                    }
                }
            } : null;
            var source = new Sdk.AzureVmWorkloadProtectionPolicy
            {
                WorkLoadType = workloadType,
                VMWorkloadPolicyType = policyType,
                Settings = new Sdk.Settings("UTC", true, true),
                SubProtectionPolicy = new List<Sdk.SubProtectionPolicy>
                {
                    new Sdk.SubProtectionPolicy
                    {
                        PolicyType = snapshot ? "SnapshotFull" : "Full",
                        SchedulePolicy = CreateServiceSchedule(),
                        RetentionPolicy = CreateServiceRetention(),
                        SnapshotBackupAdditionalDetails = details
                    },
                    new Sdk.SubProtectionPolicy
                    {
                        PolicyType = "Log",
                        SchedulePolicy = new Sdk.LogSchedulePolicy { ScheduleFrequencyInMins = 15 },
                        RetentionPolicy = new Sdk.SimpleRetentionPolicy
                        {
                            RetentionDuration = new Sdk.RetentionDuration { Count = 7, DurationType = "Days" }
                        }
                    }
                }
            };
            if (!logsEnabled)
            {
                source.SubProtectionPolicy.RemoveAt(1);
            }
            var policy = Assert.IsType<AzureVmWorkloadPolicy>(
                ConversionHelpers.GetPolicyModelForAzureVmWorkload(
                    new Sdk.ProtectionPolicyResource { Properties = source }, null));
            policy.Name = "test-policy";
            Assert.Equal(policyType, policy.VMWorkloadPolicyType);
            Assert.Same(details, policy.SnapshotBackupAdditionalDetails);

            var updates = new Dictionary<Enum, object>
            {
                { PolicyParams.IsSmartTieringEnabled, true },
                { PolicyParams.ExistingPolicy, new Sdk.ProtectionPolicyResource { Properties = source } },
                { ResourceGuardParams.IsMUAOperation, true }
            };
            if (change == "Schedule")
            {
                updates[PolicyParams.SchedulePolicy] = new SQLSchedulePolicy
                {
                    FullBackupSchedulePolicy = new SimpleSchedulePolicy
                    {
                        ScheduleRunFrequency = ScheduleRunType.Daily,
                        ScheduleRunTimes = new List<DateTime> { RunTime.AddHours(1) },
                        ScheduleRunTimeZone = "UTC"
                    },
                    IsLogBackupEnabled = policy.IsLogBackupEnabled,
                    LogBackupSchedulePolicy = (LogSchedulePolicy)policy.LogBackupSchedulePolicy,
                    IsCompression = policy.IsCompression
                };
            }
            else if (change == "Retention")
            {
                var retention = (LongTermRetentionPolicy)policy.FullBackupRetentionPolicy;
                retention.DailySchedule.DurationCountInDays = 60;
                updates[PolicyParams.RetentionPolicy] = new SQLRetentionPolicy
                {
                    FullBackupRetentionPolicy = retention,
                    LogBackupRetentionPolicy = (SimpleRetentionPolicy)policy.LogBackupRetentionPolicy
                };
            }
            else
            {
                updates[PolicyParams.FixForInconsistentItems] = true;
            }

            JObject properties = ModifyPolicy(policy, updates);
            Assert.Equal(policyType, (string)properties["vmWorkloadPolicyType"]);
            Assert.Equal(source.WorkLoadType, (string)properties["workLoadType"]);
            var subPolicies = Assert.IsType<JArray>(properties["subProtectionPolicy"]);
            JObject full = subPolicies.Children<JObject>().Single(p => (string)p["policyType"] != "Log");
            Assert.Equal(snapshot ? "SnapshotFull" : "Full", (string)full["policyType"]);
            if (snapshot)
            {
                Assert.Null(full["tieringPolicy"]);
                Assert.True(JToken.DeepEquals(JObject.FromObject(details), full["snapshotBackupAdditionalDetails"]));
            }
            else
            {
                Assert.Null(full["snapshotBackupAdditionalDetails"]);
                Assert.NotNull(full["tieringPolicy"]);
            }

            if (logsEnabled)
            {
                JObject log = Assert.Single(subPolicies.Children<JObject>(), p => (string)p["policyType"] == "Log");
                Assert.Equal(15, (int)log["schedulePolicy"]["scheduleFrequencyInMins"]);
                Assert.Equal(7, (int)log["retentionPolicy"]["retentionDuration"]["count"]);
            }
            else
            {
                Assert.DoesNotContain(subPolicies.Children<JObject>(), p => (string)p["policyType"] == "Log");
            }
            Assert.Equal(change == "Retention" ? 60 : 30,
                (int)full["retentionPolicy"]["dailySchedule"]["retentionDuration"]["count"]);
            Assert.Equal(change == "Schedule" ? RunTime.AddHours(1) : RunTime,
                (DateTime)full["schedulePolicy"]["scheduleRunTimes"][0]);
            Assert.Equal(change == "Consistency", (bool?)properties["makePolicyConsistent"] ?? false);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(false, true, 60)]
        [InlineData(false, true, 300)]
        [InlineData(false, false, 120)]
        [InlineData(false, false, null)]
        [InlineData(false, null, null)]
        [InlineData(false, null, 120)]
        [InlineData(true, true, 60)]
        [InlineData(true, true, 300)]
        [InlineData(true, false, 120)]
        [InlineData(true, false, null)]
        [InlineData(true, null, null)]
        [InlineData(true, null, 120)]
        public void VmPolicyUpdatePreservesInstantAccessSettings(bool enhanced, bool? enabled, int? minutes)
        {
            var source = new Sdk.AzureIaaSVMProtectionPolicy
            {
                PolicyType = enhanced ? "V2" : null,
                SchedulePolicy = enhanced
                    ? (Sdk.SchedulePolicy)new Sdk.SimpleSchedulePolicyV2
                    {
                        ScheduleRunFrequency = "Daily",
                        DailySchedule = new Sdk.DailySchedule
                        {
                            ScheduleRunTimes = new List<DateTime?> { RunTime }
                        }
                    }
                    : CreateServiceSchedule(),
                RetentionPolicy = CreateServiceRetention(),
                TimeZone = "UTC",
                InstantRpRetentionRangeInDays = 2,
                InstantRpDetails = new Sdk.InstantRPAdditionalDetails("snapshot", "rg"),
                InstantAccessSnapshotEnabled = enabled,
                InstantAccessDurationMinutes = minutes
            };
            var policy = Assert.IsType<AzureVmPolicy>(
                ConversionHelpers.GetPolicyModelForAzureIaaSVM(
                    new Sdk.ProtectionPolicyResource { Properties = source }, null));
            policy.Name = "test-policy";
            Assert.Equal(enabled, policy.InstantAccessSnapshotEnabled);
            Assert.Equal(minutes, policy.InstantAccessDurationMinutes);
            var retention = (LongTermRetentionPolicy)policy.RetentionPolicy;
            retention.DailySchedule.DurationCountInDays = 60;

            JObject properties = ModifyPolicy(policy, new Dictionary<Enum, object>
            {
                { PolicyParams.RetentionPolicy, retention }
            });
            Assert.Equal(enabled, (bool?)properties["instantAccessSnapshotEnabled"]);
            Assert.Equal(minutes, (int?)properties["instantAccessDurationMinutes"]);
            Assert.Equal(2, (int)properties["instantRpRetentionRangeInDays"]);
            Assert.Equal(60, (int)properties["retentionPolicy"]["dailySchedule"]["retentionDuration"]["count"]);
            Assert.Equal(enhanced ? "V2" : null, (string)properties["policyType"]);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("SnapshotFull", "Daily", null, 1440)]
        [InlineData("Full", "Daily", null, 1440)]
        [InlineData("Full", "Weekly", null, 5760)]
        [InlineData("SnapshotFull", "Daily", "Log", 15)]
        [InlineData("Full", "Weekly", "Log", 15)]
        [InlineData("Full", "Weekly", "Differential", 4320)]
        [InlineData("Full", "Weekly", "Incremental", 4320)]
        public void WorkloadPolicyRpoHandlesOptionalSubPolicies(
            string fullPolicyType, string frequency, string additionalPolicy, int expectedMinutes)
        {
            var helper = new AzureWorkloadProviderHelper(null);
            var policy = CreateRpoPolicy(fullPolicyType, frequency, additionalPolicy);

            Assert.Equal(TimeSpan.FromMinutes(expectedMinutes).Ticks, helper.calculateRPO(policy));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("SnapshotFull", true)]
        [InlineData("Full", false)]
        [InlineData("Full", true)]
        public void WorkloadPolicyRpoIncreaseRequiresMua(string fullPolicyType, bool removeLogs)
        {
            var helper = new AzureWorkloadProviderHelper(null);
            string frequency = fullPolicyType == "SnapshotFull" ? "Daily" : "Weekly";
            var oldPolicy = CreateRpoPolicy(fullPolicyType, frequency, removeLogs ? "Log" : null);
            var newPolicy = CreateRpoPolicy(fullPolicyType, frequency, null);
            if (!removeLogs)
            {
                var full = ((Sdk.AzureVmWorkloadProtectionPolicy)newPolicy.Properties).SubProtectionPolicy[0];
                ((Sdk.SimpleSchedulePolicy)full.SchedulePolicy).ScheduleRunDays =
                    new List<Sdk.DayOfWeek?> { Sdk.DayOfWeek.Monday };
            }

            Assert.Equal(
                (removeLogs ? TimeSpan.FromMinutes(15) : TimeSpan.FromDays(4)).Ticks,
                helper.calculateRPO(oldPolicy));
            int expectedDays = fullPolicyType == "SnapshotFull" ? 1 : removeLogs ? 4 : 7;
            Assert.Equal(TimeSpan.FromDays(expectedDays).Ticks, helper.calculateRPO(newPolicy));
            Assert.True(helper.checkMUAForModifyPolicy(oldPolicy, newPolicy, true));
            Assert.False(helper.checkMUAForModifyPolicy(newPolicy, oldPolicy, true));
            Assert.False(helper.checkMUAForModifyPolicy(oldPolicy, newPolicy, false));
        }

        private static Sdk.ProtectionPolicyResource CreateRpoPolicy(
            string fullPolicyType, string frequency, string additionalPolicy)
        {
            var schedule = CreateServiceSchedule();
            schedule.ScheduleRunFrequency = frequency;
            if (frequency == "Weekly")
            {
                schedule.ScheduleRunDays = new List<Sdk.DayOfWeek?>
                {
                    Sdk.DayOfWeek.Monday, Sdk.DayOfWeek.Thursday
                };
            }

            var subPolicies = new List<Sdk.SubProtectionPolicy>
            {
                new Sdk.SubProtectionPolicy
                {
                    PolicyType = fullPolicyType,
                    SchedulePolicy = schedule,
                    RetentionPolicy = CreateServiceRetention()
                }
            };
            if (additionalPolicy != null)
            {
                subPolicies.Add(new Sdk.SubProtectionPolicy
                {
                    PolicyType = additionalPolicy,
                    SchedulePolicy = additionalPolicy == "Log"
                        ? (Sdk.SchedulePolicy)new Sdk.LogSchedulePolicy { ScheduleFrequencyInMins = 15 }
                        : new Sdk.SimpleSchedulePolicy
                        {
                            ScheduleRunFrequency = "Weekly",
                            ScheduleRunDays = new List<Sdk.DayOfWeek?> { Sdk.DayOfWeek.Saturday }
                        },
                    RetentionPolicy = new Sdk.SimpleRetentionPolicy
                    {
                        RetentionDuration = new Sdk.RetentionDuration { Count = 7, DurationType = "Days" }
                    }
                });
            }
            return new Sdk.ProtectionPolicyResource
            {
                Properties = new Sdk.AzureVmWorkloadProtectionPolicy
                {
                    WorkLoadType = fullPolicyType == "SnapshotFull" ? "SQLInstance" : "SQLDataBase",
                    SubProtectionPolicy = subPolicies
                }
            };
        }

        private static Sdk.SimpleSchedulePolicy CreateServiceSchedule()
        {
            return new Sdk.SimpleSchedulePolicy
            {
                ScheduleRunFrequency = "Daily",
                ScheduleRunTimes = new List<DateTime?> { RunTime }
            };
        }

        private static Sdk.LongTermRetentionPolicy CreateServiceRetention()
        {
            return new Sdk.LongTermRetentionPolicy
            {
                DailySchedule = new Sdk.DailyRetentionSchedule
                {
                    RetentionTimes = new List<DateTime?> { RunTime },
                    RetentionDuration = new Sdk.RetentionDuration { Count = 30, DurationType = "Days" }
                }
            };
        }

        private JObject ModifyPolicy(PolicyBase policy, Dictionary<Enum, object> updates)
        {
            policy.Id = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/test-rg/providers/Microsoft.RecoveryServices/vaults/test-vault/backupPolicies/test-policy";
            var data = new Dictionary<Enum, object>
            {
                { VaultParams.VaultName, "test-vault" },
                { VaultParams.ResourceGroupName, "test-rg" },
                { PolicyParams.ProtectionPolicy, policy },
                { PolicyParams.BackupSnapshotResourceGroup, null },
                { PolicyParams.BackupSnapshotResourceGroupSuffix, null },
                { PolicyParams.SnapshotConsistencyType, default(SnapshotConsistencyType) }
            };
            foreach (var update in updates)
            {
                data[update.Key] = update.Value;
            }

            var handler = new PolicyUpdateHandler();
            using (var client = new BackupClient(new TokenCredentials("test-token"), handler))
            {
                client.SubscriptionId = "11111111-1111-1111-1111-111111111111";
                AzureSessionInitializer.InitializeAzureSession();
                var originalFactory = AzureSession.Instance.ClientFactory;
                var originalLogger = Logger.Instance;
                try
                {
                    Logger.Instance = new Logger(output.WriteLine, output.WriteLine, output.WriteLine,
                        error => throw error.Exception, error => throw error.Exception);
                    AzureSession.Instance.ClientFactory = new MockClientFactory(null, new List<object> { client });
                    var context = new AzureContext
                    {
                        Subscription = new AzureSubscription { Id = client.SubscriptionId }
                    };
                    var adapter = new ServiceClientAdapter(context);
                    IPsBackupProvider provider = policy is AzureVmPolicy
                        ? (IPsBackupProvider)new IaasVmPsBackupProvider()
                        : new AzureWorkloadPsBackupProvider();
                    provider.Initialize(data, adapter);
                    provider.ModifyPolicy();

                    Assert.Equal(HttpMethod.Put, handler.RequestMethod);
                    Assert.Equal("/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/test-rg/providers/Microsoft.RecoveryServices/vaults/test-vault/backupPolicies/test-policy",
                        handler.RequestUri.AbsolutePath);
                    Assert.Equal("?api-version=2026-10-01", handler.RequestUri.Query);
                    return Assert.IsType<JObject>(JObject.Parse(handler.RequestBody)["properties"]);
                }
                finally
                {
                    AzureSession.Instance.ClientFactory = originalFactory;
                    Logger.Instance = originalLogger;
                }
            }
        }

        private sealed class PolicyUpdateHandler : DelegatingHandler
        {
            public Uri RequestUri { get; private set; }
            public HttpMethod RequestMethod { get; private set; }
            public string RequestBody { get; private set; }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestUri = request.RequestUri;
                RequestMethod = request.Method;
                RequestBody = await request.Content.ReadAsStringAsync();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(RequestBody, Encoding.UTF8, "application/json")
                };
            }
        }
    }
}

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

using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class AuditingTests : SqlTestsBase
    {
        protected override void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlClient = GetSqlClient(context);
            var storageV2Client = GetStorageManagementClient(context);
            var newResourcesClient = GetResourcesClient(context);
            var monitorManagementClient = GetMonitorManagementClient(context);
            var commonMonitorManagementClient = GetCommonMonitorManagementClient(context);
            var eventHubManagementClient = GetEventHubManagementClient(context);
            var operationalInsightsManagementClient = GetOperationalInsightsManagementClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, storageV2Client, storageV2Client,
                newResourcesClient, monitorManagementClient, commonMonitorManagementClient,
                eventHubManagementClient, operationalInsightsManagementClient);
        }

        public AuditingTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingServerUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-BlobAuditingServerUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDisableDatabaseAuditing()
        {
            RunPowerShellTest("Test-BlobAuditingDisableDatabaseAuditing");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDisableServerAuditing()
        {
            RunPowerShellTest("Test-BlobAuditingDisableServerAuditing");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingFailedDatabaseUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-BlobAuditingFailedDatabaseUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingFailedServerUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-BlobAuditingFailedServerUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingServerUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-BlobAuditingServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingFailWithBadDatabaseIndentity()
        {
            RunPowerShellTest("Test-BlobAuditingFailWithBadDatabaseIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingFailWithBadServerIndentity()
        {
            RunPowerShellTest("Test-BlobAuditingFailWithBadServerIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseStorageKeyRotation()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingServerStorageKeyRotation()
        {
            RunPowerShellTest("Test-BlobAuditingServerStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingServerRetentionKeepProperties()
        {
            RunPowerShellTest("Test-BlobAuditingServerRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseRetentionKeepProperties()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingOnDatabase()
        {
            RunPowerShellTest("Test-BlobAuditingOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingOnServer()
        {
            RunPowerShellTest("Test-BlobAuditingOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingWithAuditActionGroups()
        {
            RunPowerShellTest("Test-BlobAuditingWithAuditActionGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditingOnDatabase()
        {
            RunPowerShellTest("Test-ExtendedAuditingOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditingOnServer()
        {
            RunPowerShellTest("Test-ExtendedAuditingOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditingOnDatabase()
        {
            RunPowerShellTest("Test-AuditingOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditingOnServer()
        {
            RunPowerShellTest("Test-AuditingOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDatabaseDiagnosticsAreCreatedOnNeed()
        {
            RunPowerShellTest("Test-NewDatabaseDiagnosticsAreCreatedOnNeed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewServerDiagnosticsAreCreatedOnNeed()
        {
            RunPowerShellTest("Test-NewServerDiagnosticsAreCreatedOnNeed");
        }
    }
}

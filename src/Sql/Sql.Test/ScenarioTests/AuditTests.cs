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
    public class AuditTests : SqlTestsBase
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

        public AuditTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-BlobAuditDatabaseUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditServerUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-BlobAuditServerUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDisableDatabaseAudit()
        {
            RunPowerShellTest("Test-BlobAuditDisableDatabaseAudit");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDisableServerAudit()
        {
            RunPowerShellTest("Test-BlobAuditDisableServerAudit");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailedDatabaseUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-BlobAuditFailedDatabaseUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailedServerUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-BlobAuditFailedServerUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-BlobAuditDatabaseUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditServerUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-BlobAuditServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailWithBadDatabaseIndentity()
        {
            RunPowerShellTest("Test-BlobAuditFailWithBadDatabaseIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailWithBadServerIndentity()
        {
            RunPowerShellTest("Test-BlobAuditFailWithBadServerIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseStorageKeyRotation()
        {
            RunPowerShellTest("Test-BlobAuditDatabaseStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditServerStorageKeyRotation()
        {
            RunPowerShellTest("Test-BlobAuditServerStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditServerRetentionKeepProperties()
        {
            RunPowerShellTest("Test-BlobAuditServerRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseRetentionKeepProperties()
        {
            RunPowerShellTest("Test-BlobAuditDatabaseRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditOnDatabase()
        {
            RunPowerShellTest("Test-BlobAuditOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditOnServer()
        {
            RunPowerShellTest("Test-BlobAuditOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion()
        {
            RunPowerShellTest("Test-BlobAuditDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWithAuditActionGroups()
        {
            RunPowerShellTest("Test-BlobAuditWithAuditActionGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditOnDatabase()
        {
            RunPowerShellTest("Test-ExtendedAuditOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditOnServer()
        {
            RunPowerShellTest("Test-ExtendedAuditOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditOnDatabase()
        {
            RunPowerShellTest("Test-AuditOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditOnServer()
        {
            RunPowerShellTest("Test-AuditOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDatabaseAuditDiagnosticsAreCreatedOnNeed()
        {
            RunPowerShellTest("Test-NewDatabaseAuditDiagnosticsAreCreatedOnNeed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewServerAuditDiagnosticsAreCreatedOnNeed()
        {
            RunPowerShellTest("Test-NewServerAuditDiagnosticsAreCreatedOnNeed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAuditOnServer()
        {
            RunPowerShellTest("Test-RemoveAuditOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAuditOnDatabase()
        {
            RunPowerShellTest("Test-RemoveAuditOnDatabase");
        }
    }
}

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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
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
            var sqlLegacyClient = GetLegacySqlClient();
            var commonStorageClient = GetCommonStorageClient(context);
            var storageV2Client = GetStorageV2Client();
            var resourcesClient = GetResourcesClient();
            var newResourcesClient = GetResourcesClient(context);
            var authorizationClient = GetAuthorizationManagementClient();
            helper.SetupSomeOfManagementClients(sqlClient, sqlLegacyClient, storageV2Client, resourcesClient, newResourcesClient, authorizationClient, commonStorageClient);
        }

        public AuditingTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip ="Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithStorage");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithStorage");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithEventTypes");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithEventTypes");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDisableDatabaseAuditing()
        {
            RunPowerShellTest("Test-AuditingDisableDatabaseAuditing");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDisableServerAuditing()
        {
            RunPowerShellTest("Test-AuditingDisableServerAuditing");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-AuditingDatabaseDisableEnableKeepProperties");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-AuditingServerDisableEnableKeepProperties");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingUseServerDefault()
        {
            RunPowerShellTest("Test-AuditingUseServerDefault");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingFailedDatabaseUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-AuditingFailedDatabaseUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingFailedServerUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-AuditingFailedServerUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingFailedUseServerDefault()
        {
            RunPowerShellTest("Test-AuditingFailedUseServerDefault");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithEventTypeShortcuts");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithEventTypeShortcuts");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyKeepPreviousStorage");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingFailWithBadDatabaseIndentity()
        {
            RunPowerShellTest("Test-AuditingFailWithBadDatabaseIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingFailWithBadServerIndentity()
        {
            RunPowerShellTest("Test-AuditingFailWithBadServerIndentity");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseStorageKeyRotation()
        {
            RunPowerShellTest("Test-AuditingDatabaseStorageKeyRotation");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerStorageKeyRotation()
        {
            RunPowerShellTest("Test-AuditingServerStorageKeyRotation");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyWithRetention()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithRetention");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithRetention()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithRetention");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerRetentionKeepProperties()
        {
            RunPowerShellTest("Test-AuditingServerRetentionKeepProperties");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseRetentionKeepProperties()
        {
            RunPowerShellTest("Test-AuditingDatabaseRetentionKeepProperties");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingOnDatabase()
        {
            RunPowerShellTest("Test-BlobAuditingOnDatabase");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingOnServer()
        {
            RunPowerShellTest("Test-BlobAuditingOnServer");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatatabaseAuditingTypeMigration()
        {
            RunPowerShellTest("Test-DatatabaseAuditingTypeMigration");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerAuditingTypeMigration()
        {
            RunPowerShellTest("Test-ServerAuditingTypeMigration");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetServerAndDatabaseAuditingInUkRegion()
        {
            RunPowerShellTest("Test-GetServerAndDatabaseAuditingInUkRegion");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingWithAuditActionGroups()
        {
            RunPowerShellTest("Test-BlobAuditingWithAuditActionGroups");
        }
    }
}

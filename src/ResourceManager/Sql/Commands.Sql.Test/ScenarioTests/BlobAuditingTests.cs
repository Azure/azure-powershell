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
    public class BlobAuditingTests : SqlTestsBase
    {
        protected override void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlClient = GetSqlClient(context);
            var sqlLegacyClient = GetLegacySqlClient();
            var storageClient = GetStorageClient();
            var storageV2Client = GetStorageV2Client();
            var commonStorageClient = GetCommonStorageClient(context);
            var resourcesClient = GetResourcesClient();
            var newResourcesClient = GetResourcesClient(context);
            var authorizationClient = GetAuthorizationManagementClient();
            helper.SetupSomeOfManagementClients(sqlClient, sqlLegacyClient, storageClient, storageV2Client, resourcesClient, newResourcesClient, authorizationClient, commonStorageClient);
        }

        public BlobAuditingTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseUpdatePolicyWithStorage");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingServerUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-BlobAuditingServerUpdatePolicyWithStorage");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDisableDatabaseAuditing()
        {
            RunPowerShellTest("Test-BlobAuditingDisableDatabaseAuditing");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
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

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseUpdatePolicyKeepPreviousStorage");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
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

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseStorageKeyRotation()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseStorageKeyRotation");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingServerStorageKeyRotation()
        {
            RunPowerShellTest("Test-BlobAuditingServerStorageKeyRotation");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingServerRetentionKeepProperties()
        {
            RunPowerShellTest("Test-BlobAuditingServerRetentionKeepProperties");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseRetentionKeepProperties()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseRetentionKeepProperties");
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
        public void TestBlobAuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingWithAuditActionGroups()
        {
            RunPowerShellTest("Test-BlobAuditingWithAuditActionGroups");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeprecatedServerAuditingCmdletToBlobAuditingNewCmdlet()
        {
            RunPowerShellTest("Test-DeprecatedServerAuditingCmdletToBlobAuditingNewCmdlet");
        }

        [Fact(Skip = "Tests failed to rerecord because of storage account creation issues, Service team needs to investigate")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeprecatedDatabaseAuditingCmdletToBlobAuditingNewCmdlet()
        {
            RunPowerShellTest("Test-DeprecatedDatabaseAuditingCmdletToBlobAuditingNewCmdlet");
        }
    }
}

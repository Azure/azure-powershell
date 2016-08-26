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

using Microsoft.Azure.Commands.ScenarioTest.Mocks;
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
            var sqlCSMClient = GetSqlClient();
            var storageClient = GetStorageClient();
            var storageV2Client = GetStorageV2Client();
            var resourcesClient = GetResourcesClient();
            var authorizationClient = GetAuthorizationManagementClient();
            helper.SetupSomeOfManagementClients(sqlCSMClient, storageClient, storageV2Client, resourcesClient, authorizationClient);
        }

        public AuditingTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyWithStorageV2()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithStorageV2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithEventTypes");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithEventTypes");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDisableDatabaseAuditing()
        {
            RunPowerShellTest("Test-AuditingDisableDatabaseAuditing");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDisableServerAuditing()
        {
            RunPowerShellTest("Test-AuditingDisableServerAuditing");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-AuditingDatabaseDisableEnableKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-AuditingServerDisableEnableKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingUseServerDefault()
        {
            RunPowerShellTest("Test-AuditingUseServerDefault");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingFailedDatabaseUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-AuditingFailedDatabaseUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingFailedServerUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-AuditingFailedServerUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingFailedUseServerDefault()
        {
            RunPowerShellTest("Test-AuditingFailedUseServerDefault");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithEventTypeShortcuts");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithEventTypeShortcuts");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingFailWithBadDatabaseIndentity()
        {
            RunPowerShellTest("Test-AuditingFailWithBadDatabaseIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingFailWithBadServerIndentity()
        {
            RunPowerShellTest("Test-AuditingFailWithBadServerIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseStorageKeyRotation()
        {
            RunPowerShellTest("Test-AuditingDatabaseStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerStorageKeyRotation()
        {
            RunPowerShellTest("Test-AuditingServerStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerUpdatePolicyWithRetention()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithRetention");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyWithRetention()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithRetention");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerRetentionKeepProperties()
        {
            RunPowerShellTest("Test-AuditingServerRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseRetentionKeepProperties()
        {
            RunPowerShellTest("Test-AuditingDatabaseRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestBlobAuditingOnDatabase()
        {
            RunPowerShellTest("Test-BlobAuditingOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestBlobAuditingOnServer()
        {
            RunPowerShellTest("Test-BlobAuditingOnServer");
        }

        [Fact (Skip = "Waiting backend validation")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion");
        }
    }
}

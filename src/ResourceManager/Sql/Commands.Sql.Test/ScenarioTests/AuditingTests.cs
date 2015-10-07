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
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class AuditingTests : SqlTestsBase
    {
        protected Microsoft.Azure.Management.Storage.StorageManagementClient GetStorageV2Client()
        {
            var client = TestBase.GetServiceClient<Microsoft.Azure.Management.Storage.StorageManagementClient>(new CSMTestEnvironmentFactory());
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
        }

        protected override void SetupManagementClients()
        {
            var sqlCSMClient = GetSqlClient();
            var storageClient = GetStorageClient();
            var storageV2Client = GetStorageV2Client();
            var resourcesClient = GetResourcesClient();
            var authorizationClient = GetAuthorizationManagementClient();
            helper.SetupSomeOfManagementClients(sqlCSMClient, storageClient, storageV2Client, resourcesClient, authorizationClient);
        }
        
        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithStorage");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyWithStorageV2()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithStorageV2");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithStorage");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithEventTypes");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithEventTypes");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDisableDatabaseAuditing()
        {
            RunPowerShellTest("Test-AuditingDisableDatabaseAuditing");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDisableServerAuditing()
        {
            RunPowerShellTest("Test-AuditingDisableServerAuditing");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-AuditingDatabaseDisableEnableKeepProperties");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-AuditingServerDisableEnableKeepProperties");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingUseServerDefault()
        {
            RunPowerShellTest("Test-AuditingUseServerDefault");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingFailedDatabaseUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-AuditingFailedDatabaseUpdatePolicyWithNoStorage");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingFailedServerUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-AuditingFailedServerUpdatePolicyWithNoStorage");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingFailedUseServerDefault()
        {
            RunPowerShellTest("Test-AuditingFailedUseServerDefault");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithEventTypeShortcuts");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithEventTypeShortcuts");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyKeepPreviousStorage");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingFailWithBadDatabaseIndentity()
        {
            RunPowerShellTest("Test-AuditingFailWithBadDatabaseIndentity");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingFailWithBadServerIndentity()
        {
            RunPowerShellTest("Test-AuditingFailWithBadServerIndentity");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseStorageKeyRotation()
        {
            RunPowerShellTest("Test-AuditingDatabaseStorageKeyRotation");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerStorageKeyRotation()
        {
            RunPowerShellTest("Test-AuditingServerStorageKeyRotation");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerUpdatePolicyWithRetention()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithRetention");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyWithRetention()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithRetention");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingServerRetentionKeepProperties()
        {
            RunPowerShellTest("Test-AuditingServerRetentionKeepProperties");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseRetentionKeepProperties()
        {
            RunPowerShellTest("Test-AuditingDatabaseRetentionKeepProperties");
        }

        [Fact(Skip = "PSGet: TODO fix by moving SM specific logic to test setup")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestAuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion");
        }
    }
}

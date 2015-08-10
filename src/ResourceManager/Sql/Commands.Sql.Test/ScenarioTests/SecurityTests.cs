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

using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.ScenarioTest.SqlTests
{
    public class SecurityTests : SqlTestsBase
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
            var sqlCSMClient = GetSqlClient(); // to interact with the security endpoints
            var storageClient = GetStorageClient();
            var storageV2Client = GetStorageV2Client();
            var resourcesClient = GetResourcesClient();
            var authorizationClient = GetAuthorizationManagementClient();
            helper.SetupSomeOfManagementClients(sqlCSMClient, storageClient, storageV2Client, resourcesClient, authorizationClient);
        }

        
        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestDatabaseUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-DatabaseUpdatePolicyWithStorage");
        }

        [Fact(Skip="Non stable interaction between the test and the testing framework")]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestDatabaseUpdatePolicyWithStorageV2()
        {
            RunPowerShellTest("Test-DatabaseUpdatePolicyWithStorageV2");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestServerUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-ServerUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestDatabaseUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-DatabaseUpdatePolicyWithEventTypes");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestServerUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-ServerUpdatePolicyWithEventTypes");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestDisableDatabaseAuditing()
        {
            RunPowerShellTest("Test-DisableDatabaseAuditing");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestDisableServerAuditing()
        {
            RunPowerShellTest("Test-DisableServerAuditing");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestDatabaseDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-DatabaseDisableEnableKeepProperties");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestServerDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-ServerDisableEnableKeepProperties");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestUseServerDefault()
        {
            RunPowerShellTest("Test-UseServerDefault");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestFailedDatabaseUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-FailedDatabaseUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestFailedServerUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-FailedServerUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestFailedUseServerDefault()
        {
            RunPowerShellTest("Test-FailedUseServerDefault");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestDatabaseUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-DatabaseUpdatePolicyWithEventTypeShortcuts");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestServerUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-ServerUpdatePolicyWithEventTypeShortcuts");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestDatabaseUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-DatabaseUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestServerUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-ServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestFailWithBadDatabaseIndentity()
        {
            RunPowerShellTest("Test-FailWithBadDatabaseIndentity");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestFailWithBadServerIndentity()
        {
            RunPowerShellTest("Test-FailWithBadServerIndentity");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestDatabaseStorageKeyRotation()
        {
            RunPowerShellTest("Test-DatabaseStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestServerStorageKeyRotation()
        {
            RunPowerShellTest("Test-ServerStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestServerUpdatePolicyWithRetention()
        {
            RunPowerShellTest("Test-ServerUpdatePolicyWithRetention");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestDatabaseUpdatePolicyWithRetention()
        {
            RunPowerShellTest("Test-DatabaseUpdatePolicyWithRetention");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestServerRetentionKeepProperties()
        {
            RunPowerShellTest("Test-ServerRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestDatabaseRetentionKeepProperties()
        {
            RunPowerShellTest("Test-DatabaseRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion()
        {
            RunPowerShellTest("Test-DatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion");
        }
    }
}

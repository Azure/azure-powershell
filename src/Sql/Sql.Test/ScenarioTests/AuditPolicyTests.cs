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
    public class AuditPolicyTests : SqlTestsBase
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

        public AuditPolicyTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyDatabaseUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-BlobAuditPolicyDatabaseUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyServerUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-BlobAuditPolicyServerUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyDisableDatabaseAuditPolicy()
        {
            RunPowerShellTest("Test-BlobAuditPolicyDisableDatabaseAuditPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyDisableServerAuditPolicy()
        {
            RunPowerShellTest("Test-BlobAuditPolicyDisableServerAuditPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyFailedDatabaseUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-BlobAuditPolicyFailedDatabaseUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyFailedServerUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-BlobAuditPolicyFailedServerUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyDatabaseUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-BlobAuditPolicyDatabaseUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyServerUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-BlobAuditPolicyServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyFailWithBadDatabaseIndentity()
        {
            RunPowerShellTest("Test-BlobAuditPolicyFailWithBadDatabaseIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyFailWithBadServerIndentity()
        {
            RunPowerShellTest("Test-BlobAuditPolicyFailWithBadServerIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyDatabaseStorageKeyRotation()
        {
            RunPowerShellTest("Test-BlobAuditPolicyDatabaseStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyServerStorageKeyRotation()
        {
            RunPowerShellTest("Test-BlobAuditPolicyServerStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyServerRetentionKeepProperties()
        {
            RunPowerShellTest("Test-BlobAuditPolicyServerRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyDatabaseRetentionKeepProperties()
        {
            RunPowerShellTest("Test-BlobAuditPolicyDatabaseRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyOnDatabase()
        {
            RunPowerShellTest("Test-BlobAuditPolicyOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyOnServer()
        {
            RunPowerShellTest("Test-BlobAuditPolicyOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion()
        {
            RunPowerShellTest("Test-BlobAuditPolicyDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditPolicyWithAuditActionGroups()
        {
            RunPowerShellTest("Test-BlobAuditPolicyWithAuditActionGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditPolicyOnDatabase()
        {
            RunPowerShellTest("Test-ExtendedAuditPolicyOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditPolicyOnServer()
        {
            RunPowerShellTest("Test-ExtendedAuditPolicyOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditPolicyOnDatabase()
        {
            RunPowerShellTest("Test-AuditPolicyOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditPolicyOnServer()
        {
            RunPowerShellTest("Test-AuditPolicyOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDatabaseAuditPolicyDiagnosticsAreCreatedOnNeed()
        {
            RunPowerShellTest("Test-NewDatabaseAuditPolicyDiagnosticsAreCreatedOnNeed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewServerAuditPolicyDiagnosticsAreCreatedOnNeed()
        {
            RunPowerShellTest("Test-NewServerAuditPolicyDiagnosticsAreCreatedOnNeed");
        }
    }
}

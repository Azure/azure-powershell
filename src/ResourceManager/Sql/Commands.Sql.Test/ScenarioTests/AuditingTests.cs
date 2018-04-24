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
            var storageV2Client = GetStorageV2Client(context);
            var newResourcesClient = GetResourcesClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, storageV2Client, newResourcesClient);
        }

        public AuditingTests(ITestOutputHelper output) : base(output)
        {
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithStorage");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithStorage");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithEventTypes");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithEventTypes");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDisableDatabaseAuditing()
        {
            RunPowerShellTest("Test-AuditingDisableDatabaseAuditing");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDisableServerAuditing()
        {
            RunPowerShellTest("Test-AuditingDisableServerAuditing");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-AuditingDatabaseDisableEnableKeepProperties");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-AuditingServerDisableEnableKeepProperties");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
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

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithEventTypeShortcuts");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithEventTypeShortcuts");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyKeepPreviousStorage");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
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

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseStorageKeyRotation()
        {
            RunPowerShellTest("Test-AuditingDatabaseStorageKeyRotation");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerStorageKeyRotation()
        {
            RunPowerShellTest("Test-AuditingServerStorageKeyRotation");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyWithRetention()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithRetention");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithRetention()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithRetention");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingServerRetentionKeepProperties()
        {
            RunPowerShellTest("Test-AuditingServerRetentionKeepProperties");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuditingDatabaseRetentionKeepProperties()
        {
            RunPowerShellTest("Test-AuditingDatabaseRetentionKeepProperties");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingOnDatabase()
        {
            RunPowerShellTest("Test-BlobAuditingOnDatabase");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingOnServer()
        {
            RunPowerShellTest("Test-BlobAuditingOnServer");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatatabaseAuditingTypeMigration()
        {
            RunPowerShellTest("Test-DatatabaseAuditingTypeMigration");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerAuditingTypeMigration()
        {
            RunPowerShellTest("Test-ServerAuditingTypeMigration");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
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

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingWithAuditActionGroups()
        {
            RunPowerShellTest("Test-BlobAuditingWithAuditActionGroups");
        }
    }
}

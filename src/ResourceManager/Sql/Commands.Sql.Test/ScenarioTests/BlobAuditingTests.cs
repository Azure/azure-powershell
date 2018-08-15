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
            var storageV2Client = GetStorageV2Client(context);
            var newResourcesClient = GetResourcesClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, storageV2Client, newResourcesClient);
        }

        public BlobAuditingTests(ITestOutputHelper output) : base(output)
        {
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseUpdatePolicyWithStorage");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingServerUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-BlobAuditingServerUpdatePolicyWithStorage");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDisableDatabaseAuditing()
        {
            RunPowerShellTest("Test-BlobAuditingDisableDatabaseAuditing");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
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

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseUpdatePolicyKeepPreviousStorage");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
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

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseStorageKeyRotation()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseStorageKeyRotation");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingServerStorageKeyRotation()
        {
            RunPowerShellTest("Test-BlobAuditingServerStorageKeyRotation");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingServerRetentionKeepProperties()
        {
            RunPowerShellTest("Test-BlobAuditingServerRetentionKeepProperties");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditingDatabaseRetentionKeepProperties()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseRetentionKeepProperties");
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
        public void TestBlobAuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion()
        {
            RunPowerShellTest("Test-BlobAuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion");
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

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeprecatedServerAuditingCmdletToBlobAuditingNewCmdlet()
        {
            RunPowerShellTest("Test-DeprecatedServerAuditingCmdletToBlobAuditingNewCmdlet");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Awaiting Storage.Common usage in Sql")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeprecatedDatabaseAuditingCmdletToBlobAuditingNewCmdlet()
        {
            RunPowerShellTest("Test-DeprecatedDatabaseAuditingCmdletToBlobAuditingNewCmdlet");
        }
    }
}

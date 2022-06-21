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

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class AuditTests : SqlTestRunner
    {
        public AuditTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseUpdatePolicyWithStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditDatabaseUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditServerUpdatePolicyWithStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditServerUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportBlobAuditServerUpdatePolicyWithStorage()
        {
            TestRunner.RunTestScript("Test-MSSupportBlobAuditServerUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDisableDatabaseAudit()
        {
            TestRunner.RunTestScript("Test-BlobAuditDisableDatabaseAudit");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDisableServerAudit()
        {
            TestRunner.RunTestScript("Test-BlobAuditDisableServerAudit");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportBlobAuditDisableServerAudit()
        {
            TestRunner.RunTestScript("Test-MSSupportBlobAuditDisableServerAudit");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailedDatabaseUpdatePolicyWithNoStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditFailedDatabaseUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailedServerUpdatePolicyWithNoStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditFailedServerUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportBlobAuditFailedServerUpdatePolicyWithNoStorage()
        {
            TestRunner.RunTestScript("Test-MSSupportBlobAuditFailedServerUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseUpdatePolicyKeepPreviousStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditDatabaseUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditServerUpdatePolicyKeepPreviousStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportBlobAuditServerUpdatePolicyKeepPreviousStorage()
        {
            TestRunner.RunTestScript("Test-MSSupportBlobAuditServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailWithBadDatabaseIndentity()
        {
            TestRunner.RunTestScript("Test-BlobAuditFailWithBadDatabaseIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailWithBadServerIndentity()
        {
            TestRunner.RunTestScript("Test-BlobAuditFailWithBadServerIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportBlobAuditFailWithBadServerIndentity()
        {
            TestRunner.RunTestScript("Test-MSSupportBlobAuditFailWithBadServerIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseStorageKeyRotation()
        {
            TestRunner.RunTestScript("Test-BlobAuditDatabaseStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditServerStorageKeyRotation()
        {
            TestRunner.RunTestScript("Test-BlobAuditServerStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditServerRetentionKeepProperties()
        {
            TestRunner.RunTestScript("Test-BlobAuditServerRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseRetentionKeepProperties()
        {
            TestRunner.RunTestScript("Test-BlobAuditDatabaseRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditOnDatabase()
        {
            TestRunner.RunTestScript("Test-BlobAuditOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditOnServer()
        {
            TestRunner.RunTestScript("Test-BlobAuditOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportBlobAuditOnServer()
        {
            TestRunner.RunTestScript("Test-MSSupportBlobAuditOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion()
        {
            TestRunner.RunTestScript("Test-BlobAuditDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWithAuditActionGroups()
        {
            TestRunner.RunTestScript("Test-BlobAuditWithAuditActionGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditOnDatabase()
        {
            TestRunner.RunTestScript("Test-ExtendedAuditOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditOnServer()
        {
            TestRunner.RunTestScript("Test-ExtendedAuditOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditOnDatabase()
        {
            TestRunner.RunTestScript("Test-AuditOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditOnServer()
        {
            TestRunner.RunTestScript("Test-AuditOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestMSSupportAuditOnServer()
        {
            TestRunner.RunTestScript("Test-MSSupportAuditOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDatabaseAuditDiagnosticsAreCreatedOnNeed()
        {
            TestRunner.RunTestScript("Test-NewDatabaseAuditDiagnosticsAreCreatedOnNeed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewServerAuditDiagnosticsAreCreatedOnNeed()
        {
            TestRunner.RunTestScript("Test-NewServerAuditDiagnosticsAreCreatedOnNeed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportNewServerAuditDiagnosticsAreCreatedOnNeed()
        {
            TestRunner.RunTestScript("Test-MSSupportNewServerAuditDiagnosticsAreCreatedOnNeed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAuditOnServer()
        {
            TestRunner.RunTestScript("Test-RemoveAuditOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportRemoveAuditOnServer()
        {
            TestRunner.RunTestScript("Test-MSSupportRemoveAuditOnServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAuditOnDatabase()
        {
            TestRunner.RunTestScript("Test-RemoveAuditOnDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveDatabaseAuditingSettingsMultipleDiagnosticSettings()
        {
            TestRunner.RunTestScript("Test-RemoveDatabaseAuditingSettingsMultipleDiagnosticSettings");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveServerAuditingSettingsMultipleDiagnosticSettings()
        {
            TestRunner.RunTestScript("Test-RemoveServerAuditingSettingsMultipleDiagnosticSettings");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportRemoveServerAuditingSettingsMultipleDiagnosticSettings()
        {
            TestRunner.RunTestScript("Test-MSSupportRemoveServerAuditingSettingsMultipleDiagnosticSettings");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerAuditingToStorageInVNet()
        {
            TestRunner.RunTestScript("Test-ServerAuditingToStorageInVNet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportServerAuditingToStorageInVNet()
        {
            TestRunner.RunTestScript("Test-MSSupportServerAuditingToStorageInVNet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseAuditingToStorageInVNet()
        {
            TestRunner.RunTestScript("Test-DatabaseAuditingToStorageInVNet");
        }
    }
}

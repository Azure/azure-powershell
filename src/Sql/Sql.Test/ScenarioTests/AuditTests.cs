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

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseUpdatePolicyWithStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditDatabaseUpdatePolicyWithStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditServerUpdatePolicyWithStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditServerUpdatePolicyWithStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportBlobAuditServerUpdatePolicyWithStorage()
        {
            TestRunner.RunTestScript("Test-MSSupportBlobAuditServerUpdatePolicyWithStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDisableDatabaseAudit()
        {
            TestRunner.RunTestScript("Test-BlobAuditDisableDatabaseAudit");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDisableServerAudit()
        {
            TestRunner.RunTestScript("Test-BlobAuditDisableServerAudit");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportBlobAuditDisableServerAudit()
        {
            TestRunner.RunTestScript("Test-MSSupportBlobAuditDisableServerAudit");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailedDatabaseUpdatePolicyWithNoStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditFailedDatabaseUpdatePolicyWithNoStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailedServerUpdatePolicyWithNoStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditFailedServerUpdatePolicyWithNoStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportBlobAuditFailedServerUpdatePolicyWithNoStorage()
        {
            TestRunner.RunTestScript("Test-MSSupportBlobAuditFailedServerUpdatePolicyWithNoStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseUpdatePolicyKeepPreviousStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditDatabaseUpdatePolicyKeepPreviousStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditServerUpdatePolicyKeepPreviousStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportBlobAuditServerUpdatePolicyKeepPreviousStorage()
        {
            TestRunner.RunTestScript("Test-MSSupportBlobAuditServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailWithBadDatabaseIndentity()
        {
            TestRunner.RunTestScript("Test-BlobAuditFailWithBadDatabaseIndentity");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailWithBadServerIndentity()
        {
            TestRunner.RunTestScript("Test-BlobAuditFailWithBadServerIndentity");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportBlobAuditFailWithBadServerIndentity()
        {
            TestRunner.RunTestScript("Test-MSSupportBlobAuditFailWithBadServerIndentity");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseStorageKeyRotation()
        {
            TestRunner.RunTestScript("Test-BlobAuditDatabaseStorageKeyRotation");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditServerStorageKeyRotation()
        {
            TestRunner.RunTestScript("Test-BlobAuditServerStorageKeyRotation");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditServerRetentionKeepProperties()
        {
            TestRunner.RunTestScript("Test-BlobAuditServerRetentionKeepProperties");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseRetentionKeepProperties()
        {
            TestRunner.RunTestScript("Test-BlobAuditDatabaseRetentionKeepProperties");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditOnDatabase()
        {
            TestRunner.RunTestScript("Test-BlobAuditOnDatabase");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditOnServer()
        {
            TestRunner.RunTestScript("Test-BlobAuditOnServer");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportBlobAuditOnServer()
        {
            TestRunner.RunTestScript("Test-MSSupportBlobAuditOnServer");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion()
        {
            TestRunner.RunTestScript("Test-BlobAuditDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWithAuditActionGroups()
        {
            TestRunner.RunTestScript("Test-BlobAuditWithAuditActionGroups");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditOnDatabase()
        {
            TestRunner.RunTestScript("Test-ExtendedAuditOnDatabase");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditOnServer()
        {
            TestRunner.RunTestScript("Test-ExtendedAuditOnServer");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditOnDatabase()
        {
            TestRunner.RunTestScript("Test-AuditOnDatabase");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditOnServer()
        {
            TestRunner.RunTestScript("Test-AuditOnServer");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestMSSupportAuditOnServer()
        {
            TestRunner.RunTestScript("Test-MSSupportAuditOnServer");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestNewDatabaseAuditDiagnosticsAreCreatedOnNeed()
        {
            TestRunner.RunTestScript("Test-NewDatabaseAuditDiagnosticsAreCreatedOnNeed");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestNewServerAuditDiagnosticsAreCreatedOnNeed()
        {
            TestRunner.RunTestScript("Test-NewServerAuditDiagnosticsAreCreatedOnNeed");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestMSSupportNewServerAuditDiagnosticsAreCreatedOnNeed()
        {
            TestRunner.RunTestScript("Test-MSSupportNewServerAuditDiagnosticsAreCreatedOnNeed");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestRemoveAuditOnServer()
        {
            TestRunner.RunTestScript("Test-RemoveAuditOnServer");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestMSSupportRemoveAuditOnServer()
        {
            TestRunner.RunTestScript("Test-MSSupportRemoveAuditOnServer");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestRemoveAuditOnDatabase()
        {
            TestRunner.RunTestScript("Test-RemoveAuditOnDatabase");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestRemoveDatabaseAuditingSettingsMultipleDiagnosticSettings()
        {
            TestRunner.RunTestScript("Test-RemoveDatabaseAuditingSettingsMultipleDiagnosticSettings");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestRemoveServerAuditingSettingsMultipleDiagnosticSettings()
        {
            TestRunner.RunTestScript("Test-RemoveServerAuditingSettingsMultipleDiagnosticSettings");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestMSSupportRemoveServerAuditingSettingsMultipleDiagnosticSettings()
        {
            TestRunner.RunTestScript("Test-MSSupportRemoveServerAuditingSettingsMultipleDiagnosticSettings");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerAuditingToStorageInVNet()
        {
            TestRunner.RunTestScript("Test-ServerAuditingToStorageInVNet");
        }

        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMSSupportServerAuditingToStorageInVNet()
        {
            TestRunner.RunTestScript("Test-MSSupportServerAuditingToStorageInVNet");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseAuditingToStorageInVNet()
        {
            TestRunner.RunTestScript("Test-DatabaseAuditingToStorageInVNet");
        }
    }
}

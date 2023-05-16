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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Synapse.Test.ScenarioTests
{
    public class AuditTests : SynapseTestRunner
    {
        public AuditTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditSqlPoolUpdatePolicyWithStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditSqlPoolUpdatePolicyWithStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWorkspaceUpdatePolicyWithStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditWorkspaceUpdatePolicyWithStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDisableSqlPoolAudit()
        {
            TestRunner.RunTestScript("Test-BlobAuditDisableSqlPoolAudit");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDisableWorkspaceAudit()
        {
            TestRunner.RunTestScript("Test-BlobAuditDisableWorkspaceAudit");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditSqlPoolUpdatePolicyKeepPreviousStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditSqlPoolUpdatePolicyKeepPreviousStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWorkspaceUpdatePolicyKeepPreviousStorage()
        {
            TestRunner.RunTestScript("Test-BlobAuditWorkspaceUpdatePolicyKeepPreviousStorage");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailWithBadSqlPoolIndentity()
        {
            TestRunner.RunTestScript("Test-BlobAuditFailWithBadSqlPoolIndentity");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailWithBadWorkspaceIndentity()
        {
            TestRunner.RunTestScript("Test-BlobAuditFailWithBadWorkspaceIndentity");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditSqlPoolStorageKeyRotation()
        {
            TestRunner.RunTestScript("Test-BlobAuditSqlPoolStorageKeyRotation");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWorkspaceStorageKeyRotation()
        {
            TestRunner.RunTestScript("Test-BlobAuditWorkspaceStorageKeyRotation");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWorkspaceRetentionKeepProperties()
        {
            TestRunner.RunTestScript("Test-BlobAuditWorkspaceRetentionKeepProperties");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditSqlPoolRetentionKeepProperties()
        {
            TestRunner.RunTestScript("Test-BlobAuditSqlPoolRetentionKeepProperties");
        }

        [Fact(Skip = "SQL Data Warehouse audit doesn’t support audit actions.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditOnSqlPool()
        {
            TestRunner.RunTestScript("Test-BlobAuditOnSqlPool");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditOnWorkspace()
        {
            TestRunner.RunTestScript("Test-BlobAuditOnWorkspace");
        }

        [Fact(Skip = "SQL Data Warehouse audit doesn’t support other audit groups.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWithAuditActionGroups()
        {
            TestRunner.RunTestScript("Test-BlobAuditWithAuditActionGroups");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditOnSqlPool()
        {
            TestRunner.RunTestScript("Test-ExtendedAuditOnSqlPool");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditOnWorkspace()
        {
            TestRunner.RunTestScript("Test-ExtendedAuditOnWorkspace");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditOnSqlPool()
        {
            TestRunner.RunTestScript("Test-AuditOnSqlPool");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditOnWorkspace()
        {
            TestRunner.RunTestScript("Test-AuditOnWorkspace");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestNewSqlPoolAuditDiagnosticsAreCreatedOnNeed()
        {
            TestRunner.RunTestScript("Test-NewSqlPoolAuditDiagnosticsAreCreatedOnNeed");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestNewWorkspaceAuditDiagnosticsAreCreatedOnNeed()
        {
            TestRunner.RunTestScript("Test-NewWorkspaceAuditDiagnosticsAreCreatedOnNeed");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestRemoveAuditOnWorkspace()
        {
            TestRunner.RunTestScript("Test-RemoveAuditOnWorkspace");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestRemoveAuditOnSqlPool()
        {
            TestRunner.RunTestScript("Test-RemoveAuditOnSqlPool");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestRemoveSqlPoolAuditingSettingsMultipleDiagnosticSettings()
        {
            TestRunner.RunTestScript("Test-RemoveSqlPoolAuditingSettingsMultipleDiagnosticSettings");
        }

        [Fact(Skip = "Test case fails due to the New-AzEventHubNamespace migration to autorest")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestRemoveWorkspaceAuditingSettingsMultipleDiagnosticSettings()
        {
            TestRunner.RunTestScript("Test-RemoveWorkspaceAuditingSettingsMultipleDiagnosticSettings");
        }
    }
}

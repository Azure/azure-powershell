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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Synapse.Test.ScenarioTests
{
    public class AuditTests : SynapseTestBase
    {
        public XunitTracingInterceptor _logger;

        public AuditTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditSqlPoolUpdatePolicyWithStorage()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditSqlPoolUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWorkspaceUpdatePolicyWithStorage()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditWorkspaceUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDisableSqlPoolAudit()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditDisableSqlPoolAudit");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditDisableWorkspaceAudit()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditDisableWorkspaceAudit");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditSqlPoolUpdatePolicyKeepPreviousStorage()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditSqlPoolUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWorkspaceUpdatePolicyKeepPreviousStorage()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditWorkspaceUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailWithBadSqlPoolIndentity()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditFailWithBadSqlPoolIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditFailWithBadWorkspaceIndentity()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditFailWithBadWorkspaceIndentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditSqlPoolStorageKeyRotation()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditSqlPoolStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWorkspaceStorageKeyRotation()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditWorkspaceStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWorkspaceRetentionKeepProperties()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditWorkspaceRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditSqlPoolRetentionKeepProperties()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditSqlPoolRetentionKeepProperties");
        }

        [Fact(Skip = "SQL Data Warehouse audit doesn’t support audit actions.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditOnSqlPool()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditOnSqlPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditOnWorkspace()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditOnWorkspace");
        }

        [Fact(Skip = "SQL Data Warehouse audit doesn’t support other audit groups.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobAuditWithAuditActionGroups()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-BlobAuditWithAuditActionGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditOnSqlPool()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-ExtendedAuditOnSqlPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExtendedAuditOnWorkspace()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-ExtendedAuditOnWorkspace");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditOnSqlPool()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-AuditOnSqlPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAuditOnWorkspace()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-AuditOnWorkspace");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSqlPoolAuditDiagnosticsAreCreatedOnNeed()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-NewSqlPoolAuditDiagnosticsAreCreatedOnNeed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewWorkspaceAuditDiagnosticsAreCreatedOnNeed()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-NewWorkspaceAuditDiagnosticsAreCreatedOnNeed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAuditOnWorkspace()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-RemoveAuditOnWorkspace");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAuditOnSqlPool()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-RemoveAuditOnSqlPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSqlPoolAuditingSettingsMultipleDiagnosticSettings()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-RemoveSqlPoolAuditingSettingsMultipleDiagnosticSettings");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveWorkspaceAuditingSettingsMultipleDiagnosticSettings()
        {
            NewInstance.RunPsTest(
                _logger,
                "Test-RemoveWorkspaceAuditingSettingsMultipleDiagnosticSettings");
        }
    }
}

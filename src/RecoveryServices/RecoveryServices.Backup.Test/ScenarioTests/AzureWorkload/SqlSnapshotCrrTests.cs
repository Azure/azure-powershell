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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.ScenarioTests
{
    public class SqlSnapshotCrrTests : RecoveryServicesBackupTestRunner
    {
        private readonly string _testModule = $"ScenarioTests/{PsBackupProviderTypes.AzureWorkload}/SqlSnapshotCrrTests.ps1";

        public SqlSnapshotCrrTests(ITestOutputHelper output) : base(output, resourceManagementApiVersion: "2023-01-31")
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestSqlInstanceSnapshotCrrGetItem()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-SqlInstanceSnapshotCrrGetItem");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestSqlSnapshotCrrGetRecoveryPoints()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-SqlSnapshotCrrGetRecoveryPoints");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestSqlSnapshotCrrGetRecoveryLogChain()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-SqlSnapshotCrrGetRecoveryLogChain");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestSqlInstanceSnapshotCrrPointInTimeRestore()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-SqlInstanceSnapshotCrrPointInTimeRestore");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(TestConstants.Workload, TestConstants.AzureVmWorkload)]
        public void TestSqlDatabaseSnapshotCrrRestore()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-SqlDatabaseSnapshotCrrRestore");
        }
    }
}

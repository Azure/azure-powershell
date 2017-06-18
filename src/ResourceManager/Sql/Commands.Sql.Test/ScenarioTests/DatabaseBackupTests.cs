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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class DatabaseBackupTests : SqlTestsBase
    {
        public DatabaseBackupTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListDatabaseRestorePoints()
        {
            RunPowerShellTest("Test-ListDatabaseRestorePoints");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreGeoBackup()
        {
            // Test cannot be re-recorded because it has hardcoded server name
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-RestoreGeoBackup");
            }
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreDeletedDatabaseBackup()
        {
            // Test cannot be re-recorded because it has hardcoded server name
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-RestoreDeletedDatabaseBackup");
            }
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestorePointInTimeBackup()
        {
            // Test cannot be re-recorded because it has hardcoded server name
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-RestorePointInTimeBackup");
            }
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerBackupLongTermRetentionVault()
        {
            // Test cannot be re-recorded because it has hardcoded server name
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-ServerBackupLongTermRetentionVault");
            }
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseBackupLongTermRetentionPolicy()
        {
            // Test cannot be re-recorded because it has hardcoded server name
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-DatabaseBackupLongTermRetentionPolicy");
            }
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreLongTermRetentionBackup()
        {
            // Test cannot be re-recorded because it has hardcoded server name
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-RestoreLongTermRetentionBackup");
            }
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseGeoBackupPolicy()
        {
            // Test cannot be re-recorded because it has hardcoded server name
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-DatabaseGeoBackupPolicy");
            }
        }
    }
}

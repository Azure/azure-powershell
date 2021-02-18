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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class DatabaseBackupTests : SqlTestsBase
    {
        public DatabaseBackupTests(ITestOutputHelper output) : base(output)
        {
<<<<<<< HEAD
=======
            base.resourceTypesToIgnoreApiVersion = new string[] {
                "Microsoft.Sql/servers"
            };
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListDatabaseRestorePoints()
        {
            // TODO Rewrite SQL backup tests to be recordable
            // TODO https://github.com/Azure/azure-powershell/issues/4155
            RunPowerShellTest("Test-ListDatabaseRestorePoints");
        }
<<<<<<< HEAD
        [Fact]
=======

        [Fact(Skip = "Not recordable")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreGeoBackup()
        {
            // TODO Rewrite SQL backup tests to be recordable
            // TODO https://github.com/Azure/azure-powershell/issues/4155
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-RestoreGeoBackup");
            }
        }
<<<<<<< HEAD
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreDeletedDatabaseBackup()
        {
            // TODO Rewrite SQL backup tests to be recordable
            // TODO https://github.com/Azure/azure-powershell/issues/4155
=======

        [Fact(Skip = "Not recordable")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreDeletedDatabaseBackup()
        {
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-RestoreDeletedDatabaseBackup");
            }
        }
<<<<<<< HEAD
        [Fact]
=======

        [Fact(Skip = "Not recordable")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestorePointInTimeBackup()
        {
            // TODO Rewrite SQL backup tests to be recordable
            // TODO https://github.com/Azure/azure-powershell/issues/4155
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-RestorePointInTimeBackup");
            }
        }

        [Fact(Skip = "LTR-V1 restore service is retiring in Prod.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreLongTermRetentionBackup()
        {
            // TODO Rewrite SQL backup tests to be recordable
            // TODO https://github.com/Azure/azure-powershell/issues/4155
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-RestoreLongTermRetentionBackup");
            }
        }
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLongTermRetentionV2Policy()
        {
            RunPowerShellTest("Test-LongTermRetentionV2Policy");
        }
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLongTermRetentionV2Backup()
        {
            RunPowerShellTest("Test-LongTermRetentionV2Backup");
        }
<<<<<<< HEAD
=======

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLongTermRetentionV2ResourceGroupBasedBackup()
        {
            RunPowerShellTest("Test-LongTermRetentionV2ResourceGroupBasedBackup");
        }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Fact(Skip = "This is not recordable test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLongTermRetentionV2()
        {
            // TODO Rewrite SQL backup tests to be recordable
            // TODO https://github.com/Azure/azure-powershell/issues/4155
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-LongTermRetentionV2");
            }
        }
<<<<<<< HEAD
        [Fact]
=======

        [Fact(Skip = "This is not recordable test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLongTermRetentionV2ResourceGroupBased()
        {
            RunPowerShellTest("Test-LongTermRetentionV2ResourceGroupBased");
        }

        [Fact(Skip = "Not recordable")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseGeoBackupPolicy()
        {
            // TODO Rewrite SQL backup tests to be recordable
            // TODO https://github.com/Azure/azure-powershell/issues/4155
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-DatabaseGeoBackupPolicy");
            }
        }
<<<<<<< HEAD
        [Fact]
=======

        [Fact(Skip = "Not recordable")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDatabaseRestorePoint()
        {
            // TODO Rewrite SQL backup tests to be recordable
            // TODO https://github.com/Azure/azure-powershell/issues/4155
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-NewDatabaseRestorePoint");
            }
        }
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveDatabaseRestorePoint()
        {
            // TODO Rewrite SQL backup tests to be recordable
            // TODO https://github.com/Azure/azure-powershell/issues/4155
            if (TestMockSupport.RunningMocked)
            {
                RunPowerShellTest("Test-RemoveDatabaseRestorePoint");
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestShortTermRetentionPolicy()
        {
            RunPowerShellTest("Test-ShortTermRetentionPolicy");
        }
    }
}

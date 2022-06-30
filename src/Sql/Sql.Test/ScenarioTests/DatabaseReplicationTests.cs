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
    public class DatabaseReplicationTests : SqlTestsBase
    {
        public DatabaseReplicationTests(ITestOutputHelper output) : base(output)
        {
            base.resourceTypesToIgnoreApiVersion = new string[] {
                "Microsoft.Sql/servers"
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDatabaseCopy()
        {
            RunPowerShellTest("Test-CreateDatabaseCopy");
        }

        [Fact(Skip = "Taking too long - try again before PR merge")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateVcoreDatabaseCopy()
        {
            RunPowerShellTest("Test-CreateVcoreDatabaseCopy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateSecondaryDatabase()
        {
            RunPowerShellTest("Test-CreateSecondaryDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNamedSecondaryDatabase()
        {
            RunPowerShellTest("Test-CreateNamedSecondaryDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNamedSecondaryDatabaseNegative()
        {
            RunPowerShellTest("Test-CreateNamedSecondaryDatabaseNegative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetReplicationLink()
        {
            RunPowerShellTest("Test-GetReplicationLink");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSecondaryDatabase()
        {
            RunPowerShellTest("Test-RemoveSecondaryDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverSecondaryDatabase()
        {
            RunPowerShellTest("Test-FailoverSecondaryDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDatabaseCopyWithBackupStorageRedundancy()
        {
            RunPowerShellTest("Test-CreateDatabaseCopyWithBackupStorageRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateSecondaryDatabaseWithBackupStorageRedundancy()
        {
            RunPowerShellTest("Test-CreateSecondaryDatabaseWithBackupStorageRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateCopyDatabaseWithGeoZoneBackupStorageRedundancy()
        {
            RunPowerShellTest("Test-CreateCopyDatabaseWithGeoZoneBackupStorageRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateSecondaryDatabaseWithGeoZoneBackupStorageRedundancy()
        {
            RunPowerShellTest("Test-CreateSecondaryDatabaseWithGeoZoneBackupStorageRedundancy");
        }

        [Fact(Skip = "Location 'East US 2 EUAP' is not accepting creation of new Windows Azure SQL Database servers at this time.'")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateCopyRegularAndZoneRedundantDatabaseWithSourceNotZoneRedundant()
        {
            RunPowerShellTest("Test-CreateCopyRegularAndZoneRedundantDatabaseWithSourceNotZoneRedundant");
        }

        [Fact(Skip = "Location 'East US 2 EUAP' is not accepting creation of new Windows Azure SQL Database servers at this time.'")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateCopyRegularAndZoneRedundantDatabaseWithSourceZoneRedundant()
        {
            RunPowerShellTest("Test-CreateCopyRegularAndZoneRedundantDatabaseWithSourceZoneRedundant");
        }

        [Fact(Skip = "Location 'East US 2 EUAP' is not accepting creation of new Windows Azure SQL Database servers at this time.'")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateSecondaryRegularAndZoneRedundantDatabaseWithSourceNotZoneRedundant()
        {
            RunPowerShellTest("Test-CreateSecondaryRegularAndZoneRedundantDatabaseWithSourceNotZoneRedundant");
        }

        [Fact(Skip = "Location 'East US 2 EUAP' is not accepting creation of new Windows Azure SQL Database servers at this time.'")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateSecondaryRegularAndZoneRedundantDatabaseWithSourceZoneRedundant()
        {
            RunPowerShellTest("Test-CreateSecondaryRegularAndZoneRedundantDatabaseWithSourceZoneRedundant");
        }
    }
}

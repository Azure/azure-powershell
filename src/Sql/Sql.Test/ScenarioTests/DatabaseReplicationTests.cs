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
    public class DatabaseReplicationTests : SqlTestRunner
    {
        public DatabaseReplicationTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDatabaseCopy()
        {
            TestRunner.RunTestScript("Test-CreateDatabaseCopy");
        }

        [Fact(Skip = "Taking too long - try again before PR merge")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateVcoreDatabaseCopy()
        {
            TestRunner.RunTestScript("Test-CreateVcoreDatabaseCopy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateSecondaryDatabase()
        {
            TestRunner.RunTestScript("Test-CreateSecondaryDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNamedSecondaryDatabase()
        {
            TestRunner.RunTestScript("Test-CreateNamedSecondaryDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNamedSecondaryDatabaseNegative()
        {
            TestRunner.RunTestScript("Test-CreateNamedSecondaryDatabaseNegative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetReplicationLink()
        {
            TestRunner.RunTestScript("Test-GetReplicationLink");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetReplicationLink()
        {
            TestRunner.RunTestScript("Test-SetReplicationLink");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSecondaryDatabase()
        {
            TestRunner.RunTestScript("Test-RemoveSecondaryDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverSecondaryDatabase()
        {
            TestRunner.RunTestScript("Test-FailoverSecondaryDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDatabaseCopyWithBackupStorageRedundancy()
        {
            TestRunner.RunTestScript("Test-CreateDatabaseCopyWithBackupStorageRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateSecondaryDatabaseWithBackupStorageRedundancy()
        {
            TestRunner.RunTestScript("Test-CreateSecondaryDatabaseWithBackupStorageRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateCopyDatabaseWithGeoZoneBackupStorageRedundancy()
        {
            TestRunner.RunTestScript("Test-CreateCopyDatabaseWithGeoZoneBackupStorageRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateSecondaryDatabaseWithGeoZoneBackupStorageRedundancy()
        {
            TestRunner.RunTestScript("Test-CreateSecondaryDatabaseWithGeoZoneBackupStorageRedundancy");
        }

        [Fact(Skip = "Location 'East US 2 EUAP' is not accepting creation of new Windows Azure SQL Database servers at this time.'")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateCopyRegularAndZoneRedundantDatabaseWithSourceNotZoneRedundant()
        {
            TestRunner.RunTestScript("Test-CreateCopyRegularAndZoneRedundantDatabaseWithSourceNotZoneRedundant");
        }

        [Fact(Skip = "Location 'East US 2 EUAP' is not accepting creation of new Windows Azure SQL Database servers at this time.'")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateCopyRegularAndZoneRedundantDatabaseWithSourceZoneRedundant()
        {
            TestRunner.RunTestScript("Test-CreateCopyRegularAndZoneRedundantDatabaseWithSourceZoneRedundant");
        }

        [Fact(Skip = "Location 'East US 2 EUAP' is not accepting creation of new Windows Azure SQL Database servers at this time.'")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateSecondaryRegularAndZoneRedundantDatabaseWithSourceNotZoneRedundant()
        {
            TestRunner.RunTestScript("Test-CreateSecondaryRegularAndZoneRedundantDatabaseWithSourceNotZoneRedundant");
        }

        [Fact(Skip = "Location 'East US 2 EUAP' is not accepting creation of new Windows Azure SQL Database servers at this time.'")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateSecondaryRegularAndZoneRedundantDatabaseWithSourceZoneRedundant()
        {
            TestRunner.RunTestScript("Test-CreateSecondaryRegularAndZoneRedundantDatabaseWithSourceZoneRedundant");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateDatabaseCopyWithPerDBCMK()
        {
            TestRunner.RunTestScript("Test-CreateDatabaseCopyWithPerDBCMK");
        }
    }
}

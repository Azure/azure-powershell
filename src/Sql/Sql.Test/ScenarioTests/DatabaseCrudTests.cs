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
    public class DatabaseCrudTests : SqlTestRunner
    {
        public DatabaseCrudTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseCreate()
        {
            TestRunner.RunTestScript("Test-CreateDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreDatabaseCreate()
        {
            TestRunner.RunTestScript("Test-CreateVcoreDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreDatabaseCreateWithLicenseType()
        {
            TestRunner.RunTestScript("Test-CreateVcoreDatabaseWithLicenseType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateServerlessDatabase()
        {
            TestRunner.RunTestScript("Test-CreateServerlessDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseCreateWithSampleName()
        {
            TestRunner.RunTestScript("Test-CreateDatabaseWithSampleName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseCreateWithZoneRedundancy()
        {
            TestRunner.RunTestScript("Test-CreateDatabaseWithZoneRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseCreateWithMaintenanceConfigurationId()
        {
            TestRunner.RunTestScript("Test-CreateDatabaseWithMaintenanceConfigurationId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseUpdate()
        {
            TestRunner.RunTestScript("Test-UpdateDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreDatabaseUpdate()
        {
            TestRunner.RunTestScript("Test-UpdateVcoreDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreDatabaseUpdateWithLicenseType()
        {
            TestRunner.RunTestScript("Test-UpdateVcoreDatabaseLicenseType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseUpdateWithZoneRedundancy()
        {
            TestRunner.RunTestScript("Test-UpdateDatabaseWithZoneRedundant");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseUpdateWithZoneRedundancyNotSpecified()
        {
            TestRunner.RunTestScript("Test-UpdateDatabaseWithZoneRedundantNotSpecified");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseUpdateWithMaintenanceConfigurationId()
        {
            TestRunner.RunTestScript("Test-UpdateDatabaseWithMaintenanceConfigurationId");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateServerlessDatabase()
        {
            TestRunner.RunTestScript("Test-UpdateServerlessDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseRename()
        {
            TestRunner.RunTestScript("Test-RenameDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseGet()
        {
            TestRunner.RunTestScript("Test-GetDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseGetWithZoneRedundancy()
        {
            TestRunner.RunTestScript("Test-GetDatabaseWithZoneRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseGetWithMaintenanceConfigurationId()
        {
            TestRunner.RunTestScript("Test-GetDatabaseWithMaintenanceConfigurationId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseRemove()
        {
            TestRunner.RunTestScript("Test-RemoveDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseCancelOperation()
        {
            TestRunner.RunTestScript("Test-CancelDatabaseOperation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseCreateWithBackupStorageRedundancy()
        {
            TestRunner.RunTestScript("Test-CreateDatabaseWithBackupStorageRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseCreateWithGeoZoneBackupStorageRedundancy()
        {
            TestRunner.RunTestScript("Test-CreateDatabaseWithGeoZoneBackupStorageRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseGetWithBackupStorageRedundancy()
        {
            TestRunner.RunTestScript("Test-GetDatabaseWithBackupStorageRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseCreateWithLedgerEnabled()
        {
            TestRunner.RunTestScript("Test-DatabaseCreateWithLedgerEnabled");
        }
    }
}
